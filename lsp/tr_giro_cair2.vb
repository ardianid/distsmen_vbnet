Imports System
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class tr_giro_cair2

    Private dv1 As DataView
    Private dv As DataView
    Private jmldet As Integer = 0

    Sub New(ByVal dva As DataView)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call
        tuseradd.EditValue = userprog
        ttgl_add.EditValue = convert_date_to_ind(Date.Now.Date.ToString)

        dv = dva

    End Sub

    Private Sub isi_grid()

        Dim ds As DataSet
        Dim dvmanager As Data.DataViewManager
        Dim cn As OracleConnection = Nothing


        Dim sql As String = ""

        If get_stat_pusat() = 1 Then
            sql = String.Format("SELECT B.KD_TOKO,B.NAMA_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.NILAI,0 AS PROSES FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO= B.KD_TOKO WHERE B.AKTIF=1 AND A.STATUS='PENDING' AND A.TGL_TEMPO <='{0}' ORDER BY A.TGL_TEMPO ASC", convert_date_to_eng(ttgl_add.EditValue.ToString))
        ElseIf get_stat_pusat() = 0 Then
            sql = String.Format("SELECT B.KD_TOKO,B.NAMA_TOKO,A.NO_GIRO,A.TGL_TEMPO,A.NILAI,0 AS PROSES FROM ADMLSP.MS_GIRO A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO= B.KD_TOKO WHERE B.AKTIF=1 AND A.STATUS='PENDING' AND A.KD_STAT='{0}' AND A.TGL_TEMPO <='{1}' ORDER BY A.TGL_TEMPO ASC", get_kode_stat, convert_date_to_eng(ttgl_add.EditValue.ToString))
        End If


        grid1.DataSource = Nothing
        Try

            dv1 = Nothing

            cn = New OracleConnection
            cn = classmy.open_conn_utama

            ds = New DataSet()
            ds = classmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            grid1.DataSource = dv1

        Catch ex As OracleException
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally


            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

    End Sub

    Private Sub insert()

        Dim tgluser As String
        If ttgl_add.Text = "" Then
            tgluser = ""
        Else
            tgluser = convert_date_to_eng(ttgl_add.EditValue.ToString)
        End If

        Dim sql As String = ""
        Dim sql_search As String = ""


        Dim cmd As OracleCommand
        Dim cn As OracleConnection = Nothing
        Dim dre As OracleDataReader = Nothing
        Dim cmdsearch As OracleCommand

        Try
            open_wait()
            cn = classmy.open_conn_utama

            tbukti.Text = classmy.GET_KODE_GIROCAIR(get_kode_stat, cn, tgluser)

            sql_search = String.Format("select no_bukti from admlsp.TR_PENCAIRAN_GIRO where no_bukti='{0}'", tbukti.Text.Trim)
            cmdsearch = New OracleCommand(sql_search, cn)
            dre = cmdsearch.ExecuteReader

            If dre.Read Then

                dre.Close()
                tbukti.Text = classmy.GET_KODE_GIROCAIR(get_kode_stat, cn, tgluser)
                'MsgBox("Kode sudah ada", MsgBoxStyle.Information, "Informasi")
                'tbukti.Focus()
                'Exit Sub
            Else
                dre.Close()
            End If


            Dim sqltrans As OracleTransaction = cn.BeginTransaction

            sql = String.Format("insert into admlsp.TR_PENCAIRAN_GIRO (no_bukti,tanggal,keterangan,user_add,kd_stat) values" & _
                                          "('{0}','{1}','{2}','{3}','{4}')", tbukti.Text.Trim.ToUpper, tgluser, tket.Text.Trim, tuseradd.Text.Trim, get_kode_stat)
            cmd = New OracleCommand(sql, cn)
            cmd.ExecuteNonQuery()

            ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_PENCAIRAN_GIRO", "INSERT", "PENCAIRAN GIRO")

            manipulate2(cn)

            If jmldet = 0 Then

                sqltrans.Rollback()

                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If

                MsgBox("Pilih dulu giro - giro yang telah cair", MsgBoxStyle.Information, "Informasi")

                Exit Try

            End If

            sqltrans.Commit()

            insert_view()

            close_wait()

            MsgBox("Data telah disimpan & giro telah dicairkan ", MsgBoxStyle.Information, "Informasi")

            Me.Close()

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

    Private Sub manipulate2(ByVal cn As OracleConnection)

        Dim cmd As OracleCommand
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim cmd2 As OracleCommand
        Dim dread As OracleDataReader

        Dim sqlupgiro As String = ""
        Dim cmdupgiro As OracleCommand

        Dim nobukti As String = ""

        jmldet = 0

        If Not IsNothing(dv1) Then

            If dv1.Count > 0 Then

                Dim i As Integer = 0
                For i = 0 To dv1.Count - 1

                    If dv1(i)("PROSES").ToString = 1 Then


                        sql2 = String.Format("select no_bukti,no_realisasi from admlsp.TR_TKO_BYAR_DETAIL where no_giro='{0}'", dv1(i)("NO_GIRO").ToString)
                        cmd2 = New OracleCommand(sql2, cn)
                        dread = cmd2.ExecuteReader

                        If dread.Read Then

                            nobukti = dread(0).ToString
                            dread.Close()

                            sql = String.Format("update admlsp.TR_TKO_BYAR_DETAIL set giro_cair=1 where no_bukti='{0}'", nobukti)

                            cmd = New OracleCommand(sql, cn)
                            cmd.ExecuteNonQuery()

                            ins_to_temp_user(cn, sql, nobukti, "TR_TKO_BYAR_DETAIL", "UPDATE", "PENCAIRAN GIRO")

                        End If

                        sql = String.Format("insert into admlsp.TR_PENCAIRAN_GIRO2 (no_bukti,no_giro) values('{0}','{1}')", tbukti.Text.Trim, dv1(i)("NO_GIRO").ToString)

                        cmd = New OracleCommand(sql, cn)
                        cmd.ExecuteNonQuery()

                        ins_to_temp_user(cn, sql, tbukti.Text.Trim, "TR_PENCAIRAN_GIRO2", "INSERT", "PENCAIRAN GIRO")

                        sqlupgiro = String.Format("update admlsp.ms_giro set status='CAIR' where no_giro='{0}'", dv1(i)("NO_GIRO").ToString)

                        cmdupgiro = New OracleCommand(sqlupgiro, cn)
                        cmdupgiro.ExecuteNonQuery()

                        ins_to_temp_user(cn, sqlupgiro, dv1(i)("NO_GIRO").ToString, "MS_GIRO", "UPDATE", "PENCAIRAN GIRO")

                        jmldet += 1

                    End If

                Next

            End If

        End If


    End Sub

    Private Sub insert_view()

        Dim orow As DataRow = dv.Table.NewRow

        orow("NO_BUKTI") = tbukti.Text

        If ttgl_add.Text = "" Then
            orow("TANGGAL") = DBNull.Value
        Else
            orow("TANGGAL") = ttgl_add.EditValue.ToString
        End If

        orow("USER_ADD") = tuseradd.Text.Trim
        orow("KETERANGAN") = tket.Text.Trim
        dv.Table.Rows.InsertAt(orow, 0)

    End Sub

    Private Sub tbukti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbukti.KeyDown
        If e.KeyCode = 13 Then
            tket.Focus()
        End If
    End Sub

    Private Sub tr_giro_cair2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        tket.Focus()
    End Sub

    Private Sub tr_giro_cair2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tbukti.Text = "<< New >>"
        isi_grid()
    End Sub

    Private Sub btsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsimpan.Click

        If tbukti.Text = "" Then
            MsgBox("No bukti tidak boleh kosong", MsgBoxStyle.Information, "Informasi")

            tbukti.Focus()
            Exit Sub
        End If

        If MsgBox("YAKIN GIRO - GIRO YANG AKAN DICAIRKAN SUDAH BENAR..... ??????", MsgBoxStyle.Question, vbYesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        insert()

    End Sub
End Class