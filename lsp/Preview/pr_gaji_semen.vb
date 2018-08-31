﻿Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports lsp.lspclass
Imports Oracle.DataAccess.Client

Public Class pr_gaji_semen

    Private bln As String
    Private namabulan As String
    Private thn As String
    Private kodekaryawan As String
    Private namakaryawan As String

    Sub New(ByVal bulan As String, ByVal tahun As String, ByVal kodekary As String, ByVal namakary As String, ByVal nmabulan As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        bln = bulan
        thn = tahun
        kodekaryawan = kodekary
        namakaryawan = namakary
        namabulan = nmabulan
    End Sub

    Private Sub open_data()

        Dim ds As DataSet = Nothing
        Dim cn As OracleConnection = Nothing
        Dim sql As String = ""

        sql = String.Format("SELECT V_GAJI_SEMEN.TANGGAL, V_GAJI_SEMEN.NAMA_TOKO, V_GAJI_SEMEN.NAMA, V_GAJI_SEMEN.TOT_JML, V_GAJI_SEMEN.OKS_ANGKUT, V_GAJI_SEMEN.SUPIR, V_GAJI_SEMEN.REAL_UANG_JLN, V_GAJI_SEMEN.KD_PRE, V_GAJI_SEMEN.REAL_TOT_OKS_AKT, V_GAJI_SEMEN.SISA_OKS, V_GAJI_SEMEN.PEND_SUPIR " & _
                "FROM   ADMLSP.V_GAJI_SEMEN V_GAJI_SEMEN " & _
                "WHERE extract(month from V_GAJI_SEMEN.TANGGAL)='{0}' and extract(year from V_GAJI_SEMEN.TANGGAL)='{1}' and V_GAJI_SEMEN.kd_supir='{2}' " & _
                "ORDER BY V_GAJI_SEMEN.SUPIR,V_GAJI_SEMEN.KD_PRE", bln, thn, kodekaryawan)


        Try

            ' open_wait()

            cn = classmy.open_conn_utama


            ds = New DataSet
            ds = classmy.GetDataSet(sql, cn)

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

            Dim objRpt As New r_det_gaji_semen
            classmy.open_CnReport(objRpt)

            objRpt.SetDataSource(ds.Tables(0))

            Dim supir As String = String.Format("{0}({1})", namakaryawan, kodekaryawan)
            Dim userprint As String = String.Format("User Print : {0}", userprog)
            Dim periode As String = String.Format("Periode Bulan {0} {1}", namabulan, thn)

            objRpt.SetParameterValue(0, supir)
            objRpt.SetParameterValue(1, periode)
            objRpt.SetParameterValue(2, userprint)

            crv1.ReportSource = objRpt
            crv1.Refresh()

            ' close_wait()

        Catch ex As OracleException
            ' close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try


    End Sub

    Private Sub pr_gaji_semen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        open_data()

    End Sub

End Class