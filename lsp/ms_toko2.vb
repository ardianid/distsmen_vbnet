Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class ms_toko2
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

        isi_combo_area()

    End Sub

    Private Sub kosongkan()

        tkode.Text = ""
        tnama.Text = ""
        talamat.Text = ""
        ttelp1.Text = ""
        ttelp2.Text = ""
        tkontak.Text = ""
        tpemilik.Text = ""

        tkodekec.Text = ""
        tnamakec.Text = ""

        tkodekab.Text = ""
        tnamakab.Text = ""

        tdeposit.EditValue = 0
        tgiro.EditValue = 0
        thutang.EditValue = 0

        tlimitnota.EditValue = 0
        tlimitval.EditValue = 0

    End Sub

    Private Sub isi_combo_area()

        Const sql = "select kode,nama,status from admlsp.MS_STAT order by kode"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv = dvm.CreateDataView(ds.Tables(0))

            cbarea.Properties.DataSource = dv


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

    Private Sub isi_combo_sales()

        Dim sql As String = String.Format("select a.KD_SALES,a.NAMA from admlsp.ms_sales a where a.KD_STAT='{0}' order by a.NAMA asc", cbarea.EditValue)

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv = dvm.CreateDataView(ds.Tables(0))

            cbsales.Properties.DataSource = dv


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

        tkode.Enabled = False
        tkode.Text = dv(posi)("KD_TOKO").ToString
        tnama.Text = dv(posi)("NAMA_TOKO").ToString
        talamat.Text = dv(posi)("ALAMAT").ToString
        ttelp1.Text = dv(posi)("TELP").ToString
        ttelp2.Text = dv(posi)("TELP2").ToString
        tkontak.Text = dv(posi)("NAMA_KONTAK").ToString
        cbtipe.Text = dv(posi)("TIPE_HARGA").ToString
        tpemilik.Text = dv(posi)("NAMA_PEMILIK").ToString

        tkodekab.Text = dv(posi)("KD_KAB").ToString
        tnamakab.Text = dv(posi)("KAB").ToString

        tkodekec.Text = dv(posi)("KD_KEC").ToString
        tnamakec.Text = dv(posi)("NAMA_KEC").ToString

        cbarea.EditValue = dv(posi)("KD_STAT").ToString

        isi_combo_sales()

        cbsales.EditValue = dv(posi)("KD_SALES").ToString

        tdeposit.EditValue = dv(posi)("TTL_DEPOSIT").ToString
        tgiro.EditValue = dv(posi)("TTL_GIRO").ToString
        thutang.EditValue = dv(posi)("TTL_HUTANG").ToString

        tlimitnota.EditValue = dv(posi)("LIMIT_NOTA").ToString
        tlimitval.EditValue = dv(posi)("LIMIT_VAL").ToString

        If dv(posi)("AKTIF").ToString = 1 Then
            caktif.Checked = 1
        Else
            caktif.Checked = 0
        End If

    End Sub

    Private Sub edit()

        Dim sql As String = String.Format("update admlsp.ms_toko set nama_toko='{0}',alamat='{1}',telp='{2}',telp2='{3}',nama_kontak='{4}',nama_pemilik='{5}',aktif={6},kd_kec='{7}',tipe_harga={8},kode_stat='{9}',kd_sales='{10}',user_edit='{11}',tgl_edit='{12}',kd_tbs='{13}',limit_nota={14},limit_val={15}" & _
                                          " where kd_toko='{16}'", tnama.Text.Trim, talamat.Text.Trim, ttelp1.Text.Trim, ttelp2.Text.Trim, tkontak.Text.Trim, tpemilik.Text.Trim, IIf(caktif.Checked = True, 1, 0), tkodekec.Text.Trim, cbtipe.EditValue, cbarea.EditValue, cbsales.EditValue, userprog, convert_date_to_eng(Date.Now.ToString), tkodekab.Text.Trim, Replace(tlimitnota.EditValue, ",", "."), Replace(tlimitval.EditValue, ",", "."), tkode.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand


        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)

            cmd.ExecuteNonQuery()

            If classmy.insert_to_temp_user(cn, sql, tkode.Text.Trim, "MS_TOKO", "UPDATE", "TOKO") = False Then
                close_wait()
                MsgBox("Kesalahan data Temp User", MsgBoxStyle.Critical, "Informasi")
            Else
                sqltrans.Commit()

                update_view()

                MsgBox("Data telah dirubah..", MsgBoxStyle.Information, "Informasi")
                'ms_supir.refresh_data()

                close_wait()

                Me.Close()
            End If

            

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


        Dim limitnota As String = tlimitnota.EditValue
        If IsNothing(limitnota) Then
            tlimitnota.EditValue = 0
        ElseIf limitnota.Equals("") Then
            tlimitnota.EditValue = 0
        End If

        Dim limitvalue As String = tlimitval.EditValue
        If IsNothing(limitvalue) Then
            tlimitval.EditValue = 0
        ElseIf limitvalue.Equals("") Then
            tlimitval.EditValue = 0
        End If

        Dim sql As String = String.Format("insert into admlsp.ms_toko (kd_toko,nama_toko,alamat,telp,telp2,nama_pemilik,nama_kontak,aktif,tipe_harga,kd_kec,kode_stat,kd_sales,user_add,tgl_add,kd_tbs,limit_nota,limit_val) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},'{9}','{10}','{11}','{12}','{13}','{14}',{15},{16})", tkode.Text.Trim.ToUpper, tnama.Text.Trim.ToUpper, talamat.Text.Trim.ToUpper, ttelp1.Text.Trim, ttelp2.Text.Trim, tpemilik.Text.Trim, tkontak.Text.Trim, IIf(caktif.Checked = True, 1, 0), cbtipe.EditValue.ToString, tkodekec.Text.Trim, cbarea.EditValue.ToString, cbsales.EditValue.ToString, userprog, convert_date_to_eng(Date.Now.ToString), tkodekab.Text.Trim, Replace(tlimitnota.EditValue, ",", "."), Replace(tlimitval.EditValue, ",", "."))
        Dim sql_search As String = String.Format("select kd_toko from admlsp.ms_toko where kd_toko='{0}'", tkode.Text.Trim)


        Dim cmd As OracleCommand
        Dim cn As OracleConnection = Nothing
        Dim dre As OracleDataReader = Nothing
        Dim cmdsearch As OracleCommand

        Try

            cn = classmy.open_conn_utama

            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                MsgBox("Kode sudah ada", MsgBoxStyle.Information, "Informasi")
                tkode.Focus()
                Exit Sub
            Else
                dre.Close()
            End If


            open_wait()

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            If classmy.insert_to_temp_user(cn, sql, tkode.Text.Trim, "MS_TOKO", "INSERT", "TOKO") = False Then
                close_wait()
                MsgBox("Kesalahan data Temp User", MsgBoxStyle.Critical, "Informasi")
            Else
                sqltrans.Commit()

                insert_view()

                close_wait()

                MsgBox("Data telah disimpan... ", MsgBoxStyle.Information, "Informasi")

                addjml = addjml + 1

                kosongkan()
                tkode.Focus()
            End If

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

        orow("KD_TOKO") = tkode.Text
        orow("NAMA_TOKO") = tnama.Text
        orow("ALAMAT") = talamat.Text
        orow("AKTIF") = IIf(caktif.Checked = True, 1, 0)
        orow("TELP") = ttelp1.Text
        orow("TELP2") = ttelp2.Text
        orow("NAMA_PEMILIK") = tpemilik.Text
        orow("NAMA_KONTAK") = tkontak.Text
        orow("TIPE_HARGA") = cbtipe.EditValue
        orow("NAMA_KEC") = tnamakec.Text.Trim
        orow("NAMA_STAT") = cbarea.Text
        orow("NAMA_SALES") = cbsales.Text

        orow("KD_KEC") = tkodekec.Text.Trim
        orow("KD_STAT") = cbarea.EditValue
        orow("KD_SALES") = cbsales.EditValue

        orow("KD_KAB") = tkodekab.Text.Trim
        orow("KAB") = tnamakab.Text.Trim

        orow("TTL_DEPOSIT") = 0
        orow("TTL_GIRO") = 0
        orow("TTL_HUTANG") = 0

        Dim limitnota As String = tlimitnota.EditValue
        If IsNothing(limitnota) Then
            limitnota = 0
        ElseIf limitnota.Equals("") Then
            limitnota = 0
        End If

        Dim limitvalue As String = tlimitval.EditValue
        If IsNothing(limitvalue) Then
            limitvalue = 0
        ElseIf limitvalue.Equals("") Then
            limitvalue = 0
        End If

        orow("LIMIT_NOTA") = limitnota
        orow("LIMIT_VAL") = limitvalue

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        dv(posi)("NAMA_TOKO") = tnama.Text
        dv(posi)("ALAMAT") = talamat.Text
        dv(posi)("AKTIF") = IIf(caktif.Checked = True, 1, 0)
        dv(posi)("TELP") = ttelp1.Text
        dv(posi)("TELP2") = ttelp2.Text
        dv(posi)("NAMA_PEMILIK") = tpemilik.Text
        dv(posi)("NAMA_KONTAK") = tkontak.Text
        dv(posi)("TIPE_HARGA") = cbtipe.EditValue
        dv(posi)("NAMA_KEC") = tnamakec.Text.Trim
        dv(posi)("NAMA_STAT") = cbarea.Text
        dv(posi)("NAMA_SALES") = cbsales.Text

        dv(posi)("KD_KEC") = tkodekec.Text.Trim
        dv(posi)("KD_STAT") = cbarea.EditValue
        dv(posi)("KD_SALES") = cbsales.EditValue

        dv(posi)("KD_KAB") = tkodekab.Text.Trim
        dv(posi)("KAB") = tnamakab.Text.Trim


        Dim limitnota As String = tlimitnota.EditValue
        If IsNothing(limitnota) Then
            limitnota = 0
        ElseIf limitnota.Equals("") Then
            limitnota = 0
        End If

        Dim limitvalue As String = tlimitval.EditValue
        If IsNothing(limitvalue) Then
            limitvalue = 0
        ElseIf limitvalue.Equals("") Then
            limitvalue = 0
        End If

        dv(posi)("LIMIT_NOTA") = limitnota
        dv(posi)("LIMIT_VAL") = limitvalue

    End Sub

    Private Sub tkodekab_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkodekab.KeyDown
        If e.KeyCode = 13 Then
            tpemilik.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'tnamatok.Text.Trim
            tkodekab.Text = ""
            tnamakab.Text = ""

            Using fcari As New sr_kab(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkodekab.Text = fcari.get_KODE
                tnamakab.Text = fcari.get_NAMA

            End Using

        End If
    End Sub

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfindsal.Click

        Dim cari As String = "" 'tnamatok.Text.Trim

        Using fcari As New sr_kab(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkodekab.Text = fcari.get_KODE
            tnamakab.Text = fcari.get_NAMA

            If tkodekab.Text.Length > 0 Then
                tnama_toko_Validating(sender, Nothing)
            End If

        End Using


    End Sub

    Private Sub tnama_toko_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkodekab.Validating

        If tkodekab.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            sql = String.Format("select a.KODE,a.NAMA from admlsp.ms_kab a inner join admlsp.ms_prop b on a.KODE_PROP=b.KODE WHERE a.KODE='{0}'", tkodekab.Text.Trim)


            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tkodekab.Text = dred(0).ToString
                    tnamakab.Text = dred(1).ToString

                    dred.Close()

                Else

                    dred.Close()
                    MsgBox("Kabupaten tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tkodekab.Focus()
                    tnamakab.Text = ""

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

            tkodekab.Text = ""
            tnamakab.Text = ""

        End If


    End Sub

    Private Sub tkodeKEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkodekec.KeyDown
        If e.KeyCode = 13 Then
            tkodekab.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'tnamatok.Text.Trim
            tkodekab.Text = ""
            tnamakab.Text = ""

            Using fcari As New sr_kec(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkodekec.Text = fcari.get_KODE
                tnamakec.Text = fcari.get_NAMA

            End Using

        End If
    End Sub

    Private Sub btfindKec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfindkec.Click

        Dim cari As String = "" 'tnamatok.Text.Trim

        Using fcari As New sr_kec(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkodekec.Text = fcari.get_KODE
            tnamakec.Text = fcari.get_NAMA

            If tkodekec.Text.Length > 0 Then
                tkodekec_Validating(sender, Nothing)
            End If

        End Using


    End Sub

    Private Sub tkodekec_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkodekec.Validating

        If tkodekec.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            sql = String.Format("select A.KODE,A.NAMA from admlsp.ms_kec a inner join admlsp.ms_kab b on a.KODE_KAB=b.KODE WHERE a.KODE='{0}'", tkodekec.Text.Trim)


            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tkodekec.Text = dred(0).ToString
                    tnamakec.Text = dred(1).ToString

                    dred.Close()

                Else

                    dred.Close()
                    MsgBox("Kecamatan tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tkodekec.Focus()
                    tnamakec.Text = ""

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

            tkodekec.Text = ""
            tnamakec.Text = ""

        End If


    End Sub

    Private Sub ms_toko2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            tkode.Focus()
        Else
            tnama.Focus()
        End If
    End Sub

    Private Sub ms_toko2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            tkode.Enabled = True

            caktif.Enabled = False
            caktif.Checked = 1
        Else

            tkode.Enabled = False

            caktif.Enabled = True
            isi_box()
        End If



    End Sub

    Private Sub tkode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkode.KeyDown
        If e.KeyCode = 13 Then
            tnama.Focus()
        End If
    End Sub

    Private Sub tnama_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnama.KeyDown
        If e.KeyCode = 13 Then
            talamat.Focus()
        End If
    End Sub

    Private Sub talamat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles talamat.KeyDown
        If e.KeyCode = 13 Then
            tkodekec.Focus()
        End If
    End Sub



    Private Sub tpemilik_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tpemilik.KeyDown
        If e.KeyCode = 13 Then
            tkontak.Focus()
        End If
    End Sub

    Private Sub tkontak_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkontak.KeyDown
        If e.KeyCode = 13 Then
            ttelp1.Focus()
        End If
    End Sub

    Private Sub ttelp1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttelp1.KeyDown
        If e.KeyCode = 13 Then
            ttelp2.Focus()
        End If
    End Sub

    Private Sub ttelp2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttelp2.KeyDown
        If e.KeyCode = 13 Then
            cbtipe.Focus()
        End If
    End Sub

    Private Sub cbtipe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbtipe.KeyDown
        If e.KeyCode = 13 Then
            cbarea.Focus()
        End If
    End Sub

    Private Sub cbarea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbarea.KeyDown
        If e.KeyCode = 13 Then
            cbsales.Focus()
        End If
    End Sub

    Private Sub cbsales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbsales.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub cbarea_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbarea.LostFocus

        If cbarea.Text = "" Then
            cbsales.EditValue = ""
            cbsales.Text = ""
        Else
            isi_combo_sales()
        End If

    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            ms_toko.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tkode.Text = "" Then

            MsgBox("Kode tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tkode.Focus()
            Exit Sub
        End If

        If tnama.Text = "" Then

            MsgBox("Nama tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tnama.Focus()
            Exit Sub
        End If


        If tkodekec.Text = "" Then

            MsgBox("Kecamatan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tkodekec.Focus()
            Exit Sub

        End If

        If tkodekab.Text = "" Then

            MsgBox("Area tebusan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tkodekab.Focus()
            Exit Sub

        End If

        If cbarea.Text = "" Then

            MsgBox("Area tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            cbarea.Focus()
            Exit Sub

        End If

        If cbsales.Text = "" Then

            MsgBox("Sales tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            cbsales.Focus()
            Exit Sub

        End If

        If cbtipe.Text = "" Then

            MsgBox("Tipe harga tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            cbtipe.Focus()
            Exit Sub

        End If

        If statadd.Equals(True) Then
            insert()
        Else
            edit()
        End If


    End Sub

End Class