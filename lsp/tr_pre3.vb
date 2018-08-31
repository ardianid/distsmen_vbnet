Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_pre3

    Private posi As Integer = 0
    Private dv As DataView
    Private dv1 As DataView
    Private editstat As Boolean = False
    Private kd_prc As String
    Private hargamin As Double = 0
    Private kdkab As String

    Sub New(ByVal edits As Boolean, ByVal dvi As DataView, ByVal ps As Integer, ByVal kd_prc2 As String, ByVal kode_kab As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        kd_prc = kd_prc2

        kdkab = kode_kab
        isi_combo2()

        editstat = edits
        dv = dvi
        dv.Sort = "KD_BARANG"
        posi = ps


    End Sub

    Private Sub isi_box()

        cbbarang.EditValue = dv(posi)("KD_BARANG").ToString
        tsatuan.EditValue = dv(posi)("SATUAN").ToString
        tjml.EditValue = CDbl(dv(posi)("JML").ToString)
        tharga.EditValue = CDbl(dv(posi)("HARGA").ToString)
        ttot.EditValue = CDbl(dv(posi)("TOTAL").ToString)

        hargamin = 0 'CType(dv(posi)("HARGABELI").ToString, Double)

    End Sub

    Private Sub isi_combo2()

        Dim sql As String = String.Format("select a.KODE,a.NAMA,a.SATUAN,b.HARGA as HARGABELI from admlsp.ms_barang a inner join admlsp.ms_barang2 b on a.KODE=b.KD_BARANG where a.AKTIF=1 and a.KD_PRC='{0}' and b.KD_KAB='{1}' order by a.NAMA asc", kd_prc, kdkab)

        Dim cn As OracleConnection = Nothing
        Dim ds As DataSet

        Try

            cn = classmy.open_conn_utama
            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dv1 = dvm.CreateDataView(ds.Tables(0))

            cbbarang.Properties.DataSource = dv1


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

    Private Function hargabeli_lebihdari() As Boolean

        If tharga.EditValue > hargamin Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub totalkanharga()
        Dim total As Double
        
        total = CDbl(tjml.EditValue) * CDbl(tharga.EditValue)

        ttot.EditValue = total

    End Sub

    Private Sub cbbarang_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbbarang.Validating

        hargamin = 0

        If cbbarang.Text = "" Then
            tsatuan.Text = ""
            tharga.EditValue = 0.0
            ttot.EditValue = 0
            Exit Sub
        End If

        If IsNothing(dv1) Then
            tsatuan.Text = ""
            tharga.EditValue = 0.0
            ttot.EditValue = 0
            Exit Sub
        End If

        tsatuan.Text = dv1(cbbarang.ItemIndex)("SATUAN").ToString

        If editstat = False Then
            tharga.EditValue = CDbl(dv1(cbbarang.ItemIndex)("HARGABELI").ToString)
        End If

        hargamin = tharga.EditValue

    End Sub

    Private Sub cbbarang_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbarang.KeyDown
        If e.KeyCode = 13 Then
            tjml.Focus()
        End If
    End Sub

    Private Sub tjml_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tjml.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub tharga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tharga.KeyDown
        If e.KeyCode = 13 Then
            btsimpan.Focus()
        End If
    End Sub

    Private Sub manipulate()

        If editstat = False Then

            Dim no_sr As Integer = -1
            no_sr = dv.Find(cbbarang.EditValue)

            If no_sr = -1 Then

                Dim orow As DataRow = dv.Table.NewRow

                orow("KD_BARANG") = cbbarang.EditValue
                orow("NAMA") = cbbarang.Text.Trim
                orow("JML") = tjml.EditValue
                orow("SATUAN") = tsatuan.Text
                orow("HARGA") = tharga.EditValue
                orow("TOTAL") = ttot.EditValue

                dv.Table.Rows.Add(orow)

                Me.Close()

            Else
                MsgBox("Barang sudah ada dalam daftar", MsgBoxStyle.Information, "Informasi")
                cbbarang.Focus()
            End If

        Else

            dv(posi)("JML") = tjml.EditValue
            dv(posi)("HARGA") = tharga.EditValue
            dv(posi)("TOTAL") = ttot.EditValue
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
            '  tjml.EditValue = 0
            cbbarang.Focus()
        End If
    End Sub

    Private Sub t_spare_out3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If editstat = True Then

            cbbarang.Enabled = False
            btsimpan.Text = "&Rubah"

            isi_box()

        Else
            cbbarang.Enabled = True
            btsimpan.Text = "&Tambah"
        End If

    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If cbbarang.EditValue = "" Then

            MsgBox("Barang tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            cbbarang.Focus()
            Exit Sub

        End If


        If tjml.EditValue = 0 Then

            MsgBox("Jml barang tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tjml.Focus()
            Exit Sub

        End If

        manipulate()

    End Sub

    Private Sub tjml_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tjml.EditValueChanged

        If Not IsNumeric(tjml.EditValue) Then
            tjml.EditValue = 0
        End If

        If Not IsNumeric(tharga.EditValue) Then
            tharga.EditValue = 0
        End If

        totalkanharga()

    End Sub
End Class