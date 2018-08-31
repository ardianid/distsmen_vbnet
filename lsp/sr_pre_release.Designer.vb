<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sr_pre_release
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
        Me.TANGGAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.cbkriteria = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tcari = New DevExpress.XtraEditors.TextEdit()
        Me.PRINCIPAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NO_BUKTI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.REGORDER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NOPOL2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TOT_JML = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.cbkriteria.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcari.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TANGGAL
        '
        Me.TANGGAL.Caption = "Tanggal"
        Me.TANGGAL.FieldName = "TANGGAL"
        Me.TANGGAL.Name = "TANGGAL"
        Me.TANGGAL.OptionsColumn.AllowEdit = False
        Me.TANGGAL.Visible = True
        Me.TANGGAL.VisibleIndex = 1
        Me.TANGGAL.Width = 94
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cbkriteria)
        Me.SplitContainerControl1.Panel1.ShowCaption = True
        Me.SplitContainerControl1.Panel1.Text = "Kriteria"
        Me.SplitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.tcari)
        Me.SplitContainerControl1.Panel2.ShowCaption = True
        Me.SplitContainerControl1.Panel2.Text = "Pencarian"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(729, 52)
        Me.SplitContainerControl1.SplitterPosition = 123
        Me.SplitContainerControl1.TabIndex = 2
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'cbkriteria
        '
        Me.cbkriteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbkriteria.Location = New System.Drawing.Point(1, 4)
        Me.cbkriteria.Name = "cbkriteria"
        Me.cbkriteria.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbkriteria.Properties.Appearance.Options.UseFont = True
        Me.cbkriteria.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbkriteria.Properties.Items.AddRange(New Object() {"NO DO", "PRINCIPAL", "REQ ORDER", "NO POLISI"})
        Me.cbkriteria.Size = New System.Drawing.Size(114, 22)
        Me.cbkriteria.TabIndex = 0
        '
        'tcari
        '
        Me.tcari.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcari.Location = New System.Drawing.Point(4, 4)
        Me.tcari.Name = "tcari"
        Me.tcari.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcari.Properties.Appearance.Options.UseFont = True
        Me.tcari.Size = New System.Drawing.Size(582, 22)
        Me.tcari.TabIndex = 0
        '
        'PRINCIPAL
        '
        Me.PRINCIPAL.Caption = "Principal"
        Me.PRINCIPAL.FieldName = "NAMA"
        Me.PRINCIPAL.Name = "PRINCIPAL"
        Me.PRINCIPAL.OptionsColumn.AllowEdit = False
        Me.PRINCIPAL.Visible = True
        Me.PRINCIPAL.VisibleIndex = 2
        Me.PRINCIPAL.Width = 156
        '
        'NO_BUKTI
        '
        Me.NO_BUKTI.Caption = "No DO"
        Me.NO_BUKTI.FieldName = "NO_BUKTI"
        Me.NO_BUKTI.Name = "NO_BUKTI"
        Me.NO_BUKTI.OptionsColumn.AllowEdit = False
        Me.NO_BUKTI.Visible = True
        Me.NO_BUKTI.VisibleIndex = 0
        Me.NO_BUKTI.Width = 93
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Location = New System.Drawing.Point(644, 3)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(78, 22)
        Me.SimpleButton2.TabIndex = 1
        Me.SimpleButton2.Text = "&Selesai"
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NO_BUKTI, Me.TANGGAL, Me.PRINCIPAL, Me.REGORDER, Me.NOPOL2, Me.TOT_JML})
        Me.GridView1.GridControl = Me.grid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'REGORDER
        '
        Me.REGORDER.Caption = "Req Order"
        Me.REGORDER.FieldName = "NAMA_TOKO"
        Me.REGORDER.Name = "REGORDER"
        Me.REGORDER.OptionsColumn.AllowEdit = False
        Me.REGORDER.Visible = True
        Me.REGORDER.VisibleIndex = 3
        Me.REGORDER.Width = 146
        '
        'NOPOL2
        '
        Me.NOPOL2.Caption = "No Polisi"
        Me.NOPOL2.FieldName = "NOPOL"
        Me.NOPOL2.Name = "NOPOL2"
        Me.NOPOL2.OptionsColumn.AllowEdit = False
        Me.NOPOL2.Visible = True
        Me.NOPOL2.VisibleIndex = 4
        Me.NOPOL2.Width = 102
        '
        'TOT_JML
        '
        Me.TOT_JML.AppearanceHeader.Options.UseTextOptions = True
        Me.TOT_JML.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TOT_JML.Caption = "Jml Req"
        Me.TOT_JML.DisplayFormat.FormatString = "n0"
        Me.TOT_JML.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TOT_JML.FieldName = "TOT_JML"
        Me.TOT_JML.Name = "TOT_JML"
        Me.TOT_JML.OptionsColumn.AllowEdit = False
        Me.TOT_JML.Visible = True
        Me.TOT_JML.VisibleIndex = 5
        Me.TOT_JML.Width = 116
        '
        'grid1
        '
        Me.grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid1.Location = New System.Drawing.Point(0, 0)
        Me.grid1.MainView = Me.GridView1
        Me.grid1.Name = "grid1"
        Me.grid1.Size = New System.Drawing.Size(725, 339)
        Me.grid1.TabIndex = 0
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Location = New System.Drawing.Point(560, 3)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(78, 22)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "&OK"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 52)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.grid1)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.SimpleButton2)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.SimpleButton1)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(729, 378)
        Me.SplitContainerControl2.SplitterPosition = 30
        Me.SplitContainerControl2.TabIndex = 3
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'sr_pre_release
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 430)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainerControl2)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "sr_pre_release"
        Me.Text = "Cari Pre Release ...."
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.cbkriteria.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcari.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TANGGAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents cbkriteria As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents tcari As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PRINCIPAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NO_BUKTI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents NOPOL2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOT_JML As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents REGORDER As DevExpress.XtraGrid.Columns.GridColumn
End Class
