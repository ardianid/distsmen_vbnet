<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fb_dliver
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fb_dliver))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ROWNU = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NAMA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KET = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.nmform = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.btload = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.grid1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btload)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(915, 343)
        Me.SplitContainerControl1.SplitterPosition = 35
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'grid1
        '
        Me.grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.grid1.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.grid1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grid1.Location = New System.Drawing.Point(0, 0)
        Me.grid1.LookAndFeel.SkinName = "McSkin"
        Me.grid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grid1.MainView = Me.gridview
        Me.grid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grid1.Name = "grid1"
        Me.grid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.grid1.Size = New System.Drawing.Size(915, 303)
        Me.grid1.TabIndex = 137
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridview})
        '
        'gridview
        '
        Me.gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ROWNU, Me.NAMA, Me.KET, Me.nmform})
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
        Me.gridview.ViewCaption = "- AREA TEBUSAN -"
        '
        'ROWNU
        '
        Me.ROWNU.Caption = "No."
        Me.ROWNU.FieldName = "ROWNUM"
        Me.ROWNU.Name = "ROWNU"
        Me.ROWNU.OptionsColumn.AllowEdit = False
        Me.ROWNU.Visible = True
        Me.ROWNU.VisibleIndex = 0
        Me.ROWNU.Width = 30
        '
        'NAMA
        '
        Me.NAMA.Caption = "Nama"
        Me.NAMA.FieldName = "NAMA"
        Me.NAMA.Name = "NAMA"
        Me.NAMA.OptionsColumn.AllowEdit = False
        Me.NAMA.Visible = True
        Me.NAMA.VisibleIndex = 1
        Me.NAMA.Width = 175
        '
        'KET
        '
        Me.KET.Caption = "Keterangan"
        Me.KET.FieldName = "KETERANGAN"
        Me.KET.Name = "KET"
        Me.KET.OptionsColumn.AllowEdit = False
        Me.KET.Visible = True
        Me.KET.VisibleIndex = 2
        Me.KET.Width = 692
        '
        'nmform
        '
        Me.nmform.Caption = "NAMAFORM"
        Me.nmform.FieldName = "NAMAFORM"
        Me.nmform.Name = "nmform"
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
        'btload
        '
        Me.btload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btload.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btload.Appearance.Options.UseFont = True
        Me.btload.Image = CType(resources.GetObject("btload.Image"), System.Drawing.Image)
        Me.btload.Location = New System.Drawing.Point(817, 2)
        Me.btload.LookAndFeel.SkinName = "Seven Classic"
        Me.btload.Name = "btload"
        Me.btload.Size = New System.Drawing.Size(94, 29)
        Me.btload.TabIndex = 9
        Me.btload.Text = "&Load"
        '
        'fb_dliver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 343)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "fb_dliver"
        Me.Text = "View Laporan Delivery Order :::"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NAMA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents nmform As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ROWNU As DevExpress.XtraGrid.Columns.GridColumn
End Class
