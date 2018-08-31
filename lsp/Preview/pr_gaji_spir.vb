Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_gaji_spir
    Private bln As String
    Private thn As String
    Private areas As String

    Sub New(ByVal bulan As String, ByVal tahun As String, ByVal area As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        bln = bulan
        thn = tahun
        areas = area

    End Sub

    Private Sub open_data()

        Dim ds As DataSet = Nothing
        Dim cn As OracleConnection = Nothing

        Dim bulan As String = bln

        Dim sql As String = ""

        sql = String.Format("select V_GAJI_SUPIR.JML_SEMEN, V_GAJI_SUPIR.JML_LAIN, V_GAJI_SUPIR.NAMA, V_GAJI_SUPIR.BULAN, V_GAJI_SUPIR.POT_KASBON, V_GAJI_SUPIR.KETERANGAN " & _
                "FROM   ADMLSP.V_GAJI_SUPIR V_GAJI_SUPIR " & _
                "WHERE V_GAJI_SUPIR.TAHUN='{0}' AND V_GAJI_SUPIR.BULAN='{1}' and V_GAJI_SUPIR.KD_STAT='{2}' " & _
                "ORDER BY V_GAJI_SUPIR.BULAN", thn, bulan, areas)


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

            Dim objRpt As New r_gaji
            classmy.open_CnReport(objRpt)

            objRpt.SetDataSource(ds.Tables(0))

            Dim userprint As String = String.Format("User Print : {0}", userprog)
            Dim blnthn As String = String.Format("{0} / {1}", bln, thn)

            objRpt.SetParameterValue(0, userprint)
            objRpt.SetParameterValue(1, blnthn)

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

    Private Sub pr_gaji_spir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        open_data()

    End Sub
End Class