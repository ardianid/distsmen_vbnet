<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ms_giro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ms_giro))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
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
        Me.TOKO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NOGIRO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TGLTEMPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NAMABANK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.STATUSGIRO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KET = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NILAIGIRO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
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
        Me.bn1.Size = New System.Drawing.Size(866, 36)
        Me.bn1.TabIndex = 125
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
        Me.cbfind.Items.AddRange(New Object() {"NO GIRO", "TGL JATUH TEMPO", "BANK", "STATUS", "TOKO"})
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
        Me.grid1.Location = New System.Drawing.Point(0, 36)
        Me.grid1.MainView = Me.gridview
        Me.grid1.Name = "grid1"
        Me.grid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.grid1.Size = New System.Drawing.Size(866, 402)
        Me.grid1.TabIndex = 126
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridview})
        '
        'gridview
        '
        Me.gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TOKO, Me.NOGIRO, Me.TGLTEMPO, Me.NAMABANK, Me.STATUSGIRO, Me.KET, Me.NILAIGIRO})
        StyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition1.Appearance.Options.UseForeColor = True
        StyleFormatCondition1.ApplyToRow = True
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Value1 = "PUSAT"
        Me.gridview.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1})
        Me.gridview.GridControl = Me.grid1
        Me.gridview.Name = "gridview"
        '
        'TOKO
        '
        Me.TOKO.Caption = "Toko"
        Me.TOKO.FieldName = "NAMA_TOKO"
        Me.TOKO.Name = "TOKO"
        Me.TOKO.OptionsColumn.AllowEdit = False
        Me.TOKO.Visible = True
        Me.TOKO.VisibleIndex = 0
        Me.TOKO.Width = 159
        '
        'NOGIRO
        '
        Me.NOGIRO.Caption = "No Giro"
        Me.NOGIRO.FieldName = "NO_GIRO"
        Me.NOGIRO.Name = "NOGIRO"
        Me.NOGIRO.OptionsColumn.AllowEdit = False
        Me.NOGIRO.Visible = True
        Me.NOGIRO.VisibleIndex = 1
        Me.NOGIRO.Width = 69
        '
        'TGLTEMPO
        '
        Me.TGLTEMPO.Caption = "Jatuh Tempo"
        Me.TGLTEMPO.FieldName = "TGL_TEMPO"
        Me.TGLTEMPO.Name = "TGLTEMPO"
        Me.TGLTEMPO.OptionsColumn.AllowEdit = False
        Me.TGLTEMPO.Visible = True
        Me.TGLTEMPO.VisibleIndex = 2
        Me.TGLTEMPO.Width = 86
        '
        'NAMABANK
        '
        Me.NAMABANK.Caption = "Bank"
        Me.NAMABANK.FieldName = "BANK"
        Me.NAMABANK.Name = "NAMABANK"
        Me.NAMABANK.OptionsColumn.AllowEdit = False
        Me.NAMABANK.Visible = True
        Me.NAMABANK.VisibleIndex = 3
        '
        'STATUSGIRO
        '
        Me.STATUSGIRO.Caption = "Status"
        Me.STATUSGIRO.FieldName = "STATUS"
        Me.STATUSGIRO.Name = "STATUSGIRO"
        Me.STATUSGIRO.OptionsColumn.AllowEdit = False
        Me.STATUSGIRO.Visible = True
        Me.STATUSGIRO.VisibleIndex = 4
        Me.STATUSGIRO.Width = 97
        '
        'KET
        '
        Me.KET.Caption = "Keterangan"
        Me.KET.FieldName = "KETERANGAN"
        Me.KET.Name = "KET"
        Me.KET.OptionsColumn.AllowEdit = False
        Me.KET.Visible = True
        Me.KET.VisibleIndex = 5
        Me.KET.Width = 245
        '
        'NILAIGIRO
        '
        Me.NILAIGIRO.AppearanceHeader.Options.UseTextOptions = True
        Me.NILAIGIRO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.NILAIGIRO.Caption = "Nilai"
        Me.NILAIGIRO.DisplayFormat.FormatString = "n"
        Me.NILAIGIRO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NILAIGIRO.FieldName = "NILAI"
        Me.NILAIGIRO.Name = "NILAIGIRO"
        Me.NILAIGIRO.OptionsColumn.AllowEdit = False
        Me.NILAIGIRO.Visible = True
        Me.NILAIGIRO.VisibleIndex = 6
        Me.NILAIGIRO.Width = 117
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
        'ms_giro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 438)
        Me.Controls.Add(Me.grid1)
        Me.Controls.Add(Me.bn1)
        Me.Name = "ms_giro"
        Me.Text = "Giro Masuk"
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
    Friend WithEvents TOKO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NOGIRO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NAMABANK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents STATUSGIRO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NILAIGIRO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents TGLTEMPO As DevExpress.XtraGrid.Columns.GridColumn
End Class
