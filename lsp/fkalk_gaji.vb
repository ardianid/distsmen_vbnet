Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fkalk_gaji

    Private dv1 As DataView

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

    Private Sub manipulate()

        Dim cn As OracleConnection = Nothing
       
        Dim bulan As String = String.Empty

        If cbbulan.SelectedIndex <= 8 Then
            bulan = String.Format("0{0}", cbbulan.SelectedIndex + 1)
        Else
            bulan = cbbulan.SelectedIndex + 1
        End If

        Dim sqlcari As String = String.Format("select sum(a.pend_supir) as jml,a.KD_SUPIR from admlsp.V_KALK_GAJI a " & _
            "where a.bulan='{0}' and a.tahun='{1}' and a.kd_stat='{2}' " & _
            "group by a.KD_SUPIR " & _
            "order by a.KD_SUPIR asc", bulan, ttahun.Text.Trim, cbstatus.EditValue)
        Dim dscari As DataSet = Nothing
        Dim dtcari As DataTable = Nothing

        Dim sqlcaritemp As String = String.Empty
        Dim cmdtemp As OracleCommand = Nothing
        Dim drtemp As OracleDataReader = Nothing

        Dim sql As String = String.Empty
        Dim cmd As OracleCommand = Nothing

        Dim sqldel As String = String.Format("update admlsp.tm_gaji_supir a set a.jml_semen=0,a.jml_lain=0,a.pot_kasbon=0,a.kd_kas='' where a.BULAN='{0}' and a.TAHUN='{1}' AND a.KD_STAT='{2}'", bulan, ttahun.Text.Trim, cbstatus.EditValue)
        Dim cmddel As OracleCommand = Nothing

        Try

            open_wait()

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmddel = New OracleCommand(sqldel, cn)
            cmddel.ExecuteNonQuery()

            Dim BLTH As String = String.Format("{0}-{1}", bulan, ttahun.Text.Trim)
            Dim BLTH_DET As String = String.Empty

            ins_to_temp_user(cn, sqldel, BLTH, "TM_GAJI_SUPIR", "UPDATE", "KALKULASI GAJI")

            dscari = New DataSet
            dscari = classmy.GetDataSet(sqlcari, cn)
            dtcari = dscari.Tables(0)

            Dim i As Integer = 0
            Dim i_tot As Integer = dtcari.Rows.Count
            Dim jmlgaji As Double = 0

            If i_tot > 0 Then

                For i = 0 To i_tot - 1

                    jmlgaji = CDbl(dtcari.Rows(i)(0).ToString)

                    sqlcaritemp = String.Format("select id from admlsp.tm_gaji_supir a where a.BULAN='{0}' and a.TAHUN='{1}' and a.KD_SUPIR='{2}' and a.KD_STAT='{3}'", bulan, ttahun.Text.Trim, dtcari.Rows(i)(1).ToString, cbstatus.EditValue)
                    cmdtemp = New OracleCommand(sqlcaritemp, cn)
                    drtemp = cmdtemp.ExecuteReader

                    If drtemp.Read Then

                        sql = String.Format("update admlsp.tm_gaji_supir set jml_semen={0},user_edit='{1}',tgl_edit='{2}' where BULAN='{3}' and TAHUN='{4}' and KD_SUPIR='{5}' and KD_STAT='{6}'", Replace(jmlgaji, ",", "."), userprog, convert_date_to_eng(Date.Now), bulan, ttahun.Text.Trim, dtcari.Rows(i)(1).ToString, cbstatus.EditValue)
                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        BLTH_DET = String.Format("{0}.{1}", BLTH, dtcari.Rows(i)(1).ToString)

                        ins_to_temp_user(cn, sql, BLTH_DET, "TM_GAJI_SUPIR", "UPDATE", "KALKULASI GAJI")

                        drtemp.Close()

                    Else

                        sql = String.Format("insert into admlsp.tm_gaji_supir (kd_supir,bulan,tahun,jml_semen,user_add,tgl_add,kd_stat) values('{0}','{1}','{2}',{3},'{4}','{5}','{6}')", dtcari.Rows(i)(1).ToString, bulan, ttahun.Text.Trim, Replace(jmlgaji, ",", "."), userprog, convert_date_to_eng(Date.Now), cbstatus.EditValue)
                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        BLTH_DET = String.Format("{0}.{1}", BLTH, dtcari.Rows(i)(1).ToString)

                        ins_to_temp_user(cn, sql, BLTH_DET, "TM_GAJI_SUPIR", "INSERT", "KALKULASI GAJI")

                        drtemp.Close()

                    End If


                Next

            End If

            manipulate_angkut(cn, BLTH)

            sqltrans.Commit()


            'MsgBox("Data selesai diproses....", MsgBoxStyle.Information, "Informasi")

            isi_grid(cn)
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

    Private Sub isi_combo2()

        Dim sql As String

        If get_stat_pusat() = 1 Then
            sql = "SELECT A.KODE,A.NAMA,B.STATUS FROM ADMLSP.MS_KAS A INNER JOIN ADMLSP.MS_STAT B ON A.KD_STAT=B.KODE"
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

    Private Sub manipulate_angkut(ByVal cn As OracleConnection, ByVal blth As String)


        Dim bulan As String = String.Empty

        If cbbulan.SelectedIndex <= 8 Then
            bulan = String.Format("0{0}", cbbulan.SelectedIndex + 1)
        Else
            bulan = cbbulan.SelectedIndex + 1
        End If

        Dim sqlcari As String = String.Format("select sum((a.TOT_OKS_ANGKUT - a.UANG_JLN) * 0.25),a.KD_SUPIR from admlsp.tr_angkutan a " & _
            "where extract (month from a.tanggal)='{0}' and extract(year from a.tanggal)='{1}' and a.kd_stat='{2}' " & _
            "group by a.KD_SUPIR " & _
            "order by a.KD_SUPIR asc", bulan, ttahun.Text.Trim, cbstatus.EditValue)

        Dim dscari As DataSet = Nothing
        Dim dtcari As DataTable = Nothing

        Dim sqlcaritemp As String = String.Empty
        Dim cmdtemp As OracleCommand = Nothing
        Dim drtemp As OracleDataReader = Nothing

        Dim BLTH_DET As String = String.Empty

        Dim sql As String = String.Empty
        Dim cmd As OracleCommand = Nothing


        dscari = New DataSet
        dscari = classmy.GetDataSet(sqlcari, cn)
        dtcari = dscari.Tables(0)

        Dim i As Integer = 0
        Dim i_tot As Integer = dtcari.Rows.Count
        Dim jmlgaji As Double = 0

        If i_tot > 0 Then

            For i = 0 To i_tot - 1

                jmlgaji = CDbl(dtcari.Rows(i)(0).ToString)

                sqlcaritemp = String.Format("select id from admlsp.tm_gaji_supir a where a.BULAN='{0}' and a.TAHUN='{1}' and a.KD_SUPIR='{2}' and a.KD_STAT='{3}'", bulan, ttahun.Text.Trim, dtcari.Rows(i)(1).ToString, cbstatus.EditValue)
                cmdtemp = New OracleCommand(sqlcaritemp, cn)
                drtemp = cmdtemp.ExecuteReader

                If drtemp.Read Then

                    sql = String.Format("update admlsp.tm_gaji_supir set jml_lain={0},user_edit='{1}',tgl_edit='{2}' where BULAN='{3}' and TAHUN='{4}' and KD_SUPIR='{5}' and KD_STAT='{6}'", Replace(jmlgaji, ",", "."), userprog, convert_date_to_eng(Date.Now), bulan, ttahun.Text.Trim, dtcari.Rows(i)(1).ToString, cbstatus.EditValue)
                    cmd = New OracleCommand(sql, cn)
                    cmd.ExecuteNonQuery()

                    BLTH_DET = String.Format("{0}.{1}", blth, dtcari.Rows(i)(1).ToString)

                    ins_to_temp_user(cn, sql, BLTH_DET, "TM_GAJI_SUPIR", "UPDATE", "KALKULASI GAJI")

                    drtemp.Close()

                Else

                    sql = String.Format("insert into admlsp.tm_gaji_supir (kd_supir,bulan,tahun,user_add,tgl_add,jml_lain,kd_stat) values('{0}','{1}','{2}','{3}','{4}',{5},'{6}')", dtcari.Rows(i)(1).ToString, bulan, ttahun.Text.Trim, userprog, convert_date_to_eng(Date.Now), Replace(jmlgaji, ",", "."), cbstatus.EditValue)
                    cmd = New OracleCommand(sql, cn)
                    cmd.ExecuteNonQuery()

                    BLTH_DET = String.Format("{0}.{1}", blth, dtcari.Rows(i)(1).ToString)

                    ins_to_temp_user(cn, sql, BLTH_DET, "TM_GAJI_SUPIR", "INSERT", "KALKULASI GAJI")

                    drtemp.Close()

                End If


            Next

        End If

    End Sub

    Private Sub manipulate_kasbon()

        Dim cn As OracleConnection = Nothing
        Dim mycomd As OracleCommand = Nothing

        Dim bulan As String = String.Empty
        If cbbulan.SelectedIndex <= 8 Then
            bulan = String.Format("0{0}", cbbulan.SelectedIndex + 1)
        Else
            bulan = cbbulan.SelectedIndex + 1
        End If

        Dim BLTH As String = String.Format("{0}-{1}", bulan, ttahun.Text.Trim)
        Dim BLTH_DET As String = String.Empty

        Dim sql As String = String.Empty

        Try

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            Dim i As Integer = 0
            For i = 0 To dv1.Count - 1

                'If Not (CDbl(dv1(i)("POT_KASBON").ToString) = 0) Or Not (dv1(i)("POT_KASBON").ToString.Length = 0) Then

                sql = String.Format("update admlsp.tm_gaji_supir a set a.POT_KASBON={0},a.KETERANGAN='{1}',a.kd_kas='{2}' where a.ID={3}", CDbl(dv1(i)("POT_KASBON").ToString), dv1(i)("KETERANGAN").ToString, cbjeniskas.EditValue, dv1(i)("ID").ToString)

                mycomd = New OracleCommand(sql, cn)
                mycomd.ExecuteNonQuery()

                BLTH_DET = String.Format("{0}/{1}", BLTH, dv1(i)("ID").ToString)

                ins_to_temp_user(cn, sql, BLTH_DET, "TM_GAJI_SUPIR", "UPDATE", "KALKULASI GAJI")

                'End If

            Next

            sqltrans.Commit()
            MsgBox("Data disimpan...", MsgBoxStyle.Information, "Informasi")

            dv1 = New DataView
            dv1 = Nothing

            grid1.DataSource = Nothing


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

    Private Sub isi_grid(ByVal cn As OracleConnection)

        Dim ds As DataSet
        Dim dvmanager As Data.DataViewManager
        '   Dim cn As OracleConnection = Nothing

        Dim bulan As String = String.Empty

        If cbbulan.SelectedIndex <= 8 Then
            bulan = String.Format("0{0}", cbbulan.SelectedIndex + 1)
        Else
            bulan = cbbulan.SelectedIndex + 1
        End If

        Dim sql As String = String.Format("select rownum as no,a.ID,a.KD_SUPIR,b.NAMA,a.JML_SEMEN,a.JML_LAIN,(a.JML_SEMEN + a.JML_LAIN) as TOT_GAJI,a.POT_KASBON,a.POT_LAIN,a.KETERANGAN " & _
            "from admlsp.tm_gaji_supir a inner join admlsp.ms_supir b on a.KD_SUPIR=b.KD_SUPIR " & _
            "where a.BULAN='{0}' and a.TAHUN='{1}' and a.KD_STAT='{2}' order by b.NAMA asc", bulan, ttahun.Text.Trim, cbstatus.EditValue)

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


            'If Not cn Is Nothing Then
            '    If cn.State = ConnectionState.Open Then
            '        cn.Close()
            '    End If
            'End If

        End Try

    End Sub

    Private Sub fkalk_gaji_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        cbbulan.Focus()
    End Sub

    Private Sub fkalk_gaji_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ttahun.Text = Year(Now)

        cbbulan.SelectedIndex = 0
        isi_combo()
        isi_combo2()

        dv1 = New DataView
        dv1 = Nothing

        grid1.DataSource = Nothing

    End Sub

    Private Sub cbbulan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbulan.KeyDown
        If e.KeyCode = 13 Then
            cbstatus.Focus()
        End If
    End Sub

    Private Sub cstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbstatus.KeyDown
        If e.KeyCode = 13 Then
            cbjeniskas.Focus()
        End If
    End Sub

    Private Sub cbjeniskas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbjeniskas.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub


    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If cbbulan.Text.Trim.Length = 0 Then
            MsgBox("Isi dulu bulan yang akan diproses", MsgBoxStyle.Information, "Informasi")
            cbbulan.Focus()
            Exit Sub
        End If

        If cbstatus.Text.Trim.Length = 0 Then
            MsgBox("Isi dulu area yang akan diproses", MsgBoxStyle.Information, "Informasi")
            cbstatus.Focus()
            Exit Sub
        End If


        ' If MsgBox("Yakin data yang akan diproses sudah benar ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Konfirmasi") = MsgBoxResult.Yes Then
        manipulate()
        ' End If


    End Sub

    Private Sub bted_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bted_det.Click

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Using frmedit As New fkalk_gaji2(dv1, Me.BindingContext(dv1).Position) With {.StartPosition = FormStartPosition.CenterScreen}
            frmedit.ShowDialog()
        End Using


    End Sub

    Private Sub btkasbon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkasbon.Click

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count = 0 Then
            Exit Sub
        End If

        If cbjeniskas.Text.Trim.Length <= 0 Then
            MsgBox("Kas tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            cbjeniskas.Focus()
            Exit Sub
        End If

        If MsgBox("Yakin semua data yang akan disimpan sudah benar ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Konfirmasi") = MsgBoxResult.No Then
            Exit Sub
        End If

        manipulate_kasbon()

    End Sub
End Class