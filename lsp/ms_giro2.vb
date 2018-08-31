Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class ms_giro2

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

        tnogiro.Text = ""
        ttgl.EditValue = Date.Now
        tbank.EditValue = ""

        tkode_toko.Text = ""
        tnama_toko.Text = ""
        talamat_toko.Text = ""

        tnil.EditValue = 0
        tnil_pakai.EditValue = 0
        tket.EditValue = ""

    End Sub

    Private Sub isi_box()

        tnogiro.Enabled = False
        tnogiro.Text = dv(posi)("NO_GIRO").ToString
        ttgl.Text = convert_date_to_ind(dv(posi)("TGL_TEMPO").ToString)
        tkode_toko.Text = dv(posi)("KD_TOKO").ToString
        tnama_toko.Text = dv(posi)("NAMA_TOKO").ToString
        talamat_toko.Text = dv(posi)("ALAMAT_TOKO").ToString
        tbank.Text = dv(posi)("BANK").ToString
        tket.Text = dv(posi)("KETERANGAN").ToString

        tnil.EditValue = dv(posi)("NILAI").ToString
        tnil_pakai.EditValue = dv(posi)("NILAI_PAKAI").ToString
        tstatus.EditValue = dv(posi)("STATUS").ToString

    End Sub

    Private Sub edit()

        Dim tgl As String
        If ttgl.Text = "" Then
            tgl = ""
        Else
            tgl = convert_date_to_eng(ttgl.EditValue.ToString)
        End If

        Dim sql As String = String.Format("update admlsp.ms_giro set tgl_tempo='{0}',kd_toko='{1}',bank='{2}',keterangan='{3}',nilai={4},user_edit='{5}',tgl_edit='{6}'" & _
                                          " where no_giro='{7}'", tgl, tkode_toko.Text, tbank.Text.Trim, tket.Text.Trim, tnil.EditValue, userprog, convert_date_to_eng(Date.Now.ToString), tnogiro.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tnogiro.Text.Trim, "MS_GIRO", "UPDATE", "GIRO")

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

        Dim sql As String = String.Format("insert into admlsp.ms_giro (no_giro,tgl_tempo,kd_toko,bank,keterangan,kd_stat,nilai,user_add,tgl_add,status) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}','{9}')", tnogiro.Text.Trim.ToUpper, tgl, tkode_toko.Text, tbank.Text.Trim, tket.Text.Trim, get_kode_stat, tnil.EditValue, userprog, convert_date_to_eng(Date.Now.ToString), tstatus.Text.Trim)
        Dim sql_search As String = String.Format("select no_giro from admlsp.ms_giro where no_giro='{0}'", tnogiro.Text.Trim)


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
                tnogiro.Focus()
                Exit Sub
            Else
                dre.Close()
            End If


            open_wait()

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tnogiro.Text.Trim, "MS_GIRO", "INSERT", "GIRO")

            sqltrans.Commit()

            insert_view()

            close_wait()

            MsgBox("Data telah disimpan... ", MsgBoxStyle.Information, "Informasi")

            addjml = addjml + 1

            kosongkan()
            tnogiro.Focus()

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

        orow("NO_GIRO") = tnogiro.Text

        If ttgl.Text = "" Then
            orow("TGL_TEMPO") = DBNull.Value
        Else
            orow("TGL_TEMPO") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        orow("KD_TOKO") = tkode_toko.Text.Trim
        orow("NAMA_TOKO") = tnama_toko.Text.Trim
        orow("ALAMAT_TOKO") = talamat_toko.Text.Trim
        orow("NILAI") = tnil.EditValue
        orow("NILAI_PAKAI") = tnil_pakai.EditValue
        orow("BANK") = tbank.Text.Trim
        orow("KETERANGAN") = tket.Text.Trim

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view()

        If ttgl.Text = "" Then
            dv(posi)("TGL_TEMPO") = DBNull.Value
        Else
            dv(posi)("TGL_TEMPO") = convert_date_to_ind(ttgl.EditValue.ToString)
        End If

        dv(posi)("KD_TOKO") = tkode_toko.Text.Trim
        dv(posi)("NAMA_TOKO") = tnama_toko.Text.Trim
        dv(posi)("ALAMAT_TOKO") = talamat_toko.Text.Trim
        dv(posi)("NILAI") = tnil.EditValue
        dv(posi)("NILAI_PAKAI") = tnil_pakai.EditValue
        dv(posi)("BANK") = tbank.Text.Trim
        dv(posi)("KETERANGAN") = tket.Text.Trim

    End Sub

    Private Sub MS_GIRO2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            tnogiro.Focus()
        Else
            ttgl.Focus()
        End If
    End Sub

    Private Sub MS_GIRO2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            tnogiro.Enabled = True

            tstatus.EditValue = "PENDING"
            kosongkan()
        Else

            tnogiro.Enabled = False

            isi_box()
        End If

    End Sub

    Private Sub tnogiro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnogiro.KeyDown
        If e.KeyCode = 13 Then
            ttgl.Focus()
        End If
    End Sub

    Private Sub ttgl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        If e.KeyCode = 13 Then
            tbank.Focus()
        End If
    End Sub

    Private Sub tbank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbank.KeyDown
        If e.KeyCode = 13 Then
            tkode_toko.Focus()
        End If
    End Sub

    Private Sub tnil_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnil.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        End If
    End Sub

    Private Sub tket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tket.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub tkode_toko_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkode_toko.KeyDown
        If e.KeyCode = 13 Then
            tnil.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'nama_toko.Text.Trim
            tnama_toko.Text = ""
            talamat_toko.Text = ""

            Using fcari As New sr_toko(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkode_toko.Text = fcari.get_kode
                tnama_toko.Text = fcari.get_nama
                talamat_toko.Text = fcari.get_alamat_toko

            End Using

        End If
    End Sub

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click

        Dim cari As String = "" 'tnama_toko.Text.Trim"

        Using fcari As New sr_toko(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkode_toko.Text = fcari.get_kode
            tnama_toko.Text = fcari.get_nama
            talamat_toko.Text = fcari.get_alamat_toko

        End Using


    End Sub

    Private Sub tnama_toko_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkode_toko.Validating

        If tkode_toko.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            If get_stat_pusat() = 1 Then
                sql = String.Format("select a.KD_TOKO,a.NAMA_TOKO,a.ALAMAT from admlsp.ms_toko a where a.AKTIF=1 and a.KD_TOKO='{0}'", tkode_toko.Text.Trim)
            ElseIf get_stat_pusat() = 0 Then
                sql = String.Format("select a.KD_TOKO,a.NAMA_TOKO,a.ALAMAT from admlsp.ms_toko a where a.AKTIF=1 and a.KD_TOKO='{0}' and a.KODE_STAT='{1}'", tkode_toko.Text.Trim, get_kode_stat)
            End If


            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tkode_toko.Text = dred(0).ToString
                    tnama_toko.Text = dred(1).ToString
                    talamat_toko.Text = dred(2).ToString

                Else

                    MsgBox("Toko tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tkode_toko.Focus()
                    tnama_toko.Text = ""
                    talamat_toko.Text = ""
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


        Else
            tkode_toko.Text = ""
            tnama_toko.Text = ""
            talamat_toko.Text = ""
        End If

    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            ms_giro.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tnogiro.Text = "" Then

            MsgBox("No GIRO tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tnogiro.Focus()
            Exit Sub
        End If

        If tkode_toko.Text = "" Then

            MsgBox("Toko tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tnama_toko.Focus()
            Exit Sub
        End If


        If tnil.EditValue = 0 Then

            MsgBox("Nilai Giro tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tnil.Focus()
            Exit Sub

        End If


        If statadd.Equals(True) Then
            insert()
        Else
            edit()
        End If


    End Sub

End Class