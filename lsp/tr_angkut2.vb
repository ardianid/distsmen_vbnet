Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_angkut2

    Private statadd As Boolean
    Private dv As DataView
    Private dv1 As DataView
    Private posi As Integer = 0
    Private addjml As Integer = 0
    Private tp_harga As Integer = 0
    Private kd_princ As String = ""

    Sub New(ByVal adstat As Boolean, ByVal dv1 As DataView, ByVal pos As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        statadd = adstat
        dv = dv1
        posi = pos
        addjml = 0

        isi_combo2()

    End Sub

    Private Sub kosongkan()

        tbukti.Text = "<< New >>"
        ttgl.EditValue = Date.Now

        tkode_spir.Text = ""
        tnama_spir.Text = ""

        tnama1.Text = ""
        talamat1.Text = ""
        tnama2.Text = ""
        talamat2.Text = ""

        tnamabar.Text = ""
        tsatuan.Text = ""
        tjml.EditValue = 0.0

        toks.EditValue = 0
        ttot_oks.EditValue = 0
        tjlan.EditValue = 0

        tket.Text = ""

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

    Private Sub isi_box()

        tbukti.Enabled = False
        tbukti.Text = dv(posi)("NO_BUKTI").ToString
        ttgl.Text = convert_date_to_ind(dv(posi)("TANGGAL").ToString)

        tkode_spir.Text = dv(posi)("KD_SUPIR").ToString
        tnama_spir.Text = dv(posi)("NAMA_SUPIR").ToString
        cbnopol.EditValue = dv(posi)("NOPOL").ToString
        tket.Text = dv(posi)("KETERANGAN").ToString

        tnama1.Text = dv(posi)("CUST_ORDER").ToString
        talamat1.Text = dv(posi)("ALAMAT_ANGKUT").ToString
        tnama2.Text = dv(posi)("CUST_TUJUAN").ToString
        talamat2.Text = dv(posi)("ALAMAT_TUJUAN").ToString

        tnamabar.Text = dv(posi)("BARANG_ANGKUT").ToString
        tsatuan.Text = dv(posi)("SATUAN").ToString
        tjml.EditValue = CDbl(dv(posi)("JML").ToString)

        toks.EditValue = CDbl(dv(posi)("OKS_ANGKUT").ToString)
        ttot_oks.EditValue = CDbl(dv(posi)("TOT_OKS_ANGKUT").ToString)
        tjlan.EditValue = dv(posi)("UANG_JLN").ToString

    End Sub

    Private Sub edit()

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim sql As String = String.Format("update admlsp.TR_ANGKUTAN set TANGGAL='{0}',CUST_ORDER='{1}',ALAMAT_ANGKUT='{2}',CUST_TUJUAN='{3}',ALAMAT_TUJUAN='{4}',KD_SUPIR='{5}',NOPOL='{6}',BARANG_ANGKUT='{7}', JML={8},SATUAN='{9}',OKS_ANGKUT={10},TOT_OKS_ANGKUT={11},UANG_JLN={12},KETERANGAN='{13}',USER_EDIT='{14}',TGL_EDIT='{15}' " & _
                                          " where NO_BUKTI='{16}'", tgl, tnama1.Text.Trim, talamat1.Text.Trim, tnama2.Text.Trim, talamat2.Text.Trim, tkode_spir.Text.Trim, cbnopol.EditValue, tnamabar.Text.Trim, tjml.EditValue.ToString.Replace(",", "."), tsatuan.Text.Trim, Replace(toks.EditValue, ",", "."), Replace(ttot_oks.EditValue, ",", "."), Replace(tjlan.EditValue, ",", "."), tket.Text.Trim, userprog, convert_date_to_eng(Date.Now.ToString), tbukti.Text.Trim)

        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_ANGKUTAN", "UPDATE", "ANGKUTAN LAIN")

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

            tbukti.EditValue = classmy.GET_KODE_AKTLAIN(get_kode_stat, cn, ttgl.EditValue)
            sql_search = String.Format("select NO_BUKTI from admlsp.TR_ANGKUTAN where no_bukti='{0}'", tbukti.Text.Trim)

            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                tbukti.EditValue = classmy.GET_KODE_AKTLAIN(get_kode_stat, cn, ttgl.EditValue)
            Else
                dre.Close()
            End If

            ' Dim disc1 As String = convert_decimal_toEng(tdisc1.EditValue.ToString)

            sql = String.Format("insert into admlsp.TR_ANGKUTAN (NO_BUKTI,TANGGAL,CUST_ORDER,ALAMAT_ANGKUT,CUST_TUJUAN,ALAMAT_TUJUAN,BARANG_ANGKUT,JML,SATUAN,KD_SUPIR,NOPOL,KETERANGAN,OKS_ANGKUT,TOT_OKS_ANGKUT,UANG_JLN,USER_ADD,TGL_ADD,KD_STAT) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}','{9}','{10}','{11}',{12},{13},{14},'{15}','{16}','{17}')", tbukti.Text.Trim.ToUpper, tgl, tnama1.Text.Trim, talamat1.Text.Trim, tnama2.Text.Trim, talamat2.Text.Trim, tnamabar.Text.Trim, Replace(tjml.EditValue, ",", "."), tsatuan.Text.Trim, tkode_spir.Text.Trim, cbnopol.EditValue, tket.Text.Trim, Replace(toks.EditValue, ",", "."), Replace(ttot_oks.EditValue, ",", "."), Replace(tjlan.EditValue, ",", "."), userprog, convert_date_to_eng(Date.Now.ToString), get_kode_stat)
            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_ANGKUTAN", "INSERT", "ANGKUTAN LAIN")

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

        Dim orow As DataRow = dv.Table.NewRow

        orow("NO_BUKTI") = tbukti.Text

        If ttgl.Text = "" Then
            orow("TANGGAL") = DBNull.Value
        Else
            orow("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        orow("CUST_ORDER") = tnama1.Text.Trim
        orow("ALAMAT_ANGKUT") = talamat1.Text.Trim
        orow("CUST_TUJUAN") = tnama2.Text.Trim
        orow("ALAMAT_TUJUAN") = talamat2.Text.Trim

        orow("BARANG_ANGKUT") = tnamabar.Text.Trim
        orow("JML") = tjml.EditValue
        orow("SATUAN") = tsatuan.Text.Trim


        orow("KD_SUPIR") = tkode_spir.Text.Trim
        orow("NAMA_SUPIR") = tnama_spir.Text.Trim
        orow("KETERANGAN") = tket.Text.Trim


        orow("OKS_ANGKUT") = toks.EditValue
        orow("TOT_OKS_ANGKUT") = ttot_oks.EditValue
        orow("OKS_ANGKUT") = ttot_oks.EditValue
        orow("UANG_JLN") = tjlan.EditValue
        
        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        If ttgl.Text = "" Then
            dv(posi)("TANGGAL") = DBNull.Value
        Else
            dv(posi)("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        dv(posi)("CUST_ORDER") = tnama1.Text.Trim
        dv(posi)("ALAMAT_ANGKUT") = talamat1.Text.Trim
        dv(posi)("CUST_TUJUAN") = tnama2.Text.Trim
        dv(posi)("ALAMAT_TUJUAN") = talamat2.Text.Trim

        dv(posi)("BARANG_ANGKUT") = tnamabar.Text.Trim
        dv(posi)("JML") = tjml.EditValue
        dv(posi)("SATUAN") = tsatuan.Text.Trim


        dv(posi)("KD_SUPIR") = tkode_spir.Text.Trim
        dv(posi)("NAMA_SUPIR") = tnama_spir.Text.Trim
        dv(posi)("KETERANGAN") = tket.Text.Trim


        dv(posi)("OKS_ANGKUT") = toks.EditValue
        dv(posi)("TOT_OKS_ANGKUT") = ttot_oks.EditValue
        '  dv(posi)("OKS_ANGKUT") = ttot_oks.EditValue
        dv(posi)("UANG_JLN") = tjlan.EditValue
       

    End Sub

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
            tkode_spir.Focus()
        End If
    End Sub

    Private Sub cbnopol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbnopol.KeyDown
        If e.KeyCode = 13 Then
            tnama1.Focus()
        End If
    End Sub

    Private Sub tnama1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnama1.KeyDown
        If e.KeyCode = 13 Then
            talamat1.Focus()
        End If
    End Sub

    Private Sub talamat1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles talamat1.KeyDown
        If e.KeyCode = 13 Then
            tnama2.Focus()
        End If
    End Sub

    Private Sub tnama2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnama2.KeyDown
        If e.KeyCode = 13 Then
            talamat2.Focus()
        End If
    End Sub

    Private Sub talamat2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles talamat2.KeyDown
        If e.KeyCode = 13 Then
            tnamabar.Focus()
        End If
    End Sub

    Private Sub tnamabar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnamabar.KeyDown
        If e.KeyCode = 13 Then
            tsatuan.Focus()
        End If
    End Sub

    Private Sub tsatuan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsatuan.KeyDown
        If e.KeyCode = 13 Then
            tjml.Focus()
        End If
    End Sub

    Private Sub tjml_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tjml.KeyDown
        If e.KeyCode = 13 Then
            toks.Focus()
        End If
    End Sub

    Private Sub toks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles toks.KeyDown
        If e.KeyCode = 13 Then
            tjlan.Focus()
        End If
    End Sub

    Private Sub tjln_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tjlan.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        End If
    End Sub

    Private Sub tket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tket.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            tr_angkut.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tbukti.Text = "" Then

            MsgBox("No Bukti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tbukti.Focus()
            Exit Sub
        End If


        If talamat2.Text.Trim.Length = 0 Then

            MsgBox("Alamat tujuan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            talamat2.Focus()
            Exit Sub
        End If

        If tjml.Text = "" Then

            MsgBox("Jml Angkut tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tjml.Focus()
            Exit Sub
        End If

        If tsatuan.Text = "" Then

            MsgBox("Satuan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tsatuan.Focus()
            Exit Sub
        End If

        If toks.EditValue = 0 Then

            MsgBox("Ongkos angkut tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            toks.Focus()
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

        If statadd.Equals(True) Then
            insert()
        Else
            edit()
        End If


    End Sub

    Private Sub tr_pre2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            ttgl.Focus()
        Else
            ttgl.Focus()
        End If
    End Sub

    Private Sub tr_pre2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            ' tbukti.Enabled = True

            kosongkan()
            btsimpan.Text = "&Simpan"

        Else

            ' tbukti.Enabled = False

            isi_box()

            btsimpan.Text = "&Rubah"

        End If

    End Sub

    Private Sub toks_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tjml.EditValueChanged, toks.EditValueChanged

        ttot_oks.EditValue = CDbl(tjml.EditValue) * CDbl(toks.EditValue)

    End Sub

    Private Sub tnama1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tnama1.EditValueChanged

        If statadd.Equals(True) Then
            tnama2.Text = tnama1.Text
        End If

    End Sub
End Class