<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tr_kas_in2
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
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.ttgl = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbjeniskas = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbukti = New DevExpress.XtraEditors.TextEdit()
        Me.tdeposit = New DevExpress.XtraEditors.TextEdit()
        Me.tket = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbjeniskas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbukti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdeposit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.btkeluar)
        Me.GroupControl1.Controls.Add(Me.btsimpan)
        Me.GroupControl1.Controls.Add(Me.ttgl)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.cbjeniskas)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.tbukti)
        Me.GroupControl1.Controls.Add(Me.tdeposit)
        Me.GroupControl1.Controls.Add(Me.tket)
        Me.GroupControl1.Location = New System.Drawing.Point(8, 8)
        Me.GroupControl1.LookAndFeel.SkinName = "VS2010"
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(401, 260)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Kas Masuk..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Keterangan :"
        '
        'btkeluar
        '
        Me.btkeluar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btkeluar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btkeluar.Appearance.Options.UseFont = True
        Me.btkeluar.Location = New System.Drawing.Point(304, 228)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(75, 27)
        Me.btkeluar.TabIndex = 6
        Me.btkeluar.Text = "Se&lesai"
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(223, 228)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 27)
        Me.btsimpan.TabIndex = 5
        Me.btsimpan.Text = "&Simpan"
        '
        'ttgl
        '
        Me.ttgl.EditValue = Nothing
        Me.ttgl.Location = New System.Drawing.Point(127, 59)
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
        Me.Label2.Location = New System.Drawing.Point(26, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Tanggal :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "No Bukti :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Jenis Kas :"
        '
        'cbjeniskas
        '
        Me.cbjeniskas.Location = New System.Drawing.Point(127, 87)
        Me.cbjeniskas.Name = "cbjeniskas"
        Me.cbjeniskas.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbjeniskas.Properties.Appearance.Options.UseFont = True
        Me.cbjeniskas.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbjeniskas.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("KODE", "Kode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAMA", "Nama"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATUS", "Status")})
        Me.cbjeniskas.Properties.DisplayMember = "NAMA"
        Me.cbjeniskas.Properties.NullText = ""
        Me.cbjeniskas.Properties.ValueMember = "KODE"
        Me.cbjeniskas.Size = New System.Drawing.Size(252, 22)
        Me.cbjeniskas.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Jml :"
        '
        'tbukti
        '
        Me.tbukti.Location = New System.Drawing.Point(127, 31)
        Me.tbukti.Name = "tbukti"
        Me.tbukti.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbukti.Properties.Appearance.Options.UseFont = True
        Me.tbukti.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbukti.Properties.ReadOnly = True
        Me.tbukti.Size = New System.Drawing.Size(129, 22)
        Me.tbukti.TabIndex = 0
        '
        'tdeposit
        '
        Me.tdeposit.Location = New System.Drawing.Point(127, 115)
        Me.tdeposit.Name = "tdeposit"
        Me.tdeposit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdeposit.Properties.Appearance.Options.UseFont = True
        Me.tdeposit.Properties.Appearance.Options.UseTextOptions = True
        Me.tdeposit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.tdeposit.Properties.DisplayFormat.FormatString = "n"
        Me.tdeposit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tdeposit.Properties.EditFormat.FormatString = "n"
        Me.tdeposit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tdeposit.Properties.Mask.EditMask = "n"
        Me.tdeposit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tdeposit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tdeposit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tdeposit.Size = New System.Drawing.Size(129, 22)
        Me.tdeposit.TabIndex = 3
        '
        'tket
        '
        Me.tket.Location = New System.Drawing.Point(127, 143)
        Me.tket.Name = "tket"
        Me.tket.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tket.Properties.Appearance.Options.UseFont = True
        Me.tket.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tket.Size = New System.Drawing.Size(252, 62)
        Me.tket.TabIndex = 4
        '
        'tr_kas_in2
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 275)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "tr_kas_in2"
        Me.Text = "Kas Masuk Detail"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbjeniskas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbukti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdeposit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ttgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbjeniskas As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbukti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tdeposit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tket As DevExpress.XtraEditors.MemoEdit
End Class
