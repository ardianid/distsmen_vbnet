Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_spare_in2
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
        tsatuan.Text = ""
        tjml.EditValue = 0
        tket.Text = ""

    End Sub

    Private Sub isi_combo()

        Const sql = "select kode,nama,satuan from admlsp.ms_sparepart order by nama asc"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        'Dim dv As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv1 = dvm.CreateDataView(ds.Tables(0))

            cbspare.Properties.DataSource = dv1


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
        tbukti.Text = dv(posi)("no_bukti").ToString
        ttgl.Text = convert_date_to_ind(dv(posi)("tgl_bukti").ToString)
        cbspare.Text = dv(posi)("nama").ToString
        cbspare.EditValue = dv(posi)("kd_spare").ToString
        tsatuan.Text = dv(posi)("satuan").ToString
        tjml.EditValue = dv(posi)("jml").ToString
        tket.Text = dv(posi)("keterangan").ToString

    End Sub

    Private Sub edit()

        Dim sql As String = String.Format("update admlsp.tr_sparepart set tgl_bukti='{0}',kd_spare='{1}',jml={2},keterangan='{3}',user_edit='{4}',tgl_edit='{5}'" & _
                                          " where no_bukti='{6}'", convert_date_to_eng(ttgl.EditValue.ToString), cbspare.EditValue, tjml.EditValue, tket.Text.Trim, userprog, convert_date_to_eng(Date.Now.ToString), tbukti.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_SPAREPART", "UPDATE", "SPAREPART MASUK")

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

        Dim sql As String = ""
        Dim sql_search As String = ""


        Dim cmd As OracleCommand
        Dim cn As OracleConnection = Nothing
        Dim dre As OracleDataReader = Nothing
        Dim cmdsearch As OracleCommand

        Try
            open_wait()
            cn = classmy.open_conn_utama

            tbukti.Text = classmy.GET_KODE_SPAREIN(get_kode_stat, cn, ttgl.EditValue)

            sql_search = String.Format("select no_bukti from admlsp.tr_sparepart where no_bukti='{0}'", tbukti.Text.Trim)
            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                tbukti.Text = classmy.GET_KODE_SPAREIN(get_kode_stat, cn, ttgl.EditValue)
                'MsgBox("Kode sudah ada", MsgBoxStyle.Information, "Informasi")
                'tbukti.Focus()
                'Exit Sub
            Else
                dre.Close()
            End If

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            sql = String.Format("insert into admlsp.tr_sparepart (no_bukti,tgl_bukti,kd_spare,jml,keterangan,user_add,tgl_add,kd_stat) values" & _
                                          "('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}')", tbukti.Text.Trim.ToUpper, convert_date_to_eng(ttgl.EditValue.ToString), cbspare.EditValue, tjml.EditValue, tket.Text.Trim, userprog, convert_date_to_eng(Date.Now.ToString), get_kode_stat)
            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_SPAREPART", "INSERT", "SPAREPART MASUK")

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
        orow("TGL_BUKTI") = convert_date_to_ind(ttgl.EditValue.ToString)
        orow("NAMA") = cbspare.Text.Trim
        orow("KD_SPARE") = cbspare.EditValue
        orow("JML") = tjml.EditValue
        orow("KETERANGAN") = tket.Text.Trim

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        dv(posi)("TGL_BUKTI") = convert_date_to_ind(ttgl.EditValue.ToString)
        dv(posi)("NAMA") = cbspare.Text.Trim
        dv(posi)("KD_SPARE") = cbspare.EditValue
        dv(posi)("JML") = tjml.EditValue
        dv(posi)("KETERANGAN") = tket.Text.Trim

    End Sub

    Private Sub tr_sparein2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            ttgl.Focus()
        Else
            ttgl.Focus()
        End If
    End Sub

    Private Sub tr_sparein2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            'tbukti.Enabled = True

            kosongkan()
        Else

            'tbukti.Enabled = False

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
            cbspare.Focus()
        End If
    End Sub

    Private Sub princ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbspare.KeyDown
        If e.KeyCode = 13 Then
            tjml.Focus()
        End If
    End Sub

    Private Sub jml_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tjml.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        End If
    End Sub

    Private Sub ket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tket.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            tr_spare_in.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tbukti.Text = "" Then

            MsgBox("No bukti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tbukti.Focus()
            Exit Sub
        End If

        If cbspare.Text = "" Then

            MsgBox("Nama sparepart tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            cbspare.Focus()
            Exit Sub
        End If


        If tjml.EditValue = 0 Then

            MsgBox("Jml masuk tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tjml.Focus()
            Exit Sub

        End If


        If statadd.Equals(True) Then
            insert()
        Else
            edit()
        End If


    End Sub

    Private Sub cbspare_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbspare.Validating

        If cbspare.Text = "" Then
            tsatuan.Text = ""
            Exit Sub
        End If

        If IsNothing(dv1) Then
            tsatuan.Text = ""
            Exit Sub
        End If

        'Dim satuan As String = dv.Find("KODE" = cbspare.EditValue)


        tsatuan.Text = dv1(cbspare.ItemIndex)("SATUAN").ToString

    End Sub
End Class