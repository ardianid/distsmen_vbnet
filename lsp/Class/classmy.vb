Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports System.Data
Imports Oracle.DataAccess.Client
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Namespace lspclass

    Public Class classmy

#Region "Deklarasi"

        Const myconnectionstring As String = "Data Source=(DESCRIPTION=" _
           + "(ADDRESS=(PROTOCOL=TCP)(HOST=dian)(PORT=1521))" _
           + "(CONNECT_DATA=(SERVICE_NAME=LSP)));" _
           + "User Id=admlsp;Password=admlsp*123;"


        Private hash1 As Byte()
#End Region

        

        Public Shared Function GetDataSet(ByVal SQL As String, ByVal cn As OracleConnection) As DataSet

            Dim adapter As New OracleDataAdapter(SQL, cn)
            Dim myData As New DataSet
            adapter.Fill(myData)

            adapter.Dispose()

            Return myData
        End Function

        Public Shared Function GetDataSet(ByVal Cmd As OracleCommand, ByVal cn As OracleConnection) As DataSet

            Dim adapter As New OracleDataAdapter(Cmd)
            Dim myData As New DataSet
            adapter.Fill(myData)

            adapter.Dispose()

            Return myData
        End Function

        Public Shared Function open_conn() As OracleConnection

            Dim cn = New OracleConnection

            Try

                cn.ConnectionString = myconnectionstring
                cn.Open()

            Catch ex As OleDb.OleDbException
                Throw New Exception(ex.ToString)
            End Try

            Return cn

        End Function

        Public Shared Function open_conn_utama() As OracleConnection

            Dim cn2 = New OracleConnection
            Dim connect As String = String.Format("Data Source=(DESCRIPTION=" _
           + "(ADDRESS=(PROTOCOL=TCP)(HOST=dian)(PORT=1521))" _
           + "(CONNECT_DATA=(SERVICE_NAME=LSP)));" _
           + "User Id={0};Password={1};", userprog, pwd)

            Try
                cn2.ConnectionString = connect
                cn2.Open()

            Catch ex As OleDb.OleDbException
                Throw New Exception(ex.ToString)
            End Try

            Return cn2

        End Function

        Public Shared Sub open_CnReport(ByVal NamaRpt As Object)

            Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo

            myConnectionInfo.ServerName = "LSP-CON"

            myConnectionInfo.DatabaseName = "LSP"

            myConnectionInfo.UserID = "admlsp"

            myConnectionInfo.Password = "admlsp*123"


            Dim myTables As Tables = NamaRpt.Database.Tables

            Dim myTable As CrystalDecisions.CrystalReports.Engine.Table

            For Each myTable In myTables

                Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo

                myTableLogonInfo.ConnectionInfo = myConnectionInfo

                myTable.ApplyLogOnInfo(myTableLogonInfo)

            Next

        End Sub

        Public Shared Function insert_to_temp_user(ByVal cn As OracleConnection, _
                                              ByVal jscript As String, _
                                              ByVal jno_kunci As String, _
                                              ByVal jtabel As String, _
                                              ByVal jtrans As String, _
                                              ByVal jtrans_apl As String) As Boolean

            Dim con As OracleConnection = Nothing
            Dim comd As OracleCommand = Nothing


            Try

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

                Return True

            Catch ex As OracleException
                Return False
            End Try

        End Function

        'Function generate_password(ByVal strSource As String) As String
        '    ' Create an Encoding object so that you can use the convenient GetBytes 
        '    ' method to obtain byte arrays.
        '    Dim uEncode As New UnicodeEncoding()
        '    ' Create a byte array from the source text passed as an argument.
        '    Dim bytProducts() As Byte = uEncode.GetBytes(strSource)

        '    ' The code is almost identical for all three hash types.
        '    'If optMD5.Checked Then
        '    Dim md5 As New MD5CryptoServiceProvider()
        '    hash1 = md5.ComputeHash(bytProducts)
        '    'ElseIf optSHA1.Checked Then
        '    'Dim sha1 As New SHA1CryptoServiceProvider()
        '    'hash = sha1.ComputeHash(bytProducts)
        '    'Else
        '    'Dim sha384 As New SHA384Managed()
        '    'hash = sha384.ComputeHash(bytProducts)
        '    'End If

        '    ' Base64 is a method of encoding binary data as ASCII text.
        '    Return Convert.ToBase64String(hash1)
        'End Function

        Public Shared Function GET_KODE_RO(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NODO,11,5))) AS NO from admlsp.tr_real_order where KD_STAT='{0}' and extract(year from tanggal)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("RO.{0}/{1}/{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_KASBON(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String, ByVal jenis As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_KASBON where KD_STAT='{0}' AND JENIS='{1}' AND extract(year from tanggal)= EXTRACT(YEAR FROM sysdate)", kodestat, jenis)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                If jenis.Trim.ToUpper = "PINJAM" Then
                    nobukti = String.Format("KPJ.{0}/{1}{2}", kodestat, yearss.Substring(2, 2), nobukti)
                ElseIf jenis.Trim.ToUpper = "BAYAR" Then
                    nobukti = String.Format("KBY.{0}/{1}{2}", kodestat, yearss.Substring(2, 2), nobukti)
                End If


            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_KASMASUK(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_KAS_IN where KD_STAT='{0}' AND extract(year from tanggal)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("KMS.{0}/{1}{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_DEPPRINC(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_DEP_PRINCIPAL where KD_STAT='{0}' AND extract(year from tanggal)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("DPR.{0}/{1}{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_DEPTOKO(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_DEP_TOKO where KD_STAT='{0}' AND extract(year from tanggal)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("DTK.{0}/{1}{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_GIROCAIR(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_PENCAIRAN_GIRO where KD_STAT='{0}' AND extract(year from tanggal)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("PDG.{0}/{1}{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_SPAREIN(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_SPAREPART where KD_STAT='{0}' AND extract(year from tgl_bukti)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("SPI.{0}/{1}{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_GANTISPARE(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_SPAREPART_OUT where KD_STAT='{0}' AND extract(year from tanggal)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("GS.{0}/{1}/{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_PREREAL(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_PRE where KD_STAT='{0}' AND extract(year from tanggal)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("PR.{0}/{1}/{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_PELUNASANTOK(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_TKO_BYAR_HEADER where KD_STAT='{0}' AND extract(year from tanggal)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("PT.{0}/{1}/{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_AKTLAIN(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_ANGKUTAN where KD_STAT='{0}' AND extract(year from tanggal)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("AKT.{0}/{1}{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_INV(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_INV where KD_STAT='{0}' AND extract(year from tanggal)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("INV.{0}/{1}{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_KASOUT(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_KAS_OUT where KD_STAT='{0}' AND extract(year from tanggal)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("KKL.{0}/{1}{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_UANGJALAN_KELUAR(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_UANG_JLN where KD_STAT='{0}' AND extract(year from tgl)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("UAK.{0}/{1}{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Function GET_KODE_UANGJALAN_ANGK_LAIN(ByVal kodestat As String, ByVal cn As OracleConnection, ByVal tanggal As String) As String

            Dim sql As String = ""
            Dim hasil As Integer = 0
            Dim nobukti As String = ""
            Dim dread As OracleDataReader = Nothing
            Dim cmd As OracleCommand = Nothing

            Dim ttgl As Date = convert_date_to_eng(tanggal)
            Dim yearss As String = ttgl.Year

            sql = String.Format("select MAX(TO_NUMBER(SUBSTR(NO_BUKTI,11,5))) AS NO from admlsp.TR_UANG_JLN_LN where KD_STAT='{0}' AND extract(year from tgl)= EXTRACT(YEAR FROM sysdate)", kodestat)

            Try

                cmd = New OracleCommand(sql, cn)
                dread = cmd.ExecuteReader

                If dread.Read Then

                    If dread(0).ToString = "" Then
                        hasil = 0
                    Else
                        hasil = CType(dread(0).ToString, Integer)
                    End If



                Else
                    hasil = 0
                End If


                hasil += 1

                Select Case Len(CType(hasil, String))
                    Case 1
                        nobukti = String.Format("0000{0}", hasil)
                    Case 2
                        nobukti = String.Format("000{0}", hasil)
                    Case 3
                        nobukti = String.Format("00{0}", hasil)
                    Case 4
                        nobukti = String.Format("0{0}", hasil)
                    Case Else
                        nobukti = hasil
                End Select

                nobukti = String.Format("UAL.{0}/{1}{2}", kodestat, yearss.Substring(2, 2), nobukti)

            Catch ex As OracleException
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            End Try

            Return nobukti

        End Function

        Public Shared Sub get_stat_reminder_user()

            Dim cn As OracleConnection = Nothing
            Dim sql As String = String.Empty
            Dim comd As OracleCommand = Nothing
            Dim dread As OracleDataReader

            Try

                cn = New OracleConnection
                cn = open_conn_utama()

                sql = String.Format("select a.REM_KEND,a.REM_GIRO,a.REM_PIUTANG from admlsp.ms_user_header a where a.NAMA='{0}'", userprog)

                comd = New OracleCommand(sql, cn)
                dread = comd.ExecuteReader

                If dread.Read Then

                    If IsNothing(dread(0).ToString) Then
                        rem_kend = 0
                    ElseIf Not IsNumeric(dread(0).ToString) Then
                        rem_kend = 0
                    Else
                        rem_kend = CInt(dread(0).ToString)
                    End If

                    If IsNothing(dread(1).ToString) Then
                        rem_giro = 0
                    ElseIf Not IsNumeric(dread(1).ToString) Then
                        rem_giro = 0
                    Else
                        rem_giro = CInt(dread(1).ToString)
                    End If

                    If IsNothing(dread(2).ToString) Then
                        rem_piutang = 0
                    ElseIf Not IsNumeric(dread(2).ToString) Then
                        rem_piutang = 0
                    Else
                        rem_piutang = CInt(dread(2).ToString)
                    End If

                Else

                    dread.Close()

                    rem_kend = 0
                    rem_giro = 0
                    rem_piutang = 0
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


        End Sub

        Public Shared Sub get_reminder(ByVal grid As DevExpress.XtraGrid.GridControl, ByVal jenis_rem As String)

            Dim cn As OracleConnection = Nothing

            Dim ds As DataSet
            Dim dvmanager As Data.DataViewManager
            Dim dv1 As Data.DataView

            Dim tanggal As Date
            Dim bulan As Integer
            tanggal = Date.Now.Date.ToString
            bulan = Date.Now.Month

            Dim sql As String = String.Empty

            Select Case jenis_rem.ToUpper
                Case "KENDARAAN"

                    sql = String.Format("select rownum,'1.Pajak' as jenis,a.nopol from admlsp.ms_kendaraan a where a.TGL_PAJAK > 0 and a.BLN_PAJAK > 0 and " & _
                                        "(to_date( to_char(to_date(a.TGL_PAJAK || '/1','DD/MM'),'DD') || '/' || to_char(to_date(a.BLN_PAJAK,'MM'),'MM') || '/' || to_char(sysdate,'YY'),'DD/MM/YY') - to_date('{0}','DD/MM/YY') >= -7 and " & _
                                        "to_date( to_char(to_date(a.TGL_PAJAK || '/1','DD/MM'),'DD') || '/' || to_char(to_date(a.BLN_PAJAK,'MM'),'MM') || '/' || to_char(sysdate,'YY'),'DD/MM/YY') - to_date('{0}','DD/MM/YY') <= 7 ) and " & _
                                        "a.aktif=1" & _
                                   " union " & _
                               "select rownum,'2.KIR' as jenis,b.nopol from admlsp.ms_kendaraan b where b.BLN_KIR1 > 0 and b.BLN_KIR2 > 0 and (b.BLN_KIR1={1} or b.BLN_KIR2={2}) and b.aktif=1", convert_date_Khusus(tanggal), bulan, bulan)

                Case "GIRO"

                    sql = String.Format("SELECT ROWNUM,A.NO_GIRO FROM ADMLSP.MS_GIRO A WHERE A.TGL_TEMPO <='{0}' AND A.STATUS='PENDING'", convert_date_to_eng(Date.Now))

                Case "PIUTANG"

                    Dim dt As Date
                    dt = Date.Now.Date.ToString

                    sql = String.Format("SELECT ROWNUM,B.NAMA_TOKO,A.NODO " & _
                            "FROM ADMLSP.TR_REAL_ORDER A INNER JOIN ADMLSP.MS_TOKO B ON A.KD_TOKO=B.KD_TOKO " & _
                            "WHERE (to_date('{0}','DD-MON-YY') - A.TANGGAL > 6) AND A.TOT_AKH > (A.TOT_BAYAR + A.TOT_BAYAR_GIRO) " & _
                            "ORDER BY ROWNUM,A.TANGGAL  ASC", convert_date_to_eng(dt))

            End Select

           

            grid.DataSource = Nothing


            Try

                dv1 = Nothing

                cn = New OracleConnection
                cn = classmy.open_conn_utama

                ds = New DataSet()
                ds = classmy.GetDataSet(sql, cn)

                dvmanager = New DataViewManager(ds)
                dv1 = dvmanager.CreateDataView(ds.Tables(0))

                grid.DataSource = dv1

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

    End Class
End Namespace
