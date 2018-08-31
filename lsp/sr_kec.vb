Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class sr_kec

    Private ds As DataSet
    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView
    Private kriteria_cari As String

    Sub New(ByVal pencarian As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        kriteria_cari = pencarian

    End Sub

    Private Sub opendata()

        Dim cn As OracleConnection = Nothing
        Dim sql As String = ""


        sql = "select b.NAMA as KABUPATEN,A.KODE,A.NAMA from admlsp.ms_kec a inner join admlsp.ms_kab b on a.KODE_KAB=b.KODE ORDER BY B.NAMA ASC"

        grid1.DataSource = Nothing


        Try

            open_wait()

            dv1 = Nothing

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            grid1.DataSource = dv1

            close_wait()

        Catch ex As OracleException
            close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally


            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

    End Sub

    Private Sub cari()

        Dim cn As OracleConnection = Nothing

        grid1.DataSource = Nothing

        Dim sql As String = ""


        Select Case cbkriteria.SelectedIndex
            Case 0
                sql = String.Format("select b.NAMA as KABUPATEN,A.KODE,A.NAMA from admlsp.ms_kec a inner join admlsp.ms_kab b on a.KODE_KAB=b.KODE WHERE A.KODE LIKE '%{0}%' ORDER BY B.NAMA ASC", tcari.Text.Trim.ToUpper)
            Case 1
                sql = String.Format("select b.NAMA as KABUPATEN,A.KODE,A.NAMA from admlsp.ms_kec a inner join admlsp.ms_kab b on a.KODE_KAB=b.KODE WHERE A.NAMA LIKE '%{0}%' ORDER BY B.NAMA ASC", tcari.Text.Trim.ToUpper)
        End Select


        Try

            open_wait()

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            grid1.DataSource = dv1

            close_wait()

        Catch ex As Exception
            close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Public ReadOnly Property get_KODE As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("KODE").ToString
        End Get
    End Property

    Public ReadOnly Property get_NAMA As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("NAMA").ToString
        End Get
    End Property

    Private Sub tcari_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tcari.KeyDown
        If e.KeyCode = 13 Then

            If dv1.Count <= 0 Then
                Exit Sub
            End If

            Me.Close()

        End If
    End Sub

    Private Sub tcari_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tcari.KeyUp
        cari()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click

        If dv1.Count <= 0 Then
            Exit Sub
        End If


        Me.Close()

    End Sub

    Private Sub grid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grid1.DoubleClick

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Me.Close()

    End Sub

    Private Sub sr_toko_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        tcari.Focus()
    End Sub

    Private Sub sr_supir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        cbkriteria.SelectedIndex = 1

        If kriteria_cari = "" Then
            opendata()
        Else
            tcari.Text = kriteria_cari
            cari()
        End If
    End Sub

End Class