﻿Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client

Public Class ms_sales

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
        Dim sql As String = String.Empty

        If get_stat_pusat() = 1 Then

            sql = "select a.aktif,b.nama as status,b.status as status2, a.kd_sales,a.nama,a.alamat,a.telp1,a.telp2,a.tgl_masuk,b.kode,a.jenis_pot" & _
                " from admlsp.ms_sales a inner join admlsp.ms_stat b on a.kd_stat=b.kode order by b.nama,a.kd_sales asc"

        ElseIf get_stat_pusat() = 0 Then

            sql = String.Format("select a.aktif,b.nama as status,b.status as status2, a.kd_sales,a.nama,a.alamat,a.telp1,a.telp2,a.tgl_masuk,b.kode,a.jenis_pot" & _
                " from admlsp.ms_sales a inner join admlsp.ms_stat b on a.kd_stat=b.kode where b.kode='{0}' order by b.nama,a.kd_sales asc", get_kode_stat)

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


            bs1 = New BindingSource() With {.DataSource = dv1}
            bn1.BindingSource = bs1

            grid1.DataSource = bs1
            gridview.RefreshData()


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
                Case 0
                    sql = String.Format("select a.aktif,b.nama as status,b.status as status2,a.kd_sales,a.nama,a.alamat,a.telp1,a.telp2,a.tgl_masuk,b.kode,a.jenis_pot" & _
                    " from admlsp.ms_sales a inner join admlsp.ms_stat b on a.kd_stat=b.kode where a.kd_sales like '%{0}%' order by b.nama,a.kd_sales asc", tsfind.Text.Trim.ToUpper)
                Case 1
                    sql = String.Format("select a.aktif,b.nama as status,b.status as status2,a.kd_sales,a.nama,a.alamat,a.telp1,a.telp2,a.tgl_masuk,b.kode,a.jenis_pot" & _
                    " from admlsp.ms_sales a inner join admlsp.ms_stat b on a.kd_stat=b.kode where a.nama like '%{0}%' order by b.nama,a.kd_sales asc", tsfind.Text.Trim.ToUpper)
                Case 2
                    sql = String.Format("select a.aktif,b.nama as status,b.status as status2,a.kd_sales,a.nama,a.alamat,a.telp1,a.telp2,a.tgl_masuk,b.kode,a.jenis_pot" & _
                    " from admlsp.ms_sales a inner join admlsp.ms_stat b on a.kd_stat=b.kode where a.alamat like '%{0}%' order by b.nama,a.kd_sales asc", tsfind.Text.Trim.ToUpper)
            End Select

        ElseIf get_stat_pusat() = 0 Then

            Select Case cbfind.SelectedIndex
                Case 0
                    sql = String.Format("select a.aktif,b.nama as status,b.status as status2,a.kd_sales,a.nama,a.alamat,a.telp1,a.telp2,a.tgl_masuk,a.jenis_pot" & _
                    " from admlsp.ms_sales a inner join admlsp.ms_stat b on a.kd_stat=b.kode where a.kd_sales like '%{0}%' and b.kode='{1}' order by b.nama,a.kd_sales asc", tsfind.Text.Trim.ToUpper, get_kode_stat)
                Case 1
                    sql = String.Format("select a.aktif,b.nama as status,b.status as status2,a.kd_sales,a.nama,a.alamat,a.telp1,a.telp2,a.tgl_masuk,a.jenis_pot" & _
                    " from admlsp.ms_sales a inner join admlsp.ms_stat b on a.kd_stat=b.kode where a.nama like '%{0}%' and b.kode='{1}' order by b.nama,a.kd_sales asc", tsfind.Text.Trim.ToUpper, get_kode_stat)
                Case 2
                    sql = String.Format("select a.aktif,b.nama as status,b.status as status2,a.kd_sales,a.nama,a.alamat,a.telp1,a.telp2,a.tgl_masuk,a.jenis_pot" & _
                    " from admlsp.ms_sales a inner join admlsp.ms_stat b on a.kd_stat=b.kode where a.alamat like '%{0}%' and b.kode='{1}' order by b.nama,a.kd_sales asc", tsfind.Text.Trim.ToUpper, get_kode_stat)
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
            gridview.RefreshData()

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


            Dim sql As String = String.Format("delete from admlsp.ms_sales where kd_sales='{0}'", dv1(BindingContext(bs1).Position)("KD_SALES").ToString)

            Dim cmd As OracleCommand = Nothing
            Dim cn As OracleConnection = Nothing

            Try

                If MsgBox("Yakin akan dihapus ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi") = MsgBoxResult.Yes Then

                    open_wait()

                    cn = classmy.open_conn_utama

                    Dim sqltrans As OracleTransaction = cn.BeginTransaction

                    cmd = New OracleCommand(sql, cn)
                    cmd.ExecuteNonQuery()

                    If classmy.insert_to_temp_user(cn, sql, dv1(BindingContext(bs1).Position)("KD_SALES").ToString, "MS_SALES", "DELETE", "SALES") = False Then
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

    Private Sub ms_sales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        Using fms_sales2 As New ms_sales2(True, dv1, 0) With {.StartPosition = FormStartPosition.CenterScreen}
            fms_sales2.ShowDialog(Me)
        End Using

    End Sub

    Private Sub tsedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsedit.Click

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Using fms_sales2 As New ms_sales2(False, dv1, bs1.Position) With {.StartPosition = FormStartPosition.CenterScreen}
            fms_sales2.ShowDialog(Me)
        End Using

    End Sub

End Class