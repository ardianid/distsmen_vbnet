Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client
Imports System.Text.RegularExpressions

Public Class ms_supir2

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
        talamat.Text = ""
        ttelp1.Text = ""
        ttelp2.Text = ""
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
        tkode.Text = dv(posi)("KD_SUPIR").ToString
        tnama.Text = dv(posi)("NAMA").ToString
        talamat.Text = dv(posi)("ALAMAT").ToString
        ttelp1.Text = dv(posi)("TELP").ToString
        ttelp2.Text = dv(posi)("TELP2").ToString

        If dv(posi)("TGL_MASUK").ToString = "" Then
            ttgl.Text = String.Empty
        Else
            ttgl.EditValue = FormatDateTime(dv(posi)("TGL_MASUK").ToString, DateFormat.ShortDate)
        End If

        'ttgl.Text = IIf(dv(posi)("TGL_MASUK").ToString = String.Empty, Date.Now, FormatDateTime(dv(posi)("TGL_MASUK").ToString, DateFormat.ShortDate))
        thutang.Text = FormatNumber(dv(posi)("JML_KASBON").ToString, 2, TriState.UseDefault, TriState.False, TriState.True)

        If dv(posi)("AKTIF").ToString = 1 Then
            caktif.Checked = 1
        Else
            caktif.Checked = 0
        End If

        cbstatus.EditValue = dv(posi)("KODE").ToString

    End Sub

    Private Sub edit()

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim sql As String = String.Format("update admlsp.ms_supir set nama='{0}',alamat='{1}',telp='{2}',telp2='{3}',tgl_masuk='{4}',kd_stat='{5}',aktif={6},user_edit='{7}',tgl_edit='{8}'" & _
                                          " where kd_supir='{9}'", tnama.Text.Trim, talamat.Text.Trim, ttelp1.Text.Trim, ttelp2.Text.Trim, tgl, cbstatus.EditValue, IIf(caktif.Checked = True, 1, 0), userprog, convert_date_to_eng(Date.Now.ToString), tkode.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)

            cmd.ExecuteNonQuery()

            If classmy.insert_to_temp_user(cn, sql, tkode.Text.Trim, "MS_SUPIR", "UPDATE", "SUPIR") = False Then
                Close()
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

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim sql As String = String.Format("insert into admlsp.ms_supir (kd_supir,nama,alamat,telp,telp2,tgl_masuk,aktif,kd_stat,user_add,tgl_add) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}','{9}')", tkode.Text.Trim.ToUpper, tnama.Text.Trim.ToUpper, talamat.Text.Trim.ToUpper, ttelp1.Text.Trim, ttelp2.Text.Trim, tgl, IIf(caktif.Checked = True, 1, 0), cbstatus.EditValue.ToString, userprog, convert_date_to_eng(Date.Now.ToString))
        Dim sql_search As String = String.Format("select kd_supir from admlsp.ms_supir where kd_supir='{0}'", tkode.Text.Trim)



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

            If classmy.insert_to_temp_user(cn, sql, tkode.Text.Trim, "MS_SUPIR", "INSERT", "SUPIR") = False Then
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

        orow("KD_SUPIR") = tkode.Text
        orow("NAMA") = tnama.Text
        orow("ALAMAT") = talamat.Text
        orow("AKTIF") = IIf(caktif.Checked = True, 1, 0)
        orow("TELP") = ttelp1.Text
        orow("TELP2") = ttelp2.Text

        If ttgl.Text = "" Then
            orow("TGL_MASUK") = DBNull.Value
        Else
            orow("TGL_MASUK") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        orow("STATUS") = cbstatus.Text
        orow("KODE") = cbstatus.EditValue
        orow("JML_KASBON") = 0

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        dv(posi)("NAMA") = tnama.Text
        dv(posi)("ALAMAT") = talamat.Text
        dv(posi)("AKTIF") = IIf(caktif.Checked = True, 1, 0)
        dv(posi)("TELP") = ttelp1.Text
        dv(posi)("TELP2") = ttelp2.Text

        If ttgl.Text = "" Then
            dv(posi)("TGL_MASUK") = DBNull.Value
        Else
            dv(posi)("TGL_MASUK") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        dv(posi)("STATUS") = cbstatus.Text
        dv(posi)("KODE") = cbstatus.EditValue

    End Sub

    Private Sub ms_supir2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            tkode.Focus()
        Else
            tnama.Focus()
        End If
    End Sub

    Private Sub ms_supir2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            tkode.Enabled = True

            caktif.Enabled = False
            caktif.Checked = 1

            kosongkan()

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
            cbstatus.Focus()
        End If
    End Sub

    Private Sub cbstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbstatus.KeyDown
        If e.KeyCode = 13 Then
            ttgl.Focus()
        End If
    End Sub

    Private Sub ttgl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            ms_supir.refresh_data()
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

            MsgBox("Penempatan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
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