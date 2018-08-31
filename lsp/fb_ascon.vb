Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fb_ascon

    Private dv1 As DataView

    Private Sub isi_grid()

        Dim ds As DataSet
        Dim dvmanager As Data.DataViewManager
        Dim cn As OracleConnection = Nothing


        Dim sql As String = String.Format("select rownum,a.NAMA,a.KETERANGAN,a.NAMAFORM from admlsp.ms_menu a inner join admlsp.ms_user_detail b on a.KODE=b.KD_MENU where b.NAMA_USER='{0}' and a.MNFILE='3.1 LAPORAN (ASSET CONTROL)' AND (b.T_ACTIVE=1 or b.T_ADD=1 or b.T_CETAK=1 or b.T_DEL=1 or b.T_EDIT=1) order by rownum,a.NAMA", userprog)

        grid1.DataSource = Nothing
        Try

            dv1 = Nothing

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            grid1.DataSource = dv1

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

    Private Sub fb_ascon_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        'If IsNothing(dv1) Then
        '    Me.Close()
        'End If

        'If dv1.Count = 0 Then
        '    Me.Close()
        'End If

    End Sub

    Private Sub fb_ascon_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        isi_grid()

    End Sub

    Private Sub btload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btload.Click

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count = 0 Then
            Exit Sub
        End If

        'open_wait()
        'Cursor = Cursors.WaitCursor

        Dim namaform As String = dv1(Me.BindingContext(dv1).Position)("NAMAFORM").ToString

        Select Case namaform.ToUpper

            Case "FSL_GANTI_SPARE"

                Dim ffsel As New fsl_ganti_spare() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

            Case "FSL_HIST_SPARE"

                Dim ffsel As New fsl_hist_spare() With {.StartPosition = FormStartPosition.CenterScreen}
                ffsel.ShowDialog()

        End Select

        'Cursor = Cursors.Default
        'close_wait()

    End Sub

    Private Sub grid1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grid1.DoubleClick
        btload_Click(sender, e)
    End Sub

End Class