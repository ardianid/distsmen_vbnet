<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ms_barang3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ms_barang3))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.tkodekab = New DevExpress.XtraEditors.TextEdit()
        Me.tnamakab = New DevExpress.XtraEditors.TextEdit()
        Me.btfindsal = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tjml = New DevExpress.XtraEditors.TextEdit()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.tkodekab.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnamakab.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tjml.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tkodekab)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tnamakab)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btfindsal)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tjml)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btsimpan)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btkeluar)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(429, 132)
        Me.SplitContainerControl1.SplitterPosition = 89
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'tkodekab
        '
        Me.tkodekab.Location = New System.Drawing.Point(100, 16)
        Me.tkodekab.Name = "tkodekab"
        Me.tkodekab.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tkodekab.Properties.Appearance.Options.UseFont = True
        Me.tkodekab.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkodekab.Size = New System.Drawing.Size(57, 22)
        Me.tkodekab.TabIndex = 1
        '
        'tnamakab
        '
        Me.tnamakab.Location = New System.Drawing.Point(160, 16)
        Me.tnamakab.Name = "tnamakab"
        Me.tnamakab.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnamakab.Properties.Appearance.Options.UseFont = True
        Me.tnamakab.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnamakab.Properties.ReadOnly = True
        Me.tnamakab.Size = New System.Drawing.Size(233, 22)
        Me.tnamakab.TabIndex = 57
        '
        'btfindsal
        '
        Me.btfindsal.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btfindsal.Appearance.Options.UseFont = True
        Me.btfindsal.Image = CType(resources.GetObject("btfindsal.Image"), System.Drawing.Image)
        Me.btfindsal.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btfindsal.Location = New System.Drawing.Point(399, 15)
        Me.btfindsal.Name = "btfindsal"
        Me.btfindsal.Size = New System.Drawing.Size(23, 23)
        Me.btfindsal.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 16)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Kabupaten :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 16)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Harga :"
        '
        'tjml
        '
        Me.tjml.Location = New System.Drawing.Point(100, 44)
        Me.tjml.Name = "tjml"
        Me.tjml.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tjml.Properties.Appearance.Options.UseFont = True
        Me.tjml.Properties.Appearance.Options.UseTextOptions = True
        Me.tjml.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.tjml.Properties.DisplayFormat.FormatString = "n4"
        Me.tjml.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tjml.Properties.EditFormat.FormatString = "n4"
        Me.tjml.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tjml.Properties.Mask.EditMask = "n4"
        Me.tjml.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tjml.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tjml.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tjml.Size = New System.Drawing.Size(168, 22)
        Me.tjml.TabIndex = 3
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(300, 6)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(60, 27)
        Me.btsimpan.TabIndex = 0
        Me.btsimpan.Text = "&Tambah"
        '
        'btkeluar
        '
        Me.btkeluar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btkeluar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btkeluar.Appearance.Options.UseFont = True
        Me.btkeluar.Location = New System.Drawing.Point(366, 6)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(60, 27)
        Me.btkeluar.TabIndex = 1
        Me.btkeluar.Text = "Se&lesai"
        '
        'ms_barang3
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 132)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ms_barang3"
        Me.Text = "Area Tebusan"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.tkodekab.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnamakab.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tjml.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tjml As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tkodekab As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tnamakab As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btfindsal As DevExpress.XtraEditors.SimpleButton
End Class
