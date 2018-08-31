<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fuser_detail
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.tpwd = New DevExpress.XtraEditors.TextEdit()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.cnonaktif = New DevExpress.XtraEditors.CheckEdit()
        Me.tpwd2 = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.KODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MNUFILE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ACUAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NAMAFORM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.T_ACTIVE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.REP_ACTIVE = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.T_ADD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.REP_ADD = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.T_EDIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.REP_ED = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.T_DEL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.REP_DEL = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.T_CETAK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.REP_CETAK = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.KETERANGAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.ck_piut = New DevExpress.XtraEditors.CheckEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ck_giro = New DevExpress.XtraEditors.CheckEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ck_kend = New DevExpress.XtraEditors.CheckEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ck_unl = New DevExpress.XtraEditors.CheckEdit()
        Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tpwd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cnonaktif.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tpwd2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REP_ACTIVE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REP_ADD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REP_ED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REP_DEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REP_CETAK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.ck_piut.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck_giro.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck_kend.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck_unl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nama User :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password :"
        '
        'tnama
        '
        Me.tnama.Location = New System.Drawing.Point(100, 11)
        Me.tnama.Name = "tnama"
        Me.tnama.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnama.Properties.Appearance.Options.UseFont = True
        Me.tnama.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnama.Size = New System.Drawing.Size(208, 22)
        Me.tnama.TabIndex = 0
        '
        'tpwd
        '
        Me.DxErrorProvider1.SetError(Me.tpwd, "Password hanya bisa berupa huruf atau huruf diikuti dengan angka")
        Me.DxErrorProvider1.SetErrorType(Me.tpwd, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information)
        Me.DxErrorProvider1.SetIconAlignment(Me.tpwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight)
        Me.tpwd.Location = New System.Drawing.Point(100, 46)
        Me.tpwd.Name = "tpwd"
        Me.tpwd.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpwd.Properties.Appearance.Options.UseFont = True
        Me.tpwd.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tpwd.Properties.UseSystemPasswordChar = True
        Me.tpwd.Size = New System.Drawing.Size(224, 22)
        Me.tpwd.TabIndex = 2
        '
        'btsimpan
        '
        Me.btsimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btsimpan.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsimpan.Appearance.Options.UseFont = True
        Me.btsimpan.Location = New System.Drawing.Point(951, 6)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 27)
        Me.btsimpan.TabIndex = 4
        Me.btsimpan.Text = "&Simpan"
        '
        'btkeluar
        '
        Me.btkeluar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btkeluar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btkeluar.Appearance.Options.UseFont = True
        Me.btkeluar.Location = New System.Drawing.Point(951, 39)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(75, 27)
        Me.btkeluar.TabIndex = 5
        Me.btkeluar.Text = "Se&lesai"
        '
        'cnonaktif
        '
        Me.cnonaktif.Location = New System.Drawing.Point(362, 11)
        Me.cnonaktif.Name = "cnonaktif"
        Me.cnonaktif.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cnonaktif.Properties.Appearance.Options.UseFont = True
        Me.cnonaktif.Properties.Caption = "&Nonaktifkan user"
        Me.cnonaktif.Size = New System.Drawing.Size(129, 21)
        Me.cnonaktif.TabIndex = 1
        '
        'tpwd2
        '
        Me.tpwd2.EditValue = ""
        Me.DxErrorProvider1.SetError(Me.tpwd2, "Password hanya bisa berupa huruf atau huruf diikuti dengan angka")
        Me.DxErrorProvider1.SetErrorType(Me.tpwd2, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information)
        Me.DxErrorProvider1.SetIconAlignment(Me.tpwd2, System.Windows.Forms.ErrorIconAlignment.MiddleRight)
        Me.tpwd2.Location = New System.Drawing.Point(495, 46)
        Me.tpwd2.Name = "tpwd2"
        Me.tpwd2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpwd2.Properties.Appearance.Options.UseFont = True
        Me.tpwd2.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tpwd2.Properties.UseSystemPasswordChar = True
        Me.tpwd2.Size = New System.Drawing.Size(224, 22)
        Me.tpwd2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(361, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Verifikasi Password :"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btkeluar)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cnonaktif)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tnama)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btsimpan)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tpwd2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tpwd)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.XtraTabControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1045, 580)
        Me.SplitContainerControl1.SplitterPosition = 81
        Me.SplitContainerControl1.TabIndex = 9
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1045, 493)
        Me.XtraTabControl1.TabIndex = 9
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.PanelControl1)
        Me.XtraTabPage1.Controls.Add(Me.GridControl1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1041, 458)
        Me.XtraTabPage1.Text = "Hak Akses PerForm"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.ComboBoxEdit1)
        Me.PanelControl1.Location = New System.Drawing.Point(824, -1)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(215, 34)
        Me.PanelControl1.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(5, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Opsi Cepat :"
        '
        'ComboBoxEdit1
        '
        Me.ComboBoxEdit1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEdit1.Location = New System.Drawing.Point(90, 9)
        Me.ComboBoxEdit1.Name = "ComboBoxEdit1"
        Me.ComboBoxEdit1.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.ComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit1.Properties.Items.AddRange(New Object() {"-Pilih opsi Cepat-", "Cek All", "Un-Check All"})
        Me.ComboBoxEdit1.Size = New System.Drawing.Size(120, 20)
        Me.ComboBoxEdit1.TabIndex = 1
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.REP_ADD, Me.REP_ED, Me.REP_DEL, Me.REP_CETAK, Me.REP_ACTIVE})
        Me.GridControl1.Size = New System.Drawing.Size(1041, 458)
        Me.GridControl1.TabIndex = 8
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.KODE, Me.MNUFILE, Me.ACUAN, Me.NAMAFORM, Me.T_ACTIVE, Me.T_ADD, Me.T_EDIT, Me.T_DEL, Me.T_CETAK, Me.KETERANGAN, Me.GridColumn1})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupCount = 2
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn1, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.MNUFILE, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'KODE
        '
        Me.KODE.Caption = "KODE"
        Me.KODE.FieldName = "KODE"
        Me.KODE.Name = "KODE"
        Me.KODE.OptionsColumn.AllowEdit = False
        '
        'MNUFILE
        '
        Me.MNUFILE.Caption = "MENU"
        Me.MNUFILE.FieldName = "MNFILE"
        Me.MNUFILE.Name = "MNUFILE"
        '
        'ACUAN
        '
        Me.ACUAN.Caption = "LOKASI"
        Me.ACUAN.FieldName = "ACUAN"
        Me.ACUAN.Name = "ACUAN"
        Me.ACUAN.OptionsColumn.AllowEdit = False
        Me.ACUAN.Visible = True
        Me.ACUAN.VisibleIndex = 0
        Me.ACUAN.Width = 154
        '
        'NAMAFORM
        '
        Me.NAMAFORM.Caption = "NAMA"
        Me.NAMAFORM.FieldName = "NAMA"
        Me.NAMAFORM.Name = "NAMAFORM"
        Me.NAMAFORM.OptionsColumn.AllowEdit = False
        Me.NAMAFORM.Visible = True
        Me.NAMAFORM.VisibleIndex = 1
        Me.NAMAFORM.Width = 131
        '
        'T_ACTIVE
        '
        Me.T_ACTIVE.AppearanceHeader.Options.UseTextOptions = True
        Me.T_ACTIVE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.T_ACTIVE.Caption = "ACTIVE"
        Me.T_ACTIVE.ColumnEdit = Me.REP_ACTIVE
        Me.T_ACTIVE.FieldName = "T_ACTIVE"
        Me.T_ACTIVE.Name = "T_ACTIVE"
        Me.T_ACTIVE.Visible = True
        Me.T_ACTIVE.VisibleIndex = 2
        Me.T_ACTIVE.Width = 49
        '
        'REP_ACTIVE
        '
        Me.REP_ACTIVE.AutoHeight = False
        Me.REP_ACTIVE.DisplayValueChecked = "1"
        Me.REP_ACTIVE.DisplayValueUnchecked = "0"
        Me.REP_ACTIVE.Name = "REP_ACTIVE"
        Me.REP_ACTIVE.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.REP_ACTIVE.ValueUnchecked = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'T_ADD
        '
        Me.T_ADD.AppearanceHeader.Options.UseTextOptions = True
        Me.T_ADD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.T_ADD.Caption = "TAMBAH"
        Me.T_ADD.ColumnEdit = Me.REP_ADD
        Me.T_ADD.FieldName = "T_ADD"
        Me.T_ADD.Name = "T_ADD"
        Me.T_ADD.Visible = True
        Me.T_ADD.VisibleIndex = 3
        Me.T_ADD.Width = 57
        '
        'REP_ADD
        '
        Me.REP_ADD.AutoHeight = False
        Me.REP_ADD.DisplayValueChecked = "1"
        Me.REP_ADD.DisplayValueUnchecked = "0"
        Me.REP_ADD.Name = "REP_ADD"
        Me.REP_ADD.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.REP_ADD.ValueUnchecked = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'T_EDIT
        '
        Me.T_EDIT.AppearanceHeader.Options.UseTextOptions = True
        Me.T_EDIT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.T_EDIT.Caption = "RUBAH"
        Me.T_EDIT.ColumnEdit = Me.REP_ED
        Me.T_EDIT.FieldName = "T_EDIT"
        Me.T_EDIT.Name = "T_EDIT"
        Me.T_EDIT.Visible = True
        Me.T_EDIT.VisibleIndex = 4
        Me.T_EDIT.Width = 49
        '
        'REP_ED
        '
        Me.REP_ED.AutoHeight = False
        Me.REP_ED.DisplayValueChecked = "1"
        Me.REP_ED.DisplayValueUnchecked = "0"
        Me.REP_ED.Name = "REP_ED"
        Me.REP_ED.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.REP_ED.ValueUnchecked = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'T_DEL
        '
        Me.T_DEL.AppearanceHeader.Options.UseTextOptions = True
        Me.T_DEL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.T_DEL.Caption = "HAPUS"
        Me.T_DEL.ColumnEdit = Me.REP_DEL
        Me.T_DEL.FieldName = "T_DEL"
        Me.T_DEL.Name = "T_DEL"
        Me.T_DEL.Visible = True
        Me.T_DEL.VisibleIndex = 5
        Me.T_DEL.Width = 46
        '
        'REP_DEL
        '
        Me.REP_DEL.AutoHeight = False
        Me.REP_DEL.DisplayValueChecked = "1"
        Me.REP_DEL.DisplayValueUnchecked = "0"
        Me.REP_DEL.Name = "REP_DEL"
        Me.REP_DEL.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.REP_DEL.ValueUnchecked = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'T_CETAK
        '
        Me.T_CETAK.AppearanceHeader.Options.UseTextOptions = True
        Me.T_CETAK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.T_CETAK.Caption = "CETAK"
        Me.T_CETAK.ColumnEdit = Me.REP_CETAK
        Me.T_CETAK.FieldName = "T_CETAK"
        Me.T_CETAK.Name = "T_CETAK"
        Me.T_CETAK.Visible = True
        Me.T_CETAK.VisibleIndex = 6
        Me.T_CETAK.Width = 44
        '
        'REP_CETAK
        '
        Me.REP_CETAK.AutoHeight = False
        Me.REP_CETAK.DisplayValueChecked = "1"
        Me.REP_CETAK.DisplayValueUnchecked = "0"
        Me.REP_CETAK.Name = "REP_CETAK"
        Me.REP_CETAK.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.REP_CETAK.ValueUnchecked = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'KETERANGAN
        '
        Me.KETERANGAN.Caption = "KETERANGAN"
        Me.KETERANGAN.FieldName = "KETERANGAN"
        Me.KETERANGAN.Name = "KETERANGAN"
        Me.KETERANGAN.OptionsColumn.AllowEdit = False
        Me.KETERANGAN.Visible = True
        Me.KETERANGAN.VisibleIndex = 7
        Me.KETERANGAN.Width = 441
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "JENIS"
        Me.GridColumn1.FieldName = "JENIS"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 8
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.ck_piut)
        Me.XtraTabPage2.Controls.Add(Me.Label9)
        Me.XtraTabPage2.Controls.Add(Me.ck_giro)
        Me.XtraTabPage2.Controls.Add(Me.Label8)
        Me.XtraTabPage2.Controls.Add(Me.Label7)
        Me.XtraTabPage2.Controls.Add(Me.ck_kend)
        Me.XtraTabPage2.Controls.Add(Me.Label6)
        Me.XtraTabPage2.Controls.Add(Me.Label5)
        Me.XtraTabPage2.Controls.Add(Me.ck_unl)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1076, 458)
        Me.XtraTabPage2.Text = "Utility"
        '
        'ck_piut
        '
        Me.ck_piut.Location = New System.Drawing.Point(77, 252)
        Me.ck_piut.Name = "ck_piut"
        Me.ck_piut.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_piut.Properties.Appearance.Options.UseFont = True
        Me.ck_piut.Properties.Caption = "&Tidak"
        Me.ck_piut.Size = New System.Drawing.Size(294, 21)
        Me.ck_piut.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(61, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(158, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "3. Piutang Overdue > 6 Hr"
        '
        'ck_giro
        '
        Me.ck_giro.Location = New System.Drawing.Point(77, 209)
        Me.ck_giro.Name = "ck_giro"
        Me.ck_giro.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_giro.Properties.Appearance.Options.UseFont = True
        Me.ck_giro.Properties.Caption = "&Tidak"
        Me.ck_giro.Size = New System.Drawing.Size(294, 21)
        Me.ck_giro.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(61, 190)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "2. Giro jatuh tempo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(61, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(167, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "1. KIR dan Pajak Kendaraan"
        '
        'ck_kend
        '
        Me.ck_kend.Location = New System.Drawing.Point(77, 166)
        Me.ck_kend.Name = "ck_kend"
        Me.ck_kend.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_kend.Properties.Appearance.Options.UseFont = True
        Me.ck_kend.Properties.Caption = "&Tidak"
        Me.ck_kend.Size = New System.Drawing.Size(294, 21)
        Me.ck_kend.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(390, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Pilih akses REMINDER (Peringatan) apa saja yang boleh diberikan :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(357, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Hak akses TANPA BATAS untuk print Faktur kepada user ini ?"
        '
        'ck_unl
        '
        Me.ck_unl.Location = New System.Drawing.Point(43, 49)
        Me.ck_unl.Name = "ck_unl"
        Me.ck_unl.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_unl.Properties.Appearance.Options.UseFont = True
        Me.ck_unl.Properties.Caption = "&Tidak"
        Me.ck_unl.Size = New System.Drawing.Size(294, 21)
        Me.ck_unl.TabIndex = 2
        '
        'DxErrorProvider1
        '
        Me.DxErrorProvider1.ContainerControl = Me
        '
        'fuser_detail
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 580)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "fuser_detail"
        Me.Text = "User Detail"
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tpwd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cnonaktif.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tpwd2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REP_ACTIVE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REP_ADD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REP_ED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REP_DEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REP_CETAK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        Me.XtraTabPage2.PerformLayout()
        CType(Me.ck_piut.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck_giro.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck_kend.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck_unl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tpwd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cnonaktif As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tpwd2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents KODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MNUFILE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ACUAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NAMAFORM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents T_ACTIVE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents REP_ACTIVE As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents T_ADD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents REP_ADD As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents T_EDIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents REP_ED As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents T_DEL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents REP_DEL As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents T_CETAK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents REP_CETAK As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents KETERANGAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ck_unl As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ck_piut As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ck_giro As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ck_kend As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
