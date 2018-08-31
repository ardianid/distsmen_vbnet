Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_byartoko2

    Private statadd As Boolean
    Private dv As DataView
    Private dv1 As DataView
    Private posi As Integer = 0
    Private addjml As Integer = 0
    Private dvmanager As Data.DataViewManager

    Sub New(ByVal adstat As Boolean, ByVal dv1 As DataView, ByVal pos As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        statadd = adstat
        dv = dv1
        posi = pos
        addjml = 0
    End Sub

    Private Sub kosongkan()

        tbukti.Text = "<< New >>"
        ttgl.EditValue = Date.Now
        tkodetok.Text = ""
        tnamatok.Text = ""
        talamattok.Text = ""
        tket.Text = ""

        dv1 = New DataView
        dv1 = Nothing

        grid1.DataSource = Nothing

        tkodetok.Enabled = True
        tkodetok.Properties.ReadOnly = False
        btfind.Enabled = True

    End Sub

    Private Sub isi_grid()

        Dim ds As DataSet
        Dim cn As OracleConnection = Nothing


        Dim sql As String = String.Format("SELECT A.GIRO_CAIR,A.NO_REALISASI,A.JML,A.JML_DEPOSIT,A.JML_TUNAI,A.JML_GIRO,A.NO_GIRO,D.TGL_TEMPO,A.JML_TOT,B.TANGGAL || chr(13) || chr(10) || C.NAMA || ' - ' || B.NOPOL AS INFO_REAL,'EDIT' as STAT_GRID,A.JML_DEPOSIT as JML_DEPOSIT_OLD " & _
            "FROM ADMLSP.TR_TKO_BYAR_DETAIL A INNER JOIN ADMLSP.TR_REAL_ORDER B ON A.NO_REALISASI= B.NODO " & _
            "INNER JOIN ADMLSP.MS_SUPIR C ON B.KD_SUPIR=C.KD_SUPIR LEFT JOIN ADMLSP.MS_GIRO D ON A.NO_GIRO=D.NO_GIRO WHERE A.NO_BUKTI='{0}'", tbukti.Text.Trim)

        grid1.DataSource = Nothing
        Try

            dv1 = Nothing

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            dv1.Sort = "NO_REALISASI"

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
        tkodetok.Text = dv(posi)("KODE_TOKO").ToString
        tnamatok.Text = dv(posi)("NAMA_TOKO").ToString
        talamattok.Text = dv(posi)("ALAMAT").ToString
        tket.Text = dv(posi)("KETERANGAN").ToString

    End Sub

    Private Sub edit(ByVal refreshd As Boolean)

        If tbukti.Text.Trim = "<< NEW >>" Then
            Exit Sub
        End If

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim JMDEPOSIT As Double = gridview.Columns("JML_DEPOSIT").SummaryItem.SummaryValue
        Dim JMTUNAI As Double = gridview.Columns("JML_TUNAI").SummaryItem.SummaryValue
        Dim JMGIRO As Double = gridview.Columns("JML_GIRO").SummaryItem.SummaryValue
        Dim JMPIU As Double = gridview.Columns("JML").SummaryItem.SummaryValue

        Dim TOTAL As Double = JMDEPOSIT + JMTUNAI + JMGIRO

        Dim sql As String = String.Format("update admlsp.TR_TKO_BYAR_HEADER set tanggal='{0}',kode_toko='{1}',keterangan='{2}',tot_deposit={3},tot_tunai={4},tot_giro={5},total={6},tot_jml={7},user_edit='{8}',tgl_edit='{9}'" & _
                                          " where no_bukti='{10}'", tgl, tkodetok.Text.Trim, tket.Text.Trim, JMDEPOSIT, JMTUNAI, JMGIRO, TOTAL, JMPIU, userprog, convert_date_to_eng(Date.Now.ToString), tbukti.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_TKO_BYAR_HEADER", "UPDATE", "PEMBAYARAN DO")

            manipulate2(cn)

            sqltrans.Commit()

            update_view()

            If refreshd = False Then
                MsgBox("Data telah dirubah..", MsgBoxStyle.Information, "Informasi")
                'ms_supir.refresh_data()
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

    Private Sub insert()

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim JMDEPOSIT As Double = gridview.Columns("JML_DEPOSIT").SummaryItem.SummaryValue
        Dim JMTUNAI As Double = gridview.Columns("JML_TUNAI").SummaryItem.SummaryValue
        Dim JMGIRO As Double = gridview.Columns("JML_GIRO").SummaryItem.SummaryValue
        Dim JMPIU As Double = gridview.Columns("JML").SummaryItem.SummaryValue

        Dim TOTAL As Double = JMDEPOSIT + JMTUNAI + JMGIRO

        Dim sql As String = ""
        Dim sql_search As String = ""


        Dim cmd As OracleCommand
        Dim cn As OracleConnection = Nothing
        Dim dre As OracleDataReader = Nothing
        Dim cmdsearch As OracleCommand

        Try

            open_wait()
            cn = classmy.open_conn_utama

            tbukti.Text = classmy.GET_KODE_PELUNASANTOK(get_kode_stat, cn, ttgl.EditValue)

            sql_search = String.Format("select no_bukti from admlsp.TR_TKO_BYAR_HEADER where no_bukti='{0}'", tbukti.Text.Trim)
            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                tbukti.Text = classmy.GET_KODE_PELUNASANTOK(get_kode_stat, cn, ttgl.EditValue)
                'MsgBox("Kode sudah ada", MsgBoxStyle.Information, "Informasi")
                'tbukti.Focus()
                'Exit Sub
            Else
                dre.Close()
            End If

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            sql = String.Format("insert into admlsp.TR_TKO_BYAR_HEADER (no_bukti,tanggal,kode_toko,kd_stat,keterangan,tot_deposit,tot_tunai,tot_giro,total,tot_jml,user_add,tgl_add) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8},{9},'{10}','{11}')", tbukti.Text.Trim.ToUpper, tgl, tkodetok.Text.Trim, get_kode_stat, tket.Text.Trim, JMDEPOSIT, JMTUNAI, JMGIRO, TOTAL, JMPIU, userprog, convert_date_to_eng(Date.Now.ToString))
            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_TKO_BYAR_HEADER", "INSERT", "PEMBAYARAN DO")

            manipulate2(cn)

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


            Me.Close()

        End Try

    End Sub

    Private Sub manipulate2(ByVal cn As OracleConnection)

        Dim cmd As OracleCommand
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim cmd2 As OracleCommand
        Dim dread As OracleDataReader
        Dim jmdep As Double = 0
        Dim jmtunai As Double = 0
        Dim jmgiro As Double = 0
        Dim jm As Double = 0
        Dim jmtot As Double = 0

        If Not IsNothing(dv1) Then

            If dv1.Count > 0 Then

                Dim i As Integer = 0
                For i = 0 To dv1.Count - 1

                    jm = 0 : jmdep = 0 : jmtunai = 0 : jmgiro = 0 : jmtot = 0

                    jm = dv1(i)("JML").ToString
                    jmdep = dv1(i)("JML_DEPOSIT").ToString
                    jmtunai = dv1(i)("JML_TUNAI").ToString
                    jmgiro = dv1(i)("JML_GIRO").ToString

                    jmtot = jmdep + jmtunai + jmgiro


                    sql2 = String.Format("select no_bukti from admlsp.TR_TKO_BYAR_DETAIL where no_bukti='{0}' and no_realisasi='{1}'", tbukti.Text.Trim, dv1(i)("NO_REALISASI").ToString)
                    cmd2 = New OracleCommand(sql2, cn)
                    dread = cmd2.ExecuteReader

                    If dread.Read Then

                        dread.Close()

                        sql = String.Format("update admlsp.TR_TKO_BYAR_DETAIL set jml={0},jml_deposit={1},jml_tunai={2},jml_giro={3},no_giro='{4}',jml_tot={5} where no_bukti='{6}' and no_realisasi='{7}'", jm, jmdep, jmtunai, jmgiro, dv1(i)("NO_GIRO").ToString, jmtot, tbukti.Text.Trim, dv1(i)("NO_REALISASI").ToString)

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_TKO_BYAR_DETAIL", "UPDATE", "PEMBAYARAN DO")

                    Else

                        dread.Close()

                        sql = String.Format("insert into admlsp.TR_TKO_BYAR_DETAIL (no_bukti,no_realisasi,jml,jml_deposit,jml_tunai,jml_giro,no_giro,jml_tot) values('{0}','{1}',{2},{3},{4},{5},'{6}',{7})", tbukti.Text.Trim, dv1(i)("NO_REALISASI").ToString, jm, jmdep, jmtunai, jmgiro, dv1(i)("NO_GIRO").ToString, jmtot)

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_TKO_BYAR_DETAIL", "INSERT", "PEMBAYARAN DO")

                    End If

                Next

            End If

        End If


    End Sub

    Private Sub insert_view()

        Dim JMDEPOSIT As Double = gridview.Columns("JML_DEPOSIT").SummaryItem.SummaryValue
        Dim JMTUNAI As Double = gridview.Columns("JML_TUNAI").SummaryItem.SummaryValue
        Dim JMGIRO As Double = gridview.Columns("JML_GIRO").SummaryItem.SummaryValue
        Dim JMPIU As Double = gridview.Columns("JML").SummaryItem.SummaryValue

        Dim TOTAL As Double = JMDEPOSIT + JMTUNAI + JMGIRO

        Dim orow As DataRow = dv.Table.NewRow

        orow("NO_BUKTI") = tbukti.Text

        If ttgl.Text = "" Then
            orow("TANGGAL") = DBNull.Value
        Else
            orow("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        orow("KODE_TOKO") = tkodetok.Text.Trim
        orow("NAMA_TOKO") = tnamatok.Text.Trim
        orow("ALAMAT") = talamattok.Text.Trim

        orow("KETERANGAN") = tket.Text.Trim

        orow("TOTAL") = TOTAL
        orow("TOT_DEPOSIT") = JMDEPOSIT
        orow("TOT_TUNAI") = JMTUNAI
        orow("TOT_GIRO") = JMGIRO
        orow("TOT_JML") = JMPIU

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        Dim JMDEPOSIT As Double = gridview.Columns("JML_DEPOSIT").SummaryItem.SummaryValue
        Dim JMTUNAI As Double = gridview.Columns("JML_TUNAI").SummaryItem.SummaryValue
        Dim JMGIRO As Double = gridview.Columns("JML_GIRO").SummaryItem.SummaryValue
        Dim JMPIU As Double = gridview.Columns("JML").SummaryItem.SummaryValue

        Dim TOTAL As Double = JMDEPOSIT + JMTUNAI + JMGIRO

        If ttgl.Text = "" Then
            dv(posi)("TANGGAL") = DBNull.Value
        Else
            dv(posi)("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        dv(posi)("KODE_TOKO") = tkodetok.Text.Trim
        dv(posi)("NAMA_TOKO") = tnamatok.Text.Trim
        dv(posi)("ALAMAT") = talamattok.Text.Trim

        dv(posi)("KETERANGAN") = tket.Text.Trim

        dv(posi)("TOTAL") = TOTAL
        dv(posi)("TOT_DEPOSIT") = JMDEPOSIT
        dv(posi)("TOT_TUNAI") = JMTUNAI
        dv(posi)("TOT_GIRO") = JMGIRO
        dv(posi)("TOT_JML") = JMPIU

    End Sub

    Private Sub hapus_detail()

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Dim cn As OracleConnection = Nothing
        Dim sql As String = String.Format("delete from admlsp.TR_TKO_BYAR_DETAIL where no_bukti='{0}' and no_realisasi='{1}'", tbukti.Text.Trim, dv1(Me.BindingContext(dv1).Position)("NO_REALISASI").ToString)
        Dim cmd As OracleCommand

        Dim sql2 As String = String.Format("update admlsp.TR_TKO_BYAR_HEADER SET USER_EDIT='{0}',TGL_EDIT='{1}' WHERE NO_BUKTI='{2}'", userprog, convert_date_to_eng(Date.Now.ToString), tbukti.Text.Trim)
        Dim cmd2 As OracleCommand

        Try

            cn = classmy.open_conn_utama
            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd2 = New OracleCommand(sql2, cn)
            cmd2.ExecuteNonQuery()

            ins_to_temp_user(cn, sql2, tbukti.Text.Trim, "TR_TKO_BYAR_DETAIL", "DELETE", "PEMBAYARAN DO")

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_TKO_BYAR_DETAIL", "DELETE", "PEMBAYARAN DO")

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

    Private Sub tnama_toko_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkodetok.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'nama_toko.Text.Trim
            tnamatok.Text = ""
            talamattok.Text = ""

            Using fcari As New sr_toko(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkodetok.Text = fcari.get_kode
                tnamatok.Text = fcari.get_nama
                talamattok.Text = fcari.get_alamat_toko

            End Using

        End If
    End Sub

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click

        Dim cari As String = "" 'tnama_toko.Text.Trim"

        Using fcari As New sr_toko(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkodetok.Text = fcari.get_kode
            tnamatok.Text = fcari.get_nama
            talamattok.Text = fcari.get_alamat_toko

        End Using


    End Sub

    Private Sub tnama_toko_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkodetok.Validating

        If tkodetok.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            If get_stat_pusat() = 1 Then
                sql = String.Format("select a.KD_TOKO,a.NAMA_TOKO,a.ALAMAT from admlsp.ms_toko a where a.AKTIF=1 and a.KD_TOKO='{0}'", tkodetok.Text.Trim)
            ElseIf get_stat_pusat() = 0 Then
                sql = String.Format("select a.KD_TOKO,a.NAMA_TOKO,a.ALAMAT from admlsp.ms_toko a where a.AKTIF=1 and a.KD_TOKO='{0}' and a.KODE_STAT='{1}'", tkodetok.Text.Trim, get_kode_stat)
            End If


            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tkodetok.Text = dred(0).ToString
                    tnamatok.Text = dred(1).ToString
                    talamattok.Text = dred(2).ToString

                Else

                    MsgBox("Toko tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tkodetok.Focus()
                    tnamatok.Text = ""
                    talamattok.Text = ""
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
            tkodetok.Text = ""
            tnamatok.Text = ""
            talamattok.Text = ""
        End If

    End Sub

    Private Sub tbukti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbukti.KeyDown
        If e.KeyCode = 13 Then
            ttgl.Focus()
        End If
    End Sub

    Private Sub ttgl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        If e.KeyCode = 13 Then
            tkodetok.Focus()
        End If
    End Sub

    Private Sub tket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tket.KeyDown
        If e.KeyCode = 13 Then
            btadd_det.Focus()
        End If
    End Sub

    Private Sub tr_dep_toko2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            ttgl.Focus()
        Else
            ttgl.Focus()
        End If
    End Sub

    Private Sub tr_dep_toko2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            ' tbukti.Enabled = True

            kosongkan()

            btsimpan.Text = "&Simpan"

            ttgl.Properties.ReadOnly = False
            tkodetok.Properties.ReadOnly = False
            'bted_det.Enabled = True
            btfind.Enabled = True

        Else

            '  tbukti.Enabled = False

            isi_box()

            btsimpan.Text = "&Rubah"

            ttgl.Properties.ReadOnly = True
            tkodetok.Properties.ReadOnly = True
            'bted_det.Enabled = False
            btfind.Enabled = False

        End If

        isi_grid()

    End Sub

    Private Sub btadd_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btadd_det.Click

        If tkodetok.Text = "" Then

            MsgBox("Toko harus diisi dulu", MsgBoxStyle.Information, "Informasi")
            tkodetok.Focus()
            Exit Sub

        End If

        tkodetok.Properties.ReadOnly = True
        btfind.Enabled = False

        Using fspare3 As New tr_byartoko3(False, dv1, 0, tkodetok.Text.Trim) With {.StartPosition = FormStartPosition.CenterParent}
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

        If tkodetok.Text = "" Then

            MsgBox("Toko harus diisi dulu", MsgBoxStyle.Information, "Informasi")
            tkodetok.Focus()
            Exit Sub

        End If

        tkodetok.Properties.ReadOnly = True
        btfind.Enabled = False

        If dv1(Me.BindingContext(dv1).Position)("GIRO_CAIR") = 1 And Not (dv1(Me.BindingContext(dv1).Position)("NO_GIRO").ToString = "") Then
            MsgBox("Data tidak dapat dirubah karna giro telah cair", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        End If

        Using fspare3 As New tr_byartoko3(True, dv1, Me.BindingContext(dv1).Position, tkodetok.Text.Trim) With {.StartPosition = FormStartPosition.CenterParent}
            fspare3.ShowDialog(Me)
        End Using



    End Sub

    Private Sub btdel_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btdel_det.Click

        tkodetok.Properties.ReadOnly = True
        btfind.Enabled = False

        If dv1(Me.BindingContext(dv1).Position)("GIRO_CAIR") = 1 And Not (dv1(Me.BindingContext(dv1).Position)("NO_GIRO").ToString = "") Then
            MsgBox("Data tidak dapat dirubah karna giro telah cair", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        End If

        hapus_detail()

        If dv1.Count < 1 Then
            tkodetok.Properties.ReadOnly = False
            btfind.Enabled = True
        ElseIf IsNothing(dv1) Then
            tkodetok.Properties.ReadOnly = False
            btfind.Enabled = True
        End If

    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            tr_byartoko.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tbukti.Text = "" Then

            MsgBox("No bukti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tbukti.Focus()
            Exit Sub
        End If

        If tkodetok.Text = "" Then

            MsgBox("Toko tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tkodetok.Focus()
            Exit Sub
        End If

        If IsNothing(dv1) Then
            MsgBox("Pelunasan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            btadd_det.Focus()
            Exit Sub
        End If

        If dv1.Count <= 0 Then

            MsgBox("Pelunasan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            btadd_det.Focus()
            Exit Sub
        End If


        If statadd.Equals(True) Then
            insert()
        Else
            edit(False)
        End If


    End Sub

End Class