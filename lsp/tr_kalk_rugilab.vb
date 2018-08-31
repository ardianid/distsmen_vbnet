Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_kalk_rugilab

    Dim tot_zak As Double

    Private Function kalk_selisih_harga(ByVal cn As OracleConnection, ByVal thn As String, ByVal bln As String, ByVal kd_stat As String) As Double

        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("SELECT tr_real_order2.harga as harga,tr_real_order2.jml AS jml_zak " & _
                "FROM admlsp.tr_real_order, admlsp.tr_real_order2 " & _
                "WHERE tr_real_order.nodo = tr_real_order2.nodo " & _
                "and tr_real_order.kd_stat='{0}' " & _
                "and extract(month from tr_real_order.TANGGAL)='{1}' " & _
                "and extract(year from tr_real_order.TANGGAL)='{2}'", kd_stat, bln, thn)


        '"and NOT (tr_real_order.TGL_LUNAS IS NULL ) " & _

        comd = New OracleCommand(sql, cn)
        dread = comd.ExecuteReader

        Dim hasil As Double = 0
        Dim hasilakhir As Double = 0

        If dread.HasRows Then

            Do While dread.Read

                If Not IsNothing(dread(0).ToString) Then
                    If IsNumeric(dread(0).ToString) Then
                        hasil = CDbl(dread(0).ToString)
                    Else
                        hasil = 0
                    End If
                End If

                If Not IsNothing(dread(1).ToString) Then
                    If IsNumeric(dread(1).ToString) Then
                        tot_zak = CDbl(dread(1).ToString)
                    Else
                        tot_zak = 0
                    End If
                End If

                hasilakhir = hasilakhir + (hasil * tot_zak)

            Loop

        Else
            hasil = 0
            tot_zak = 0
            hasilakhir = 0
        End If

        Return hasilakhir

    End Function

    Private Shared Function kalk_invent_sal(ByVal cn As OracleConnection, ByVal thn As String, ByVal bln As String, ByVal kd_stat As String) As Double

        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("select sum(a.TOT_JML) as jml from admlsp.tr_inv a " & _
                "where extract(month from a.TANGGAL)='{0}' " & _
                "and extract(year from a.TANGGAL)='{1}' " & _
                "and a.KD_STAT='{2}'", bln, thn, kd_stat)

        comd = New OracleCommand(sql, cn)
        dread = comd.ExecuteReader

        Dim hasil As Double = 0
        If dread.Read Then

            If Not IsNothing(dread(0).ToString) Then
                If IsNumeric(dread(0).ToString) Then
                    hasil = CDbl(dread(0).ToString)
                Else
                    hasil = 0
                End If
            End If

        Else
            hasil = 0
        End If

        Return hasil

    End Function

    Private Shared Function kalk_angkutan_lain(ByVal cn As OracleConnection, ByVal thn As String, ByVal bln As String, ByVal kd_stat As String) As Double

        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("select sum(a.TOT_OKS_ANGKUT) as jml from admlsp.tr_angkutan a " & _
                "where extract(month from a.TANGGAL)='{0}' " & _
                "and extract(year from a.TANGGAL)='{1}' " & _
                "and a.KD_STAT='{2}'", bln, thn, kd_stat)

        comd = New OracleCommand(sql, cn)
        dread = comd.ExecuteReader

        Dim hasil As Double = 0
        If dread.Read Then

            If Not IsNothing(dread(0).ToString) Then
                If IsNumeric(dread(0).ToString) Then
                    hasil = CDbl(dread(0).ToString)
                Else
                    hasil = 0
                End If
            End If

        Else
            hasil = 0
        End If

        Return hasil

    End Function

    Private Shared Function kalk_kas_in(ByVal cn As OracleConnection, ByVal thn As String, ByVal bln As String, ByVal kd_stat As String) As Double

        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("select a.OKS_ANGKUT * a.TOT_JML as oks_angkut,a.NO_BUKTI from admlsp.v_kso_detail a " & _
                                    "where extract(month from a.TANGGAL)='{0}' " & _
                        "and extract(year from a.TANGGAL)='{1}' " & _
                        "and a.KD_STAT='{2}'", bln, thn, kd_stat)


        'String.Format("select sum(a.TOTAL) as jml from admlsp.tr_kas_in a " & _
        '                "where extract(month from a.TANGGAL)='{0}' " & _
        '                "and extract(year from a.TANGGAL)='{1}' " & _
        '                "and a.KD_STAT='{2}'", bln, thn, kd_stat)

        comd = New OracleCommand(sql, cn)
        dread = comd.ExecuteReader

        Dim hasil As Double = 0
        Dim hasilakhir As Double = 0
        Dim fee As Double = 0
        If dread.HasRows Then

            Do While dread.Read

                If Not IsNothing(dread(0).ToString) Then
                    If IsNumeric(dread(0).ToString) Then
                        hasil = CDbl(dread(0).ToString)

                        fee = 0
                        fee = hasil * (15 / 100)
                        hasil = hasil - fee

                        hasilakhir = hasilakhir + hasil

                    Else
                        hasil = 0
                    End If
                End If

            Loop

        Else
            hasilakhir = 0
            hasil = 0
        End If

        Return hasilakhir

    End Function

    Private Shared Function kalk_bayar_kasbon(ByVal cn As OracleConnection, ByVal thn As String, ByVal bln As String, ByVal kd_stat As String) As Double

        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("select sum(a.JML) as jml from admlsp.TR_KASBON a " & _
                "where extract(month from a.TANGGAL)='{0}' " & _
                "and extract(year from a.TANGGAL)='{1}' " & _
                "and a.KD_STAT='{2}' and a.JENIS='BAYAR'", bln, thn, kd_stat)

        comd = New OracleCommand(sql, cn)
        dread = comd.ExecuteReader

        Dim hasil As Double = 0
        If dread.Read Then

            If Not IsNothing(dread(0).ToString) Then
                If IsNumeric(dread(0).ToString) Then
                    hasil = CDbl(dread(0).ToString)
                Else
                    hasil = 0
                End If
            End If

        Else
            hasil = 0
        End If

        Return hasil

    End Function


    Private Shared Function kalk_dep_princ(ByVal cn As OracleConnection, ByVal thn As String, ByVal bln As String, ByVal kd_stat As String) As Double

        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        'Dim sql As String = String.Format("select sum(a.JML_DEPOSIT) as jml from admlsp.tr_dep_principal a " & _
        '        "where extract(month from a.TANGGAL)='{0}' " & _
        '        "and extract(year from a.TANGGAL)='{1}'", bln, thn)

        Dim sql As String = String.Format("SELECT tr_real_order2.harga_beli as harga,tr_real_order2.jml AS jml_zak " & _
            "FROM admlsp.tr_real_order, admlsp.tr_real_order2 " & _
            "WHERE tr_real_order.nodo = tr_real_order2.nodo " & _
            "and tr_real_order.kd_stat='{0}' " & _
            "and extract(month from tr_real_order.TANGGAL)='{1}' " & _
            "and extract(year from tr_real_order.TANGGAL)='{2}'", kd_stat, bln, thn)

        comd = New OracleCommand(sql, cn)
        dread = comd.ExecuteReader

        Dim hasil As Double = 0
        Dim hasilakhir As Double = 0
        Dim totzak As Double = 0

        If dread.HasRows Then

            Do While dread.Read

                If Not IsNothing(dread(0).ToString) Then
                    If IsNumeric(dread(0).ToString) Then
                        hasil = CDbl(dread(0).ToString)
                    Else
                        hasil = 0
                    End If
                End If

                If Not IsNothing(dread(1).ToString) Then
                    If IsNumeric(dread(1).ToString) Then
                        totzak = CDbl(dread(1).ToString)
                    Else
                        totzak = 0
                    End If
                End If

                hasilakhir = hasilakhir + (hasil * totzak)

            Loop

        Else
            hasil = 0
            totzak = 0
            hasilakhir = 0
        End If

        Return hasilakhir

    End Function

    Private Shared Function kalk_kas_out(ByVal cn As OracleConnection, ByVal thn As String, ByVal bln As String, ByVal kd_stat As String) As Double

        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("select sum(a.TOTAL) as jml from admlsp.tr_kas_out a " & _
                "where extract(month from a.TANGGAL)='{0}' " & _
                "and extract(year from a.TANGGAL)='{1}' " & _
                "and a.KD_STAT='{2}'", bln, thn, kd_stat)

        comd = New OracleCommand(sql, cn)
        dread = comd.ExecuteReader

        Dim hasil As Double = 0
        If dread.Read Then

            If Not IsNothing(dread(0).ToString) Then
                If IsNumeric(dread(0).ToString) Then
                    hasil = CDbl(dread(0).ToString)
                Else
                    hasil = 0
                End If
            End If

        Else
            hasil = 0
        End If

        Return hasil

    End Function

    Private Shared Function kalk_kasbon(ByVal cn As OracleConnection, ByVal thn As String, ByVal bln As String, ByVal kd_stat As String) As Double

        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("select sum(a.JML) as jml from admlsp.TR_KASBON a " & _
                "where extract(month from a.TANGGAL)='{0}' " & _
                "and extract(year from a.TANGGAL)='{1}' " & _
                "and a.KD_STAT='{2}' and a.JENIS='PINJAM'", bln, thn, kd_stat)

        comd = New OracleCommand(sql, cn)
        dread = comd.ExecuteReader

        Dim hasil As Double = 0
        If dread.Read Then

            If Not IsNothing(dread(0).ToString) Then
                If IsNumeric(dread(0).ToString) Then
                    hasil = CDbl(dread(0).ToString)
                Else
                    hasil = 0
                End If
            End If

        Else
            hasil = 0
        End If

        Return hasil

    End Function

    Private Shared Function kalk_uang_jln(ByVal cn As OracleConnection, ByVal thn As String, ByVal bln As String, ByVal kd_stat As String) As Double

        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("select sum(a.JML) as jml from admlsp.TR_UANG_JLN a " & _
                "where extract(month from a.TGL)='{0}' " & _
                "and extract(year from a.TGL)='{1}' " & _
                "and a.KD_STAT='{2}'", bln, thn, kd_stat)

        comd = New OracleCommand(sql, cn)
        dread = comd.ExecuteReader

        Dim hasil As Double = 0
        If dread.Read Then

            If Not IsNothing(dread(0).ToString) Then
                If IsNumeric(dread(0).ToString) Then
                    hasil = CDbl(dread(0).ToString)
                Else
                    hasil = 0
                End If
            End If

        Else
            hasil = 0
        End If

        Return hasil

    End Function

    Private Shared Function kalk_uang_jln_ln(ByVal cn As OracleConnection, ByVal thn As String, ByVal bln As String, ByVal kd_stat As String) As Double

        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("select sum(a.JML) as jml from admlsp.TR_UANG_JLN_LN a " & _
                "where extract(month from a.TGL)='{0}' " & _
                "and extract(year from a.TGL)='{1}' " & _
                "and a.KD_STAT='{2}'", bln, thn, kd_stat)

        comd = New OracleCommand(sql, cn)
        dread = comd.ExecuteReader

        Dim hasil As Double = 0
        If dread.Read Then

            If Not IsNothing(dread(0).ToString) Then
                If IsNumeric(dread(0).ToString) Then
                    hasil = CDbl(dread(0).ToString)
                Else
                    hasil = 0
                End If
            End If

        Else
            hasil = 0
        End If

        Return hasil

    End Function

    Private Sub isi_combo()

        Dim sql As String = String.Empty

        If get_stat_pusat() = 1 Then
            sql = "select kode,nama,status from admlsp.MS_STAT order by kode"
        Else
            sql = String.Format("select kode,nama,status from admlsp.MS_STAT where a.kode='{0}' order by kode", get_kode_stat)
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

            cbstatus.Properties.DataSource = dv

            cbstatus.ItemIndex = 0

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

    Private Sub kalkulasi()

        Dim cn As OracleConnection = Nothing

        Dim in_selisih_harga As Double = 0
        Dim in_invent_sal As Double = 0
        Dim in_angkt_lain As Double = 0
        Dim in_kasin As Double = 0
        Dim in_byar_kasbon As Double = 0

        Dim out_dep_princ As Double = 0
        Dim out_kasout As Double = 0
        Dim out_kasbon As Double = 0
        Dim out_ujalan As Double = 0
        Dim out_ujalan_ln As Double = 0

        Dim bulan As String = String.Empty

        Dim cmd_search As OracleCommand = Nothing
        Dim dread_search As OracleDataReader

        Dim cmd_insert As OracleCommand = Nothing
        Dim cmd_update As OracleCommand = Nothing

        If cbbulan.SelectedIndex <= 8 Then
            bulan = String.Format("0{0}", cbbulan.SelectedIndex + 1)
        Else
            bulan = cbbulan.SelectedIndex + 1
        End If

        Try

            open_wait()

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            in_selisih_harga = kalk_selisih_harga(cn, ttahun.EditValue, bulan, cbstatus.EditValue)
            in_invent_sal = kalk_invent_sal(cn, ttahun.EditValue, bulan, cbstatus.EditValue)
            in_angkt_lain = kalk_angkutan_lain(cn, ttahun.EditValue, bulan, cbstatus.EditValue)
            in_kasin = kalk_kas_in(cn, ttahun.EditValue, bulan, cbstatus.EditValue)
            in_byar_kasbon = kalk_bayar_kasbon(cn, ttahun.EditValue, bulan, cbstatus.EditValue)

            If get_stat_pusat() = 1 Then
                out_dep_princ = kalk_dep_princ(cn, ttahun.EditValue, bulan, cbstatus.EditValue)
            Else
                out_dep_princ = 0
            End If

            out_kasout = kalk_kas_out(cn, ttahun.EditValue, bulan, cbstatus.EditValue)
            out_kasbon = kalk_kasbon(cn, ttahun.EditValue, bulan, cbstatus.EditValue)
            out_ujalan = kalk_uang_jln(cn, ttahun.EditValue, bulan, cbstatus.EditValue)
            out_ujalan_ln = kalk_uang_jln_ln(cn, ttahun.EditValue, bulan, cbstatus.EditValue)

            Dim sql_search As String = String.Format("select a.NO_ID from admlsp.tm_rugilab a where a.THN='{0}' and a.BLN='{1}' and a.KD_STAT='{2}'", ttahun.EditValue, bulan, cbstatus.EditValue)
            Dim sql_insert As String = String.Format("insert into admlsp.tm_rugilab a (a.THN,a.BLN,a.KD_STAT,a.SEL_JUAL,a.INVENT_SAL,a.ANGK_LAIN,a.KAS_IN,a.PEMB_KASBON,a.DEP_PRINC,a.KS_OUT,a.KASBON_SPR,a.UANG_JLN,a.UANG_JLN_LAIN,a.TOT_ZAK) " & _
                                            "values('{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})", ttahun.EditValue, bulan, cbstatus.EditValue, _
                                                        Replace(in_selisih_harga, ",", "."), Replace(in_invent_sal, ",", "."), Replace(in_angkt_lain, ",", "."), Replace(in_kasin, ",", "."), Replace(in_byar_kasbon, ",", "."), Replace(out_dep_princ, ",", "."), Replace(out_kasout, ",", "."), Replace(out_kasbon, ",", "."), Replace(out_ujalan, ",", "."), Replace(out_ujalan_ln, ",", "."), Replace(tot_zak, ",", "."))
            Dim sql_update As String = String.Format("update admlsp.tm_rugilab a set a.SEL_JUAL={0},a.INVENT_SAL={1},a.ANGK_LAIN={2},a.KAS_IN={3},a.PEMB_KASBON={4},a.DEP_PRINC={5},a.KS_OUT={6},a.KASBON_SPR={7},a.UANG_JLN={8},a.UANG_JLN_LAIN={9},a.TOT_ZAK={10} " & _
                                            "where a.THN='{11}' and a.BLN='{12}' and a.KD_STAT='{13}'", _
                                                        Replace(in_selisih_harga, ",", "."), Replace(in_invent_sal, ",", "."), Replace(in_angkt_lain, ",", "."), Replace(in_kasin, ",", "."), Replace(in_byar_kasbon, ",", "."), Replace(out_dep_princ, ",", "."), Replace(out_kasout, ",", "."), Replace(out_kasbon, ",", "."), Replace(out_ujalan, ",", "."), Replace(out_ujalan_ln, ",", "."), Replace(tot_zak, ",", "."), ttahun.EditValue, bulan, cbstatus.EditValue)

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd_search = New OracleCommand(sql_search, cn)
            dread_search = cmd_search.ExecuteReader

            If dread_search.Read Then

                cmd_update = New OracleCommand(sql_update, cn)
                cmd_update.ExecuteNonQuery()

                dread_search.Close()

            Else

                cmd_insert = New OracleCommand(sql_insert, cn)
                cmd_insert.ExecuteNonQuery()

                dread_search.Close()

            End If

            sqltrans.Commit()
            close_wait()
            MsgBox("Kalkulasi selesai......", MsgBoxStyle.Information, "Informasi")

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

    Private Sub tr_kalk_rugilab_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        cbbulan.Focus()
    End Sub

    Private Sub tr_kalk_rugilab_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ttahun.Text = Year(Now)

        cbbulan.SelectedIndex = 0
        isi_combo()

    End Sub

    Private Sub cbbulan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbulan.KeyDown
        If e.KeyCode = 13 Then
            cbstatus.Focus()
        End If
    End Sub

    Private Sub cbstatus_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbstatus.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If ttahun.Text.Trim.Length <= 0 Then
            MsgBox("Tahun tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        End If

        If cbbulan.Text.Trim.Length <= 0 Then
            MsgBox("Bulan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            cbbulan.Focus()
            Exit Sub
        End If

        If cbstatus.Text.Trim.Length <= 0 Then
            MsgBox("Area tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            cbstatus.Focus()
            Exit Sub
        End If

        kalkulasi()

    End Sub
End Class