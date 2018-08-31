Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_labarugi

    Dim kdstat As String
    Dim namastat As String
    Dim bln2 As String
    Dim thn2 As String
    Dim rkap As Boolean = False

    Sub New(ByVal kdstatt As String, ByVal namastatt As String, ByVal bbln As String, ByVal tthn As String, ByVal rrkap As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        kdstat = kdstatt
        namastat = namastatt
        bln2 = bbln
        thn2 = tthn
        rkap = rrkap

    End Sub

    Private Sub open_data()

        Dim ds As DataSet
        Dim dt As DataTable
        Dim cn As OracleConnection = Nothing

        Dim sql As String = ""

        If rkap = True Then
            sql = String.Format("SELECT TM_RUGILAB.NO_ID, TM_RUGILAB.THN, TM_RUGILAB.BLN, TM_RUGILAB.SEL_JUAL, TM_RUGILAB.INVENT_SAL, TM_RUGILAB.ANGK_LAIN, TM_RUGILAB.KAS_IN, TM_RUGILAB.DEP_PRINC, TM_RUGILAB.KS_OUT, TM_RUGILAB.KASBON_SPR, TM_RUGILAB.PEMB_KASBON, TM_RUGILAB.UANG_JLN, TM_RUGILAB.UANG_JLN_LAIN, TM_RUGILAB.TOT_ZAK " & _
                    "FROM   ADMLSP.TM_RUGILAB TM_RUGILAB " & _
                    "WHERE TM_RUGILAB.THN='{0}' AND TM_RUGILAB.KD_STAT='{1}'", thn2, kdstat)

            If Not bln2 = "0" Then
                sql = String.Format("{0} AND TM_RUGILAB.BLN='{1}'", sql, bln2)
            End If

            sql = String.Format("{0} {1}", sql, "ORDER BY TM_RUGILAB.THN, TM_RUGILAB.BLN")

        Else

            sql = String.Format("SELECT TM_RUGILAB.THN, TM_RUGILAB.BLN, TM_RUGILAB.SEL_JUAL, TM_RUGILAB.INVENT_SAL, TM_RUGILAB.ANGK_LAIN, TM_RUGILAB.KAS_IN, TM_RUGILAB.DEP_PRINC, TM_RUGILAB.KS_OUT, TM_RUGILAB.KASBON_SPR, TM_RUGILAB.PEMB_KASBON, TM_RUGILAB.UANG_JLN, TM_RUGILAB.UANG_JLN_LAIN, TM_RUGILAB.TOT_ZAK " & _
                    "FROM   ADMLSP.TM_RUGILAB TM_RUGILAB " & _
                    "WHERE TM_RUGILAB.THN='{0}' AND TM_RUGILAB.KD_STAT='{1}'", thn2, kdstat)

            If Not bln2 = "0" Then
                sql = String.Format("{0} AND TM_RUGILAB.BLN='{1}'", sql, bln2)
            End If

            sql = String.Format("{0} {1}", sql, "ORDER BY TM_RUGILAB.THN, TM_RUGILAB.BLN")

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

            dt = New DataTable
            dt = ds.Tables(0)

            If rkap = True Then

                Dim objRpt As New r_labarugi_tot
                classmy.open_CnReport(objRpt)

                'objRpt.SetDatabaseLogon("admlsp", "admlsp*123", "LSP-CON", "LSP")
                objRpt.SetDataSource(dt)

                Dim userprint As String = String.Format("User Print : {0}", userprog)
                Dim area As String = ""

                If Not (kdstat.ToUpper = "ALL") Then
                    area = String.Format("- {0} -", namastat)
                Else
                    area = "- All Area -"
                End If


                objRpt.SetParameterValue(0, area)
                objRpt.SetParameterValue(1, userprint)

                crv1.ReportSource = objRpt
                crv1.Refresh()


            Else



                Dim objRpt As New r_labarugi_bln
                classmy.open_CnReport(objRpt)

                'objRpt.SetDatabaseLogon("admlsp", "admlsp*123", "LSP-CON", "LSP")
                objRpt.SetDataSource(dt)

                Dim userprint As String = String.Format("User Print : {0}", userprog)
                Dim area As String = ""

                If Not (kdstat.ToUpper = "ALL") Then
                    area = String.Format("- {0} -", namastat)
                Else
                    area = "- All Area -"
                End If


                objRpt.SetParameterValue(0, area)
                objRpt.SetParameterValue(1, userprint)

                crv1.ReportSource = objRpt
                crv1.Refresh()


            End If

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

    Private Sub pr_labarugi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        open_data()

    End Sub

End Class