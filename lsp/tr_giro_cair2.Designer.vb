<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tr_giro_cair2
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbukti = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tuseradd = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ttgl_add = New DevExpress.XtraEditors.TextEdit()
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TOKO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NOGIRO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TANGGALC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.JML = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PROS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEdit3 = New DevExpress.XtraEditors.MemoEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tket = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.tbukti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tuseradd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl_add.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "No Bukti :"
        '
        'tbukti
        '
        Me.tbukti.Location = New System.Drawing.Point(107, 9)
        Me.tbukti.Name = "tbukti"
        Me.tbukti.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbukti.Properties.Appearance.Options.UseFont = True
        Me.tbukti.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbukti.Properties.ReadOnly = True
        Me.tbukti.Size = New System.Drawing.Size(129, 22)
        Me.tbukti.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 16)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Dicairkan oleh user :"
        '
        'tuseradd
        '
        Me.tuseradd.Location = New System.Drawing.Point(22, 115)
        Me.tuseradd.Name = "tuseradd"
        Me.tuseradd.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tuseradd.Properties.Appearance.Options.UseFont = True
        Me.tuseradd.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tuseradd.Properties.ReadOnly = True
        Me.tuseradd.Size = New System.Drawing.Size(223, 22)
        Me.tuseradd.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(248, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 16)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Pada tanggal :"
        '
        'ttgl_add
        '
        Me.ttgl_add.Location = New System.Drawing.Point(251, 115)
        Me.ttgl_add.Name = "ttgl_add"
        Me.ttgl_add.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttgl_add.Properties.Appearance.Options.UseFont = True
        Me.ttgl_add.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ttgl_add.Properties.ReadOnly = True
        Me.ttgl_add.Size = New System.Drawing.Size(113, 22)
        Me.ttgl_add.TabIndex = 42
        '
        'grid1
        '
        Me.grid1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.grid1.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.grid1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grid1.Location = New System.Drawing.Point(12, 144)
        Me.grid1.MainView = Me.gridview
        Me.grid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grid1.Name = "grid1"
        Me.grid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.grid1.Size = New System.Drawing.Size(502, 228)
        Me.grid1.TabIndex = 134
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridview})
        '
        'gridview
        '
        Me.gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TOKO, Me.NOGIRO, Me.TANGGALC, Me.JML, Me.PROS})
        StyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition1.Appearance.Options.UseForeColor = True
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Value1 = "PUSAT"
        StyleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition2.Appearance.Options.UseForeColor = True
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition2.Value1 = "CABANG"
        Me.gridview.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2})
        Me.gridview.GridControl = Me.grid1
        Me.gridview.Name = "gridview"
        Me.gridview.OptionsView.ShowGroupPanel = False
        Me.gridview.OptionsView.ShowViewCaption = True
        Me.gridview.ViewCaption = "- DAFTAR GIRO -"
        '
        'TOKO
        '
        Me.TOKO.Caption = "Toko"
        Me.TOKO.FieldName = "NAMA_TOKO"
        Me.TOKO.Name = "TOKO"
        Me.TOKO.OptionsColumn.AllowEdit = False
        Me.TOKO.Visible = True
        Me.TOKO.VisibleIndex = 0
        Me.TOKO.Width = 124
        '
        'NOGIRO
        '
        Me.NOGIRO.Caption = "No Giro"
        Me.NOGIRO.FieldName = "NO_GIRO"
        Me.NOGIRO.Name = "NOGIRO"
        Me.NOGIRO.OptionsColumn.AllowEdit = False
        Me.NOGIRO.Visible = True
        Me.NOGIRO.VisibleIndex = 1
        Me.NOGIRO.Width = 110
        '
        'TANGGALC
        '
        Me.TANGGALC.Caption = "Tgl Cair"
        Me.TANGGALC.FieldName = "TGL_TEMPO"
        Me.TANGGALC.Name = "TANGGALC"
        Me.TANGGALC.OptionsColumn.AllowEdit = False
        Me.TANGGALC.Visible = True
        Me.TANGGALC.VisibleIndex = 2
        Me.TANGGALC.Width = 100
        '
        'JML
        '
        Me.JML.AppearanceHeader.Options.UseTextOptions = True
        Me.JML.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.JML.Caption = "Jumlah"
        Me.JML.DisplayFormat.FormatString = "n"
        Me.JML.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.JML.FieldName = "NILAI"
        Me.JML.Name = "JML"
        Me.JML.OptionsColumn.AllowEdit = False
        Me.JML.Visible = True
        Me.JML.VisibleIndex = 3
        Me.JML.Width = 94
        '
        'PROS
        '
        Me.PROS.AppearanceHeader.Options.UseTextOptions = True
        Me.PROS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PROS.Caption = "Proses"
        Me.PROS.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.PROS.FieldName = "PROSES"
        Me.PROS.Name = "PROS"
        Me.PROS.Visible = True
        Me.PROS.VisibleIndex = 4
        Me.PROS.Width = 56
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.DisplayValueChecked = "1"
        Me.RepositoryItemCheckEdit1.DisplayValueGrayed = "-1"
        Me.RepositoryItemCheckEdit1.DisplayValueUnchecked = "0"
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(439, 379)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 75)
        Me.btsimpan.TabIndex = 135
        Me.btsimpan.Text = "&Proses"
        '
        'TextEdit3
        '
        Me.TextEdit3.EditValue = "Pastikan Giro yang anda masukkan BENAR, karena data yang sudah dilunasi tidak dap" & _
            "at DIEDIT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SEMUA PELUNASAN yang menyangkut giro tersebut akan OTOMATIS TERLUNA" & _
            "SI"
        Me.TextEdit3.Location = New System.Drawing.Point(12, 379)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.TextEdit3.Properties.Appearance.Options.UseFont = True
        Me.TextEdit3.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit3.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TextEdit3.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TextEdit3.Properties.ReadOnly = True
        Me.TextEdit3.Size = New System.Drawing.Size(421, 75)
        Me.TextEdit3.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 16)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Keterangan :"
        '
        'tket
        '
        Me.tket.Location = New System.Drawing.Point(106, 37)
        Me.tket.Name = "tket"
        Me.tket.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tket.Properties.Appearance.Options.UseFont = True
        Me.tket.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tket.Size = New System.Drawing.Size(407, 45)
        Me.tket.TabIndex = 138
        '
        'tr_giro_cair2
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 463)
        Me.Controls.Add(Me.TextEdit3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btsimpan)
        Me.Controls.Add(Me.grid1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ttgl_add)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tuseradd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbukti)
        Me.Controls.Add(Me.tket)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "tr_giro_cair2"
        Me.Text = "Pencairan Giro Detail"
        CType(Me.tbukti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tuseradd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl_add.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbukti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tuseradd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ttgl_add As DevExpress.XtraEditors.TextEdit
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TOKO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NOGIRO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TANGGALC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents JML As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PROS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tket As DevExpress.XtraEditors.MemoEdit
End Class
