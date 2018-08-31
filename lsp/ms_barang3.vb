Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class ms_barang3

    Private posi As Integer = 0
    Private dv As DataView
    Private dv1 As DataView
    Private editstat As Boolean = False

    Sub New(ByVal edits As Boolean, ByVal dvi As DataView, ByVal ps As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        editstat = edits
        dv = dvi
        dv.Sort = "KD_KAB"
        posi = ps

    End Sub

    Private Sub isi_box()

        tkodekab.Text = dv(posi)("KD_KAB").ToString
        tnamakab.Text = dv(posi)("NAMA").ToString
        tjml.EditValue = CDbl(dv(posi)("HARGA").ToString)

    End Sub

    Private Sub tkodekab_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkodekab.KeyDown
        If e.KeyCode = 13 Then
            tjml.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'tnamatok.Text.Trim
            tkodekab.Text = ""
            tnamakab.Text = ""

            Using fcari As New sr_kab(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkodekab.Text = fcari.get_KODE
                tnamakab.Text = fcari.get_NAMA

            End Using

        End If
    End Sub

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfindsal.Click

        Dim cari As String = "" 'tnamatok.Text.Trim

        Using fcari As New sr_kab(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkodekab.Text = fcari.get_KODE
            tnamakab.Text = fcari.get_NAMA

            If tkodekab.Text.Length > 0 Then
                tnama_toko_Validating(sender, Nothing)
            End If


        End Using


    End Sub

    Private Sub tnama_toko_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkodekab.Validating

        If tkodekab.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            sql = String.Format("select a.KODE,a.NAMA from admlsp.ms_kab a inner join admlsp.ms_prop b on a.KODE_PROP=b.KODE WHERE a.KODE='{0}'", tkodekab.Text.Trim)
        

        Try

            cn = classmy.open_conn_utama
            comd = New OracleCommand(Sql, cn)
            dred = comd.ExecuteReader

            If dred.Read Then

                    tkodekab.Text = dred(0).ToString
                    tnamakab.Text = dred(1).ToString
                
                dred.Close()

            Else

                dred.Close()
                    MsgBox("Kabupaten tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                e.Cancel = True
                    tkodekab.Focus()
                    tnamakab.Text = ""

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

            tkodekab.Text = ""
            tnamakab.Text = ""
        
        End If


    End Sub

    Private Sub tjml_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tjml.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub manipulate()

        If editstat = False Then

            Dim no_sr As Integer = -1
            no_sr = dv.Find(tkodekab.EditValue)

            If no_sr = -1 Then

                Dim orow As DataRow = dv.Table.NewRow

                orow("KD_KAB") = tkodekab.EditValue
                orow("NAMA") = tnamakab.Text.Trim
                orow("HARGA") = tjml.EditValue

                dv.Table.Rows.Add(orow)

                Me.Close()

            Else
                MsgBox("Kabupaten sudah ada dalam daftar", MsgBoxStyle.Information, "Informasi")
                tkodekab.Focus()
            End If

        Else

            dv(posi)("HARGA") = tjml.EditValue
            Me.Close()

        End If



    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub t_KASout3_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If editstat = True Then
            tjml.Focus()
        Else
            ' tjml.EditValue = 0
            tkodekab.Focus()
        End If
    End Sub

    Private Sub t_spare_out3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If editstat = True Then

            tkodekab.Enabled = False
            btfindsal.Enabled = False
            btsimpan.Text = "&Rubah"

            isi_box()

        Else
            tkodekab.Enabled = True
            btfindsal.Enabled = True
            btsimpan.Text = "&Tambah"
        End If

    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tkodekab.EditValue = "" Then

            MsgBox("Kabupaten tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tkodekab.Focus()
            Exit Sub

        End If


        If tjml.EditValue = 0 Then

            MsgBox("Harga tebusan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tjml.Focus()
            Exit Sub

        End If

        manipulate()

    End Sub

End Class