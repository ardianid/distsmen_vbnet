Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class ms_kso2

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

    Private Sub kosongkan()

        tkode.Text = ""
        tnama.Text = ""
        talamat.Text = ""
        ttelp1.Text = ""
        ttelp2.Text = ""
        tkontak.Text = ""

    End Sub

    Private Sub isi_box()

        tkode.Enabled = False
        tkode.Text = dv(posi)("KODE").ToString
        tnama.Text = dv(posi)("NAMA").ToString
        talamat.Text = dv(posi)("ALAMAT").ToString
        ttelp1.Text = dv(posi)("TELP1").ToString
        ttelp2.Text = dv(posi)("TELP2").ToString

        cbstatus.EditValue = dv(posi)("KD_STAT").ToString

        If dv(posi)("AKTIF").ToString = 1 Then
            caktif.Checked = 1
        Else
            caktif.Checked = 0
        End If

    End Sub

    Private Sub edit()

        Dim sql As String = String.Format("update admlsp.ms_kso set nama='{0}',alamat='{1}',telp1='{2}',telp2='{3}',aktif={4},user_edit='{5}',tgl_edit='{6}',kontak='{7}',kd_stat='{8}' " & _
                                          " where kode='{9}'", tnama.Text.Trim, talamat.Text.Trim, ttelp1.Text.Trim, ttelp2.Text.Trim, IIf(caktif.Checked = True, 1, 0), userprog, convert_date_to_eng(Date.Now.ToString), tkontak.Text.Trim, cbstatus.EditValue, tkode.Text.Trim)




        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand

        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)

            cmd.ExecuteNonQuery()

            If classmy.insert_to_temp_user(cn, sql, tkode.Text.Trim, "MS_KSO", "UPDATE", "KSO") Then
                close_wait()
                MsgBox("Kesalahan data Temp User", MsgBoxStyle.Critical, "Informasi")
            Else
                sqltrans.Commit()

                update_view()

                MsgBox("Data telah dirubah..", MsgBoxStyle.Information, "Informasi")
                ms_supir.refresh_data()

                close_wait()

                Me.Close()
            End If

            

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

        Dim sql As String = String.Format("insert into admlsp.ms_kso (kode,nama,alamat,telp1,telp2,aktif,user_add,tgl_add,kontak,kd_stat) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", tkode.Text.Trim.ToUpper, tnama.Text.Trim.ToUpper, talamat.Text.Trim.ToUpper, ttelp1.Text.Trim, ttelp2.Text.Trim, IIf(caktif.Checked = True, 1, 0), userprog, convert_date_to_eng(Date.Now.ToString), tkontak.Text.Trim, cbstatus.EditValue)
        Dim sql_search As String = String.Format("select kode from admlsp.ms_kso where kode='{0}'", tkode.Text.Trim)



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

            If classmy.insert_to_temp_user(cn, sql, tkode.Text.Trim, "MS_KSO", "INSERT", "KSO") Then
                close_wait()
                MsgBox("Kesalahan data Temp User", MsgBoxStyle.Critical, "Informasi")
            Else

                sqltrans.Commit()

                insert_view()

                close_wait()

                MsgBox("Data telah disimpan... ", MsgBoxStyle.Information, "Informasi")

                addjml = addjml + 1

                kosongkan()
                tkode.Focus()

            End If

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
        orow("ALAMAT") = talamat.Text
        orow("AKTIF") = IIf(caktif.Checked = True, 1, 0)
        orow("TELP1") = ttelp1.Text
        orow("TELP2") = ttelp2.Text
        orow("KONTAK") = tkontak.Text
        orow("STATUS") = cbstatus.Text
        orow("KD_STAT") = cbstatus.EditValue

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        dv(posi)("NAMA") = tnama.Text
        dv(posi)("ALAMAT") = talamat.Text
        dv(posi)("AKTIF") = IIf(caktif.Checked = True, 1, 0)
        dv(posi)("TELP1") = ttelp1.Text
        dv(posi)("TELP2") = ttelp2.Text
        dv(posi)("KONTAK") = tkontak.Text
        dv(posi)("STATUS") = cbstatus.Text
        dv(posi)("KD_STAT") = cbstatus.EditValue

    End Sub

    Private Sub ms_kso2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            tkode.Focus()
        Else
            tnama.Focus()
        End If
    End Sub

    Private Sub ms_kso2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            tkode.Enabled = True

            caktif.Enabled = False
            caktif.Checked = 1
        Else

            tkode.Enabled = False

            caktif.Enabled = True
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
            talamat.Focus()
        End If
    End Sub

    Private Sub talamat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles talamat.KeyDown
        If e.KeyCode = 13 Then
            tkontak.Focus()
        End If
    End Sub

    Private Sub tkontak_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkontak.KeyDown
        If e.KeyCode = 13 Then
            cbstatus.Focus()
        End If
    End Sub

    Private Sub status_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbstatus.KeyDown
        If e.KeyCode = 13 Then
            ttelp1.Focus()
        End If
    End Sub


    Private Sub ttelp1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttelp1.KeyDown
        If e.KeyCode = 13 Then
            ttelp2.Focus()
        End If
    End Sub

    Private Sub ttelp2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttelp2.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub


    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            ms_kso.refresh_data()
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

            MsgBox("Area tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

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