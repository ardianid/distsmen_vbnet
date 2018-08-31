Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_byartoko3

    Private posii As Integer
    Private dv As DataView
    Private dv1 As DataView
    Private editstat As Boolean
    Private kode_tok As String
    Private jmldep_old As Double
    Private st_grid As String

    Sub New(ByVal edits As Boolean, ByVal dvi As DataView, ByVal ps As Integer, ByVal kd_toko As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        editstat = edits
        dv = dvi
        '  dv.Sort = "NO_REALISASI"
        posii = ps
        kode_tok = kd_toko

    End Sub

    Private Function cek_kelebihan_giro() As Boolean

        Dim hasil As Boolean
        Dim jmlbeli As Double
        If tjmldo.EditValue = 0 Then
            jmlbeli = 0
        Else
            jmlbeli = CDbl(tjmldo.EditValue)
        End If

        Dim jmlgiro As Double
        If tgiro.EditValue = 0 Then
            jmlgiro = 0
        Else
            jmlgiro = CDbl(tgiro.EditValue)
        End If

        If jmlgiro > jmlbeli Then
            hasil = True
        Else
            hasil = False
        End If

        Return hasil

    End Function

    Private Sub isi_box()

        tnodo.EditValue = dv(posii)("NO_REALISASI").ToString
        tinfo_do.EditValue = dv(posii)("INFO_REAL").ToString
        tjmldo.EditValue = dv(posii)("JML").ToString
        tdeposit.EditValue = dv(posii)("JML_DEPOSIT").ToString
        ttunai.EditValue = dv(posii)("JML_TUNAI").ToString
        tnogiro.EditValue = dv(posii)("NO_GIRO").ToString
        ttgl_tempo.EditValue = convert_date_to_ind(dv(posii)("TGL_TEMPO").ToString)
        tgiro.EditValue = dv(posii)("JML_GIRO").ToString
        ttotal.EditValue = dv(posii)("JML_TOT").ToString

        jmldep_old = CDbl(dv(posii)("JML_DEPOSIT_OLD").ToString)
        st_grid = dv(posii)("STAT_GRID").ToString

    End Sub

    Private Sub manipulate()

       

        If editstat = False Then

            Dim no_sr As Integer = -1
            no_sr = dv.Find(tnodo.EditValue)

            If no_sr = -1 Then

                Dim orow As DataRow = dv.Table.NewRow

                orow("NO_REALISASI") = tnodo.Text.Trim
                orow("INFO_REAL") = tinfo_do.Text.Trim
                orow("JML") = tjmldo.EditValue
                orow("JML_DEPOSIT") = tdeposit.EditValue
                orow("JML_TUNAI") = ttunai.EditValue
                orow("JML_GIRO") = tgiro.EditValue
                orow("NO_GIRO") = tnogiro.Text.Trim
                orow("STAT_GRID") = "ADD"
                orow("GIRO_CAIR") = 0

                If ttgl_tempo.Text = "" Then
                    orow("TGL_TEMPO") = DBNull.Value
                Else
                    orow("TGL_TEMPO") = ttgl_tempo.Text.Trim
                End If

                orow("JML_TOT") = ttotal.EditValue
                orow("JML_DEPOSIT_OLD") = tdeposit.EditValue

                dv.Table.Rows.Add(orow)

                Me.Close()

            Else
                MsgBox("NO DO sudah ada dalam daftar", MsgBoxStyle.Information, "Informasi")
                tnodo.Focus()
            End If

        Else

            'Dim orow As DataRow = dv.Table.Rows(posii)

            'orow("NO_REALISASI") = tnodo.Text.Trim
            'orow("INFO_REAL") = tinfo_do.Text.Trim
            'orow("JML") = tjmldo.EditValue
            dv(posii)("JML_DEPOSIT") = tdeposit.EditValue
            dv(posii)("JML_TUNAI") = ttunai.EditValue
            dv(posii)("JML_GIRO") = tgiro.EditValue
            dv(posii)("NO_GIRO") = tnogiro.Text.Trim

            If ttgl_tempo.Text = "" Then
                dv(posii)("TGL_TEMPO") = DBNull.Value
            Else
                dv(posii)("TGL_TEMPO") = ttgl_tempo.Text.Trim
            End If


            dv(posii)("JML_TOT") = ttotal.EditValue

            Me.Close()

        End If



    End Sub

    Private Sub tnodo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnodo.KeyDown
        If e.KeyCode = 13 Then
            tdeposit.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = ""
            tinfo_do.EditValue = ""
            tjmldo.EditValue = 0

            Using fcari As New sr_real(cari, True, kode_tok) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tnodo.Text = fcari.get_NODO

            End Using

        End If
    End Sub

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click

        Dim cari As String = ""

        Using fcari As New sr_real(cari, True, kode_tok) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tnodo.Text = fcari.get_NODO

            If tnodo.Text <> "" Then
                tnodo_Validating(sender, Nothing)
            End If

        End Using


    End Sub

    Private Sub tnodo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tnodo.Validating

        If tnodo.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            If get_stat_pusat() = 1 Then
                sql = String.Format("select b.NODO,b.TOT_AKH - (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) as TOT_JML,b.TANGGAL || chr(13) || chr(10) || d.NAMA || ' - ' || b.NOPOL AS INFO_REAL from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                    "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where b.TOT_AKH > (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) and b.KD_TOKO='{0}' and b.NODO='{1}'  order by b.TANGGAL desc", kode_tok, tnodo.Text.Trim)
            ElseIf get_stat_pusat() = 0 Then
                sql = String.Format("select b.NODO,b.TOT_AKH - (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) as TOT_JML,b.TANGGAL || chr(13) || chr(10) || d.NAMA || ' - ' || b.NOPOL AS INFO_REAL from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                   "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where b.TOT_AKH > (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) and b.KD_TOKO='{0}' and b.NODO='{1}' and b.KD_STAT='{2}' order by b.TANGGAL desc", kode_tok, tnodo.Text.Trim, get_kode_stat)
            End If


            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tnodo.Text = dred("NODO").ToString
                    tinfo_do.Text = dred("INFO_REAL").ToString
                    tjmldo.EditValue = CType(dred("TOT_JML").ToString, Double)

                    dred.Close()

                    If editstat = False Then
                        cek_deposit()
                    End If

                Else
                    dred.Close()
                    MsgBox("NODO tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tnodo.Focus()
                    tinfo_do.Text = ""
                    tjmldo.EditValue = 0
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
            tnodo.Text = ""
            tinfo_do.Text = ""
            tjmldo.EditValue = 0
        End If

    End Sub

    Private Function Deposit_Validate() As Double

        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand = Nothing
        Dim dread As OracleDataReader = Nothing
        Dim sql As String = String.Format("select a.TTL_DEPOSIT from admlsp.ms_toko a where a.KD_TOKO='{0}'", kode_tok)
        Dim hasil As Double = 0

        Try

            cn = classmy.open_conn_utama
            cmd = New OracleCommand(sql, cn)
            dread = cmd.ExecuteReader

            If dread.Read Then

                Dim ttl_dep As Double = 0
                Dim dep_selebumnya As Double = 0

                If Not IsNothing(dread(0).ToString) Then
                    If IsNumeric(dread(0).ToString) Then
                        ttl_dep = CDbl(dread(0).ToString)
                    End If
                End If

                dread.Close()

                dep_selebumnya = deposit_sebelumnya()

                If st_grid = "EDIT" Then

                    If ttl_dep = 0 Then
                        hasil = jmldep_old
                    Else
                        hasil = (ttl_dep + jmldep_old) - dep_selebumnya
                    End If

                Else
                    hasil = ttl_dep - dep_selebumnya
                End If

                hasil = hasil - CDbl(tdeposit.EditValue)

            Else
                dread.Close()
                hasil = 0

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

        Return hasil

    End Function

    Private Sub total_bayar()

        Dim deposit, tunai, giro As Double
        Dim total As Double = 0

        If tdeposit.EditValue = 0 Then
            deposit = 0
        Else
            deposit = tdeposit.EditValue
        End If

        If ttunai.EditValue = 0 Then
            tunai = 0
        Else
            tunai = ttunai.EditValue
        End If


        If IsNumeric(tgiro.EditValue) Then

            If tgiro.EditValue = 0 Then
                giro = 0
            Else
                giro = tgiro.EditValue
            End If

        Else
            giro = 0
        End If
        

        total = deposit + tunai + giro

        ttotal.EditValue = total

    End Sub

    Private Function deposit_sebelumnya() As Double

        Dim hasil As Double = 0

        Dim dvme As DataView
        dvme = New DataView
        dvme = dv

        If Not IsNothing(dvme) Then

            Dim i As Integer = 0
            For i = 0 To dvme.Count - 1

                If dvme(i)("NO_REALISASI").ToString = tnodo.Text.Trim Then
                Else

                    If dvme(i)("STAT_GRID").ToString = "ADD" Then
                        hasil += CDbl(dvme(i)("JML_DEPOSIT").ToString)
                    End If

                    End If

            Next

        End If

        Return hasil

    End Function

    Private Sub cek_deposit()

        Dim cn As OracleConnection = Nothing
        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Try

            Dim sql As String = String.Format("select a.TTL_DEPOSIT from admlsp.ms_toko a where a.KD_TOKO='{0}'", kode_tok)

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            comd = New OracleCommand(sql, cn)
            dread = comd.ExecuteReader

            If dread.Read Then

                Dim ttl_dep As Double = 0
                Dim dep_selebumnya As Double = 0
                Dim real_dep As Double = 0


                If Not IsNothing(dread(0).ToString) Then
                    If IsNumeric(dread(0).ToString) Then
                        ttl_dep = CDbl(dread(0).ToString)
                    End If
                End If

                dread.Close()

                dep_selebumnya = deposit_sebelumnya()

                real_dep = ttl_dep - dep_selebumnya

                If real_dep > CDbl(tjmldo.EditValue) Then
                    tdeposit.EditValue = CDbl(tjmldo.EditValue)
                Else
                    tdeposit.EditValue = real_dep
                End If


            Else
                dread.Close()
                tdeposit.EditValue = 0
            End If


        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Sub tnogiro_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tnogiro.EditValueChanged
        If tnogiro.Text = "" Then
            tgiro.Properties.ReadOnly = True
        Else
            tgiro.Properties.ReadOnly = False
            tgiro.EditValue = 0
        End If

        total_bayar()

    End Sub

    Private Sub tnoGIRO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnogiro.KeyDown
        If e.KeyCode = 13 Then

            If tnogiro.Text <> "" Then
                tgiro.Focus()
            Else
                btsimpan.Focus()
            End If

        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = ""
            tnogiro.EditValue = ""
            ttgl_tempo.EditValue = ""
            tgiro.EditValue = 0

            Using fcari As New sr_giro(cari, kode_tok) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tnogiro.EditValue = fcari.get_NoGrio
                ttgl_tempo.EditValue = convert_date_to_ind(fcari.get_JATUHtEMPO)
                tgiro.EditValue = fcari.get_SisaNilai

            End Using

        End If
    End Sub

    Private Sub btfindgiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind_gro.Click

        Dim cari As String = ""

        Using fcari As New sr_giro(cari, kode_tok) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tnogiro.EditValue = fcari.get_NoGrio
            ttgl_tempo.EditValue = convert_date_to_ind(fcari.get_JATUHtEMPO)
            tgiro.EditValue = fcari.get_SisaNilai

            '  cek_kelebihan_giro()

        End Using


    End Sub

    Private Sub tnogiro_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tnogiro.Validating

        If tnogiro.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            If get_stat_pusat() = 1 Then
                sql = String.Format("select a.NO_GIRO,a.TGL_TEMPO,a.NILAI - a.NILAI_PAKAI as SISA_NILAI from admlsp.ms_giro a " & _
                        "where a.STATUS='PENDING' and a.NILAI > a.NILAI_PAKAI and a.KD_TOKO='{0}' and a.NO_GIRO='{1}' order by a.TGL_TEMPO asc", kode_tok, tnogiro.Text.Trim)
            ElseIf get_stat_pusat() = 0 Then
                sql = String.Format("select a.NO_GIRO,a.TGL_TEMPO,a.NILAI - a.NILAI_PAKAI as SISA_NILAI from admlsp.ms_giro a " & _
                        "where a.STATUS='PENDING' and a.NILAI > a.NILAI_PAKAI and a.KD_TOKO='{0}' and a.NO_GIRO='{1}' and a.KD_STAT='{2}' order by a.TGL_TEMPO asc", kode_tok, tnogiro.Text.Trim, get_kode_stat)
            End If


            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tnogiro.Text = dred(0).ToString
                    ttgl_tempo.Text = convert_date_to_ind(dred(1).ToString)
                    tgiro.EditValue = CDbl(dred(2).ToString)
                    dred.Close()

                    'cek_kelebihan_giro()

                Else

                    dred.Close()
                    MsgBox("No GIRO tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tnogiro.Focus()
                    ttgl_tempo.Text = ""
                    tgiro.EditValue = 0
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
            tnogiro.Text = ""
            ttgl_tempo.Text = ""
            tgiro.EditValue = 0
        End If

    End Sub

    Private Sub ttunai_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttunai.EditValueChanged
        total_bayar()
    End Sub

    Private Sub ttunai_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttunai.KeyDown
        If e.KeyCode = 13 Then
            tnogiro.Focus()
        End If
    End Sub

    Private Sub tdeposit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdeposit.EditValueChanged
        total_bayar()
    End Sub

    Private Sub tdeposit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdeposit.KeyDown
        If e.KeyCode = 13 Then
            ttunai.Focus()
        End If
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub t_spare_out3_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If editstat = True Then
            tdeposit.Focus()
        Else
            tnodo.Focus()
        End If
    End Sub

    Private Sub t_spare_out3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If editstat = True Then

            tnodo.Enabled = False
            btsimpan.Text = "&Rubah"

            btsimpan.Enabled = False

            tdeposit.Properties.ReadOnly = True
            ttunai.Properties.ReadOnly = True
            tnogiro.Properties.ReadOnly = True
            btfind_gro.Enabled = False

            isi_box()

        Else
            tnodo.Enabled = True
            btsimpan.Text = "&Tambah"

            tjmldo.EditValue = 0
            tdeposit.EditValue = 0
            ttunai.EditValue = 0
            tgiro.EditValue = 0
            ttotal.EditValue = 0

            tdeposit.Properties.ReadOnly = False
            ttunai.Properties.ReadOnly = False
            tnogiro.Properties.ReadOnly = False
            btfind_gro.Enabled = True

            st_grid = "ADD"

            btsimpan.Enabled = True

            tgiro.Properties.ReadOnly = True

        End If

    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tnodo.EditValue = "" Then

            MsgBox("NO DO tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tnodo.Focus()
            Exit Sub

        End If

        If ttotal.EditValue = 0 Then

            MsgBox("Tidak ada pelunasan yang akan disimpan", MsgBoxStyle.Information, "Informasi")
            tdeposit.Focus()
            Exit Sub

        End If

        If Deposit_Validate() < 0 Then
            MsgBox("Nilai deposit pelunasan melebihi sisa deposit yang ada", MsgBoxStyle.Information, "Informasi")
            tdeposit.Focus()
            Exit Sub
        End If

        If CDbl(tdeposit.EditValue) > CDbl(tjmldo.EditValue) Then
            MsgBox("Nilai deposit melebihi jumlah nota ", MsgBoxStyle.Information, "Informasi")
            tgiro.Focus()
            Exit Sub
        End If

        If cek_kelebihan_giro() = True Then
            MsgBox("Nilai giro melebihi jumlah nota", MsgBoxStyle.Information, "Informasi")
            tgiro.Focus()
            Exit Sub
        End If

        If (CDbl(tgiro.EditValue) + CDbl(tdeposit.EditValue)) > CDbl(tjmldo.EditValue) Then
            MsgBox("Nilai giro + deposit melebihi jumlah nota", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        End If

        manipulate()

    End Sub

    Private Sub tgiro_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgiro.EditValueChanged
        total_bayar()
    End Sub

    Private Sub tgiro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tgiro.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

End Class