Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_kas_in2

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
        tdeposit.EditValue = 0


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

    Private Sub isi_box()

        'tbukti.Enabled = False
        tbukti.Text = dv(posi)("no_bukti").ToString
        ttgl.Text = convert_date_to_ind(dv(posi)("tanggal").ToString)
        cbjeniskas.EditValue = dv(posi)("kd_kas").ToString
        tdeposit.EditValue = dv(posi)("total").ToString
        tket.Text = dv(posi)("keterangan").ToString

    End Sub

    Private Sub edit()

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim sql As String = String.Format("update admlsp.TR_KAS_IN set tanggal='{0}',kd_kas='{1}',total={2},keterangan='{3}',user_edit='{4}',tgl_edit='{5}'" & _
                                          " where no_bukti='{6}'", tgl, cbjeniskas.EditValue, tdeposit.EditValue, tket.Text.Trim, userprog, convert_date_to_eng(Date.Now.ToString), tbukti.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_KAS_IN", "UPDATE", "KAS MASUK")

            sqltrans.Commit()

            update_view()

            MsgBox("Data telah dirubah..", MsgBoxStyle.Information, "Informasi")

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

            tbukti.Text = classmy.GET_KODE_KASMASUK(get_kode_stat, cn, ttgl.EditValue)

            sql_search = String.Format("select no_bukti from admlsp.TR_KAS_IN where no_bukti='{0}'", tbukti.Text.Trim)
            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                tbukti.Text = classmy.GET_KODE_KASMASUK(get_kode_stat, cn, ttgl.EditValue)
                'MsgBox("Kode sudah ada", MsgBoxStyle.Information, "Informasi")
                'tbukti.Focus()
                'Exit Sub
            Else
                dre.Close()
            End If




            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            sql = String.Format("insert into admlsp.TR_KAS_IN (no_bukti,tanggal,kd_kas,total,keterangan,kd_stat,user_add,tgl_add) values" & _
                                          "('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}')", tbukti.Text.Trim.ToUpper, tgl, cbjeniskas.EditValue, tdeposit.EditValue, tket.Text.Trim, get_kode_stat, userprog, convert_date_to_eng(Date.Now.ToString))

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_KAS_IN", "INSERT", "KAS MASUK")

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
            orow("TANGGAL") = DBNull.Value
        Else
            orow("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        orow("NAMA") = cbjeniskas.Text.Trim
        orow("KD_KAS") = cbjeniskas.EditValue
        orow("TOTAL") = tdeposit.EditValue
        orow("KETERANGAN") = tket.Text.Trim

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()


        If ttgl.Text = "" Then
            dv(posi)("TANGGAL") = DBNull.Value
        Else
            dv(posi)("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        dv(posi)("NAMA") = cbjeniskas.Text.Trim
        dv(posi)("KD_KAS") = cbjeniskas.EditValue
        dv(posi)("TOTAL") = tdeposit.EditValue
        dv(posi)("KETERANGAN") = tket.Text.Trim

    End Sub

    Private Sub tr_kasin2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            ttgl.Focus()
        Else
            ttgl.Focus()
        End If
    End Sub

    Private Sub tr_kasin2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            'ttgl.Properties.ReadOnly = False
            cbjeniskas.Properties.ReadOnly = False

            kosongkan()
        Else

            'ttgl.Properties.ReadOnly = True
            cbjeniskas.Properties.ReadOnly = True

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
            cbjeniskas.Focus()
        End If
    End Sub

    Private Sub cbjeniskas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbjeniskas.KeyDown
        If e.KeyCode = 13 Then
            tdeposit.Focus()
        End If
    End Sub

    Private Sub tdeposit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdeposit.KeyDown
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
            tr_kas_in.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tbukti.Text = "" Then

            MsgBox("No bukti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tbukti.Focus()
            Exit Sub
        End If

        If cbjeniskas.Text = "" Then

            MsgBox("Jenis kas tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            cbjeniskas.Focus()
            Exit Sub
        End If


        If tdeposit.EditValue = 0 Then

            MsgBox("Jml kas masuk tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tdeposit.Focus()
            Exit Sub

        End If


        If statadd.Equals(True) Then
            insert()
        Else
            edit()
        End If


    End Sub

End Class