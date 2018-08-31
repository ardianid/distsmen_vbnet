<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ms_barang2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ms_barang2))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.tinsentif = New DevExpress.XtraEditors.TextEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tkode = New DevExpress.XtraEditors.TextEdit()
        Me.cbunit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.thargajual3 = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.thargajual1 = New DevExpress.XtraEditors.TextEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.thargajual2 = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tvolum = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.tsatuan = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.caktif = New DevExpress.XtraEditors.CheckEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbprinc = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btadd_det = New DevExpress.XtraEditors.SimpleButton()
        Me.btdel_det = New DevExpress.XtraEditors.SimpleButton()
        Me.bted_det = New DevExpress.XtraEditors.SimpleButton()
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NAMA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.JML = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KDKAB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.tinsentif.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbunit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.thargajual3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.thargajual1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.thargajual2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tvolum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tsatuan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.caktif.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbprinc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.SplitContainerControl1)
        Me.GroupControl1.Controls.Add(Me.btkeluar)
        Me.GroupControl1.Controls.Add(Me.btsimpan)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.ShowCaption = False
        Me.GroupControl1.Size = New System.Drawing.Size(875, 396)
        Me.GroupControl1.TabIndex = 20
        Me.GroupControl1.Text = "Data Barang Detail"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainerControl1.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl1.Panel1.CaptionLocation = DevExpress.Utils.Locations.Bottom
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tinsentif)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tkode)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cbunit)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.thargajual3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.thargajual1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.thargajual2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tvolum)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tnama)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tsatuan)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.caktif)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cbprinc)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainerControl1.Panel1.ShowCaption = True
        Me.SplitContainerControl1.Panel1.Text = "Barang Detail"
        Me.SplitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Bottom
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btadd_det)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btdel_det)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.bted_det)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.grid1)
        Me.SplitContainerControl1.Panel2.ShowCaption = True
        Me.SplitContainerControl1.Panel2.Text = "Area Tebusan"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(871, 358)
        Me.SplitContainerControl1.SplitterPosition = 406
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'tinsentif
        '
        Me.tinsentif.Location = New System.Drawing.Point(112, 182)
        Me.tinsentif.Name = "tinsentif"
        Me.tinsentif.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tinsentif.Properties.Appearance.Options.UseFont = True
        Me.tinsentif.Properties.Appearance.Options.UseTextOptions = True
        Me.tinsentif.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.tinsentif.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tinsentif.Properties.Mask.EditMask = "n"
        Me.tinsentif.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tinsentif.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tinsentif.Size = New System.Drawing.Size(140, 22)
        Me.tinsentif.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 185)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 16)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Pot Insentif :"
        '
        'tkode
        '
        Me.tkode.Location = New System.Drawing.Point(112, 14)
        Me.tkode.Name = "tkode"
        Me.tkode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tkode.Properties.Appearance.Options.UseFont = True
        Me.tkode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkode.Size = New System.Drawing.Size(73, 22)
        Me.tkode.TabIndex = 0
        '
        'cbunit
        '
        Me.cbunit.Location = New System.Drawing.Point(112, 156)
        Me.cbunit.Name = "cbunit"
        Me.cbunit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbunit.Properties.Items.AddRange(New Object() {"@ 40 Kg", "@ 50 Kg"})
        Me.cbunit.Size = New System.Drawing.Size(73, 20)
        Me.cbunit.TabIndex = 4
        '
        'thargajual3
        '
        Me.thargajual3.Location = New System.Drawing.Point(112, 266)
        Me.thargajual3.Name = "thargajual3"
        Me.thargajual3.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.thargajual3.Properties.Appearance.Options.UseFont = True
        Me.thargajual3.Properties.Appearance.Options.UseTextOptions = True
        Me.thargajual3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.thargajual3.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.thargajual3.Properties.Mask.EditMask = "n"
        Me.thargajual3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.thargajual3.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.thargajual3.Size = New System.Drawing.Size(140, 22)
        Me.thargajual3.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 16)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Unit :"
        '
        'thargajual1
        '
        Me.thargajual1.Location = New System.Drawing.Point(112, 210)
        Me.thargajual1.Name = "thargajual1"
        Me.thargajual1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.thargajual1.Properties.Appearance.Options.UseFont = True
        Me.thargajual1.Properties.Appearance.Options.UseTextOptions = True
        Me.thargajual1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.thargajual1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.thargajual1.Properties.Mask.EditMask = "n"
        Me.thargajual1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.thargajual1.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.thargajual1.Size = New System.Drawing.Size(140, 22)
        Me.thargajual1.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 269)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Harga Jual 3 :"
        '
        'thargajual2
        '
        Me.thargajual2.Location = New System.Drawing.Point(112, 238)
        Me.thargajual2.Name = "thargajual2"
        Me.thargajual2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.thargajual2.Properties.Appearance.Options.UseFont = True
        Me.thargajual2.Properties.Appearance.Options.UseTextOptions = True
        Me.thargajual2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.thargajual2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.thargajual2.Properties.Mask.EditMask = "n"
        Me.thargajual2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.thargajual2.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.thargajual2.Size = New System.Drawing.Size(140, 22)
        Me.thargajual2.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Harga Jual 2 :"
        '
        'tvolum
        '
        Me.tvolum.Location = New System.Drawing.Point(112, 98)
        Me.tvolum.Name = "tvolum"
        Me.tvolum.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvolum.Properties.Appearance.Options.UseFont = True
        Me.tvolum.Properties.Appearance.Options.UseTextOptions = True
        Me.tvolum.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.tvolum.Properties.Mask.EditMask = "d"
        Me.tvolum.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tvolum.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tvolum.Properties.ReadOnly = True
        Me.tvolum.Size = New System.Drawing.Size(73, 22)
        Me.tvolum.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 213)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Harga Jual 1 :"
        '
        'tnama
        '
        Me.tnama.Location = New System.Drawing.Point(112, 42)
        Me.tnama.Name = "tnama"
        Me.tnama.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnama.Properties.Appearance.Options.UseFont = True
        Me.tnama.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnama.Size = New System.Drawing.Size(279, 22)
        Me.tnama.TabIndex = 1
        '
        'tsatuan
        '
        Me.tsatuan.Location = New System.Drawing.Point(112, 126)
        Me.tsatuan.Name = "tsatuan"
        Me.tsatuan.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsatuan.Properties.Appearance.Options.UseFont = True
        Me.tsatuan.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tsatuan.Size = New System.Drawing.Size(73, 22)
        Me.tsatuan.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Satuan :"
        '
        'caktif
        '
        Me.caktif.Location = New System.Drawing.Point(110, 302)
        Me.caktif.Name = "caktif"
        Me.caktif.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.caktif.Properties.Appearance.Options.UseFont = True
        Me.caktif.Properties.Caption = "&Aktif"
        Me.caktif.Size = New System.Drawing.Size(60, 21)
        Me.caktif.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Volume :"
        '
        'cbprinc
        '
        Me.cbprinc.Location = New System.Drawing.Point(112, 70)
        Me.cbprinc.Name = "cbprinc"
        Me.cbprinc.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbprinc.Properties.Appearance.Options.UseFont = True
        Me.cbprinc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbprinc.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("KD_PRC", "Kode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAMA", "Area")})
        Me.cbprinc.Properties.DisplayMember = "NAMA"
        Me.cbprinc.Properties.NullText = ""
        Me.cbprinc.Properties.ShowHeader = False
        Me.cbprinc.Properties.ValueMember = "KD_PRC"
        Me.cbprinc.Size = New System.Drawing.Size(279, 22)
        Me.cbprinc.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Kode :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Principal :"
        '
        'btadd_det
        '
        Me.btadd_det.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btadd_det.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btadd_det.Appearance.Options.UseFont = True
        Me.btadd_det.Image = CType(resources.GetObject("btadd_det.Image"), System.Drawing.Image)
        Me.btadd_det.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btadd_det.Location = New System.Drawing.Point(9, 304)
        Me.btadd_det.Name = "btadd_det"
        Me.btadd_det.Size = New System.Drawing.Size(34, 24)
        Me.btadd_det.TabIndex = 1
        Me.btadd_det.ToolTip = "Tambah data barang"
        '
        'btdel_det
        '
        Me.btdel_det.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btdel_det.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btdel_det.Appearance.Options.UseFont = True
        Me.btdel_det.Image = CType(resources.GetObject("btdel_det.Image"), System.Drawing.Image)
        Me.btdel_det.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btdel_det.Location = New System.Drawing.Point(79, 304)
        Me.btdel_det.Name = "btdel_det"
        Me.btdel_det.Size = New System.Drawing.Size(34, 24)
        Me.btdel_det.TabIndex = 3
        Me.btdel_det.ToolTip = "Hapus data barang"
        '
        'bted_det
        '
        Me.bted_det.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bted_det.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bted_det.Appearance.Options.UseFont = True
        Me.bted_det.Image = CType(resources.GetObject("bted_det.Image"), System.Drawing.Image)
        Me.bted_det.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.bted_det.Location = New System.Drawing.Point(44, 304)
        Me.bted_det.Name = "bted_det"
        Me.bted_det.Size = New System.Drawing.Size(34, 24)
        Me.bted_det.TabIndex = 2
        Me.bted_det.ToolTip = "Edit data barang"
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
        Me.grid1.Size = New System.Drawing.Size(455, 301)
        Me.grid1.TabIndex = 0
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridview})
        '
        'gridview
        '
        Me.gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NAMA, Me.JML, Me.KDKAB})
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
        Me.gridview.ViewCaption = "- AREA TEBUSAN -"
        '
        'NAMA
        '
        Me.NAMA.Caption = "Kabupaten"
        Me.NAMA.FieldName = "NAMA"
        Me.NAMA.Name = "NAMA"
        Me.NAMA.OptionsColumn.AllowEdit = False
        Me.NAMA.Visible = True
        Me.NAMA.VisibleIndex = 0
        Me.NAMA.Width = 289
        '
        'JML
        '
        Me.JML.AppearanceHeader.Options.UseTextOptions = True
        Me.JML.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.JML.Caption = "Harga Tebusan"
        Me.JML.DisplayFormat.FormatString = "n4"
        Me.JML.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.JML.FieldName = "HARGA"
        Me.JML.Name = "JML"
        Me.JML.OptionsColumn.AllowEdit = False
        Me.JML.Visible = True
        Me.JML.VisibleIndex = 1
        Me.JML.Width = 149
        '
        'KDKAB
        '
        Me.KDKAB.Caption = "KDKAB"
        Me.KDKAB.FieldName = "KD_KAB"
        Me.KDKAB.Name = "KDKAB"
        Me.KDKAB.OptionsColumn.AllowEdit = False
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
        'btkeluar
        '
        Me.btkeluar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btkeluar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btkeluar.Appearance.Options.UseFont = True
        Me.btkeluar.Location = New System.Drawing.Point(798, 366)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(75, 27)
        Me.btkeluar.TabIndex = 9
        Me.btkeluar.Text = "Se&lesai"
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(717, 366)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 27)
        Me.btsimpan.TabIndex = 8
        Me.btsimpan.Text = "&Simpan"
        '
        'ms_barang2
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 396)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ms_barang2"
        Me.Text = "Data Barang Detail"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.tinsentif.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbunit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.thargajual3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.thargajual1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.thargajual2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tvolum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tsatuan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.caktif.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbprinc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbprinc As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents caktif As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tkode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tsatuan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tvolum As DevExpress.XtraEditors.TextEdit
    Friend WithEvents thargajual2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents thargajual1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents thargajual3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbunit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NAMA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents JML As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KDKAB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents btadd_det As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btdel_det As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bted_det As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tinsentif As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
