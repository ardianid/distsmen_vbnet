﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fsl_gaji_angk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fsl_gaji_angk))
        Me.ttahun = New DevExpress.XtraEditors.TextEdit()
        Me.btpre = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.btfindspir = New DevExpress.XtraEditors.SimpleButton()
        Me.cbbulan = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tkode_spir = New DevExpress.XtraEditors.TextEdit()
        Me.tnama_spir = New DevExpress.XtraEditors.TextEdit()
        CType(Me.ttahun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.cbbulan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode_spir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama_spir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ttahun
        '
        Me.ttahun.Location = New System.Drawing.Point(72, 10)
        Me.ttahun.Name = "ttahun"
        Me.ttahun.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttahun.Properties.Appearance.Options.UseFont = True
        Me.ttahun.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ttahun.Properties.Mask.EditMask = "f0"
        Me.ttahun.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ttahun.Size = New System.Drawing.Size(73, 22)
        Me.ttahun.TabIndex = 0
        '
        'btpre
        '
        Me.btpre.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btpre.Appearance.Options.UseFont = True
        Me.btpre.Location = New System.Drawing.Point(318, 4)
        Me.btpre.Name = "btpre"
        Me.btpre.Size = New System.Drawing.Size(75, 27)
        Me.btpre.TabIndex = 0
        Me.btpre.Text = "&Preview"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 14)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Tahun :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Supir :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 14)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Bulan :"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ttahun)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btfindspir)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cbbulan)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tkode_spir)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tnama_spir)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btpre)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(401, 144)
        Me.SplitContainerControl1.SplitterPosition = 102
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'btfindspir
        '
        Me.btfindspir.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btfindspir.Appearance.Options.UseFont = True
        Me.btfindspir.Image = CType(resources.GetObject("btfindspir.Image"), System.Drawing.Image)
        Me.btfindspir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btfindspir.Location = New System.Drawing.Point(358, 63)
        Me.btfindspir.Name = "btfindspir"
        Me.btfindspir.Size = New System.Drawing.Size(23, 23)
        Me.btfindspir.TabIndex = 3
        '
        'cbbulan
        '
        Me.cbbulan.Location = New System.Drawing.Point(72, 38)
        Me.cbbulan.Name = "cbbulan"
        Me.cbbulan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbbulan.Properties.Items.AddRange(New Object() {"JANUARI", "FEBRUARI", "MARET", "APRIL", "MEI", "JUNI", "JULI", "AGUSTUS", "SEPTEMBER", "OKTOBER", "NOVEMBER", "DESEMBER"})
        Me.cbbulan.Size = New System.Drawing.Size(176, 20)
        Me.cbbulan.TabIndex = 1
        '
        'tkode_spir
        '
        Me.tkode_spir.Location = New System.Drawing.Point(72, 64)
        Me.tkode_spir.Name = "tkode_spir"
        Me.tkode_spir.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tkode_spir.Properties.Appearance.Options.UseFont = True
        Me.tkode_spir.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkode_spir.Size = New System.Drawing.Size(57, 22)
        Me.tkode_spir.TabIndex = 2
        '
        'tnama_spir
        '
        Me.tnama_spir.Location = New System.Drawing.Point(132, 64)
        Me.tnama_spir.Name = "tnama_spir"
        Me.tnama_spir.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnama_spir.Properties.Appearance.Options.UseFont = True
        Me.tnama_spir.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnama_spir.Properties.ReadOnly = True
        Me.tnama_spir.Size = New System.Drawing.Size(220, 22)
        Me.tnama_spir.TabIndex = 22
        '
        'fsl_gaji_angk
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 144)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fsl_gaji_angk"
        Me.Text = "Seleksi Rekap Anngkutan Lain"
        CType(Me.ttahun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.cbbulan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode_spir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama_spir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ttahun As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btpre As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents btfindspir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbbulan As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents tkode_spir As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tnama_spir As DevExpress.XtraEditors.TextEdit
End Class
