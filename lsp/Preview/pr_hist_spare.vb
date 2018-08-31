Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_hist_spare

    Private tgl1 As Date
    Private tgl2 As Date
    Private kdspare As String
    Private in_old As Double
    Private out_old As Double

    Sub New(ByVal ttgl1 As Date, ByVal ttgl2 As Date, ByVal kodespares As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        tgl1 = ttgl1
        tgl2 = ttgl2
        kdspare = kodespares

    End Sub

    Private Sub kalkulasi_old(ByVal cn As OracleConnection)

        Dim comd As OracleCommand
        Dim dred As OracleDataReader

        Dim sql As String = String.Empty

        Try

            sql = String.Format("select sum(jml_in) as jml_in,sum(jml_out) as jml_out from admlsp.v_hist_spare where tanggal <'{0}'  and kode_spare='{1}'", convert_date_to_eng(tgl1), kdspare)

            If Not (kdspare.ToUpper = "ALL") Then
                sql = String.Format(sql & " AND KODE_SPARE='{0}'", kdspare)
            End If

            comd = New OracleCommand(sql, cn)
            dred = comd.ExecuteReader

            If dred.Read Then

                If IsNothing(dred(0).ToString) Then
                    in_old = 0
                ElseIf Not IsNumeric(dred(0).ToString) Then
                    in_old = 0
                Else
                    in_old = CDbl(dred(0).ToString)
                End If

                If IsNothing(dred(1).ToString) Then
                    out_old = 0
                ElseIf Not IsNumeric(dred(1).ToString) Then
                    out_old = 0
                Else
                    out_old = CDbl(dred(1).ToString)
                End If

                dred.Close()
            Else

                in_old = 0
                out_old = 0

                dred.Close()

            End If

        Catch ex As OracleException
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        End Try


    End Sub

    Private Sub open_data()

        Dim ds As DataSet = Nothing
        Dim cn As OracleConnection = Nothing
        Dim sql As String = ""

        sql = String.Format("SELECT V_HIST_SPARE.NO_BUKTI, V_HIST_SPARE.TANGGAL, V_HIST_SPARE.NOPOL, V_HIST_SPARE.JML_IN, V_HIST_SPARE.JML_OUT, V_HIST_SPARE.USER_ADD, V_HIST_SPARE.NAMA " & _
            "FROM   ADMLSP.V_HIST_SPARE V_HIST_SPARE " & _
            "WHERE V_HIST_SPARE.TANGGAL >='{0}' and V_HIST_SPARE.TANGGAL <='{1}' ", convert_date_to_eng(tgl1), convert_date_to_eng(tgl2))

        If Not (kdspare.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_HIST_SPARE.KODE_SPARE='{0}'", kdspare)
        End If

        sql = String.Format(sql & " {0}", "ORDER BY V_HIST_SPARE.NAMA")


        Try

            ' open_wait()

            cn = classmy.open_conn_utama

            kalkulasi_old(cn)

            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

            Dim objRpt As New r_hist_spare
            classmy.open_CnReport(objRpt)

            objRpt.SetDataSource(ds.Tables(0))

            Dim userprint As String = String.Format("User Print : {0}", userprog)
            Dim periode As String = String.Format("Periode Tanggal : {0} s/d {1}", convert_date_to_ind(tgl1), convert_date_to_ind(tgl2))

            objRpt.SetParameterValue(0, in_old)
            objRpt.SetParameterValue(1, out_old)
            objRpt.SetParameterValue(2, periode)
            objRpt.SetParameterValue(3, userprint)

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