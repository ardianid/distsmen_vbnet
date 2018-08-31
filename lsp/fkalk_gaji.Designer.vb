<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fkalk_gaji
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fkalk_gaji))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.ttahun = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbbulan = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbstatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbjeniskas = New DevExpress.XtraEditors.LookUpEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.bted_det = New DevExpress.XtraEditors.SimpleButton()
        Me.btkasbon = New DevExpress.XtraEditors.SimpleButton()
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NOO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NAMASPR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAJISEMEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAJILAIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.POT_KASBON = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TOTGAJI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.POT_LAIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KET = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NOID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.ttahun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbbulan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbstatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.cbjeniskas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ttahun
        '
        Me.ttahun.Location = New System.Drawing.Point(82, 12)
        Me.ttahun.Name = "ttahun"
        Me.ttahun.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttahun.Properties.Appearance.Options.UseFont = True
        Me.ttahun.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ttahun.Properties.ReadOnly = True
        Me.ttahun.Size = New System.Drawing.Size(73, 22)
        Me.ttahun.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tahun :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(196, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Bulan :"
        '
        'cbbulan
        '
        Me.cbbulan.Location = New System.Drawing.Point(255, 14)
        Me.cbbulan.Name = "cbbulan"
        Me.cbbulan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbbulan.Properties.Items.AddRange(New Object() {"JANUARI", "FEBRUARI", "MARET", "APRIL", "MEI", "JUNI", "JULI", "AGUSTUS", "SEPTEMBER", "OKTOBER", "NOVEMBER", "DESEMBER"})
        Me.cbbulan.Size = New System.Drawing.Size(176, 20)
        Me.cbbulan.TabIndex = 0
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(459, 17)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(81, 42)
        Me.btsimpan.TabIndex = 3
        Me.btsimpan.Text = "&Proses"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Area :"
        '
        'cbstatus
        '
        Me.cbstatus.Location = New System.Drawing.Point(82, 40)
        Me.cbstatus.Name = "cbstatus"
        Me.cbstatus.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbstatus.Properties.Appearance.Options.UseFont = True
        Me.cbstatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbstatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("KODE", "Kode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAMA", "Area"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATUS", "Status")})
        Me.cbstatus.Properties.DisplayMember = "NAMA"
        Me.cbstatus.Properties.NullText = ""
        Me.cbstatus.Properties.ValueMember = "KODE"
        Me.cbstatus.Size = New System.Drawing.Size(349, 22)
        Me.cbstatus.TabIndex = 1
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cbjeniskas)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cbbulan)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ttahun)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cbstatus)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btsimpan)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.TextEdit1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.bted_det)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btkasbon)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.grid1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(738, 510)
        Me.SplitContainerControl1.SplitterPosition = 121
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(340, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(387, 16)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "* Kas ini digunakan untuk pengurangan otomatis potongan kasbon"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 16)
        Me.Label8.TabIndex = 149
        Me.Label8.Text = "Kas :"
        '
        'cbjeniskas
        '
        Me.cbjeniskas.Location = New System.Drawing.Point(82, 68)
        Me.cbjeniskas.Name = "cbjeniskas"
        Me.cbjeniskas.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbjeniskas.Properties.Appearance.Options.UseFont = True
        Me.cbjeniskas.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbjeniskas.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("KODE", "Kode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAMA", "Nama"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATUS", "Status")})
        Me.cbjeniskas.Properties.DisplayMember = "NAMA"
        Me.cbjeniskas.Properties.NullText = ""
        Me.cbjeniskas.Properties.ValueMember = "KODE"
        Me.cbjeniskas.Size = New System.Drawing.Size(252, 22)
        Me.cbjeniskas.TabIndex = 2
        '
        'TextEdit1
        '
        Me.TextEdit1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextEdit1.EditValue = "WARNING !!! SETIAP PROSES YANG DILAKUKAN AKAN MENGHAPUS KALKULASI SEBELUMNYA "
        Me.TextEdit1.Location = New System.Drawing.Point(0, 101)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.TextEdit1.Properties.Appearance.Options.UseFont = True
        Me.TextEdit1.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit1.Properties.Appearance.Options.UseTextOptions = True
        Me.TextEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TextEdit1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TextEdit1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEdit1.Size = New System.Drawing.Size(738, 20)
        Me.TextEdit1.TabIndex = 6
        '
        'bted_det
        '
        Me.bted_det.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bted_det.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bted_det.Appearance.Options.UseFont = True
        Me.bted_det.Image = CType(resources.GetObject("bted_det.Image"), System.Drawing.Image)
        Me.bted_det.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.bted_det.Location = New System.Drawing.Point(8, 349)
        Me.bted_det.Name = "bted_det"
        Me.bted_det.Size = New System.Drawing.Size(34, 24)
        Me.bted_det.TabIndex = 5
        Me.bted_det.ToolTip = "Edit Kasbon"
        '
        'btkasbon
        '
        Me.btkasbon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btkasbon.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btkasbon.Appearance.Options.UseFont = True
        Me.btkasbon.Location = New System.Drawing.Point(654, 352)
        Me.btkasbon.Name = "btkasbon"
        Me.btkasbon.Size = New System.Drawing.Size(81, 28)
        Me.btkasbon.TabIndex = 4
        Me.btkasbon.Text = "&Simpan"
        '
        'grid1
        '
        Me.grid1.Dock = System.Windows.Forms.DockStyle.Top
        Me.grid1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.grid1.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.grid1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grid1.Location = New System.Drawing.Point(0, 0)
        Me.grid1.MainView = Me.gridview
        Me.grid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grid1.Name = "grid1"
        Me.grid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.grid1.Size = New System.Drawing.Size(738, 345)
        Me.grid1.TabIndex = 1
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridview})
        '
        'gridview
        '
        Me.gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NOO, Me.NAMASPR, Me.GAJISEMEN, Me.GAJILAIN, Me.POT_KASBON, Me.TOTGAJI, Me.POT_LAIN, Me.KET, Me.NOID})
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
        Me.gridview.ViewCaption = "- DAFTAR GAJI -"
        '
        'NOO
        '
        Me.NOO.AppearanceHeader.Options.UseTextOptions = True
        Me.NOO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.NOO.Caption = "No"
        Me.NOO.FieldName = "NO"
        Me.NOO.Name = "NOO"
        Me.NOO.OptionsColumn.AllowEdit = False
        Me.NOO.Width = 28
        '
        'NAMASPR
        '
        Me.NAMASPR.Caption = "Nama Supir"
        Me.NAMASPR.FieldName = "NAMA"
        Me.NAMASPR.Name = "NAMASPR"
        Me.NAMASPR.OptionsColumn.AllowEdit = False
        Me.NAMASPR.Visible = True
        Me.NAMASPR.VisibleIndex = 0
        Me.NAMASPR.Width = 156
        '
        'GAJISEMEN
        '
        Me.GAJISEMEN.AppearanceHeader.Options.UseTextOptions = True
        Me.GAJISEMEN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GAJISEMEN.Caption = "Gaji Angk Semen"
        Me.GAJISEMEN.DisplayFormat.FormatString = "n2"
        Me.GAJISEMEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAJISEMEN.FieldName = "JML_SEMEN"
        Me.GAJISEMEN.Name = "GAJISEMEN"
        Me.GAJISEMEN.OptionsColumn.AllowEdit = False
        Me.GAJISEMEN.Visible = True
        Me.GAJISEMEN.VisibleIndex = 1
        Me.GAJISEMEN.Width = 126
        '
        'GAJILAIN
        '
        Me.GAJILAIN.AppearanceHeader.Options.UseTextOptions = True
        Me.GAJILAIN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GAJILAIN.Caption = "Gaji Angk Lain"
        Me.GAJILAIN.DisplayFormat.FormatString = "n2"
        Me.GAJILAIN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAJILAIN.FieldName = "JML_LAIN"
        Me.GAJILAIN.Name = "GAJILAIN"
        Me.GAJILAIN.OptionsColumn.AllowEdit = False
        Me.GAJILAIN.Visible = True
        Me.GAJILAIN.VisibleIndex = 2
        Me.GAJILAIN.Width = 113
        '
        'POT_KASBON
        '
        Me.POT_KASBON.AppearanceHeader.Options.UseTextOptions = True
        Me.POT_KASBON.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.POT_KASBON.Caption = "Pot Kasbon"
        Me.POT_KASBON.DisplayFormat.FormatString = "n2"
        Me.POT_KASBON.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.POT_KASBON.FieldName = "POT_KASBON"
        Me.POT_KASBON.Name = "POT_KASBON"
        Me.POT_KASBON.OptionsColumn.AllowEdit = False
        Me.POT_KASBON.Visible = True
        Me.POT_KASBON.VisibleIndex = 4
        Me.POT_KASBON.Width = 87
        '
        'TOTGAJI
        '
        Me.TOTGAJI.AppearanceHeader.Options.UseTextOptions = True
        Me.TOTGAJI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TOTGAJI.Caption = "Total Gaji"
        Me.TOTGAJI.DisplayFormat.FormatString = "n2"
        Me.TOTGAJI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TOTGAJI.FieldName = "TOT_GAJI"
        Me.TOTGAJI.Name = "TOTGAJI"
        Me.TOTGAJI.OptionsColumn.AllowEdit = False
        Me.TOTGAJI.Visible = True
        Me.TOTGAJI.VisibleIndex = 3
        Me.TOTGAJI.Width = 103
        '
        'POT_LAIN
        '
        Me.POT_LAIN.AppearanceHeader.Options.UseTextOptions = True
        Me.POT_LAIN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.POT_LAIN.Caption = "Pot Lain"
        Me.POT_LAIN.DisplayFormat.FormatString = "n2"
        Me.POT_LAIN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.POT_LAIN.FieldName = "POT_LAIN"
        Me.POT_LAIN.Name = "POT_LAIN"
        Me.POT_LAIN.Width = 100
        '
        'KET
        '
        Me.KET.Caption = "Keterangan"
        Me.KET.FieldName = "KETERANGAN"
        Me.KET.Name = "KET"
        Me.KET.OptionsColumn.AllowEdit = False
        Me.KET.Visible = True
        Me.KET.VisibleIndex = 5
        Me.KET.Width = 226
        '
        'NOID
        '
        Me.NOID.Caption = "ID"
        Me.NOID.FieldName = "ID"
        Me.NOID.Name = "NOID"
        Me.NOID.OptionsColumn.AllowEdit = False
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
        'fkalk_gaji
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 510)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fkalk_gaji"
        Me.Text = "Kalkulasi Gaji Supir"
        CType(Me.ttahun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbbulan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbstatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.cbjeniskas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ttahun As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbulan As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbstatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NOO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents btkasbon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents NAMASPR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAJISEMEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAJILAIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents POT_KASBON As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents POT_LAIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NOID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents bted_det As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TOTGAJI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbjeniskas As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
