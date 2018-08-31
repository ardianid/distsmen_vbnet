Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_kas_out3

    Private posi As Integer = 0
    Private dv As DataView
    Private dv1 As DataView
    Private editstat As Boolean = False
    Private kd_prc As String

    Sub New(ByVal edits As Boolean, ByVal dvi As DataView, ByVal ps As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        isi_combo2()

        editstat = edits
        dv = dvi
        ''   dv.Sort = "KD_AKUN"
        posi = ps

    End Sub

    Private Sub isi_box()

        cbakun.EditValue = dv(posi)("KD_AKUN").ToString
        tjml.EditValue = dv(posi)("JML").ToString
        tket.Text = dv(posi)("DESKRIPSI").ToString
   
    End Sub

    Private Sub isi_combo2()

        Dim sql As String = "SELECT A.KODE,A.NAMA FROM ADMLSP.MS_AKUN A ORDER BY A.NAMA ASC"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv1 = dvm.CreateDataView(ds.Tables(0))

            cbakun.Properties.DataSource = dv1


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

    Private Sub cbakun_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbakun.KeyDown
        If e.KeyCode = 13 Then
            tjml.Focus()
        End If
    End Sub

    Private Sub tjml_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tjml.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        End If
    End Sub

    Private Sub tket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tket.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub manipulate()

        Dim no_sr As Integer = -1

        If editstat = False Then


            Dim dv2 As DataView = New DataView()
            dv2 = dv

            ' dv2.Sort = "KD_AKUN"

            no_sr = dv2.Find(cbakun.EditValue)

            If no_sr = -1 Then

                Dim orow As DataRow = dv.Table.NewRow

                orow("KD_AKUN") = cbakun.EditValue
                orow("NAMA") = cbakun.Text.Trim
                orow("JML") = tjml.EditValue
                orow("DESKRIPSI") = tket.Text.Trim

                dv.Table.Rows.Add(orow)

                Me.Close()

            Else
                MsgBox("Akun sudah ada dalam daftar", MsgBoxStyle.Information, "Informasi")
                cbakun.Focus()
            End If

        Else

            'dv.Sort = "KD_AKUN"

            dv.BeginInit()

            'For i As Integer = 0 To dv.Count - 1
            '    If dv(i)("KD_AKUN").ToString = cbakun.EditValue Then

            dv(posi)("JML") = tjml.EditValue
            dv(posi)("DESKRIPSI") = tket.Text.Trim

            'End If
            '    Next

            dv.EndInit()

            Me.Close()

        End If



    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub t_KASout3_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If editstat = True Then
            tjml.Focus()
        Else
            ' tjml.EditValue = 0
            cbakun.Focus()
        End If
    End Sub

    Private Sub t_spare_out3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If editstat = True Then

            cbakun.Enabled = False
            btsimpan.Text = "&Rubah"

            isi_box()

        Else
            cbakun.Enabled = True
            btsimpan.Text = "&Tambah"
        End If

    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If cbakun.EditValue = "" Then

            MsgBox("Akun tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            cbakun.Focus()
            Exit Sub

        End If


        If tjml.EditValue = 0 Then

            MsgBox("Jml tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tjml.Focus()
            Exit Sub

        End If

        manipulate()

    End Sub

End Class