Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fsl_gaji_supir

    Private Sub isi_combo()

        Dim sql As String = String.Empty

        If get_stat_pusat() = 1 Then
            sql = "select kode,nama,status from admlsp.MS_STAT order by kode"
        Else
            sql = String.Format("select kode,nama,status from admlsp.MS_STAT where a.kode='{0}' order by kode", get_kode_stat)
        End If



        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv = dvm.CreateDataView(ds.Tables(0))

            cbstatus.Properties.DataSource = dv

            cbstatus.ItemIndex = 0

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

    Private Sub fsl_gaji_supir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ttahun.Text = Year(Now)

        cbbulan.SelectedIndex = 0
        isi_combo()

    End Sub

    Private Sub cbbulan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbulan.KeyDown
        If e.KeyCode = 13 Then
            cbstatus.Focus()
        End If
    End Sub

    Private Sub cbarea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbstatus.KeyDown
        If e.KeyCode = 13 Then
            btpre.Focus()
        End If
    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        If cbbulan.Text.Trim.Length = 0 Then
            MsgBox("Bulan harus diisi...", MsgBoxStyle.Information, "Informasi")
            cbbulan.Focus()
            Exit Sub
        End If

        If cbstatus.Text.Trim.Length = 0 Then
            MsgBox("Area harus diisi...", MsgBoxStyle.Information, "Informasi")
            cbstatus.Focus()
            Exit Sub
        End If

        Dim bulan As String = String.Empty

        If cbbulan.SelectedIndex <= 8 Then
            bulan = String.Format("0{0}", cbbulan.SelectedIndex + 1)
        Else
            bulan = cbbulan.SelectedIndex + 1
        End If

        Dim gjspir As New pr_gaji_spir(bulan, ttahun.Text.Trim, cbstatus.EditValue) With {.WindowState = FormWindowState.Maximized}
        gjspir.Show()

    End Sub

End Class