Namespace lspclass
    Public Class terbilang

        Public Shared Function ANGKA_TERBILANG(ByVal nilai As Double) As String
            Dim bilangan As String() = {"", "SATU", "DUA", "TIGA", "EMPAT", "LIMA", _
     "ENAM", "TUJUH", "DELAPAN", "SEMBILAN", "SEPULUH", "SEBELAS"}
            If nilai < 12 Then
                Return " " & bilangan(nilai)
            ElseIf nilai < 20 Then
                Return ANGKA_TERBILANG(nilai - 10) & " belas"
            ElseIf nilai < 100 Then
                Return (ANGKA_TERBILANG(CInt((nilai \ 10))) & " puluh") + ANGKA_TERBILANG(nilai Mod 10)
            ElseIf nilai < 200 Then
                Return " seratus" & ANGKA_TERBILANG(nilai - 100)
            ElseIf nilai < 1000 Then
                Return (ANGKA_TERBILANG(CInt((nilai \ 100))) & " ratus") + ANGKA_TERBILANG(nilai Mod 100)
            ElseIf nilai < 2000 Then
                Return " seribu" & ANGKA_TERBILANG(nilai - 1000)
            ElseIf nilai < 1000000 Then
                Return (ANGKA_TERBILANG(CInt((nilai \ 1000))) & " ribu") + ANGKA_TERBILANG(nilai Mod 1000)
            ElseIf nilai < 1000000000 Then
                Return (ANGKA_TERBILANG(CInt((nilai \ 1000000))) & " juta") + ANGKA_TERBILANG(nilai Mod 1000000)
            ElseIf nilai < 1000000000000 Then
                Return (ANGKA_TERBILANG(CInt((nilai \ 1000000000))) & " milyar") + ANGKA_TERBILANG(nilai Mod 1000000000)
            ElseIf nilai < 1000000000000000 Then
                Return (ANGKA_TERBILANG(CInt((nilai \ 1000000000000))) & " trilyun") + ANGKA_TERBILANG(nilai Mod 1000000000000)
            Else
                Return ""
            End If
        End Function

    End Class
End Namespace
