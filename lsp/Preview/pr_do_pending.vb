Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_do_pending

    Private tgl1 As Date
    Private tgl2 As Date
    Private kode_area As String
    Private nama_area As String
    Private kd_princp As String
    Private nama_princp As String
    Private kd_toko As String
    Private nama_toko As String

    Sub New(ByVal ttgl1 As Date, ByVal ttgl2 As Date, ByVal kode_areas As String, ByVal nama_areas As String, ByVal kd_pri As String, ByVal nama_pri As String, ByVal kd_tok As String, ByVal nama_tok As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        tgl1 = ttgl1
        tgl2 = ttgl2
        kode_area = kode_areas
        nama_area = nama_areas
        kd_princp = kd_pri
        nama_princp = nama_pri
        kd_toko = kd_tok
        nama_toko = nama_tok

    End Sub

    Private Sub open_data()

        Dim ds As DataSet = Nothing
        Dim cn As OracleConnection = Nothing
        Dim sql As String = ""

        sql = String.Format("SELECT V_DO_PENDING.NO_BUKTI, V_DO_PENDING.TANGGAL, V_DO_PENDING.PRINCIPAL, V_DO_PENDING.NAMA_SUPIR, V_DO_PENDING.NAMA_TOKO, V_DO_PENDING.TOT_JML, V_DO_PENDING.TOT_HARGA, V_DO_PENDING.NOPOL, V_DO_PENDING.KETERANGAN " & _
                "FROM   ADMLSP.V_DO_PENDING V_DO_PENDING " & _
                "WHERE V_DO_PENDING.TANGGAL >='{0}' and V_DO_PENDING.TANGGAL <='{1}' ", convert_date_to_eng(tgl1), convert_date_to_eng(tgl2))

        If Not (kode_area.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_DO_PENDING.KD_STAT='{0}'", kode_area)
        End If

        If Not (kd_princp.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_DO_PENDING.KD_PRC='{0}'", kd_princp)
        End If

        If Not (kd_toko.Trim.Length = 0) Then
            sql = String.Format(sql & " AND V_DO_PENDING.KD_TOKO='{0}'", kd_toko)
        End If

        sql = String.Format(sql & " {0}", "ORDER BY V_DO_PENDING.PRINCIPAL")


        Try

            ' open_wait()

            cn = classmy.open_conn_utama


            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

            Dim objRpt As New r_do_pending
            classmy.open_CnReport(objRpt)

            objRpt.SetDataSource(ds.Tables(0))

            Dim area_print As String

            If Not (kode_area.ToUpper = "ALL") Then
                area_print = String.Format("Area : {0}", nama_area)
            Else
                area_print = String.Format("Area : {0}", "All Area")
            End If

            Dim userprint As String = String.Format("User Print : {0}", userprog)
            Dim periode As String = String.Format("Periode Tanggal : {0} s/d {1}", convert_date_to_ind(tgl1), convert_date_to_ind(tgl2))

            objRpt.SetParameterValue(0, periode)
            objRpt.SetParameterValue(1, userprint)
            objRpt.SetParameterValue(2, area_print)

            crv1.ReportSource = objRpt
            crv1.Refresh()

            ' close_wait()

        Catch ex As OracleException
            ' close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try


    End Sub

    Private Sub pr_do_pending_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        open_data()

    End Sub

End Class