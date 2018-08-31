Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fsl_labarugi

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

    Private Sub ttahun_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttahun.KeyDown
        If e.KeyCode = 13 Then
            cbbulan.Focus()
        End If
    End Sub

    Private Sub cbbulan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbulan.KeyDown
        If e.KeyCode = 13 Then
            cbarea.Focus()
        End If
    End Sub

    Private Sub cbarea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbarea.KeyDown
        If e.KeyCode = 13 Then
            btpre.Focus()
        End If
    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        If ttahun.Text.Trim.Length <= 0 Then
            MsgBox("Tahun harus diisi", MsgBoxStyle.Information, "Informasi")
            ttahun.Focus()
            Exit Sub
        End If

        If cbbulan.Text.Trim.Length <= 0 Then
            MsgBox("Bulan harus diisi", MsgBoxStyle.Information, "Informasi")
            cbbulan.Focus()
            Exit Sub
        End If

        If cbarea.Text.Trim.Length <= 0 Then
            MsgBox("Area harus diisi", MsgBoxStyle.Information, "Informasi")
            cbarea.Focus()
            Exit Sub
        End If

        Dim rrkap As Boolean = False

        If RadioGroup1.SelectedIndex = 0 Then
            rrkap = True
        Else
            rrkap = False
        End If

        Dim bulan As String
        If cbbulan.SelectedIndex >= 1 And cbbulan.SelectedIndex <= 9 Then
            bulan = String.Format("0{0}", cbbulan.SelectedIndex)
        ElseIf cbbulan.SelectedIndex > 9 Then
            bulan = cbbulan.SelectedIndex
        Else
            bulan = 0
        End If

        Dim fpr_klabarugi As New pr_labarugi(cbarea.EditValue, cbarea.Text.Trim, bulan, ttahun.EditValue, rrkap) With {.WindowState = FormWindowState.Maximized}
        fpr_klabarugi.Show()

    End Sub

    Private Sub fsl_labarugi_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ttahun.Focus()
    End Sub

    Private Sub fsl_labarugi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        isi_combo()

        cbbulan.SelectedIndex = 0
        ttahun.EditValue = Year(Now)

        RadioGroup1.SelectedIndex = 0

    End Sub
End Class