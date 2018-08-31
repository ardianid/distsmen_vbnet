Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class ms_sparepart2


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

    End Sub

    Private Sub kosongkan()

        tkode.Text = ""
        tnama.Text = ""
        tsatuan.Text = ""
        thutang.EditValue = 0
        thargajual1.EditValue = 0

    End Sub

    Private Sub isi_box()

        tkode.Enabled = False
        tkode.Text = dv(posi)("KODE").ToString
        tnama.Text = dv(posi)("NAMA").ToString
        tsatuan.Text = dv(posi)("SATUAN").ToString
        thutang.EditValue = dv(posi)("JML").ToString
        thargajual1.EditValue = dv(posi)("HARGA").ToString

    End Sub

    Private Sub edit()

        Dim sql As String = String.Format("update admlsp.ms_sparepart set nama='{0}',satuan='{1}',user_edit='{2}',tgl_edit='{3}',harga={4}" & _
                                          " where kode='{5}'", tnama.Text.Trim, tsatuan.Text.Trim, userprog, convert_date_to_eng(Date.Now.ToString), Replace(thargajual1.EditValue, ",", "."), tkode.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tkode.Text.Trim, "MS_SPAREPART", "UPDATE", "DATA SPAREPART")

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

        Dim sql As String = String.Format("insert into admlsp.ms_sparepart (kode,nama,satuan,user_add,tgl_add,harga) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}',{5})", tkode.Text.Trim.ToUpper, tnama.Text.Trim.ToUpper, tsatuan.Text.Trim, userprog, convert_date_to_eng(Date.Now.ToString), Replace(thargajual1.EditValue, ",", "."))
        Dim sql_search As String = String.Format("select kode from admlsp.ms_sparepart where kode='{0}'", tkode.Text.Trim)



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

            ins_to_temp_user(cn, sql, tkode.Text.Trim, "MS_SPAREPART", "INSERT", "DATA SPAREPART")

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
        orow("SATUAN") = tsatuan.Text
        orow("JML") = 0
        orow("HARGA") = thargajual1.EditValue

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        dv(posi)("NAMA") = tnama.Text
        dv(posi)("SATUAN") = tsatuan.Text
        dv(posi)("HARGA") = thargajual1.EditValue

    End Sub

    Private Sub ms_sparepart2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            tkode.Focus()
        Else
            tnama.Focus()
        End If
    End Sub

    Private Sub ms_parepart2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            tsatuan.Focus()
        End If
    End Sub

    Private Sub tsatuan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsatuan.KeyDown
        If e.KeyCode = 13 Then
            thargajual1.Focus()
        End If
    End Sub

    Private Sub thargajual1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles thargajual1.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            ms_sparepart.refresh_data()
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


        If tsatuan.Text = "" Then

            MsgBox("Satuan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tsatuan.Focus()
            Exit Sub

        End If

        If thargajual1.EditValue = 0 Then

            MsgBox("Harga tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            thargajual1.Focus()
            Exit Sub

        End If

        If statadd.Equals(True) Then
            insert()
        Else
            edit()
        End If


    End Sub

End Class