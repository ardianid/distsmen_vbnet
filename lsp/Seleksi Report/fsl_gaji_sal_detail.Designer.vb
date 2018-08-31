<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fsl_gaji_sal_detail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fsl_gaji_sal_detail))
        Me.ttahun = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.cbarea = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tkodesal = New DevExpress.XtraEditors.TextEdit()
        Me.tnamasal = New DevExpress.XtraEditors.TextEdit()
        Me.btfindsal = New DevExpress.XtraEditors.SimpleButton()
        Me.cbbulan = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btpre = New DevExpress.XtraEditors.SimpleButton()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.ttahun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.cbarea.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkodesal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnamasal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbbulan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ttahun
        '
        Me.ttahun.Location = New System.Drawing.Point(128, 10)
        Me.ttahun.Name = "ttahun"
        Me.ttahun.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttahun.Properties.Appearance.Options.UseFont = True
        Me.ttahun.Properties.Appearance.Options.UseTextOptions = True
        Me.ttahun.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ttahun.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ttahun.Properties.Mask.EditMask = "f0"
        Me.ttahun.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ttahun.Properties.ReadOnly = True
        Me.ttahun.Size = New System.Drawing.Size(57, 22)
        Me.ttahun.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Tahun/Bulan :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Sales :"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.RadioGroup1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cbarea)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tkodesal)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tnamasal)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btfindsal)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ttahun)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cbbulan)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btpre)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(482, 189)
        Me.SplitContainerControl1.SplitterPosition = 144
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'cbarea
        '
        Me.cbarea.Location = New System.Drawing.Point(128, 66)
        Me.cbarea.Name = "cbarea"
        Me.cbarea.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbarea.Properties.Appearance.Options.UseFont = True
        Me.cbarea.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbarea.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("KODE", "Kode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAMA", "Area")})
        Me.cbarea.Properties.DisplayMember = "NAMA"
        Me.cbarea.Properties.NullText = ""
        Me.cbarea.Properties.ShowHeader = False
        Me.cbarea.Properties.ValueMember = "KODE"
        Me.cbarea.Size = New System.Drawing.Size(296, 22)
        Me.cbarea.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 16)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Area :"
        '
        'tkodesal
        '
        Me.tkodesal.Location = New System.Drawing.Point(128, 38)
        Me.tkodesal.Name = "tkodesal"
        Me.tkodesal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tkodesal.Properties.Appearance.Options.UseFont = True
        Me.tkodesal.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkodesal.Size = New System.Drawing.Size(57, 22)
        Me.tkodesal.TabIndex = 1
        '
        'tnamasal
        '
        Me.tnamasal.Location = New System.Drawing.Point(191, 38)
        Me.tnamasal.Name = "tnamasal"
        Me.tnamasal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnamasal.Properties.Appearance.Options.UseFont = True
        Me.tnamasal.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnamasal.Properties.ReadOnly = True
        Me.tnamasal.Size = New System.Drawing.Size(233, 22)
        Me.tnamasal.TabIndex = 26
        '
        'btfindsal
        '
        Me.btfindsal.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btfindsal.Appearance.Options.UseFont = True
        Me.btfindsal.Image = CType(resources.GetObject("btfindsal.Image"), System.Drawing.Image)
        Me.btfindsal.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btfindsal.Location = New System.Drawing.Point(430, 37)
        Me.btfindsal.Name = "btfindsal"
        Me.btfindsal.Size = New System.Drawing.Size(23, 23)
        Me.btfindsal.TabIndex = 2
        '
        'cbbulan
        '
        Me.cbbulan.Location = New System.Drawing.Point(191, 10)
        Me.cbbulan.Name = "cbbulan"
        Me.cbbulan.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbbulan.Properties.Appearance.Options.UseFont = True
        Me.cbbulan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbbulan.Properties.Items.AddRange(New Object() {"JANUARI", "FEBRUARI", "MARET", "APRIL", "MEI", "JUNI", "JULI", "AGUSTUS", "SEPTEMBER", "OKTOBER", "NOVEMBER", "DESEMBER"})
        Me.cbbulan.Size = New System.Drawing.Size(233, 22)
        Me.cbbulan.TabIndex = 0
        '
        'btpre
        '
        Me.btpre.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btpre.Appearance.Options.UseFont = True
        Me.btpre.Location = New System.Drawing.Point(393, 4)
        Me.btpre.Name = "btpre"
        Me.btpre.Size = New System.Drawing.Size(75, 27)
        Me.btpre.TabIndex = 0
        Me.btpre.Text = "&Preview"
        '
        'RadioGroup1
        '
        Me.RadioGroup1.Location = New System.Drawing.Point(128, 94)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(CType(1, Short), "Total"), New DevExpress.XtraEditors.Controls.RadioGroupItem(CType(0, Short), "Detail")})
        Me.RadioGroup1.Size = New System.Drawing.Size(134, 24)
        Me.RadioGroup1.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 16)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "Jenis Laporan :"
        '
        'fsl_gaji_sal_detail
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 189)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fsl_gaji_sal_detail"
        Me.Text = "Seleksi pendapatan sales"
        CType(Me.ttahun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.cbarea.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkodesal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnamasal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbbulan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ttahun As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents cbbulan As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btpre As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tkodesal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tnamasal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btfindsal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbarea As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
