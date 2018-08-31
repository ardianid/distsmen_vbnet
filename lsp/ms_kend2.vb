Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client


Public Class ms_kend2

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

        tnopol.Text = ""
        ttgl_pjk.EditValue = 0
        tbln_pjk.EditValue = 0
        tblnkir1.EditValue = 0
        tblnkir2.EditValue = 0
        tket.Text = ""

    End Sub

    Private Sub isi_box()

        tnopol.Enabled = False
        tnopol.Text = dv(posi)("NOPOL").ToString

        If dv(posi)("TGL_BELI").ToString = "" Then
            ttgl_beli.Text = String.Empty
        Else
            ttgl_beli.EditValue = FormatDateTime(dv(posi)("TGL_BELI").ToString, DateFormat.ShortDate)
        End If

        If dv(posi)("TGL_BERLAKU").ToString = "" Then
            ttgl_berlaku.Text = String.Empty
        Else
            ttgl_berlaku.EditValue = FormatDateTime(dv(posi)("TGL_BERLAKU").ToString, DateFormat.ShortDate)
        End If

        ttgl_pjk.EditValue = dv(posi)("TGL_PAJAK").ToString
        tbln_pjk.EditValue = dv(posi)("BLN_PAJAK").ToString

        tblnkir1.EditValue = dv(posi)("BLN_KIR1").ToString
        tblnkir2.EditValue = dv(posi)("BLN_KIR2").ToString

        tket.Text = dv(posi)("KETERANGAN").ToString

        caktif.Checked = dv(posi)("AKTIF").ToString

    End Sub

    Private Sub edit()

        Dim tglbeli As String
        If ttgl_beli.Text = "" Then
            tglbeli = ""
        Else
            tglbeli = convert_date_to_eng(ttgl_beli.EditValue.ToString)
        End If

        Dim tglberlaku As String
        If ttgl_berlaku.Text = "" Then
            tglberlaku = ""
        Else
            tglberlaku = convert_date_to_eng(ttgl_berlaku.EditValue.ToString)
        End If

        Dim sql As String = String.Format("update admlsp.ms_kendaraan set tgl_beli='{0}',tgl_berlaku='{1}',tgl_pajak={2},bln_pajak={3},bln_kir1={4},bln_kir2={5},keterangan='{6}',aktif={7},user_edit='{8}',tgl_edit='{9}'" & _
                                          " where nopol='{10}'", tglbeli, tglberlaku, ttgl_pjk.EditValue, tbln_pjk.EditValue, tblnkir1.EditValue, tblnkir2.EditValue, tket.EditValue, IIf(caktif.Checked = True, 1, 0), userprog, convert_date_to_eng(Date.Now.ToString), tnopol.Text.Trim)


        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            open_wait()

            cn = classmy.open_conn_utama

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)

            cmd.ExecuteNonQuery()

            If classmy.insert_to_temp_user(cn, sql, tnopol.Text.Trim, "MS_KENDARAAN", "UPDATE", "KENDARAAN") = False Then
                close_wait()
                MsgBox("Kesalahan data Temp User", MsgBoxStyle.Critical, "Informasi")
            Else

                sqltrans.Commit()

                update_view(tglbeli, tglberlaku)

                MsgBox("Data telah dirubah..", MsgBoxStyle.Information, "Informasi")
                ms_supir.refresh_data()

                Me.Close()

                close_wait()

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

        Dim tglbeli As String
        If ttgl_beli.Text = "" Then
            tglbeli = ""
        Else
            tglbeli = convert_date_to_eng(ttgl_beli.EditValue.ToString)
        End If

        Dim tglberlaku As String
        If ttgl_berlaku.Text = "" Then
            tglberlaku = ""
        Else
            tglberlaku = convert_date_to_eng(ttgl_berlaku.EditValue.ToString)
        End If

        Dim sql As String = String.Format("insert into admlsp.ms_kendaraan (nopol,tgl_beli,tgl_berlaku,tgl_pajak,bln_pajak,bln_kir1,bln_kir2,keterangan,aktif,user_add,tgl_add) values" & _
                                          "('{0}','{1}','{2}',{3},{4},{5},{6},'{7}',{8},'{9}','{10}')", tnopol.Text.Trim.ToUpper, tglbeli, tglberlaku, ttgl_pjk.EditValue, tbln_pjk.EditValue, tblnkir1.EditValue, tblnkir2.EditValue, tket.Text.Trim, IIf(caktif.Checked = True, 1, 0), userprog, convert_date_to_eng(Date.Now.ToString))
        Dim sql_search As String = String.Format("select kode from admlsp.ms_kec where kode='{0}'", tnopol.Text.Trim)


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
                tnopol.Focus()
                Exit Sub
            Else
                dre.Close()
            End If

            open_wait()

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            If classmy.insert_to_temp_user(cn, sql, tnopol.Text.Trim, "MS_KENDARAAN", "INSERT", "KENDARAAN") = False Then
                close_wait()
                MsgBox("Kesalahan data Temp User", MsgBoxStyle.Critical, "Informasi")
            Else
                sqltrans.Commit()

                insert_view(tglbeli, tglberlaku)


                close_wait()

                MsgBox("Data telah disimpan... ", MsgBoxStyle.Information, "Informasi")

                addjml = addjml + 1

                kosongkan()
                tnopol.Focus()
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

    Private Sub insert_view(ByVal tglbeli As String, ByVal tglberlaku As String)

        Dim orow As DataRow

        orow = dv.Table.NewRow()

        orow("NOPOL") = tnopol.Text
        orow("TGL_BELI") = IIf(tglbeli = "", DBNull.Value, convert_date_to_ind(tglbeli))
        orow("TGL_BERLAKU") = IIf(tglberlaku = "", DBNull.Value, convert_date_to_ind(tglberlaku))
        orow("TGLB_PAJAK") = String.Format("{0}/{1}", ttgl_pjk.EditValue, tbln_pjk.EditValue)
        orow("BLN_KIR") = String.Format("{0}/{1}", tblnkir1.EditValue, tblnkir2.EditValue)
        orow("KETERANGAN") = tket.Text.Trim

        orow("TGL_PAJAK") = ttgl_pjk.EditValue
        orow("BLN_PAJAK") = tbln_pjk.EditValue

        orow("BLN_KIR1") = tblnkir1.EditValue
        orow("BLN_KIR2") = tblnkir2.EditValue

        orow("AKTIF") = IIf(caktif.Checked = True, 1, 0)

        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub update_view(ByVal tglbeli As String, ByVal tglberlaku As String)

        dv(posi)("TGL_BELI") = IIf(tglbeli = "", DBNull.Value, convert_date_to_ind(tglbeli))
        dv(posi)("TGL_BERLAKU") = IIf(tglberlaku = "", DBNull.Value, convert_date_to_ind(tglberlaku))
        dv(posi)("TGLB_PAJAK") = String.Format("{0}/{1}", ttgl_pjk.EditValue, tbln_pjk.EditValue)
        dv(posi)("BLN_KIR") = String.Format("{0}/{1}", tblnkir1.EditValue, tblnkir2.EditValue)
        dv(posi)("KETERANGAN") = tket.Text.Trim

        dv(posi)("TGL_PAJAK") = ttgl_pjk.EditValue
        dv(posi)("BLN_PAJAK") = tbln_pjk.EditValue

        dv(posi)("BLN_KIR1") = tblnkir1.EditValue
        dv(posi)("BLN_KIR2") = tblnkir2.EditValue

        dv(posi)("AKTIF") = IIf(caktif.Checked = True, 1, 0)

    End Sub


    Private Sub ms_kend2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If statadd.Equals(True) Then
            tnopol.Focus()
        Else
            ttgl_beli.Focus()
        End If
    End Sub

    Private Sub ms_kend2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If statadd.Equals(True) Then

            tnopol.Enabled = True

            caktif.Enabled = False
            caktif.Checked = 1

            kosongkan()

        Else

            tnopol.Enabled = False

            caktif.Enabled = True
            isi_box()
        End If



    End Sub

    Private Sub tnopol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnopol.KeyDown
        If e.KeyCode = 13 Then
            ttgl_beli.Focus()
        End If
    End Sub

    Private Sub tglbeli_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl_beli.KeyDown
        If e.KeyCode = 13 Then
            ttgl_berlaku.Focus()
        End If
    End Sub

    Private Sub tglberlaku_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl_berlaku.KeyDown
        If e.KeyCode = 13 Then
            ttgl_pjk.Focus()
        End If
    End Sub

    Private Sub tglpajak_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl_pjk.KeyDown
        If e.KeyCode = 13 Then
            tbln_pjk.Focus()
        End If
    End Sub

    Private Sub tblnpajak_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbln_pjk.KeyDown
        If e.KeyCode = 13 Then
            tblnkir1.Focus()
        End If
    End Sub

    Private Sub tblnkir1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblnkir1.KeyDown
        If e.KeyCode = 13 Then
            tblnkir2.Focus()
        End If
    End Sub

    Private Sub tblnkir2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblnkir2.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        End If
    End Sub

    Private Sub tket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tket.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        If statadd.Equals(True) And addjml > 0 Then
            ms_kend.refresh_data()
        End If

        Me.Close()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tnopol.Text = "" Then

            MsgBox("No Polisi tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tnopol.Focus()
            Exit Sub
        End If


        If ttgl_pjk.EditValue > 31 Then

            MsgBox("Tanggal pajak tidak boleh lebih dari 31", MsgBoxStyle.Information, "Informasi")

            ttgl_pjk.Focus()
            Exit Sub
        End If

        If tbln_pjk.EditValue > 12 Then

            MsgBox("Bulan pajak tidak boleh lebih dari 12", MsgBoxStyle.Information, "Informasi")

            tbln_pjk.Focus()
            Exit Sub
        End If

        If tblnkir1.EditValue > 12 Then

            MsgBox("Bulan KIR 1 pajak tidak boleh lebih dari 12", MsgBoxStyle.Information, "Informasi")

            tblnkir1.Focus()
            Exit Sub
        End If

        If tblnkir2.EditValue > 12 Then

            MsgBox("Bulan KIR 2 pajak tidak boleh lebih dari 12", MsgBoxStyle.Information, "Informasi")

            tblnkir2.Focus()
            Exit Sub
        End If

        If statadd.Equals(True) Then
            insert()
        Else
            edit()
        End If


    End Sub

End Class