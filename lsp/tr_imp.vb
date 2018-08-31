Imports System.Xml
Imports System.IO
Imports System.Text
Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client
Imports System.Security.Cryptography

Public Class tr_imp

    Private ds_imp As DataSet
    Private cn1 As OracleConnection
    Private sqltrans As OracleTransaction
    Private pros As Integer = 0
    Dim dvmanager As Data.DataViewManager
    Dim dv1 As Data.DataView

    Private Function cek_data(ByVal tabel As String, ByVal key1 As String, ByVal cn As OracleConnection) As Integer

        Dim sqltrack2 As String = String.Empty

        Select Case tabel.ToUpper

            Case "MS_AKUN"
                sqltrack2 = String.Format("SELECT A.USER_ADDl FROM MS_AKUN A WHERE A.KODE='{0}'", key1)
            Case "MS_BARANG"
                sqltrack2 = String.Format("SELECT ms_barang.user_add FROM admlsp.ms_barang WHERE ms_barang.KODE='{0}'", key1)
            Case "MS_GIRO"
                sqltrack2 = String.Format("SELECT ms_giro.user_add FROM ADMLSP.ms_giro WHERE ms_giro.no_giro = '{0}')", key1)
            Case "MS_KAB"
                sqltrack2 = String.Format("SELECT ms_kab.user_add FROM admlsp.ms_kab WHERE ((ms_kab.kode = '{0}'))", key1)
            Case "MS_KAS"
                sqltrack2 = String.Format("SELECT ms_kas.user_add FROM ADMLSP.ms_kas WHERE ms_kas.kode = '{0}')", key1)
            Case "MS_KEC"
                sqltrack2 = String.Format("SELECT ms_kec.user_add FROM ADMLSP.ms_kec WHERE ((ms_kec.kode = '{0}'))", key1)
            Case "MS_KENDARAAN"
                sqltrack2 = String.Format("SELECT ms_kendaraan.user_add FROM ADMLSP.ms_kendaraan WHERE ((ms_kendaraan.nopol = '{0}'))", key1)
            Case "MS_KSO"
                sqltrack2 = String.Format("SELECT ms_kso.user_add FROM ADMLSP.ms_kso WHERE ms_kso.kode = '{0}')", key1)
            Case "MS_PRINCIPAL"
                sqltrack2 = String.Format("SELECT ms_principal.user_add FROM ADMLSP.ms_principal WHERE ((ms_principal.kd_prc = '{0}'))", key1)
            Case "MS_PROP"
                sqltrack2 = String.Format("SELECT ms_prop.user_add FROM ADMLSP.ms_prop WHERE ((ms_prop.kode = '{0}'))", key1)
            Case "MS_SALES"
                sqltrack2 = String.Format("SELECT ms_sales.user_add FROM ADMLSP.ms_sales WHERE ms_sales.kd_sales = '{0}'", key1)
            Case "MS_SPAREPART"
                sqltrack2 = String.Format("SELECT ms_sparepart.user_add FROM ADMLSP.ms_sparepart WHERE ((ms_sparepart.kode = '{0}'))", key1)
            Case "MS_SUPIR"
                sqltrack2 = String.Format("SELECT  ms_supir.tgl_add FROM admlsp.ms_supir WHERE ms_supir.kd_supir = '{0}'", key1)
            Case "MS_TOKO"
                sqltrack2 = String.Format("SELECT ms_toko.user_add FROM admlsp.ms_toko WHERE ms_toko.kd_toko = '{0}'", key1)
            Case "MS_USER_HEADER"
                sqltrack2 = String.Format("SELECT ms_user_header.user_add FROM admlsp.ms_user_header WHERE ((ms_user_header.nama = '{0}'))", key1)
            Case "TR_ANGKUTAN"
                sqltrack2 = String.Format("SELECT tr_angkutan.user_add FROM admlsp.tr_angkutan WHERE tr_angkutan.no_bukti = '{0}'", key1)
            Case "TR_DEP_PRINCIPAL"
                sqltrack2 = String.Format("SELECT tr_dep_principal.user_add FROM admlsp.tr_dep_principal WHERE tr_dep_principal.no_bukti = '{0}'", key1)
            Case "TR_DEP_TOKO"
                sqltrack2 = String.Format("SELECT tr_dep_toko.user_add FROM admlsp.tr_dep_toko WHERE tr_dep_toko.no_bukti = '{0}'", key1)
            Case "TR_INV"
                sqltrack2 = String.Format("SELECT tr_inv.user_add FROM admlsp.tr_inv WHERE tr_inv.no_bukti = '{0}'", key1)
            Case "TR_KAS_IN"
                sqltrack2 = String.Format("SELECT tr_kas_in.user_add FROM admlsp.tr_kas_in WHERE tr_kas_in.no_bukti = '{0}'", key1)
            Case "TR_KAS_OUT"
                sqltrack2 = String.Format("SELECT tr_kas_out.user_add FROM admlsp.tr_kas_out WHERE tr_kas_out.no_bukti = '{0}'", key1)
            Case "TR_KASBON"
                sqltrack2 = String.Format("SELECT tr_kasbon.user_add FROM admlsp.tr_kasbon WHERE tr_kasbon.no_bukti = '{0}'", key1)
            Case "TR_PENCAIRAN_GIRO"
                sqltrack2 = String.Format("SELECT tr_pencairan_giro.user_add FROM admlsp.tr_pencairan_giro WHERE tr_pencairan_giro.no_bukti = '{0}'", key1)
            Case "TR_PRE"
                sqltrack2 = String.Format("SELECT tr_pre.user_add FROM admlsp.tr_pre WHERE tr_pre.no_bukti = '{0}'", key1)
            Case "TR_REAL_ORDER"
                sqltrack2 = String.Format("SELECT tr_real_order.user_add FROM admlsp.tr_real_order WHERE tr_real_order.nodo = '{0}'", key1)
            Case "TR_SPAREPART"
                sqltrack2 = String.Format("SELECT tr_sparepart.user_add FROM admlsp.tr_sparepart WHERE tr_sparepart.no_bukti = '{0}'", key1)
            Case "TR_SPAREPART_OUT"
                sqltrack2 = String.Format("SELECT tr_sparepart_out.user_add FROM admlsp.tr_sparepart_out WHERE tr_sparepart_out.no_bukti = '{0}'", key1)
            Case "TR_TKO_BYAR_HEADER"
                sqltrack2 = String.Format("SELECT tr_tko_byar_header.user_add FROM admlsp.tr_tko_byar_header WHERE tr_tko_byar_header.no_bukti = '{0}'", key1)
            Case "TR_UANG_JLN"
                sqltrack2 = String.Format("SELECT TR_UANG_JLN.USER_ADD FROM ADMLSP.TR_UANG_JLN WHERE TR_UANG_JLN.NO_BUKTI = '{0}'", key1)
            Case "TR_UANG_JLN_LN"
                sqltrack2 = String.Format("SELECT TR_UANG_JLN_LN.USER_ADD FROM ADMLSP.TR_UANG_JLN_LN WHERE TR_UANG_JLN_LN.NO_BUKTI = '{0}'", key1)
        End Select

        Dim comd As OracleCommand
        Dim dread As OracleDataReader

        Try

            comd = New OracleCommand(sqltrack2, cn)
            dread = comd.ExecuteReader()

            If dread.Read Then

                If dread(0).ToString = "" Then
                    Return 0
                Else
                    Return 1
                End If

            Else
                Return 0
            End If


        Catch ex As Exception
            Return 2
        End Try

    End Function

    Private Shared Function MyDecryptor(ByVal sPath As String) As String

        Dim byteKey As Byte() = System.Text.Encoding.UTF8.GetBytes("B499F4BF48242E05548D1E4C8BB26A2E")
        Dim byteIV As Byte() = System.Text.Encoding.UTF8.GetBytes(",%u'm&'CXSy/T7x;4")

        Dim vFile As FileStream = New IO.FileStream(sPath, FileMode.Open)
        Dim vCrypto As New CryptoStream(vFile, (New RijndaelManaged()).CreateDecryptor(byteKey, byteIV), CryptoStreamMode.Read)
        Dim vTextReader As New StreamReader(vCrypto, Encoding.Unicode)

        Dim s As String = vTextReader.ReadToEnd

        vTextReader.Close()
        vCrypto.Close()
        vFile.Close()

        Return s
    End Function

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click

        OpenFileDialog1.Title = "Please Select a File"
        OpenFileDialog1.Filter = "xml Files|*.xml"
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.FileName = ""

        OpenFileDialog1.ShowDialog()

    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

        Dim strm As System.IO.Stream
        strm = OpenFileDialog1.OpenFile()
        tfile.Text = OpenFileDialog1.FileName.ToString
        If Not (strm Is Nothing) Then
            'insert code to read the file data
            strm.Close()
        End If

        If tfile.Text.Trim.Length > 0 Then
            Application.DoEvents()
            open_from_file()
        End If

    End Sub

    Private Sub open_from_file()

        Try

            open_wait()

            If pros = 1 Then
                sqltrans.Rollback()
            End If

            ttottal.Text = 0
            grid1.DataSource = Nothing

            ' MyDecryptor(tfile.Text.Trim)

            tok.Text = 0
            tduplikasi.Text = 0
            tkesalahan.Text = 0

            ds_imp = New DataSet
            ds_imp.ReadXml(tfile.Text.Trim)

            If ds_imp.Tables(0).Rows.Count <= 0 Or IsNothing(ds_imp) Then
                close_wait()
                MsgBox("File yang dipilih tidak dapat ditampilkan...", MsgBoxStyle.Information, "Informasi")
                Exit Sub
            End If

            proses()

        Catch ex As Exception
            close_wait()
            MsgBox("Terjadi kesalahan import data, hubungi administrator...", vbOKOnly + MsgBoxStyle.Critical, "Informasi")
        End Try

    End Sub

    Private Sub proses()

        If IsNothing(ds_imp) Then
            Exit Sub
        End If

        If ds_imp.Tables(0).Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim i As Integer = 0

        Dim cn As OracleConnection = Nothing
        Dim comd As OracleCommand = Nothing

        '   Try

        ' open_wait()

        cn1 = New OracleConnection
        cn1 = classmy.open_conn_utama
        sqltrans = cn1.BeginTransaction()

        pros = 1

        tok.Text = 0
        tduplikasi.Text = 0
        tkesalahan.Text = 0
        list1.Items.Clear()

        Dim vok As Integer = 0
        Dim vduplikasi As Integer = 0
        Dim vkesalahan As Integer = 0
        Dim hasilcek As Integer = 0
        Dim potong1, potong2 As String
        Dim nourut As Integer = 0

        For i = 0 To ds_imp.Tables(0).Rows.Count - 1


            'Try
            ' potong1 = ds_imp.Tables(0).Rows(i)("NO_ID").ToString
            potong1 = ds_imp.Tables(0).Rows(i)("JTABEL").ToString
            potong2 = ds_imp.Tables(0).Rows(i)("JTABEL").ToString

            potong1 = InStr(potong1, "2")
            potong2 = InStr(potong2, "DETAIL")

            If potong1 <> "0" Or _
               potong2 <> "0" Then

                comd = New OracleCommand(ds_imp.Tables(0).Rows(i)("SCRIPT").ToString, cn1)
                comd.ExecuteNonQuery()

                ins_to_temp_user(cn1, ds_imp.Tables(0).Rows(i)("SCRIPT").ToString, ds_imp.Tables(0).Rows(i)("KEY_NUM").ToString, ds_imp.Tables(0).Rows(i)("JTABEL").ToString, ds_imp.Tables(0).Rows(i)("JTRANS").ToString, ds_imp.Tables(0).Rows(i)("JTRANS_APL").ToString)

                ds_imp.Tables(0).Rows(i)("STAT") = "OK"


            Else

                hasilcek = cek_data(ds_imp.Tables(0).Rows(i)("JTABEL").ToString, ds_imp.Tables(0).Rows(i)("KEY_NUM").ToString, cn1)

                If hasilcek = 0 Then

                    comd = New OracleCommand(ds_imp.Tables(0).Rows(i)("SCRIPT").ToString, cn1)
                    comd.ExecuteNonQuery()

                    ins_to_temp_user(cn1, ds_imp.Tables(0).Rows(i)("SCRIPT").ToString, ds_imp.Tables(0).Rows(i)("KEY_NUM").ToString, ds_imp.Tables(0).Rows(i)("JTABEL").ToString, ds_imp.Tables(0).Rows(i)("JTRANS").ToString, ds_imp.Tables(0).Rows(i)("JTRANS_APL").ToString)

                    ds_imp.Tables(0).Rows(i)("STAT") = "OK"

                    vok = vok + 1
                    tok.Text = vok

                    nourut += 1

                    With list1
                        .Items.Add(String.Format("No ({0})", nourut))
                        .Items.Add(String.Format("No Bukti         : {0}", ds_imp.Tables(0).Rows(i)("KEY_NUM").ToString))
                        .Items.Add(String.Format("Transaksi/Form   : {0}", ds_imp.Tables(0).Rows(i)("JTRANS_APL").ToString))
                        .Items.Add(String.Format("Jns Manipulasi   : {0}", ds_imp.Tables(0).Rows(i)("JTRANS").ToString))
                        .Items.Add(String.Format("Status Import    : {0}", "OK."))
                        .Items.Add(vbCrLf)
                    End With

                    Application.DoEvents()

                ElseIf hasilcek = 1 Then
                    ds_imp.Tables(0).Rows(i)("STAT") = "Data Sudah Ada (Tidak diproses)"

                    vduplikasi = vduplikasi + 1
                    tduplikasi.Text = vduplikasi

                    nourut += 1

                    With list1
                        .Items.Add(String.Format("No ({0})", nourut))
                        .Items.Add(String.Format("No Bukti         : {0}", ds_imp.Tables(0).Rows(i)("KEY_NUM").ToString))
                        .Items.Add(String.Format("Transaksi/Form   : {0}", ds_imp.Tables(0).Rows(i)("JTRANS_APL").ToString))
                        .Items.Add(String.Format("Jns Manipulasi   : {0}", ds_imp.Tables(0).Rows(i)("JTRANS").ToString))
                        .Items.Add(String.Format("Status Import    : {0}", "Data Sudah Ada (Tidak diproses)"))
                        .Items.Add(vbCrLf)
                    End With

                    Application.DoEvents()

                ElseIf hasilcek = 2 Then

                    ds_imp.Tables(0).Rows(i)("STAT") = "Kesalahan data (Hub Administrator)"

                    vkesalahan = vkesalahan + 1
                    tkesalahan.Text = vkesalahan

                    nourut += 1

                    With list1
                        .Items.Add(String.Format("No ({0})", nourut))
                        .Items.Add(String.Format("No Bukti         : {0}", ds_imp.Tables(0).Rows(i)("KEY_NUM").ToString))
                        .Items.Add(String.Format("Transaksi/Form   : {0}", ds_imp.Tables(0).Rows(i)("JTRANS_APL").ToString))
                        .Items.Add(String.Format("Jns Manipulasi   : {0}", ds_imp.Tables(0).Rows(i)("JTRANS").ToString))
                        .Items.Add(String.Format("Status Import    : {0}", "Kesalahan data (Hub Administrator)"))
                        .Items.Add(vbCrLf)
                    End With

                    Application.DoEvents()

                End If

            End If


            'Catch ex As OracleException
            '    MsgBox("Terjadi kesalahan import data, hubungi administrator...", vbOKOnly + MsgBoxStyle.Critical, "Informasi")
            'End Try


        Next

        Dim filename As String

        filename = String.Format("import{0}{1}{2}.{3}{4}{5}", Date.Now.Day, Date.Now.Month, Date.Now.Year, Hour(Now), Minute(Now), Second(Now))
        filename = String.Format("C:\{0}", filename & ".txt")

        Dim listboxdata As String = String.Empty
        Dim str As String
        For Each str In list1.Items
            listboxdata += str + vbCrLf
        Next
        File.WriteAllText(filename, listboxdata)

        With list1
            .Items.Add("Import data Selesai...")
            .Items.Add("Log Import dapat anda lihat di " & filename)
        End With

        close_wait()
        btpros.Enabled = False

    End Sub

    Private Sub btpros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpros.Click

        proses()

    End Sub

    Private Sub tr_imp_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If pros = 1 Then
            e.Cancel = True
        Else
            grid1.DataSource = Nothing
            tfile.Text = ""
            ttottal.Text = 0
            tok.Text = 0
            tduplikasi.Text = 0
            tkesalahan.Text = 0
            list1.Items.Clear()
        End If

        

    End Sub

    Private Sub tr_imp_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        pros = 0
    End Sub

    Private Sub btcanc_Click(sender As System.Object, e As System.EventArgs) Handles btcanc.Click

        If pros = 1 Then

            Try

                sqltrans.Rollback()

                If Not cn1 Is Nothing Then
                    If cn1.State = ConnectionState.Open Then
                        cn1.Close()
                    End If
                End If

                pros = 0

            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.OkOnly, "Konfirmasi")
            End Try

        End If


        grid1.DataSource = Nothing
        tfile.Text = ""
        ttottal.Text = 0
        tok.Text = 0
        tduplikasi.Text = 0
        tkesalahan.Text = 0
        list1.Items.Clear()

        Me.Close()

    End Sub

    Private Sub btsave_Click(sender As System.Object, e As System.EventArgs) Handles btsave.Click

        If pros = 1 Then

            Try

                sqltrans.Commit()

                If Not cn1 Is Nothing Then
                    If cn1.State = ConnectionState.Open Then
                        cn1.Close()
                    End If
                End If

                pros = 0

                MsgBox("Data Telah disimpan...", vbOKOnly + MsgBoxStyle.Information, "Informasi")

            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.OkOnly, "Konfirmasi")
            End Try

        Else
            MsgBox("Data belum diproses...", vbOKOnly, "Informasi")
        End If

    End Sub

End Class