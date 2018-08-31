Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client


Public Class pr_track

    Dim nodo As String
    Private objRpt As New r_track

    Sub New(ByVal nod As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        nodo = nod
    End Sub

    Private Sub open_data()

        Dim ds As DataSet
        Dim dt As DataTable
        Dim cn As OracleConnection = Nothing

        Dim sql As String = ""
        sql = String.Format("SELECT V_REKAP_ORDER2.NO_BUKTI, V_REKAP_ORDER2.NODO, V_REKAP_ORDER2.TGL_PRE, V_REKAP_ORDER2.TGL_REAL, V_REKAP_ORDER2.TOKO_PRE, V_REKAP_ORDER2.TOKO_REAL, V_REKAP_ORDER2.ALAMAT_TOKO_PRE, V_REKAP_ORDER2.ALAMAT_TOKO_REAL, V_REKAP_ORDER2.SUPIR_PRE, V_REKAP_ORDER2.SUPIR_REAL, V_REKAP_ORDER2.NOPOL_PRE, V_REKAP_ORDER2.NOPOL_REAL, V_REKAP_ORDER2.TOT_JML, V_REKAP_ORDER2.JML_DATANG, V_REKAP_ORDER2.JML, V_REKAP_ORDER2.KD_BARANG, V_REKAP_ORDER2.NAMABARANG " & _
        "FROM   ADMLSP.V_REKAP_ORDER2 V_REKAP_ORDER2 WHERE V_REKAP_ORDER2.NO_BUKTI='{0}' " & _
        "ORDER BY V_REKAP_ORDER2.NO_BUKTI, V_REKAP_ORDER2.NODO", nodo)


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