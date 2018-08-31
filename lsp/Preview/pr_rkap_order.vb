Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_rkap_order

    Dim tgl1 As Date
    Dim tgl2 As Date
    Dim kdstat As String
    Dim namastat As String
    Private objRpt As New r_rkap_order

    Sub New(ByVal tgll1 As Date, ByVal tgll2 As Date, ByVal kdstatt As String, ByVal namastatt As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        tgl1 = tgll1
        tgl2 = tgll2
        kdstat = kdstatt
        namastat = namastatt

    End Sub

    Private Sub open_data()

        Dim ds As DataSet
        Dim dt As DataTable
        Dim cn As OracleConnection = Nothing

        Dim sql As String = ""
        sql = String.Format("SELECT V_REKAP_ORDER.NO_BUKTI, V_REKAP_ORDER.TOT_PRE, V_REKAP_ORDER.TANGGAL, V_REKAP_ORDER.KD_SUPIR, " & _
            "V_REKAP_ORDER.NOPOL, V_REKAP_ORDER.NO_SPB, V_REKAP_ORDER.TOT_REAL, V_REKAP_ORDER.UANG_JLN, V_REKAP_ORDER.SUPIR, V_REKAP_ORDER.SALES, V_REKAP_ORDER.JNS_AKT, V_REKAP_ORDER.HARGA, V_REKAP_ORDER.TOKO_PRE, V_REKAP_ORDER.TOKO_REAL, V_REKAP_ORDER.KEC_PRE, V_REKAP_ORDER.KEC_REAL, V_REKAP_ORDER.PRINCIPAL " & _
            "FROM   ADMLSP.V_REKAP_ORDER V_REKAP_ORDER" & _
        " WHERE V_REKAP_ORDER.TANGGAL >= '{0}' and V_REKAP_ORDER.TANGGAL <= '{1}'", convert_date_to_eng(tgl1), convert_date_to_eng(tgl2))

        If Not (kdstat.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_REKAP_ORDER.KD_STAT='{0}'", kdstat)
        End If

        sql = String.Format(sql & " {0}", "ORDER BY V_REKAP_ORDER.PRINCIPAL")

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

            dt = New DataTable
            dt = ds.Tables(0)

            classmy.open_CnReport(objRpt)

            'objRpt.SetDatabaseLogon("admlsp", "admlsp*123", "LSP-CON", "LSP")
            objRpt.SetDataSource(dt)

            Dim userprint As String = String.Format("User Print : {0}", userprog)
            Dim area As String = ""

            If Not (kdstat.ToUpper = "ALL") Then
                area = namastat
            Else
                area = "All Area"
            End If

            objRpt.SetParameterValue(0, tgl1)
            objRpt.SetParameterValue(1, tgl2)
            objRpt.SetParameterValue(2, userprint)
            objRpt.SetParameterValue(3, area)

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

    Private Sub pr_inv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        open_data()
    End Sub

End Class