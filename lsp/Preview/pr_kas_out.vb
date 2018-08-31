Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_kas_out

    Private tgl1 As Date
    Private tgl2 As Date
    Private kode_area As String
    Private nama_area As String
    Private kd_kas As String

    Sub New(ByVal ttgl1 As Date, ByVal ttgl2 As Date, ByVal kode_areas As String, ByVal nama_areas As String, ByVal kdkas As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        tgl1 = ttgl1
        tgl2 = ttgl2
        kode_area = kode_areas
        nama_area = nama_areas
        kd_kas = kdkas

    End Sub

    Private Sub open_data()

        Dim ds As DataSet = Nothing
        Dim cn As OracleConnection = Nothing
        Dim sql As String = ""

        sql = String.Format("SELECT V_KAS_OUT.NO_BUKTI, V_KAS_OUT.TANGGAL, V_KAS_OUT.KETERANGAN, V_KAS_OUT.NAMAKAS, V_KAS_OUT.KD_AKUN, V_KAS_OUT.NAMAAKUN, V_KAS_OUT.JML, V_KAS_OUT.DESKRIPSI " & _
                "FROM   ADMLSP.V_KAS_OUT V_KAS_OUT " & _
                "WHERE V_KAS_OUT.TANGGAL >='{0}' and V_KAS_OUT.TANGGAL <='{1}' ", convert_date_to_eng(tgl1), convert_date_to_eng(tgl2))

        If Not (kode_area.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_KAS_OUT.KD_STAT='{0}'", kode_area)
        End If

        If Not (kd_kas.ToUpper = "ALL") And kd_kas.Trim.Length > 0 Then
            sql = String.Format(sql & " AND V_KAS_OUT.KD_KAS='{0}'", kd_kas)
        End If

        sql = String.Format(sql & " {0}", "ORDER BY V_KAS_OUT.NO_BUKTI")


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

            Dim objRpt As New r_kas_out
            classmy.open_CnReport(objRpt)

            objRpt.SetDataSource(ds.Tables(0))

            Dim area_print As String

            If Not (kode_area.ToUpper = "ALL") Then
                area_print = String.Format("{0}", nama_area)
            Else
                area_print = String.Format("{0}", "All Area")
            End If

            Dim userprint As String = String.Format("User Print : {0}", userprog)
            Dim periode As String = String.Format("Periode Tanggal : {0} s/d {1}", convert_date_to_ind(tgl1), convert_date_to_ind(tgl2))
            periode = String.Format("{0} ({1})", periode, area_print)
            objRpt.SetParameterValue(0, userprint)
            objRpt.SetParameterValue(1, periode)

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