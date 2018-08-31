Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client

Public Class tr_angkut

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

        Dim sql As String = ""

        If get_stat_pusat() = 1 Then
            sql = "SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=50 ORDER BY A.TANGGAL DESC"
        ElseIf get_stat_pusat() = 0 Then
            sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=50 AND A.KD_STAT='{0}' ORDER BY A.TANGGAL DESC", get_kode_stat)
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
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND A.NO_BUKTI LIKE '%{0}%' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", tsfind.Text.Trim.ToUpper)

                Case 1 ' TANGGAL

                    If Not IsDate(tsfind.Text.Trim) Then

                        MsgBox("Format tanggal yang anda masukkan salah", MsgBoxStyle.Information, "Informasi")
                        tsfind.Focus()
                        Exit Sub
                    End If

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND A.TANGGAL = '{0}' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", convert_date_to_eng(tsfind.Text.Trim.ToString))

                Case 2 ' CUST ORDER
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND A.CUST_ORDER LIKE '%{0}%' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", tsfind.Text.Trim.ToUpper)

                Case 3 ' ALAMAT KIRIM

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND A.ALAMAT_TUJUAN LIKE '%{0}%' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", tsfind.Text.Trim.ToUpper)

                Case 4 ' BARANG ANGKUT

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND A.BARANG_ANGKUT LIKE '%{0}%' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", tsfind.Text.Trim.ToUpper)

                Case 5 ' SUPIR

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND B.NAMA LIKE '%{0}%' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", tsfind.Text.Trim.ToUpper)

                Case 6 ' NOPOL

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND A.NOPOL LIKE '%{0}%' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", tsfind.Text.Trim.ToUpper)

            End Select
        ElseIf get_stat_pusat() = 0 Then

            Select Case cbfind.SelectedIndex
                Case 0 ' NO BUKTI
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND A.NO_BUKTI LIKE '%{0}%' AND A.KS_STAT='{1}' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 1 ' TANGGAL

                    If Not IsDate(tsfind.Text.Trim) Then

                        MsgBox("Format tanggal yang anda masukkan salah", MsgBoxStyle.Information, "Informasi")
                        tsfind.Focus()
                        Exit Sub
                    End If

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND A.TANGGAL = '{0}' AND A.KS_STAT='{1}' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", convert_date_to_eng(tsfind.Text.Trim.ToString), get_kode_stat)

                Case 2 ' CUST ORDER
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND A.CUST_ORDER LIKE '%{0}%' AND A.KS_STAT='{1}' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 3 ' ALAMAT KIRIM

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND A.ALAMAT_TUJUAN LIKE '%{0}%' AND A.KS_STAT='{1}' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 4 ' BARANG ANGKUT

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND A.BARANG_ANGKUT LIKE '%{0}%' AND A.KS_STAT='{1}' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 5 ' SUPIR

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND B.NAMA LIKE '%{0}%' AND A.KS_STAT='{1}' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 6 ' NOPOL

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.CUST_ORDER,A.ALAMAT_ANGKUT,A.CUST_TUJUAN,A.ALAMAT_TUJUAN,A.BARANG_ANGKUT,A.JML,A.SATUAN, " & _
                    "A.NOPOL,A.KD_SUPIR,B.NAMA AS NAMA_SUPIR,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KETERANGAN FROM ADMLSP.TR_ANGKUTAN A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR= B.KD_SUPIR " & _
                        "WHERE ROWNUM <=1000 AND A.NOPOL LIKE '%{0}%' AND A.KS_STAT='{1}' ORDER BY A.TANGGAL,A.NO_BUKTI DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

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

    Private Sub hapus_data()


        If dv1.Count > 0 Then


            Dim sql As String = String.Format("delete from admlsp.TR_ANGKUTAN where no_bukti='{0}'", dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString)
            Dim sqlupdate As String = String.Format("update admlsp.TR_ANGKUTAN set user_edit='{0}',tgl_edit='{1}' where no_bukti='{2}'", userprog, convert_date_to_eng(Date.Now.ToString), dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString)


            Dim cmd As OracleCommand = Nothing
            Dim cmEdit As OracleCommand = Nothing
            Dim cmd_det As OracleCommand = Nothing
            Dim cn As OracleConnection = Nothing

            Try

                cn = classmy.open_conn_utama

                If MsgBox("Yakin akan dihapus ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi") = MsgBoxResult.Yes Then

                    open_wait()

                    Dim sqltrans As OracleTransaction = cn.BeginTransaction

                    cmEdit = New OracleCommand(sqlupdate, cn)
                    cmEdit.ExecuteNonQuery()

                    ins_to_temp_user(cn, sqlupdate, dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString, "TR_ANGKUTAN", "UPDATE", "ANGKUTAN LAIN")

                    cmd = New OracleCommand(sql, cn)
                    cmd.ExecuteNonQuery()

                    ins_to_temp_user(cn, sql, dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString, "TR_ANGKUTAN", "DELETE", "ANGKUTAN LAIN")

                    sqltrans.Commit()
                    opendata()

                    close_wait()

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

    Private Sub tr_angkut_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        Using tr_angk2 As New tr_angkut2(True, dv1, 0) With {.StartPosition = FormStartPosition.CenterScreen}
            tr_angk2.ShowDialog(Me)
        End Using

    End Sub

    Private Sub tsedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsedit.Click

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Using tr_angk2 As New tr_angkut2(False, dv1, bs1.Position) With {.StartPosition = FormStartPosition.CenterScreen}
            tr_angk2.ShowDialog(Me)
        End Using

    End Sub

End Class