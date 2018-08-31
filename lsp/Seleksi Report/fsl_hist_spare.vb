Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fsl_hist_spare

    Private Sub isi_combo3()

        Const sql = "select kode,nama,satuan from admlsp.ms_sparepart order by nama asc"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv1 As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

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
            cbspare.Focus()
        End If
    End Sub

    Private Sub cbspare_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbspare.KeyDown
        If e.KeyCode = 13 Then
            btpre.Focus()
        End If
    End Sub

    Private Sub fsl_ganti_spare_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ttgl.Focus()
    End Sub

    Private Sub fsl_ganti_spare_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        isi_combo3()

        ttgl.EditValue = Date.Now
        ttgl2.EditValue = Date.Now

        cbspare.ItemIndex = 0
    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        If cbspare.Text.Trim.Length = 0 Then
            MsgBox("Sparepart harus diisi...", MsgBoxStyle.Information, "Informasi")
            cbspare.Focus()
            Exit Sub
        End If

        Dim fpr_ganti_spare As New pr_hist_spare(ttgl.EditValue, ttgl2.EditValue, cbspare.EditValue) With {.WindowState = FormWindowState.Maximized}
        fpr_ganti_spare.Show()

    End Sub

End Class