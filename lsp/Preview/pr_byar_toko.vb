Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_byar_toko

    Private periode As Date
    Private periode2 As Date
    Private kd_stat As String
    Private stats As String

    Sub New(ByVal period As Date, ByVal period2 As Date, ByVal kdstat As String, ByVal namastat As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        periode = period
        periode2 = period2
        kd_stat = kdstat
        stats = namastat

    End Sub

    Private Sub open_data()

        Dim ds As DataSet = Nothing
        Dim cn As OracleConnection = Nothing
        Dim sql As String = ""

        sql = String.Format("SELECT V_PEMBAYARAN_TOKO.NO_BUKTI, V_PEMBAYARAN_TOKO.TANGGAL, V_PEMBAYARAN_TOKO.JML, V_PEMBAYARAN_TOKO.JML_DEPOSIT, V_PEMBAYARAN_TOKO.JML_TUNAI, V_PEMBAYARAN_TOKO.JML_GIRO, V_PEMBAYARAN_TOKO.JML_TOT, V_PEMBAYARAN_TOKO.TANGGAL_REAL, V_PEMBAYARAN_TOKO.NAMA_TOKO " & _
                    "FROM   ADMLSP.V_PEMBAYARAN_TOKO V_PEMBAYARAN_TOKO " & _
                    "WHERE V_PEMBAYARAN_TOKO.TANGGAL >='{0}' AND V_PEMBAYARAN_TOKO.TANGGAL <='{1}'", convert_date_to_eng(periode), convert_date_to_eng(periode2))

        If Not (kd_stat.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_PEMBAYARAN_TOKO.KD_STAT='{0}'", kd_stat)
        End If

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

            Dim objRpt As New r_byar_toko
            classmy.open_CnReport(objRpt)

            objRpt.SetDataSource(ds.Tables(0))

            Dim areas As String = String.Format("Area : {0}", stats)
            Dim userprint As String = String.Format("User Print : {0}", userprog)
            Dim period As String = String.Format("Periode Tgl : {0} s/d {1}", convert_date_to_ind(periode), convert_date_to_ind(periode2.Date))

            objRpt.SetParameterValue(0, period)
            objRpt.SetParameterValue(1, userprint)
            objRpt.SetParameterValue(2, areas)

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

    Private Sub pr_byar_toko_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        open_data()

    End Sub

End Class