﻿Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client

Public Class tr_spare_in

    Private bs1 As BindingSource
    Private ds As DataSet
    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Get_Aksesform()

    End Sub

    Private Sub Get_Aksesform()

        Dim rows() As DataRow = dtmenu.Select(String.Format("NAMAFORM='{0}'", Me.Name.ToUpper.ToString))

        If Convert.ToInt16(rows(0)("T_ADD")) = 1 Then
            tsadd.Enabled = True
        Else
            tsadd.Enabled = False
        End If

        If Convert.ToInt16(rows(0)("T_EDIT")) = 1 Then
            tsedit.Enabled = True
        Else
            tsedit.Enabled = False
        End If

        If Convert.ToInt16(rows(0)("T_DEL")) = 1 Then
            tsdel.Enabled = True
        Else
            tsdel.Enabled = False
        End If

        If Convert.ToInt16(rows(0)("T_CETAK")) = 1 Then

        Else

        End If

    End Sub

    Sub refresh_data()
        opendata()
    End Sub

    Private Sub opendata()

        tsfind.Text = ""
        Dim cn As OracleConnection = Nothing

        Const sql As String = "SELECT a.NO_BUKTI,a.TGL_BUKTI,b.NAMA,a.KETERANGAN,a.JML,b.SATUAN,a.KD_SPARE FROM ADMLSP.TR_SPAREPART a INNER JOIN ADMLSP.MS_SPAREPART b ON a.KD_SPARE=b.KODE " & _
                "WHERE ROWNUM <= 50 ORDER BY A.TGL_BUKTI DESC"

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


            bs1 = New BindingSource
            bs1.DataSource = dv1
            bn1.BindingSource = bs1

            grid1.DataSource = bs1

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

    Private Sub cari()

        Dim cn As OracleConnection = Nothing

        grid1.DataSource = Nothing

        Dim sql As String = ""

        Select Case cbfind.SelectedIndex
            Case 0
                sql = String.Format("SELECT a.NO_BUKTI,a.TGL_BUKTI,b.NAMA,a.KETERANGAN,a.JML,b.SATUAN,a.KD_SPARE FROM ADMLSP.TR_SPAREPART a INNER JOIN ADMLSP.MS_SPAREPART b ON a.KD_SPARE=b.KODE " & _
                "WHERE ROWNUM <= 1000 AND a.NO_BUKTI like '%{0}%'  ORDER BY A.TGL_BUKTI DESC", tsfind.Text.Trim.ToUpper)
            Case 1

                If Not IsDate(tsfind.Text.Trim) Then

                    MsgBox("Format tanggal yang anda masukkan salah", MsgBoxStyle.Information, "Informasi")
                    tsfind.Focus()
                    Exit Sub
                End If

                sql = String.Format("SELECT a.NO_BUKTI,a.TGL_BUKTI,b.NAMA,a.KETERANGAN,a.JML,b.SATUAN,a.KD_SPARE FROM ADMLSP.TR_SPAREPART a INNER JOIN ADMLSP.MS_SPAREPART b ON a.KD_SPARE=b.KODE " & _
                "WHERE ROWNUM <= 1000 AND a.TGL_BUKTI='{0}'  ORDER BY A.TGL_BUKTI DESC", convert_date_to_eng(tsfind.Text.Trim.ToString))
            Case 2
                sql = String.Format("SELECT a.NO_BUKTI,a.TGL_BUKTI,b.NAMA,a.KETERANGAN,a.JML,b.SATUAN,a.KD_SPARE FROM ADMLSP.TR_SPAREPART a INNER JOIN ADMLSP.MS_SPAREPART b ON a.KD_SPARE=b.KODE " & _
                "WHERE ROWNUM <= 1000 AND b.NAMA like '%{0}%'  ORDER BY A.TGL_BUKTI DESC", tsfind.Text.Trim.ToUpper)
        End Select

        Try

            open_wait()

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            bs1.DataSource = dv1
            bn1.BindingSource = bs1

            grid1.DataSource = bs1

            close_wait()

        Catch ex As Exception
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

    Private Sub hapus_data()


        If dv1.Count > 0 Then


            Dim sql As String = String.Format("delete from admlsp.TR_SPAREPART where no_bukti='{0}'", dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString)
            Dim sqlupdate As String = String.Format("update admlsp.TR_SPAREPART set user_edit='{0}',tgl_edit='{1}' where no_bukti='{2}'", userprog, convert_date_to_eng(Date.Now.ToString), dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString)

            Dim cmd As OracleCommand = Nothing
            Dim cmdEdit As OracleCommand = Nothing
            Dim cn As OracleConnection = Nothing

            Try

                If MsgBox("Yakin akan dihapus ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi") = MsgBoxResult.Yes Then

                    open_wait()

                    cn = classmy.open_conn_utama

                    Dim sqltrans As OracleTransaction = cn.BeginTransaction

                    cmdEdit = New OracleCommand(sqlupdate, cn)
                    cmdEdit.ExecuteNonQuery()

                    ins_to_temp_user(cn, sqlupdate, dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString, "TR_SPAREPART", "UPDATE", "SPAREPART MASUK")

                    cmd = New OracleCommand(sql, cn)
                    cmd.ExecuteNonQuery()

                    ins_to_temp_user(cn, sql, dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString, "TR_SPAREPART", "DELETE", "SPAREPART MASUK")

                    sqltrans.Commit()
                    opendata()

                    close_wait()

                End If

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


        End If


    End Sub

    Private Sub tr_sparein_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cbfind.SelectedIndex = 0
        opendata()
    End Sub

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click
        cari()
    End Sub

    Private Sub tsfind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsfind.KeyDown
        If e.KeyCode = 13 Then
            cari()
        End If
    End Sub

    Private Sub tsdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdel.Click
        hapus_data()
    End Sub

    Private Sub tsadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsadd.Click

        Using tr_depsparein2 As New tr_spare_in2(True, dv1, 0) With {.StartPosition = FormStartPosition.CenterScreen}
            tr_depsparein2.ShowDialog(Me)
        End Using

    End Sub

    Private Sub tsedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsedit.Click

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Using tr_depsparein2 As New tr_spare_in2(False, dv1, bs1.Position) With {.StartPosition = FormStartPosition.CenterScreen}
            tr_depsparein2.ShowDialog(Me)
        End Using

    End Sub

End Class