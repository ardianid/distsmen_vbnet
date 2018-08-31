Imports System.Xml
Imports System.IO
Imports System.Text
Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client
Imports System.Security.Cryptography


Public Class tr_eks

    'Private Shared Sub d()(ByVal S As String, ByVal sPath As String)

    '    Dim byteKey As Byte() = System.Text.Encoding.UTF8.GetBytes("B499F4BF48242E05548D1E4C8BB26A2E")
    '    Dim byteIV As Byte() = System.Text.Encoding.UTF8.GetBytes(",%u'm&'CXSy/T7x;4")

    '    Dim vFile As FileStream = New IO.FileStream(sPath, FileMode.Create)
    '    Dim vCrypto As New CryptoStream(vFile, (New RijndaelManaged()).CreateEncryptor(byteKey, byteIV), CryptoStreamMode.Write)
    '    Dim vTextWriter As New StreamWriter(vCrypto, Encoding.Unicode)

    '    vTextWriter.Write(S)
    '    vTextWriter.Flush()

    '    vTextWriter.Close()
    '    vCrypto.Close()
    '    vFile.Close()
    'End Sub

    Private Sub parsing_nama()

        If ttgl.Text.ToString.Trim.Length < 10 Then
            Exit Sub
        End If

        If ttgl2.Text.ToString.Trim.Length < 10 Then
            Exit Sub
        End If

        If Not IsDate(ttgl.Text) Then
            Exit Sub
        End If

        If Not IsDate(ttgl2.Text) Then
            Exit Sub
        End If

        Dim tgl1, month1, year1 As String
        Dim tgl2, month2, year2 As String

        tgl1 = DateValue(ttgl.EditValue).Day

        If tgl1.Length = 1 Then
            tgl1 = String.Format("0{0}", tgl1)
        End If

        month1 = DateValue(ttgl.EditValue).Month

        If month1.Length = 1 Then
            month1 = String.Format("0{0}", month1)
        End If

        year1 = ttgl.EditValue.ToString.Substring(8, 2)

        tgl2 = DateValue(ttgl2.EditValue).Day

        If tgl2.Length = 1 Then
            tgl2 = String.Format("0{0}", tgl2)
        End If

        month2 = DateValue(ttgl2.EditValue).Month

        If month2.Length = 1 Then
            month2 = String.Format("0{0}", month2)
        End If

        year2 = ttgl2.EditValue.ToString.Substring(8, 2)

        tnmfile.Text = String.Format("{0}{1}{2}-{3}{4}{5}", tgl1, month1, year1, tgl2, month2, year2)

    End Sub

    Private Sub proses_data()

        Dim cn As OracleConnection = Nothing
        Dim ds As New DataSet

        Dim sql As String = String.Format("select a.NO_ID,a.JUSER,a.JTABEL,a.TANGGAL,a.JTRANS,a.SCRIPT,a.KEY_NUM,a.JTRANS_APL,'-' AS STAT from admlsp.tm_user a where to_date(a.TANGGAL,'DD-Mon-YY') >='{0}' and to_date(a.TANGGAL,'DD-Mon-YY') <='{1}' order by a.NO_ID,a.TANGGAL asc", convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue))

        Try

            open_wait()

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = classmy.GetDataSet(sql, cn)
            ds.Tables(0).TableName = "Exp"

            Dim path2 As String = String.Empty

            If Not tfolder.Text.Trim.Substring(Len(tfolder.Text.Trim) - 1, 1) = "\" Then
                tfolder.Text = String.Format("{0}\", tfolder.Text.Trim)
            End If

            path2 = String.Format("{0}{1}.xml", Trim(tfolder.Text), Trim(tnmfile.Text))

            ds.WriteXml(path2)

            close_wait()
            MsgBox("Export data selesai...", MsgBoxStyle.Information, "Informasi")

        Catch ex As Exception
            close_wait()
            MsgBox(ex.ToString, "Informasi", "Konfirmasi")
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click

        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog

        ' Descriptive text displayed above the tree view control in the dialog box
        MyFolderBrowser.Description = "Select the Folder"

        ' Sets the root folder where the browsing starts from
        'MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyDocuments

        ' Do not show the button for new folder
        MyFolderBrowser.ShowNewFolderButton = True

        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then
            tfolder.Text = MyFolderBrowser.SelectedPath
        End If

    End Sub

    Private Sub tr_eks_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ttgl.Focus()
    End Sub

    Private Sub tr_eks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ttgl.EditValue = Date.Now
        ttgl2.EditValue = Date.Now

        ttgl_Validating(sender, Nothing)
        ttgl2_Validating(sender, Nothing)

    End Sub

    Private Sub ttgl_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ttgl.Validating
        parsing_nama()
    End Sub

    Private Sub ttgl2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ttgl2.Validating
        parsing_nama()
    End Sub

    Private Sub btpros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpros.Click

        If tfolder.Text.Trim.Length = 0 Then
            MsgBox("Pastikan dahulu letak file...", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        End If

        proses_data()

    End Sub
End Class