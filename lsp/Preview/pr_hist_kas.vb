Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_hist_kas

    Private tgl1 As Date
    Private tgl2 As Date
    Private kd_kas As String
    Private in_old As Double
    Private out_old As Double
    Private ket As String
    Private kd_stat As String
    Private namastat As String
    Private namakas As String

    Sub New(ByVal ttgl1 As Date, ByVal ttgl2 As Date, ByVal kdkas As String, _
            ByVal kett As String, ByVal kkd_stat As String, ByVal nnamastat As String, ByVal nmkas As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        tgl1 = ttgl1
        tgl2 = ttgl2
        kd_kas = kdkas
        ket = kett
        kd_stat = kkd_stat
        namastat = nnamastat
        namakas = nmkas

    End Sub

    Private Sub kalkulasi_old(ByVal cn As OracleConnection)

        Dim comd As OracleCommand
        Dim dred As OracleDataReader

        Dim sql As String = String.Empty

        Try

            sql = String.Format("select sum(a.JML_IN) as jml_in,sum(a.JML_OUT) as jml_out from admlsp.V_HIST_KAS a where a.TANGGAL < '{0}'", convert_date_to_eng(tgl1))


            If Not kd_kas.Trim.ToUpper = "ALL" Then
                sql = String.Format("{0} AND a.KD_KAS='{1}'", sql, kd_kas)
            End If

            If Not kd_stat.Trim.ToUpper = "ALL" Then
                sql = String.Format("{0} AND a.KD_STAT='{1}'", sql, kd_stat)
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

        sql = String.Format("SELECT V_HIST_KAS.NO_BUKTI, V_HIST_KAS.TANGGAL, V_HIST_KAS.JML_IN, V_HIST_KAS.JML_OUT, V_HIST_KAS.KETERANGAN, V_HIST_KAS.ID " & _
            "FROM   ADMLSP.V_HIST_KAS V_HIST_KAS " & _
            "WHERE V_HIST_KAS.TANGGAL >='{0}' and V_HIST_KAS.TANGGAL <='{1}' ", convert_date_to_eng(tgl1), convert_date_to_eng(tgl2))

        If Not kd_kas.Trim.ToUpper = "ALL" Then
            sql = String.Format("{0} AND V_HIST_KAS.KD_KAS='{1}'", sql, kd_kas)
        End If

        If Not ket.Trim.Length = 0 Then
            sql = String.Format("{0} AND V_HIST_KAS.KETERANGAN  like '%{1}%'", sql, ket)
        End If

        If Not kd_stat.Trim.ToUpper = "ALL" Then
            sql = String.Format("{0} AND V_HIST_KAS.KD_STAT='{1}'", sql, kd_stat)
        End If

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

            Dim objRpt As New r_hist_kas
            classmy.open_CnReport(objRpt)

            objRpt.SetDataSource(ds.Tables(0))


            Dim area_print As String

            If Not (kd_stat.ToUpper = "ALL") Then
                area_print = String.Format("{0}", namastat)
            Else
                area_print = String.Format("{0}", "All Area")
            End If

            Dim userprint As String = String.Format("User Print : {0}", userprog)
            Dim periode As String = String.Format("Periode Tanggal : {0} s/d {1}", convert_date_to_ind(tgl1), convert_date_to_ind(tgl2))
            periode = String.Format("{0} ({1})", periode, area_print)

            objRpt.SetParameterValue(0, in_old)
            objRpt.SetParameterValue(1, out_old)
            objRpt.SetParameterValue(2, periode)
            objRpt.SetParameterValue(3, userprint)
            objRpt.SetParameterValue(4, namakas)

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