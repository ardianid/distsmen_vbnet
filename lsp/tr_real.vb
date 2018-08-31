Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client

Public Class tr_real

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
            tsprint.Enabled = True
        Else
            tsprint.Enabled = False
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

            sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=50 AND A.KD_STAT='{0}' ORDER BY A.TANGGAL DESC", get_kode_stat)
        ElseIf get_stat_pusat() = 1 Then

            sql = "SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT  " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
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
                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND A.NODO LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)
                Case 1 ' tanggal

                    If Not IsDate(tsfind.Text.Trim) Then

                        MsgBox("Format tanggal yang anda masukkan salah", MsgBoxStyle.Information, "Informasi")
                        tsfind.Focus()
                        Exit Sub
                    End If

                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND A.TANGGAL='{0}' ORDER BY A.TANGGAL DESC", convert_date_to_eng(tsfind.Text.Trim.ToString))
                Case 2 ' no SPB

                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND A.NO_SPB LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)

                Case 3 ' NAMA TOKO

                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND C.NAMA_TOKO LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)

                Case 4 ' SALES

                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND D.NAMA LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)

                Case 5 ' SUPIR

                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND B.NAMA LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)
                Case 6 ' NOPOL
                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND A.NOPOL LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)
                Case 7  ' NO DO

                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND A.KD_PRE LIKE '%{0}%' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper)


            End Select

        ElseIf get_stat_pusat() = 0 Then

            Select Case cbfind.SelectedIndex
                Case 0 ' no bukti
                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND A.NODO LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)
                Case 1 ' tanggal

                    If Not IsDate(tsfind.Text.Trim) Then

                        MsgBox("Format tanggal yang anda masukkan salah", MsgBoxStyle.Information, "Informasi")
                        tsfind.Focus()
                        Exit Sub
                    End If

                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND A.TANGGAL='{0}' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", convert_date_to_eng(tsfind.Text.Trim.ToString), get_kode_stat)
                Case 2 ' no SPB

                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND A.NO_SPB LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 3 ' NAMA TOKO

                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND C.NAMA_TOKO LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 4 ' SALES

                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND D.NAMA LIKE '%{0}%' AND AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 5 ' SUPIR

                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND B.NAMA LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)
                Case 6 ' NOPOL
                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND A.NOPOL LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)

                Case 7 ' NODO
                    sql = String.Format("SELECT A.KD_PRE,A.NODO,A.TANGGAL,A.NO_SPB,C.NAMA_TOKO,C.ALAMAT as ALAMAT_TOKO,D.NAMA AS SALES,B.NAMA AS SUPIR,A.NOPOL,A.KETERANGAN,A.TOT_JML,A.TOT_HARGA,A.KD_TOKO,A.KD_SALES,A.KD_SUPIR,A.KD_PRE,F.TANGGAL || chr(13) || chr(10) || G.NAMA AS INFO_PRE,c.TIPE_HARGA,A.OKS_ANGKUT,A.TOT_OKS_ANGKUT,A.UANG_JLN,A.KD_PRC,A.DISC1,A.DISC2,A.TOT_AKH,A.TERBILANG,A.TGL_TEMPO,A.HARI_TEMPO,A.JENIS_POT " & _
                    "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_SUPIR B ON A.KD_SUPIR=B.KD_SUPIR " & _
                    "INNER JOIN ADMLSP.MS_TOKO C ON A.KD_TOKO=C.KD_TOKO " & _
                        "INNER JOIN ADMLSP.MS_SALES D ON A.KD_SALES=D.KD_SALES " & _
                            "INNER JOIN ADMLSP.MS_STAT E ON A.KD_STAT=E.KODE " & _
                            "LEFT JOIN ADMLSP.TR_PRE F ON A.KD_PRE=F.NO_BUKTI LEFT JOIN ADMLSP.MS_PRINCIPAL G ON F.KD_PRC=G.KD_PRC " & _
                                "WHERE ROWNUM <=1000 AND A.KD_PRE LIKE '%{0}%' AND A.KD_STAT='{1}' ORDER BY A.TANGGAL DESC", tsfind.Text.Trim.ToUpper, get_kode_stat)


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


            Dim sql As String = String.Format("delete from admlsp.TR_REAL_ORDER where NODO='{0}'", dv1(BindingContext(bs1).Position)("NODO").ToString)
            Dim sqlupdate As String = String.Format("update admlsp.TR_REAL_ORDER set user_edit='{0}',tgl_edit='{1}' where NODO='{2}'", userprog, convert_date_to_eng(Date.Now.ToString), dv1(BindingContext(bs1).Position)("NODO").ToString)
            Dim sqldelete As String = String.Format("delete from admlsp.TR_REAL_ORDER2 where NODO='{0}'", dv1(BindingContext(bs1).Position)("NODO").ToString)

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

                    ins_to_temp_user(cn, sqlupdate, dv1(BindingContext(bs1).Position)("NODO").ToString, "TR_REAL_ORDER", "UPDATE", "REALISASI ORDER")

                    cmd_DEt = New OracleCommand(sqldelete, cn)
                    cmd_DEt.ExecuteNonQuery()

                    ins_to_temp_user(cn, sqldelete, dv1(BindingContext(bs1).Position)("NODO").ToString, "TR_REAL_ORDER2", "DELETE", "REALISASI ORDER")

                    cmd = New OracleCommand(sql, cn)
                    cmd.ExecuteNonQuery()

                    ins_to_temp_user(cn, sql, dv1(BindingContext(bs1).Position)("NODO").ToString, "TR_REAL_ORDER", "DELETE", "REALISASI ORDER")

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

    Private Function cek_bayar() As Boolean

        Dim hasil As Boolean = True

        Dim cn As OracleConnection = Nothing
        Dim comd As OracleCommand = Nothing
        Dim dred As OracleDataReader = Nothing

        Try

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            Dim sql As String = String.Format("select a.TOT_AKH,(a.TOT_BAYAR + a.TOT_BAYAR_GIRO) as TOT_BAYAR from admlsp.tr_real_order a where a.NODO='{0}'", dv1(BindingContext(bs1).Position)("NODO").ToString)

            comd = New OracleCommand(sql, cn)
            dred = comd.ExecuteReader

            If dred.Read Then

                If IsNothing(dred(0).ToString) Or IsNothing(dred(1).ToString) Then
                    hasil = False
                ElseIf Not (IsNumeric(dred(0).ToString)) Or Not (IsNumeric(dred(1).ToString)) Then
                    hasil = False
                Else

                    If CDbl(dred(0).ToString) = CDbl(dred(1).ToString) Then
                        hasil = True
                    Else
                        hasil = False
                    End If

                End If

                dred.Close()

            Else

                dred.Close()
                hasil = False

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

        Return hasil
    End Function

    Private Sub tr_real_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        If cek_bayar() = True Then
            MsgBox("data sudah lunas, tidak dapat dihapus", MsgBoxStyle.Exclamation, "Informasi")
            Exit Sub
        End If

        hapus_data()
    End Sub

    Private Sub tsadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsadd.Click

        Using tr_dep2 As New tr_real2(True, dv1, 0, False) With {.StartPosition = FormStartPosition.CenterScreen}
            tr_dep2.ShowDialog(Me)
        End Using

    End Sub

    Private Sub tsedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsedit.Click

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        If cek_bayar() = True Then
            MsgBox("data sudah lunas, tidak dapat dirubah", MsgBoxStyle.Exclamation, "Informasi")
            Exit Sub
        End If

        Using tr_dep2 As New tr_real2(False, dv1, bs1.Position, False) With {.StartPosition = FormStartPosition.CenterScreen}
            tr_dep2.ShowDialog(Me)
        End Using

    End Sub

    Private Function cek_unlt_fakt() As Integer

        Dim cn As OracleConnection = Nothing
        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("select unl_print from admlsp.ms_user_header where nama='{0}'", userprog)

        Try

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            comd = New OracleCommand(sql, cn)
            dread = comd.ExecuteReader

            If dread.Read Then

                Dim hasil As Integer
                hasil = CInt(dread(0).ToString)

                dread.Close()

                Return hasil

            Else
                dread.Close()
                Return 0
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

    End Function

    Private Function cek_jml_tagih() As Integer

        Dim cn As OracleConnection = Nothing
        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("select tagih from admlsp.tr_real_order where nodo='{0}'", dv1(bs1.Position)("NODO").ToString)

        Try

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            comd = New OracleCommand(sql, cn)
            dread = comd.ExecuteReader

            If dread.Read Then

                Dim hasil As Integer
                hasil = CInt(dread(0).ToString)

                dread.Close()

                Return hasil

            Else
                dread.Close()
                Return 0
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

    End Function

    Private Function cek_jml_byr() As Integer

        Dim cn As OracleConnection = Nothing
        Dim comd As OracleCommand = Nothing
        Dim dread As OracleDataReader

        Dim sql As String = String.Format("select tot_bayar + tot_bayar_giro as jml_bayar,tot_akh from admlsp.tr_real_order where nodo='{0}'", dv1(bs1.Position)("NODO").ToString)

        Try

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            comd = New OracleCommand(sql, cn)
            dread = comd.ExecuteReader

            If dread.Read Then

                Dim jml_bayar As Double
                Dim tagih As Double

                jml_bayar = CInt(dread(0).ToString)
                tagih = CInt(dread(1).ToString)

                dread.Close()

                If jml_bayar < tagih Then
                    Return 1
                Else
                    Return 0
                End If

            Else
                dread.Close()
                Return 0
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

    End Function

    Private Sub trinv1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trinv1.Click

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        If cek_jml_tagih() >= 1 Then

            If cek_unlt_fakt() = 0 Then
                MsgBox("Invoice tidak dapat dicetak lebih dari 1x...", MsgBoxStyle.Exclamation, "Informasi")
                Exit Sub
            End If
        Else

            If cek_jml_byr() = 0 Then

                If cek_unlt_fakt() = 1 Then
                Else
                    MsgBox("Data sudah lunas tidak dapat cetak Invoice", MsgBoxStyle.Exclamation, "Informasi")
                    Exit Sub
                End If

            End If

        End If

        Dim nobukti As New ArrayList
        nobukti.Insert(0, String.Format("{0}", dv1(bs1.Position)("NODO")))

        Dim finv As New pr_inv(nobukti, False) With {.WindowState = FormWindowState.Maximized}
        finv.Show()

    End Sub

    Private Sub trinv2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trinv2.Click

        Dim finv As New fsl_bbr_inv() With {.StartPosition = FormStartPosition.CenterParent}
        finv.Show()

    End Sub

    Private Sub tsview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsview.Click

        If dv1.Count <= 0 Then
            Exit Sub
        End If

        Using tr_dep2 As New tr_real2(False, dv1, bs1.Position, True) With {.StartPosition = FormStartPosition.CenterScreen}
            tr_dep2.ShowDialog(Me)
        End Using

    End Sub
End Class