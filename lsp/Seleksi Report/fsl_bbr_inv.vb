Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client

Public Class fsl_bbr_inv

    Private ds As DataSet
    Private dv1 As Data.DataView
    Private dvmanager As Data.DataViewManager
    Dim nobukti As ArrayList

    Private Sub opendata()

        Dim cn As OracleConnection = Nothing

        Dim sql As String = ""

        sql = String.Format("select B.NAMA_TOKO,A.NODO,A.TANGGAL,A.TOT_AKH,0 AS CETAK from admlsp.tr_real_order a inner join admlsp.ms_toko b on a.KD_TOKO=b.KD_TOKO " & _
            "WHERE (A.TOT_BAYAR + A.TOT_BAYAR_GIRO) < A.TOT_AKH AND A.TAGIH=0 AND (A.TANGGAL >='{0}' AND A.TANGGAL <='{1}') ORDER BY B.NAMA_TOKO", convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue))

        grid1.DataSource = Nothing


        Try

            open_wait()

            dv1 = Nothing

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            grid1.DataSource = dv1
            gridview.RefreshData()


            close_wait()

        Catch ex As OracleException
            close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally


            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

    End Sub

    Private Sub generate__bukti()

        Dim i As Integer = 0
        Dim a As Integer = 0

        nobukti = New ArrayList

        For i = 0 To dv1.Count - 1

            If dv1(i)("CETAK") = 1 Then
                nobukti.Insert(a, String.Format("'{0}'", dv1(i)("NODO").ToString))
                a += 1
            End If

        Next

    End Sub

    Private Sub fsl_bbr_inv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ttgl.Focus()
    End Sub

    Private Sub ttgl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        ttgl2.Focus()
    End Sub

    Private Sub ttgl2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl2.KeyDown
        ttgl2.Focus()
    End Sub

    Private Sub btlihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btlihat.Click
        opendata()
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click

        Me.Close()

    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        If IsNothing(dv1) Then
            MsgBox("Pilih dulu periode invoice yang akan diproses...", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        End If

        generate__bukti()

        If nobukti.Count <= 0 Then
            MsgBox("Pilih dulu data yang akan di print", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        End If

        Dim finv As New pr_inv(nobukti, True) With {.WindowState = FormWindowState.Maximized}
        finv.Show()

    End Sub

    Private Sub fsl_bbr_inv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ttgl.EditValue = Date.Now
        ttgl2.EditValue = Date.Now
    End Sub
End Class