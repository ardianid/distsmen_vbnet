﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tr_real3
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
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ttot = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tharga = New DevExpress.XtraEditors.TextEdit()
        Me.cbbarang = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tsatuan = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tjml = New DevExpress.XtraEditors.TextEdit()
        Me.tnote1 = New DevExpress.XtraEditors.TextEdit()
        Me.tnote2 = New DevExpress.XtraEditors.TextEdit()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.ttot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tharga.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbbarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tsatuan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tjml.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnote1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnote2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ttot)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tharga)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cbbarang)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tsatuan)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tjml)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tnote1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tnote2)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btsimpan)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btkeluar)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(548, 277)
        Me.SplitContainerControl1.SplitterPosition = 238
        Me.SplitContainerControl1.TabIndex = 1
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 16)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Total :"
        '
        'ttot
        '
        Me.ttot.Enabled = False
        Me.ttot.Location = New System.Drawing.Point(154, 158)
        Me.ttot.Name = "ttot"
        Me.ttot.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttot.Properties.Appearance.Options.UseFont = True
        Me.ttot.Properties.Appearance.Options.UseTextOptions = True
        Me.ttot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ttot.Properties.DisplayFormat.FormatString = "n0"
        Me.ttot.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ttot.Properties.EditFormat.FormatString = "n0"
        Me.ttot.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ttot.Properties.Mask.EditMask = "n0"
        Me.ttot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ttot.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.ttot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ttot.Size = New System.Drawing.Size(140, 22)
        Me.ttot.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 16)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Harga :"
        '
        'tharga
        '
        Me.tharga.Location = New System.Drawing.Point(154, 130)
        Me.tharga.Name = "tharga"
        Me.tharga.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tharga.Properties.Appearance.Options.UseFont = True
        Me.tharga.Properties.Appearance.Options.UseTextOptions = True
        Me.tharga.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.tharga.Properties.DisplayFormat.FormatString = "n"
        Me.tharga.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tharga.Properties.EditFormat.FormatString = "n"
        Me.tharga.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tharga.Properties.Mask.EditMask = "n"
        Me.tharga.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tharga.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tharga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tharga.Size = New System.Drawing.Size(140, 22)
        Me.tharga.TabIndex = 2
        '
        'cbbarang
        '
        Me.cbbarang.Location = New System.Drawing.Point(154, 46)
        Me.cbbarang.Name = "cbbarang"
        Me.cbbarang.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbbarang.Properties.Appearance.Options.UseFont = True
        Me.cbbarang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbbarang.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("KD_BARANG", "Kode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAMA", "Nama Barang"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("SATUAN", "Satuan", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PRINCIPAL", "Principal"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HARGA1", "HARGA1", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HARGA2", "HARGA2", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HARGA3", "HARGA3", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cbbarang.Properties.DisplayMember = "NAMA"
        Me.cbbarang.Properties.NullText = ""
        Me.cbbarang.Properties.ValueMember = "KD_BARANG"
        Me.cbbarang.Size = New System.Drawing.Size(324, 22)
        Me.cbbarang.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(56, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Barang :"
        '
        'tsatuan
        '
        Me.tsatuan.Enabled = False
        Me.tsatuan.Location = New System.Drawing.Point(154, 74)
        Me.tsatuan.Name = "tsatuan"
        Me.tsatuan.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsatuan.Properties.Appearance.Options.UseFont = True
        Me.tsatuan.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tsatuan.Size = New System.Drawing.Size(66, 22)
        Me.tsatuan.TabIndex = 53
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(56, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 16)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Jml :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Satuan :"
        '
        'tjml
        '
        Me.tjml.Location = New System.Drawing.Point(154, 102)
        Me.tjml.Name = "tjml"
        Me.tjml.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tjml.Properties.Appearance.Options.UseFont = True
        Me.tjml.Properties.Appearance.Options.UseTextOptions = True
        Me.tjml.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.tjml.Properties.DisplayFormat.FormatString = "n0"
        Me.tjml.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tjml.Properties.EditFormat.FormatString = "n0"
        Me.tjml.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tjml.Properties.Mask.EditMask = "n0"
        Me.tjml.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tjml.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tjml.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tjml.Size = New System.Drawing.Size(66, 22)
        Me.tjml.TabIndex = 1
        '
        'tnote1
        '
        Me.tnote1.Dock = System.Windows.Forms.DockStyle.Top
        Me.tnote1.EditValue = "( SALES : EKO ) |-| ( POT INCENTIVE : LANGSUNG )"
        Me.tnote1.Location = New System.Drawing.Point(0, 0)
        Me.tnote1.Name = "tnote1"
        Me.tnote1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnote1.Properties.Appearance.Options.UseFont = True
        Me.tnote1.Properties.Appearance.Options.UseTextOptions = True
        Me.tnote1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.tnote1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.tnote1.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.tnote1.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.tnote1.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.tnote1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnote1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.tnote1.Properties.ReadOnly = True
        Me.tnote1.Size = New System.Drawing.Size(544, 20)
        Me.tnote1.TabIndex = 61
        '
        'tnote2
        '
        Me.tnote2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tnote2.EditValue = "NOTE : HARGA JUAL YANG HARUS DIMASUKKAN ADALAH HARGA ( + ) INCENTIVE SALESMAN"
        Me.tnote2.Location = New System.Drawing.Point(0, 214)
        Me.tnote2.Name = "tnote2"
        Me.tnote2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnote2.Properties.Appearance.Options.UseFont = True
        Me.tnote2.Properties.Appearance.Options.UseTextOptions = True
        Me.tnote2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.tnote2.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.tnote2.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.tnote2.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.tnote2.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.tnote2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnote2.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.tnote2.Properties.ReadOnly = True
        Me.tnote2.Size = New System.Drawing.Size(544, 20)
        Me.tnote2.TabIndex = 62
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(419, 3)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(60, 27)
        Me.btsimpan.TabIndex = 0
        Me.btsimpan.Text = "&Tambah"
        '
        'btkeluar
        '
        Me.btkeluar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btkeluar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btkeluar.Appearance.Options.UseFont = True
        Me.btkeluar.Location = New System.Drawing.Point(485, 3)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(60, 27)
        Me.btkeluar.TabIndex = 1
        Me.btkeluar.Text = "Se&lesai"
        '
        'tr_real3
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 277)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "tr_real3"
        Me.Text = "Real order barang detail"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.ttot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tharga.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbbarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tsatuan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tjml.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnote1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnote2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ttot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tharga As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbbarang As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tsatuan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tjml As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tnote1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tnote2 As DevExpress.XtraEditors.TextEdit
End Class
