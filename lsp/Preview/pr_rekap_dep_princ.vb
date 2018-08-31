Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_rekap_dep_princ


    Private tgl1 As Date
    Private tgl2 As Date
    Private kdprinc As String
    Private namaprinc As String
    Private in_old As Double
    Private out_old As Double

    Sub New(ByVal ttgl1 As Date, ByVal ttgl2 As Date, ByVal kodespares As String, ByVal namapr As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        tgl1 = ttgl1
        tgl2 = ttgl2
        kdprinc = kodespares
        namaprinc = namapr

    End Sub

    Private Sub kalkulasi_old(ByVal cn As OracleConnection)

        Dim comd As OracleCommand
        Dim dred As OracleDataReader

        Dim sql As String = String.Empty

        Try

            sql = String.Format("select sum(dep_in) as jml_in,sum(dep_out) as jml_out from admlsp.V_TMP_DEP_PRINCIPAL where tanggal <'{0}'  and kd_prc='{1}'", convert_date_to_eng(tgl1), kdprinc)

            If Not (kdprinc.ToUpper = "ALL") Then
                sql = String.Format(sql & " AND KD_PRC='{0}'", kdprinc)
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

        sql = String.Format("SELECT V_TMP_DEP_PRINCIPAL.NAMA, V_TMP_DEP_PRINCIPAL.DEP_IN, V_TMP_DEP_PRINCIPAL.DEP_OUT, V_TMP_DEP_PRINCIPAL.NO_BUKTI, V_TMP_DEP_PRINCIPAL.TANGGAL " & _
            "FROM   ADMLSP.V_TMP_DEP_PRINCIPAL V_TMP_DEP_PRINCIPAL " & _
            "WHERE V_TMP_DEP_PRINCIPAL.TANGGAL >='{0}' and V_TMP_DEP_PRINCIPAL.TANGGAL <='{1}' ", convert_date_to_eng(tgl1), convert_date_to_eng(tgl2))

        If Not (kdprinc.ToUpper = "ALL") Then
            sql = String.Format(sql & " AND V_TMP_DEP_PRINCIPAL.KD_PRC='{0}'", kdprinc)
        End If

        sql = String.Format(sql & " {0}", "ORDER BY V_TMP_DEP_PRINCIPAL.NAMA")


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

            Dim objRpt As New r_rekap_deposit_princ
            classmy.open_CnReport(objRpt)

            objRpt.SetDataSource(ds.Tables(0))

            Dim userprint As String = String.Format("User Print : {0}", userprog)
            Dim periode As String = String.Format("Periode Tanggal : {0} s/d {1}", convert_date_to_ind(tgl1), convert_date_to_ind(tgl2))
            Dim namap As String = String.Format("Ke {0}", namaprinc)

            objRpt.SetParameterValue(0, out_old)
            objRpt.SetParameterValue(1, in_old)
            objRpt.SetParameterValue(2, userprint)
            objRpt.SetParameterValue(3, namap)
            objRpt.SetParameterValue(4, periode)

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