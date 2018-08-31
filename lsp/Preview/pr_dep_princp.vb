Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_dep_princp

    Private Sub open_data()

        Dim ds As DataSet = Nothing
        Dim cn As OracleConnection = Nothing

        Dim sql As String = ""

        sql = "SELECT V_DEP_PRINCIPAL.KD_PRC, V_DEP_PRINCIPAL.NAMA, V_DEP_PRINCIPAL.TTL_DEPOSIT, V_DEP_PRINCIPAL.JML_DEP_PENDING " & _
                "FROM   ADMLSP.V_DEP_PRINCIPAL V_DEP_PRINCIPAL"

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

            Dim objRpt As New r_dep_princ
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

    Private Sub pr_dep_princ_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        open_data()

    End Sub

End Class