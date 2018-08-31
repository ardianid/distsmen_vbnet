Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fsl_hutang_supir

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

    Private Sub tkodesupir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkode_spir.KeyDown
        If e.KeyCode = 13 Then
            cbarea.Focus()
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

    Private Sub cbarea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbarea.KeyDown
        If e.KeyCode = 13 Then
            btpre.Focus()
        End If
    End Sub


    Private Sub fsl_ganti_spare_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        tkode_spir.Focus()
    End Sub

    Private Sub fsl_ganti_spare_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        isi_combo()

        cbarea.ItemIndex = 0
    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        Dim fpr_ganti_spare As New pr_hutang_supir(tkode_spir.Text.Trim, cbarea.EditValue) With {.WindowState = FormWindowState.Maximized}
        fpr_ganti_spare.Show()

    End Sub

End Class