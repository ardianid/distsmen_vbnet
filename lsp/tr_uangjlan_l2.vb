Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_uangjlan_l2

    Private statadd As Boolean
    Private dv As DataView
    Private posi As Integer = 0
    Private addjml As Integer = 0
    Private dv1 As DataView

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
        tnodo.Text = ""
        tinfo.Text = ""
        tjmljalan.EditValue = 0
        tjml.EditValue = 0
        tket.Text = ""

    End Sub

    Private Sub tnodo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnodo.KeyDown
        If e.KeyCode = 13 Then
            cbjeniskas.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'nama_toko.Text.Trim
            tnodo.Text = ""

            Using fcari As New sr_angk_lain(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tnodo.Text = fcari.get_NOBUKTI

            End Using

        End If
    End Sub

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click

        Dim cari As String = "" 'tnama_toko.Text.Trim"

        Using fcari As New sr_angk_lain(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tnodo.Text = fcari.get_NOBUKTI


            If tnodo.Text <> "" Then
                tnodo_Validating(sender, Nothing)
            End If

        End Using


    End Sub

    Private Sub tnodo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tnodo.Validating

        If tnodo.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            If statadd = False Then

                If get_stat_pusat() = 1 Then
                    sql = String.Format("SELECT tr_angkutan.no_bukti, tr_angkutan.tanggal, tr_angkutan.cust_order,tr_angkutan.alamat_tujuan, tr_angkutan.nopol,tr_angkutan.uang_jln " & _
                        "FROM admlsp.tr_angkutan " & _
                        "where tr_angkutan.NO_BUKTI='{0}'", tnodo.Text.Trim)
                ElseIf get_stat_pusat() = 0 Then
                    sql = String.Format("SELECT tr_angkutan.no_bukti, tr_angkutan.tanggal, tr_angkutan.cust_order,tr_angkutan.alamat_tujuan, tr_angkutan.nopol,tr_angkutan.uang_jln " & _
                        "FROM admlsp.tr_angkutan " & _
                        "where tr_angkutan.NO_BUKTI='{0}' AND tr_angkutan.KD_STAT='{1}'", tnodo.Text.Trim, get_kode_stat)
                End If

            Else

                If get_stat_pusat() = 1 Then
                    sql = String.Format("SELECT tr_angkutan.no_bukti, tr_angkutan.tanggal, tr_angkutan.cust_order,tr_angkutan.alamat_tujuan, tr_angkutan.nopol,(tr_angkutan.uang_jln - tr_angkutan.uang_jln_cair) as uang_jln  " & _
                        "FROM admlsp.tr_angkutan " & _
                        "where tr_angkutan.uang_jln_cair < tr_angkutan.uang_jln and tr_angkutan.NO_BUKTI='{0}'", tnodo.Text.Trim)
                ElseIf get_stat_pusat() = 0 Then
                    sql = String.Format("SELECT tr_angkutan.no_bukti, tr_angkutan.tanggal, tr_angkutan.cust_order,tr_angkutan.alamat_tujuan, tr_angkutan.nopol,(tr_angkutan.uang_jln - tr_angkutan.uang_jln_cair) as uang_jln " & _
                        "FROM admlsp.tr_angkutan " & _
                        "where tr_angkutan.uang_jln_cair < tr_angkutan.uang_jln and tr_angkutan.NO_BUKTI='{0}' AND tr_angkutan.KD_STAT='{1}'", tnodo.Text.Trim, get_kode_stat)
                End If

            End If




            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tnodo.Text = dred(0).ToString

                    Dim info As String = String.Format("{0}{1}{2}{3}", CType(dred("TANGGAL").ToString, Date) & Environment.NewLine, dred("CUST_ORDER").ToString & " - ", dred("ALAMAT_TUJUAN").ToString & Environment.NewLine & Environment.NewLine, dred("NOPOL").ToString)

                    tinfo.EditValue = info

                    If Not IsNothing(dred("UANG_JLN").ToString) Then
                        If IsNumeric(dred("UANG_JLN").ToString) Then
                            tjmljalan.EditValue = CDbl(dred("UANG_JLN").ToString)
                        Else
                            tjmljalan.EditValue = 0
                        End If
                    Else
                        tjmljalan.EditValue = 0
                    End If

                    dred.Close()

                Else

                    MsgBox("No Bukti tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tnodo.Focus()
                    tinfo.EditValue = ""
                    tjmljalan.EditValue = 0
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
            tnodo.Text = ""
            tinfo.EditValue = ""
            tjmljalan.EditValue = 0
        End If

    End Sub

    Private Sub isi_box()

        tbukti.Enabled = False
        tbukti.Text = dv(posi)("NO_BUKTI").ToString
        ttgl.Text = convert_date_to_ind(dv(posi)("TGL").ToString)
        tnodo.Text = dv(posi)("KD_PRE").ToString

        cbjeniskas.EditValue = dv(posi)("KD_KAS").ToString

        tjml.EditValue = dv(posi)("JML").ToString
        tket.Text = dv(posi)("KETERANGAN").ToString

        tnodo_Validating(Nothing, Nothing)

    End Sub

    Private Sub isi_combo()

        Dim sql As String

        If get_stat_pusat() = 1 Then
            Sql = "SELECT A.KODE,A.NAMA,B.STATUS FROM ADMLSP.MS_KAS A INNER JOIN ADMLSP.MS_STAT B ON A.KD_STAT=B.KODE"
        Else
            sql = String.Format("SELECT A.KODE,A.NAMA,B.STATUS FROM ADMLSP.MS_KAS A INNER JOIN ADMLSP.MS_STAT B ON A.KD_STAT=B.KODE WHERE A.KD_STAT='{0}'", get_kode_stat)
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

            cbjeniskas.Properties.DataSource = dv


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

    Private Sub edit()

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim sql As String = String.Format("update admlsp.TR_UANG_JLN_LN set tgl='{0}',kd_angk='{1}',jml={2},keterangan='{3}',user_edit='{4}',tgl_edit='{5}',kd_kas='{6}'" & _
                                          " where no_bukti='{7}'", tgl, tnodo.Text.Trim, tjml.EditValue, tket.Text.Trim, userprog, convert_date_to_eng(Date.Now.ToString), cbjeniskas.EditValue, tbukti.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_UANG_JLN_LN", "UPDATE", "UANG JALAN ANGK LAIN")

            sqltrans.Commit()

            update_view()

            MsgBox("Data telah dirubah..", MsgBoxStyle.Information, "Informasi")
            ' ms_supir.refresh_data()

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

        Dim cmd As OracleCommand
        Dim cn As OracleConnection = Nothing
        Dim dre As OracleDataReader = Nothing
        Dim cmdsearch As OracleCommand

        Try

            cn = classmy.open_conn_utama

            tbukti.Text = classmy.GET_KODE_UANGJALAN_ANGK_LAIN(get_kode_stat, cn, ttgl.EditValue)


            Dim sql_search As String = String.Format("select no_bukti from admlsp.TR_UANG_JLN_LN where no_bukti='{0}'", tbukti.Text.Trim)
            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                MsgBox("Kode sudah ada", MsgBoxStyle.Information, "Informasi")
                tbukti.Focus()
                Exit Sub
            Else
                dre.Close()
            End If


            open_wait()

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            Dim sql As String = String.Format("insert into admlsp.TR_UANG_JLN_LN (no_bukti,tgl,kd_angk,jml,user_add,tgl_add,kd_stat,kd_kas) values" & _
                                          "('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}')", tbukti.Text.Trim.ToUpper, tgl, tnodo.Text.Trim, tjml.EditValue, userprog, convert_date_to_eng(Date.Now.ToString), get_kode_stat, cbjeniskas.EditValue)

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_UANG_JLN_LN", "INSERT", "UANG JALAN ANGK LAIN")

            sqltrans.Commit()

            insert_view()

            close_wait()

            MsgBox("Data telah disimpan... ", MsgBoxStyle.Information, "Informasi")

            addjml = addjml + 1

            kosongkan()
            tbukti.Focus()

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
            orow("TGL") = DBNull.Value
        Else
            orow("TGL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        orow("KD_PRE") = tnodo.Text.Trim
        orow("KETERANGAN") = tket.Text.Trim
        orow("KD_KAS") = cbjeniskas.EditValue
        orow("NAMA_KAS") = cbjeniskas.Text.Trim
        orow("JML") = tjml.EditValue

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        If ttgl.Text = "" Then
            dv(posi)("TGL") = DBNull.Value
        Else
            dv(posi)("TGL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        dv(posi)("KD_PRE") = tnodo.Text.Trim
        dv(posi)("KETERANGAN") = tket.Text.Trim
        dv(posi)("KD_KAS") = cbjeniskas.EditValue
        dv(posi)("NAMA_KAS") = cbjeniskas.Text.Trim
        dv(posi)("JML") = tjml.EditValue

    End Sub

    Private Sub tr_dep_toko2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            ttgl.Focus()
        Else
            ttgl.Focus()
        End If
    End Sub

    Private Sub tr_dep_toko2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        isi_combo()

        If statadd.Equals(True) Then

            tbukti.Enabled = True

            cbjeniskas.Properties.ReadOnly = False
            tnodo.Properties.ReadOnly = False
            btfind.Enabled = True

            kosongkan()

        Else

            tbukti.Enabled = False

            cbjeniskas.Properties.ReadOnly = True
            tnodo.Properties.ReadOnly = True
            btfind.Enabled = False

            isi_box()
        End If

    End Sub

    Private Sub tbukti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbukti.KeyDown
        If e.KeyCode = 13 Then
            ttgl.Focus()
        End If
    End Sub

    Private Sub ttgl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        If e.KeyCode = 13 Then
            tnodo.Focus()
        End If
    End Sub

    Private Sub cbjeniskas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbjeniskas.KeyDown
        If e.KeyCode = 13 Then
            tjml.Focus()
        End If
    End Sub

    Private Sub tjml_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tjml.KeyDown
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
            tr_uangjlan_l.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tbukti.Text = "" Then

            MsgBox("No bukti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tbukti.Focus()
            Exit Sub
        End If

        If tnodo.Text = "" Then

            MsgBox("No Bukti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tnodo.Focus()
            Exit Sub
        End If

        If cbjeniskas.Text.Trim.Length <= 0 Then

            MsgBox("Kas tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            cbjeniskas.Focus()
            Exit Sub

        End If

        If tjml.EditValue <= 0 Then

            MsgBox("Uang jalan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
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