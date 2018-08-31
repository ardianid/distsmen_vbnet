<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tr_kas_out2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tr_kas_out2))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.ttgl = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbjeniskas = New DevExpress.XtraEditors.LookUpEdit()
        Me.tbukti = New DevExpress.XtraEditors.TextEdit()
        Me.tket = New DevExpress.XtraEditors.MemoEdit()
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NAMA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.JML = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DESK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.KDAKUN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btadd_det = New DevExpress.XtraEditors.SimpleButton()
        Me.btdel_det = New DevExpress.XtraEditors.SimpleButton()
        Me.bted_det = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbjeniskas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbukti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.Appearance.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Right
        Me.GroupControl1.Controls.Add(Me.btadd_det)
        Me.GroupControl1.Controls.Add(Me.btdel_det)
        Me.GroupControl1.Controls.Add(Me.bted_det)
        Me.GroupControl1.Controls.Add(Me.grid1)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.btkeluar)
        Me.GroupControl1.Controls.Add(Me.btsimpan)
        Me.GroupControl1.Controls.Add(Me.ttgl)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.cbjeniskas)
        Me.GroupControl1.Controls.Add(Me.tbukti)
        Me.GroupControl1.Controls.Add(Me.tket)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.LookAndFeel.SkinName = "VS2010"
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(659, 374)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Kas keluar detail ..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Keterangan :"
        '
        'btkeluar
        '
        Me.btkeluar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btkeluar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btkeluar.Appearance.Options.UseFont = True
        Me.btkeluar.Location = New System.Drawing.Point(572, 342)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(75, 27)
        Me.btkeluar.TabIndex = 6
        Me.btkeluar.Text = "Se&lesai"
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(491, 342)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 27)
        Me.btsimpan.TabIndex = 5
        Me.btsimpan.Text = "&Simpan"
        '
        'ttgl
        '
        Me.ttgl.EditValue = Nothing
        Me.ttgl.Location = New System.Drawing.Point(115, 40)
        Me.ttgl.Name = "ttgl"
        Me.ttgl.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttgl.Properties.Appearance.Options.UseFont = True
        Me.ttgl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ttgl.Properties.Mask.EditMask = ""
        Me.ttgl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.ttgl.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ttgl.Size = New System.Drawing.Size(129, 22)
        Me.ttgl.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Tanggal :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "No Bukti :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Kas :"
        '
        'cbjeniskas
        '
        Me.cbjeniskas.Location = New System.Drawing.Point(115, 68)
        Me.cbjeniskas.Name = "cbjeniskas"
        Me.cbjeniskas.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbjeniskas.Properties.Appearance.Options.UseFont = True
        Me.cbjeniskas.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbjeniskas.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("KODE", "Kode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAMA", "Nama"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATUS", "Status")})
        Me.cbjeniskas.Properties.DisplayMember = "NAMA"
        Me.cbjeniskas.Properties.NullText = ""
        Me.cbjeniskas.Properties.ValueMember = "KODE"
        Me.cbjeniskas.Size = New System.Drawing.Size(344, 22)
        Me.cbjeniskas.TabIndex = 2
        '
        'tbukti
        '
        Me.tbukti.Location = New System.Drawing.Point(115, 12)
        Me.tbukti.Name = "tbukti"
        Me.tbukti.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbukti.Properties.Appearance.Options.UseFont = True
        Me.tbukti.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbukti.Properties.ReadOnly = True
        Me.tbukti.Size = New System.Drawing.Size(129, 22)
        Me.tbukti.TabIndex = 0
        '
        'tket
        '
        Me.tket.Location = New System.Drawing.Point(115, 96)
        Me.tket.Name = "tket"
        Me.tket.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tket.Properties.Appearance.Options.UseFont = True
        Me.tket.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tket.Size = New System.Drawing.Size(344, 54)
        Me.tket.TabIndex = 4
        '
        'grid1
        '
        Me.grid1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.grid1.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.grid1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grid1.Location = New System.Drawing.Point(5, 157)
        Me.grid1.MainView = Me.gridview
        Me.grid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grid1.Name = "grid1"
        Me.grid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.grid1.Size = New System.Drawing.Size(642, 178)
        Me.grid1.TabIndex = 135
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridview})
        '
        'gridview
        '
        Me.gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NAMA, Me.JML, Me.DESK, Me.KDAKUN})
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
        Me.gridview.OptionsView.ShowFooter = True
        Me.gridview.OptionsView.ShowGroupPanel = False
        Me.gridview.OptionsView.ShowViewCaption = True
        Me.gridview.ViewCaption = "- BARANG -"
        '
        'NAMA
        '
        Me.NAMA.Caption = "Nama"
        Me.NAMA.FieldName = "NAMA"
        Me.NAMA.Name = "NAMA"
        Me.NAMA.OptionsColumn.AllowEdit = False
        Me.NAMA.Visible = True
        Me.NAMA.VisibleIndex = 0
        Me.NAMA.Width = 229
        '
        'JML
        '
        Me.JML.AppearanceHeader.Options.UseTextOptions = True
        Me.JML.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.JML.Caption = "Jml"
        Me.JML.DisplayFormat.FormatString = "n0"
        Me.JML.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.JML.FieldName = "JML"
        Me.JML.Name = "JML"
        Me.JML.OptionsColumn.AllowEdit = False
        Me.JML.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "JML", "{0:n0}")})
        Me.JML.Visible = True
        Me.JML.VisibleIndex = 1
        Me.JML.Width = 125
        '
        'DESK
        '
        Me.DESK.Caption = "Deskripsi"
        Me.DESK.FieldName = "DESKRIPSI"
        Me.DESK.Name = "DESK"
        Me.DESK.OptionsColumn.AllowEdit = False
        Me.DESK.Visible = True
        Me.DESK.VisibleIndex = 2
        Me.DESK.Width = 272
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
        'KDAKUN
        '
        Me.KDAKUN.Caption = "KDAKUN"
        Me.KDAKUN.FieldName = "KD_AKUN"
        Me.KDAKUN.Name = "KDAKUN"
        Me.KDAKUN.OptionsColumn.AllowEdit = False
        '
        'btadd_det
        '
        Me.btadd_det.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btadd_det.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btadd_det.Appearance.Options.UseFont = True
        Me.btadd_det.Image = CType(resources.GetObject("btadd_det.Image"), System.Drawing.Image)
        Me.btadd_det.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btadd_det.Location = New System.Drawing.Point(5, 342)
        Me.btadd_det.Name = "btadd_det"
        Me.btadd_det.Size = New System.Drawing.Size(34, 24)
        Me.btadd_det.TabIndex = 136
        Me.btadd_det.ToolTip = "Tambah data barang"
        '
        'btdel_det
        '
        Me.btdel_det.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btdel_det.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btdel_det.Appearance.Options.UseFont = True
        Me.btdel_det.Image = CType(resources.GetObject("btdel_det.Image"), System.Drawing.Image)
        Me.btdel_det.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btdel_det.Location = New System.Drawing.Point(75, 342)
        Me.btdel_det.Name = "btdel_det"
        Me.btdel_det.Size = New System.Drawing.Size(34, 24)
        Me.btdel_det.TabIndex = 138
        Me.btdel_det.ToolTip = "Hapus data barang"
        '
        'bted_det
        '
        Me.bted_det.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bted_det.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bted_det.Appearance.Options.UseFont = True
        Me.bted_det.Image = CType(resources.GetObject("bted_det.Image"), System.Drawing.Image)
        Me.bted_det.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.bted_det.Location = New System.Drawing.Point(40, 342)
        Me.bted_det.Name = "bted_det"
        Me.bted_det.Size = New System.Drawing.Size(34, 24)
        Me.bted_det.TabIndex = 137
        Me.bted_det.ToolTip = "Edit data barang"
        '
        'tr_kas_out2
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 374)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "tr_kas_out2"
        Me.Text = "Kas Keluar Detail"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbjeniskas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbukti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ttgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbjeniskas As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents tbukti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tket As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NAMA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents JML As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DESK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents KDAKUN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btadd_det As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btdel_det As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bted_det As DevExpress.XtraEditors.SimpleButton
End Class
