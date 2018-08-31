Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class sr_real

    Private ds As DataSet
    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView
    Private kriteria_cari As String
    Private plunasan_info As Boolean
    Private kd_toko As String

    Sub New(ByVal pencarian As String, ByVal plunasan As Boolean, ByVal kd_tok As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        kriteria_cari = pencarian
        plunasan_info = plunasan
        kd_toko = kd_tok

    End Sub

    Private Sub opendata()

        Dim cn As OracleConnection = Nothing
        Dim sql As String = ""

        If plunasan_info = False Then

            If get_stat_pusat() = 1 Then
                sql = "select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                    "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 order by b.TANGGAL desc"
            ElseIf get_stat_pusat() = 0 Then
                sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                    "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and b.kd_stat='{0}' order by b.TANGGAL desc", get_kode_stat)
            Else
                Exit Sub
            End If

        ElseIf plunasan_info = True Then

            If get_stat_pusat() = 1 Then
                sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_AKH - (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) as TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                    "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and b.TOT_AKH > (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) and b.KD_TOKO='{0}' order by b.TANGGAL desc", kd_toko)
            ElseIf get_stat_pusat() = 0 Then
                sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_AKH - (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) as TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                    "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and b.kd_stat='{0}' and b.TOT_AKH > (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) and b.KD_TOKO='{1}' order by b.TANGGAL desc", get_kode_stat, kd_toko)
            Else
                Exit Sub
            End If

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

        If plunasan_info = False Then


            If get_stat_pusat() = 1 Then


                Select Case cbkriteria.SelectedIndex
                    Case 0

                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and b.NODO like '%{0}%'  order by b.TANGGAL desc", tcari.Text.Trim.ToUpper)
                    Case 1

                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and c.NAMA_TOKO like '%{0}%'  order by b.TANGGAL desc", tcari.Text.Trim.ToUpper)
                    Case 2
                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and d.NAMA like '%{0}%'  order by b.TANGGAL desc", tcari.Text.Trim.ToUpper)
                    Case 3
                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and b.NOPOL like '%{0}%'  order by b.TANGGAL desc", tcari.Text.Trim.ToUpper)
                End Select

            ElseIf get_stat_pusat() = 0 Then

                Select Case cbkriteria.SelectedIndex
                    Case 0

                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and b.NODO like '%{0}%' and b.KD_STAT='{1}'  order by b.TANGGAL desc", tcari.Text.Trim.ToUpper, get_kode_stat)
                    Case 1

                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and c.NAMA_TOKO like '%{0}%' and b.KD_STAT='{1}'  order by b.TANGGAL desc", tcari.Text.Trim.ToUpper, get_kode_stat)
                    Case 2
                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and d.NAMA like '%{0}%' and b.KD_STAT='{1}'  order by b.TANGGAL desc", tcari.Text.Trim.ToUpper, get_kode_stat)
                    Case 3
                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and b.NOPOL like '%{0}%' and b.KD_STAT='{1}'  order by b.TANGGAL desc", tcari.Text.Trim.ToUpper, get_kode_stat)
                End Select

            Else
                Exit Sub
            End If


        ElseIf plunasan_info = True Then

            If get_stat_pusat() = 1 Then


                Select Case cbkriteria.SelectedIndex
                    Case 0

                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_AKH - (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) as TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and b.NODO like '%{0}%' and b.TOT_AKH > (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) and b.KD_TOKO='{1}'  order by b.TANGGAL desc", tcari.Text.Trim.ToUpper, kd_toko)
                    Case 1

                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_AKH - (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) as TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and c.NAMA_TOKO like '%{0}%' and  b.TOT_AKH >(b.TOT_BAYAR + b.TOT_BAYAR_GIRO) and b.KD_TOKO='{1}' order by b.TANGGAL desc", tcari.Text.Trim.ToUpper, kd_toko)
                    Case 2
                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_AKH - (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) as TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and d.NAMA like '%{0}%' and b.TOT_AKH > (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) and b.KD_TOKO='{1}' order by b.TANGGAL desc", tcari.Text.Trim.ToUpper, kd_toko)
                    Case 3
                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_AKH - (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) as TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and b.NOPOL like '%{0}%' and b.TOT_AKH > (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) and b.KD_TOKO='{1}' order by b.TANGGAL desc", tcari.Text.Trim.ToUpper, kd_toko)
                End Select

            ElseIf get_stat_pusat() = 0 Then

                Select Case cbkriteria.SelectedIndex
                    Case 0

                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_AKH - (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) as TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and b.NODO like '%{0}%' and b.KD_STAT='{1}' and b.TOT_AKH > (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) and b.KD_TOKO='{2}'  order by b.TANGGAL desc", tcari.Text.Trim.ToUpper, get_kode_stat, kd_toko)
                    Case 1

                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_AKH - (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) as TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and c.NAMA_TOKO like '%{0}%' and b.KD_STAT='{1}' and b.TOT_AKH > (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) and b.KD_TOKO='{2}' order by b.TANGGAL desc", tcari.Text.Trim.ToUpper, get_kode_stat, kd_toko)
                    Case 2
                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_AKH - (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) as TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and d.NAMA like '%{0}%' and b.KD_STAT='{1}' and b.TOT_AKH > (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) and b.KD_TOKO='{2}' order by b.TANGGAL desc", tcari.Text.Trim.ToUpper, get_kode_stat, kd_toko)
                    Case 3
                        sql = String.Format("select b.NODO,b.TANGGAL,d.NAMA as SUPIR,b.NOPOL,c.NAMA_TOKO,b.TOT_AKH - (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) as TOT_JML from admlsp.tr_real_order b inner join admlsp.ms_toko c on b.KD_TOKO=c.KD_TOKO " & _
                            "inner join admlsp.ms_supir d on b.KD_SUPIR=d.KD_SUPIR where rownum <= 500 and b.NOPOL like '%{0}%' and b.KD_STAT='{1}' and b.TOT_AKH > (b.TOT_BAYAR + b.TOT_BAYAR_GIRO) and b.KD_TOKO='{2}' order by b.TANGGAL desc", tcari.Text.Trim.ToUpper, get_kode_stat, kd_toko)
                End Select

            Else
                Exit Sub
            End If

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

    Public ReadOnly Property get_NODO As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("NODO").ToString
        End Get
    End Property

    Public ReadOnly Property get_HUTANG As Double
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If

            If plunasan_info = True Then
                Return dv1(Me.BindingContext(dv1).Position)("TOT_JML").ToString
            Else
                Return 0
            End If
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