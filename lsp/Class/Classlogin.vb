Namespace lspclass
    Public Class Classlogin


        Private nama As String
        Public Property m_nama_user() As String
            Get
                Return nama
            End Get

            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukkan nama user")
                End If
                nama = value
            End Set
        End Property

        Private pwd As String
        Public Property m_pwd() As String
            Get
                Return pwd
            End Get

            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukkan nama user")
                End If
                pwd = value
            End Set
        End Property


    End Class
End Namespace