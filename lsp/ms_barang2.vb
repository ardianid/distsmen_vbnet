Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class ms_barang2

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

        tkode.Text = ""
        tnama.Text = ""
        tvolum.EditValue = 0
        tsatuan.Text = ""
        cbunit.Text = ""
        thargajual1.EditValue = 0
        thargajual2.EditValue = 0
        thargajual3.EditValue = 0
        tinsentif.EditValue = 0

        dv1 = New DataView
        dv1 = Nothing

        grid1.DataSource = Nothing

    End Sub

    Private Sub isi_combo()

        Const sql = "SELECT KD_PRC,NAMA FROM ADMLSP.MS_PRINCIPAL WHERE AKTIF=1 ORDER BY NAMA ASC"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv = dvm.CreateDataView(ds.Tables(0))

            cbprinc.Properties.DataSource = dv


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
        tkode.Text = dv(posi)("KODE").ToString
        tnama.Text = dv(posi)("NAMA").ToString
        cbprinc.EditValue = dv(posi)("KD_PRC").ToString
        tvolum.Text = dv(posi)("VOLUME").ToString
        tsatuan.Text = dv(posi)("SATUAN").ToString

        cbunit.Text = dv(posi)("UNIT").ToString

        thargajual1.Text = dv(posi)("HARGA1").ToString
        thargajual2.Text = dv(posi)("HARGA2").ToString
        thargajual3.Text = dv(posi)("HARGA3").ToString

        tinsentif.Text = dv(posi)("INSENTIF").ToString

        If dv(posi)("AKTIF").ToString = 1 Then
            caktif.Checked = 1
        Else
            caktif.Checked = 0
        End If

    End Sub

    Private Sub isi_grid()

        Dim ds As DataSet
        Dim dvmanager As Data.DataViewManager
        Dim cn As OracleConnection = Nothing


        Dim sql As String = String.Format("select a.KD_KAB,b.NAMA,a.HARGA from admlsp.ms_barang2 a inner join admlsp.ms_kab b on a.KD_KAB=b.KODE where a.KD_BARANG='{0}' ", tkode.Text.Trim)

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

    Private Sub edit()

        Dim sql As String = String.Format("update admlsp.ms_barang set nama='{0}',kd_prc='{1}',satuan='{2}',volume={3},unit='{4}',harga1={5},harga2={6},harga3={7},aktif={8},user_edit='{9}',tgl_edit='{10}',insentif={11}" & _
                                          " where kode='{12}'", tnama.Text.Trim, cbprinc.EditValue, tsatuan.Text, tvolum.EditValue, cbunit.Text.Trim, thargajual1.EditValue, thargajual2.EditValue, thargajual3.EditValue, IIf(caktif.Checked = True, 1, 0), userprog, convert_date_to_eng(Date.Now.ToString), tinsentif.EditValue, tkode.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand

        

        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)

            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tkode.Text.Trim, "MS_BARANG", "UPDATE", "BARANG")

            manipulate2(cn)

            sqltrans.Commit()

            update_view()

            MsgBox("Data telah dirubah..", MsgBoxStyle.Information, "Informasi")
            'ms_supir.refresh_data()

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

        Dim sql As String = String.Format("insert into admlsp.ms_barang (kode,nama,kd_prc,satuan,volume,unit,harga1,harga2,harga3,aktif,user_add,tgl_add,insentif) values" & _
                                          "('{0}','{1}','{2}','{3}',{4},'{5}',{6},{7},{8},'{9}','{10}','{11}',{12})", tkode.Text.Trim.ToUpper, tnama.Text.Trim.ToUpper, cbprinc.EditValue, tsatuan.Text, tvolum.EditValue, cbunit.Text.Trim, thargajual1.EditValue, thargajual2.EditValue, thargajual3.EditValue, IIf(caktif.Checked = True, 1, 0), userprog, convert_date_to_eng(Date.Now.ToString), tinsentif.EditValue)
        Dim sql_search As String = String.Format("select kode from admlsp.ms_barang where kode='{0}'", tkode.Text.Trim)



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

           
                manipulate2(cn)

                sqltrans.Commit()

                insert_view()

                close_wait()

                MsgBox("Data telah disimpan... ", MsgBoxStyle.Information, "Informasi")

                addjml = addjml + 1

                kosongkan()
                tkode.Focus()

            

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

                    sql2 = String.Format("select kd_barang from admlsp.MS_BARANG2 where kd_barang='{0}' and kd_kab='{1}'", tkode.Text.Trim, dv1(i)("KD_KAB").ToString)
                    cmd2 = New OracleCommand(sql2, cn)
                    dread = cmd2.ExecuteReader

                    If dread.Read Then

                        dread.Close()

                        sql = String.Format("update admlsp.MS_BARANG2 set HARGA={0} where kd_barang='{1}' and kd_kab='{2}'", Replace(dv1(i)("HARGA").ToString, ",", "."), tkode.Text.Trim, dv1(i)("KD_KAB").ToString)

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tkode.Text.Trim, "MS_BARANG2", "UPDATE", "BARANG")

                    Else

                        dread.Close()

                        sql = String.Format("insert into admlsp.MS_BARANG2 (kd_barang,kd_kab,harga) values('{0}','{1}',{2})", tkode.Text.Trim, dv1(i)("KD_KAB").ToString, Replace(dv1(i)("HARGA").ToString, ",", "."))

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tkode.Text.Trim, "MS_BARANG2", "INSERT", "BARANG")

                    End If

                Next

            End If

        End If


    End Sub

    Private Sub insert_view()

        Dim orow As DataRow

        orow = dv.Table.NewRow()

        orow("KODE") = tkode.Text
        orow("NAMA") = tnama.Text
        orow("SUPPLIER") = cbprinc.Text
        orow("KD_PRC") = cbprinc.EditValue
        orow("AKTIF") = IIf(caktif.Checked = True, 1, 0)
        orow("SATUAN") = tsatuan.Text
        orow("VOLUME") = tvolum.EditValue
        orow("UNIT") = cbunit.Text.Trim
        orow("HARGA1") = thargajual1.EditValue
        orow("HARGA2") = thargajual2.EditValue
        orow("HARGA3") = thargajual3.EditValue
        orow("INSENTIF") = tinsentif.EditValue

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        dv(posi)("NAMA") = tnama.Text
        dv(posi)("SUPPLIER") = cbprinc.Text
        dv(posi)("KD_PRC") = cbprinc.EditValue
        dv(posi)("AKTIF") = IIf(caktif.Checked = True, 1, 0)
        dv(posi)("SATUAN") = tsatuan.Text
        dv(posi)("VOLUME") = tvolum.EditValue
        dv(posi)("UNIT") = cbunit.Text.Trim
        dv(posi)("HARGA1") = thargajual1.EditValue
        dv(posi)("HARGA2") = thargajual2.EditValue
        dv(posi)("HARGA3") = thargajual3.EditValue
        dv(posi)("INSENTIF") = tinsentif.EditValue

    End Sub

    Private Sub hapus_detail()

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Dim cn As OracleConnection = Nothing
        Dim sql As String = String.Format("delete from admlsp.MS_BARANG2 where kd_barang='{0}' and kd_kab='{1}'", tkode.Text.Trim, dv1(Me.BindingContext(dv1).Position)("KD_KAB").ToString)
        Dim cmd As OracleCommand

        Try

            cn = classmy.open_conn_utama
            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tkode.Text.Trim, "MS_BARANG2", "DELETE", "BARANG")

            dv1(Me.BindingContext(dv1).Position).Delete()

            sqltrans.Commit()

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
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

    End Sub

    Private Sub ms_barang2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            tkode.Focus()
        Else
            tnama.Focus()
        End If
    End Sub

    Private Sub ms_barang2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            tkode.Enabled = True

            caktif.Enabled = False
            caktif.Checked = 1

            kosongkan()

            tvolum.EditValue = 1

        Else

            tkode.Enabled = False

            caktif.Enabled = True
            isi_box()
        End If

        isi_grid()

    End Sub

    Private Sub tkode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkode.KeyDown
        If e.KeyCode = 13 Then
            tnama.Focus()
        End If
    End Sub

    Private Sub tnama_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnama.KeyDown
        If e.KeyCode = 13 Then
            cbprinc.Focus()
        End If
    End Sub

    Private Sub cbprinc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbprinc.KeyDown
        If e.KeyCode = 13 Then
            tsatuan.Focus()
        End If
    End Sub

    Private Sub tsatuan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsatuan.KeyDown
        If e.KeyCode = 13 Then
            cbunit.Focus()
        End If
    End Sub

    Private Sub tvolum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tvolum.KeyDown
        If e.KeyCode = 13 Then
            tsatuan.Focus()
        End If
    End Sub

    Private Sub cbunit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbunit.KeyDown
        If e.KeyCode = 13 Then
            tinsentif.Focus()
        End If
    End Sub

    Private Sub tinsentif_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tinsentif.KeyDown
        If e.KeyCode = 13 Then
            thargajual1.Focus()
        End If
    End Sub

    Private Sub tharga1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles thargajual1.KeyDown
        If e.KeyCode = 13 Then
            thargajual2.Focus()
        End If
    End Sub

    Private Sub tharga2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles thargajual2.KeyDown
        If e.KeyCode = 13 Then
            thargajual3.Focus()
        End If
    End Sub

    Private Sub tharga3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles thargajual3.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            ms_barang.refresh_data()
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


        If cbprinc.Text = "" Then

            MsgBox("Principal tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            cbprinc.Focus()
            Exit Sub

        End If

        If tvolum.EditValue = 0 Then

            MsgBox("Volume tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tvolum.Focus()
            Exit Sub
        End If

        If tsatuan.Text = "" Then

            MsgBox("Satuan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tsatuan.Focus()
            Exit Sub
        End If

        If cbunit.Text.Length = 0 Then

            MsgBox("Unit tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            cbunit.Focus()
            Exit Sub
        End If

        If thargajual1.EditValue = 0 Then

            MsgBox("Harga jual 1 tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            thargajual1.Focus()
            Exit Sub
        End If

        If statadd.Equals(True) Then
            insert()
        Else
            edit()
        End If


    End Sub

    Private Sub btadd_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btadd_det.Click

        Using ts_kasot3 As New ms_barang3(False, dv1, 0) With {.StartPosition = FormStartPosition.CenterParent}
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

        Using ts_kasot3 As New ms_barang3(True, dv1, Me.BindingContext(dv1).Position) With {.StartPosition = FormStartPosition.CenterParent}
            ts_kasot3.ShowDialog(Me)
        End Using

    End Sub

    Private Sub btdel_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btdel_det.Click
        hapus_detail()
    End Sub

End Class