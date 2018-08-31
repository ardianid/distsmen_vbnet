Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fsl_gaji_semen

    Private Sub tkodesupir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkode_spir.KeyDown
        If e.KeyCode = 13 Then
            btpre.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'tnama_spir.Text.Trim
            tnama_spir.Text = ""
            tkode_spir.Text = ""

            Using fcari As New s_supir(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkode_spir.Text = fcari.get_kode
                tnama_spir.Text = fcari.get_nama

            End Using

        End If
    End Sub

    Private Sub btfindSpir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfindspir.Click

        Dim cari As String = "" 'tnama_spir.Text.Trim

        Using fcari As New s_supir(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkode_spir.Text = fcari.get_kode
            tnama_spir.Text = fcari.get_nama

        End Using


    End Sub

    Private Sub tkode_spir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkode_spir.Validating

        If tkode_spir.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            ' If get_stat_pusat() = 1 Then
            sql = String.Format("select a.KD_SUPIR,a.NAMA from admlsp.ms_supir a where a.AKTIF=1 and a.KD_SUPIR='{0}'", tkode_spir.Text.Trim)
            '    'ElseIf get_stat_pusat() = 2 Then
            '    '    sql = String.Format("select a.KD_SUPIR,a.NAMA from admlsp.ms_supir a where a.AKTIF=1 and a.KD_STAT='{0}' and a.NAMA='{1}'", get_kode_stat, tnama_spir.Text.Trim)
            'Else
            '    Exit Sub
            'End If



            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tkode_spir.Text = dred(0).ToString
                    tnama_spir.Text = dred(1).ToString

                    dred.Close()

                Else

                    dred.Close()
                    MsgBox("Nama supir tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tkode_spir.Focus()
                    tnama_spir.Text = ""

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


        Else

            tkode_spir.Text = ""
            tnama_spir.Text = ""

        End If


    End Sub

    Private Sub ttahun_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = 13 Then
            cbbulan.Focus()

        End If
    End Sub

    Private Sub cbbulan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = 13 Then
            tkode_spir.Focus()
        End If
    End Sub

    Private Sub fsl_gaji_semen_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ttahun.Focus()
    End Sub

    Private Sub fsl_gaji_semen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ttahun.Text = Year(Now)

        cbbulan.SelectedIndex = 0

    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        If cbbulan.Text.Trim.Length = 0 Then
            MsgBox("Bulan harus diisi...", MsgBoxStyle.Information, "Informasi")
            cbbulan.Focus()
            Exit Sub
        End If

        If ttahun.Text.Trim.Length = 0 Then
            MsgBox("Tahun harus diisi...", MsgBoxStyle.Information, "Informasi")
            ttahun.Focus()
            Exit Sub
        End If

        If tkode_spir.Text.Trim.Length = 0 Then
            MsgBox("Supir harus diisi...", MsgBoxStyle.Information, "Informasi")
            tkode_spir.Focus()
            Exit Sub
        End If

        Dim bulan As String = String.Empty

        If cbbulan.SelectedIndex <= 8 Then
            bulan = String.Format("0{0}", cbbulan.SelectedIndex + 1)
        Else
            bulan = cbbulan.SelectedIndex + 1
        End If


        Dim gajisemen As New pr_gaji_semen(bulan, ttahun.EditValue, tkode_spir.Text.Trim, tnama_spir.Text.Trim, cbbulan.Text.Trim) With {.WindowState = FormWindowState.Maximized}
        gajisemen.Show()

    End Sub

End Class