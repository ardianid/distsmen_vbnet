Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fsl_ganti_spare

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

    Private Sub isi_combo2()

        Const sql = "SELECT B.NOPOL FROM ADMLSP.MS_KENDARAAN B WHERE B.AKTIF=1 ORDER BY B.NOPOL ASC"

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

                orow("NOPOL") = "All"

                ds.Tables(0).Rows.InsertAt(orow, 0)


            End If

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv2 = dvm.CreateDataView(ds.Tables(0))

            cbnopol.Properties.DataSource = dv2


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

    Private Sub isi_combo3()

        Const sql = "select kode,nama,satuan from admlsp.ms_sparepart order by nama asc"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv1 As DataView

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
            dv1 = dvm.CreateDataView(ds.Tables(0))

            cbspare.Properties.DataSource = dv1


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
            cbnopol.Focus()
        End If
    End Sub

    Private Sub cbnopol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbnopol.KeyDown
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
        isi_combo()
        isi_combo3()
        isi_combo2()

        ttgl.EditValue = Date.Now
        ttgl2.EditValue = Date.Now

        cbnopol.ItemIndex = 0
        cbspare.ItemIndex = 0
        cbarea.ItemIndex = 0
    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        Dim fpr_ganti_spare As New pr_ganti_spare(ttgl.EditValue, ttgl2.EditValue, cbarea.EditValue, cbarea.Text.Trim, cbnopol.Text.Trim, cbspare.EditValue) With {.WindowState = FormWindowState.Maximized}
        fpr_ganti_spare.Show()

    End Sub

End Class