Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client
Imports System.Text.RegularExpressions

Public Class ms_kec2

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

    End Sub

    Private Sub isi_combo()

        Const sql = "select B.NAMA AS PROPINSI,A.KODE,A.NAMA FROM ADMLSP.MS_KAB A INNER JOIN ADMLSP.MS_PROP B ON A.KODE_PROP=B.KODE ORDER BY B.NAMA,A.NAMA ASC"

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

        cbstatus.EditValue = dv(posi)("KD_KAB").ToString

    End Sub

    Private Sub edit()

        Dim sql As String = String.Format("update admlsp.ms_kec set nama='{0}',kode_kab='{1}',user_edit='{2}',tgl_edit='{3}'" & _
                                          " where kode='{4}'", tnama.Text.Trim, cbstatus.EditValue, userprog, convert_date_to_eng(Date.Now.ToString), tkode.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tkode.Text.Trim, "MS_KEC", "UPDATE", "KECAMATAN")

            sqltrans.Commit()

            update_view()

            MsgBox("Data telah dirubah..", MsgBoxStyle.Information, "Informasi")
            ms_supir.refresh_data()

            Me.Close()

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

        Dim sql As String = String.Format("insert into admlsp.ms_kec (kode,nama,kode_kab,user_add,tgl_add) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}')", tkode.Text.Trim.ToUpper, tnama.Text.Trim.ToUpper, cbstatus.EditValue.ToString, userprog, convert_date_to_eng(Date.Now.ToString))
        Dim sql_search As String = String.Format("select kode from admlsp.ms_kec where kode='{0}'", tkode.Text.Trim)


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

            ins_to_temp_user(cn, sql, tkode.Text.Trim, "MS_KEC", "INSERT", "KECAMATAN")

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

        orow("KODe") = tkode.Text
        orow("NAMA") = tnama.Text
        orow("KABUPATEN") = cbstatus.Text
        orow("KD_KAB") = cbstatus.EditValue

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        dv(posi)("NAMA") = tnama.Text
        dv(posi)("KABUPATEN") = cbstatus.Text
        dv(posi)("KD_KAB") = cbstatus.EditValue

    End Sub

    Private Sub ms_sales2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            tkode.Focus()
        Else
            tnama.Focus()
        End If
    End Sub

    Private Sub ms_sales2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            tkode.Enabled = True
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
            ms_kec.refresh_data()
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


        If cbstatus.Text = "" Then

            MsgBox("Propinsi tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            cbstatus.Focus()
            Exit Sub

        End If

        If statadd.Equals(True) Then
            insert()
        Else
            edit()
        End If


    End Sub

End Class