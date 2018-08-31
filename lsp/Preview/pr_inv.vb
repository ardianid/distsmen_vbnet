Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_inv

    Private nobukti As ArrayList
    Private beberapa As Boolean

    Sub New(ByVal no_bukti As ArrayList, ByVal beberapainv As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        nobukti = New ArrayList
        nobukti = no_bukti

        beberapa = beberapainv

    End Sub

    Private Sub open_data()

        Dim ds As DataSet = Nothing
        Dim cn As OracleConnection = Nothing

        Dim sql As String = ""
        sql = "SELECT TR_REAL_ORDER.NODO, TR_REAL_ORDER.TANGGAL, TR_REAL_ORDER.KD_TOKO, TR_REAL_ORDER.NO_SPB, TR_REAL_ORDER.TOT_HARGA, TR_REAL_ORDER.DISC2, TR_REAL_ORDER.TOT_AKH, TR_REAL_ORDER.TERBILANG, TR_REAL_ORDER2.JML, TR_REAL_ORDER2.HARGA, TR_REAL_ORDER2.TOTAL, MS_TOKO.NAMA_TOKO, MS_TOKO.ALAMAT, MS_TOKO.TELP, MS_BARANG.NAMA, MS_BARANG.SATUAN, MS_BARANG.UNIT " & _
                "FROM   ((ADMLSP.MS_BARANG MS_BARANG INNER JOIN ADMLSP.TR_REAL_ORDER2 TR_REAL_ORDER2 ON MS_BARANG.KODE=TR_REAL_ORDER2.KD_BARANG) INNER JOIN ADMLSP.TR_REAL_ORDER TR_REAL_ORDER ON TR_REAL_ORDER2.NODO=TR_REAL_ORDER.NODO) INNER JOIN ADMLSP.MS_TOKO MS_TOKO ON TR_REAL_ORDER.KD_TOKO=MS_TOKO.KD_TOKO " & _
                "WHERE TR_REAL_ORDER.NODO in("

        Dim i As Integer = 0
        Dim sql2 As String = ""

        If nobukti.Count = 1 Then

            If beberapa = True Then
                sql2 = String.Format("{0})", nobukti(0).ToString)
            Else
                sql2 = String.Format("'{0}')", nobukti(0).ToString)
            End If


        Else

            For i = 0 To nobukti.Count - 1

                If i < nobukti.Count - 1 Then
                    sql2 = sql2 & nobukti(i).ToString & ","
                Else
                    sql2 = sql2 & nobukti(i).ToString & ")"
                End If
            Next

        End If

        sql = sql & sql2 & " ORDER BY TR_REAL_ORDER.NODO"

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

            Dim objRpt As New r_invoice

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

    Private Sub pr_inv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        open_data()

        update_jml_tagih()

    End Sub

    Private Function update_jml_tagih() As Integer

        Dim cn As OracleConnection = Nothing
        Dim comd As OracleCommand = Nothing

        Dim sql As String = "update admlsp.tr_real_order set tagih=tagih +1 where nodo in("

        Dim i As Integer = 0
        Dim sql2 As String = ""

        If nobukti.Count = 1 Then

            If beberapa = True Then
                sql2 = String.Format("{0})", nobukti(0).ToString)
            Else
                sql2 = String.Format("'{0}')", nobukti(0).ToString)
            End If

        Else

            For i = 0 To nobukti.Count - 1

                If i < nobukti.Count - 1 Then
                    sql2 = sql2 & nobukti(i).ToString & ","
                Else
                    sql2 = sql2 & nobukti(i).ToString & ")"
                End If
            Next

        End If

        sql = sql & sql2

        Try

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            comd = New OracleCommand(sql, cn)
            comd.ExecuteNonQuery()

        Catch ex As Exception

            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

    End Function

End Class