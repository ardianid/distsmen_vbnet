Imports System
Imports System.Data
Imports lsp.lspclass
Imports System.Windows.Forms
Imports Oracle.DataAccess.Client

Public Class tr_hist_user

    Private sql_track As String = String.Empty

    Private Sub open_perUser()

        Dim dvmanager As Data.DataViewManager
        Dim dv1 As Data.DataView

        Dim ds As DataSet

        Dim cn As OracleConnection = Nothing
        Dim sql As String = ""
        sql = String.Format("SELECT DISTINCT rownum,A.TANGGAL,a.JUSER,a.JTRANS,a.JTRANS_APL,a.KEY_NUM FROM ADMLSP.TM_USER A " & _
                            "WHERE to_date(a.TANGGAL,'DD-Mon-YY') >='{0}' AND to_date(a.TANGGAL,'DD-Mon-YY') <='{1}' AND a.JUSER='{2}'", convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue), tuser.Text.Trim)

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

            grid1.DataSource = dv1

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

    Private Sub open_track()

        grid2.DataSource = Nothing

        open_wait()

        track_tmp_user()

        If sql_track = "" Then
            close_wait()
            Exit Sub
        End If

        Dim dvmanager As Data.DataViewManager
        Dim dv1 As Data.DataView

        Dim ds As DataSet

        Dim cn As OracleConnection = Nothing

        Try

            dv1 = Nothing

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql_track, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            grid2.DataSource = dv1

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

    Private Sub track_tmp_user()

        Dim cn As OracleConnection = Nothing
        'Dim comd As OracleCommand = Nothing
        Dim ds As DataSet = Nothing
        Dim dt As DataTable = Nothing
        'Dim dread As OracleDataReader = Nothing

        Try

            Dim sql As String = String.Format("select a.jtabel,a.jtrans from admlsp.tm_user a where a.key_num='{0}' and not (a.JTABEL LIKE '%2%' OR a.JTABEL LIKE '%DETAIL%')", tkode.Text.Trim)

            cn = New OracleConnection()
            cn = classmy.open_conn_utama

            ds = classmy.GetDataSet(sql, cn)
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then

                Dim i As Integer = 0
                For i = 0 To dt.Rows.Count - 1

                    If i = 0 Then
                        sql_track = _rtrack_sql(dt.Rows(i)(0).ToString, dt.Rows(i)(1).ToString)
                    Else
                        sql_track = String.Format("{0} union {1}", sql_track, _rtrack_sql(dt.Rows(i)(0).ToString, dt.Rows(i)(1).ToString))
                    End If

                Next

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If


     
            Else
                close_wait()
                sql_track = ""
            End If


        Catch ex As OracleException
            close_wait()
            sql_track = ""
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally


            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Function _rtrack_sql(ByVal tabel As String, ByVal jtrans As String) As String

        Dim sqltrack2 As String = String.Empty

        If jtrans.ToUpper = "DELETE" Then
            sqltrack2 = String.Format("SELECT 'DIHAPUS ~>' as STATDATA,A.jtrans_apl AS TRANS,A.TANGGAL,A.jtrans AS STAT,'' as USERADD,TO_DATE('') as TGL_ADD,A.juser as USER_EDIT,A.TANGGAL as TGL_EDIT FROM admlsp.tm_user A WHERE A.key_num='{0}' and A.JTRANS='DELETE'", tkode.Text.Trim)
            Return sqltrack2
            Exit Function
        End If


        Select Case tabel.ToUpper

            Case "MS_AKUN"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'AKUN' AS TRANS,TO_DATE('') AS TANGGAL,'' AS STAT,A.USER_ADD,A.TGL_ADD,A.USER_EDIT,A.TGL_EDIT FROM MS_AKUN A WHERE A.KODE='{0}'", tkode.Text.Trim)
            Case "MS_BARANG"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'MASTER BARANG' AS TRANS,TO_DATE('') AS TANGGAL,'' AS STAT,ms_barang.user_add, ms_barang.tgl_add, ms_barang.user_edit,ms_barang.tgl_edit FROM admlsp.ms_barang WHERE ms_barang.KODE='{0}'", tkode.Text.Trim)
            Case "MS_GIRO"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'DATA GIRO' AS TRANS,TO_DATE('') AS TANGGAL,ms_giro.user_add, ms_giro.tgl_add, ms_giro.user_edit, ms_giro.tgl_edit,ms_stat.nama FROM ADMLSP.ms_giro, ADMLSP.ms_stat WHERE ((ms_giro.kd_stat = ms_stat.kode) AND ((ms_giro.no_giro = '{0}')))", tkode.Text.Trim)
            Case "MS_KAB"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'KABUPATEN' AS TRANS,TO_DATE('') AS TANGGAL,'' AS STAT,ms_kab.user_add, ms_kab.tgl_add, ms_kab.user_edit, ms_kab.tgl_edit FROM admlsp.ms_kab WHERE ((ms_kab.kode = '{0}'))", tkode.Text.Trim)
            Case "MS_KAS"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'KAS' AS TRANS,TO_DATE('') AS TANGGAL,ms_kas.user_add, ms_kas.tgl_add, ms_kas.user_edit, ms_kas.tgl_edit,ms_stat.nama AS stat FROM ADMLSP.ms_kas, ADMLSP.ms_stat WHERE ((ms_kas.kd_stat = ms_stat.kode) AND ((ms_kas.kode = '{0}')))", tkode.Text.Trim)
            Case "MS_KEC"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'KECAMATAN' AS TRANS,TO_DATE('') AS TANGGAL,'' AS STAT,ms_kec.user_add, ms_kec.tgl_add, ms_kec.user_edit, ms_kec.tgl_edit FROM ADMLSP.ms_kec WHERE ((ms_kec.kode = '{0}'))", tkode.Text.Trim)
            Case "MS_KENDARAAN"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'KENDARAAN' AS TRANS,TO_DATE('') AS TANGGAL,'' AS STAT,ms_kendaraan.user_add, ms_kendaraan.tgl_add, ms_kendaraan.user_edit,ms_kendaraan.tgl_edit FROM ADMLSP.ms_kendaraan WHERE ((ms_kendaraan.nopol = '{0}'))", tkode.Text.Trim)
            Case "MS_KSO"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'MASTER KSO' AS TRANS,TO_DATE('') AS TANGGAL,ms_kso.user_add, ms_kso.tgl_add, ms_kso.user_edit, ms_kso.tgl_edit,ms_stat.nama AS STAT FROM ADMLSP.ms_kso, ADMLSP.ms_stat WHERE ((ms_kso.kd_stat = ms_stat.kode) AND ((ms_kso.kode = '{0}')))", tkode.Text.Trim)
            Case "MS_PRINCIPAL"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'PRINCIPAL' AS TRANS,TO_DATE('') AS TANGGAL,'' AS STAT,ms_principal.user_add, ms_principal.tgl_add, ms_principal.user_edit,ms_principal.tgl_edit FROM ADMLSP.ms_principal WHERE ((ms_principal.kd_prc = '{0}'))", tkode.Text.Trim)
            Case "MS_PROP"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'PROPINSI' AS TRANS,TO_DATE('') AS TANGGAL,'' AS STAT,ms_prop.user_add, ms_prop.tgl_add, ms_prop.user_edit, ms_prop.tgl_edit FROM ADMLSP.ms_prop WHERE ((ms_prop.kode = '{0}'))", tkode.Text.Trim)
            Case "MS_SALES"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'SALES' AS TRANS,TO_DATE('') AS TANGGAL,ms_stat.nama AS STAT, ms_sales.user_add, ms_sales.tgl_add, ms_sales.user_edit,ms_sales.tgl_edit FROM ADMLSP.ms_sales, ADMLSP.ms_stat WHERE ((ms_sales.kd_stat = ms_stat.kode) AND ((ms_sales.kd_sales = '{0}')))", tkode.Text.Trim)
            Case "MS_SPAREPART"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'SPAREPART' AS TRANS,TO_DATE('') AS TANGGAL,'' AS STAT,ms_sparepart.user_add, ms_sparepart.tgl_add, ms_sparepart.user_edit,ms_sparepart.tgl_edit FROM ADMLSP.ms_sparepart WHERE ((ms_sparepart.kode = '{0}'))", tkode.Text.Trim)
            Case "MS_SUPIR"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'SUPIR' AS TRANS,TO_DATE('') AS TANGGAL,ms_stat.nama AS STAT, ms_supir.user_add, ms_supir.tgl_add, ms_supir.user_edit,ms_supir.tgl_edit FROM admlsp.ms_supir, admlsp.ms_stat WHERE ((ms_supir.kd_stat = ms_stat.kode) AND ((ms_supir.kd_supir = '{0}')))", tkode.Text.Trim)
            Case "MS_TOKO"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'TOKO' AS TRANS,TO_DATE('') AS TANGGAL,ms_stat.nama as stat, ms_toko.user_add, ms_toko.tgl_add, ms_toko.user_edit,ms_toko.tgl_edit FROM admlsp.ms_stat, admlsp.ms_toko WHERE ((ms_toko.kode_stat = ms_stat.kode) AND ((ms_toko.kd_toko = '{0}')))", tkode.Text.Trim)
            Case "MS_USER_HEADER"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'USER' AS TRANS,TO_DATE('') AS TANGGAL,'' AS STAT,ms_user_header.user_add, ms_user_header.tgl_add,ms_user_header.user_edit, ms_user_header.tgl_edit FROM admlsp.ms_user_header WHERE ((ms_user_header.nama = '{0}'))", tkode.Text.Trim)
            Case "TR_ANGKUTAN"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'ANGKUTAN LAIN' AS TRANS,tr_angkutan.TANGGAL,ms_stat.nama as stat, tr_angkutan.user_add, tr_angkutan.tgl_add,tr_angkutan.user_edit, tr_angkutan.tgl_edit FROM admlsp.tr_angkutan, admlsp.ms_stat WHERE ((tr_angkutan.kd_stat = ms_stat.kode) AND ((tr_angkutan.no_bukti = '{0}')))", tkode.Text.Trim)
            Case "TR_DEP_PRINCIPAL"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'DEPOSIT PRINCIPAL' AS TRANS,tr_dep_principal.TANGGAL,ms_stat.nama as stat, tr_dep_principal.user_add, tr_dep_principal.tgl_add,tr_dep_principal.user_edit, tr_dep_principal.tgl_edit FROM admlsp.ms_stat, admlsp.tr_dep_principal WHERE ((tr_dep_principal.kd_stat = ms_stat.kode) AND ((tr_dep_principal.no_bukti = '{0}')))", tkode.Text.Trim)
            Case "TR_DEP_TOKO"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'DEPOSIT TOKO' AS TRANS,tr_dep_toko.tanggal,ms_stat.nama as stat, tr_dep_toko.user_add, tr_dep_toko.tgl_add,tr_dep_toko.user_edit, tr_dep_toko.tgl_edit FROM admlsp.ms_stat, admlsp.tr_dep_toko WHERE ((tr_dep_toko.kd_stat = ms_stat.kode) AND ((tr_dep_toko.no_bukti = '{0}')))", tkode.Text.Trim)
            Case "TR_INV"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'INVENTORY SALES' AS TRANS,tr_inv.tanggal,ms_stat.nama as stat, tr_inv.user_add, tr_inv.tgl_add,tr_inv.user_edit, tr_inv.tgl_edit FROM admlsp.ms_stat, admlsp.tr_inv WHERE ((tr_inv.kd_stat = ms_stat.kode) AND ((tr_inv.no_bukti = '{0}')))", tkode.Text.Trim)
            Case "TR_KAS_IN"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'KAS MASUK' AS TRANS,tr_kas_in.tanggal,ms_stat.nama as stat, tr_kas_in.user_add, tr_kas_in.tgl_add,tr_kas_in.user_edit, tr_kas_in.tgl_edit FROM admlsp.ms_stat, admlsp.tr_kas_in WHERE ((tr_kas_in.kd_stat = ms_stat.kode) AND ((tr_kas_in.no_bukti = '{0}')))", tkode.Text.Trim)
            Case "TR_KAS_OUT"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'KAS KELUAR' AS TRANS,tr_kas_out.tanggal,ms_stat.nama as stat, tr_kas_out.user_add,tr_kas_out.tgl_add, tr_kas_out.user_edit, tr_kas_out.tgl_edit FROM admlsp.ms_stat, admlsp.tr_kas_out WHERE ((tr_kas_out.kd_stat = ms_stat.kode) AND ((tr_kas_out.no_bukti = '{0}')))", tkode.Text.Trim)
            Case "TR_KASBON"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'KASBON SUPIR' AS TRANS,tr_kasbon.tanggal,ms_stat.nama as stat, tr_kasbon.user_add, tr_kasbon.tgl_add,tr_kasbon.user_edit, tr_kasbon.tgl_edit FROM admlsp.ms_stat, admlsp.tr_kasbon WHERE ((tr_kasbon.kd_stat = ms_stat.kode) AND ((tr_kasbon.no_bukti = '{0}')))", tkode.Text.Trim)
            Case "TR_PENCAIRAN_GIRO"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'PENCAIRAN GIRO' AS TRANS,tr_pencairan_giro.tanggal,ms_stat.nama as stat, tr_pencairan_giro.user_add,'' AS tgl_add,'' AS user_edit,'' AS tgl_edit FROM admlsp.ms_stat, admlsp.tr_pencairan_giro WHERE ((tr_pencairan_giro.kd_stat = ms_stat.kode) AND ((tr_pencairan_giro.no_bukti = '{0}')))", tkode.Text.Trim)
            Case "TR_PRE"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'PRE RELEASE' AS TRANS,tr_pre.tanggal,ms_stat.nama as stat, tr_pre.user_add, tr_pre.tgl_add,tr_pre.user_edit, tr_pre.tgl_edit FROM admlsp.ms_stat, admlsp.tr_pre WHERE ((tr_pre.kd_stat = ms_stat.kode) AND ((tr_pre.no_bukti = '{0}')))", tkode.Text.Trim)
            Case "TR_REAL_ORDER"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'REALISASI ORDER' AS TRANS,tr_real_order.tanggal,ms_stat.nama as stat,tr_real_order.user_add,tr_real_order.tgl_add, tr_real_order.user_edit, tr_real_order.tgl_edit FROM admlsp.ms_stat, admlsp.tr_real_order WHERE ((tr_real_order.kd_stat = ms_stat.kode) AND ((tr_real_order.nodo = '{0}')))", tkode.Text.Trim)
            Case "TR_SPAREPART"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'SPAREPART MASUK' AS TRANS,tr_sparepart.tgl_bukti as tanggal,ms_stat.nama as stat, tr_sparepart.user_add,tr_sparepart.tgl_add, tr_sparepart.user_edit, tr_sparepart.tgl_edit FROM admlsp.ms_stat, admlsp.tr_sparepart WHERE ((tr_sparepart.kd_stat = ms_stat.kode) AND ((tr_sparepart.no_bukti = '{0}')))", tkode.Text.Trim)
            Case "TR_SPAREPART_OUT"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'PERGANTIAN SPAREPART' AS TRANS,ms_stat.nama as stat, tr_sparepart_out.tanggal, tr_sparepart_out.user_add,tr_sparepart_out.tgl_add, tr_sparepart_out.user_edit,tr_sparepart_out.tgl_edit FROM admlsp.ms_stat, admlsp.tr_sparepart_out WHERE ((tr_sparepart_out.kd_stat = ms_stat.kode) AND ((tr_sparepart_out.no_bukti = '{0}')))", tkode.Text.Trim)
            Case "TR_TKO_BYAR_HEADER"
                sqltrack2 = String.Format("SELECT 'DATA VALID ~>' as STATDATA,'PEMBAYARAN TOKO' AS TRANS, ms_stat.nama as stat,tr_tko_byar_header.tanggal, tr_tko_byar_header.user_add,tr_tko_byar_header.tgl_add, tr_tko_byar_header.user_edit,tr_tko_byar_header.tgl_edit FROM admlsp.ms_stat, admlsp.tr_tko_byar_header WHERE ((tr_tko_byar_header.kd_stat = ms_stat.kode) AND ((tr_tko_byar_header.no_bukti = '{0}')))", tkode.Text.Trim)

        End Select


        Return sqltrack2

    End Function

    Private Sub tr_hist_user_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ttgl.EditValue = Date.Now
        ttgl2.EditValue = Date.Now

    End Sub

    Private Sub btload1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btload1.Click
        If tuser.Text.Trim.Length = 0 Then
            MsgBox("User harus diisi...", MsgBoxStyle.Information, "Informasi")
            tuser.Focus()
            Exit Sub
        End If

        open_perUser()

    End Sub

    Private Sub btload2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btload2.Click

        If tkode.Text.Trim.Length = 0 Then
            MsgBox("Key number harus diisi...", MsgBoxStyle.Information, "Informasi")
            tkode.Focus()
            Exit Sub
        End If

        open_track()

    End Sub

End Class