﻿Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class fsl_hist_kas

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

        Dim sql As String

        If get_stat_pusat() = 1 Then
            sql = "SELECT A.KODE,A.NAMA,B.STATUS FROM ADMLSP.MS_KAS A INNER JOIN ADMLSP.MS_STAT B ON A.KD_STAT=B.KODE"
        Else
            sql = String.Format("SELECT A.KODE,A.NAMA,B.STATUS FROM ADMLSP.MS_KAS A INNER JOIN ADMLSP.MS_STAT B ON A.KD_STAT=B.KODE WHERE A.KD_STAT='{0}'", get_kode_stat)
        End If

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim orow As DataRow

            orow = ds.Tables(0).NewRow

            orow("KODE") = "ALL"
            orow("NAMA") = "All"

            ds.Tables(0).Rows.InsertAt(orow, 0)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv = dvm.CreateDataView(ds.Tables(0))

            cbjeniskas.Properties.DataSource = dv


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

    Private Sub ttgl_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl.KeyDown
        If e.KeyCode = 13 Then
            ttgl2.Focus()
        End If
    End Sub

    Private Sub ttgl2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttgl2.KeyDown
        If e.KeyCode = 13 Then
            cbjeniskas.Focus()
        End If
    End Sub

    Private Sub cbjeniskas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbjeniskas.KeyDown
        If e.KeyCode = 13 Then
            cbarea.Focus()
        End If
    End Sub

    Private Sub cbarea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbarea.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        End If
    End Sub

    Private Sub tket_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tket.KeyDown
        If e.KeyCode = 13 Then
            btpre.Focus()
        End If
    End Sub

    Private Sub fsl_hist_kas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ttgl.Focus()
    End Sub

    Private Sub fsl_hist_kas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        isi_combo()
        isi_combo2()

        cbjeniskas.ItemIndex = 0
        cbarea.ItemIndex = 0

        ttgl.EditValue = Date.Now
        ttgl2.EditValue = Date.Now
    End Sub

    Private Sub btpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btpre.Click

        Dim fhist_kas As New pr_hist_kas(ttgl.EditValue, ttgl2.EditValue, cbjeniskas.EditValue, tket.Text.Trim.ToUpper, cbarea.EditValue, cbarea.Text.Trim, cbjeniskas.Text.Trim) With {.WindowState = FormWindowState.Maximized}
        fhist_kas.Show()

    End Sub

End Class