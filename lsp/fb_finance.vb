Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fb_finance


    Private dv1 As DataView

    Private Sub isi_grid()

        Dim ds As DataSet
        Dim dvmanager As Data.DataViewManager
        Dim cn As OracleConnection = Nothing


        Dim sql As String = String.Format("select rownum,a.MNFILE,a.NAMA,a.KETERANGAN,a.NAMAFORM from admlsp.ms_menu a inner join admlsp.ms_user_detail b on a.KODE=b.KD_MENU where b.NAMA_USER='{0}' and a.JENIS='B. LAPORAN' AND (b.T_ACTIVE=1 or b.T_ADD=1 or b.T_CETAK=1 or b.T_DEL=1 or b.T_EDIT=1)", userprog)

        grid1.DataSource = Nothing
        Try

            dv1 = Nothing

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            grid1.DataSource = dv1

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

    Private Sub fb_dliver_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        isi_grid()

    End Sub

    Private Sub btload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btload.Click

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count = 0 Then
            Exit Sub
        End If

        'open_wait()
        'Cursor = Cursors.WaitCursor

        Dim namaform As String = dv1(Me.BindingContext(dv1).Position)("NAMAFORM").ToString

        Select Case namaform.ToUpper
            Case "PR_GAJI_SPIR"

                Dim ffsel As New fsl_gaji_supir() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_GAJI_SEMEN"

                Dim ffsel As New fsl_gaji_semen() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_GAJI_ANGK"

                Dim ffsel As New fsl_gaji_angk() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "PR_DEP_PRINCP"

                Dim ffsel As New pr_dep_princp()
                ffsel.Show()

            Case "FSLHIST_KSB_SPR"

                Dim ffsel As New fsl_hist_ksbon_supir() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_HUTANG_SUPIR"

                Dim ffsel As New fsl_hutang_supir() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_GAJI_SAL_DETAIL"

                Dim ffsel As New fsl_gaji_sal_detail() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_REKAP_DEP_PRINC"

                Dim ffsel As New fsl_rekap_dep_princ() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_KAS_OUT"

                Dim ffsel As New fsl_kas_out() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_LABARUGI"

                Dim ffsel As New fsl_labarugi() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_HIST_KAS"

                Dim ffsel As New fsl_hist_kas() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_REKAP"

                Dim ffsel As New fsl_rkap() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_BYAR_TOKO"

                Dim ffsel As New fsl_byar_toko() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_DO_PENDING"
                Dim ffsel As New fsl_do_pending() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_KSO_DETAIL"
                Dim ffsel As New fsl_kso_detail() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()
            Case "FSL_SELISIH_REKAP"
                Dim ffsel As New fsl_selisih_rekap() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_GANTI_SPARE"

                Dim ffsel As New fsl_ganti_spare() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_HIST_SPARE"

                Dim ffsel As New fsl_hist_spare() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_PARETO"

                Dim ffsel As New fsl_pareto() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_TRACK"

                Dim ffsel As New fsl_track() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

        End Select

        'Cursor = Cursors.Default
        'close_wait()

    End Sub

    Private Sub grid1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grid1.DoubleClick
        btload_Click(sender, e)
    End Sub

    Private Sub grid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grid1.Click

    End Sub
End Class