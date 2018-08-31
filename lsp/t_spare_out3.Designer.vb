<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class t_spare_out3
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
        Me.cbspare = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tsatuan = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tjml = New DevExpress.XtraEditors.TextEdit()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.ttot_harga = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.thargajual1 = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.cbspare.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tsatuan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tjml.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.ttot_harga.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.thargajual1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbspare
        '
        Me.cbspare.Location = New System.Drawing.Point(115, 16)
        Me.cbspare.Name = "cbspare"
        Me.cbspare.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbspare.Properties.Appearance.Options.UseFont = True
        Me.cbspare.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbspare.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("KODE", "KODE", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAMA", "Nama SparePart"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("SATUAN", "Satuan"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HARGA", "HARGA", 20, DevExpress.Utils.FormatType.Numeric, "n0", True, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cbspare.Properties.DisplayMember = "NAMA"
        Me.cbspare.Properties.NullText = ""
        Me.cbspare.Properties.ValueMember = "KODE"
        Me.cbspare.Size = New System.Drawing.Size(181, 22)
        Me.cbspare.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "SparePart :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Satuan :"
        '
        'tsatuan
        '
        Me.tsatuan.Enabled = False
        Me.tsatuan.Location = New System.Drawing.Point(115, 44)
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
        Me.Label7.Location = New System.Drawing.Point(17, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 16)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Jml :"
        '
        'tjml
        '
        Me.tjml.Location = New System.Drawing.Point(115, 72)
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
        'btkeluar
        '
        Me.btkeluar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btkeluar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btkeluar.Appearance.Options.UseFont = True
        Me.btkeluar.Location = New System.Drawing.Point(258, 6)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(60, 27)
        Me.btkeluar.TabIndex = 1
        Me.btkeluar.Text = "Se&lesai"
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(192, 6)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(60, 27)
        Me.btsimpan.TabIndex = 0
        Me.btsimpan.Text = "&Tambah"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ttot_harga)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.thargajual1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cbspare)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tsatuan)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tjml)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btsimpan)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btkeluar)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(321, 204)
        Me.SplitContainerControl1.SplitterPosition = 162
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'ttot_harga
        '
        Me.ttot_harga.Location = New System.Drawing.Point(115, 128)
        Me.ttot_harga.Name = "ttot_harga"
        Me.ttot_harga.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttot_harga.Properties.Appearance.Options.UseFont = True
        Me.ttot_harga.Properties.Appearance.Options.UseTextOptions = True
        Me.ttot_harga.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ttot_harga.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ttot_harga.Properties.Mask.EditMask = "n"
        Me.ttot_harga.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ttot_harga.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.ttot_harga.Properties.ReadOnly = True
        Me.ttot_harga.Size = New System.Drawing.Size(140, 22)
        Me.ttot_harga.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Tot Harga :"
        '
        'thargajual1
        '
        Me.thargajual1.Location = New System.Drawing.Point(115, 100)
        Me.thargajual1.Name = "thargajual1"
        Me.thargajual1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.thargajual1.Properties.Appearance.Options.UseFont = True
        Me.thargajual1.Properties.Appearance.Options.UseTextOptions = True
        Me.thargajual1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.thargajual1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.thargajual1.Properties.DisplayFormat.FormatString = "n"
        Me.thargajual1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.thargajual1.Properties.EditFormat.FormatString = "n"
        Me.thargajual1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.thargajual1.Properties.Mask.EditMask = "n"
        Me.thargajual1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.thargajual1.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.thargajual1.Size = New System.Drawing.Size(140, 22)
        Me.thargajual1.TabIndex = 57
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 16)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Harga :"
        '
        't_spare_out3
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 204)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "t_spare_out3"
        Me.Text = "Sparepart Detail"
        CType(Me.cbspare.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tsatuan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tjml.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.ttot_harga.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.thargajual1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbspare As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tsatuan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tjml As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents ttot_harga As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents thargajual1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
