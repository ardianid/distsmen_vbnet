Imports lsp.lspclass
Imports Oracle.DataAccess.Client
Imports DevExpress.XtraBars

Public Class utama
    Inherits DevExpress.XtraEditors.XtraForm

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

    Public Sub setmenu(ByVal cn As OracleConnection)

        Dim ds As DataSet
        Dim sql As String = String.Format("select  a.kd_menu,a.t_add,a.t_edit,a.t_del,a.t_cetak,b.namaform from admlsp.ms_user_detail a inner join admlsp.ms_menu b on a.kd_menu=b.kode where a.nama_user='{0}'", userprog.Trim.ToUpper)


        cn = New OracleConnection
        cn = classmy.open_conn_utama

        ds = New DataSet
        ds = classmy.GetDataSet(sql, cn)

        dtmenu = New DataTable
        dtmenu.Clear()

        dtmenu = ds.Tables(0)

        If ds.Tables(0).Rows.Count > 0 Then


            Dim i As Integer = 0
            For i = 0 To BarManager1.Items.Count - 1
                If TypeOf BarManager1.Items(i) Is BarButtonItem Then

                    Dim btnbar As BarButtonItem = CType(BarManager1.Items(i), BarButtonItem)

                    If btnbar.Name.Substring(0, 2).ToUpper = "NO" Or btnbar.Name.Substring(0, 1).ToUpper = "X" Then
                        btnbar.Enabled = True
                    Else


                        Dim rows() As DataRow = dtmenu.Select(String.Format("KD_MENU='{0}'", btnbar.Name.ToUpper.Trim))
                        Dim i2 As Integer = 0
                        For i2 = 0 To rows.GetUpperBound(0)

                            If Convert.ToInt16(rows(i2)("T_ADD")) = 1 Or _
                                 Convert.ToInt16(rows(i2)("T_EDIT")) = 1 Or _
                                    Convert.ToInt16(rows(i2)("T_DEL")) = 1 Or _
                                        Convert.ToInt16(rows(i2)("T_CETAK")) = 1 Then

                                btnbar.Enabled = True

                            Else

                                btnbar.Enabled = False

                            End If

                        Next

                    End If

                End If
            Next

        End If


    End Sub


    Private Sub XtraForm1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        BarManager1.ForceInitialize()

        bar_tgl.Caption = "Tanggal : " & DateTime.Now.Date.ToLongDateString
        Timer1.Start()

        disable_bar()


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
End Class