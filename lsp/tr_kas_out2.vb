Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_kas_out2

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

        isi_combo()

    End Sub

    Private Sub kosongkan()

        tbukti.Text = "<< New >>"
        ttgl.EditValue = Date.Now
        tket.Text = ""

        dv1 = New DataView
        dv1 = Nothing

        grid1.DataSource = Nothing

    End Sub

    Private Sub isi_combo()

        Dim sql As String

        If get_stat_pusat() = 1 Then
            sql = "SELECT A.KODE,A.NAMA,B.STATUS FROM ADMLSP.MS_KAS A INNER JOIN ADMLSP.MS_STAT B ON A.KD_STAT=B.KODE"
        Else
            sql = String.Format("SELECT A.KODE,A.NAMA,B.STATUS FROM ADMLSP.MS_KAS A INNER JOIN ADMLSP.MS_STAT B ON A.KD_STAT=B.KODE WHERE A.KD_STAT='{0}'", get_kode_stat)
        End If

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dvcb As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dvcb = dvm.CreateDataView(ds.Tables(0))

            cbjeniskas.Properties.DataSource = dvcb


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


        Dim sql As String = String.Format("SELECT A.KD_AKUN,B.NAMA,A.JML,A.DESKRIPSI FROM ADMLSP.TR_KAS_OUT2 A INNER JOIN ADMLSP.MS_AKUN B ON A.KD_AKUN=B.KODE WHERE A.NO_BUKTI='{0}'", tbukti.Text.Trim)

        grid1.DataSource = Nothing
        Try

            dv1 = Nothing

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            dv1.Sort = "KD_AKUN"

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

        tbukti.Text = dv(posi)("no_bukti").ToString
        ttgl.Text = convert_date_to_ind(dv(posi)("tanggal").ToString)
        cbjeniskas.EditValue = dv(posi)("kd_kas").ToString

        tket.Text = dv(posi)("keterangan").ToString

    End Sub

    Private Sub edit(ByVal refreshd As Boolean)

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim sql As String = String.Format("update admlsp.TR_KAS_OUT set tanggal='{0}',kd_kas='{1}',total={2},keterangan='{3}',user_edit='{4}',tgl_edit='{5}'" & _
                                          " where no_bukti='{6}'", tgl, cbjeniskas.EditValue, gridview.Columns("JML").SummaryItem.SummaryValue, tket.Text.Trim, userprog, convert_date_to_eng(Date.Now.ToString), tbukti.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_KAS_OUT", "UPDATE", "KAS KELUAR")

            manipulate2(cn)

            sqltrans.Commit()

            update_view()

            If refreshd = False Then
                MsgBox("Data telah dirubah..", MsgBoxStyle.Information, "Informasi")
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

        Dim sql As String = ""
        Dim sql_search As String = ""


        Dim cmd As OracleCommand
        Dim cn As OracleConnection = Nothing
        Dim dre As OracleDataReader = Nothing
        Dim cmdsearch As OracleCommand

        Try
            open_wait()
            cn = classmy.open_conn_utama

            tbukti.Text = classmy.GET_KODE_KASOUT(get_kode_stat, cn, ttgl.EditValue)

            sql_search = String.Format("select no_bukti from admlsp.TR_KAS_OUT where no_bukti='{0}'", tbukti.Text.Trim)
            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                tbukti.Text = classmy.GET_KODE_KASOUT(get_kode_stat, cn, ttgl.EditValue)
                'MsgBox("Kode sudah ada", MsgBoxStyle.Information, "Informasi")
                'tbukti.Focus()
                'Exit Sub
            Else
                dre.Close()
            End If


            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            sql = String.Format("insert into admlsp.TR_KAS_OUT (no_bukti,tanggal,kd_kas,kd_stat,keterangan,total,user_add,tgl_add) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}')", tbukti.Text.Trim.ToUpper, tgl, cbjeniskas.EditValue, get_kode_stat, tket.Text.Trim, gridview.Columns("JML").SummaryItem.SummaryValue, userprog, convert_date_to_eng(Date.Now.ToString))
            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_KAS_OUT", "INSERT", "KAS KELUAR")

            manipulate2(cn)

            sqltrans.Commit()

            insert_view()

            close_wait()

            MsgBox("Data telah disimpan... ", MsgBoxStyle.Information, "Informasi")

            addjml = addjml + 1

            'Me.Close()
            kosongkan()

            isi_grid()

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

                    sql2 = String.Format("select no_bukti from admlsp.TR_KAS_OUT2 where no_bukti='{0}' and kd_akun='{1}'", tbukti.Text.Trim, dv1(i)("KD_AKUN").ToString)
                    cmd2 = New OracleCommand(sql2, cn)
                    dread = cmd2.ExecuteReader

                    If dread.Read Then

                        dread.Close()

                        sql = String.Format("update admlsp.TR_KAS_OUT2 set jml={0},deskripsi='{1}' where no_bukti='{2}' and kd_akun='{3}'", dv1(i)("JML").ToString, dv1(i)("DESKRIPSI").ToString, tbukti.Text.Trim, dv1(i)("KD_AKUN").ToString)

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_KAS_OUT2", "UPDATE", "KAS KELUAR")

                    Else

                        dread.Close()

                        sql = String.Format("insert into admlsp.TR_KAS_OUT2 (no_bukti,kd_akun,jml,deskripsi) values('{0}','{1}',{2},'{3}')", tbukti.Text.Trim, dv1(i)("KD_AKUN").ToString, dv1(i)("JML").ToString, dv1(i)("DESKRIPSI").ToString)

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_KAS_OUT2", "INSERT", "KAS KELUAR")

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

        orow("KETERANGAN") = tket.Text.Trim
        orow("KD_KAS") = cbjeniskas.EditValue
        orow("NAMA") = cbjeniskas.Text.Trim
        orow("TOTAL") = gridview.Columns("JML").SummaryItem.SummaryValue

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()


        If ttgl.Text = "" Then
            dv(posi)("TANGGAL") = DBNull.Value
        Else
            dv(posi)("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        dv(posi)("NAMA") = cbjeniskas.Text.Trim
        dv(posi)("KETERANGAN") = tket.Text.Trim
        dv(posi)("KD_KAS") = cbjeniskas.EditValue
        dv(posi)("TOTAL") = gridview.Columns("JML").SummaryItem.SummaryValue


    End Sub

    Private Sub hapus_detail()

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Dim cn As OracleConnection = Nothing
        Dim sql As String = String.Format("delete from admlsp.TR_KAS_OUT2 where no_bukti='{0}' and kd_akun='{1}'", tbukti.Text.Trim, dv1(Me.BindingContext(dv1).Position)("KD_AKUN").ToString)
        Dim cmd As OracleCommand

        Try

            cn = classmy.open_conn_utama
            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_KAS_OUT2", "DELETE", "KAS KELUAR")

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

    Private Sub tr_kasout2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            ttgl.Focus()
        Else
            ttgl.Focus()
        End If
    End Sub

    Private Sub tr_kasout2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            'ttgl.Properties.ReadOnly = False
            cbjeniskas.Properties.ReadOnly = False

            kosongkan()
        Else

            'ttgl.Properties.ReadOnly = True
            cbjeniskas.Properties.ReadOnly = True

            isi_box()
        End If

        isi_grid()

    End Sub

    Private Sub ttgl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        If e.KeyCode = 13 Then
            cbjeniskas.Focus()
        End If
    End Sub

    Private Sub cbjenis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbjeniskas.KeyDown
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
            tr_kas_out.refresh_data()
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

            MsgBox("Kas tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            cbjeniskas.Focus()
            Exit Sub
        End If

        If IsNothing(dv1) Then
            MsgBox("Detail tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            btadd_det.Focus()
            Exit Sub
        End If

        If dv1.Count <= 0 Then

            MsgBox("Detail tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            btadd_det.Focus()
            Exit Sub
        End If


        If statadd.Equals(True) Then
            insert()
        Else
            edit(False)
        End If


    End Sub

    Private Sub btadd_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btadd_det.Click

        Using ts_kasot3 As New tr_kas_out3(False, dv1, 0) With {.StartPosition = FormStartPosition.CenterParent}
            ts_kasot3.ShowDialog(Me)
        End Using

    End Sub

    Private Sub bted_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bted_det.Click

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Using ts_kasot3 As New tr_kas_out3(True, dv1, Me.BindingContext(dv1).Position) With {.StartPosition = FormStartPosition.CenterParent}
            ts_kasot3.ShowDialog(Me)
        End Using

    End Sub

    Private Sub btdel_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btdel_det.Click
        hapus_detail()
    End Sub

End Class