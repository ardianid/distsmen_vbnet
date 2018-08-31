Imports Oracle.DataAccess.Client
Imports lsp.lspclass
Imports System
Imports System.Data

Public Class fuser_detail

    Public addstat As Boolean = True

    Public nama As String
    Public nonaktifkan As Integer
    Public un_print As Integer
    
    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private Sub load_header()

        Dim cn As OracleConnection = Nothing
        Dim cmd As OracleCommand
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("select UNL_PRINT,REM_KEND,REM_GIRO,REM_PIUTANG from admlsp.MS_USER_HEADER WHERE NAMA='{0}'", nama)

        Try

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            cmd = New OracleCommand(sql, cn)
            dread = cmd.ExecuteReader

            If dread.Read Then

                Dim cek As Integer = 0

                If IsNothing(dread(0).ToString) Then
                    ck_unl.Checked = False
                Else

                    cek = CInt(dread(0).ToString)

                    ck_unl.Checked = cek
                    ck_unl_CheckedChanged(Nothing, Nothing)

                End If

                Dim cek_kendaraan As Integer = 0
                If IsNothing(dread(1).ToString) Then
                    ck_kend.Checked = False
                Else

                    cek_kendaraan = CInt(dread(1).ToString)

                    ck_kend.Checked = cek_kendaraan
                    ck_kendaraan_CheckedChanged(Nothing, Nothing)

                End If

                Dim cek_giro As Integer = 0
                If IsNothing(dread(2).ToString) Then
                    ck_giro.Checked = False
                Else

                    cek_giro = CInt(dread(2).ToString)

                    ck_giro.Checked = cek_giro
                    ck_giro_CheckedChanged(Nothing, Nothing)

                End If

                Dim cek_piutang As Integer = 0
                If IsNothing(dread(3).ToString) Then
                    ck_piut.Checked = False
                Else

                    cek_piutang = CInt(dread(3).ToString)

                    ck_piut.Checked = cek_piutang
                    ck_piutang_CheckedChanged(Nothing, Nothing)

                End If

                dread.Close()

            Else
                dread.Close()
                ck_unl.Checked = False
            End If


        Catch ex As OracleException
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Informasi")
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try


    End Sub

    Private Sub manipulate()

        Dim cn As New OracleConnection
        
        Dim unlmtd_print As Integer = 0
        If ck_unl.Checked = True Then
            unlmtd_print = 1
        Else
            unlmtd_print = 0
        End If


        Dim cek_kendaraan As Integer = 0
        If ck_kend.Checked = True Then
            cek_kendaraan = 1
        Else
            cek_kendaraan = 0
        End If

        Dim cek_giro As Integer = 0
        If ck_giro.Checked = True Then
            cek_giro = 1
        Else
            cek_giro = 0
        End If

        Dim cek_piut As Integer = 0
        If ck_piut.Checked = True Then
            cek_piut = 1
        Else
            cek_piut = 0
        End If


            Dim sql_addproc As String = String.Format("BEGIN ADDU ('{0}','{1}'); END;", tnama.Text.ToUpper.Trim, tpwd.Text.ToUpper.Trim)
            Dim sql_alterproc As String = String.Format("BEGIN ALT_ADDU ('{0}','{1}'); END;", tnama.Text.ToUpper.Trim, tpwd.Text.ToUpper.Trim)
            Dim sql_alterlock As String = String.Format("BEGIN LOCKUSER ('{0}','{1}'); END;", IIf(cnonaktif.Checked.Equals(True), 0, 1), tnama.Text.ToUpper.Trim)

        Dim sql_insert As String = String.Format("INSERT INTO ADMLSP.MS_USER_HEADER (NAMA,NONAKTIF,USER_ADD,TGL_ADD,UNL_PRINT,REM_KEND,REM_GIRO,REM_PIUTANG) VALUES('{0}',{1},'{2}','{3}',{4},{5},{6},{7})", tnama.Text.Trim.ToUpper, IIf(cnonaktif.Checked.Equals(True), 1, 0), userprog, convert_date_to_eng(Date.Now.ToString), unlmtd_print, cek_kendaraan, cek_giro, cek_piut)
        Dim sql_update As String = String.Format("UPDATE ADMLSP.MS_USER_HEADER SET NONAKTIF={0},USER_EDIT='{1}',TGL_EDIT='{2}',UNL_PRINT={3},REM_KEND={4},REM_GIRO={5},REM_PIUTANG={6} WHERE NAMA='{7}'", IIf(cnonaktif.Checked.Equals(True), 1, 0), userprog, convert_date_to_eng(Date.Now.ToString), unlmtd_print, cek_kendaraan, cek_giro, cek_piut, tnama.Text.Trim.ToUpper)

            Dim sql_search As String = String.Format("select nama from admlsp.ms_user_header where nama='{0}'", tnama.Text.Trim)
            Dim dread As OracleDataReader
            Dim cmdsearch As OracleCommand

            Try




                cn = classmy.open_conn

                If addstat.Equals(True) Then

                    cmdsearch = New OracleCommand(sql_search, cn)
                    dread = cmdsearch.ExecuteReader

                    If dread.Read Then

                        dread.Close()
                        MsgBox("User sudah ada", MsgBoxStyle.Information, "Informasi")
                        tnama.Focus()
                        Exit Sub
                    Else
                        dread.Close()
                    End If

                End If


                open_wait()

                Dim sqltrans As OracleTransaction = cn.BeginTransaction


                Dim cmd As OracleCommand
                Dim cmd2 As OracleCommand
                Dim cmd3 As OracleCommand

                If addstat.Equals(True) Then

                    cmd2 = New OracleCommand With {.CommandType = CommandType.Text, .CommandText = sql_insert, .Connection = cn}
                cmd = New OracleCommand With {.CommandType = CommandType.StoredProcedure, .CommandText = "ADMLSP.ADDU", .Connection = cn}
                cmd.Parameters.Add("nme", OracleDbType.Varchar2).Value = tnama.Text.Trim.ToUpper
                cmd.Parameters.Add("pwd", OracleDbType.Varchar2).Value = tpwd.Text.Trim.ToUpper
                    cmd2.ExecuteNonQuery()



                    cmd.ExecuteNonQuery()



                Else


                    cmd2 = New OracleCommand With {.CommandType = CommandType.Text, .CommandText = sql_update, .Connection = cn}
                    cmd2.ExecuteNonQuery()

                    If Not (tpwd.Text = "" Or tpwd2.Text = "") Then
                        cmd = New OracleCommand With {.CommandType = CommandType.StoredProcedure, .CommandText = "ADMLSP.ALT_ADDU", .Connection = cn}
                        cmd.Parameters.Add("nme", OracleDbType.Varchar2).Value = tnama.Text.Trim.ToUpper
                        cmd.Parameters.Add("pwd_new", OracleDbType.Varchar2).Value = tpwd.Text.Trim.ToUpper

                        cmd.ExecuteNonQuery()

                    End If

                    cmd3 = New OracleCommand With {.CommandType = CommandType.StoredProcedure, .CommandText = "ADMLSP.LOCKUSER", .Connection = cn}
                    cmd3.Parameters.Add("LOCKS", OracleDbType.Varchar2).Value = IIf(cnonaktif.Checked.Equals(True), 1, 0)
                    cmd3.Parameters.Add("USERT", OracleDbType.Varchar2).Value = tnama.Text.ToUpper.Trim

                    cmd3.ExecuteNonQuery()

                End If


                manipulate_detail(cn)

                sqltrans.Commit()

                Me.Close()

            Catch ex As OracleException

                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Informasi")
            Finally

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If

                close_wait()
                fuser.refresh_data()


            End Try


    End Sub

    Private Sub manipulate_detail(ByVal cn As OracleConnection)

        Dim sql As String
        Dim sql_ins As String
        Dim sql_edit As String
        Dim a As Integer = 0
        Dim dread As OracleDataReader = Nothing
        Dim comd As OracleCommand
        Dim comd2 As OracleCommand

        For a = 0 To dv1.Count - 1

            sql = String.Format("select id from admlsp.ms_user_detail where kd_menu='{0}' and nama_user='{1}'", dv1(a)(0).ToString, tnama.Text.Trim.ToUpper)

            comd = New OracleCommand With {.CommandType = CommandType.Text, .CommandText = sql, .Connection = cn}
            dread = comd.ExecuteReader

            If dread.Read Then

                sql_edit = String.Format("update admlsp.ms_user_detail set t_active={0},t_add={1},t_edit={2},t_del={3},t_cetak={4} where id={5}", dv1(a)(3).ToString, dv1(a)(4).ToString, dv1(a)(5).ToString, dv1(a)(6).ToString, dv1(a)(7).ToString, dread(0).ToString)
                comd2 = New OracleCommand With {.CommandType = CommandType.Text, .CommandText = sql_edit, .Connection = cn}
                comd2.ExecuteNonQuery()

            Else

                sql_ins = String.Format("insert into admlsp.ms_user_detail (kd_menu,t_active,t_add,t_edit,t_del,t_cetak,nama_user) values('{0}',{1},{2},{3},{4},{5},'{6}')", dv1(a)(0).ToString, dv1(a)(3).ToString, dv1(a)(4).ToString, dv1(a)(5).ToString, dv1(a)(6).ToString, dv1(a)(7).ToString, tnama.Text.Trim.ToUpper)
                comd2 = New OracleCommand With {.CommandType = CommandType.Text, .CommandText = sql_ins, .Connection = cn}
                comd2.ExecuteNonQuery()

            End If


        Next

    End Sub

    Private Sub load_detail()


        Dim ds As DataSet
        Dim cn As OracleConnection = Nothing

        Dim sql_add As String = "SELECT A.KODE,A.ACUAN,A.NAMA,0 AS T_ACTIVE,0 AS T_ADD,0 AS T_EDIT,0 AS T_DEL,0 AS T_CETAK,A.KETERANGAN,A.MNFILE,A.JENIS" _
            + " FROM ADMLSP.MS_MENU A"

        Try

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql_add, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            GridControl1.DataSource = dv1

            If addstat.Equals(False) Then
                cek_valid_user(cn)
            End If


        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

    End Sub

    Private Sub cek_valid_user(ByVal cn As OracleConnection)

        Dim a As Integer = 0
        Dim dred As OracleDataReader = Nothing
        Dim sql As String = ""
        Dim mycomd As OracleCommand = Nothing
        Dim kode As String

        Try


            If Not (dv1.Count <= 0) Then

                For a = 0 To dv1.Count - 1

                    kode = dv1(a)("KODE").ToString

                    sql = String.Format("select t_active,t_add,t_edit,t_del,t_cetak from admlsp.ms_user_detail where kd_menu='{0}' and nama_user=upper('{1}')", kode, tnama.Text)

                    mycomd = New OracleCommand With {.CommandType = CommandType.Text, .CommandText = sql, .Connection = cn}
                    dred = mycomd.ExecuteReader

                    If dred.Read Then


                        dv1(a)(3) = Convert.ToInt32(dred(0).ToString)
                        dv1(a)(4) = Convert.ToInt32(dred(1).ToString)
                        dv1(a)(5) = Convert.ToInt32(dred(2).ToString)
                        dv1(a)(6) = Convert.ToInt32(dred(3).ToString)
                        dv1(a)(7) = Convert.ToInt32(dred(4).ToString)

                    End If

                    dred.Close()

                Next

                GridControl1.Refresh()

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        End Try

        

    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub fuser_detail_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If addstat.Equals(True) Then
            tnama.Focus()
        Else
            tpwd.Focus()
        End If

    End Sub

    Private Sub fuser_detail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If addstat.Equals(True) Then
            tnama.Enabled = True

            cnonaktif.Checked = False
            cnonaktif.Enabled = False

        Else
            tnama.Enabled = False

            tnama.Text = nama
            cnonaktif.Enabled = True
            cnonaktif.Checked = nonaktifkan

            'ck_unl.Checked = un_print
            'ck_unl_CheckedChanged(sender, Nothing)

            load_header()

        End If

        load_detail()
        ComboBoxEdit1.SelectedIndex = 0

    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tnama.Text = "" Then
            MsgBox("Nama user tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
            tnama.Focus()
            Exit Sub
        End If

        If addstat.Equals(True) Then

            If tpwd.Text = "" Then
                MsgBox("Password tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
                tpwd.Focus()
                Exit Sub
            End If

            If tpwd2.Text = "" Then
                MsgBox("Verifikasi password tidak boleh kosong", MsgBoxStyle.Information, "Informasi")
                tpwd2.Focus()
                Exit Sub
            End If

            If Not tpwd.Text.Equals(tpwd2.Text) Then

                MsgBox("Password dan verifikasi password tidak sama", MsgBoxStyle.Information, "Informasi")
                tpwd.Focus()
                Exit Sub
            End If

        Else

            If tpwd.Text <> "" And tpwd2.Text <> "" Then

                If Not tpwd.Text.Equals(tpwd2.Text) Then

                    MsgBox("Password dan verifikasi password tidak sama", MsgBoxStyle.Information, "Informasi")
                    tpwd.Focus()
                    Exit Sub
                End If

            End If

        End If

        manipulate()

    End Sub

    Private Sub ComboBoxEdit1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxEdit1.SelectedIndexChanged

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count > 0 Then

            Dim a As Integer = 0
            For a = 0 To dv1.Count - 1

                If ComboBoxEdit1.SelectedIndex = 1 Then

                    dv1(a)(3) = 1 ' active
                    dv1(a)(4) = 1 ' add
                    dv1(a)(5) = 1 ' edit
                    dv1(a)(6) = 1 ' del
                    dv1(a)(7) = 1 ' cetak

                ElseIf ComboBoxEdit1.SelectedIndex = 2 Then

                    dv1(a)(3) = 0 ' active
                    dv1(a)(4) = 0 ' add
                    dv1(a)(5) = 0 ' edit
                    dv1(a)(6) = 0 ' del
                    dv1(a)(7) = 0 ' cetak

                End If

            Next


            GridControl1.Refresh()

        End If

    End Sub

    Private Sub tnama_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tnama.EditValueChanged

    End Sub

    Private Sub tnama_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tnama.KeyDown
        If e.KeyCode = 13 Then
            tpwd.Focus()
        End If
    End Sub

    Private Sub tpwd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tpwd.KeyDown
        If e.KeyCode = 13 Then
            tpwd2.Focus()
        End If
    End Sub

    Private Sub ck_unl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ck_unl.CheckedChanged

        If ck_unl.Checked = True Then
            ck_unl.Text = "&Ya"
        Else
            ck_unl.Text = "&Tidak"
        End If

    End Sub

    Private Sub ck_kendaraan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ck_kend.CheckedChanged

        If ck_kend.Checked = True Then
            ck_kend.Text = "&Ya"
        Else
            ck_kend.Text = "&Tidak"
        End If

    End Sub

    Private Sub ck_giro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ck_giro.CheckedChanged

        If ck_giro.Checked = True Then
            ck_giro.Text = "&Ya"
        Else
            ck_giro.Text = "&Tidak"
        End If

    End Sub

    Private Sub ck_piutang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ck_piut.CheckedChanged

        If ck_piut.Checked = True Then
            ck_piut.Text = "&Ya"
        Else
            ck_piut.Text = "&Tidak"
        End If

    End Sub

    Private Sub PanelControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelControl1.Paint

    End Sub
End Class