<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ms_sales2
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbstatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.ttgl = New DevExpress.XtraEditors.DateEdit()
        Me.talamat = New DevExpress.XtraEditors.MemoEdit()
        Me.caktif = New DevExpress.XtraEditors.CheckEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tkode = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.ttelp2 = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ttelp1 = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbjenis = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cbstatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.talamat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.caktif.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttelp2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttelp1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbjenis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.Appearance.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Right
        Me.GroupControl1.Controls.Add(Me.cbjenis)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.btkeluar)
        Me.GroupControl1.Controls.Add(Me.btsimpan)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.cbstatus)
        Me.GroupControl1.Controls.Add(Me.ttgl)
        Me.GroupControl1.Controls.Add(Me.talamat)
        Me.GroupControl1.Controls.Add(Me.caktif)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.tkode)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.tnama)
        Me.GroupControl1.Controls.Add(Me.ttelp2)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.ttelp1)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.LookAndFeel.SkinName = "Pumpkin"
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(425, 349)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Data Sales Detail"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 38)
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
        Me.btkeluar.Location = New System.Drawing.Point(335, 311)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(75, 27)
        Me.btkeluar.TabIndex = 9
        Me.btkeluar.Text = "Se&lesai"
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(254, 311)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 27)
        Me.btsimpan.TabIndex = 8
        Me.btsimpan.Text = "&Simpan"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 229)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Penempatan :"
        '
        'cbstatus
        '
        Me.cbstatus.Location = New System.Drawing.Point(119, 226)
        Me.cbstatus.Name = "cbstatus"
        Me.cbstatus.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbstatus.Properties.Appearance.Options.UseFont = True
        Me.cbstatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbstatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("KODE", "Kode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAMA", "Area"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATUS", "Status")})
        Me.cbstatus.Properties.DisplayMember = "NAMA"
        Me.cbstatus.Properties.NullText = ""
        Me.cbstatus.Properties.ValueMember = "KODE"
        Me.cbstatus.Size = New System.Drawing.Size(158, 22)
        Me.cbstatus.TabIndex = 6
        '
        'ttgl
        '
        Me.ttgl.EditValue = Nothing
        Me.ttgl.Location = New System.Drawing.Point(119, 254)
        Me.ttgl.Name = "ttgl"
        Me.ttgl.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttgl.Properties.Appearance.Options.UseFont = True
        Me.ttgl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ttgl.Properties.Mask.EditMask = ""
        Me.ttgl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.ttgl.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ttgl.Size = New System.Drawing.Size(158, 22)
        Me.ttgl.TabIndex = 7
        '
        'talamat
        '
        Me.talamat.Location = New System.Drawing.Point(119, 91)
        Me.talamat.Name = "talamat"
        Me.talamat.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.talamat.Properties.Appearance.Options.UseFont = True
        Me.talamat.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.talamat.Size = New System.Drawing.Size(279, 47)
        Me.talamat.TabIndex = 2
        '
        'caktif
        '
        Me.caktif.Location = New System.Drawing.Point(217, 35)
        Me.caktif.Name = "caktif"
        Me.caktif.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.caktif.Properties.Appearance.Options.UseFont = True
        Me.caktif.Properties.Caption = "&Aktif"
        Me.caktif.Size = New System.Drawing.Size(60, 21)
        Me.caktif.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 257)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Tgl Masuk :"
        '
        'tkode
        '
        Me.tkode.Location = New System.Drawing.Point(119, 35)
        Me.tkode.Name = "tkode"
        Me.tkode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tkode.Properties.Appearance.Options.UseFont = True
        Me.tkode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkode.Size = New System.Drawing.Size(73, 22)
        Me.tkode.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Telp 2 :"
        '
        'tnama
        '
        Me.tnama.Location = New System.Drawing.Point(119, 63)
        Me.tnama.Name = "tnama"
        Me.tnama.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnama.Properties.Appearance.Options.UseFont = True
        Me.tnama.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnama.Size = New System.Drawing.Size(279, 22)
        Me.tnama.TabIndex = 1
        '
        'ttelp2
        '
        Me.ttelp2.Location = New System.Drawing.Point(119, 172)
        Me.ttelp2.Name = "ttelp2"
        Me.ttelp2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttelp2.Properties.Appearance.Options.UseFont = True
        Me.ttelp2.Size = New System.Drawing.Size(279, 22)
        Me.ttelp2.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Alamat :"
        '
        'ttelp1
        '
        Me.ttelp1.Location = New System.Drawing.Point(119, 144)
        Me.ttelp1.Name = "ttelp1"
        Me.ttelp1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttelp1.Properties.Appearance.Options.UseFont = True
        Me.ttelp1.Size = New System.Drawing.Size(279, 22)
        Me.ttelp1.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Telp 1 :"
        '
        'cbjenis
        '
        Me.cbjenis.Location = New System.Drawing.Point(119, 200)
        Me.cbjenis.Name = "cbjenis"
        Me.cbjenis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbjenis.Properties.Items.AddRange(New Object() {"GAJI", "LANGSUNG"})
        Me.cbjenis.Size = New System.Drawing.Size(158, 20)
        Me.cbjenis.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 201)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Jenis Insentif :"
        '
        'ms_sales2
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 349)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ms_sales2"
        Me.Text = "Sales Detail :::"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.cbstatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.talamat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.caktif.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttelp2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttelp1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbjenis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbstatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ttgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents talamat As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents caktif As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tkode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ttelp2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ttelp1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbjenis As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
