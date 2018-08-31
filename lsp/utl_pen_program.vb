Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class utl_pen_program

    Private dv As DataView
    Dim st_ins As Boolean = True


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        isi_combo()
    End Sub

    Private Sub isi_combo()

        Const sql = "select * from admlsp.MS_STAT order by NAMA asc"
        Const sql2 = "select * from admlsp.UTL_PNM_PROG"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        Dim dv As DataView

        Dim dred As OracleDataReader
        Dim comd As OracleCommand

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv = dvm.CreateDataView(ds.Tables(0))

            cbprinc.Properties.DataSource = dv

            comd = New OracleCommand(sql2, cn)
            dred = comd.ExecuteReader

            If dred.Read Then

                Dim kode As String = dred("KODE").ToString

                dred.Close()
                If kode = "" Then
                    st_ins = True
                Else
                    cbprinc.EditValue = kode
                    st_ins = False
                End If

            Else
                st_ins = True
                dred.Close()
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

    End Sub

    Private Sub simpan()

        Dim sql As String = String.Empty

        If st_ins = True Then
            sql = String.Format("insert into admlsp.UTL_PNM_PROG (KODE) values('{0}')", cbprinc.EditValue)
        Else
            sql = String.Format("update admlsp.UTL_PNM_PROG set KODE='{0}'", cbprinc.EditValue)
        End If

        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Try

            cn = classmy.open_conn

            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            cmd = New OracleCommand(sql, cn)

            cmd.ExecuteNonQuery()
            sqltrans.Commit()

            MsgBox("Data telah disimpan..", MsgBoxStyle.Information, "Informasi")

            Me.Close()

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

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub utl_pen_program_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TextEdit1.Focus()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click
        simpan()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        If TextEdit1.Text.ToLower = "pegasus*13lsp" Then
            PanelControl1.Visible = False
            cbprinc.Focus()

        End If
    End Sub

    Private Sub TextEdit1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextEdit1.KeyDown
        SimpleButton1.PerformClick()
    End Sub
End Class