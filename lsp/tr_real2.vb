Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_real2

    Private statadd As Boolean
    Private dv As DataView
    Private dv1 As DataView
    Private posi As Integer = 0
    Private addjml As Integer = 0
    Private tp_harga As Integer = 0
    Private kd_princ As String = ""
    Private jenis_pot As String = ""
    Private old_ujlan As Double = 0
    Private kd_kass As String = String.Empty
    Private tsview As Boolean

    Sub New(ByVal adstat As Boolean, ByVal dv1 As DataView, ByVal pos As Integer, ByVal tsvv As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        statadd = adstat
        dv = dv1
        posi = pos
        addjml = 0

        tsview = tsvv

        isi_combo2()

    End Sub

    Private Sub kosongkan()

        tbukti.Text = "<< New >>"
        ttgl.EditValue = Date.Now
        ttgl_tempo.EditValue = Date.Now
        tjml.EditValue = 0
        tnospb.Text = ""
        tkodesal.Text = ""
        tnamasal.Text = ""
        tkodetok.Text = ""
        tnamatok.Text = ""
        talamattok.Text = ""
        tnorel.Text = ""
        tinforel.Text = ""
        tkode_spir.Text = ""
        tnama_spir.Text = ""
        tket.Text = ""

        toks_akt.EditValue = 0
        ttot_oks.EditValue = 0

        t_jlan.Properties.ReadOnly = False
        t_jlan.EditValue = 0

        ttot_akh.EditValue = 0
        tterbilang.EditValue = ""
        tdisc2.EditValue = 0
        tdisc1.EditValue = 0.0
        ttot_harga.EditValue = 0

        jenis_pot = ""

        kd_princ = ""

        dv1 = New DataView
        dv1 = Nothing

        grid1.DataSource = Nothing

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


        Dim sql As String = String.Format("SELECT A.KD_BARANG,B.NAMA,A.JML,A.SATUAN,A.HARGA,A.TOTAL,A.HARGA_BELI AS HARGABELI,A.TOTAL_BELI AS TOTALBELI,A.INSENTIF,A.JML_INSENTIF FROM ADMLSP.TR_REAL_ORDER2 A INNER JOIN ADMLSP.MS_BARANG B ON A.KD_BARANG=B.KODE" & _
                " WHERE A.NODO='{0}' ORDER BY A.KD_BARANG ASC", tbukti.Text.Trim)

        grid1.DataSource = Nothing
        Try

            dv1 = New DataView

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

    Private Sub isi_grid_berdasarkan_pre()

        Dim ds As DataSet
        Dim dvmanager As Data.DataViewManager
        Dim cn As OracleConnection = Nothing


        Dim sql As String = String.Format("SELECT A.KD_BARANG,B.NAMA,A.JML - A.JML_DATANG as JML ,A.SATUAN,0 as HARGA,0 AS TOTAL,A.HARGA AS HARGABELI,A.TOTAL AS TOTALBELI,B.INSENTIF,0 as JML_INSENTIF FROM ADMLSP.TR_PRE2 A INNER JOIN ADMLSP.MS_BARANG B ON A.KD_BARANG=B.KODE" & _
                " WHERE A.NO_BUKTI='{0}' ORDER BY A.KD_BARANG ASC", tnorel.Text.Trim)

        grid1.DataSource = Nothing
        Try

            dv1 = New DataView

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            grid1.DataSource = dv1

            ttot_harga.EditValue = gridview.Columns("TOTAL").SummaryItem.SummaryValue

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

    Private Sub kalkulasi_ulang_insentif()

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count = 0 Then
            Exit Sub
        End If

        
        Dim cn As OracleConnection = Nothing


        Try

            Dim sql As String = String.Empty

            Dim mycomd As OracleCommand = Nothing
            Dim dread As OracleDataReader

            Dim insentf As Double = 0
            Dim jml_insentif As Double = 0

            cn = classmy.open_conn_utama

            Dim i As Integer = 0
            For i = 0 To dv1.Count - 1

                If jenis_pot.Trim.ToUpper.Equals("LANGSUNG") Then
                    dv1(i)("INSENTIF") = 0
                Else


                    sql = String.Format("select a.INSENTIF from admlsp.ms_barang a where a.KODE='{0}'", dv1(i)("KD_BARANG").ToString)

                    mycomd = New OracleCommand(sql, cn)
                    dread = mycomd.ExecuteReader

                    If dread.Read Then

                        jml_insentif = 0

                        If IsNothing(dread(0).ToString) Then
                            insentf = 0
                        ElseIf Not IsNumeric(dread(0).ToString) Then
                            insentf = 0
                        Else
                            insentf = CDbl(dread(0).ToString)
                            jml_insentif = insentf * CDbl(dv1(i)("JML").ToString)
                        End If

                        dread.Close()

                        dv1(i)("INSENTIF") = insentf
                        dv1(i)("JML_INSENTIF") = jml_insentif

                    Else

                        dread.Close()
                        dv1(i)("INSENTIF") = 0
                        dv1(i)("JML_INSENTIF") = 0

                    End If

                End If


            Next


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

    Private Function cek_kelengkapan_detail() As Boolean

        Dim hasil As Boolean = True

        Dim i As Integer
        For i = 0 To dv1.Count - 1

            If Not IsNumeric(dv1(i)("JML").ToString) Or Not IsNumeric(dv1(i)("HARGA").ToString) Then
                hasil = False
            End If

            If dv1(i)("JML").ToString = 0 Or dv1(i)("HARGA").ToString = 0 Then
                hasil = False
            End If
        Next

        Return hasil

    End Function

    Private Sub isi_box()

        tbukti.Enabled = False
        tbukti.Text = dv(posi)("NODO").ToString
        ttgl.Text = convert_date_to_ind(dv(posi)("TANGGAL").ToString)
        ttgl_tempo.Text = convert_date_to_ind(dv(posi)("TGL_TEMPO").ToString)
        tjml.Text = dv(posi)("HARI_TEMPO").ToString
        tnospb.Text = dv(posi)("NO_SPB").ToString
        tkodesal.Text = dv(posi)("KD_SALES").ToString
        tnamasal.Text = dv(posi)("SALES").ToString
        tkodetok.Text = dv(posi)("KD_TOKO").ToString
        tnamatok.Text = dv(posi)("NAMA_TOKO").ToString
        talamattok.Text = dv(posi)("ALAMAT_TOKO").ToString


        tnorel.Text = dv(posi)("KD_PRE").ToString
        tinforel.Text = dv(posi)("INFO_PRE").ToString

        tkode_spir.Text = dv(posi)("KD_SUPIR").ToString
        tnama_spir.Text = dv(posi)("SUPIR").ToString
        cbnopol.EditValue = dv(posi)("NOPOL").ToString
        tket.Text = dv(posi)("KETERANGAN").ToString

        tp_harga = CType(dv(posi)("TIPE_HARGA").ToString, Integer)

        toks_akt.EditValue = dv(posi)("OKS_ANGKUT").ToString

        t_jlan.EditValue = dv(posi)("UANG_JLN").ToString
        old_ujlan = CDbl(t_jlan.EditValue)

        ttot_harga.EditValue = dv(posi)("TOT_HARGA").ToString
        tdisc1.EditValue = dv(posi)("DISC1").ToString
        tdisc2.EditValue = dv(posi)("DISC2").ToString
        ttot_akh.EditValue = dv(posi)("TOT_AKH").ToString

        ttot_oks.EditValue = dv(posi)("TOT_OKS_ANGKUT").ToString

        tterbilang.EditValue = dv(posi)("TERBILANG").ToString

        kd_princ = dv(posi)("KD_PRC").ToString

        jenis_pot = dv(posi)("JENIS_POT").ToString

    End Sub

    Private Sub edit(ByVal refreshd As Boolean)

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim tgl_tempo As String
        If ttgl_tempo.Text = "" Then
            tgl_tempo = ""
        Else
            tgl_tempo = convert_date_to_eng(ttgl_tempo.EditValue.ToString)
        End If

        Dim sql As String = String.Format("update admlsp.TR_REAL_ORDER set tanggal='{0}',no_spb='{1}',kd_sales='{2}',kd_toko='{3}',kd_pre='{4}',kd_supir='{5}',nopol='{6}',keterangan='{7}', tot_jml={8},tot_harga={9},user_edit='{10}',tgl_edit='{11}',oks_angkut={12},tot_oks_angkut={13},uang_jln={14},kd_prc='{15}',disc1={16},disc2={17},tot_akh={18},terbilang='{19}',tgl_tempo='{20}',hari_tempo={21},jenis_pot='{22}'" & _
                                          " where nodo='{23}'", tgl, tnospb.Text.Trim, tkodesal.Text.Trim, tkodetok.Text.Trim, tnorel.Text.Trim, tkode_spir.Text.Trim, cbnopol.EditValue, tket.Text.Trim, gridview.Columns("JML").SummaryItem.SummaryValue, gridview.Columns("TOTAL").SummaryItem.SummaryValue, userprog, convert_date_to_eng(Date.Now.ToString), toks_akt.EditValue, ttot_oks.EditValue, t_jlan.EditValue, kd_princ, tdisc1.EditValue.ToString.Replace(",", "."), tdisc2.EditValue, ttot_akh.EditValue, tterbilang.EditValue, tgl_tempo, tjml.EditValue, jenis_pot, tbukti.Text.Trim)

        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            'If refreshd = False Then

            '    Dim upp_jlan As Integer = 0
            '    upp_jlan = update_uang_jalan(cn)


            '    If upp_jlan = 1 Then
            '        MsgBox("Jumlah kas tidak cukup untuk pengeluaran uang jalan,proses edit dibatalkan", MsgBoxStyle.Exclamation, "Informasi")
            '        close_wait()
            '        Exit Sub
            '    ElseIf upp_jlan = 2 Then
            '        MsgBox("Tidak ada master kas yang di default untuk pengambilan uang jalan,proses edit dibatalkan", MsgBoxStyle.Exclamation, "Informasi")
            '        close_wait()
            '        Exit Sub
            '    End If

            'End If

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_REAL_ORDER", "UPDATE", "REALISASI ORDER")

            Dim nobuktilaen As String = cek_2_release(cn)

            manipulate2(cn)

            sqltrans.Commit()

            update_view()

            If refreshd = False Then

                If Not (nobuktilaen = String.Empty) Then
                    MsgBox("Uang jalan No Bukti " & nobuktilaen & " telah dirubah,karna menggunakan NO-DO yang sama dengan transaksi ini...", MsgBoxStyle.Information, "Informasi")
                End If

                MsgBox("Data telah dirubah..", MsgBoxStyle.Information, "Informasi")

                If Not (nobuktilaen = String.Empty) Then
                    tr_real.refresh_data()
                End If

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

        Dim tgl_tempo As String
        If ttgl_tempo.Text = "" Then
            tgl_tempo = ""
        Else
            tgl_tempo = convert_date_to_eng(ttgl_tempo.EditValue.ToString)
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

            'Dim upp_jlan As Integer = 0
            'upp_jlan = update_uang_jalan(cn)

            'If upp_jlan = 1 Then
            '    MsgBox("Jumlah kas tidak cukup untuk pengeluaran uang jalan,proses edit dibatalkan", MsgBoxStyle.Exclamation, "Informasi")
            '    close_wait()
            '    Exit Sub
            'ElseIf upp_jlan = 2 Then
            '    MsgBox("Tidak ada master kas yang di default untuk pengambilan uang jalan,proses edit dibatalkan", MsgBoxStyle.Exclamation, "Informasi")
            '    close_wait()
            '    Exit Sub
            'End If

            tbukti.EditValue = classmy.GET_KODE_RO(get_kode_stat, cn, ttgl.EditValue)
            sql_search = String.Format("select nodo from admlsp.TR_REAL_ORDER where nodo='{0}'", tbukti.Text.Trim)

            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                tbukti.EditValue = classmy.GET_KODE_RO(get_kode_stat, cn, ttgl.EditValue)
            Else
                dre.Close()
            End If

            ' Dim disc1 As String = convert_decimal_toEng(tdisc1.EditValue.ToString)

            sql = String.Format("insert into admlsp.TR_REAL_ORDER (nodo,tanggal,no_spb,kd_sales,kd_toko,kd_pre,kd_supir,nopol,keterangan,kd_stat,tot_jml,tot_harga,user_add,tgl_add,oks_angkut,tot_oks_angkut,uang_jln,kd_prc,disc1,disc2,tot_akh,terbilang,tgl_tempo,hari_tempo,jenis_pot) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},{11},'{12}','{13}',{14},{15},{16},'{17}',{18},{19},{20},'{21}','{22}',{23},'{24}')", tbukti.Text.Trim.ToUpper, tgl, tnospb.Text.Trim, tkodesal.Text.Trim, tkodetok.Text.Trim, tnorel.Text.Trim, tkode_spir.Text.Trim, cbnopol.EditValue, tket.Text.Trim, get_kode_stat, gridview.Columns("JML").SummaryItem.SummaryValue, gridview.Columns("TOTAL").SummaryItem.SummaryValue, userprog, convert_date_to_eng(Date.Now.ToString), toks_akt.EditValue, ttot_oks.EditValue, t_jlan.EditValue, kd_princ, tdisc1.EditValue.ToString.Replace(",", "."), tdisc2.EditValue, ttot_akh.EditValue, tterbilang.Text.Trim, tgl_tempo, tjml.EditValue, jenis_pot)
            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_REAL_ORDER", "INSERT", "REALISASI ORDER")

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

                    sql2 = String.Format("select nodo from admlsp.TR_REAL_ORDER2 where nodo='{0}' and kd_barang='{1}'", tbukti.Text.Trim, dv1(i)("KD_BARANG").ToString)
                    cmd2 = New OracleCommand(sql2, cn)
                    dread = cmd2.ExecuteReader

                    If dread.Read Then

                        dread.Close()

                        sql = String.Format("update admlsp.TR_REAL_ORDER2 set jml={0},satuan='{1}',harga={2},total={3},harga_beli={4},total_beli={5},insentif={6},jml_insentif={7} where nodo='{8}' and kd_barang='{9}'", dv1(i)("JML").ToString, dv1(i)("SATUAN").ToString, Replace(dv1(i)("HARGA").ToString, ",", "."), Replace(dv1(i)("TOTAL").ToString, ",", "."), Replace(dv1(i)("HARGABELI").ToString, ",", "."), Replace(dv1(i)("TOTALBELI").ToString, ",", "."), Replace(dv1(i)("INSENTIF").ToString, ",", "."), Replace(dv1(i)("JML_INSENTIF").ToString, ",", "."), tbukti.Text.Trim, dv1(i)("KD_BARANG").ToString)

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_REAL_ORDER2", "UPDATE", "REALISASI ORDER")

                    Else

                        dread.Close()

                        sql = String.Format("insert into admlsp.TR_REAL_ORDER2 (nodo,kd_barang,jml,satuan,harga,total,harga_beli,total_beli,insentif,jml_insentif) values('{0}','{1}',{2},'{3}',{4},{5},{6},{7},{8},{9})", tbukti.Text.Trim, dv1(i)("KD_BARANG").ToString, dv1(i)("JML").ToString, dv1(i)("SATUAN").ToString, Replace(dv1(i)("HARGA").ToString, ",", "."), Replace(dv1(i)("TOTAL").ToString, ",", "."), Replace(dv1(i)("HARGABELI").ToString, ",", "."), Replace(dv1(i)("TOTALBELI").ToString, ",", "."), Replace(dv1(i)("INSENTIF").ToString, ",", "."), Replace(dv1(i)("JML_INSENTIF").ToString, ",", "."))

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_REAL_ORDER2", "INSERT", "REALISASI ORDER")

                    End If

                Next

            End If

        End If


    End Sub

    Private Sub insert_view()

        Dim orow As DataRow = dv.Table.NewRow

        orow("NODO") = tbukti.Text

        If ttgl.Text = "" Then
            orow("TANGGAL") = DBNull.Value
        Else
            orow("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        If ttgl_tempo.Text = "" Then
            orow("TGL_TEMPO") = DBNull.Value
        Else
            orow("TGL_TEMPO") = convert_date_to_ind(ttgl_tempo.EditValue.ToString)
        End If

        orow("HARI_TEMPO") = tjml.EditValue

        orow("NO_SPB") = tnospb.Text.Trim
        orow("KD_SALES") = tkodesal.Text.Trim
        orow("SALES") = tnamasal.Text.Trim
        orow("KD_TOKO") = tkodetok.Text.Trim
        orow("NAMA_TOKO") = tnamatok.Text.Trim
        orow("ALAMAT_TOKO") = talamattok.Text.Trim
        orow("KD_PRE") = tnorel.Text.Trim
        orow("INFO_PRE") = tinforel.Text.Trim
        orow("KD_SUPIR") = tkode_spir.Text.Trim
        orow("SUPIR") = tnama_spir.Text.Trim
        orow("TOT_JML") = gridview.Columns("JML").SummaryItem.SummaryValue
        orow("TOT_HARGA") = gridview.Columns("TOTAL").SummaryItem.SummaryValue
        orow("TIPE_HARGA") = tp_harga
        orow("KETERANGAN") = tket.Text.Trim
        orow("KD_PRC") = kd_princ
        orow("TOT_AKH") = ttot_akh.EditValue
        orow("OKS_ANGKUT") = toks_akt.EditValue
        orow("TOT_OKS_ANGKUT") = ttot_oks.EditValue
        orow("UANG_JLN") = t_jlan.EditValue
        orow("DISC1") = tdisc1.EditValue
        orow("DISC2") = tdisc2.EditValue
        orow("TERBILANG") = tterbilang.Text.Trim
        orow("JENIS_POT") = jenis_pot
        orow("KD_PRE") = tnorel.Text.Trim

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        If ttgl.Text = "" Then
            dv(posi)("TANGGAL") = DBNull.Value
        Else
            dv(posi)("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        If ttgl_tempo.Text = "" Then
            dv(posi)("TGL_TEMPO") = DBNull.Value
        Else
            dv(posi)("TGL_TEMPO") = convert_date_to_ind(ttgl_tempo.EditValue.ToString)
        End If

        dv(posi)("HARI_TEMPO") = tjml.EditValue

        dv(posi)("NO_SPB") = tnospb.Text.Trim
        dv(posi)("KD_SALES") = tkodesal.Text.Trim
        dv(posi)("SALES") = tnamasal.Text.Trim
        dv(posi)("KD_TOKO") = tkodetok.Text.Trim
        dv(posi)("NAMA_TOKO") = tnamatok.Text.Trim
        dv(posi)("ALAMAT_TOKO") = talamattok.Text.Trim
        dv(posi)("KD_PRE") = tnorel.Text.Trim
        dv(posi)("INFO_PRE") = tinforel.Text.Trim
        dv(posi)("KD_SUPIR") = tkode_spir.Text.Trim
        dv(posi)("SUPIR") = tnama_spir.Text.Trim
        dv(posi)("TOT_JML") = gridview.Columns("JML").SummaryItem.SummaryValue
        dv(posi)("TOT_HARGA") = gridview.Columns("TOTAL").SummaryItem.SummaryValue
        dv(posi)("TIPE_HARGA") = tp_harga
        dv(posi)("KETERANGAN") = tket.Text.Trim
        dv(posi)("KD_PRC") = kd_princ
        dv(posi)("TOT_AKH") = ttot_akh.EditValue
        dv(posi)("OKS_ANGKUT") = toks_akt.EditValue
        dv(posi)("TOT_OKS_ANGKUT") = ttot_oks.EditValue
        dv(posi)("UANG_JLN") = t_jlan.EditValue
        dv(posi)("DISC1") = tdisc1.EditValue
        dv(posi)("DISC2") = tdisc2.EditValue
        dv(posi)("TERBILANG") = tterbilang.Text.Trim
        dv(posi)("JENIS_POT") = jenis_pot
        dv(posi)("KD_PRE") = tnorel.Text.Trim

    End Sub

    Private Sub hapus_detail()

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Dim cn As OracleConnection = Nothing
        Dim sql As String = String.Format("delete from admlsp.TR_REAL_ORDER2 where nodo='{0}' and kd_barang='{1}'", tbukti.Text.Trim, dv1(Me.BindingContext(dv1).Position)("KD_BARANG").ToString)
        Dim cmd As OracleCommand

        Try

            cn = classmy.open_conn_utama
            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_REAL_ORDER2", "DELETE", "REALISASI ORDER")

            dv1(Me.BindingContext(dv1).Position).Delete()

            sqltrans.Commit()

            ttot_harga.EditValue = gridview.Columns("TOTAL").SummaryItem.SummaryValue

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

    Private Function cek_2_release(ByVal cn As OracleConnection) As String

        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim hasil As String = String.Empty

        Dim sql As String = String.Format("select a.NODO from admlsp.tr_real_order a where a.KD_PRE='{0}' and not( a.NODO='{1}')", tnorel.Text.Trim, tbukti.Text.Trim)

        comd = New OracleCommand(sql, cn)
        dread = comd.ExecuteReader

        If dread.Read Then

            If Not IsNothing(dread(0).ToString) Then

                If dread(0).ToString.Trim.Length > 0 Then

                    Dim nobukti As String = dread(0).ToString

                    Dim sql2 As String = String.Format("update admlsp.tr_real_order b set b.UANG_JLN={0} where b.NODO='{1}'", t_jlan.EditValue, nobukti)

                    Dim comd2 As OracleCommand = Nothing
                    comd2 = New OracleCommand(sql2, cn)
                    comd2.ExecuteNonQuery()

                    ins_to_temp_user(cn, sql2, tbukti.Text.Trim, "TR_REAL_ORDER", "UPDATE", "REALISASI ORDER")

                    hasil = nobukti

                End If

            Else
                hasil = String.Empty
            End If

            dread.Close()

        Else
            dread.Read()

            hasil = String.Empty

        End If

        Return hasil

    End Function

    Private Function update_uang_jalan(ByVal cn As OracleConnection) As Integer

        Dim hasil As Integer = 0

        Dim sql As String = String.Format("select a.JML,a.KODE from admlsp.ms_kas a where a.STAT_UJLAN=1 and a.KD_STAT='{0}'", get_kode_stat)
        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        comd = New OracleCommand(sql, cn)
        dread = comd.ExecuteReader

        If dread.Read Then

            Dim jmla As Double
            Dim kodekas As String

            If Not IsNothing(dread(0).ToString) Then
                If IsNumeric(dread(0).ToString) Then
                    jmla = CDbl(dread(0).ToString)
                Else
                    jmla = 0
                End If
            Else
                jmla = 0
            End If

            If Not IsNothing(dread(1).ToString) Then
                If Not (dread(0).ToString.Trim.Length = 0) Then
                    kodekas = dread(1).ToString
                Else
                    kodekas = ""
                End If
            Else
                kodekas = ""
            End If

            kd_kass = kodekas

            jmla = jmla + old_ujlan

            If jmla >= CDbl(t_jlan.EditValue) Then
                hasil = 0
            Else
                hasil = 1
            End If

            dread.Close()

        Else
            kd_kass = ""
            hasil = 2
            dread.Close()
        End If
        Return hasil

    End Function

    Private Sub tnama_sales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkodesal.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            If tkodetok.Text = "" Then
                Exit Sub
            End If

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

        If tkodetok.Text = "" Then
            Exit Sub
        End If

        Dim cari As String = "" 'tnamasal.Text.Trim

        Using fcari As New sr_sales(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkodesal.Text = fcari.get_kode
            tnamasal.Text = fcari.get_nama

        End Using


    End Sub

    Private Sub tnama_sles_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkodesal.Validating

        If tkodetok.Text = "" Then
            tkodesal.Text = ""
            tnamasal.Text = ""
            jenis_pot = ""
            Exit Sub
        End If

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

                    jenis_pot = dred(2).ToString

                    dred.Close()

                Else

                    dred.Close()
                    MsgBox("Sales tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tkodesal.Focus()
                    tnamasal.Text = ""
                    jenis_pot = ""

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
            jenis_pot = ""

        End If


    End Sub


    Private Sub tnamatok_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkodetok.KeyDown
        If e.KeyCode = 13 Then
            tkodesal.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'tnamatok.Text.Trim
            tnamatok.Text = ""
            tkodetok.Text = ""

            Using fcari As New sr_toko(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkodetok.Text = fcari.get_kode
                tnamatok.Text = fcari.get_nama
                talamattok.Text = fcari.get_alamat_toko
                tp_harga = fcari.get_tipe_harga

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
            tp_harga = fcari.get_tipe_harga

            If tkodetok.Text <> "" Then
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
                sql = String.Format("select a.KD_TOKO,a.NAMA_TOKO,a.TIPE_HARGA,a.ALAMAT,b.KD_SALES,b.NAMA from admlsp.ms_toko a inner join admlsp.ms_sales b on a.KD_SALES=b.KD_SALES where a.AKTIF=1 and a.KD_TOKO='{0}'", tkodetok.Text.Trim)
            ElseIf get_stat_pusat() = 0 Then
                sql = String.Format("select a.KD_TOKO,a.NAMA_TOKO,a.TIPE_HARGA,a.ALAMAT,b.KD_SALES,b.NAMA from admlsp.ms_toko a inner join admlsp.ms_sales b on a.KD_SALES=b.KD_SALES where a.AKTIF=1 and a.KODE_STAT='{0}' and a.KD_TOKO='{1}'", get_kode_stat, tkodetok.Text.Trim)
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

                    tp_harga = dred(2).ToString

                    tkodesal.Text = dred(4).ToString

                    dred.Close()

                    tnama_sles_Validating(sender, e)

                    'tnamasal.Text = dred(5).ToString

                Else

                    dred.Close()
                    MsgBox("Nama toko tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tkodetok.Focus()
                    tnamatok.Text = ""
                    talamattok.Text = ""
                    tp_harga = 0
                    tkodesal.Text = ""
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

            tkodetok.Text = ""
            tnamatok.Text = ""
            talamattok.Text = ""
            tp_harga = 0
            tkodesal.Text = ""
            tnamasal.Text = ""

        End If


    End Sub


    Private Sub tnorel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnorel.KeyDown
        If e.KeyCode = 13 Then
            tkode_spir.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = tnorel.Text.Trim
            tnorel.Text = ""

            Using fcari As New sr_pre_release(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tnorel.Text = fcari.get_NOBUKTI
                tinforel.Text = fcari.get_INFO
                'tkode_spir.Text = fcari.get_KD_SUPIR
                'tnama_spir.Text = fcari.get_NAMA_SUPIR
                'cbnopol.EditValue = fcari.get_NOPOL
                'tkodetok.Text = fcari.get_KdToko
                'tnamatok.Text = fcari.get_NAMATOKO
                'talamattok.Text = fcari.get_ALAMATTOKO
                'tkodesal.Text = fcari.get_KDSALES
                'tnamasal.Text = fcari.get_NAMASALES


            End Using

        End If
    End Sub

    Private Sub btfindRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfindrel.Click

        Dim cari As String = tnorel.Text.Trim

        Using fcari As New sr_pre_release(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tnorel.Text = fcari.get_NOBUKTI
            tinforel.Text = fcari.get_INFO
            'tkode_spir.Text = fcari.get_KD_SUPIR
            'tnama_spir.Text = fcari.get_NAMA_SUPIR
            'cbnopol.EditValue = fcari.get_NOPOL
            'tkodetok.Text = fcari.get_KdToko
            'tnamatok.Text = fcari.get_NAMATOKO
            'talamattok.Text = fcari.get_ALAMATTOKO
            'tkodesal.Text = fcari.get_KDSALES
            'tnamasal.Text = fcari.get_NAMASALES

            If tnorel.Text <> "" Then
                tno_rel_Validating(sender, Nothing)
            End If

        End Using


    End Sub

    Private Sub tno_rel_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tnorel.Validating

        If tnorel.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            If get_stat_pusat() = 1 Then
                sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,B.NAMA,C.NAMA_TOKO,A.NOPOL,A.TOT_JML,A.KD_SUPIR,A.NAMA_SUPIR,A.KD_TOKO,C.ALAMAT AS ALAMAT_TOKO,C.KD_SALES,D.NAMA AS NAMA_SALES,A.KD_PRC,A.REAL_UANG_JLN FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL B ON A.KD_PRC=B.KD_PRC " & _
                        "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO INNER JOIN ADMLSP.MS_SALES D ON C.KD_SALES=D.KD_SALES WHERE A.TOT_JML > A.JML_DATANG AND A.NO_BUKTI='{0}' ORDER BY A.TANGGAL ASC", tnorel.Text.Trim)
            ElseIf get_stat_pusat() = 0 Then
                sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,B.NAMA,C.NAMA_TOKO,A.NOPOL,A.TOT_JML,A.KD_SUPIR,A.NAMA_SUPIR,A.KD_TOKO,C.ALAMAT AS ALAMAT_TOKO,C.KD_SALES,D.NAMA AS NAMA_SALES,A.KD_PRC,A.REAL_UANG_JLN FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL B ON A.KD_PRC=B.KD_PRC " & _
                        "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO INNER JOIN ADMLSP.MS_SALES D ON C.KD_SALES=D.KD_SALES WHERE A.TOT_JML > A.JML_DATANG AND A.KD_STAT='{0}' AND A.NO_BUKTI='{1}' ORDER BY A.TANGGAL ASC", get_kode_stat, tnorel.Text.Trim)
            Else
                Exit Sub
            End If


            Try

                cn = classmy.open_conn_utama

                If cek_kesesuaian_realisasi() = False Then

                    MsgBox("Realisasi tidak sesuai dengan periode tanggal sebelumnya", MsgBoxStyle.Exclamation, "Warning")
                    If Not IsNothing(e) Then
                        e.Cancel = True

                    End If
                    tnorel.Focus()

                End If

                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    Dim info As String = String.Format("{0} {1}", CType(dred("TANGGAL").ToString, Date) & Environment.NewLine, dred("NAMA").ToString)

                    tnorel.Text = dred("NO_BUKTI").ToString
                    tinforel.Text = info

                    Dim uangjln_real As Double

                    If IsNothing(dred("REAL_UANG_JLN").ToString) Then
                        uangjln_real = 0
                    Else
                        uangjln_real = CDbl(dred("REAL_UANG_JLN").ToString)
                    End If

                    If uangjln_real > 0 Then
                        t_jlan.Properties.ReadOnly = True
                        t_jlan.EditValue = uangjln_real
                    Else
                        t_jlan.Properties.ReadOnly = False
                        t_jlan.EditValue = 0
                    End If

                    tkode_spir.Text = "" 'dred("KD_SUPIR").ToString
                    tnama_spir.Text = "" 'dred("NAMA_SUPIR").ToString
                    ' cbnopol.EditValue = ""

                    tkodetok.Text = "" 'dred("KD_TOKO").ToString
                    tnamatok.Text = "" 'dred("NAMA_TOKO").ToString
                    talamattok.Text = "" 'dred("ALAMAT_TOKO").ToString

                    tkodesal.Text = "" 'dred("KD_SALES").ToString
                    tnamasal.Text = "" 'dred("NAMA_SALES").ToString

                    kd_princ = dred("KD_PRC").ToString

                    dred.Close()

                    isi_grid_berdasarkan_pre()

                    btadd_det.Enabled = False
                    btdel_det.Enabled = False

                Else

                    dred.Close()
                    MsgBox("No realisasi order tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tnorel.Focus()
                    tinforel.Text = ""

                    t_jlan.Properties.ReadOnly = False
                    t_jlan.EditValue = 0

                    tkode_spir.Text = ""
                    tnama_spir.Text = ""

                    tkodetok.Text = ""
                    tnamatok.Text = ""
                    talamattok.Text = ""

                    tkodesal.Text = ""
                    tnamasal.Text = ""

                    ' cbnopol.Text = ""

                    kd_princ = ""

                    grid1.DataSource = Nothing
                    grid1.DataSource = dv1

                    btadd_det.Enabled = True
                    btdel_det.Enabled = True

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

            tnorel.Text = ""
            tinforel.Text = ""

            tkode_spir.Text = ""
            tnama_spir.Text = ""

            tkodetok.Text = ""
            tnamatok.Text = ""
            talamattok.Text = ""

            tkodesal.Text = ""
            tnamasal.Text = ""

            t_jlan.Properties.ReadOnly = False
            t_jlan.EditValue = 0

            kd_princ = ""

            grid1.DataSource = Nothing
            grid1.DataSource = dv1

            btadd_det.Enabled = True
            btdel_det.Enabled = True

        End If


    End Sub

    Private Function cek_kesesuaian_realisasi() As Boolean

        Dim hasil As Boolean = True

        Dim cn As OracleConnection = Nothing
        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader = Nothing

        Dim bln As String = CDate(ttgl.EditValue).ToString("MM")
        Dim thn As String = CDate(ttgl.EditValue).ToString("yyyy")

        Dim sql As String = String.Format("select to_char(tanggal,'MM') as bln,to_char(tanggal,'YYYY') as thn from admlsp.tr_real_order where kd_pre='{0}'", tnorel.Text.Trim)

        Try

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            comd = New OracleCommand(sql, cn)
            dread = comd.ExecuteReader

            If dread.Read Then

                If IsNothing(dread(0).ToString) Or IsNothing(dread(1).ToString) Then
                    hasil = True
                Else

                    If Not (dread(0).ToString = bln) Or Not (dread(1).ToString = thn) Then
                        hasil = False
                    Else
                        hasil = True
                    End If

                End If

            Else
                hasil = True
            End If

        Catch ex As Exception
            hasil = True
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

        Return hasil

    End Function

    Private Sub tkodesupir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkode_spir.KeyDown
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

    Private Sub tnobukti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbukti.KeyDown
        If e.KeyCode = 13 Then
            ttgl.Focus()
        End If
    End Sub

    Private Sub ttgl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        If e.KeyCode = 13 Then
            ttgl_tempo.Focus()
        End If
    End Sub

    Private Sub ttgl_tempo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl_tempo.KeyDown
        If e.KeyCode = 13 Then
            tjml.Focus()
        End If
    End Sub

    Private Sub tJML_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tjml.KeyDown
        If e.KeyCode = 13 Then
            tnospb.Focus()
        End If
    End Sub

    Private Sub tnoSPB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnospb.KeyDown
        If e.KeyCode = 13 Then
            tnorel.Focus()
        End If
    End Sub

    Private Sub tNOPOL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbnopol.KeyDown
        If e.KeyCode = 13 Then
            tkodetok.Focus()
        End If
    End Sub

    Private Sub tket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tket.KeyDown
        If e.KeyCode = 13 Then

            If btadd_det.Enabled = True Then
                btadd_det.Focus()
            Else
                bted_det.Focus()
            End If


        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            tr_real.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tbukti.Text = "" Then

            MsgBox("No DO tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tbukti.Focus()
            Exit Sub
        End If

        If tnorel.Text = "" Then

            MsgBox("No Realisasi tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tnorel.Focus()
            Exit Sub
        End If

        If tnospb.Text = "" Then

            MsgBox("NO-SPB tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tnospb.Focus()
            Exit Sub
        End If

        If tkodesal.Text = "" Then

            MsgBox("Sales tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tnamasal.Focus()
            Exit Sub
        End If

        If tkodetok.Text = "" Then

            MsgBox("Toko tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tnamatok.Focus()
            Exit Sub
        End If

        If tkode_spir.Text = "" Then

            MsgBox("Supir tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tnama_spir.Focus()
            Exit Sub
        End If

        If cbnopol.Text = "" Then

            MsgBox("No Polisi tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            cbnopol.Focus()
            Exit Sub
        End If



        'If toks_akt.EditValue = 0 Then

        '    MsgBox("Ongkos angkut tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

        '    toks_akt.Focus()
        '    Exit Sub
        'End If


        'If t_jlan.EditValue = 0 Then

        '    MsgBox("Uang jalan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

        '    t_jlan.Focus()
        '    Exit Sub
        'End If

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

        If cek_kelengkapan_detail() = False Then
            MsgBox("Semua data barang harus lengkap", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        End If

        kalkulasi_ulang_insentif()

        If toks_akt.EditValue = 0 Or t_jlan.EditValue = 0 Then
            If MsgBox("Ongkos angkut / Uang jalan kosong,apakah anda yakin akan melanjutkan ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        If MsgBox("Yakin data yang dimasukkan sudah benar ... ???", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi") = MsgBoxResult.No Then
            Exit Sub
        End If

        If statadd.Equals(True) Then
            insert()
        Else
            edit(False)
        End If

    End Sub

    Private Sub btadd_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btadd_det.Click

        If tkodetok.Text = "" Then

            MsgBox("Toko harus diisi dahulu", MsgBoxStyle.Information, "Informasi")
            tnamatok.Focus()
            Exit Sub
        End If

        Using ts_pre3 As New tr_real3(False, dv1, 0, tp_harga, jenis_pot, tnamasal.Text.Trim) With {.StartPosition = FormStartPosition.CenterParent}
            ts_pre3.ShowDialog(Me)

            ttot_harga.EditValue = gridview.Columns("TOTAL").SummaryItem.SummaryValue

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

            MsgBox("Toko harus diisi dahulu", MsgBoxStyle.Information, "Informasi")
            tnamatok.Focus()
            Exit Sub

        End If

        Using ts_pre3 As New tr_real3(True, dv1, Me.BindingContext(dv1).Position, tp_harga, jenis_pot, tnamasal.Text.Trim) With {.StartPosition = FormStartPosition.CenterParent}
            ts_pre3.ShowDialog(Me)

            ttot_harga.EditValue = gridview.Columns("TOTAL").SummaryItem.SummaryValue

        End Using

    End Sub

    Private Sub btdel_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btdel_det.Click
        hapus_detail()
    End Sub

    Private Sub tr_pre2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            ttgl.Focus()
        Else
            ttgl.Focus()
        End If
    End Sub

    Private Sub tr_pre2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        btadd_det.Enabled = True
        bted_det.Enabled = True
        btdel_det.Enabled = True
        btsimpan.Enabled = True

        ttgl.Enabled = True
        ttgl_tempo.Enabled = True
        tnospb.Enabled = True
        tnorel.Enabled = True
        btfindrel.Enabled = True
        tkode_spir.Enabled = True
        btfindspir.Enabled = True
        cbnopol.Enabled = True
        tkodetok.Enabled = True
        btfindtok.Enabled = True
        tkodesal.Enabled = True
        btfindsal.Enabled = True
        toks_akt.Enabled = True
        t_jlan.Enabled = True
        tdisc1.Enabled = True
        tdisc2.Enabled = True

        If statadd.Equals(True) Then

            ' tbukti.Enabled = True

            kosongkan()

            ttgl.Properties.ReadOnly = False

            ' tbukti.Text = " << New >> "

            old_ujlan = 0

            btadd_det.Enabled = True
            btdel_det.Enabled = True

        Else

            'tbukti.Enabled = False

            ttgl.Properties.ReadOnly = True

            isi_box()

            If tnorel.Text <> "" Then
                btadd_det.Enabled = False
                btdel_det.Enabled = False
            Else
                btadd_det.Enabled = True
                btdel_det.Enabled = True
            End If

        End If

        If tsview = True Then

            isi_box()

            btadd_det.Enabled = False
            bted_det.Enabled = False
            btdel_det.Enabled = False
            btsimpan.Enabled = False


            ttgl.Enabled = False
            ttgl_tempo.Enabled = False
            tnospb.Enabled = False
            tnorel.Enabled = False
            btfindrel.Enabled = False
            tkode_spir.Enabled = False
            btfindspir.Enabled = False
            cbnopol.Enabled = False
            tkodetok.Enabled = False
            btfindtok.Enabled = False
            tkodesal.Enabled = False
            btfindsal.Enabled = False
            toks_akt.Enabled = False
            t_jlan.Enabled = False
            tdisc1.Enabled = False
            tdisc2.Enabled = False

        End If

        isi_grid()

    End Sub

    Private Sub toks_akt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles toks_akt.KeyDown
        If e.KeyCode = 13 Then
            t_jlan.Focus()
        End If
    End Sub

    Private Sub tjalan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles t_jlan.KeyDown
        If e.KeyCode = 13 Then
            tdisc1.Focus()
        End If
    End Sub

    Private Sub toks_akt_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toks_akt.EditValueChanged
        Dim tot_jml As Integer = 0
        tot_jml = gridview.Columns("JML").SummaryItem.SummaryValue

        ttot_oks.EditValue = toks_akt.EditValue * tot_jml
    End Sub

    Private Sub ttot_harga_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ttot_harga.EditValueChanged
        toks_akt_EditValueChanged(sender, Nothing)
        tdisc2_EditValueChanged(sender, Nothing)
    End Sub

    Private Sub tdisc1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdisc1.EditValueChanged

        If Not IsNumeric(tdisc1.EditValue) Then
            Exit Sub
        End If

        If tdisc1.EditValue > 0 Then
            tdisc2.Properties.ReadOnly = True
        Else
            tdisc2.Properties.ReadOnly = False
        End If

        Dim discPersen As Double = 0
        discPersen = tdisc1.EditValue.ToString.Replace(".", ",") / 100

        tdisc2.EditValue = discPersen * ttot_harga.EditValue

    End Sub

    Private Sub tdisc2_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdisc2.EditValueChanged
        ttot_akh.EditValue = ttot_harga.EditValue - tdisc2.EditValue
    End Sub

    Private Sub ttot_akh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ttot_akh.EditValueChanged
        If ttot_akh.EditValue <= 0 Or ttot_akh.EditValue <= 0.0 Then
            tterbilang.EditValue = ""
        Else
            tterbilang.EditValue = terbilang.ANGKA_TERBILANG(ttot_akh.EditValue) & " Rupiah"
        End If
    End Sub

    Private Sub tdisc1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdisc1.KeyDown
        If e.KeyCode = 13 Then

            If tdisc2.Properties.ReadOnly = True Then
                btsimpan.Focus()
            Else
                tdisc2.Focus()
            End If

        End If
    End Sub

    Private Sub tdisc2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdisc2.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub ttgl_tempo_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ttgl_tempo.EditValueChanged

        If Not IsDate(ttgl.EditValue) Then
            Exit Sub
        End If

        If Not IsDate(ttgl_tempo.EditValue) Then
            Exit Sub
        End If

        If IsDate(ttgl.EditValue) > IsDate(ttgl_tempo.EditValue) Then
            tjml.EditValue = 0
            Exit Sub
        End If

        Dim jmlhari As Integer
        jmlhari = DateDiff(DateInterval.Day, ttgl.EditValue, ttgl_tempo.EditValue)
        tjml.EditValue = jmlhari

    End Sub

    Private Sub ttgl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ttgl.Validating
        If tnorel.Text.Trim.Length > 0 Then

            If cek_kesesuaian_realisasi() = False Then

                MsgBox("Realisasi tidak sesuai dengan periode tanggal sebelumnya", MsgBoxStyle.Exclamation, "Warning")
                e.Cancel = True
                ttgl.Focus()

            End If

        End If
    End Sub
End Class