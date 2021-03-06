﻿Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_deposit_princ2
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

        Const sql = "select kd_prc,nama,alamat from admlsp.ms_principal order by nama asc"

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

        tbukti.Enabled = False
        tbukti.Text = dv(posi)("no_bukti").ToString
        ttgl.Text = convert_date_to_ind(dv(posi)("tanggal").ToString)
        cbprinc.EditValue = dv(posi)("kd_prc").ToString
        tdeposit.EditValue = dv(posi)("jml_deposit").ToString

    End Sub

    Private Sub edit()

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim sql As String = String.Format("update admlsp.tr_dep_principal set tanggal='{0}',kd_prc='{1}',jml_deposit={2},user_edit='{3}',tgl_edit='{4}'" & _
                                          " where no_bukti='{5}'", tgl, cbprinc.EditValue, tdeposit.EditValue, userprog, convert_date_to_eng(Date.Now.ToString), tbukti.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)

            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_DEP_PRINCIPAL", "UPDATE", "DEPOSIT PRINCIPAL")

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

            tbukti.Text = classmy.GET_KODE_DEPPRINC(get_kode_stat, cn, ttgl.EditValue)

            sql_search = String.Format("select no_bukti from admlsp.tr_dep_principal where no_bukti='{0}'", tbukti.Text.Trim)
            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                tbukti.Text = classmy.GET_KODE_DEPPRINC(get_kode_stat, cn, ttgl.EditValue)
                'MsgBox("Kode sudah ada", MsgBoxStyle.Information, "Informasi")
                'tbukti.Focus()
                'Exit Sub
            Else
                dre.Close()
            End If

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            sql = String.Format("insert into admlsp.tr_dep_principal (no_bukti,tanggal,kd_prc,jml_deposit,user_add,tgl_add,kd_stat) values" & _
                                          "('{0}','{1}','{2}',{3},'{4}','{5}','{6}')", tbukti.Text.Trim.ToUpper, tgl, cbprinc.EditValue, tdeposit.EditValue, userprog, convert_date_to_eng(Date.Now.ToString), get_kode_stat)

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_DEP_PRINCIPAL", "INSERT", "DEPOSIT PRINCIPAL")

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

        orow("PRINCIPAL") = cbprinc.Text.Trim
        orow("KD_PRC") = cbprinc.EditValue
        orow("JML_DEPOSIT") = tdeposit.EditValue

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()


        If ttgl.Text = "" Then
            dv(posi)("TANGGAL") = DBNull.Value
        Else
            dv(posi)("TANGGAL") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        dv(posi)("PRINCIPAL") = cbprinc.Text.Trim
        dv(posi)("KD_PRC") = cbprinc.EditValue
        dv(posi)("JML_DEPOSIT") = tdeposit.EditValue
       
    End Sub

    Private Sub ms_dep2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            ttgl.Focus()
        Else
            ttgl.Focus()
        End If
    End Sub

    Private Sub ms_toko2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            ' tbukti.Enabled = True

            kosongkan()
        Else

            ' tbukti.Enabled = False

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
            cbprinc.Focus()
        End If
    End Sub

    Private Sub princ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbprinc.KeyDown
        If e.KeyCode = 13 Then
            tdeposit.Focus()
        End If
    End Sub

    Private Sub tdeposit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdeposit.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            tr_deposit_princ.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tbukti.Text = "" Then

            MsgBox("No bukti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tbukti.Focus()
            Exit Sub
        End If

        If cbprinc.Text = "" Then

            MsgBox("Principal tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            cbprinc.Focus()
            Exit Sub
        End If


        If tdeposit.EditValue = 0 Then

            MsgBox("Jml deposit tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
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