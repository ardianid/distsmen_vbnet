Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class sr_pre_release

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

        If get_stat_pusat() = 1 Then
            sql = "SELECT A.NO_BUKTI,A.TANGGAL,B.NAMA,C.NAMA_TOKO,A.NOPOL,A.TOT_JML,A.KD_SUPIR,A.NAMA_SUPIR,A.KD_TOKO,C.ALAMAT AS ALAMAT_TOKO,C.KD_SALES,D.NAMA AS NAMA_SALES FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL B ON A.KD_PRC=B.KD_PRC " & _
                        "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO INNER JOIN ADMLSP.MS_SALES D ON C.KD_SALES=D.KD_SALES WHERE ROWNUM <= 500 And A.TOT_JML > A.JML_DATANG ORDER BY A.TANGGAL ASC"
        ElseIf get_stat_pusat() = 0 Then
            sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,B.NAMA,C.NAMA_TOKO,A.NOPOL,A.TOT_JML,A.KD_SUPIR,A.NAMA_SUPIR,A.KD_TOKO,C.ALAMAT AS ALAMAT_TOKO,C.KD_SALES,D.NAMA AS NAMA_SALES FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL B ON A.KD_PRC=B.KD_PRC " & _
                        "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO INNER JOIN ADMLSP.MS_SALES D ON C.KD_SALES=D.KD_SALES WHERE ROWNUM <= 500 And A.TOT_JML > A.JML_DATANG AND A.KD_STAT='{0}' ORDER BY A.TANGGAL ASC", get_kode_stat)
        Else
            Exit Sub
        End If

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

        If get_stat_pusat() = 1 Then

            Select Case cbkriteria.SelectedIndex
                Case 0 ' no bukti
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,B.NAMA,C.NAMA_TOKO,A.NOPOL,A.TOT_JML,A.KD_SUPIR,A.NAMA_SUPIR,A.KD_TOKO,C.ALAMAT AS ALAMAT_TOKO,C.KD_SALES,D.NAMA AS NAMA_SALES FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL B ON A.KD_PRC=B.KD_PRC " & _
                        "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO INNER JOIN ADMLSP.MS_SALES D ON C.KD_SALES=D.KD_SALES WHERE ROWNUM <= 500 And A.TOT_JML > A.JML_DATANG AND A.NO_BUKTI LIKE '%{0}%' ORDER BY A.TANGGAL ASC", tcari.Text.Trim.ToUpper)
                Case 1 ' principal
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,B.NAMA,C.NAMA_TOKO,A.NOPOL,A.TOT_JML,A.KD_SUPIR,A.NAMA_SUPIR,A.KD_TOKO,C.ALAMAT AS ALAMAT_TOKO,C.KD_SALES,D.NAMA AS NAMA_SALES FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL B ON A.KD_PRC=B.KD_PRC " & _
                        "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO INNER JOIN ADMLSP.MS_SALES D ON C.KD_SALES=D.KD_SALES WHERE ROWNUM <= 500 And A.TOT_JML > A.JML_DATANG AND B.NAMA LIKE '%{0}%' ORDER BY A.TANGGAL ASC", tcari.Text.Trim.ToUpper)
                Case 2 ' nama toko
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,B.NAMA,C.NAMA_TOKO,A.NOPOL,A.TOT_JML,A.KD_SUPIR,A.NAMA_SUPIR,A.KD_TOKO,C.ALAMAT AS ALAMAT_TOKO,C.KD_SALES,D.NAMA AS NAMA_SALES FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL B ON A.KD_PRC=B.KD_PRC " & _
                        "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO INNER JOIN ADMLSP.MS_SALES D ON C.KD_SALES=D.KD_SALES WHERE ROWNUM <= 500 And A.TOT_JML > A.JML_DATANG AND C.NAMA_TOKO LIKE '%{0}%' ORDER BY A.TANGGAL ASC", tcari.Text.Trim.ToUpper)
                Case 3 ' nopol
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,B.NAMA,C.NAMA_TOKO,A.NOPOL,A.TOT_JML,A.KD_SUPIR,A.NAMA_SUPIR,A.KD_TOKO,C.ALAMAT AS ALAMAT_TOKO,C.KD_SALES,D.NAMA AS NAMA_SALES FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL B ON A.KD_PRC=B.KD_PRC " & _
                        "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO INNER JOIN ADMLSP.MS_SALES D ON C.KD_SALES=D.KD_SALES WHERE ROWNUM <= 500 And A.TOT_JML > A.JML_DATANG AND A.NOPOL LIKE '%{0}%' ORDER BY A.TANGGAL ASC", tcari.Text.Trim.ToUpper)
            End Select

        ElseIf get_stat_pusat() = 0 Then

            Select Case cbkriteria.SelectedIndex
                Case 0 ' no bukti
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,B.NAMA,C.NAMA_TOKO,A.NOPOL,A.TOT_JML,A.KD_SUPIR,A.NAMA_SUPIR,A.KD_TOKO,C.ALAMAT AS ALAMAT_TOKO,C.KD_SALES,D.NAMA AS NAMA_SALES FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL B ON A.KD_PRC=B.KD_PRC " & _
                        "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO INNER JOIN ADMLSP.MS_SALES D ON C.KD_SALES=D.KD_SALES WHERE ROWNUM <= 500 And A.TOT_JML > A.JML_DATANG AND A.NO_BUKTI LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL ASC", tcari.Text.Trim.ToUpper, get_kode_stat)
                Case 1 ' principal
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,B.NAMA,C.NAMA_TOKO,A.NOPOL,A.TOT_JML,A.KD_SUPIR,A.NAMA_SUPIR,A.KD_TOKO,C.ALAMAT AS ALAMAT_TOKO,C.KD_SALES,D.NAMA AS NAMA_SALES FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL B ON A.KD_PRC=B.KD_PRC " & _
                        "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO INNER JOIN ADMLSP.MS_SALES D ON C.KD_SALES=D.KD_SALES WHERE ROWNUM <= 500 And A.TOT_JML > A.JML_DATANG AND B.NAMA LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL ASC", tcari.Text.Trim.ToUpper, get_kode_stat)
                Case 2 ' nama toko
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,B.NAMA,C.NAMA_TOKO,A.NOPOL,A.TOT_JML,A.KD_SUPIR,A.NAMA_SUPIR,A.KD_TOKO,C.ALAMAT AS ALAMAT_TOKO,C.KD_SALES,D.NAMA AS NAMA_SALES FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL B ON A.KD_PRC=B.KD_PRC " & _
                        "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO INNER JOIN ADMLSP.MS_SALES D ON C.KD_SALES=D.KD_SALES WHERE ROWNUM <= 500 And A.TOT_JML > A.JML_DATANG AND C.NAMA_TOKO LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL ASC", tcari.Text.Trim.ToUpper, get_kode_stat)
                Case 3 ' nopol
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,B.NAMA,C.NAMA_TOKO,A.NOPOL,A.TOT_JML,A.KD_SUPIR,A.NAMA_SUPIR,A.KD_TOKO,C.ALAMAT AS ALAMAT_TOKO,C.KD_SALES,D.NAMA AS NAMA_SALES FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL B ON A.KD_PRC=B.KD_PRC " & _
                        "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO INNER JOIN ADMLSP.MS_SALES D ON C.KD_SALES=D.KD_SALES WHERE ROWNUM <= 500 And A.TOT_JML > A.JML_DATANG AND A.NOPOL LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL ASC", tcari.Text.Trim.ToUpper, get_kode_stat)
            End Select

        Else
            Exit Sub
        End If


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

    Public ReadOnly Property get_NOBUKTI As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("NO_BUKTI").ToString
        End Get
    End Property

    Public ReadOnly Property get_INFO As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If

            Dim info As String = String.Format("{0} {1}", CType(dv1(Me.BindingContext(dv1).Position)("TANGGAL").ToString, Date) & Environment.NewLine, dv1(Me.BindingContext(dv1).Position)("NAMA").ToString)

            Return info
        End Get
    End Property

    Public ReadOnly Property get_KD_SUPIR As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("KD_SUPIR").ToString
        End Get
    End Property

    Public ReadOnly Property get_NAMA_SUPIR As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("NAMA_SUPIR").ToString
        End Get
    End Property

    Public ReadOnly Property get_NOPOL As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("NOPOL").ToString
        End Get
    End Property

    Public ReadOnly Property get_KdToko As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("KD_TOKO").ToString
        End Get
    End Property

    Public ReadOnly Property get_NAMATOKO As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("NAMA_TOKO").ToString
        End Get
    End Property

    Public ReadOnly Property get_ALAMATTOKO As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("ALAMAT_TOKO").ToString
        End Get
    End Property

    Public ReadOnly Property get_KDSALES As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("KD_SALES").ToString
        End Get
    End Property

    Public ReadOnly Property get_NAMASALES As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("NAMA_SALES").ToString
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

    Private Sub sr_toko_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        cbkriteria.SelectedIndex = 0

        If kriteria_cari = "" Then
            opendata()
        Else
            tcari.Text = kriteria_cari
            cari()
        End If

    End Sub

End Class