Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fsl_gaji_sal_detail

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
                orow("NAMA") = "ALL"

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

    Private Sub tnama_sales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkodesal.KeyDown
        If e.KeyCode = 13 Then
            cbarea.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'tnamasal.Text.Trim
            tnamasal.Text = ""
            tkodesal.Text = ""

            Using fcari As New sr_sales(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkodesal.Text = fcari.get_kode
                tnamasal.Text = fcari.get_nama

            End Using

        End If
    End Sub

    Private Sub btfindsal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfindsal.Click

        Dim cari As String = "" 'tnamasal.Text.Trim

        Using fcari As New sr_sales(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkodesal.Text = fcari.get_kode
            tnamasal.Text = fcari.get_nama

        End Using


    End Sub

    Private Sub tnama_sles_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkodesal.Validating

        If tkodesal.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            If get_stat_pusat() = 1 Then
                sql = String.Format("select a.KD_SALES,a.NAMA,a.JENIS_POT from admlsp.ms_sales a where a.AKTIF=1 and a.KD_SALES='{0}'", tkodesal.Text.Trim)
            ElseIf get_stat_pusat() = 0 Then
                sql = String.Format("select a.KD_SALES,a.NAMA,a.JENIS_POT from admlsp.ms_sales a where a.AKTIF=1 and a.KD_STAT='{0}' and a.KD_SALES='{1}'", get_kode_stat, tkodesal.Text.Trim)
            Else
                Exit Sub
            End If


            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tkodesal.Text = dred(0).ToString
                    tnamasal.Text = dred(1).ToString

                    dred.Close()

                Else

                    dred.Close()
                    MsgBox("Sales tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tkodesal.Focus()
                    tnamasal.Text = ""

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

            tkodesal.Text = ""
            tnamasal.Text = ""

        End If


    End Sub

    Private Sub cbbulan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbulan.KeyDown
        If e.KeyCode = 13 Then
            tkodesal.Focus()
        End If
    End Sub

    Private Sub cbarea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbarea.KeyDown
        If e.KeyCode = 13 Then
            btpre.Focus()
        End If
    End Sub

    Private Sub fsl_ganti_spare_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        cbbulan.Focus()
    End Sub

    Private Sub fsl_ganti_spare_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RadioGroup1.SelectedIndex = 0

        ttahun.Text = Year(Now)

        cbbulan.SelectedIndex = 0

        isi_combo()
        cbarea.ItemIndex = 0
    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        If cbbulan.Text.Trim.Length = 0 Then
            MsgBox("Bulan harus diisi...", MsgBoxStyle.Information, "Informasi")
            cbbulan.Focus()
            Exit Sub
        End If

        Dim bulan As String = String.Empty

        If cbbulan.SelectedIndex <= 8 Then
            bulan = String.Format("0{0}", cbbulan.SelectedIndex + 1)
        Else
            bulan = cbbulan.SelectedIndex + 1
        End If


        If RadioGroup1.SelectedIndex = 1 Then

            Dim fpr_gaji_sal_detail As New pr_gaji_sal_detail(cbarea.EditValue, cbarea.Text.Trim, bulan, ttahun.Text.Trim, tkodesal.Text.Trim, tnamasal.Text.Trim, cbbulan.Text.Trim) With {.WindowState = FormWindowState.Maximized}
            fpr_gaji_sal_detail.Show()

        Else

            Dim fpr_gaji_sal_detail As New pr_gaji_sal_tot(cbarea.EditValue, cbarea.Text.Trim, bulan, ttahun.Text.Trim, tkodesal.Text.Trim, tnamasal.Text.Trim, cbbulan.Text.Trim) With {.WindowState = FormWindowState.Maximized}
            fpr_gaji_sal_detail.Show()

        End If

        

    End Sub

End Class