Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_hutang_supir

    Private kd_supir As String
    Private kd_stat As String

    Sub New(ByVal kdspr As String, ByVal kdstat As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        kd_supir = kdspr
        kd_stat = kdstat

    End Sub

    Private Sub open_data()

        Dim ds As DataSet = Nothing
        Dim cn As OracleConnection = Nothing
        Dim sql As String = ""

        sql = "SELECT V_SISA_KSB_SUPIR.KD_SUPIR, V_SISA_KSB_SUPIR.NAMA, V_SISA_KSB_SUPIR.JML_KASBON, V_SISA_KSB_SUPIR.AREA " & _
            "FROM   ADMLSP.V_SISA_KSB_SUPIR V_SISA_KSB_SUPIR"

        If Not (kd_stat.ToUpper = "ALL") Then
            sql = String.Format(sql & " WHERE V_SISA_KSB_SUPIR.KD_STAT='{0}'", kd_stat)
        End If

        If Not (kd_supir.Length = 0) Then

            If Not (kd_stat.ToUpper = "ALL") Then
                sql = String.Format(sql & " AND V_SISA_KSB_SUPIR.KD_SUPIR='{0}'", kd_supir)
            Else
                sql = String.Format(sql & " WHERE V_SISA_KSB_SUPIR.KD_SUPIR='{0}'", kd_supir)
            End If

        End If

        sql = String.Format(sql & " {0}", "ORDER BY V_SISA_KSB_SUPIR.AREA")


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

            Dim objRpt As New r_hutang_supir
            classmy.open_CnReport(objRpt)

            objRpt.SetDataSource(ds.Tables(0))

            Dim userprint As String = String.Format("User Print : {0}", userprog)

            objRpt.SetParameterValue(0, userprint)

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

    Private Sub pr_hist_spare_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        open_data()
    End Sub

End Class