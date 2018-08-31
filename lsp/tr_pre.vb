Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client

Public Class tr_pre

    Private bs1 As BindingSource
    Private ds As DataSet
    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Get_Aksesform()

    End Sub

    Private Sub Get_Aksesform()

        Dim rows() As DataRow = dtmenu.Select(String.Format("NAMAFORM='{0}'", Me.Name.ToUpper.ToString))

        If Convert.ToInt16(rows(0)("T_ADD")) = 1 Then
            tsadd.Enabled = True
        Else
            tsadd.Enabled = False
        End If

        If Convert.ToInt16(rows(0)("T_EDIT")) = 1 Then
            tsedit.Enabled = True
        Else
            tsedit.Enabled = False
        End If

        If Convert.ToInt16(rows(0)("T_DEL")) = 1 Then
            tsdel.Enabled = True
        Else
            tsdel.Enabled = False
        End If

        If Convert.ToInt16(rows(0)("T_CETAK")) = 1 Then

        Else

        End If

    End Sub

    Sub refresh_data()
        opendata()
    End Sub

    Private Sub opendata()

        tsfind.Text = ""
        Dim cn As OracleConnection = Nothing

        Dim sql As String = ""

        If get_stat_pusat() = 0 Then

            sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                "WHERE ROWNUM <=50 AND A.KD_STAT='{0}' ORDER BY A.TANGGAL DESC", get_kode_stat)
        ElseIf get_stat_pusat() = 1 Then

            sql = "SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                "WHERE ROWNUM <=50 ORDER BY A.TANGGAL DESC"

        Else
            Exit Sub
        End If


        grid1.DataSource = Nothing


        Try

            open_wait()

            dv1 = Nothing

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))


            bs1 = New BindingSource
            bs1.DataSource = dv1
            bn1.BindingSource = bs1

            grid1.DataSource = bs1

            close_wait()

        Catch ex As OracleException
            close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally


            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

    End Sub

    Private Sub cari()

        Dim cn As OracleConnection = Nothing

        grid1.DataSource = Nothing

        Dim sql As String = ""

        If get_stat_pusat() = 1 Then

            Select Case cbfind.SelectedIndex
                Case 0 ' no bukti
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND A.NO_BUKTI LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)
                Case 1 ' tanggal

                    If Not IsDate(tsfind.Text.Trim) Then

                        MsgBox("Format tanggal yang anda masukkan salah", MsgBoxStyle.Information, "Informasi")
                        tsfind.Focus()
                        Exit Sub
                    End If

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND A.TANGGAL='{0}' ORDER BY A.TANGGAL DESC", convert_date_to_eng(tsfind.Text.Trim.ToString))
                Case 2 ' PRINCIPAL

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND C.NAMA LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)

                Case 3 ' KSO

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND F.NAMA LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)

                Case 4 ' REQ ORDER / NAMA TOKO

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND E.NAMA_TOKO LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)

                Case 5 ' SUPIR

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND A.NAMA_SUPIR LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)

                Case 6 ' NOPOL

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND A.NOPOL LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)

            End Select

        ElseIf get_stat_pusat() = 0 Then

            Select Case cbfind.SelectedIndex
                Case 0 ' no bukti
                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND A.NO_BUKTI LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)
                Case 1 ' tanggal

                    If Not IsDate(tsfind.Text.Trim) Then

                        MsgBox("Format tanggal yang anda masukkan salah", MsgBoxStyle.Information, "Informasi")
                        tsfind.Focus()
                        Exit Sub
                    End If

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND A.TANGGAL='{0}' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", convert_date_to_eng(tsfind.Text.Trim.ToString), get_kode_stat)
                Case 2 ' PRINCIPAL

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND C.NAMA LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 3 ' KSO

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND F.NAMA LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 4 ' REQ ORDER / NAMA TOKO

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND E.NAMA_TOKO LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 5 ' SUPIR

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND A.NAMA_SUPIR LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 6 ' NOPOL

                    sql = String.Format("SELECT A.NO_BUKTI,A.TANGGAL,A.KD_PRC,C.NAMA AS PRINCIPAL,A.KD_SUPIR,A.NAMA_SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.JML_DATANG,A.TOT_HARGA,E.NAMA_TOKO,F.NAMA AS NAMA_KSO,A.KD_TOKO,A.KD_KSO,F.ALAMAT AS ALAMAT_KSO,E.ALAMAT AS ALAMAT_TOKO,A.OKS_KSO,A.TOT_OKS_KSO " & _
                        "FROM ADMLSP.TR_PRE A INNER JOIN ADMLSP.MS_PRINCIPAL C ON A.KD_PRC=C.KD_PRC INNER JOIN ADMLSP.MS_STAT D ON A.KD_STAT=D.KODE " & _
                        "INNER JOIN ADMLSP.MS_TOKO E ON A.KD_TOKO=E.KD_TOKO LEFT JOIN ADMLSP.MS_KSO F ON A.KD_KSO=F.KODE " & _
                        "WHERE ROWNUM <=1000 AND A.NOPOL LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

            End Select

        Else
            Exit Sub
        End If

        Try

            open_wait()

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            bs1.DataSource = dv1
            bn1.BindingSource = bs1

            grid1.DataSource = bs1

            close_wait()

        Catch ex As Exception
            close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Sub hapus_data()


        If dv1.Count > 0 Then


            Dim sql As String = String.Format("delete from admlsp.TR_PRE where no_bukti='{0}'", dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString)
            Dim sqlupdate As String = String.Format("update admlsp.TR_PRE set user_edit='{0}',tgl_edit='{1}' where no_bukti='{2}'", userprog, convert_date_to_eng(Date.Now.ToString), dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString)
            Dim sqldelete As String = String.Format("delete from admlsp.TR_PRE2 where no_bukti='{0}'", dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString)

            Dim cmd_DEt As OracleCommand = Nothing
            Dim cmd As OracleCommand = Nothing
            Dim cmdEdit As OracleCommand = Nothing
            Dim cn As OracleConnection = Nothing

            Try

                If MsgBox("Yakin akan dihapus ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi") = MsgBoxResult.Yes Then

                    open_wait()

                    cn = classmy.open_conn_utama

                    Dim sqltrans As OracleTransaction = cn.BeginTransaction

                    cmdEdit = New OracleCommand(sqlupdate, cn)
                    cmdEdit.ExecuteNonQuery()

                    ins_to_temp_user(cn, sqlupdate, dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString, "TR_PRE", "UPDATE", "PRE RELEASE")

                    cmd_DEt = New OracleCommand(sqldelete, cn)
                    cmd_DEt.ExecuteNonQuery()

                    ins_to_temp_user(cn, sqldelete, dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString, "TR_PRE2", "DELETE", "PRE RELEASE")

                    cmd = New OracleCommand(sql, cn)
                    cmd.ExecuteNonQuery()

                    ins_to_temp_user(cn, sql, dv1(BindingContext(bs1).Position)("NO_BUKTI").ToString, "TR_PRE", "DELETE", "PRE RELEASE")

                    sqltrans.Commit()
                    opendata()

                    close_wait()

                End If

            Catch ex As OracleException
                close_wait()
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            Finally

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If

            End Try


        End If


    End Sub

    Public Function cek_JmlDatang(ByVal no_buktiS As String) As Integer

        Dim sql As String = ""
        Dim cmd As OracleCommand = Nothing
        Dim dread As OracleDataReader = Nothing
        Dim cn As OracleConnection = Nothing

        Dim jml As Integer = 0

        sql = String.Format("select a.JML_DATANG from admlsp.tr_pre a where a.NO_BUKTI='{0}'", no_buktiS)

        Try

            cn = classmy.open_conn_utama

            cmd = New OracleCommand(sql, cn)
            dread = cmd.ExecuteReader

            If dread.Read Then

                jml = dread(0).ToString
                dread.Close()

            Else
                dread.Close()
                jml = 0
            End If


        Catch ex As OracleException
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

        Return jml

    End Function

    Private Sub ms_toko_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cbfind.SelectedIndex = 0
        opendata()
    End Sub

    Private Sub btfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfind.Click
        cari()
    End Sub

    Private Sub tsfind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsfind.KeyDown
        If e.KeyCode = 13 Then
            cari()
        End If
    End Sub

    Private Sub tsdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdel.Click

        Dim jmldat As Integer = 0
        jmldat = cek_JmlDatang(dv1(bs1.Position)("NO_BUKTI").ToString)

        If jmldat > 0 Then
            MsgBox("Data tidak dapat dihapus karna sudah datang ....", MsgBoxStyle.Exclamation, "Informasi")
            Exit Sub
        End If

        hapus_data()
    End Sub

    Private Sub tsadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsadd.Click

        'Dim jmldat As Double = 0
        'jmldat = dv1(bs1.Position)("JML_DATANG").ToString

        'If jmldat > 0 Then
        '    Exit Sub
        'End If

        Using tr_dep2 As New tr_pre2(True, dv1, 0) With {.StartPosition = FormStartPosition.CenterScreen}
            tr_dep2.ShowDialog(Me)
        End Using

    End Sub

    Private Sub tsedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsedit.Click


        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Dim jmldat As Integer = 0
        jmldat = cek_JmlDatang(dv1(bs1.Position)("NO_BUKTI").ToString)

        If jmldat > 0 Then
            MsgBox("Data tidak dapat diedit karna sudah datang ....", MsgBoxStyle.Exclamation, "Informasi")
            Exit Sub
        End If

        Using tr_dep2 As New tr_pre2(False, dv1, bs1.Position) With {.StartPosition = FormStartPosition.CenterScreen}
            tr_dep2.ShowDialog(Me)
        End Using

    End Sub

End Class