Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class t_spare_out2

    Private statadd As Boolean
    Private dv As DataView
    Private dv1 As DataView
    Private posi As Integer = 0
    Private addjml As Integer = 0

    Sub New(ByVal adstat As Boolean, ByVal dv1 As DataView, ByVal pos As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        statadd = adstat
        dv = dv1
        posi = pos
        addjml = 0

        isi_combo()


    End Sub

    Private Sub kosongkan()

        tbukti.Text = "<< New >>"
        ttgl.EditValue = Date.Now
        tkode_spir.Text = ""
        tnama_spir.Text = ""
        tket.Text = ""

        dv1 = New DataView
        dv1 = Nothing

        grid1.DataSource = Nothing

    End Sub

    Private Sub isi_combo()

        Const sql = "select a.NOPOL from admlsp.ms_kendaraan a where a.AKTIF=1 order by a.NOPOL"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv2 As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv2 = dvm.CreateDataView(ds.Tables(0))

            cbnopol.Properties.DataSource = dv2


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

    Private Sub isi_grid()

        Dim ds As DataSet
        Dim dvmanager As Data.DataViewManager
        Dim cn As OracleConnection = Nothing


        Dim sql As String = String.Format("select a.JML,a.SATUAN,a.KD_SPARE,b.NAMA,a.harga,a.tot_harga from admlsp.TR_SPAREPART_OUT2 a inner join admlsp.MS_SPAREPART b on a.KD_SPARE=b.KODE " & _
                                " where a.NO_BUKTI='{0}'", tbukti.Text.Trim)

        grid1.DataSource = Nothing
        Try

            dv1 = Nothing

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            dv1.Sort = "KD_SPARE"

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

    Private Sub isi_box()

        tbukti.Enabled = False
        tbukti.Text = dv(posi)("NO_BUKTI").ToString
        ttgl.Text = convert_date_to_ind(dv(posi)("TANGGAL").ToString)
        cbnopol.EditValue = dv(posi)("NOPOL").ToString
        tkode_spir.Text = dv(posi)("KD_SUPIR").ToString
        tnama_spir.Text = dv(posi)("SUPIR").ToString
        tket.Text = dv(posi)("KETERANGAN").ToString

        'isi_grid()

    End Sub

    Private Sub edit(ByVal refresd As Boolean)

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim sql As String = String.Format("update admlsp.TR_SPAREPART_OUT set tanggal='{0}',nopol='{1}',kd_supir='{2}',keterangan='{3}',user_edit='{4}',tgl_edit='{5}',tot_harga={6}" & _
                                          " where no_bukti='{7}'", tgl, cbnopol.EditValue, tkode_spir.Text.Trim, tket.Text.Trim, userprog, convert_date_to_eng(Date.Now.ToString), gridview.Columns("TOT_HARGA").SummaryItem.SummaryValue, tbukti.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)

            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_SPAREPART_OUT", "UPDATE", "PERGANTIAN SPAREPART")

            manipulate2(cn)

            sqltrans.Commit()

            update_view()

            If refresd = False Then
                MsgBox("Data telah dirubah..", MsgBoxStyle.Information, "Informasi")
                '  ms_supir.refresh_data()
                Me.Close()
            End If

            close_wait()

        Catch ex As OracleException
            close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try


    End Sub

    Private Sub manipulate2(ByVal cn As OracleConnection)

        Dim cmd As OracleCommand
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim cmd2 As OracleCommand
        Dim dread As OracleDataReader

        If Not IsNothing(dv1) Then

            If dv1.Count > 0 Then

                Dim i As Integer = 0
                For i = 0 To dv1.Count - 1

                    sql2 = String.Format("select no_bukti from admlsp.TR_SPAREPART_OUT2 where no_bukti='{0}' and kd_spare='{1}'", tbukti.Text.Trim, dv1(i)("KD_SPARE").ToString)
                    cmd2 = New OracleCommand(sql2, cn)
                    dread = cmd2.ExecuteReader

                    If dread.Read Then

                        dread.Close()

                        sql = String.Format("update admlsp.TR_SPAREPART_OUT2 set jml={0},satuan='{1}',harga={2},tot_harga={3} where no_bukti='{4}' and kd_spare='{5}'", dv1(i)("JML").ToString, dv1(i)("SATUAN").ToString, dv1(i)("HARGA").ToString, dv1(i)("TOT_HARGA").ToString, tbukti.Text.Trim, dv1(i)("KD_SPARE").ToString)

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_SPAREPART_OUT2", "UPDATE", "PERGANTIAN SPAREPART")

                    Else

                        dread.Close()

                        sql = String.Format("insert into admlsp.TR_SPAREPART_OUT2 (no_bukti,kd_spare,jml,satuan,harga,tot_harga) values('{0}','{1}',{2},'{3}',{4},{5})", tbukti.Text.Trim, dv1(i)("KD_SPARE").ToString, dv1(i)("JML").ToString, dv1(i)("SATUAN").ToString, dv1(i)("HARGA").ToString, dv1(i)("TOT_HARGA").ToString)

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_SPAREPART_OUT2", "INSERT", "PERGANTIAN SPAREPART")

                    End If

                Next

            End If

        End If


    End Sub

    Private Sub insert()

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim sql As String = ""
        Dim sql_search As String = ""


        Dim cmd As OracleCommand
        Dim cn As OracleConnection = Nothing
        Dim dre As OracleDataReader = Nothing
        Dim cmdsearch As OracleCommand

        Try
            open_wait()
            cn = classmy.open_conn_utama

            tbukti.Text = classmy.GET_KODE_GANTISPARE(get_kode_stat, cn, ttgl.EditValue)

            sql_search = String.Format("select no_bukti from admlsp.TR_SPAREPART_OUT where no_bukti='{0}'", tbukti.Text.Trim)
            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                tbukti.Text = classmy.GET_KODE_GANTISPARE(get_kode_stat, cn, ttgl.EditValue)
                'MsgBox("Kode sudah ada", MsgBoxStyle.Information, "Informasi")
                'tbukti.Focus()
                'Exit Sub
            Else
                dre.Close()
            End If


            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            sql = String.Format("insert into admlsp.TR_SPAREPART_OUT (no_bukti,tanggal,nopol,kd_supir,keterangan,user_add,tgl_add,kd_stat,tot_harga) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8})", tbukti.Text.Trim.ToUpper, tgl, cbnopol.EditValue, tkode_spir.Text.Trim, tket.Text.Trim, userprog, convert_date_to_eng(Date.Now.ToString), get_kode_stat, gridview.Columns("TOT_HARGA").SummaryItem.SummaryValue)
            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_SPAREPART_OUT", "INSERT", "PERGANTIAN SPAREPART")

            manipulate2(cn)

            sqltrans.Commit()

            insert_view()

            close_wait()

            MsgBox("Data telah disimpan... ", MsgBoxStyle.Information, "Informasi")

            addjml = addjml + 1

            kosongkan()
            ttgl.Focus()

            Me.Close()

        Catch ex As OracleException
            close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If


        End Try

    End Sub

    Private Sub insert_view()

        Dim orow As DataRow = dv.Table.NewRow

        orow("NO_BUKTI") = tbukti.Text

        If ttgl.Text = "" Then
            orow("TANGGAL") = DBNull.Value
        Else
            orow("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        orow("SUPIR") = tnama_spir.Text.Trim
        orow("NOPOL") = cbnopol.EditValue
        orow("KETERANGAN") = tket.Text.Trim
        orow("KD_SUPIR") = tkode_spir.Text.Trim

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()


        If ttgl.Text = "" Then
            dv(posi)("TANGGAL") = DBNull.Value
        Else
            dv(posi)("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        dv(posi)("SUPIR") = tnama_spir.Text.Trim
        dv(posi)("NOPOL") = cbnopol.EditValue
        dv(posi)("KETERANGAN") = tket.Text.Trim
        dv(posi)("KD_SUPIR") = tkode_spir.Text.Trim

    End Sub

    Private Sub hapus_detail()

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Dim cn As OracleConnection = Nothing
        Dim sql As String = String.Format("delete from admlsp.TR_SPAREPART_OUT2 where no_bukti='{0}' and kd_spare='{1}'", tbukti.Text.Trim, dv1(Me.BindingContext(dv1).Position)("KD_SPARE").ToString)
        Dim cmd As OracleCommand

        Try

            cn = classmy.open_conn_utama
            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_SPAREPART_OUT2", "DELETE", "PERGANTIAN SPAREPART")

            dv1(Me.BindingContext(dv1).Position).Delete()

            sqltrans.Commit()

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

            edit(True)

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

    Private Sub tnama_spir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkode_spir.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'tnama_spir.Text.Trim
            tnama_spir.Text = ""

            Using fcari As New s_supir(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkode_spir.Text = fcari.get_kode
                tnama_spir.Text = fcari.get_nama

            End Using

        End If
    End Sub

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click

        Dim cari As String = "" 'tnama_spir.Text.Trim

        Using fcari As New s_supir(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkode_spir.Text = fcari.get_kode
            tnama_spir.Text = fcari.get_nama

        End Using


    End Sub

    Private Sub t_spareout2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            ttgl.Focus()
        Else
            ttgl.Focus()
        End If
    End Sub

    Private Sub t_spareout2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            'tbukti.Enabled = True

            ttgl.Properties.ReadOnly = False
            cbnopol.Properties.ReadOnly = False

            kosongkan()
        Else

            'tbukti.Enabled = False

            ttgl.Properties.ReadOnly = True
            cbnopol.Properties.ReadOnly = True

            isi_box()
        End If

        isi_grid()

    End Sub

    Private Sub tbukti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbukti.KeyDown
        If e.KeyCode = 13 Then
            ttgl.Focus()
        End If
    End Sub

    Private Sub ttgl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        If e.KeyCode = 13 Then
            cbnopol.Focus()
        End If
    End Sub

    Private Sub cbnopol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbnopol.KeyDown
        If e.KeyCode = 13 Then
            tkode_spir.Focus()
        End If
    End Sub

    Private Sub tket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tket.KeyDown
        If e.KeyCode = 13 Then
            btadd_det.Focus()
        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            tr_spare_out.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tbukti.Text = "" Then

            MsgBox("No bukti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tbukti.Focus()
            Exit Sub
        End If

        If cbnopol.Text = "" Then

            MsgBox("No Polisi tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            cbnopol.Focus()
            Exit Sub
        End If

        If tkode_spir.Text = "" Then

            MsgBox("Supir tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tnama_spir.Focus()
            Exit Sub
        End If

        If IsNothing(dv1) Then
            MsgBox("Sparepart yang akan diganti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            btadd_det.Focus()
            Exit Sub
        End If

        If dv1.Count <= 0 Then

            MsgBox("Sparepart yang akan diganti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            btadd_det.Focus()
            Exit Sub
        End If
       


        If statadd.Equals(True) Then
            insert()
        Else
            edit(False)
        End If


    End Sub

    Private Sub tnama_spir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkode_spir.Validating


        If tkode_spir.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            sql = String.Format("select a.KD_SUPIR,a.NAMA from admlsp.MS_SUPIR a where a.AKTIF=1 and a.KD_SUPIR='{0}'", tkode_spir.Text.Trim)


            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tkode_spir.Text = dred(0).ToString
                    tnama_spir.Text = dred(1).ToString

                Else

                    MsgBox("Supir tidak ditemukan", MsgBoxStyle.Information, "Informasi")
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

    Private Sub btadd_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btadd_det.Click

        Using fspare3 As New t_spare_out3(False, dv1, 0) With {.StartPosition = FormStartPosition.CenterParent}
            fspare3.ShowDialog(Me)
        End Using

    End Sub

    Private Sub bted_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bted_det.Click

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Using fspare3 As New t_spare_out3(True, dv1, Me.BindingContext(dv1).Position) With {.StartPosition = FormStartPosition.CenterParent}
            fspare3.ShowDialog(Me)
        End Using

    End Sub

    Private Sub btdel_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btdel_det.Click
        hapus_detail()
    End Sub

End Class