Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client

Public Class tr_giro_cair

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

        Else

        End If

        If Convert.ToInt16(rows(0)("T_DEL")) = 1 Then

        Else

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
        Dim sql As String = ""

        If get_stat_pusat() = 1 Then

            sql = "SELECT A.NO_BUKTI,A.TANGGAL,A.USER_ADD,A.KETERANGAN FROM ADMLSP.TR_PENCAIRAN_GIRO A WHERE ROWNUM <= 50 ORDER BY A.TANGGAL DESC"

        ElseIf get_stat_pusat() = 0 Then

            sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.USER_ADD,A.KETERANGAN FROM ADMLSP.TR_PENCAIRAN_GIRO A WHERE A.KD_STAT='{0}' AND ROWNUM <= 50  ORDER BY A.TANGGAL DESC", get_kode_stat)

        Else
            Exit Sub
        End If



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

        Dim cn As OracleConnection = Nothing

        grid1.DataSource = Nothing

        Dim sql As String = ""

        If get_stat_pusat() = 1 Then

            Select Case cbfind.SelectedIndex
                Case 0 ' NO BUKTI

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.USER_ADD,A.KETERANGAN FROM ADMLSP.TR_PENCAIRAN_GIRO A WHERE ROWNUM <= 1000  AND A.NO_BUKTI LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)
                Case 1 ' TANGGAL BUKTI

                    If Not IsDate(tsfind.Text.Trim) Then

                        MsgBox("Format tanggal yang anda masukkan salah", MsgBoxStyle.Information, "Informasi")
                        tsfind.Focus()
                        Exit Sub
                    End If

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.USER_ADD,A.KETERANGAN FROM ADMLSP.TR_PENCAIRAN_GIRO A WHERE ROWNUM <= 1000  AND A.TANGGAL='{0}' ORDER BY A.TANGGAL DESC", convert_date_to_eng(tsfind.Text.Trim.ToString))

                Case 2 ' USER

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.USER_ADD,A.KETERANGAN FROM ADMLSP.TR_PENCAIRAN_GIRO A WHERE ROWNUM <= 1000  AND A.USER_ADD LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)

            End Select

        ElseIf get_stat_pusat() = 0 Then

            Select Case cbfind.SelectedIndex
                Case 0 ' NO BUKTI

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.USER_ADD,A.KETERANGAN FROM ADMLSP.TR_PENCAIRAN_GIRO A WHERE ROWNUM <= 1000  AND A.NO_BUKTI LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)
                Case 1 ' TANGGAL BUKTI

                    If Not IsDate(tsfind.Text.Trim) Then

                        MsgBox("Format tanggal yang anda masukkan salah", MsgBoxStyle.Information, "Informasi")
                        tsfind.Focus()
                        Exit Sub
                    End If

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.USER_ADD,A.KETERANGAN FROM ADMLSP.TR_PENCAIRAN_GIRO A WHERE ROWNUM <= 1000  AND A.TANGGAL='{0}' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", convert_date_to_eng(tsfind.Text.Trim.ToString), get_kode_stat)

                Case 2 ' USER

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.USER_ADD,A.KETERANGAN FROM ADMLSP.TR_PENCAIRAN_GIRO A WHERE ROWNUM <= 1000  AND A.USER_ADD LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

            End Select

        Else
            Exit Sub
        End If



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

    Private Sub tr_girocair_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub tsadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsadd.Click

        Using tr_girocair2 As New tr_giro_cair2(dv1) With {.StartPosition = FormStartPosition.CenterScreen}
            tr_girocair2.ShowDialog(Me)
        End Using

    End Sub

End Class