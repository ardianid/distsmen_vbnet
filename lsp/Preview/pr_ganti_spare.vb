Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_ganti_spare

    Private tgl1 As Date
    Private tgl2 As Date
    Private kode_area As String
    Private nama_area As String
    Private nopol As String
    Private kdspare As String

    Sub New(ByVal ttgl1 As Date, ByVal ttgl2 As Date, ByVal kode_areas As String, ByVal nama_areas As String, ByVal nopols As String, ByVal kodespares As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        tgl1 = ttgl1
        tgl2 = ttgl2
        kode_area = kode_areas
        nama_area = nama_areas
        nopol = nopols
        kdspare = kodespares

    End Sub

    Private Sub open_data()

        Dim ds As DataSet = Nothing
        Dim cn As OracleConnection = Nothing
        Dim sql As String = ""

        sql = String.Format("SELECT V_TRANS_SPARE_OUT.NO_BUKTI, V_TRANS_SPARE_OUT.TANGGAL, V_TRANS_SPARE_OUT.NOPOL, V_TRANS_SPARE_OUT.KETERANGAN, V_TRANS_SPARE_OUT.SUPIR, V_TRANS_SPARE_OUT.NAMA_SPARE, V_TRANS_SPARE_OUT.JML, V_TRANS_SPARE_OUT.SATUAN,V_TRANS_SPARE_OUT.HARGA,V_TRANS_SPARE_OUT.TOT_HARGA " & _
                "FROM   ADMLSP.V_TRANS_SPARE_OUT V_TRANS_SPARE_OUT " & _
                "WHERE V_TRANS_SPARE_OUT.TANGGAL >='{0}' and V_TRANS_SPARE_OUT.TANGGAL <='{1}' ", convert_date_to_eng(tgl1), convert_date_to_eng(tgl2))

        If Not (kode_area.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_TRANS_SPARE_OUT.KD_STAT='{0}'", kode_area)
        End If

        If Not (nopol.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_TRANS_SPARE_OUT.NOPOL='{0}'", nopol)
        End If

        If Not (kdspare.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_TRANS_SPARE_OUT.KD_SPARE='{0}'", kdspare)
        End If

        sql = String.Format(sql & " {0}", "ORDER BY V_TRANS_SPARE_OUT.NO_BUKTI")


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

            Dim objRpt As New r_ganti_spare
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

    Private Sub pr_gaji_semen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        open_data()

    End Sub

End Class