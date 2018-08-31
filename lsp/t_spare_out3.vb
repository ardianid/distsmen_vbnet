Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class t_spare_out3

    Private posi As Integer = 0
    Private dv As DataView
    Private dv1 As DataView
    Private editstat As Boolean = False

    Sub New(ByVal edits As Boolean, ByVal dvi As DataView, ByVal ps As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        isi_combo2()
        editstat = edits

        dv = dvi
        posi = ps

    End Sub

    Private Sub isi_box()

        cbspare.EditValue = dv(posi)("KD_SPARE").ToString
        tsatuan.EditValue = dv(posi)("SATUAN").ToString
        tjml.EditValue = dv(posi)("JML").ToString

        thargajual1.EditValue = dv(posi)("HARGA").ToString
        ttot_harga.EditValue = dv(posi)("TOT_HARGA").ToString

    End Sub

    Private Sub isi_combo2()

        Const sql = "select kode,nama,satuan,harga from admlsp.ms_sparepart order by nama asc"

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet
        ' Dim dv1 As DataView

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv1 = dvm.CreateDataView(ds.Tables(0))

            cbspare.Properties.DataSource = dv1


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

    Private Sub totalHarga()

        ttot_harga.EditValue = CDbl(tjml.EditValue) * CDbl(thargajual1.EditValue)

    End Sub

    Private Sub cbspare_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbspare.KeyDown
        If e.KeyCode = 13 Then
            tjml.Focus()
        End If
    End Sub

    Private Sub tjml_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tjml.KeyDown
        If e.KeyCode = 13 Then
            ttot_harga.Focus()
        End If
    End Sub

    Private Sub ttot_harga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ttot_harga.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub cbspare_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbspare.Validating

        If cbspare.Text = "" Then
            tsatuan.Text = ""
            Exit Sub
        End If

        If IsNothing(dv1) Then
            tsatuan.Text = ""
            Exit Sub
        End If

        tsatuan.Text = dv1(cbspare.ItemIndex)("SATUAN").ToString
        thargajual1.Text = dv1(cbspare.ItemIndex)("HARGA").ToString

    End Sub

    Private Sub manipulate()

        If editstat = False Then

            Dim no_sr As Integer = -1
            no_sr = dv.Find(cbspare.EditValue)

            If no_sr = -1 Then

                Dim orow As DataRow = dv.Table.NewRow

                orow("KD_SPARE") = cbspare.EditValue
                orow("NAMA") = cbspare.Text.Trim
                orow("JML") = tjml.EditValue
                orow("SATUAN") = tsatuan.Text
                orow("HARGA") = thargajual1.EditValue
                orow("TOT_HARGA") = ttot_harga.EditValue

                dv.Table.Rows.Add(orow)

                tjml.EditValue = 0
                thargajual1.EditValue = 0
                cbspare.Focus()

            Else
                MsgBox("SparePart yang akan diganti sudah ada dalam daftar", MsgBoxStyle.Information, "Informasi")
                cbspare.Focus()
            End If

        Else

            dv(posi)("JML") = tjml.EditValue
            dv(posi)("HARGA") = thargajual1.EditValue
            dv(posi)("TOT_HARGA") = ttot_harga.EditValue
            Me.Close()

        End If

        

    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub t_spare_out3_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If editstat = True Then
            tjml.Focus()
        Else
            tjml.EditValue = 0
            cbspare.Focus()
        End If
    End Sub

    Private Sub t_spare_out3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If editstat = True Then

            cbspare.Enabled = False
            btsimpan.Text = "&Rubah"

            isi_box()

        Else
            cbspare.Enabled = True
            btsimpan.Text = "&Tambah"
        End If

    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If cbspare.EditValue = "" Then

            MsgBox("Sparepart yang akan diganti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            cbspare.Focus()
            Exit Sub

        End If


        If tjml.EditValue = 0 Then

            MsgBox("Jml Sparepart yang akan diganti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tjml.Focus()
            Exit Sub

        End If

        If thargajual1.EditValue = 0 Then

            MsgBox("Harga tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            thargajual1.Focus()
            Exit Sub

        End If

        manipulate()

    End Sub

    Private Sub tjml_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tjml.EditValueChanged
        totalHarga()
    End Sub

    Private Sub thargajual1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles thargajual1.EditValueChanged
        totalHarga()
    End Sub
End Class