Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class sr_pre_ujlan

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
            sql = "SELECT tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal,ms_toko.nama_toko, ms_supir.nama as nama_supir, tr_real_order.tot_jml,tr_real_order.kd_stat,(tr_pre.REAL_UANG_JLN - tr_pre.UANG_JLN_CAIR) as UANG_JLN " & _
                    "FROM ADMLSP.tr_pre, ADMLSP.tr_real_order, ADMLSP.ms_toko, ADMLSP.ms_supir " & _
                    "WHERE tr_pre.no_bukti = tr_real_order.kd_pre " & _
                    "AND tr_real_order.kd_toko = ms_toko.kd_toko " & _
                    "AND tr_real_order.kd_supir = ms_supir.kd_supir " & _
                    "AND rownum <= 500 " & _
                    "AND tr_pre.UANG_JLN_CAIR < tr_pre.REAL_UANG_JLN " & _
                    "ORDER BY tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal desc"


        ElseIf get_stat_pusat() = 0 Then
            sql = String.Format("SELECT tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal,ms_toko.nama_toko, ms_supir.nama as nama_supir, tr_real_order.tot_jml,tr_real_order.kd_stat,(tr_pre.REAL_UANG_JLN - tr_pre.UANG_JLN_CAIR) as UANG_JLN " & _
                    "FROM ADMLSP.tr_pre, ADMLSP.tr_real_order, ADMLSP.ms_toko, ADMLSP.ms_supir " & _
                    "WHERE tr_pre.no_bukti = tr_real_order.kd_pre " & _
                    "AND tr_real_order.kd_toko = ms_toko.kd_toko " & _
                    "AND tr_real_order.kd_supir = ms_supir.kd_supir " & _
                    "AND rownum <= 500 " & _
                    "AND tr_pre.UANG_JLN_CAIR < tr_pre.REAL_UANG_JLN AND tr_real_order.KD_STAT='{0}' " & _
                    "ORDER BY tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal desc", get_kode_stat)
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
                    sql = String.Format("SELECT tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal,ms_toko.nama_toko, ms_supir.nama as nama_supir, tr_real_order.tot_jml,tr_real_order.kd_stat,(tr_pre.REAL_UANG_JLN - tr_pre.UANG_JLN_CAIR) as UANG_JLN " & _
                    "FROM ADMLSP.tr_pre, ADMLSP.tr_real_order, ADMLSP.ms_toko, ADMLSP.ms_supir " & _
                    "WHERE tr_pre.no_bukti = tr_real_order.kd_pre " & _
                    "AND tr_real_order.kd_toko = ms_toko.kd_toko " & _
                    "AND tr_real_order.kd_supir = ms_supir.kd_supir " & _
                    "AND rownum <= 500 " & _
                    "AND tr_pre.UANG_JLN_CAIR < tr_pre.REAL_UANG_JLN AND tr_pre.NO_BUKTI like '%{0}%' ORDER BY tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal desc", tcari.Text.Trim.ToUpper)
                Case 1 ' nodo
                    sql = String.Format("SELECT tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal,ms_toko.nama_toko, ms_supir.nama as nama_supir, tr_real_order.tot_jml,tr_real_order.kd_stat,(tr_pre.REAL_UANG_JLN - tr_pre.UANG_JLN_CAIR) as UANG_JLN " & _
                    "FROM ADMLSP.tr_pre, ADMLSP.tr_real_order, ADMLSP.ms_toko, ADMLSP.ms_supir " & _
                    "WHERE tr_pre.no_bukti = tr_real_order.kd_pre " & _
                    "AND tr_real_order.kd_toko = ms_toko.kd_toko " & _
                    "AND tr_real_order.kd_supir = ms_supir.kd_supir " & _
                    "AND rownum <= 500 " & _
                    "AND tr_pre.UANG_JLN_CAIR < tr_pre.REAL_UANG_JLN AND tr_real_order.NODO like '%{0}%' ORDER BY tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal desc", tcari.Text.Trim.ToUpper)
                Case 2 ' nama toko
                    sql = String.Format("SELECT tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal,ms_toko.nama_toko, ms_supir.nama as nama_supir, tr_real_order.tot_jml,tr_real_order.kd_stat,(tr_pre.REAL_UANG_JLN - tr_pre.UANG_JLN_CAIR) as UANG_JLN " & _
                    "FROM ADMLSP.tr_pre, ADMLSP.tr_real_order, ADMLSP.ms_toko, ADMLSP.ms_supir " & _
                    "WHERE tr_pre.no_bukti = tr_real_order.kd_pre " & _
                    "AND tr_real_order.kd_toko = ms_toko.kd_toko " & _
                    "AND tr_real_order.kd_supir = ms_supir.kd_supir " & _
                    "AND rownum <= 500 " & _
                    "AND tr_pre.UANG_JLN_CAIR < tr_pre.REAL_UANG_JLN AND ms_toko.NAMA_TOKO like '%{0}%' ORDER BY tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal desc", tcari.Text.Trim.ToUpper)
                Case 3 ' supir
                    sql = String.Format("SELECT tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal,ms_toko.nama_toko, ms_supir.nama as nama_supir, tr_real_order.tot_jml,tr_real_order.kd_stat,(tr_pre.REAL_UANG_JLN - tr_pre.UANG_JLN_CAIR) as UANG_JLN " & _
                    "FROM ADMLSP.tr_pre, ADMLSP.tr_real_order, ADMLSP.ms_toko, ADMLSP.ms_supir " & _
                    "WHERE tr_pre.no_bukti = tr_real_order.kd_pre " & _
                    "AND tr_real_order.kd_toko = ms_toko.kd_toko " & _
                    "AND tr_real_order.kd_supir = ms_supir.kd_supir " & _
                    "AND rownum <= 500 " & _
                    "AND tr_pre.UANG_JLN_CAIR < tr_pre.REAL_UANG_JLN AND ms_supir.NAMA like '%{0}%' ORDER BY tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal desc", tcari.Text.Trim.ToUpper)
            End Select

        ElseIf get_stat_pusat() = 0 Then

            Select Case cbkriteria.SelectedIndex
                Case 0 ' no bukti
                    sql = String.Format("SELECT tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal,ms_toko.nama_toko, ms_supir.nama as nama_supir, tr_real_order.tot_jml,tr_real_order.kd_stat,(tr_pre.REAL_UANG_JLN - tr_pre.UANG_JLN_CAIR) as UANG_JLN " & _
                    "FROM ADMLSP.tr_pre, ADMLSP.tr_real_order, ADMLSP.ms_toko, ADMLSP.ms_supir " & _
                    "WHERE tr_pre.no_bukti = tr_real_order.kd_pre " & _
                    "AND tr_real_order.kd_toko = ms_toko.kd_toko " & _
                    "AND tr_real_order.kd_supir = ms_supir.kd_supir " & _
                    "AND rownum <= 500 " & _
                    "AND tr_pre.UANG_JLN_CAIR < tr_pre.REAL_UANG_JLN AND tr_pre.NO_BUKTI like '%{0}%' AND tr_real_order.KD_STAT='{1}' ORDER BY tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal desc", tcari.Text.Trim.ToUpper, get_kode_stat)
                Case 1 ' nodo
                    sql = String.Format("SELECT tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal,ms_toko.nama_toko, ms_supir.nama as nama_supir, tr_real_order.tot_jml,tr_real_order.kd_stat,(tr_pre.REAL_UANG_JLN - tr_pre.UANG_JLN_CAIR) as UANG_JLN " & _
                    "FROM ADMLSP.tr_pre, ADMLSP.tr_real_order, ADMLSP.ms_toko, ADMLSP.ms_supir " & _
                    "WHERE tr_pre.no_bukti = tr_real_order.kd_pre " & _
                    "AND tr_real_order.kd_toko = ms_toko.kd_toko " & _
                    "AND tr_real_order.kd_supir = ms_supir.kd_supir " & _
                    "AND rownum <= 500 " & _
                    "AND tr_pre.UANG_JLN_CAIR < tr_pre.REAL_UANG_JLN AND tr_real_order.NODO like '%{0}%' AND tr_real_order.KD_STAT='{1}' ORDER BY tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal desc", tcari.Text.Trim.ToUpper, get_kode_stat)
                Case 2 ' nama toko
                    sql = String.Format("SELECT tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal,ms_toko.nama_toko, ms_supir.nama as nama_supir, tr_real_order.tot_jml,tr_real_order.kd_stat,(tr_pre.REAL_UANG_JLN - tr_pre.UANG_JLN_CAIR) as UANG_JLN " & _
                    "FROM ADMLSP.tr_pre, ADMLSP.tr_real_order, ADMLSP.ms_toko, ADMLSP.ms_supir " & _
                    "WHERE tr_pre.no_bukti = tr_real_order.kd_pre " & _
                    "AND tr_real_order.kd_toko = ms_toko.kd_toko " & _
                    "AND tr_real_order.kd_supir = ms_supir.kd_supir " & _
                    "AND rownum <= 500 " & _
                    "AND tr_pre.UANG_JLN_CAIR < tr_pre.REAL_UANG_JLN AND ms_toko.NAMA_TOKO like '%{0}%' AND tr_real_order.KD_STAT='{1}' ORDER BY tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal desc", tcari.Text.Trim.ToUpper, get_kode_stat)
                Case 3 ' supir
                    sql = String.Format("SELECT tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal,ms_toko.nama_toko, ms_supir.nama as nama_supir, tr_real_order.tot_jml,tr_real_order.kd_stat,(tr_pre.REAL_UANG_JLN - tr_pre.UANG_JLN_CAIR) as UANG_JLN " & _
                    "FROM ADMLSP.tr_pre, ADMLSP.tr_real_order, ADMLSP.ms_toko, ADMLSP.ms_supir " & _
                    "WHERE tr_pre.no_bukti = tr_real_order.kd_pre " & _
                    "AND tr_real_order.kd_toko = ms_toko.kd_toko " & _
                    "AND tr_real_order.kd_supir = ms_supir.kd_supir " & _
                    "AND rownum <= 500 " & _
                    "AND tr_pre.UANG_JLN_CAIR < tr_pre.REAL_UANG_JLN AND ms_supir.NAMA like '%{0}%' AND tr_real_order.KD_STAT='{1}' ORDER BY tr_pre.no_bukti, tr_real_order.nodo, tr_real_order.tanggal desc", tcari.Text.Trim.ToUpper, get_kode_stat)
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

    Public ReadOnly Property get_UANGJALAN As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("UANG_JLN").ToString
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
            'tcari.Text = kriteria_cari
            cari()
        End If

    End Sub

End Class