Namespace lspclass
    Public Class user

        Private Property nama_user As String
        Private Property kodemenu As String
        Private Property add As String
        Private Property edit As String
        Private Property delete As String
        Private Property cetak As String

        Public Property m_nama_user() As String
            Get
                Return nama_user
            End Get

            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukkan nama user")
                End If
                nama_user = value
            End Set
        End Property

        Public Property m_kodemenu() As String
            Get
                Return kodemenu
            End Get

            Set(ByVal value As String)
                kodemenu = value
            End Set
        End Property

        Public Property m_add() As String
            Get
                Return add
            End Get

            Set(ByVal value As String)
                add = value
            End Set
        End Property

        Public Property m_edit() As String
            Get
                Return edit
            End Get

            Set(ByVal value As String)
                edit = value
            End Set
        End Property

        Public Property m_delete() As String
            Get
                Return delete
            End Get

            Set(ByVal value As String)
                delete = value
            End Set
        End Property

        Public Property m_cetak() As String
            Get
                Return cetak
            End Get

            Set(ByVal value As String)
                cetak = value
            End Set
        End Property

    End Class
End Namespace
