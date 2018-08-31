Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class ms_kas2

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

        tkode.Text = ""
        tnama.Text = ""
        thutang.EditValue = 0

    End Sub

    Private Sub isi_combo()

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

            cbstatus.Properties.DataSource = dv


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

        cbstatus.EditValue = dv(posi)("KD_STAT").ToString

        If Not IsNothing(dv(posi)("stat_ujlan").ToString) Then

            If dv(posi)("stat_ujlan").ToString = 1 Then
                ck_stat.Checked = True
            Else
                ck_stat.Checked = False
            End If

        Else
            ck_stat.Checked = False
        End If

        thutang.Text = FormatNumber(dv(posi)("JML").ToString, 2, TriState.UseDefault, TriState.False, TriState.True)

    End Sub

    Private Sub edit()

        Dim sql As String = String.Format("update admlsp.ms_kas set nama='{0}',kd_stat='{1}',user_edit='{2}',tgl_edit='{3}',stat_ujlan={4}" & _
                                          " where kode='{5}'", tnama.Text.Trim, cbstatus.EditValue, userprog, convert_date_to_eng(Date.Now.ToString), IIf(ck_stat.Checked = True, 1, 0), tkode.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try


            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)

            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tkode.Text.Trim, "MS_KAS", "UPDATE", "KAS")

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

        Dim sql As String = String.Format("insert into admlsp.ms_kas (kode,nama,kd_stat,user_add,tgl_add,stat_ujlan) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}',{5})", tkode.Text.Trim.ToUpper, tnama.Text.Trim.ToUpper, cbstatus.EditValue, userprog, convert_date_to_eng(Date.Now.ToString), IIf(ck_stat.Checked = True, 1, 0))
        Dim sql_search As String = String.Format("select kode from admlsp.ms_kas where kode='{0}'", tkode.Text.Trim)



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

            ins_to_temp_user(cn, sql, tkode.Text.Trim, "MS_KAS", "INSERT", "KAS")

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

    Private Sub insert_view()

        Dim orow As DataRow

        orow = dv.Table.NewRow()

        orow("KODE") = tkode.Text
        orow("NAMA") = tnama.Text
        orow("KD_STAT") = cbstatus.EditValue
        orow("JML") = 0
        orow("STAT_UJLAN") = IIf(ck_stat.Checked = True, 1, 0)

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        dv(posi)("NAMA") = tnama.Text
        dv(posi)("KD_STAT") = cbstatus.EditValue
        dv(posi)("STAT_UJLAN") = IIf(ck_stat.Checked = True, 1, 0)

    End Sub

    Private Sub ms_kas2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            tkode.Focus()
        Else
            tnama.Focus()
        End If
    End Sub

    Private Sub ms_supir2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            tkode.Enabled = True

            kosongkan()
        Else

            tkode.Enabled = False

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
            cbstatus.Focus()
        End If
    End Sub

    Private Sub cbstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbstatus.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            ms_kas.refresh_data()
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

        If statadd.Equals(True) Then
            insert()
        Else
            edit()
        End If


    End Sub

    Private Sub ck_stat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ck_stat.CheckedChanged

        If ck_stat.Checked = True Then
            ck_stat.Text = "&Ya"
        Else
            ck_stat.Text = "&Tidak"
        End If

    End Sub

End Class