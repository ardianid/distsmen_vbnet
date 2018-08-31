Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_real3

    Private posi As Integer = 0
    Private dv As DataView
    Private dv1 As DataView
    Private editstat As Boolean = False
    Private hargamin As Double = 0
    Private tipe_harga As Integer = 0
    Private harga_beli As Double = 0
    Private total_beli As Double = 0
    Private jenis_pot As String = ""
    Private namsal As String = ""

    Sub New(ByVal edits As Boolean, ByVal dvi As DataView, ByVal ps As Integer, ByVal tipe_h As Integer, ByVal jenispot As String, ByVal namasales As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        tipe_harga = tipe_h

        isi_combo2()

        editstat = edits

        jenis_pot = jenispot

        dv = dvi
        dv.Sort = "KD_BARANG"
        posi = ps

        namsal = namasales


    End Sub

    Private Sub isi_box()

        cbbarang.EditValue = dv(posi)("KD_BARANG").ToString
        tsatuan.EditValue = dv(posi)("SATUAN").ToString
        tjml.EditValue = CDbl(dv(posi)("JML").ToString)
        tharga.EditValue = CDbl(dv(posi)("HARGA").ToString)
        ttot.EditValue = CDbl(dv(posi)("TOTAL").ToString)

        harga_beli = dv(posi)("HARGABELI").ToString
        total_beli = dv(posi)("TOTALBELI").ToString

        hargamin = 0 'CType(dv(posi)("HARGABELI").ToString, Double)

    End Sub

    Private Sub isi_combo2()

        Const sql As String = "select a.KODE AS KD_BARANG,a.NAMA,a.SATUAN,a.HARGA1,a.HARGA2,a.HARGA3,b.nama as PRINCIPAL from admlsp.ms_barang a inner join admlsp.ms_principal b on a.kd_prc=b.kd_prc where a.AKTIF=1 order by a.NAMA asc"

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
        Dim total As Double = 0

        total = CDbl(tjml.EditValue) * CDbl(tharga.EditValue)

        total_beli = CDbl(tjml.EditValue) * CDbl(harga_beli)
        ttot.EditValue = total

    End Sub

    Private Sub cbbarang_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbbarang.Validating

        hargamin = 0

        If cbbarang.Text = "" Then
            tsatuan.Text = ""
            tharga.EditValue = 0
            ttot.EditValue = 0
            Exit Sub
        End If

        If IsNothing(dv1) Then
            tsatuan.Text = ""
            tharga.EditValue = 0
            ttot.EditValue = 0
            Exit Sub
        End If

        tsatuan.Text = dv1(cbbarang.ItemIndex)("SATUAN").ToString

        If editstat = False Then

            Select Case tipe_harga
                Case 1
                    tharga.EditValue = dv1(cbbarang.ItemIndex)("HARGA1").ToString
                Case 2
                    tharga.EditValue = dv1(cbbarang.ItemIndex)("HARGA2").ToString
                Case 3
                    tharga.EditValue = dv1(cbbarang.ItemIndex)("HARGA3").ToString
            End Select


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
            tharga.Focus()
        End If
    End Sub

    Private Sub tharga_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tharga.EditValueChanged
        If Not IsNumeric(tjml.EditValue) Then
            tjml.EditValue = 0
        End If

        If Not IsNumeric(tharga.EditValue) Then
            tharga.EditValue = 0
        End If

        totalkanharga()
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
                orow("HARGABELI") = harga_beli
                orow("TOTALBELI") = total_beli

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
            dv(posi)("HARGABELI") = harga_beli
            dv(posi)("TOTALBELI") = total_beli
            dv.Table.AcceptChanges()
            Me.Close()

        End If



    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub t_real3_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If editstat = True Then
            tjml.Focus()
        Else
            tjml.EditValue = 0
            cbbarang.Focus()
        End If
    End Sub

    Private Sub t_real3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        tnote1.Text = String.Format("( SALES : {0} ) |-| ( POT INCENTIVE : {1} )", namsal, jenis_pot)

        If jenis_pot.Trim.ToUpper.Equals("GAJI") Then
            tnote2.Text = "NOTE : HARGA JUAL YANG HARUS DIMASUKKAN ADALAH HARGA ( + ) INCENTIVE SALESMAN"
        Else
            tnote2.Text = "NOTE : HARGA JUAL YANG HARUS DIMASUKKAN ADALAH HARGA ( - ) INCENTIVE SALESMAN"
        End If


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


    Private Sub tjml_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles tjml.EditValueChanged

        If Not IsNumeric(tjml.EditValue) Then
            tjml.EditValue = 0
        End If

        If Not IsNumeric(tharga.EditValue) Then
            tharga.EditValue = 0
        End If

        totalkanharga()
    End Sub
End Class