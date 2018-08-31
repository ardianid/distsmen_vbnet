<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fkalk_gaji2
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
        Me.tsupir = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tsemen = New DevExpress.XtraEditors.TextEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tlain = New DevExpress.XtraEditors.TextEdit()
        Me.tpot = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ttot = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tket = New DevExpress.XtraEditors.MemoEdit()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.tsupir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tsemen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tlain.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tpot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsupir
        '
        Me.tsupir.Location = New System.Drawing.Point(150, 17)
        Me.tsupir.Name = "tsupir"
        Me.tsupir.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsupir.Properties.Appearance.Options.UseFont = True
        Me.tsupir.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tsupir.Properties.ReadOnly = True
        Me.tsupir.Size = New System.Drawing.Size(339, 22)
        Me.tsupir.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Supir :"
        '
        'tsemen
        '
        Me.tsemen.Location = New System.Drawing.Point(150, 45)
        Me.tsemen.Name = "tsemen"
        Me.tsemen.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsemen.Properties.Appearance.Options.UseFont = True
        Me.tsemen.Properties.Appearance.Options.UseTextOptions = True
        Me.tsemen.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.tsemen.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tsemen.Properties.Mask.EditMask = "n2"
        Me.tsemen.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tsemen.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tsemen.Properties.ReadOnly = True
        Me.tsemen.Size = New System.Drawing.Size(140, 22)
        Me.tsemen.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 16)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "Gaji Angk Semen :"
        '
        'tlain
        '
        Me.tlain.Location = New System.Drawing.Point(150, 73)
        Me.tlain.Name = "tlain"
        Me.tlain.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tlain.Properties.Appearance.Options.UseFont = True
        Me.tlain.Properties.Appearance.Options.UseTextOptions = True
        Me.tlain.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.tlain.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tlain.Properties.Mask.EditMask = "n3"
        Me.tlain.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tlain.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tlain.Properties.ReadOnly = True
        Me.tlain.Size = New System.Drawing.Size(140, 22)
        Me.tlain.TabIndex = 35
        '
        'tpot
        '
        Me.tpot.Location = New System.Drawing.Point(150, 129)
        Me.tpot.Name = "tpot"
        Me.tpot.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpot.Properties.Appearance.Options.UseFont = True
        Me.tpot.Properties.Appearance.Options.UseTextOptions = True
        Me.tpot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.tpot.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tpot.Properties.Mask.EditMask = "n"
        Me.tpot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tpot.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tpot.Size = New System.Drawing.Size(140, 22)
        Me.tpot.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 16)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Potongan Kasbon :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 16)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Gaji Angk Lain :"
        '
        'ttot
        '
        Me.ttot.Location = New System.Drawing.Point(150, 101)
        Me.ttot.Name = "ttot"
        Me.ttot.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttot.Properties.Appearance.Options.UseFont = True
        Me.ttot.Properties.Appearance.Options.UseTextOptions = True
        Me.ttot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ttot.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ttot.Properties.Mask.EditMask = "n3"
        Me.ttot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ttot.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.ttot.Properties.ReadOnly = True
        Me.ttot.Size = New System.Drawing.Size(140, 22)
        Me.ttot.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Total :"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tsupir)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ttot)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tsemen)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tpot)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tlain)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tket)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btkeluar)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btsimpan)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(527, 267)
        Me.SplitContainerControl1.SplitterPosition = 219
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Keterangan :"
        '
        'tket
        '
        Me.tket.Location = New System.Drawing.Point(150, 157)
        Me.tket.Name = "tket"
        Me.tket.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tket.Properties.Appearance.Options.UseFont = True
        Me.tket.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tket.Size = New System.Drawing.Size(339, 47)
        Me.tket.TabIndex = 1
        '
        'btkeluar
        '
        Me.btkeluar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btkeluar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btkeluar.Appearance.Options.UseFont = True
        Me.btkeluar.Location = New System.Drawing.Point(436, 5)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(75, 27)
        Me.btkeluar.TabIndex = 1
        Me.btkeluar.Text = "Se&lesai"
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(355, 5)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 27)
        Me.btsimpan.TabIndex = 0
        Me.btsimpan.Text = "&Simpan"
        '
        'fkalk_gaji2
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 267)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "fkalk_gaji2"
        Me.Text = "Edit Potongan Gaji"
        CType(Me.tsupir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tsemen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tlain.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tpot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tsupir As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tsemen As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tlain As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tpot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ttot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tket As DevExpress.XtraEditors.MemoEdit
End Class
