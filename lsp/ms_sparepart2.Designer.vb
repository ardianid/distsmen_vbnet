<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ms_sparepart2
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tsatuan = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tkode = New DevExpress.XtraEditors.TextEdit()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.thutang = New DevExpress.XtraEditors.TextEdit()
        Me.thargajual1 = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.tsatuan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.thutang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.thargajual1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.Appearance.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Right
        Me.GroupControl1.Controls.Add(Me.thargajual1)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.tsatuan)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.btkeluar)
        Me.GroupControl1.Controls.Add(Me.btsimpan)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.tkode)
        Me.GroupControl1.Controls.Add(Me.tnama)
        Me.GroupControl1.Controls.Add(Me.thutang)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.ShowCaption = False
        Me.GroupControl1.Size = New System.Drawing.Size(353, 231)
        Me.GroupControl1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 16)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Satuan :"
        '
        'tsatuan
        '
        Me.tsatuan.Location = New System.Drawing.Point(116, 86)
        Me.tsatuan.Name = "tsatuan"
        Me.tsatuan.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsatuan.Properties.Appearance.Options.UseFont = True
        Me.tsatuan.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tsatuan.Size = New System.Drawing.Size(88, 22)
        Me.tsatuan.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Kode :"
        '
        'btkeluar
        '
        Me.btkeluar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btkeluar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btkeluar.Appearance.Options.UseFont = True
        Me.btkeluar.Location = New System.Drawing.Point(273, 199)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(75, 27)
        Me.btkeluar.TabIndex = 5
        Me.btkeluar.Text = "Se&lesai"
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(192, 199)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 27)
        Me.btsimpan.TabIndex = 4
        Me.btsimpan.Text = "&Simpan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Jml Sparepart :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama :"
        '
        'tkode
        '
        Me.tkode.Location = New System.Drawing.Point(116, 30)
        Me.tkode.Name = "tkode"
        Me.tkode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tkode.Properties.Appearance.Options.UseFont = True
        Me.tkode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkode.Size = New System.Drawing.Size(88, 22)
        Me.tkode.TabIndex = 0
        '
        'tnama
        '
        Me.tnama.Location = New System.Drawing.Point(116, 58)
        Me.tnama.Name = "tnama"
        Me.tnama.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnama.Properties.Appearance.Options.UseFont = True
        Me.tnama.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnama.Size = New System.Drawing.Size(218, 22)
        Me.tnama.TabIndex = 1
        '
        'thutang
        '
        Me.thutang.Enabled = False
        Me.thutang.Location = New System.Drawing.Point(116, 142)
        Me.thutang.Name = "thutang"
        Me.thutang.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.thutang.Properties.Appearance.Options.UseFont = True
        Me.thutang.Properties.Appearance.Options.UseTextOptions = True
        Me.thutang.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.thutang.Properties.DisplayFormat.FormatString = "n"
        Me.thutang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.thutang.Properties.EditFormat.FormatString = "n"
        Me.thutang.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.thutang.Properties.Mask.EditMask = "n"
        Me.thutang.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.thutang.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.thutang.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.thutang.Size = New System.Drawing.Size(140, 22)
        Me.thutang.TabIndex = 17
        '
        'thargajual1
        '
        Me.thargajual1.Location = New System.Drawing.Point(116, 114)
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
        Me.thargajual1.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 16)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Harga :"
        '
        'ms_sparepart2
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 250)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ms_sparepart2"
        Me.Text = "Stok Persediaan Detail"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.tsatuan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.thutang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.thargajual1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tsatuan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tkode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents thutang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents thargajual1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
