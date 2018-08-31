<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ms_giro2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ms_giro2))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tstatus = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tket = New DevExpress.XtraEditors.MemoEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tnil_pakai = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbank = New DevExpress.XtraEditors.TextEdit()
        Me.tkode_toko = New DevExpress.XtraEditors.TextEdit()
        Me.tnama_toko = New DevExpress.XtraEditors.TextEdit()
        Me.btfind = New DevExpress.XtraEditors.SimpleButton()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.ttgl = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tnogiro = New DevExpress.XtraEditors.TextEdit()
        Me.tnil = New DevExpress.XtraEditors.TextEdit()
        Me.talamat_toko = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.tstatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnil_pakai.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode_toko.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama_toko.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnogiro.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.talamat_toko.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.tstatus)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.tket)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.tnil_pakai)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.tbank)
        Me.GroupControl1.Controls.Add(Me.tkode_toko)
        Me.GroupControl1.Controls.Add(Me.tnama_toko)
        Me.GroupControl1.Controls.Add(Me.btfind)
        Me.GroupControl1.Controls.Add(Me.btkeluar)
        Me.GroupControl1.Controls.Add(Me.btsimpan)
        Me.GroupControl1.Controls.Add(Me.ttgl)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.tnogiro)
        Me.GroupControl1.Controls.Add(Me.tnil)
        Me.GroupControl1.Controls.Add(Me.talamat_toko)
        Me.GroupControl1.Location = New System.Drawing.Point(6, 7)
        Me.GroupControl1.LookAndFeel.SkinName = "Seven Classic"
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(420, 386)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Giro Detail"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 16)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Status :"
        '
        'tstatus
        '
        Me.tstatus.Location = New System.Drawing.Point(118, 41)
        Me.tstatus.Name = "tstatus"
        Me.tstatus.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstatus.Properties.Appearance.Options.UseFont = True
        Me.tstatus.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstatus.Properties.ReadOnly = True
        Me.tstatus.Size = New System.Drawing.Size(129, 22)
        Me.tstatus.TabIndex = 47
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 269)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 16)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Keterangan :"
        '
        'tket
        '
        Me.tket.Location = New System.Drawing.Point(118, 266)
        Me.tket.Name = "tket"
        Me.tket.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tket.Properties.Appearance.Options.UseFont = True
        Me.tket.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tket.Size = New System.Drawing.Size(251, 63)
        Me.tket.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Nilai Pakai :"
        '
        'tnil_pakai
        '
        Me.tnil_pakai.Location = New System.Drawing.Point(118, 238)
        Me.tnil_pakai.Name = "tnil_pakai"
        Me.tnil_pakai.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnil_pakai.Properties.Appearance.Options.UseFont = True
        Me.tnil_pakai.Properties.Appearance.Options.UseTextOptions = True
        Me.tnil_pakai.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.tnil_pakai.Properties.DisplayFormat.FormatString = "n"
        Me.tnil_pakai.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tnil_pakai.Properties.EditFormat.FormatString = "n"
        Me.tnil_pakai.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tnil_pakai.Properties.Mask.EditMask = "n"
        Me.tnil_pakai.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tnil_pakai.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tnil_pakai.Properties.ReadOnly = True
        Me.tnil_pakai.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tnil_pakai.Size = New System.Drawing.Size(129, 22)
        Me.tnil_pakai.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Bank :"
        '
        'tbank
        '
        Me.tbank.Location = New System.Drawing.Point(118, 97)
        Me.tbank.Name = "tbank"
        Me.tbank.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbank.Properties.Appearance.Options.UseFont = True
        Me.tbank.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbank.Size = New System.Drawing.Size(129, 22)
        Me.tbank.TabIndex = 2
        '
        'tkode_toko
        '
        Me.tkode_toko.Location = New System.Drawing.Point(118, 125)
        Me.tkode_toko.Name = "tkode_toko"
        Me.tkode_toko.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tkode_toko.Properties.Appearance.Options.UseFont = True
        Me.tkode_toko.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkode_toko.Size = New System.Drawing.Size(45, 22)
        Me.tkode_toko.TabIndex = 3
        '
        'tnama_toko
        '
        Me.tnama_toko.Location = New System.Drawing.Point(166, 125)
        Me.tnama_toko.Name = "tnama_toko"
        Me.tnama_toko.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnama_toko.Properties.Appearance.Options.UseFont = True
        Me.tnama_toko.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnama_toko.Properties.ReadOnly = True
        Me.tnama_toko.Size = New System.Drawing.Size(203, 22)
        Me.tnama_toko.TabIndex = 2
        '
        'btfind
        '
        Me.btfind.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btfind.Appearance.Options.UseFont = True
        Me.btfind.Image = CType(resources.GetObject("btfind.Image"), System.Drawing.Image)
        Me.btfind.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btfind.Location = New System.Drawing.Point(375, 124)
        Me.btfind.Name = "btfind"
        Me.btfind.Size = New System.Drawing.Size(23, 23)
        Me.btfind.TabIndex = 4
        '
        'btkeluar
        '
        Me.btkeluar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btkeluar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btkeluar.Appearance.Options.UseFont = True
        Me.btkeluar.Location = New System.Drawing.Point(339, 353)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(75, 27)
        Me.btkeluar.TabIndex = 8
        Me.btkeluar.Text = "Se&lesai"
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(258, 353)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 27)
        Me.btsimpan.TabIndex = 7
        Me.btsimpan.Text = "&Simpan"
        '
        'ttgl
        '
        Me.ttgl.EditValue = Nothing
        Me.ttgl.Location = New System.Drawing.Point(118, 69)
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
        Me.Label2.Location = New System.Drawing.Point(27, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Jatuh Tempo :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "No Giro :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Toko :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Nilai :"
        '
        'tnogiro
        '
        Me.tnogiro.Location = New System.Drawing.Point(118, 16)
        Me.tnogiro.Name = "tnogiro"
        Me.tnogiro.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnogiro.Properties.Appearance.Options.UseFont = True
        Me.tnogiro.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnogiro.Size = New System.Drawing.Size(129, 22)
        Me.tnogiro.TabIndex = 0
        '
        'tnil
        '
        Me.tnil.Location = New System.Drawing.Point(118, 210)
        Me.tnil.Name = "tnil"
        Me.tnil.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnil.Properties.Appearance.Options.UseFont = True
        Me.tnil.Properties.Appearance.Options.UseTextOptions = True
        Me.tnil.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.tnil.Properties.DisplayFormat.FormatString = "n"
        Me.tnil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tnil.Properties.EditFormat.FormatString = "n"
        Me.tnil.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.tnil.Properties.Mask.EditMask = "n"
        Me.tnil.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tnil.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tnil.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tnil.Size = New System.Drawing.Size(129, 22)
        Me.tnil.TabIndex = 5
        '
        'talamat_toko
        '
        Me.talamat_toko.Location = New System.Drawing.Point(118, 153)
        Me.talamat_toko.Name = "talamat_toko"
        Me.talamat_toko.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.talamat_toko.Properties.Appearance.Options.UseFont = True
        Me.talamat_toko.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.talamat_toko.Properties.ReadOnly = True
        Me.talamat_toko.Size = New System.Drawing.Size(251, 51)
        Me.talamat_toko.TabIndex = 40
        '
        'ms_giro2
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 398)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ms_giro2"
        Me.Text = "Giro Detail"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.tstatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnil_pakai.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode_toko.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama_toko.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnogiro.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.talamat_toko.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents tkode_toko As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tnama_toko As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btfind As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ttgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tnogiro As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tnil As DevExpress.XtraEditors.TextEdit
    Friend WithEvents talamat_toko As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbank As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tnil_pakai As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tket As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tstatus As DevExpress.XtraEditors.TextEdit
End Class
