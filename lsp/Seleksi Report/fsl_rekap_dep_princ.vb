Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fsl_rekap_dep_princ

    Private Sub isi_combo()

        Const sql = "SELECT A.KD_PRC,A.NAMA,A.ALAMAT FROM ADMLSP.MS_PRINCIPAL A WHERE A.AKTIF=1 ORDER BY A.NAMA ASC"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv2 As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv2 = dvm.CreateDataView(ds.Tables(0))

            cbprinc.Properties.DataSource = dv2


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
            cbprinc.Focus()
        End If
    End Sub

    Private Sub cbprinc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbprinc.KeyDown
        If e.KeyCode = 13 Then
            btpre.Focus()
        End If
    End Sub

    Private Sub fsl_ganti_spare_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ttgl.Focus()
    End Sub

    Private Sub fsl_ganti_spare_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        isi_combo()

        ttgl.EditValue = Date.Now
        ttgl2.EditValue = Date.Now

    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        If cbprinc.Text.Trim.Length = 0 Then
            MsgBox("Principal harus diisi...", MsgBoxStyle.Information, "Informasi")
            cbprinc.Focus()
            Exit Sub
        End If

        Dim fpr_ganti_spare As New pr_rekap_dep_princ(ttgl.EditValue, ttgl2.EditValue, cbprinc.EditValue, cbprinc.Text.Trim) With {.WindowState = FormWindowState.Maximized}
        fpr_ganti_spare.Show()

    End Sub

End Class