Imports DevExpress.XtraSplashScreen
Imports System.Data
Imports System.Globalization
Imports Oracle.DataAccess.Client
Imports lsp.lspclass

Module modul_my

#Region "Deklarasi"

    Public userprog, pwd As String
    Public dtmenu As DataTable
    Public dtstat_prog As DataTable
    Public rem_kend As Integer = 0
    Public rem_giro As Integer = 0
    Public rem_piutang As Integer = 0
#End Region
    Public limit_not As Integer = 0
    Public limit_vl As Double
    Public rlimit_not As Integer = 0
    Public rlimit_vl As Double

    Public Sub ceklimit_toko(ByVal kdtoko As String, ByVal cn As OracleConnection)

        'Dim cn As OracleConnection = Nothing

        'Try

        '    cn = New OracleConnection
        '    cn = classmy.open_conn_utama

        Dim SQL As String = String.Format("SELECT A.TOT_AKH,B.LIMIT_NOTA,B.LIMIT_VAL FROM ADMLSP.TR_REAL_ORDER A inner join ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO WHERE A.KD_TOKO='{0}' AND A.TOT_AKH > (A.TOT_BAYAR + A.TOT_BAYAR_GIRO)", kdtoko)

        Dim comd As OracleCommand = New OracleCommand(SQL, cn)
        Dim dread As OracleDataReader = comd.ExecuteReader

        Dim i As Integer = 0
        Dim jmlpiut As Double = 0

        limit_not = 0
        limit_vl = 0

        Dim limit_n As String = 0
        Dim limit_v As String = 0

        If dread.HasRows Then
            While dread.Read

                Dim jmld As String = dread(0).ToString
                limit_n = dread(1).ToString
                limit_v = dread(2).ToString

                If limit_n.Equals("") Then
                    limit_n = 0
                End If

                If limit_v.Equals("") Then
                    limit_v = 0
                End If

                If jmld.Equals("") Then
                    jmld = 0
                End If

                jmlpiut = jmlpiut + Double.Parse(jmld)

                i = i + 1

            End While
        End If

        dread.Close()

        limit_not = Integer.Parse(limit_n)
        limit_vl = Double.Parse(limit_v)

        rlimit_not = i
        rlimit_vl = jmlpiut

        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        'Finally


        '    If Not cn Is Nothing Then
        '        If cn.State = ConnectionState.Open Then
        '            cn.Close()
        '        End If
        '    End If
        'End Try

    End Sub

    Public Function get_kode_stat() As String

        Dim kode As String = dtstat_prog.Rows(0)("KODE").ToString

        Return kode

    End Function

    Public Function get_stat_pusat() As Integer

        Dim hasil As Integer

        If IsNothing(dtstat_prog) Then
            hasil = -1
        End If

        If dtstat_prog.Rows(0)("STATUS").ToString.ToUpper = "CABANG" Then
            hasil = 0
        Else
            hasil = 1
        End If

        Return hasil

    End Function

    Public Function convert_date_to_eng(ByVal valdate As String) As String

        If valdate = "" Then
            Return ""
        End If

        valdate = CType(valdate, Date).ToString("dd-MMM-yy", CultureInfo.CreateSpecificCulture("en-US"))

        Return valdate

    End Function

    Public Function convert_datetime_to_eng(ByVal valdate As String) As String

        If valdate = "" Then
            Return ""
        End If

        valdate = CType(valdate, DateTime).ToString("dd-MMM-yy HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"))

        Return valdate

    End Function

    Public Function convert_date_to_ind(ByVal valdate As String) As String

        If valdate = "" Then
            Return ""
        End If

        valdate = CType(valdate, Date).ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("id-ID"))

        Return valdate

    End Function

    Public Function convert_date_Khusus(ByVal valdate As String) As String

        If valdate = "" Then
            Return ""
        End If

        valdate = CType(valdate, Date).ToString("dd/MM/yy", CultureInfo.CreateSpecificCulture("en-US"))

        Return valdate

    End Function


    Public Function convert_decimal_toEng(ByVal nilai As String) As String

        Dim hasil As Double = 0
        Dim style As NumberStyles
        Dim ci As CultureInfo

        style = NumberStyles.AllowDecimalPoint
        ci = CultureInfo.CreateSpecificCulture("fr-FR")

        If Double.TryParse(nilai, style, ci, hasil) Then
            Return hasil
        Else
            Return 0
        End If

    End Function

    Public Sub open_wait()
        SplashScreenManager.ShowForm(utama2, GetType(waitf), True, True, False)
    End Sub

    Public Sub close_wait()
        SplashScreenManager.CloseForm(False)
    End Sub

    Public Sub ins_to_temp_user(ByVal cn As OracleConnection, _
                                              ByVal jscript As String, _
                                              ByVal jno_kunci As String, _
                                              ByVal jtabel As String, _
                                              ByVal jtrans As String, _
                                              ByVal jtrans_apl As String)

        Dim con As OracleConnection = Nothing
        Dim comd As OracleCommand = Nothing


        'Try

        con = cn

        'Dim sql As String = String.Format("insert into admlsp.tm_user (juser,jtabel,tanggal,jtrans,script,key_num,jtrans_apl) values ('{0}','{1}','{2}','{3}',''{4}'','{5}','{6}')", _
        '                                  userprog, jtabel, convert_date_to_eng(Date.Now), jtrans, jscript, jno_kunci, jtrans_apl)

        Dim jamtgl As String = convert_datetime_to_eng(DateTime.Now)


        comd = New OracleCommand With {.CommandType = CommandType.StoredProcedure, .CommandText = "admlsp.proc_temp_user", .Connection = con}

        comd.Parameters.Add("juser_p", OracleDbType.Varchar2).Value = userprog
        comd.Parameters.Add("jtabel_p", OracleDbType.Varchar2).Value = jtabel
        comd.Parameters.Add("jtanggal_p", OracleDbType.Varchar2).Value = jamtgl
        comd.Parameters.Add("jtrans_p", OracleDbType.Varchar2).Value = jtrans
        comd.Parameters.Add("jscript_p", OracleDbType.Varchar2).Value = jscript
        comd.Parameters.Add("jkey_num_p", OracleDbType.Varchar2).Value = jno_kunci
        comd.Parameters.Add("jtrans_apl_p", OracleDbType.Varchar2).Value = jtrans_apl

        comd.ExecuteNonQuery()

        'Catch ex As OracleException
        '    '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Informasi")
        'End Try

    End Sub



End Module
