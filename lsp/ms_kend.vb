Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client

Public Class ms_kend

    Private bs1 As BindingSource
    Private ds As DataSet
    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Get_Aksesform()

    End Sub

    Private Sub Get_Aksesform()

        Dim rows() As DataRow = dtmenu.Select(String.Format("NAMAFORM='{0}'", Me.Name.ToUpper.ToString))

        If Convert.ToInt16(rows(0)("T_ADD")) = 1 Then
            tsadd.Enabled = True
        Else
            tsadd.Enabled = False
        End If

        If Convert.ToInt16(rows(0)("T_EDIT")) = 1 Then
            tsedit.Enabled = True
        Else
            tsedit.Enabled = False
        End If

        If Convert.ToInt16(rows(0)("T_DEL")) = 1 Then
            tsdel.Enabled = True
        Else
            tsdel.Enabled = False
        End If

        If Convert.ToInt16(rows(0)("T_CETAK")) = 1 Then

        Else

        End If

    End Sub

    Sub refresh_data()
        opendata()
    End Sub

    Private Sub opendata()

        tsfind.Text = ""
        Dim cn As OracleConnection = Nothing

        Const sql As String = "select a.AKTIF,a.NOPOL,a.TGL_BELI,a.TGL_BERLAKU,a.TGL_PAJAK || '/' || a.BLN_PAJAK as TGLB_PAJAK," & _
                    "a.BLN_KIR1 || '/' || a.BLN_KIR2 as BLN_KIR,a.KETERANGAN,a.TGL_PAJAK,a.BLN_PAJAK,a.BLN_KIR1,a.BLN_KIR2 from admlsp.ms_kendaraan a order by a.NOPOL asc"

        grid1.DataSource = Nothing


        Try

            open_wait()

            dv1 = Nothing

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))


            bs1 = New BindingSource
            bs1.DataSource = dv1
            bn1.BindingSource = bs1

            grid1.DataSource = bs1

            close_wait()

        Catch ex As OracleException
            close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally


            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

    End Sub

    Private Sub cari()

        If tsfind.Text = "" Then
            opendata()
            Exit Sub
        End If

        Dim cn As OracleConnection = Nothing

        grid1.DataSource = Nothing

        Dim sql As String = ""

        Select Case cbfind.SelectedIndex
            Case 0
                sql = String.Format("select a.AKTIF,a.NOPOL,a.TGL_BELI,a.TGL_BERLAKU,a.TGL_PAJAK || '/' || a.BLN_PAJAK as TGLB_PAJAK," & _
                    "a.BLN_KIR1 || '/' || a.BLN_KIR2 as BLN_KIR,a.KETERANGAN,a.TGL_PAJAK,a.BLN_PAJAK,a.BLN_KIR1,a.BLN_KIR2 from admlsp.ms_kendaraan a where a.NOPOL='{0}' order by a.NOPOL asc", tsfind.Text.Trim.ToUpper)
            Case 1

                If Not IsDate(tsfind.Text.Trim) Then
                    MsgBox("Tanggal yang anda masukkan salah...", MsgBoxStyle.Information, "Informasi")
                    tsfind.Focus()
                    Exit Sub
                End If

                Dim tgl As String = convert_date_to_eng(tsfind.Text.Trim.ToString)

                sql = String.Format("select a.AKTIF,a.NOPOL,a.TGL_BELI,a.TGL_BERLAKU,a.TGL_PAJAK || '/' || a.BLN_PAJAK as TGLB_PAJAK," & _
                    "a.BLN_KIR1 || '/' || a.BLN_KIR2 as BLN_KIR,a.KETERANGAN,a.TGL_PAJAK,a.BLN_PAJAK,a.BLN_KIR1,a.BLN_KIR2 from admlsp.ms_kendaraan a where a.TGL_BELI='{0}' order by a.NOPOL asc", tgl)
            Case 2
                If Not IsDate(tsfind.Text.Trim) Then
                    MsgBox("Tanggal yang anda masukkan salah...", MsgBoxStyle.Information, "Informasi")
                    tsfind.Focus()
                    Exit Sub
                End If

                Dim tgl2 As String = convert_date_to_eng(tsfind.Text.Trim.ToString)

                sql = String.Format("select a.AKTIF,a.NOPOL,a.TGL_BELI,a.TGL_BERLAKU,a.TGL_PAJAK || '/' || a.BLN_PAJAK as TGLB_PAJAK," & _
                    "a.BLN_KIR1 || '/' || a.BLN_KIR2 as BLN_KIR,a.KETERANGAN,a.TGL_PAJAK,a.BLN_PAJAK,a.BLN_KIR1,a.BLN_KIR2 from admlsp.ms_kendaraan a where a.TGL_BERLAKU='{0}' order by a.NOPOL asc", tgl2)
            Case 3

                Dim myindx = tsfind.Text.Trim.IndexOf("/")

                If myindx <= 0 Then
                    MsgBox("Periksa kembali data yang akan anda cari", MsgBoxStyle.Information, "Informasi")
                    tsfind.Focus()
                    Exit Sub
                End If


                sql = String.Format("select a.AKTIF,a.NOPOL,a.TGL_BELI,a.TGL_BERLAKU,a.TGL_PAJAK || '/' || a.BLN_PAJAK as TGLB_PAJAK," & _
                    "a.BLN_KIR1 || '/' || a.BLN_KIR2 as BLN_KIR,a.KETERANGAN,a.TGL_PAJAK,a.BLN_PAJAK,a.BLN_KIR1,a.BLN_KIR2 from admlsp.ms_kendaraan a where a.TGL_PAJAK={0} and a.BLN_PAJAK={1} order by a.NOPOL asc", tsfind.Text.Trim.Substring(0, myindx), tsfind.Text.Trim.Substring(myindx + 1, Len(tsfind.Text.Trim) - (myindx + 1)))

            Case 4

                Dim myindx2 = tsfind.Text.Trim.IndexOf("/")

                If myindx2 <= 0 Then
                    MsgBox("Periksa kembali data yang akan anda cari", MsgBoxStyle.Information, "Informasi")
                    tsfind.Focus()
                    Exit Sub
                End If

                sql = String.Format("select a.AKTIF,a.NOPOL,a.TGL_BELI,a.TGL_BERLAKU,a.TGL_PAJAK || '/' || a.BLN_PAJAK as TGLB_PAJAK," & _
                   "a.BLN_KIR1 || '/' || a.BLN_KIR2 as BLN_KIR,a.KETERANGAN,a.TGL_PAJAK,a.BLN_PAJAK,a.BLN_KIR1,a.BLN_KIR2 from admlsp.ms_kendaraan a where a.BLN_KIR1={0} and a.BLN_KIR2={1} order by a.NOPOL asc", tsfind.Text.Trim.Substring(0, myindx2), tsfind.Text.Trim.Substring(myindx2 + 1, Len(tsfind.Text.Trim) - (myindx2 + 1)))

        End Select

        Try

            open_wait()

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            bs1.DataSource = dv1
            bn1.BindingSource = bs1

            grid1.DataSource = bs1

            close_wait()

        Catch ex As Exception
            close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Sub hapus_data()


        If dv1.Count > 0 Then


            Dim sql As String = String.Format("delete from admlsp.ms_kendaraan where nopol='{0}'", dv1(BindingContext(bs1).Position)("NOPOL").ToString)

            Dim cmd As OracleCommand = Nothing
            Dim cn As OracleConnection = Nothing

            Try

                If MsgBox("Yakin akan dihapus ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi") = MsgBoxResult.Yes Then

                    open_wait()

                    cn = classmy.open_conn_utama

                    Dim sqltrans As OracleTransaction = cn.BeginTransaction

                    cmd = New OracleCommand(sql, cn)
                    cmd.ExecuteNonQuery()

                    If classmy.insert_to_temp_user(cn, sql, dv1(BindingContext(bs1).Position)("NOPOL").ToString, "MS_KENDARAAN", "DELETE", "KENDARAAN") = False Then
                        close_wait()
                        MsgBox("Kesalahan data Temp User", MsgBoxStyle.Critical, "Informasi")
                    Else
                        sqltrans.Commit()
                        opendata()

                        close_wait()
                    End If

                End If

            Catch ex As OracleException
                close_wait()
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            Finally

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If

            End Try


        End If


    End Sub

    Private Sub ms_supir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cbfind.SelectedIndex = 0
        opendata()
    End Sub

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click
        cari()
    End Sub

    Private Sub tsfind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsfind.KeyDown
        If e.KeyCode = 13 Then
            cari()
        End If
    End Sub

    Private Sub tsdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdel.Click
        hapus_data()
    End Sub

    Private Sub tsadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsadd.Click

        Using fms_kend2 As New ms_kend2(True, dv1, 0) With {.StartPosition = FormStartPosition.CenterScreen}
            fms_kend2.ShowDialog(Me)
        End Using

    End Sub

    Private Sub tsedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsedit.Click

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Using fms_kend2 As New ms_kend2(False, dv1, bs1.Position) With {.StartPosition = FormStartPosition.CenterScreen}
            fms_kend2.ShowDialog(Me)
        End Using

    End Sub

End Class