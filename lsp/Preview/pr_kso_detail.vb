Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_kso_detail

    Dim tgl1 As Date
    Dim tgl2 As Date
    Dim kdstat As String
    Dim namastat As String
    Dim kd_kso As String
    Dim nm_kso As String

    Sub New(ByVal tgll1 As Date, ByVal tgll2 As Date, ByVal kdstatt As String, ByVal namastatt As String, ByVal kdks As String, ByVal namaks As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        tgl1 = tgll1
        tgl2 = tgll2
        kdstat = kdstatt
        namastat = namastatt
        kd_kso = kdks
        nm_kso = namaks

    End Sub

    Private Sub open_data()

        Dim ds As DataSet
        Dim dt As DataTable
        Dim cn As OracleConnection = Nothing

        Dim sql As String = ""
        sql = String.Format("SELECT V_KSO_DETAIL.NO_BUKTI, V_KSO_DETAIL.TANGGAL, V_KSO_DETAIL.NOPOL, V_KSO_DETAIL.KECAMATAN, V_KSO_DETAIL.NAMA_TOKO, V_KSO_DETAIL.TOT_JML, V_KSO_DETAIL.OKS_ANGKUT, V_KSO_DETAIL.NAMA_KSO " & _
                "FROM   ADMLSP.V_KSO_DETAIL V_KSO_DETAIL " & _
                " WHERE V_KSO_DETAIL.TANGGAL >= '{0}' and V_KSO_DETAIL.TANGGAL <= '{1}'", convert_date_to_eng(tgl1), convert_date_to_eng(tgl2))

        If Not (kdstat.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_KSO_DETAIL.KD_STAT='{0}'", kdstat)
        End If

        If Not (kd_kso.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_KSO_DETAIL.KODE_KSO='{0}'", kd_kso)
        End If

        sql = String.Format(sql & " {0}", "ORDER BY V_KSO_DETAIL.NAMA_KSO")

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

            Dim objRpt As New r_kso_detail
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

            Dim periode As String = String.Format("Periode Tanggal : {0} s/d {1}", convert_date_to_ind(tgl1), convert_date_to_ind(tgl2))
            periode = String.Format("{0} ({1})", periode, area)

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

    Private Sub pr_kso_detail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        open_data()

    End Sub

End Class