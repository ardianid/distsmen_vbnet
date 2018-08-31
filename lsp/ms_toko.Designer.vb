<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ms_toko
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ms_toko))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.bn1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsadd = New System.Windows.Forms.ToolStripButton()
        Me.tsedit = New System.Windows.Forms.ToolStripButton()
        Me.tsdel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cbfind = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tsfind = New System.Windows.Forms.ToolStripTextBox()
        Me.btfind = New System.Windows.Forms.ToolStripButton()
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AKTIF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.KD_TOKO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NAMA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ALAMAT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TTL_DEPOSIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TTL_GIRO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TTL_HUTANG = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.bn1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bn1.SuspendLayout()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bn1
        '
        Me.bn1.AddNewItem = Nothing
        Me.bn1.CountItem = Me.BindingNavigatorCountItem
        Me.bn1.DeleteItem = Nothing
        Me.bn1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bn1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.bn1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.tsadd, Me.tsedit, Me.tsdel, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.cbfind, Me.ToolStripButton1, Me.tsfind, Me.btfind})
        Me.bn1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.bn1.Location = New System.Drawing.Point(0, 0)
        Me.bn1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bn1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bn1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bn1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bn1.Name = "bn1"
        Me.bn1.PositionItem = Me.BindingNavigatorPositionItem
        Me.bn1.Size = New System.Drawing.Size(912, 36)
        Me.bn1.TabIndex = 126
        Me.bn1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 33)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 33)
        Me.BindingNavigatorMoveFirstItem.Tag = "True"
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 33)
        Me.BindingNavigatorMovePreviousItem.Tag = "True"
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 36)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(58, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 36)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 33)
        Me.BindingNavigatorMoveNextItem.Tag = "True"
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 33)
        Me.BindingNavigatorMoveLastItem.Tag = "True"
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 36)
        '
        'tsadd
        '
        Me.tsadd.AutoSize = False
        Me.tsadd.Image = CType(resources.GetObject("tsadd.Image"), System.Drawing.Image)
        Me.tsadd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsadd.Name = "tsadd"
        Me.tsadd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsadd.Size = New System.Drawing.Size(49, 33)
        Me.tsadd.Text = "&Tambah"
        Me.tsadd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsadd.ToolTipText = "Tambah data"
        '
        'tsedit
        '
        Me.tsedit.AutoSize = False
        Me.tsedit.Image = CType(resources.GetObject("tsedit.Image"), System.Drawing.Image)
        Me.tsedit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsedit.Name = "tsedit"
        Me.tsedit.Size = New System.Drawing.Size(49, 33)
        Me.tsedit.Text = "&Edit"
        Me.tsedit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsedit.ToolTipText = "Rubah data"
        '
        'tsdel
        '
        Me.tsdel.AutoSize = False
        Me.tsdel.Image = CType(resources.GetObject("tsdel.Image"), System.Drawing.Image)
        Me.tsdel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdel.Name = "tsdel"
        Me.tsdel.Size = New System.Drawing.Size(49, 33)
        Me.tsdel.Text = "&Hapus"
        Me.tsdel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsdel.ToolTipText = "Hapus data"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 36)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(36, 33)
        Me.ToolStripLabel1.Text = "Cari  :"
        '
        'cbfind
        '
        Me.cbfind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbfind.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbfind.Items.AddRange(New Object() {"KODE", "NAMA", "ALAMAT"})
        Me.cbfind.Name = "cbfind"
        Me.cbfind.Size = New System.Drawing.Size(125, 36)
        Me.cbfind.ToolTipText = "Kriteria pencarian"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 33)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "-"
        '
        'tsfind
        '
        Me.tsfind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsfind.Name = "tsfind"
        Me.tsfind.Size = New System.Drawing.Size(116, 36)
        Me.tsfind.ToolTipText = "Data yang akan dicari"
        '
        'btfind
        '
        Me.btfind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btfind.Image = CType(resources.GetObject("btfind.Image"), System.Drawing.Image)
        Me.btfind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btfind.Name = "btfind"
        Me.btfind.Size = New System.Drawing.Size(23, 33)
        Me.btfind.Text = "&Cari"
        Me.btfind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btfind.ToolTipText = "Proses pencarian"
        '
        'grid1
        '
        Me.grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.grid1.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.grid1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grid1.Location = New System.Drawing.Point(0, 36)
        Me.grid1.MainView = Me.gridview
        Me.grid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grid1.Name = "grid1"
        Me.grid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.grid1.Size = New System.Drawing.Size(912, 431)
        Me.grid1.TabIndex = 129
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridview})
        '
        'gridview
        '
        Me.gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.AKTIF, Me.KD_TOKO, Me.NAMA, Me.ALAMAT, Me.TTL_DEPOSIT, Me.TTL_GIRO, Me.TTL_HUTANG})
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
        '
        'AKTIF
        '
        Me.AKTIF.Caption = "Aktif"
        Me.AKTIF.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.AKTIF.FieldName = "AKTIF"
        Me.AKTIF.Name = "AKTIF"
        Me.AKTIF.OptionsColumn.AllowEdit = False
        Me.AKTIF.OptionsColumn.FixedWidth = True
        Me.AKTIF.Visible = True
        Me.AKTIF.VisibleIndex = 0
        Me.AKTIF.Width = 36
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
        'KD_TOKO
        '
        Me.KD_TOKO.Caption = "Kode"
        Me.KD_TOKO.FieldName = "KD_TOKO"
        Me.KD_TOKO.Name = "KD_TOKO"
        Me.KD_TOKO.OptionsColumn.AllowEdit = False
        Me.KD_TOKO.Visible = True
        Me.KD_TOKO.VisibleIndex = 1
        Me.KD_TOKO.Width = 81
        '
        'NAMA
        '
        Me.NAMA.Caption = "Nama"
        Me.NAMA.FieldName = "NAMA_TOKO"
        Me.NAMA.Name = "NAMA"
        Me.NAMA.OptionsColumn.AllowEdit = False
        Me.NAMA.Visible = True
        Me.NAMA.VisibleIndex = 2
        Me.NAMA.Width = 236
        '
        'ALAMAT
        '
        Me.ALAMAT.Caption = "Alamat"
        Me.ALAMAT.FieldName = "ALAMAT"
        Me.ALAMAT.Name = "ALAMAT"
        Me.ALAMAT.OptionsColumn.AllowEdit = False
        Me.ALAMAT.Visible = True
        Me.ALAMAT.VisibleIndex = 3
        Me.ALAMAT.Width = 213
        '
        'TTL_DEPOSIT
        '
        Me.TTL_DEPOSIT.AppearanceHeader.Options.UseTextOptions = True
        Me.TTL_DEPOSIT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TTL_DEPOSIT.Caption = "Total Deposit"
        Me.TTL_DEPOSIT.DisplayFormat.FormatString = "c"
        Me.TTL_DEPOSIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TTL_DEPOSIT.FieldName = "TTL_DEPOSIT"
        Me.TTL_DEPOSIT.Name = "TTL_DEPOSIT"
        Me.TTL_DEPOSIT.OptionsColumn.AllowEdit = False
        Me.TTL_DEPOSIT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TTL_DEPOSIT", "{0:c}")})
        Me.TTL_DEPOSIT.Visible = True
        Me.TTL_DEPOSIT.VisibleIndex = 4
        Me.TTL_DEPOSIT.Width = 102
        '
        'TTL_GIRO
        '
        Me.TTL_GIRO.AppearanceHeader.Options.UseTextOptions = True
        Me.TTL_GIRO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TTL_GIRO.Caption = "Total Giro"
        Me.TTL_GIRO.DisplayFormat.FormatString = "c"
        Me.TTL_GIRO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TTL_GIRO.FieldName = "TTL_GIRO"
        Me.TTL_GIRO.Name = "TTL_GIRO"
        Me.TTL_GIRO.OptionsColumn.AllowEdit = False
        Me.TTL_GIRO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TTL_GIRO", "{0:c}")})
        Me.TTL_GIRO.Visible = True
        Me.TTL_GIRO.VisibleIndex = 5
        Me.TTL_GIRO.Width = 103
        '
        'TTL_HUTANG
        '
        Me.TTL_HUTANG.AppearanceHeader.Options.UseTextOptions = True
        Me.TTL_HUTANG.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TTL_HUTANG.Caption = "Total Hutang"
        Me.TTL_HUTANG.DisplayFormat.FormatString = "c"
        Me.TTL_HUTANG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TTL_HUTANG.FieldName = "TTL_HUTANG"
        Me.TTL_HUTANG.Name = "TTL_HUTANG"
        Me.TTL_HUTANG.OptionsColumn.AllowEdit = False
        Me.TTL_HUTANG.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TTL_HUTANG", "{0:c}")})
        Me.TTL_HUTANG.Visible = True
        Me.TTL_HUTANG.VisibleIndex = 6
        Me.TTL_HUTANG.Width = 123
        '
        'ms_toko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 467)
        Me.Controls.Add(Me.grid1)
        Me.Controls.Add(Me.bn1)
        Me.Name = "ms_toko"
        Me.Text = "Data Toko :::"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.bn1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bn1.ResumeLayout(False)
        Me.bn1.PerformLayout()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bn1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsadd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsedit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsdel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cbfind As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsfind As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btfind As System.Windows.Forms.ToolStripButton
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents AKTIF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents KD_TOKO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NAMA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ALAMAT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TTL_DEPOSIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TTL_GIRO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TTL_HUTANG As DevExpress.XtraGrid.Columns.GridColumn
End Class
