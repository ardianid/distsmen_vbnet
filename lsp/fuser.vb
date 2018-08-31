Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client

Public Class fuser

    Private bs1 As BindingSource
    Private ds As DataSet
    Private cn As OracleConnection
    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        opendata()

        Get_Aksesform()

    End Sub

    Sub refresh_data()
        opendata()
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

        Else

        End If

        If Convert.ToInt16(rows(0)("T_CETAK")) = 1 Then

        Else

        End If

    End Sub

    Private Sub opendata()

        tsfind.Text = ""

        Const sql As String = "select nonaktif,nama,unl_print from admlsp.ms_user_header order by nama asc"

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

        'bs1.DataSource = Nothing
        grid1.DataSource = Nothing

        Dim sql As String = String.Format("select nonaktif,nama,unl_print from admlsp.ms_user_header where nama like upper('%{0}%') order by nama asc", tsfind.Text.Trim)

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

    Private Sub fuser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        cbfind.SelectedIndex = 0


    End Sub


    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click
        cari()
    End Sub

    Private Sub tsfind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsfind.KeyDown
        If e.KeyCode = 13 Then
            cari()
        End If
    End Sub

    Private Sub tsadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsadd.Click

        Cursor = Cursors.WaitCursor

        Using userdetail As New fuser_detail With {.StartPosition = FormStartPosition.CenterScreen, .addstat = True}
            userdetail.ShowDialog(Me)
        End Using

        Cursor = Cursors.Default

    End Sub

    Private Sub tsedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsedit.Click

        If dv1.Count <= 0 Then
        Else

            Cursor = Cursors.WaitCursor

            Dim userdetail As New fuser_detail With {.StartPosition = FormStartPosition.CenterScreen,
                                                     .addstat = False,
                                                     .nama = dv1(Me.BindingContext(bs1).Position)("NAMA").ToString,
                                                     .nonaktifkan = dv1(Me.BindingContext(bs1).Position)("NONAKTIF").ToString,
                                                     .un_print = dv1(Me.BindingContext(bs1).Position)("UNL_PRINT").ToString}

            userdetail.ShowDialog(Me)


            Cursor = Cursors.Default

        End If

    End Sub
End Class