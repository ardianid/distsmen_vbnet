Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_jual_beli_rekap
    Private tgl1 As Date
    Private tgl2 As Date
    Private kode_area As String
    Private nama_area As String
    Private kodekab As String
    Private semuajual As Boolean

    Sub New(ByVal ttgl1 As Date, ByVal ttgl2 As Date, ByVal kode_areas As String, ByVal nama_areas As String, ByVal kdkab As String, ByVal smjual As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        tgl1 = ttgl1
        tgl2 = ttgl2
        kode_area = kode_areas
        nama_area = nama_areas
        kodekab = kdkab
        semuajual = smjual

    End Sub

    Private Sub open_data()

        Dim ds As DataSet = Nothing
        Dim cn As OracleConnection = Nothing
        Dim sql As String = ""

        If semuajual = True Then

            sql = String.Format("SELECT V_SELISIH_HARGA_KAB2.KABUPATEN, V_SELISIH_HARGA_KAB2.HARGA_JUAL, V_SELISIH_HARGA_KAB2.HARGA_BELI, V_SELISIH_HARGA_KAB2.JML, V_SELISIH_HARGA_KAB2.NAMA_BARANG, V_SELISIH_HARGA_KAB2.TANGGAL, V_SELISIH_HARGA_KAB2.TGL_LUNAS, V_SELISIH_HARGA_KAB2.NODO " & _
                    "FROM   ADMLSP.V_SELISIH_HARGA_KAB2 V_SELISIH_HARGA_KAB2 " & _
                    "WHERE V_SELISIH_HARGA_KAB2.TANGGAL >='{0}' and V_SELISIH_HARGA_KAB2.TANGGAL <='{1}'", convert_date_to_eng(tgl1), convert_date_to_eng(tgl2))

            
        Else

            sql = String.Format("SELECT V_SELISIH_HARGA_KAB2.KABUPATEN, V_SELISIH_HARGA_KAB2.HARGA_JUAL, V_SELISIH_HARGA_KAB2.HARGA_BELI, V_SELISIH_HARGA_KAB2.JML, V_SELISIH_HARGA_KAB2.NAMA_BARANG, V_SELISIH_HARGA_KAB2.TANGGAL, V_SELISIH_HARGA_KAB2.TGL_LUNAS, V_SELISIH_HARGA_KAB2.NODO " & _
                   "FROM   ADMLSP.V_SELISIH_HARGA_KAB2 V_SELISIH_HARGA_KAB2 " & _
                   "WHERE V_SELISIH_HARGA_KAB2.TGL_LUNAS >='{0}' and V_SELISIH_HARGA_KAB2.TGL_LUNAS <='{1}'", convert_date_to_eng(tgl1), convert_date_to_eng(tgl2))

        End If

        
        If Not (kode_area.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_SELISIH_HARGA_KAB2.KD_STAT='{0}'", kode_area)
        End If

        If Not (kodekab.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_SELISIH_HARGA_KAB2.KODE_KAB='{0}'", kodekab)
        End If

        sql = String.Format("{0} {1}", sql, "ORDER BY V_SELISIH_HARGA_KAB2.NAMA_BARANG, V_SELISIH_HARGA_KAB2.KABUPATEN, V_SELISIH_HARGA_KAB2.NODO")

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

            Dim objRpt As New r_selisih_rekap_kab
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
            periode = String.Format("{0} ({1})", periode, nama_area)
            objRpt.SetParameterValue(0, periode)
            objRpt.SetParameterValue(1, userprint)

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

    Private Sub pr_gaji_semen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        open_data()

    End Sub

End Class