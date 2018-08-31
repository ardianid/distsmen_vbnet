<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tr_byartoko2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tr_byartoko2))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.btadd_det = New DevExpress.XtraEditors.SimpleButton()
        Me.btdel_det = New DevExpress.XtraEditors.SimpleButton()
        Me.bted_det = New DevExpress.XtraEditors.SimpleButton()
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NO_REALISASI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.JML = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.JMLDEPOSIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.JMLTUNAI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.JMLGIRO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tkodetok = New DevExpress.XtraEditors.TextEdit()
        Me.tnamatok = New DevExpress.XtraEditors.TextEdit()
        Me.btfind = New DevExpress.XtraEditors.SimpleButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.ttgl = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbukti = New DevExpress.XtraEditors.TextEdit()
        Me.tket = New DevExpress.XtraEditors.MemoEdit()
        Me.talamattok = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkodetok.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnamatok.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbukti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.talamattok.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.GroupControl1.Controls.Add(Me.tkodetok)
        Me.GroupControl1.Controls.Add(Me.tnamatok)
        Me.GroupControl1.Controls.Add(Me.btfind)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.btkeluar)
        Me.GroupControl1.Controls.Add(Me.btsimpan)
        Me.GroupControl1.Controls.Add(Me.ttgl)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.tbukti)
        Me.GroupControl1.Controls.Add(Me.tket)
        Me.GroupControl1.Controls.Add(Me.talamattok)
        Me.GroupControl1.Location = New System.Drawing.Point(5, 6)
        Me.GroupControl1.LookAndFeel.SkinName = "Glass Oceans"
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(682, 464)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Pelunasan Toko ..."
        '
        'btadd_det
        '
        Me.btadd_det.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btadd_det.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btadd_det.Appearance.Options.UseFont = True
        Me.btadd_det.Image = CType(resources.GetObject("btadd_det.Image"), System.Drawing.Image)
        Me.btadd_det.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btadd_det.Location = New System.Drawing.Point(10, 427)
        Me.btadd_det.Name = "btadd_det"
        Me.btadd_det.Size = New System.Drawing.Size(34, 24)
        Me.btadd_det.TabIndex = 5
        Me.btadd_det.ToolTip = "Tambah detail data pelunasan"
        '
        'btdel_det
        '
        Me.btdel_det.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btdel_det.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btdel_det.Appearance.Options.UseFont = True
        Me.btdel_det.Image = CType(resources.GetObject("btdel_det.Image"), System.Drawing.Image)
        Me.btdel_det.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btdel_det.Location = New System.Drawing.Point(126, 427)
        Me.btdel_det.Name = "btdel_det"
        Me.btdel_det.Size = New System.Drawing.Size(34, 24)
        Me.btdel_det.TabIndex = 7
        Me.btdel_det.ToolTip = "Hapus detail pelunasan"
        '
        'bted_det
        '
        Me.bted_det.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bted_det.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bted_det.Appearance.Options.UseFont = True
        Me.bted_det.Image = CType(resources.GetObject("bted_det.Image"), System.Drawing.Image)
        Me.bted_det.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.bted_det.Location = New System.Drawing.Point(46, 427)
        Me.bted_det.Name = "bted_det"
        Me.bted_det.Size = New System.Drawing.Size(77, 24)
        Me.bted_det.TabIndex = 6
        Me.bted_det.Text = "View"
        Me.bted_det.ToolTip = "Edit detail peluanasan"
        '
        'grid1
        '
        Me.grid1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.grid1.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.grid1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grid1.Location = New System.Drawing.Point(7, 220)
        Me.grid1.MainView = Me.gridview
        Me.grid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grid1.Name = "grid1"
        Me.grid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.grid1.Size = New System.Drawing.Size(663, 203)
        Me.grid1.TabIndex = 133
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridview})
        '
        'gridview
        '
        Me.gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NO_REALISASI, Me.JML, Me.JMLDEPOSIT, Me.JMLTUNAI, Me.JMLGIRO})
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
        Me.gridview.ViewCaption = "- PELUNASAN -"
        '
        'NO_REALISASI
        '
        Me.NO_REALISASI.Caption = "No DO"
        Me.NO_REALISASI.FieldName = "NO_REALISASI"
        Me.NO_REALISASI.Name = "NO_REALISASI"
        Me.NO_REALISASI.OptionsColumn.AllowEdit = False
        Me.NO_REALISASI.Visible = True
        Me.NO_REALISASI.VisibleIndex = 0
        Me.NO_REALISASI.Width = 132
        '
        'JML
        '
        Me.JML.AppearanceHeader.Options.UseTextOptions = True
        Me.JML.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.JML.Caption = "Jml Piutang"
        Me.JML.DisplayFormat.FormatString = "n"
        Me.JML.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.JML.FieldName = "JML"
        Me.JML.Name = "JML"
        Me.JML.OptionsColumn.AllowEdit = False
        Me.JML.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "JML", "{0:n}")})
        Me.JML.Visible = True
        Me.JML.VisibleIndex = 1
        Me.JML.Width = 128
        '
        'JMLDEPOSIT
        '
        Me.JMLDEPOSIT.AppearanceHeader.Options.UseTextOptions = True
        Me.JMLDEPOSIT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.JMLDEPOSIT.Caption = "Deposit"
        Me.JMLDEPOSIT.DisplayFormat.FormatString = "n"
        Me.JMLDEPOSIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.JMLDEPOSIT.FieldName = "JML_DEPOSIT"
        Me.JMLDEPOSIT.Name = "JMLDEPOSIT"
        Me.JMLDEPOSIT.OptionsColumn.AllowEdit = False
        Me.JMLDEPOSIT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "JML_DEPOSIT", "{0:n}")})
        Me.JMLDEPOSIT.Visible = True
        Me.JMLDEPOSIT.VisibleIndex = 2
        Me.JMLDEPOSIT.Width = 118
        '
        'JMLTUNAI
        '
        Me.JMLTUNAI.AppearanceHeader.Options.UseTextOptions = True
        Me.JMLTUNAI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.JMLTUNAI.Caption = "Tunai"
        Me.JMLTUNAI.DisplayFormat.FormatString = "n"
        Me.JMLTUNAI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.JMLTUNAI.FieldName = "JML_TUNAI"
        Me.JMLTUNAI.Name = "JMLTUNAI"
        Me.JMLTUNAI.OptionsColumn.AllowEdit = False
        Me.JMLTUNAI.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "JML_TUNAI", "{0:n}")})
        Me.JMLTUNAI.Visible = True
        Me.JMLTUNAI.VisibleIndex = 3
        Me.JMLTUNAI.Width = 133
        '
        'JMLGIRO
        '
        Me.JMLGIRO.AppearanceHeader.Options.UseTextOptions = True
        Me.JMLGIRO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.JMLGIRO.Caption = "Giro"
        Me.JMLGIRO.DisplayFormat.FormatString = "n"
        Me.JMLGIRO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.JMLGIRO.FieldName = "JML_GIRO"
        Me.JMLGIRO.Name = "JMLGIRO"
        Me.JMLGIRO.OptionsColumn.AllowEdit = False
        Me.JMLGIRO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "JML_GIRO", "{0:n}")})
        Me.JMLGIRO.Visible = True
        Me.JMLGIRO.VisibleIndex = 4
        Me.JMLGIRO.Width = 134
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
        'tkodetok
        '
        Me.tkodetok.Location = New System.Drawing.Point(122, 72)
        Me.tkodetok.Name = "tkodetok"
        Me.tkodetok.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tkodetok.Properties.Appearance.Options.UseFont = True
        Me.tkodetok.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkodetok.Size = New System.Drawing.Size(61, 22)
        Me.tkodetok.TabIndex = 2
        '
        'tnamatok
        '
        Me.tnamatok.Location = New System.Drawing.Point(186, 72)
        Me.tnamatok.Name = "tnamatok"
        Me.tnamatok.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnamatok.Properties.Appearance.Options.UseFont = True
        Me.tnamatok.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnamatok.Properties.ReadOnly = True
        Me.tnamatok.Size = New System.Drawing.Size(269, 22)
        Me.tnamatok.TabIndex = 3
        '
        'btfind
        '
        Me.btfind.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btfind.Appearance.Options.UseFont = True
        Me.btfind.Image = CType(resources.GetObject("btfind.Image"), System.Drawing.Image)
        Me.btfind.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btfind.Location = New System.Drawing.Point(461, 71)
        Me.btfind.Name = "btfind"
        Me.btfind.Size = New System.Drawing.Size(23, 23)
        Me.btfind.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 16)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Toko :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Keterangan :"
        '
        'btkeluar
        '
        Me.btkeluar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btkeluar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btkeluar.Appearance.Options.UseFont = True
        Me.btkeluar.Location = New System.Drawing.Point(595, 427)
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
        Me.btsimpan.Location = New System.Drawing.Point(514, 427)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 27)
        Me.btsimpan.TabIndex = 8
        Me.btsimpan.Text = "&Simpan"
        '
        'ttgl
        '
        Me.ttgl.EditValue = Nothing
        Me.ttgl.Location = New System.Drawing.Point(122, 44)
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
        Me.Label2.Location = New System.Drawing.Point(21, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Tanggal :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "No Bukti :"
        '
        'tbukti
        '
        Me.tbukti.Location = New System.Drawing.Point(122, 16)
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
        Me.tket.Location = New System.Drawing.Point(122, 157)
        Me.tket.Name = "tket"
        Me.tket.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tket.Properties.Appearance.Options.UseFont = True
        Me.tket.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tket.Size = New System.Drawing.Size(332, 56)
        Me.tket.TabIndex = 4
        '
        'talamattok
        '
        Me.talamattok.Location = New System.Drawing.Point(122, 100)
        Me.talamattok.Name = "talamattok"
        Me.talamattok.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.talamattok.Properties.Appearance.Options.UseFont = True
        Me.talamattok.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.talamattok.Properties.ReadOnly = True
        Me.talamattok.Size = New System.Drawing.Size(333, 51)
        Me.talamattok.TabIndex = 137
        '
        'tr_byartoko2
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 474)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "tr_byartoko2"
        Me.Text = "Pelunasan Piutang Toko Detail ...."
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkodetok.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnamatok.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbukti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.talamattok.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btadd_det As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btdel_det As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bted_det As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NO_REALISASI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents JML As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents tkodetok As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tnamatok As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btfind As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ttgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbukti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tket As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents talamattok As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents JMLTUNAI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents JMLGIRO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents JMLDEPOSIT As DevExpress.XtraGrid.Columns.GridColumn
End Class
