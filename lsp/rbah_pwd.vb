Imports Oracle.DataAccess.Client
Imports lsp.lspclass

Public Class rbah_pwd

    Private Sub rubah_password()

        Dim cmd As OracleCommand
        Dim cn As OracleConnection = Nothing


        Try

            cn = classmy.open_conn

            cmd = New OracleCommand With {.CommandType = CommandType.StoredProcedure, .CommandText = "ADMLSP.ALT_ADDU", .Connection = cn}
            cmd.Parameters.Add("nme", OracleDbType.Varchar2).Value = tuser.Text.Trim.ToUpper
            cmd.Parameters.Add("pwd_new", OracleDbType.Varchar2).Value = tpwd.Text.Trim.ToUpper

            cmd.ExecuteNonQuery()

            MsgBox("Password telah dirubah", MsgBoxStyle.Information, "Informasi")
            Me.Close()

        Catch ex As OracleException
            MsgBox(ex.Message, MsgBoxStyle.Information, "Informasi")
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try
        

    End Sub


    Private Sub rbah_pwd_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        tpwd.Focus()
    End Sub

    Private Sub rbah_pwd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        tuser.Text = userprog

    End Sub

    Private Sub tpwd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tpwd.KeyDown
        If e.KeyCode = 13 Then
            tpwd2.Focus()
        End If
    End Sub

    Private Sub tpwd2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tpwd2.KeyDown
        If e.KeyCode = 13 Then
            btmasuk.PerformClick()
        End If
    End Sub

    Private Sub btbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btbatal.Click
        Me.Close()
    End Sub

    Private Sub btmasuk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmasuk.Click

        If tpwd.Text = "" Then
            MsgBox("Password tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tpwd.Focus()
            Exit Sub
        End If

        If tpwd2.Text = "" Then
            MsgBox("Verifikasi password tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tpwd2.Focus()
            Exit Sub
        End If

        If Not tpwd.Text.Equals(tpwd2.Text) Then

            MsgBox("Password dan verifikasi password tidak sama", MsgBoxStyle.Information, "Informasi")
            tpwd.Focus()
            Exit Sub
        End If

        rubah_password()

    End Sub
End Class