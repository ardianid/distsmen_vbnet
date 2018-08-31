Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_pre2

    Private statadd As Boolean
    Private dv As DataView
    Private dv1 As DataView
    Private posi As Integer = 0
    Private addjml As Integer = 0
    Private kodekab As String = String.Empty

    Sub New(ByVal adstat As Boolean, ByVal dv1 As DataView, ByVal pos As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        statadd = adstat
        dv = dv1
        posi = pos
        addjml = 0

        isi_combo()
        isi_combo2()

    End Sub

    Private Sub kosongkan()

        tbukti.Text = ""
        ttgl.EditValue = Date.Now
        tkode_spir.Text = ""
        tnama_spir.Text = ""
        tket.Text = ""
        tkodekso.Text = ""
        tnamakso.Text = ""
        tkodetok.Text = ""
        tnamatok.Text = ""
        talamattok.Text = ""
        toks_akt.EditValue = 0
        ttot_oks.EditValue = 0

        toks_akt.Properties.ReadOnly = True

        dv1 = New DataView
        dv1 = Nothing

        grid1.DataSource = Nothing

    End Sub

    Private Sub isi_combo()

        Const sql = "SELECT A.KD_PRC,A.NAMA,A.ALAMAT FROM ADMLSP.MS_PRINCIPAL A WHERE A.AKTIF=1 ORDER BY A.NAMA ASC"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv2 As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv2 = dvm.CreateDataView(ds.Tables(0))

            cbprinc.Properties.DataSource = dv2


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

    Private Sub isi_combo2()

        Const sql = "SELECT B.NOPOL FROM ADMLSP.MS_KENDARAAN B WHERE B.AKTIF=1 ORDER BY B.NOPOL ASC"

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


        Dim sql As String = String.Format("SELECT A.KD_BARANG,B.NAMA,A.JML,A.SATUAN,A.HARGA,A.TOTAL,0 as HARGABELI FROM ADMLSP.TR_PRE2 A INNER JOIN ADMLSP.MS_BARANG B ON A.KD_BARANG=B.KODE" & _
                " WHERE A.NO_BUKTI='{0}' ORDER BY A.KD_BARANG ASC", tbukti.Text.Trim)

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

    Private Sub isi_box()

        tbukti.Enabled = False
        tbukti.Text = dv(posi)("NO_BUKTI").ToString
        ttgl.Text = convert_date_to_ind(dv(posi)("TANGGAL").ToString)
        cbprinc.EditValue = dv(posi)("KD_PRC").ToString

        tkodekso.Text = dv(posi)("KD_KSO").ToString
        tnamakso.Text = dv(posi)("NAMA_KSO").ToString
        talamatkso.Text = dv(posi)("ALAMAT_KSO").ToString

        tkodetok.Text = dv(posi)("KD_TOKO").ToString

        tnama_toko_Validating(Nothing, Nothing)

        tnamatok.Text = dv(posi)("NAMA_TOKO").ToString
        talamattok.Text = dv(posi)("ALAMAT_TOKO").ToString

        tkode_spir.Text = dv(posi)("KD_SUPIR").ToString
        tnama_spir.Text = dv(posi)("NAMA_SUPIR").ToString
        cbnopol.EditValue = dv(posi)("NOPOL").ToString
        tket.Text = dv(posi)("KETERANGAN").ToString

        toks_akt.EditValue = dv(posi)("OKS_KSO").ToString
        ttot_oks.EditValue = dv(posi)("TOT_OKS_KSO").ToString

        If toks_akt.EditValue = 0 Then
            toks_akt.Properties.ReadOnly = True
        End If

        'isi_grid()

    End Sub

    Private Sub edit(ByVal refreshd As Boolean)

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim jenis_akt As String
        If tkodekso.Text.Trim.Length = 0 Then
            jenis_akt = "as"
        Else
            jenis_akt = "perangko"
        End If

        Dim sql As String = String.Format("update admlsp.TR_PRE set tanggal='{0}',nopol='{1}',kd_supir='{2}',nama_supir='{3}',kd_prc='{4}',keterangan='{5}', tot_jml={6},tot_harga={7},user_edit='{8}',tgl_edit='{9}',kd_toko='{10}',kd_kso='{11}',jns_akt='{12}',oks_kso={13},tot_oks_kso={14}" & _
                                          " where no_bukti='{15}'", tgl, cbnopol.EditValue, tkode_spir.Text.Trim, tnama_spir.Text.Trim, cbprinc.EditValue, tket.Text.Trim, gridview.Columns("JML").SummaryItem.SummaryValue, Replace(gridview.Columns("TOTAL").SummaryItem.SummaryValue, ",", "."), userprog, convert_date_to_eng(Date.Now.ToString), tkodetok.Text.Trim, tkodekso.Text.Trim, jenis_akt.ToUpper, toks_akt.EditValue, ttot_oks.EditValue, tbukti.Text.Trim)

        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_PRE", "UPDATE", "PRE RELEASE")

            manipulate2(cn)

            sqltrans.Commit()

            update_view()

            If refreshd = False Then
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

    Private Sub insert()

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim jenis_akt As String
        If tkodekso.Text.Trim.Length = 0 Then
            jenis_akt = "as"
        Else
            jenis_akt = "perangko"
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

            limit_not = 0
            limit_vl = 0
            rlimit_not = 0
            rlimit_vl = 0

            ceklimit_toko(tkodetok.Text.Trim, cn)

            If rlimit_not > limit_not Then
                If rlimit_not > 0 And limit_not > 0 Then
                    MsgBox(String.Format("Toko melebihi limit nota, Limit:Real={0}:{1}", limit_not, rlimit_not), vbOKOnly + vbCritical, "Konfirmasi")
                    close_wait()
                    Return
                End If
            End If

            If rlimit_vl > limit_vl Then
                If rlimit_vl > 0 And limit_vl > 0 Then
                    MsgBox(String.Format("Toko melebihi limit value, Limit:Real={0}:{1}", limit_vl, rlimit_vl), vbOKOnly + vbCritical, "Konfirmasi")
                    close_wait()
                    Return
                End If
            End If

            '    tbukti.Text = classmy.GET_KODE_PREREAL(get_kode_stat, cn, ttgl.EditValue)

            sql_search = String.Format("select no_bukti from admlsp.TR_PRE where no_bukti='{0}'", tbukti.Text.Trim)
            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                '    tbukti.Text = classmy.GET_KODE_PREREAL(get_kode_stat, cn, ttgl.EditValue)
                MsgBox("Kode sudah ada", MsgBoxStyle.Information, "Informasi")
                tbukti.Focus()
                Exit Sub
            Else
                dre.Close()
            End If


            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            sql = String.Format("insert into admlsp.TR_PRE (no_bukti,tanggal,nopol,kd_supir,nama_supir,kd_prc,kd_stat,keterangan,tot_jml,tot_harga,user_add,tgl_add,kd_kso,kd_toko,jns_akt,oks_kso,tot_oks_kso) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},{9},'{10}','{11}','{12}','{13}','{14}',{15},{16})", tbukti.Text.Trim.ToUpper, tgl, cbnopol.EditValue, tkode_spir.Text.Trim, tnama_spir.Text.Trim, cbprinc.EditValue, get_kode_stat, tket.Text.Trim, gridview.Columns("JML").SummaryItem.SummaryValue, Replace(gridview.Columns("TOTAL").SummaryItem.SummaryValue, ",", "."), userprog, convert_date_to_eng(Date.Now.ToString), tkodekso.Text.Trim, tkodetok.Text.Trim, jenis_akt.ToUpper, toks_akt.EditValue, ttot_oks.EditValue)
            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_PRE", "INSERT", "PRE RELEASE")

            manipulate2(cn)

            sqltrans.Commit()

            insert_view()

            close_wait()

            MsgBox("Data telah disimpan... ", MsgBoxStyle.Information, "Informasi")

            addjml = addjml + 1

            Me.Close()
            'kosongkan()
            'tbukti.Focus()


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

                    sql2 = String.Format("select no_bukti from admlsp.TR_PRE2 where no_bukti='{0}' and kd_barang='{1}'", tbukti.Text.Trim, dv1(i)("KD_BARANG").ToString)
                    cmd2 = New OracleCommand(sql2, cn)
                    dread = cmd2.ExecuteReader

                    If dread.Read Then

                        dread.Close()

                        sql = String.Format("update admlsp.TR_PRE2 set jml={0},satuan='{1}',harga={2},total={3} where no_bukti='{4}' and kd_barang='{5}'", dv1(i)("JML").ToString, dv1(i)("SATUAN").ToString, Replace(dv1(i)("HARGA").ToString, ",", "."), Replace(dv1(i)("TOTAL").ToString, ",", "."), tbukti.Text.Trim, dv1(i)("KD_BARANG").ToString)

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_PRE2", "UPDATE", "PRE RELEASE")

                    Else

                        dread.Close()

                        sql = String.Format("insert into admlsp.TR_PRE2 (no_bukti,kd_barang,jml,satuan,harga,total) values('{0}','{1}',{2},'{3}',{4},{5})", tbukti.Text.Trim, dv1(i)("KD_BARANG").ToString, dv1(i)("JML").ToString, dv1(i)("SATUAN").ToString, Replace(dv1(i)("HARGA").ToString, ",", "."), Replace(dv1(i)("TOTAL").ToString, ",", "."))

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_PRE2", "INSERT", "PRE RELEASE")

                    End If

                Next

            End If

        End If


    End Sub

    Private Sub insert_view()

        Dim orow As DataRow = dv.Table.NewRow

        orow("NO_BUKTI") = tbukti.Text

        If ttgl.Text = "" Then
            orow("TANGGAL") = DBNull.Value
        Else
            orow("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        orow("KD_PRC") = cbprinc.EditValue
        orow("PRINCIPAL") = cbprinc.Text
        orow("KD_SUPIR") = tkode_spir.Text.Trim
        orow("NAMA_SUPIR") = tnama_spir.Text.Trim
        orow("NOPOL") = cbnopol.EditValue
        orow("KETERANGAN") = tket.Text.Trim
        orow("TOT_JML") = gridview.Columns("JML").SummaryItem.SummaryValue
        orow("JML_DATANG") = 0
        orow("TOT_HARGA") = gridview.Columns("TOTAL").SummaryItem.SummaryValue

        orow("KD_KSO") = tkodekso.Text.Trim
        orow("NAMA_KSO") = tnamakso.Text.Trim
        orow("ALAMAT_KSO") = talamatkso.Text.Trim

        orow("KD_TOKO") = tkodetok.Text.Trim
        orow("NAMA_TOKO") = tnamatok.Text.Trim
        orow("ALAMAT_TOKO") = talamattok.Text.Trim

        orow("OKS_KSO") = toks_akt.EditValue
        orow("TOT_OKS_KSO") = ttot_oks.EditValue

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()


        If ttgl.Text = "" Then
            dv(posi)("TANGGAL") = DBNull.Value
        Else
            dv(posi)("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        dv(posi)("KD_PRC") = cbprinc.EditValue
        dv(posi)("PRINCIPAL") = cbprinc.Text
        dv(posi)("KD_SUPIR") = tkode_spir.Text.Trim
        dv(posi)("NAMA_SUPIR") = tnama_spir.Text.Trim
        dv(posi)("NOPOL") = cbnopol.EditValue
        dv(posi)("KETERANGAN") = tket.Text.Trim
        dv(posi)("TOT_JML") = gridview.Columns("JML").SummaryItem.SummaryValue
        dv(posi)("JML_DATANG") = 0
        dv(posi)("TOT_HARGA") = gridview.Columns("TOTAL").SummaryItem.SummaryValue

        dv(posi)("KD_KSO") = tkodekso.Text.Trim
        dv(posi)("NAMA_KSO") = tnamakso.Text.Trim
        dv(posi)("ALAMAT_KSO") = talamatkso.Text.Trim

        dv(posi)("KD_TOKO") = tkodetok.Text.Trim
        dv(posi)("NAMA_TOKO") = tnamatok.Text.Trim
        dv(posi)("ALAMAT_TOKO") = talamattok.Text.Trim

        dv(posi)("OKS_KSO") = toks_akt.EditValue
        dv(posi)("TOT_OKS_KSO") = ttot_oks.EditValue

    End Sub

    Private Sub hapus_detail()

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Dim cn As OracleConnection = Nothing
        Dim sql As String = String.Format("delete from admlsp.TR_PRE2 where no_bukti='{0}' and kd_barang='{1}'", tbukti.Text.Trim, dv1(Me.BindingContext(dv1).Position)("KD_BARANG").ToString)
        Dim cmd As OracleCommand

        Try

            cn = classmy.open_conn_utama
            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_PRE2", "DELETE", "PRE RELEASE")

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

    Private Sub kalkulasi_oks_angkut()

        Dim jml As Double
        If IsNothing(gridview.Columns("JML").SummaryItem.SummaryValue) Then
            jml = 0
        ElseIf Not IsNumeric(gridview.Columns("JML").SummaryItem.SummaryValue) Then
            jml = 0
        Else
            jml = CDbl(gridview.Columns("JML").SummaryItem.SummaryValue)
        End If


        ttot_oks.EditValue = CDbl(toks_akt.EditValue) * jml

    End Sub

    Private Sub tnama_spir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkode_spir.KeyDown
        If e.KeyCode = 13 Then
            cbnopol.Focus()
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

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click

        Dim cari As String = tnama_spir.Text.Trim

        Using fcari As New s_supir(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkode_spir.Text = fcari.get_kode
            tnama_spir.Text = fcari.get_nama

        End Using


    End Sub

    Private Sub tr_pre2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            tbukti.Focus()
        Else
            ttgl.Focus()
        End If
    End Sub

    Private Sub tr_pre2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            tbukti.Enabled = True

            kosongkan()
        Else

            tbukti.Enabled = False


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
            cbprinc.Focus()
        End If
    End Sub

    Private Sub tnamatok_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkodetok.KeyDown
        If e.KeyCode = 13 Then
            tkode_spir.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'tnamatok.Text.Trim
            tnamatok.Text = ""
            tkodetok.Text = ""

            Using fcari As New sr_toko(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkodetok.Text = fcari.get_kode
                tnamatok.Text = fcari.get_nama
                talamattok.Text = fcari.get_alamat_toko

            End Using

        End If
    End Sub

    Private Sub btfindTok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfindtok.Click

        Dim cari As String = "" 'tnamatok.Text.Trim

        Using fcari As New sr_toko(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkodetok.Text = fcari.get_kode
            tnamatok.Text = fcari.get_nama
            talamattok.Text = fcari.get_alamat_toko

            If tkodetok.Text.Length > 0 Then
                tnama_toko_Validating(sender, Nothing)
            End If


        End Using


    End Sub

    Private Sub tnama_toko_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkodetok.Validating

        If tkodetok.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            If get_stat_pusat() = 1 Then
                sql = String.Format("select a.KD_TOKO,a.NAMA_TOKO,a.TIPE_HARGA,a.ALAMAT,a.KD_TBS AS KODE_KAB from admlsp.ms_toko a inner join admlsp.ms_kec b on a.KD_KEC=b.KODE where a.AKTIF=1 and a.KD_TOKO='{0}'", tkodetok.Text.Trim)
            ElseIf get_stat_pusat() = 0 Then
                sql = String.Format("select a.KD_TOKO,a.NAMA_TOKO,a.TIPE_HARGA,a.ALAMAT,a.KD_TBS AS KODE_KAB from admlsp.ms_toko a inner join admlsp.ms_kec b on a.KD_KEC=b.KODE where a.AKTIF=1 and a.KODE_STAT='{0}' and a.KD_TOKO='{1}'", get_kode_stat, tkodetok.Text.Trim)
            Else
                Exit Sub
            End If


            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tkodetok.Text = dred(0).ToString
                    tnamatok.Text = dred(1).ToString
                    talamattok.Text = dred(3).ToString

                    kodekab = dred(4).ToString

                    dred.Close()

                Else

                    dred.Close()
                    MsgBox("Nama toko tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tkodetok.Focus()
                    tnamatok.Text = ""
                    talamattok.Text = ""

                    kodekab = ""

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

            kodekab = ""

        End If


    End Sub


    Private Sub tkodekso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkodekso.KeyDown
        If e.KeyCode = 13 Then

            If tkodekso.Text.Trim.Length > 0 Then
                toks_akt.Focus()
            Else
                tkodetok.Focus()
            End If


        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'tnamatok.Text.Trim
            tnamatok.Text = ""
            tkodetok.Text = ""

            Using fcari As New sr_kso(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkodekso.Text = fcari.get_kode
                tnamakso.Text = fcari.get_nama
                talamatkso.Text = fcari.get_alamat

            End Using

        End If
    End Sub

    Private Sub btfindkso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfindkso.Click

        Dim cari As String = "" 'tnamatok.Text.Trim

        Using fcari As New sr_kso(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkodekso.Text = fcari.get_kode
            tnamakso.Text = fcari.get_nama
            talamatkso.Text = fcari.get_alamat

            If tkodekso.Text.Trim.Length > 0 Then
                toks_akt.Properties.ReadOnly = False
            Else
                toks_akt.Properties.ReadOnly = True
            End If

        End Using


    End Sub

    Private Sub tkodekso_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkodekso.Validating

        If tkodekso.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            sql = String.Format("SELECT A.KODE,A.NAMA,A.ALAMAT FROM ADMLSP.MS_KSO A WHERE A.AKTIF=1 AND A.KODE='{0}'", tkodekso.Text.Trim)


        Try

            cn = classmy.open_conn_utama
            comd = New OracleCommand(Sql, cn)
            dred = comd.ExecuteReader

            If dred.Read Then

                    tkodekso.Text = dred(0).ToString
                    tnamakso.Text = dred(1).ToString
                    talamatkso.Text = dred(2).ToString

                    toks_akt.Properties.ReadOnly = False

                dred.Close()

            Else

                dred.Close()
                    MsgBox("KSO tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                e.Cancel = True
                    tkodekso.Focus()
                    tnamakso.Text = ""
                    talamatkso.Text = ""

                    toks_akt.Properties.ReadOnly = True
                    toks_akt.EditValue = 0
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

            tkodekso.Text = ""
            tnamakso.Text = ""
            talamatkso.Text = ""
            toks_akt.Properties.ReadOnly = True
            toks_akt.EditValue = 0
        End If


    End Sub


    Private Sub cbprinc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbprinc.KeyDown
        If e.KeyCode = 13 Then
            tkodekso.Focus()
        End If
    End Sub

    Private Sub cbnopol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbnopol.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        End If
    End Sub

    Private Sub tket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tket.KeyDown
        If e.KeyCode = 13 Then
            btadd_det.Focus()
        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            tr_pre.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tbukti.Text = "" Then

            MsgBox("No bukti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tbukti.Focus()
            Exit Sub
        End If

        If cbprinc.Text = "" Then

            MsgBox("Principal tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            cbprinc.Focus()
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
            MsgBox("Barang tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            btadd_det.Focus()
            Exit Sub
        End If

        If dv1.Count <= 0 Then

            MsgBox("Barang tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            btadd_det.Focus()
            Exit Sub
        End If

        If tkodekso.Text.Trim.Length > 0 Then

            If toks_akt.EditValue = 0 Then
                MsgBox("Ongkos angkut tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
                toks_akt.Focus()
                Exit Sub
            End If

        End If

        kalkulasi_oks_angkut()

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
                    dred.Close()

                Else

                    dred.Close()
                    MsgBox("Kode supir tidak ditemukan", MsgBoxStyle.Information, "Informasi")
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

        If cbprinc.EditValue = "" Then
            MsgBox("Isi dulu data principal", MsgBoxStyle.Information, "Informasi")
            cbprinc.Focus()
            Exit Sub
        End If

        If tkodetok.Text.Length = 0 Then

            MsgBox("Isi Req order", MsgBoxStyle.Information, "Informasi")
            tkodetok.Focus()
            Exit Sub

        End If

        Using ts_pre3 As New tr_pre3(False, dv1, 0, cbprinc.EditValue, kodekab) With {.StartPosition = FormStartPosition.CenterParent}
            ts_pre3.ShowDialog(Me)
        End Using

    End Sub

    Private Sub bted_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bted_det.Click

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        If cbprinc.EditValue = "" Then
            MsgBox("Isi dulu data principal", MsgBoxStyle.Information, "Informasi")
            cbprinc.Focus()
            Exit Sub
        End If

        If tkodetok.Text.Length = 0 Then

            MsgBox("Isi Req order", MsgBoxStyle.Information, "Informasi")
            tkodetok.Focus()
            Exit Sub

        End If

        Using ts_pre3 As New tr_pre3(True, dv1, Me.BindingContext(dv1).Position, cbprinc.EditValue, kodekab) With {.StartPosition = FormStartPosition.CenterParent}
            ts_pre3.ShowDialog(Me)
        End Using

    End Sub

    Private Sub btdel_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btdel_det.Click
        hapus_detail()
    End Sub

    Private Sub toks_akt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles toks_akt.KeyDown
        If e.KeyCode = 13 Then
            tkodetok.Focus()
        End If
    End Sub

    Private Sub toks_akt_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toks_akt.EditValueChanged
        kalkulasi_oks_angkut()
    End Sub
End Class