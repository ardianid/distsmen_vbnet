Public Class fsl_track 

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click
        If TextEdit1.Text.Trim.Length = 0 Then
            MsgBox("No-DO yang akan dicari tidak boleh kosong..", vbOKOnly + MsgBoxStyle.Critical, "Konfirmasi")
            TextEdit1.Focus()
            Exit Sub
        End If

        Dim fpr_kso_Detail As New pr_track(TextEdit1.Text.Trim.ToUpper) With {.WindowState = FormWindowState.Maximized}
        fpr_kso_Detail.Show()

    End Sub

    Private Sub fsl_track_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TextEdit1.Focus()
    End Sub

    Private Sub TextEdit1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextEdit1.KeyDown
        If e.KeyCode = 13 Then
            btpre_Click(sender, Nothing)
        End If

    End Sub
End Class