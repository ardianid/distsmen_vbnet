Imports lsp.lspclass
Imports Oracle.DataAccess.Client
Imports DevExpress.XtraBars

Public Class login

    Private Sub login_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        tuser.Focus()
    End Sub

    Private Sub btbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btbatal.Click
        Application.Exit()
    End Sub

    Private Sub btmasuk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmasuk.Click

        If tuser.Text = "" Then
            MsgBox("Nama user harus diisi", MsgBoxStyle.Information, "Informasi")
            tuser.Focus()
            Exit Sub
        End If

        If tpwd.Text = "" Then
            MsgBox("Password harus diisi", MsgBoxStyle.Information, "Informasi")
            tpwd.Focus()
            Exit Sub
        End If

        open_wait()

        Dim cn As OracleConnection = New OracleConnection
        userprog = tuser.Text.Trim.ToUpper
        pwd = tpwd.Text.Trim

        Try


            cn = classmy.open_conn_utama


            setmenu()
            utama2.baruser.Caption = "User : " & userprog.Trim.ToUpper

            Me.Close()

            close_wait()

        Catch ex As Exception

            close_wait()

            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Informasi")

        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                    cn.Dispose()
                End If
            End If

        End Try


    End Sub

    Public Sub setmenu()

        Dim ds As DataSet
        Dim sql As String = String.Format("select  a.kd_menu,a.t_active,a.t_add,a.t_edit,a.t_del,a.t_cetak,b.namaform from admlsp.ms_user_detail a inner join admlsp.ms_menu b on a.kd_menu=b.kode where a.nama_user='{0}'", userprog.Trim.ToUpper)


        Dim cn2 As New OracleConnection

        Try

            cn2 = classmy.open_conn_utama

            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn2)

            dtmenu = New DataTable
            dtmenu.Clear()

            dtmenu = ds.Tables(0)

            If ds.Tables(0).Rows.Count > 0 Then


                Dim i As Integer = 0
                For i = 0 To utama2.BarManager1.Items.Count - 1
                    If TypeOf utama2.BarManager1.Items(i) Is BarButtonItem Then

                        Dim btnbar As BarButtonItem = CType(utama2.BarManager1.Items(i), BarButtonItem)

                        If btnbar.Name.Substring(0, 2).ToUpper = "NO" Or btnbar.Name.Substring(0, 1).ToUpper = "X" Or btnbar.Name.Substring(0, 3).ToUpper = "LAP" Then
                            btnbar.Enabled = True
                        Else


                            Dim rows() As DataRow = dtmenu.Select(String.Format("KD_MENU='{0}'", btnbar.Name.ToUpper.Trim))
                            Dim i2 As Integer = 0
                            For i2 = 0 To rows.GetUpperBound(0)

                                If Convert.ToInt16(rows(i2)("T_ACTIVE")) = 1 Then

                                    btnbar.Enabled = True

                                Else

                                    btnbar.Enabled = False

                                End If

                            Next

                        End If

                    End If
                Next


                If Not cn2 Is Nothing Then
                    If cn2.State = ConnectionState.Open Then
                        cn2.Close()
                        cn2.Dispose()
                    End If
                End If

                classmy.get_stat_reminder_user()

                If Not (rem_kend = 1 Or rem_giro = 1 Or rem_piutang = 1) Then
                    utama2.NO_RSTREMIND.Enabled = False
                Else
                    utama2.NO_RSTREMIND.Enabled = True
                End If

                If rem_piutang = 1 Then

                    utama2.dock_piutang.Visibility = Docking.DockVisibility.Visible
                    classmy.get_reminder(utama2.grid_piut, "PIUTANG")

                Else
                    utama2.grid_piut.DataSource = Nothing
                    utama2.dock_piutang.Visibility = Docking.DockVisibility.Hidden
                End If

                If rem_giro = 1 Then

                    utama2.dock_giro.Visibility = Docking.DockVisibility.Visible
                    classmy.get_reminder(utama2.grid_giro, "GIRO")
                Else
                    utama2.grid_giro.DataSource = Nothing
                    utama2.dock_giro.Visibility = Docking.DockVisibility.Hidden
                End If

                If rem_kend = 1 Then

                    utama2.dock_kend.Visibility = Docking.DockVisibility.Visible
                    classmy.get_reminder(utama2.grid_kend, "KENDARAAN")

                Else
                    utama2.grid_kend.DataSource = Nothing
                    utama2.dock_kend.Visibility = Docking.DockVisibility.Hidden
                End If


            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Informasi")
        Finally
            If Not cn2 Is Nothing Then
                If cn2.State = ConnectionState.Open Then
                    cn2.Close()
                    cn2.Dispose()
                End If
            End If
        End Try

        set_status_program()

    End Sub

    Private Sub set_status_program()

        Dim ds As DataSet
        Const sql = "select a.kode,a.nama,a.status from admlsp.ms_stat a inner join admlsp.utl_pnm_prog b on a.KODE=b.KODE"

        Dim cn As OracleConnection = New OracleConnection


        Try

            cn = classmy.open_conn_utama

            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            dtstat_prog = New DataTable
            dtstat_prog.Clear()

            dtstat_prog = ds.Tables(0)

            If dtstat_prog.Rows.Count > 0 Then

                Dim stat As String = String.Format("Status : {0} [-{1}-]", dtstat_prog.Rows(0)("STATUS").ToString.ToUpper, dtstat_prog.Rows(0)("NAMA").ToString.ToLower)

                utama2.barstatus.Caption = stat

            Else
                utama2.barstatus.Caption = "Status : "
            End If

        Catch ex As OracleException
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        End Try

    End Sub

    Private Sub tuser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tuser.KeyDown
        If e.KeyCode = 13 Then
            tpwd.Focus()
        End If
    End Sub

    Private Sub tpwd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tpwd.KeyDown
        If e.KeyCode = 13 Then
            btmasuk.PerformClick()
        End If
    End Sub



End Class