Public Class Splash
    Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub labelControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles labelControl1.Click

    End Sub
End Class
