Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_gaji_sal_detail

    Private bln As String
    Private namabulan As String
    Private thn As String
    Private kodekaryawan As String
    Private namakaryawan As String
    Private kdarea As String
    Private namaarea As String

    Sub New(ByVal kdrea As String, ByVal nmarea As String, ByVal bulan As String, ByVal tahun As String, ByVal kodekary As String, ByVal namakary As String, ByVal nmabulan As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        kdarea = kdrea
        namaarea = nmarea
        bln = bulan
        thn = tahun
        kodekaryawan = kodekary
        namakaryawan = namakary
        namabulan = nmabulan
    End Sub

    Private Sub open_data()

        Dim ds As DataSet = Nothing
        Dim cn As OracleConnection = Nothing
        Dim sql As String = ""


        sql = String.Format("SELECT V_GAJI_SALES.NODO, V_GAJI_SALES.TANGGAL, V_GAJI_SALES.NAMA_TOKO, V_GAJI_SALES.TOT_AKH, V_GAJI_SALES.TOT_INSENTIF, V_GAJI_SALES.NAMA_SALES, V_GAJI_SALES.KECAMATAN, V_GAJI_SALES.TOT_JML " & _
                "FROM   ADMLSP.V_GAJI_SALES V_GAJI_SALES " & _
                "WHERE extract(month from V_GAJI_SALES.TGL_LUNAS)='{0}' and extract(year from V_GAJI_SALES.TGL_LUNAS)='{1}'", bln, thn)

        If Not (kdarea.Trim.ToUpper = "ALL") Then
            sql = String.Format(" {0} AND V_GAJI_SALES.KD_STAT='{1}'", sql, kdarea)
        End If

        If kodekaryawan.Trim.Length > 0 Then
            sql = String.Format(" {0} AND V_GAJI_SALES.KD_SALES='{1}'", sql, kodekaryawan)
        End If

        sql = String.Format(" {0} {1}", sql, "ORDER BY V_GAJI_SALES.NAMA_SALES")

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

            Dim objRpt As New r_gaji_sales_det
            classmy.open_CnReport(objRpt)

            objRpt.SetDataSource(ds.Tables(0))

            Dim userprint As String = String.Format("User Print : {0}", userprog)
            Dim periode As String = String.Format("Periode Bulan {0} {1}", namabulan, thn)
            periode = String.Format("{0} ({1})", periode, namaarea)

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