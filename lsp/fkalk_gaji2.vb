Public Class fkalk_gaji2

    Private dv1 As DataView
    Private posi As Integer

    Sub New(ByVal dv As DataView, ByVal pos As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        dv1 = dv
        posi = pos
    End Sub

    Private Sub isi_box()

        tsupir.Text = dv1(posi)("NAMA").ToString

        tsemen.EditValue = CDbl(dv1(posi)("JML_SEMEN").ToString)
        tlain.EditValue = CDbl(dv1(posi)("JML_LAIN").ToString)
        ttot.EditValue = CDbl(dv1(posi)("TOT_GAJI").ToString)

        tpot.EditValue = CDbl(dv1(posi)("POT_KASBON").ToString)
        tket.Text = dv1(posi)("KETERANGAN").ToString

    End Sub

    Private Sub update_vw()

        dv1(posi)("POT_KASBON") = tpot.EditValue
        dv1(posi)("KETERANGAN") = tket.Text.Trim

    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub fkalk_gaji2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        tpot.Focus()
    End Sub

    Private Sub fkalk_gaji2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        isi_box()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        update_vw()
        Me.Close()

    End Sub

    Private Sub tpot_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tpot.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        End If
    End Sub

    Private Sub tket_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tket.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

End Class