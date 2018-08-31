Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fsl_do_pending

    Private Sub isi_combo()

        Dim sql As String = ""

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv As DataView
        Dim statpusat As Boolean = True

        If get_stat_pusat() = 1 Then
            statpusat = True
            sql = "select a.KODE,a.NAMA from admlsp.ms_stat a"
        Else
            statpusat = False
            sql = String.Format("select a.KODE,a.NAMA from admlsp.ms_stat a where a.KODE='{0}'", get_kode_stat)
        End If

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            If statpusat = True Then

                Dim orow As DataRow

                orow = ds.Tables(0).NewRow

                orow("KODE") = "ALL"
                orow("NAMA") = "<<- ALL ->>"

                ds.Tables(0).Rows.InsertAt(orow, 0)


            End If

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv = dvm.CreateDataView(ds.Tables(0))

            cbarea.Properties.DataSource = dv


        Catch ex As OracleException
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

    End Sub

    Private Sub isi_combo2()

        Const sql = "SELECT A.KD_PRC,A.NAMA,A.ALAMAT FROM ADMLSP.MS_PRINCIPAL A ORDER BY A.NAMA ASC"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv2 As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            If get_stat_pusat() = 1 Then

                Dim orow As DataRow

                orow = ds.Tables(0).NewRow

                orow("KD_PRC") = "All"
                orow("NAMA") = "All"

                ds.Tables(0).Rows.InsertAt(orow, 0)


            End If

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv2 = dvm.CreateDataView(ds.Tables(0))

            cbprinc.Properties.DataSource = dv2


        Catch ex As OracleException
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

    End Sub

    Private Sub tnamatok_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkodetok.KeyDown
        If e.KeyCode = 13 Then
            cbarea.Focus()
        ElseIf e.KeyCode = Keys.F4 Then

            Dim cari As String = "" 'tnamatok.Text.Trim
            tnamatok.Text = ""
            tkodetok.Text = ""

            Using fcari As New sr_toko(cari) With {.StartPosition = FormStartPosition.CenterParent}
                fcari.ShowDialog()

                tkodetok.Text = fcari.get_kode
                tnamatok.Text = fcari.get_nama

            End Using

        End If
    End Sub

    Private Sub btfindTok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfindtok.Click

        Dim cari As String = "" 'tnamatok.Text.Trim

        Using fcari As New sr_toko(cari) With {.StartPosition = FormStartPosition.CenterParent}
            fcari.ShowDialog()

            tkodetok.Text = fcari.get_kode
            tnamatok.Text = fcari.get_nama

            If tkodetok.Text.Length > 0 Then
                tnama_toko_Validating(sender, Nothing)
            End If


        End Using


    End Sub

    Private Sub tnama_toko_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tkodetok.Validating

        If tkodetok.Text <> "" Then

            Dim cn As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing
            Dim dred As OracleDataReader = Nothing
            Dim sql As String = ""

            If get_stat_pusat() = 1 Then
                sql = String.Format("select a.KD_TOKO,a.NAMA_TOKO,a.TIPE_HARGA,a.ALAMAT,a.KD_TBS AS KODE_KAB from admlsp.ms_toko a inner join admlsp.ms_kec b on a.KD_KEC=b.KODE where a.AKTIF=1 and a.KD_TOKO='{0}'", tkodetok.Text.Trim)
            ElseIf get_stat_pusat() = 0 Then
                sql = String.Format("select a.KD_TOKO,a.NAMA_TOKO,a.TIPE_HARGA,a.ALAMAT,a.KD_TBS AS KODE_KAB from admlsp.ms_toko a inner join admlsp.ms_kec b on a.KD_KEC=b.KODE where a.AKTIF=1 and a.KODE_STAT='{0}' and a.KD_TOKO='{1}'", get_kode_stat, tkodetok.Text.Trim)
            Else
                Exit Sub
            End If


            Try

                cn = classmy.open_conn_utama
                comd = New OracleCommand(sql, cn)
                dred = comd.ExecuteReader

                If dred.Read Then

                    tkodetok.Text = dred(0).ToString
                    tnamatok.Text = dred(1).ToString

                    dred.Close()

                Else

                    dred.Close()
                    MsgBox("Nama toko tidak ditemukan", MsgBoxStyle.Information, "Informasi")
                    e.Cancel = True
                    tkodetok.Focus()
                    tnamatok.Text = ""
                End If

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            Finally

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If

            End Try


        Else

            tkodetok.Text = ""
            tnamatok.Text = ""

        End If


    End Sub

    Private Sub ttgl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        If e.KeyCode = 13 Then
            ttgl2.Focus()
        End If
    End Sub

    Private Sub ttgl2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl2.KeyDown
        If e.KeyCode = 13 Then
            cbprinc.Focus()
        End If
    End Sub

    Private Sub CBPRINC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbprinc.KeyDown
        If e.KeyCode = 13 Then
            tkodetok.Focus()
        End If
    End Sub

    Private Sub tkodetok_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tkodetok.KeyDown
        If e.KeyCode = 13 Then
            cbarea.Focus()
        End If
    End Sub

    Private Sub cbarea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbarea.KeyDown
        If e.KeyCode = 13 Then
            btpre.Focus()
        End If
    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        Dim fpr_do_pending As New pr_do_pending(ttgl.EditValue, ttgl2.EditValue, cbarea.EditValue, cbarea.Text.Trim, cbprinc.EditValue, cbprinc.Text.Trim, tkodetok.Text.Trim, tnamatok.Text.Trim) With {.WindowState = FormWindowState.Maximized}
        fpr_do_pending.Show()

    End Sub

    Private Sub fsl_ganti_spare_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ttgl.Focus()
    End Sub

    Private Sub fsl_ganti_spare_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        isi_combo()
        isi_combo2()

        ttgl.EditValue = Date.Now
        ttgl2.EditValue = Date.Now

        cbprinc.ItemIndex = 0
        cbarea.ItemIndex = 0
    End Sub


End Class