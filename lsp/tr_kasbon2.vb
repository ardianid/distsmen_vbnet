Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_kasbon2

    Private statadd As Boolean
    Private dv As DataView
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
        tkodesup.Text = ""
        tnamasup.Text = ""
        tjml.EditValue = 0
        tket.Text = ""

    End Sub

    Private Sub isi_combo()

        Dim sql = ""

        If get_stat_pusat() = 1 Then
            sql = "SELECT A.KODE,A.NAMA FROM ADMLSP.MS_KAS A"
        ElseIf get_stat_pusat() = 0 Then
            sql = String.Format("SELECT A.KODE,A.NAMA FROM ADMLSP.MS_KAS A WHERE A.KD_STAT='{0}'", get_kode_stat)
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

            cbkas.Properties.DataSource = dv


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

        cbjenis.Properties.ReadOnly = True
        cbjenis.EditValue = dv(posi)("JENIS").ToString

        tbukti.Text = dv(posi)("no_bukti").ToString
        ttgl.Text = convert_date_to_ind(dv(posi)("tanggal").ToString)
        tkodesup.Text = dv(posi)("KD_SUPIR").ToString
        tnamasup.Text = dv(posi)("NAMA_SUPIR").ToString
        cbkas.EditValue = dv(posi)("kode_kas").ToString
        tjml.EditValue = dv(posi)("JML").ToString
        tket.Text = dv(posi)("KETERANGAN").ToString

    End Sub

    Private Sub edit()

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim sql As String = String.Format("update admlsp.TR_KASBON set tanggal='{0}',kd_supir='{1}',kode_kas='{2}',jml={3},keterangan='{4}',user_edit='{5}',tgl_edit='{6}'" & _
                                          " where no_bukti='{7}'", tgl, tkodesup.Text.Trim, cbkas.EditValue, tjml.EditValue, tket.Text.Trim, userprog, convert_date_to_eng(Date.Now.ToString), tbukti.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_KASBON", "EDIT", "KASBON SUPIR")

            sqltrans.Commit()

            update_view()

            MsgBox("Data telah dirubah..", MsgBoxStyle.Information, "Informasi")
            ms_supir.refresh_data()

            close_wait()

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

            tbukti.Text = classmy.GET_KODE_KASBON(get_kode_stat, cn, ttgl.EditValue, cbjenis.Text)

            sql_search = String.Format("select no_bukti from admlsp.TR_KASBON where no_bukti='{0}'", tbukti.Text.Trim)
            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                tbukti.Text = classmy.GET_KODE_KASBON(get_kode_stat, cn, ttgl.EditValue, cbjenis.Text)
                'MsgBox("Kode sudah ada", MsgBoxStyle.Information, "Informasi")
                'tbukti.Focus()
                'Exit Sub
            Else
                dre.Close()
            End If


            sql = String.Format("insert into admlsp.TR_KASBON (no_bukti,tanggal,kd_supir,kode_kas,jenis,kd_stat,keterangan,jml,user_add,tgl_add) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}','{9}')", tbukti.Text.Trim.ToUpper, tgl, tkodesup.Text.Trim, cbkas.EditValue, cbjenis.Text.Trim, get_kode_stat, tket.Text.Trim, tjml.EditValue, userprog, convert_date_to_eng(Date.Now.ToString))
            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_KASBON", "INSERT", "KASBON SUPIR")

            sqltrans.Commit()

            insert_view()

            close_wait()

            MsgBox("Data telah disimpan... ", MsgBoxStyle.Information, "Informasi")

            addjml = addjml + 1

            kosongkan()
            ttgl.Focus()

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

        Dim orow As DataRow

        orow = dv.Table.NewRow()

        orow("NO_BUKTI") = tbukti.Text

        If ttgl.Text = "" Then
            orow("TANGGAL") = DBNull.Value
        Else
            orow("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        orow("JENIS") = cbjenis.Text.Trim
        orow("KD_SUPIR") = tkodesup.Text.Trim
        orow("NAMA_SUPIR") = tnamasup.Text.Trim
        orow("KODE_KAS") = cbkas.EditValue
        orow("NAMA_KAS") = cbkas.Text.Trim
        orow("KETERANGAN") = tket.Text.Trim
        orow("JML") = tjml.EditValue

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()


        If ttgl.Text = "" Then
            dv(posi)("TANGGAL") = DBNull.Value
        Else
            dv(posi)("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        dv(posi)("KD_SUPIR") = tkodesup.Text.Trim
        dv(posi)("NAMA_SUPIR") = tnamasup.Text.Trim
        dv(posi)("KODE_KAS") = cbkas.EditValue
        dv(posi)("NAMA_KAS") = cbkas.Text.Trim
        dv(posi)("KETERANGAN") = tket.Text.Trim
        dv(posi)("JML") = tjml.EditValue

    End Sub

    Private Sub tkode_spir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkodesup.KeyDown
        If e.KeyCode = 13 Then
            cbkas.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'tnama_spir.Text.Trim
            tkodesup.Text = ""
            tnamasup.Text = ""

            Using fcari As New s_supir(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkodesup.Text = fcari.get_kode
                tnamasup.Text = fcari.get_nama

            End Using

        End If
    End Sub

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click

        Dim cari As String = ""


        Using fcari As New s_supir(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkodesup.Text = fcari.get_kode
            tnamasup.Text = fcari.get_nama

        End Using


    End Sub

    Private Sub tkode_spir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkodesup.Validating

        If tkodesup.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            sql = String.Format("select a.KD_SUPIR,a.NAMA from admlsp.MS_SUPIR a where a.AKTIF=1 and a.KD_SUPIR='{0}'", tkodesup.Text.Trim)


            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tkodesup.Text = dred(0).ToString
                    tnamasup.Text = dred(1).ToString
                    dred.Close()

                Else

                    dred.Close()
                    MsgBox("Kode supir tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tkodesup.Focus()
                    tnamasup.Text = ""


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

            tkodesup.Text = ""
            tnamasup.Text = ""

        End If


    End Sub

    Private Sub ms_dep2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            cbjenis.Focus()
        Else
            ttgl.Focus()
        End If
    End Sub

    Private Sub ms_toko2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            cbkas.Properties.ReadOnly = False

            kosongkan()
            cbjenis.SelectedIndex = 0
            btsimpan.Text = "&Simpan"

        Else

            cbkas.Properties.ReadOnly = True

            isi_box()
            btsimpan.Text = "&Rubah"
        End If



    End Sub

    Private Sub cbjenis_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbjenis.KeyDown
        If e.KeyCode = 13 Then
            ttgl.Focus()
        End If
    End Sub

    Private Sub ttgl_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        If e.KeyCode = 13 Then
            tkodesup.Focus()
        End If
    End Sub

    Private Sub cbkas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbkas.KeyDown
        If e.KeyCode = 13 Then
            tjml.Focus()
        End If
    End Sub

    Private Sub tjml_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tjml.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        End If
    End Sub

    Private Sub tket_keydown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tket.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            tr_kasbon.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tbukti.Text = "" Then

            MsgBox("No bukti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tbukti.Focus()
            Exit Sub
        End If

        If tkodesup.Text = "" Then

            MsgBox("Supir tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tkodesup.Focus()
            Exit Sub
        End If

        If cbkas.Text = "" Then

            MsgBox("Kas tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            cbkas.Focus()
            Exit Sub
        End If

        If cbjenis.Text = "" Then

            MsgBox("Jenis transaksi tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            cbjenis.Focus()
            Exit Sub
        End If


        If tjml.EditValue = 0 Then

            MsgBox("Jml tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tjml.Focus()
            Exit Sub

        End If


        If statadd.Equals(True) Then
            insert()
        Else
            edit()
        End If


    End Sub

End Class