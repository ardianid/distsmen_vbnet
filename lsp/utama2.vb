Imports lsp.lspclass
Imports Oracle.DataAccess.Client
Imports DevExpress.XtraBars

Public Class utama2
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub disable_bar()

        Dim i As Integer = 0
        For i = 0 To BarManager1.Items.Count - 1
            If TypeOf BarManager1.Items(i) Is BarButtonItem Then

                Dim btn As BarButtonItem = CType(BarManager1.Items(i), BarButtonItem)

                If Not btn.Name.Substring(0, 1).ToUpper = "X" Then
                    btn.Enabled = False
                End If

            End If
        Next

    End Sub

    Private Sub XtraForm1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        BarManager1.ForceInitialize()

        bar_tgl.Caption = "Tanggal : " & DateTime.Now.Date.ToLongDateString
        Timer1.Start()

        disable_bar()

        dock_kend.Visibility = Docking.DockVisibility.Hidden
        dock_giro.Visibility = Docking.DockVisibility.Hidden
        dock_piutang.Visibility = Docking.DockVisibility.Hidden


        Dim fmlogin As New login With {.MdiParent = Me, .WindowState = FormWindowState.Maximized}
        fmlogin.Show()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        barjam.Caption = "Jam : " & DateTime.Now.ToLongTimeString
    End Sub

    Private Sub m_user_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFUSER.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        fuser.MdiParent = Me
        fuser.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub m_rbah_pwd_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles NO_RBHPWD.ItemClick

        'open_wait()

        Using frubah_pwd As New rbah_pwd With {.StartPosition = FormStartPosition.CenterScreen}
            frubah_pwd.ShowDialog(Me)
        End Using

        'close_wait()


    End Sub


    Private Sub X_LOGOFF_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles NO_LOGOFF.ItemClick

        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        disable_bar()

        userprog = ""
        pwd = ""

        baruser.Caption = "User : "
        barstatus.Caption = "Status : "

        dock_kend.Visibility = Docking.DockVisibility.Hidden
        dock_giro.Visibility = Docking.DockVisibility.Hidden
        dock_piutang.Visibility = Docking.DockVisibility.Hidden

        grid_kend.DataSource = Nothing
        grid_giro.DataSource = Nothing
        grid_piut.DataSource = Nothing

        Dim fmlogin As New login With {.MdiParent = Me, .WindowState = FormWindowState.Maximized}
        fmlogin.Show()

    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles X_EXIT.ItemClick
        Application.Exit()
    End Sub

    Private Sub L_SUPIR_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles L_SUPIR.ItemClick



        open_wait()
        Cursor = Cursors.WaitCursor

        ms_supir.MdiParent = Me
        ' ms_supir.WindowState = FormWindowState.Maximized
        ms_supir.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFAREA_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFAREA.ItemClick

        If get_stat_pusat() = -1 Then
            Exit Sub
        ElseIf get_stat_pusat() = 0 Then
            MsgBox("Fasilitas ini hanya berlaku untuk AREA PUSAT", MsgBoxStyle.Exclamation, "Warning")
            Exit Sub
        End If

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_area.MdiParent = Me
        '  ms_area.WindowState = FormWindowState.Maximized
        ms_area.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFSALES_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFSALES.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_sales.MdiParent = Me
        ' ms_sales.WindowState = FormWindowState.Maximized
        ms_sales.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFPROP_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFPROP.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_prop.MdiParent = Me
        ms_prop.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFKAB_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFKAB.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_kab.MdiParent = Me
        ms_kab.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFKEC_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFKEC.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_kec.MdiParent = Me
        ms_kec.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFPRC_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFPRC.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        MS_PRC.MdiParent = Me
        MS_PRC.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFBARANG_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFBARANG.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_barang.MdiParent = Me
        ms_barang.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFTOKO_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFTOKO.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_toko.MdiParent = Me
        ms_toko.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFKEND_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFKEND.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_kend.MdiParent = Me
        ms_kend.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFKAS_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFKAS.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_kas.MdiParent = Me
        ms_kas.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFAKUN_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFAKUN.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_akun.MdiParent = Me
        ms_akun.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFSPARE_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFSPARE.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_sparepart.MdiParent = Me
        ms_sparepart.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFKSO_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFKSO.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_kso.MdiParent = Me
        ms_kso.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFDEPPRINC_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFDEPPRINC.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_deposit_princ.MdiParent = Me
        tr_deposit_princ.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFDEPTOKO_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFDEPTOKO.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_deposit_toko.MdiParent = Me
        tr_deposit_toko.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub NO_AREAPROG_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles NO_AREAPROG.ItemClick


        Using utl_penprog As New utl_pen_program With {.StartPosition = FormStartPosition.CenterScreen}
            utl_penprog.ShowDialog()
        End Using

    End Sub

    Private Sub FFSPAREIN_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFSPAREIN.ItemClick
        open_wait()
        Cursor = Cursors.WaitCursor

        tr_spare_in.MdiParent = Me
        tr_spare_in.Show()

        Cursor = Cursors.Default
        close_wait()
    End Sub


    Private Sub FFSPAREOUT_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFSPAREOUT.ItemClick
        open_wait()
        Cursor = Cursors.WaitCursor

        tr_spare_out.MdiParent = Me
        tr_spare_out.Show()

        Cursor = Cursors.Default
        close_wait()
    End Sub

    Private Sub FFPRE_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFPRE.ItemClick
        open_wait()
        Cursor = Cursors.WaitCursor

        tr_pre.MdiParent = Me
        tr_pre.Show()

        Cursor = Cursors.Default
        close_wait()
    End Sub

    Private Sub FFREAL_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFREAL.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_real.MdiParent = Me
        tr_real.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFUANGJLN_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFUANGJLN.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_uangjlan.MdiParent = Me
        tr_uangjlan.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFKASIN_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFKASIN.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_kas_in.MdiParent = Me
        tr_kas_in.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFGIRO_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFGIRO.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        ms_giro.MdiParent = Me
        ms_giro.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFPIUTANG_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFPIUTANG.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_byartoko.MdiParent = Me
        tr_byartoko.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFGIROCAIR_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFGIROCAIR.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_giro_cair.MdiParent = Me
        tr_giro_cair.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFKASBON_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFKASBON.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_kasbon.MdiParent = Me
        tr_kasbon.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFANGKUT_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFANGKUT.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_angkut.MdiParent = Me
        tr_angkut.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFINV_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFINV.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_inv.MdiParent = Me
        tr_inv.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFKASOUT_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFKASOUT.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_kas_out.MdiParent = Me
        tr_kas_out.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFLAPDEL_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

        If userprog.Trim.Length = 0 Then
            Exit Sub
        End If

        open_wait()
        Cursor = Cursors.WaitCursor

        fb_dliver.MdiParent = Me
        fb_dliver.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFKALKSUPIR_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFKALKSUPIR.ItemClick

        'open_wait()
        Cursor = Cursors.WaitCursor

        fkalk_gaji.StartPosition = FormStartPosition.CenterScreen
        fkalk_gaji.ShowDialog(Me)

        Cursor = Cursors.Default
        'close_wait()

    End Sub

    Private Sub LAPFINAN_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles LAPFINAN.ItemClick

        If userprog.Trim.Length = 0 Then
            Exit Sub
        End If

        open_wait()
        Cursor = Cursors.WaitCursor

        fb_finance.MdiParent = Me
        fb_finance.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub LAPAS_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

        If userprog.Trim.Length = 0 Then
            Exit Sub
        End If

        open_wait()
        Cursor = Cursors.WaitCursor

        fb_ascon.MdiParent = Me
        fb_ascon.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFTRACKUSER_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFTRACKUSER.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_hist_user.MdiParent = Me
        tr_hist_user.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub NO_RSTREMIND_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles NO_RSTREMIND.ItemClick

        open_wait()

        classmy.get_stat_reminder_user()

        If rem_piutang = 1 Then

            dock_piutang.Visibility = Docking.DockVisibility.Visible
            classmy.get_reminder(grid_piut, "PIUTANG")

        Else
            grid_piut.DataSource = Nothing
            dock_piutang.Visibility = Docking.DockVisibility.Hidden
        End If

        If rem_giro = 1 Then

            dock_giro.Visibility = Docking.DockVisibility.Visible
            classmy.get_reminder(grid_giro, "GIRO")

        Else
            grid_giro.DataSource = Nothing
            dock_giro.Visibility = Docking.DockVisibility.Hidden
        End If

        If rem_kend = 1 Then

            dock_kend.Visibility = Docking.DockVisibility.Visible
            classmy.get_reminder(grid_kend, "KENDARAAN")

        Else
            grid_kend.DataSource = Nothing
            dock_kend.Visibility = Docking.DockVisibility.Hidden
        End If

        close_wait()

    End Sub

    Private Sub FFKELUJALAN_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFKELUJALAN.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_uangjlan.MdiParent = Me
        tr_uangjlan.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFKELULAIN_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFKELULAIN.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        tr_uangjlan_l.MdiParent = Me
        tr_uangjlan_l.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub FFKALKLABRUG_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFKALKLABRUG.ItemClick

        Cursor = Cursors.WaitCursor

        tr_kalk_rugilab.StartPosition = FormStartPosition.CenterScreen
        tr_kalk_rugilab.ShowDialog(Me)

        Cursor = Cursors.Default

    End Sub

    Private Sub FFEKSPOR_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFEKSPOR.ItemClick

        tr_eks.StartPosition = FormStartPosition.CenterScreen
        tr_eks.ShowDialog(Me)

    End Sub

    Private Sub FFIMPOR_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FFIMPOR.ItemClick

        tr_imp.StartPosition = FormStartPosition.CenterScreen
        tr_imp.ShowDialog(Me)

    End Sub
End Class