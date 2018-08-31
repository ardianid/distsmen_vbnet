<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sr_real
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
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NO_BUKTI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SUPIR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NOPOL2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NAMA_TOKO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TOT_JML = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.cbkriteria = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tcari = New DevExpress.XtraEditors.TextEdit()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.cbkriteria.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcari.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TANGGAL.Width = 93
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NO_BUKTI, Me.TANGGAL, Me.SUPIR, Me.NOPOL2, Me.NAMA_TOKO, Me.TOT_JML})
        Me.GridView1.GridControl = Me.grid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'NO_BUKTI
        '
        Me.NO_BUKTI.Caption = "No Transaksi"
        Me.NO_BUKTI.FieldName = "NODO"
        Me.NO_BUKTI.Name = "NO_BUKTI"
        Me.NO_BUKTI.OptionsColumn.AllowEdit = False
        Me.NO_BUKTI.Visible = True
        Me.NO_BUKTI.VisibleIndex = 0
        Me.NO_BUKTI.Width = 91
        '
        'SUPIR
        '
        Me.SUPIR.Caption = "Supir"
        Me.SUPIR.FieldName = "SUPIR"
        Me.SUPIR.Name = "SUPIR"
        Me.SUPIR.OptionsColumn.AllowEdit = False
        Me.SUPIR.Visible = True
        Me.SUPIR.VisibleIndex = 2
        Me.SUPIR.Width = 84
        '
        'NOPOL2
        '
        Me.NOPOL2.Caption = "No Polisi"
        Me.NOPOL2.FieldName = "NOPOL"
        Me.NOPOL2.Name = "NOPOL2"
        Me.NOPOL2.OptionsColumn.AllowEdit = False
        Me.NOPOL2.Visible = True
        Me.NOPOL2.VisibleIndex = 3
        Me.NOPOL2.Width = 94
        '
        'NAMA_TOKO
        '
        Me.NAMA_TOKO.Caption = "Toko"
        Me.NAMA_TOKO.FieldName = "NAMA_TOKO"
        Me.NAMA_TOKO.Name = "NAMA_TOKO"
        Me.NAMA_TOKO.OptionsColumn.AllowEdit = False
        Me.NAMA_TOKO.Visible = True
        Me.NAMA_TOKO.VisibleIndex = 4
        Me.NAMA_TOKO.Width = 245
        '
        'TOT_JML
        '
        Me.TOT_JML.AppearanceHeader.Options.UseTextOptions = True
        Me.TOT_JML.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TOT_JML.Caption = "Jml"
        Me.TOT_JML.DisplayFormat.FormatString = "n0"
        Me.TOT_JML.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TOT_JML.FieldName = "TOT_JML"
        Me.TOT_JML.Name = "TOT_JML"
        Me.TOT_JML.OptionsColumn.AllowEdit = False
        Me.TOT_JML.Visible = True
        Me.TOT_JML.VisibleIndex = 5
        Me.TOT_JML.Width = 89
        '
        'grid1
        '
        Me.grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid1.Location = New System.Drawing.Point(0, 0)
        Me.grid1.MainView = Me.GridView1
        Me.grid1.Name = "grid1"
        Me.grid1.Size = New System.Drawing.Size(714, 351)
        Me.grid1.TabIndex = 0
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Location = New System.Drawing.Point(633, 3)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(78, 22)
        Me.SimpleButton2.TabIndex = 1
        Me.SimpleButton2.Text = "&Selesai"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Location = New System.Drawing.Point(549, 3)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(78, 22)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "&OK"
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
        Me.SplitContainerControl1.Size = New System.Drawing.Size(718, 52)
        Me.SplitContainerControl1.SplitterPosition = 123
        Me.SplitContainerControl1.TabIndex = 4
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
        Me.cbkriteria.Properties.Items.AddRange(New Object() {"NO TRANSAKSI", "TOKO", "SUPIR", "NO POLISI"})
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
        Me.tcari.Size = New System.Drawing.Size(570, 22)
        Me.tcari.TabIndex = 0
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
        Me.SplitContainerControl2.Size = New System.Drawing.Size(718, 390)
        Me.SplitContainerControl2.SplitterPosition = 30
        Me.SplitContainerControl2.TabIndex = 5
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'sr_real
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 442)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainerControl2)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "sr_real"
        Me.Text = "Cari Realisasi Order ..."
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.cbkriteria.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcari.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TANGGAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NO_BUKTI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SUPIR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NOPOL2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NAMA_TOKO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOT_JML As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents cbkriteria As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents tcari As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
End Class
