Public Class tr_inv3 

    Private posi As Integer = 0
    Private dv As DataView
    Private editstat As Boolean = False

    Sub New(ByVal edits As Boolean, ByVal dvi As DataView, ByVal ps As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        editstat = edits
        dv = dvi
        dv.Sort = "NAMA_BARANG"
        posi = ps


    End Sub

    Private Sub isi_box()

        tbar.Text = dv(posi)("NAMA_BARANG").ToString
        tsatuan.EditValue = dv(posi)("SATUAN").ToString
        tjml.EditValue = dv(posi)("JML").ToString
        tharga.EditValue = dv(posi)("HARGA").ToString
        ttot.EditValue = dv(posi)("TOT_HARGA").ToString

    End Sub

    Private Sub tbar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbar.KeyDown
        If e.KeyCode = 13 Then
            tsatuan.Focus()
        End If
    End Sub

    Private Sub tsatuan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsatuan.KeyDown
        If e.KeyCode = 13 Then
            tjml.Focus()
        End If
    End Sub

    Private Sub tjml_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tjml.KeyDown
        If e.KeyCode = 13 Then
            tharga.Focus()
        End If
    End Sub

    Private Sub tharga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tharga.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub manipulate()

        If editstat = False Then

            Dim no_sr As Integer = -1
            no_sr = dv.Find(tbar.Text.Trim)

            If no_sr = -1 Then

                Dim orow As DataRow = dv.Table.NewRow

                orow("NAMA_BARANG") = tbar.Text.Trim
                orow("JML") = tjml.EditValue
                orow("SATUAN") = tsatuan.Text
                orow("HARGA") = tharga.EditValue
                orow("TOT_HARGA") = ttot.EditValue

                dv.Table.Rows.Add(orow)

                Me.Close()

            Else
                MsgBox("Barang sudah ada dalam daftar", MsgBoxStyle.Information, "Informasi")
                tbar.Focus()
            End If

        Else

            dv(posi)("JML") = tjml.EditValue
            dv(posi)("SATUAN") = tsatuan.Text
            dv(posi)("HARGA") = tharga.EditValue
            dv(posi)("TOT_HARGA") = ttot.EditValue

            Me.Close()

        End If



    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub t_inv3_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If editstat = True Then
            tsatuan.Focus()
        Else
            ' tjml.EditValue = 0
            tbar.Focus()
        End If
    End Sub

    Private Sub t_inv3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If editstat = True Then

            tbar.Properties.ReadOnly = False
            btsimpan.Text = "&Rubah"

            isi_box()

        Else
            tbar.Properties.ReadOnly = False
            btsimpan.Text = "&Tambah"
        End If

    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tbar.Text = "" Then

            MsgBox("Barang tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tbar.Focus()
            Exit Sub

        End If

        If tsatuan.Text = "" Then

            MsgBox("Satuan tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tsatuan.Focus()
            Exit Sub

        End If

        If tjml.EditValue = 0 Then

            MsgBox("Jml barang tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tjml.Focus()
            Exit Sub

        End If

        If tharga.EditValue = 0 Then

            MsgBox("Harga Barang tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tharga.Focus()
            Exit Sub

        End If

        manipulate()

    End Sub

    Private Sub tjml_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tjml.EditValueChanged, tharga.EditValueChanged

        ttot.EditValue = tjml.EditValue * tharga.EditValue

    End Sub
End Class