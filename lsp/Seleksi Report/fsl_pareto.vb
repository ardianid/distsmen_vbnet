Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fsl_pareto

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
                orow("NAMA") = "<<- ALL ->>"

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

    Private Sub isi_combo_propinsi()

        Dim SQL As String = String.Empty

        'If get_stat_pusat() = 1 Then
        SQL = "SELECT A.KODE,A.NAMA FROM ADMLSP.MS_PROP A"
        'Else
        'SQL = String.Format("SELECT A.KODE,A.NAMA,A.ALAMAT FROM ADMLSP.MS_KSO A where A.KD_STAT='{0}'", get_kode_stat)
        'End If

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv2 As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(SQL, cn)

            If get_stat_pusat() = 1 Then

                Dim orow As DataRow

                orow = ds.Tables(0).NewRow

                orow("KODE") = "All"
                orow("NAMA") = "All"

                ds.Tables(0).Rows.InsertAt(orow, 0)


            End If

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv2 = dvm.CreateDataView(ds.Tables(0))

            cbprop.Properties.DataSource = dv2

            cbprop.ItemIndex = 0


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

    Private Sub isi_combo_kabupaten()

        Dim SQL As String = String.Empty

        If Not (cbprop.EditValue.ToString.ToUpper = "ALL") Then
            SQL = String.Format("SELECT A.KODE,A.NAMA FROM ADMLSP.MS_KAB A WHERE A.KODE_PROP='{0}'", cbprop.EditValue)
        Else
            SQL = "SELECT A.KODE,A.NAMA FROM ADMLSP.MS_KAB A"
        End If


        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv2 As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(SQL, cn)

            If get_stat_pusat() = 1 Then

                Dim orow As DataRow

                orow = ds.Tables(0).NewRow

                orow("KODE") = "All"
                orow("NAMA") = "All"

                ds.Tables(0).Rows.InsertAt(orow, 0)


            End If

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv2 = dvm.CreateDataView(ds.Tables(0))

            cbkab.Properties.DataSource = Nothing

            cbkab.Properties.DataSource = dv2

            cbkab.ItemIndex = 0

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

    Private Sub isi_combo_kecamatan()

        Dim SQL As String = String.Empty

        If Not (cbprop.EditValue.ToString.ToUpper = "ALL") Then


            If Not (cbkab.EditValue.ToString.ToUpper = "ALL") Then
                SQL = String.Format("SELECT ms_kec.kode, ms_kec.nama FROM admlsp.ms_prop ms_prop, admlsp.ms_kab ms_kab, admlsp.ms_kec ms_kec " & _
                    "WHERE ((ms_kab.kode_prop = ms_prop.kode) AND (ms_kec.kode_kab = ms_kab.kode) AND (ms_prop.kode='{0}') AND (ms_kab.kode='{1}')) order by ms_kec.nama", cbprop.EditValue, cbkab.EditValue)
            Else
                SQL = String.Format("SELECT ms_kec.kode, ms_kec.nama FROM admlsp.ms_prop ms_prop, admlsp.ms_kab ms_kab, admlsp.ms_kec ms_kec " & _
                    "WHERE ((ms_kab.kode_prop = ms_prop.kode) AND (ms_kec.kode_kab = ms_kab.kode) AND (ms_prop.kode='{0}')) order by ms_kec.nama", cbprop.EditValue)
            End If


        Else

            If Not (cbkab.EditValue.ToString.ToUpper = "ALL") Then
                SQL = String.Format("SELECT ms_kec.kode, ms_kec.nama FROM admlsp.ms_prop ms_prop, admlsp.ms_kab ms_kab, admlsp.ms_kec ms_kec " & _
                    "WHERE ((ms_kab.kode_prop = ms_prop.kode) AND (ms_kec.kode_kab = ms_kab.kode)  AND (ms_kab.kode='{0}')) order by ms_kec.nama", cbkab.EditValue)
            Else
                SQL = "SELECT ms_kec.kode, ms_kec.nama FROM admlsp.ms_prop ms_prop, admlsp.ms_kab ms_kab, admlsp.ms_kec ms_kec " & _
                    "WHERE ((ms_kab.kode_prop = ms_prop.kode) AND (ms_kec.kode_kab = ms_kab.kode)) order by ms_kec.nama"
            End If

        End If


        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv2 As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(SQL, cn)

            If get_stat_pusat() = 1 Then

                Dim orow As DataRow

                orow = ds.Tables(0).NewRow

                orow("KODE") = "All"
                orow("NAMA") = "All"

                ds.Tables(0).Rows.InsertAt(orow, 0)


            End If

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv2 = dvm.CreateDataView(ds.Tables(0))

            cbkec.Properties.DataSource = Nothing

            cbkec.Properties.DataSource = dv2

            cbkec.ItemIndex = 0

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

    Private Sub fsl_ganti_spare_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ttgl.Focus()
    End Sub

    Private Sub fsl_ganti_spare_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        isi_combo()
        isi_combo_propinsi()

        ttgl.EditValue = Date.Now
        ttgl2.EditValue = Date.Now

        cbarea.ItemIndex = 0

    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        Dim fpr_kso_Detail As New pr_pareto(ttgl.EditValue, ttgl2.EditValue, cbarea.EditValue, cbarea.Text.Trim, cbprop.EditValue, cbkab.EditValue, cbkec.EditValue) With {.WindowState = FormWindowState.Maximized}
        fpr_kso_Detail.Show()

    End Sub

    Private Sub cbprop_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbprop.EditValueChanged
        isi_combo_kabupaten()
        isi_combo_kecamatan()
    End Sub

    Private Sub cbkab_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbkab.EditValueChanged
        isi_combo_kecamatan()
    End Sub

    Private Sub ttgl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        If e.KeyCode = 13 Then
            ttgl2.Focus()
        End If
    End Sub

    Private Sub ttgl2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl2.KeyDown
        If e.KeyCode = 13 Then
            cbprop.Focus()
        End If
    End Sub

    Private Sub cbprop_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbprop.KeyDown
        If e.KeyCode = 13 Then
            cbkab.Focus()
        End If
    End Sub

    Private Sub cbkab_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbkab.KeyDown
        If e.KeyCode = 13 Then
            cbkec.Focus()
        End If
    End Sub

    Private Sub cbkec_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbkec.KeyDown
        If e.KeyCode = 13 Then
            cbarea.Focus()
        End If
    End Sub

    Private Sub cbarea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbarea.KeyDown
        If e.KeyCode = 13 Then
            btpre.Focus()
        End If
    End Sub

End Class