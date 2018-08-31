<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tr_kalk_rugilab
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
        Me.cbbulan = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ttahun = New DevExpress.XtraEditors.TextEdit()
        Me.cbstatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.cbbulan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttahun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbstatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbbulan
        '
        Me.cbbulan.Location = New System.Drawing.Point(244, 8)
        Me.cbbulan.Name = "cbbulan"
        Me.cbbulan.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbbulan.Properties.Appearance.Options.UseFont = True
        Me.cbbulan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbbulan.Properties.Items.AddRange(New Object() {"JANUARI", "FEBRUARI", "MARET", "APRIL", "MEI", "JUNI", "JULI", "AGUSTUS", "SEPTEMBER", "OKTOBER", "NOVEMBER", "DESEMBER"})
        Me.cbbulan.Size = New System.Drawing.Size(176, 22)
        Me.cbbulan.TabIndex = 0
        '
        'ttahun
        '
        Me.ttahun.Location = New System.Drawing.Point(71, 6)
        Me.ttahun.Name = "ttahun"
        Me.ttahun.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttahun.Properties.Appearance.Options.UseFont = True
        Me.ttahun.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ttahun.Size = New System.Drawing.Size(73, 22)
        Me.ttahun.TabIndex = 6
        '
        'cbstatus
        '
        Me.cbstatus.Location = New System.Drawing.Point(71, 34)
        Me.cbstatus.Name = "cbstatus"
        Me.cbstatus.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbstatus.Properties.Appearance.Options.UseFont = True
        Me.cbstatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbstatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("KODE", "Kode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAMA", "Area"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATUS", "Status")})
        Me.cbstatus.Properties.DisplayMember = "NAMA"
        Me.cbstatus.Properties.NullText = ""
        Me.cbstatus.Properties.ValueMember = "KODE"
        Me.cbstatus.Size = New System.Drawing.Size(349, 22)
        Me.cbstatus.TabIndex = 1
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(339, 62)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(81, 42)
        Me.btsimpan.TabIndex = 2
        Me.btsimpan.Text = "&Proses"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Tahun :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Area :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(185, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Bulan :"
        '
        'tr_kalk_rugilab
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 109)
        Me.Controls.Add(Me.cbbulan)
        Me.Controls.Add(Me.ttahun)
        Me.Controls.Add(Me.cbstatus)
        Me.Controls.Add(Me.btsimpan)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "tr_kalk_rugilab"
        Me.Text = "Kalkulasi Laba Rugi"
        CType(Me.cbbulan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttahun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbstatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbbulan As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents ttahun As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbstatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
