﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sr_pre_ujlan
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
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NO_BUKTI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NO_TRANS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TGL_TRANS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CUST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SUPIR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.cbkriteria = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tcari = New DevExpress.XtraEditors.TextEdit()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.cbkriteria.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcari.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grid1
        '
        Me.grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid1.Location = New System.Drawing.Point(0, 0)
        Me.grid1.MainView = Me.GridView1
        Me.grid1.Name = "grid1"
        Me.grid1.Size = New System.Drawing.Size(709, 332)
        Me.grid1.TabIndex = 0
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NO_BUKTI, Me.NO_TRANS, Me.TGL_TRANS, Me.CUST, Me.SUPIR, Me.GridColumn1})
        Me.GridView1.GridControl = Me.grid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.AllowCellMerge = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'NO_BUKTI
        '
        Me.NO_BUKTI.Caption = "No DO"
        Me.NO_BUKTI.FieldName = "NO_BUKTI"
        Me.NO_BUKTI.Name = "NO_BUKTI"
        Me.NO_BUKTI.OptionsColumn.AllowEdit = False
        Me.NO_BUKTI.Visible = True
        Me.NO_BUKTI.VisibleIndex = 0
        Me.NO_BUKTI.Width = 116
        '
        'NO_TRANS
        '
        Me.NO_TRANS.Caption = "No Transaksi"
        Me.NO_TRANS.FieldName = "NODO"
        Me.NO_TRANS.Name = "NO_TRANS"
        Me.NO_TRANS.OptionsColumn.AllowEdit = False
        Me.NO_TRANS.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.NO_TRANS.Visible = True
        Me.NO_TRANS.VisibleIndex = 1
        Me.NO_TRANS.Width = 131
        '
        'TGL_TRANS
        '
        Me.TGL_TRANS.Caption = "Tgl Realisasi"
        Me.TGL_TRANS.FieldName = "TANGGAL"
        Me.TGL_TRANS.Name = "TGL_TRANS"
        Me.TGL_TRANS.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.TGL_TRANS.Visible = True
        Me.TGL_TRANS.VisibleIndex = 2
        Me.TGL_TRANS.Width = 126
        '
        'CUST
        '
        Me.CUST.Caption = "Toko"
        Me.CUST.FieldName = "NAMA_TOKO"
        Me.CUST.Name = "CUST"
        Me.CUST.OptionsColumn.AllowEdit = False
        Me.CUST.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.CUST.Visible = True
        Me.CUST.VisibleIndex = 3
        Me.CUST.Width = 113
        '
        'SUPIR
        '
        Me.SUPIR.Caption = "Supir"
        Me.SUPIR.FieldName = "NAMA_SUPIR"
        Me.SUPIR.Name = "SUPIR"
        Me.SUPIR.OptionsColumn.AllowEdit = False
        Me.SUPIR.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.SUPIR.Visible = True
        Me.SUPIR.VisibleIndex = 4
        Me.SUPIR.Width = 147
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.Caption = "Jml Kirim"
        Me.GridColumn1.FieldName = "TOT_JML"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 5
        Me.GridColumn1.Width = 58
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Location = New System.Drawing.Point(628, 2)
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
        Me.SimpleButton1.Location = New System.Drawing.Point(544, 2)
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
        Me.SplitContainerControl1.Size = New System.Drawing.Size(713, 52)
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
        Me.cbkriteria.Properties.Items.AddRange(New Object() {"NO DO", "NO TRANSAKSI", "TOKO", "SUPIR"})
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
        Me.tcari.Size = New System.Drawing.Size(566, 22)
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
        Me.SplitContainerControl2.Size = New System.Drawing.Size(713, 372)
        Me.SplitContainerControl2.SplitterPosition = 30
        Me.SplitContainerControl2.TabIndex = 5
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'sr_pre_ujlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainerControl2)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "sr_pre_ujlan"
        Me.Text = "Cari Prea Release + Realisasi"
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.cbkriteria.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcari.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NO_BUKTI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NO_TRANS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TGL_TRANS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CUST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SUPIR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents cbkriteria As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents tcari As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
End Class
