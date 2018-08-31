Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fsl_selisih_rekap

    Private Sub isi_combo()

        Dim sql As String = ""

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv As DataView
        Dim statpusat As Boolean = True

        If get_stat_pusat() = 1 Then
            statpusat = True
            sql = "select a.KODE,a.NAMA from admlsp.ms_stat a"
        Else
            statpusat = False
            sql = String.Format("select a.KODE,a.NAMA from admlsp.ms_stat a where a.KODE='{0}'", get_kode_stat)
        End If

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            If statpusat = True Then

                Dim orow As DataRow

                orow = ds.Tables(0).NewRow

                orow("KODE") = "ALL"
                orow("NAMA") = "All"

                ds.Tables(0).Rows.InsertAt(orow, 0)


            End If

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv = dvm.CreateDataView(ds.Tables(0))

            cbarea.Properties.DataSource = dv


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

    Private Sub isi_combo2()

        Dim SQL As String = String.Empty

            SQL = "select kode,nama from admlsp.ms_kab"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv2 As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            If get_stat_pusat() = 1 Then

                Dim orow As DataRow

                orow = ds.Tables(0).NewRow

                orow("KODE") = "All"
                orow("NAMA") = "All"

                ds.Tables(0).Rows.InsertAt(orow, 0)


            End If

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv2 = dvm.CreateDataView(ds.Tables(0))

            cbkab.Properties.DataSource = dv2


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

    Private Sub ttgl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        If e.KeyCode = 13 Then
            ttgl2.Focus()
        End If
    End Sub

    Private Sub ttgl2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl2.KeyDown
        If e.KeyCode = 13 Then
            cbkab.Focus()
        End If
    End Sub

    Private Sub cbkab_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbkab.KeyDown
        If e.KeyCode = 13 Then
            cbarea.Focus()
        End If
    End Sub

    Private Sub cbarea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbarea.KeyDown
        If e.KeyCode = 13 Then
            btpre.Focus()
        End If
    End Sub

    Private Sub fsl_ganti_spare_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ttgl.Focus()
    End Sub

    Private Sub fsl_ganti_spare_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RadioGroup1.SelectedIndex = 0
        RadioGroup2.SelectedIndex = 0

        isi_combo()
        isi_combo2()

        ttgl.EditValue = Date.Now
        ttgl2.EditValue = Date.Now

        cbkab.ItemIndex = 0
        cbarea.ItemIndex = 0
    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        Dim semuajual As Boolean = True
        If RadioGroup2.SelectedIndex = 0 Then
            semuajual = True
        Else
            semuajual = False
        End If


        If RadioGroup1.SelectedIndex = 1 Then

            Dim fpr_kso_Detail As New pr_jual_beli_detail(ttgl.EditValue, ttgl2.EditValue, cbarea.EditValue, cbarea.Text.Trim, cbkab.EditValue) With {.WindowState = FormWindowState.Maximized}
            fpr_kso_Detail.Show()

        Else

            Dim fpr_kso_Detail As New pr_jual_beli_rekap(ttgl.EditValue, ttgl2.EditValue, cbarea.EditValue, cbarea.Text.Trim, cbkab.EditValue, semuajual) With {.WindowState = FormWindowState.Maximized}
            fpr_kso_Detail.Show()

        End If

    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioGroup1.SelectedIndexChanged

        If RadioGroup1.SelectedIndex = 0 Then

            RadioGroup2.Enabled = True
            '  RadioGroup2.SelectedIndex = 0

        Else

            RadioGroup2.Enabled = False
            RadioGroup2.SelectedIndex = 0

        End If

    End Sub
End Class