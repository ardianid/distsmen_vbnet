Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client

Public Class ms_giro

    Private bs1 As BindingSource
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
        Dim ds As DataSet
        Dim dvmanager As Data.DataViewManager

        Dim sql As String = ""

        If get_stat_pusat() = 1 Then
            sql = "SELECT A.KD_TOKO,B.NAMA_TOKO,B.ALAMAT AS ALAMAT_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.STATUS,A.BANK,A.NILAI,A.NILAI_PAKAI,A.KETERANGAN " & _
                "FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE ROWNUM <= 50 ORDER BY A.TGL_TEMPO,A.NO_GIRO DESC"
        ElseIf get_stat_pusat() = 0 Then
            sql = String.Format("SELECT A.KD_TOKO,B.NAMA_TOKO,B.ALAMAT AS ALAMAT_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.STATUS,A.BANK,A.NILAI,A.NILAI_PAKAI,A.KETERANGAN " & _
                "FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE ROWNUM <= 50 AND A.KD_STAT='{0}' ORDER BY A.TGL_TEMPO,A.NO_GIRO DESC", get_kode_stat)
        Else
            Exit Sub
        End If

        grid1.DataSource = Nothing


        Try

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


        Catch ex As OracleException
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
        Dim ds As DataSet
        Dim dvmanager As Data.DataViewManager

        grid1.DataSource = Nothing

        Dim sql As String = ""

        If get_stat_pusat() = 1 Then

            Select Case cbfind.SelectedIndex
                Case 0 ' NO GIRO
                    sql = String.Format("SELECT A.KD_TOKO,B.NAMA_TOKO,B.ALAMAT AS ALAMAT_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.STATUS,A.BANK,A.NILAI,A.NILAI_PAKAI,A.KETERANGAN " & _
                    "FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE ROWNUM <= 1000 AND A.NO_GIRO LIKE '%{0}%' ORDER BY A.TGL_TEMPO,A.NO_GIRO DESC", tsfind.Text.Trim.ToUpper)
                Case 1 ' TANGGAL JATUH TEMPO

                    If Not IsDate(tsfind.Text.Trim) Then

                        MsgBox("Format tanggal yang anda masukkan salah", MsgBoxStyle.Information, "Informasi")
                        tsfind.Focus()
                        Exit Sub
                    End If

                    sql = String.Format("SELECT A.KD_TOKO,B.NAMA_TOKO,B.ALAMAT AS ALAMAT_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.STATUS,A.BANK,A.NILAI,A.NILAI_PAKAI,A.KETERANGAN " & _
                    "FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE ROWNUM <= 1000 AND A.TGL_TEMPO='{0}' ORDER BY A.TGL_TEMPO,A.NO_GIRO DESC", convert_date_to_eng(tsfind.Text.Trim))
                Case 2 ' BANK
                    sql = String.Format("SELECT A.KD_TOKO,B.NAMA_TOKO,B.ALAMAT AS ALAMAT_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.STATUS,A.BANK,A.NILAI,A.NILAI_PAKAI,A.KETERANGAN " & _
                    "FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE ROWNUM <= 1000 AND A.BANK LIKE '%{0}%' ORDER BY A.TGL_TEMPO,A.NO_GIRO DESC", tsfind.Text.Trim.ToUpper)
                Case 3 ' STATUS
                    sql = String.Format("SELECT A.KD_TOKO,B.NAMA_TOKO,B.ALAMAT AS ALAMAT_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.STATUS,A.BANK,A.NILAI,A.NILAI_PAKAI,A.KETERANGAN " & _
                    "FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE ROWNUM <= 1000 AND A.STATUS LIKE '%{0}%' ORDER BY A.TGL_TEMPO,A.NO_GIRO DESC", tsfind.Text.Trim.ToUpper)
                Case 4 ' NAMA TOKO
                    sql = String.Format("SELECT A.KD_TOKO,B.NAMA_TOKO,B.ALAMAT AS ALAMAT_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.STATUS,A.BANK,A.NILAI,A.NILAI_PAKAI,A.KETERANGAN " & _
                    "FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE ROWNUM <= 1000 AND B.NAMA_TOKO LIKE '%{0}%' ORDER BY A.TGL_TEMPO,A.NO_GIRO DESC", tsfind.Text.Trim.ToUpper)
            End Select

        ElseIf get_stat_pusat() = 0 Then

            Select Case cbfind.SelectedIndex
                Case 0 ' NO GIRO
                    sql = String.Format("SELECT A.KD_TOKO,B.NAMA_TOKO,B.ALAMAT AS ALAMAT_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.STATUS,A.BANK,A.NILAI,A.NILAI_PAKAI,A.KETERANGAN " & _
                    "FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE ROWNUM <= 1000 AND A.NO_GIRO LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TGL_TEMPO,A.NO_GIRO DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)
                Case 1 ' TANGGAL JATUH TEMPO

                    If Not IsDate(tsfind.Text.Trim) Then

                        MsgBox("Format tanggal yang anda masukkan salah", MsgBoxStyle.Information, "Informasi")
                        tsfind.Focus()
                        Exit Sub
                    End If

                    sql = String.Format("SELECT A.KD_TOKO,B.NAMA_TOKO,B.ALAMAT AS ALAMAT_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.STATUS,A.BANK,A.NILAI,A.NILAI_PAKAI,A.KETERANGAN " & _
                    "FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE ROWNUM <= 1000 AND A.TGL_TEMPO='{0}' AND A.KD_STAT='{1}' ORDER BY A.TGL_TEMPO,A.NO_GIRO DESC", convert_date_to_eng(tsfind.Text.Trim), get_kode_stat)
                Case 2 ' BANK
                    sql = String.Format("SELECT A.KD_TOKO,B.NAMA_TOKO,B.ALAMAT AS ALAMAT_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.STATUS,A.BANK,A.NILAI,A.NILAI_PAKAI,A.KETERANGAN " & _
                    "FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE ROWNUM <= 1000 AND A.BANK LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TGL_TEMPO,A.NO_GIRO DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)
                Case 3 ' STATUS
                    sql = String.Format("SELECT A.KD_TOKO,B.NAMA_TOKO,B.ALAMAT AS ALAMAT_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.STATUS,A.BANK,A.NILAI,A.NILAI_PAKAI,A.KETERANGAN " & _
                    "FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE ROWNUM <= 1000 AND A.STATUS LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TGL_TEMPO,A.NO_GIRO DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)
                Case 4 ' NAMA TOKO
                    sql = String.Format("SELECT A.KD_TOKO,B.NAMA_TOKO,B.ALAMAT AS ALAMAT_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.STATUS,A.BANK,A.NILAI,A.NILAI_PAKAI,A.KETERANGAN " & _
                    "FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE ROWNUM <= 1000 AND B.NAMA_TOKO LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TGL_TEMPO,A.NO_GIRO DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)
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

            If dv1(bs1.Position)("STATUS").ToString.ToUpper = "CAIR" Then
                MsgBox("Giro telah cair, data tidak dapat dihapus", MsgBoxStyle.Information, "Informasi")
                Exit Sub
            End If

            If dv1(bs1.Position)("NILAI_PAKAI").ToString > 0 Then
                MsgBox("Giro telah dipakai untuk pelunasan, data tidak dapat dihapus", MsgBoxStyle.Information, "Informasi")
                Exit Sub
            End If

            Dim sql As String = String.Format("delete from admlsp.ms_giro where no_giro='{0}'", dv1(BindingContext(bs1).Position)("NO_GIRO").ToString)

            Dim cmd As OracleCommand = Nothing
            Dim cn As OracleConnection = Nothing

            Try

                If MsgBox("Yakin akan dihapus ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi") = MsgBoxResult.Yes Then

                    open_wait()

                    cn = classmy.open_conn_utama

                    Dim sqltrans As OracleTransaction = cn.BeginTransaction

                    cmd = New OracleCommand(sql, cn)
                    cmd.ExecuteNonQuery()

                    ins_to_temp_user(cn, sql, dv1(BindingContext(bs1).Position)("NO_GIRO").ToString, "MS_GIRO", "DELETE", "GIRO")

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

    Public Function cek_status(ByVal no_giro As String) As String

        Dim sql As String = ""
        Dim cmd As OracleCommand = Nothing
        Dim dread As OracleDataReader = Nothing
        Dim cn As OracleConnection = Nothing

        Dim stat As String = ""

        sql = String.Format("select a.STATUS from admlsp.ms_giro a where a.NO_GIRO='{0}'", no_giro)

        Try

            cn = classmy.open_conn_utama

            cmd = New OracleCommand(sql, cn)
            dread = cmd.ExecuteReader

            If dread.Read Then

                stat = dread(0).ToString
                dread.Close()

            Else
                dread.Close()
                stat = ""
            End If


        Catch ex As OracleException
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

        Return stat

    End Function

    Public Function cek_nilaipakai(ByVal no_giro As String) As Double

        Dim sql As String = ""
        Dim cmd As OracleCommand = Nothing
        Dim dread As OracleDataReader = Nothing
        Dim cn As OracleConnection = Nothing

        Dim jml As Double = 0

        sql = String.Format("select a.NILAI_PAKAI from admlsp.ms_giro a where a.NO_GIRO='{0}'", no_giro)

        Try

            cn = classmy.open_conn_utama

            cmd = New OracleCommand(sql, cn)
            dread = cmd.ExecuteReader

            If dread.Read Then

                jml = dread(0).ToString
                dread.Close()

            Else
                dread.Close()
                jml = 0
            End If


        Catch ex As OracleException
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

        Return jml

    End Function

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click
        cari()
    End Sub

    Private Sub tsfind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsfind.KeyDown
        If e.KeyCode = 13 Then
            cari()
        End If
    End Sub

    Private Sub tsdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdel.Click

        If cek_status(dv1(bs1.Position)("NO_GIRO").ToString.ToUpper) = "CAIR" Then
            MsgBox("Giro telah cair, data tidak dapat dihapus", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        End If

        If cek_nilaipakai(dv1(bs1.Position)("NO_GIRO").ToString) > 0 Then
            MsgBox("Giro telah dipakai untuk pelunasan, data tidak dapat dihapus", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        End If

        hapus_data()
    End Sub

    Private Sub ms_giro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cbfind.SelectedIndex = 0
        opendata()
    End Sub

    Private Sub tsadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsadd.Click

        Using fms_giro2 As New ms_giro2(True, dv1, 0)
            fms_giro2.StartPosition = FormStartPosition.CenterScreen
            fms_giro2.ShowDialog(Me)
        End Using

    End Sub

    Private Sub tsedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsedit.Click

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        If cek_status(dv1(bs1.Position)("NO_GIRO").ToString.ToUpper) = "CAIR" Then
            MsgBox("Giro telah cair, data tidak dapat dirubah", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        End If

        If cek_nilaipakai(dv1(bs1.Position)("NO_GIRO").ToString) > 0 Then
            MsgBox("Giro telah dipakai untuk pelunasan, data tidak dapat dirubah", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        End If

        Using fms_giro2 As New ms_giro2(False, dv1, bs1.Position)
            fms_giro2.StartPosition = FormStartPosition.CenterScreen
            fms_giro2.ShowDialog(Me)
        End Using

    End Sub

End Class