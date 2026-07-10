
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class pembayaran_frmAgenIKANC
    Inherits System.Web.UI.Page



#Region "Variables Declaration"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation
    Protected opClass2 As SQLOperation
    Dim SQLReader As System.Data.SqlClient.SqlDataReader
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
    Dim SQLReader3 As System.Data.SqlClient.SqlDataReader
    Dim SQLReader4 As System.Data.SqlClient.SqlDataReader
    Dim DepositSemasa As Decimal
    Dim total_caj_kredit As Decimal
    Dim total_caj_agen As Decimal
    Dim stmt As String = ""
    Dim NoSiriResit As String = ""
    Dim Baki_Semasa As Decimal = 0
    Dim DepositSkrg As Decimal
    Dim cajIkan1 As String = ""

    Dim barcodex As String

#End Region

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()

        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        opClass2 = New SQLOperation()
        opClass2.dbConnection()

        Session.LCID = 2057

        If Page.IsPostBack Then

            If TextBox2.Text = "" Or kod_agen.Text = "" Then

                Response.Write("<script languange=javascript>alert('Sila masukkan tarikh dan kod agen');self.location.href='frmAgenIKANC.aspx';</script>")
                Response.End()

            End If

            id_nameagen.Attributes.Add("style", "DISPLAY:Block")

            Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))

            Try
                If Session("username").ToString() Is Nothing Then

                    Session.Clear()
                    Dim popupScript As String = "<script language='javascript'>" & _
                    "alert('Sessi penggunaan anda telah tamat !!!');parent.location.href='../index.aspx';" & _
                    "</script>"
                    Response.Write(popupScript)
                    Response.End()

                End If
            Catch ex As Exception
                Dim popupScript As String = "<script language='javascript'>" & _
                "alert('Sessi penggunaan anda telah tamat !!!');parent.location.href='../index.aspx';" & _
                "</script>"
                Response.Write(popupScript)
                Response.End()

            End Try

            Dim splitout = Split(TextBox2.Text, "/")

            Dim strKod As String = "select Nama_Agen_Pengangkutan,kod_agen_pengangkutan,deposit_semasa from agen_pengangkutan where " _
            & " kod_agen_pengangkutan='" & Trim(kod_agen.Text) & "'"
            SQLReader = opClass.DataReader(strKod)

            If SQLReader.HasRows Then

                SQLReader.Read()
                kod_agen.Text = SQLReader("Kod_Agen_Pengangkutan")
                name_agen.Text = SQLReader("Nama_Agen_Pengangkutan")
                DepositSkrg = Trim(SQLReader("deposit_semasa"))
                lbldepositagen.Text = (Trim(SQLReader("deposit_semasa")))

            Else

                name_agen.Text = "Nama Agen tidak terdapat dalam pengkalan data"

            End If

            SQLReader.Close()
            SQLReader = Nothing


            ' untuk cek jumlah yang ada telah digunakan oleh agen

            Dim cekBayar As String = "Select sum(jumlah_caj_kredit) as total_caj from pembayaran_caj where Kod_Agen_Pengangkutan = '" & Trim(kod_agen.Text) & "' and " _
            & "(DAY(Tarikh_Bayar) = Day(getdate())) AND (MONTH(Tarikh_Bayar) = month(getdate())) AND (YEAR(Tarikh_Bayar) = year(getdate()))"
            SQLReader = opClass.DataReader(cekBayar)

            If SQLReader.HasRows Then
                SQLReader.Read()
                If (SQLReader.IsDBNull(0)) Then
                    total_caj_kredit = 0
                Else
                    total_caj_kredit = Trim(SQLReader("total_caj"))
                End If
            End If

            SQLReader.Close()
            SQLReader = Nothing


            '-------------utk tolak jumlah caj kredit dgn nilai rebat jika ada buat rebat
            Dim rebatkurang As Decimal
            Dim cekBayar1 As String = "select sum(a.nilai_caj_kurang) as nilaicajkurang from pembayaran_caj as b inner join item_caj_kibfg as a on b.no_barcode= a.no_barcode where Kod_Agen_Pengangkutan = '" & Trim(kod_agen.Text) & "' and  (DAY(Tarikh_Bayar) = Day(getdate())) AND (MONTH(Tarikh_Bayar) = month(getdate())) AND (YEAR(Tarikh_Bayar) = year(getdate())) and b.jumlah_caj_kredit<>0"
            SQLReader = opClass.DataReader(cekBayar1)

            If SQLReader.HasRows Then
                SQLReader.Read()
                If (SQLReader.IsDBNull(0)) Then
                    rebatkurang = 0
                Else
                    rebatkurang = Trim(SQLReader("nilaicajkurang"))
                End If
            End If

            SQLReader.Close()
            SQLReader = Nothing
            '---------------------------------



            'lbldepositagen.Text = FormatNumber(CDec(DepositSkrg) - CDec(total_caj_kredit))
            lbldepositagen.Text = FormatNumber(CDec(DepositSkrg) - CDec(total_caj_kredit)) + CDec(rebatkurang)



            '-------------------------------------------------------------koding baru utk asingkan hanya bukan rebat saja keluar
            Dim strSQL1 As String = "select i.no_barcode as no_barcode,n.no_invois,sum(i.totalcajikan) as cajikan,j.nilai_caj, j.cara_pembayaran,j.no_cek " _
                   & " from pengisytiharan_i i" _
                   & " inner join pendaftaran_pintu p on i.no_barcode=p.nombor_barcode" _
                   & " inner join no_invois n on i.no_barcode=n.no_barcode" _
                   & " inner join pembayaran_caj_ikan k on i.no_barcode=k.no_barcode" _
                   & " inner join item_caj j on i.no_barcode=j.no_barcode" _
                   & " where p.kod_agen_pengangkutan='" & Trim((kod_agen.Text)) & "' " _
                   & " and day(p.Tarikh_Masa_Masuk)='" & splitout(0) & "' and month(p.Tarikh_Masa_Masuk)='" & splitout(1) & "' and " _
                   & " year(p.Tarikh_Masa_Masuk)='" & splitout(2) & "' " _
                   & " and i.status='A' and k.siri_module='agent_receipt' and j.kod_service_caj='Caj Perkhidmatan Ikan' and k.print_status=0 " _
                   & " group by i.no_barcode,n.no_invois,j.nilai_caj, j.cara_pembayaran,j.no_cek"
            SQLReader4 = opClass2.DataReader(strSQL1)

            If SQLReader4.HasRows Then


                While SQLReader4.Read()


                    barcodex = SQLReader4("no_barcode")
                    Dim strSQL9 As String = "select i.no_barcode as no_barcode " _
                   & " from pengisytiharan_i_kibfg i" _
                   & " inner join pendaftaran_pintu p on i.no_barcode=p.nombor_barcode" _
                   & " inner join no_invois n on i.no_barcode=n.no_barcode" _
                   & " inner join pembayaran_caj_ikan k on i.no_barcode=k.no_barcode" _
                   & " inner join item_caj_kibfg j on i.no_barcode=j.no_barcode" _
                   & " where p.kod_agen_pengangkutan='" & Trim((kod_agen.Text)) & "' " _
                   & " and day(p.Tarikh_Masa_Masuk)='" & splitout(0) & "' and month(p.Tarikh_Masa_Masuk)='" & splitout(1) & "' and " _
                   & " year(p.Tarikh_Masa_Masuk)='" & splitout(2) & "' " _
                   & " and i.status='A' and k.siri_module='agent_receipt' and j.kod_service_caj='Caj Perkhidmatan Ikan(Kotak Insulasi)' and k.print_status=0 and i.no_barcode = '" & barcodex & "'" _
                   & " group by i.no_barcode"
                    SQLReader = opClass.DataReader(strSQL9)




                    If (SQLReader.HasRows = False) Then

                        Dim bil1 As Integer = 0
                        Dim itemTunai As Decimal = 0
                        Dim itemCek As Decimal = 0
                        Dim cara_bayar As String = ""
                        Dim no_cek As String = ""

                        'While SQLReader.Read()

                        cajIkan1 = cajIkan1 & SQLReader4("no_barcode") & "`" & SQLReader4("no_invois") & "`" & (SQLReader4("nilai_caj")) & "`" & SQLReader4("cara_pembayaran") & "`" & SQLReader4("no_cek") & "~"

                        Dim sqlText1 As String = "SELECT print_status from no_siri_resit_lkim where No_barcode = '" & Trim(SQLReader4("no_barcode")) & "'"
                        SQLReader1 = opClass1.DataReader(sqlText1)

                        SQLReader1.Read()

                        If Not SQLReader1.HasRows Then
                            print_status.Value = "N"
                        Else
                            print_status.Value = "Y"
                        End If

                        SQLReader1.Close()
                        SQLReader1 = Nothing

                        'End While


                    End If

                    SQLReader.Close()
                    SQLReader = Nothing




                End While

            End If

            SQLReader4.Close()
            SQLReader4 = Nothing


            '------------------------------------------------------------koding asal untuk asingkan bukan rebat saja keluar



            'info untuk paparkan yang dah bayar lagi dan untuk print sekali

            'Dim strSQL1 As String = "select i.no_barcode,n.no_invois,sum(i.totalcajikan) as cajikan,j.nilai_caj, j.cara_pembayaran,j.no_cek " _
            '& " from pengisytiharan_i i" _
            '& " inner join pendaftaran_pintu p on i.no_barcode=p.nombor_barcode" _
            '& " inner join no_invois n on i.no_barcode=n.no_barcode" _
            '& " inner join pembayaran_caj_ikan k on i.no_barcode=k.no_barcode" _
            '& " inner join item_caj j on i.no_barcode=j.no_barcode" _
            '& " where p.kod_agen_pengangkutan='" & Trim((kod_agen.Text)) & "' " _
            '& " and day(p.Tarikh_Masa_Masuk)='" & splitout(0) & "' and month(p.Tarikh_Masa_Masuk)='" & splitout(1) & "' and " _
            '& " year(p.Tarikh_Masa_Masuk)='" & splitout(2) & "' " _
            '& " and i.status='A' and k.siri_module='agent_receipt' and j.kod_service_caj='Caj Perkhidmatan Ikan' and k.print_status=0 and i.no_barcode <> '" & barcodex & "'" _
            '& " group by i.no_barcode,n.no_invois,j.nilai_caj, j.cara_pembayaran,j.no_cek"
            'SQLReader = opClass.DataReader(strSQL1)

            'If SQLReader.HasRows Then

            '    Dim bil1 As Integer = 0
            '    Dim itemTunai As Decimal = 0
            '    Dim itemCek As Decimal = 0
            '    Dim cara_bayar As String = ""
            '    Dim no_cek As String = ""

            '    While SQLReader.Read()

            '        cajIkan1 = cajIkan1 & SQLReader("no_barcode") & "`" & SQLReader("no_invois") & "`" & (SQLReader("nilai_caj")) & "`" & SQLReader("cara_pembayaran") & "`" & SQLReader("no_cek") & "~"

            '        Dim sqlText1 As String = "SELECT print_status from no_siri_resit_lkim where No_barcode = '" & Trim(SQLReader("no_barcode")) & "'"
            '        SQLReader1 = opClass1.DataReader(sqlText1)

            '        SQLReader1.Read()

            '        If Not SQLReader1.HasRows Then
            '            print_status.Value = "N"
            '        Else
            '            print_status.Value = "Y"
            '        End If

            '        SQLReader1.Close()
            '        SQLReader1 = Nothing

            '    End While


            'End If

            'SQLReader.Close()
            'SQLReader = Nothing

            ' end coded
            '--------------------------------------------------------------------------------------------------------------------------------

            arrayVal.Value = cajIkan1
            lblStatusPembayaran.Text = "Jelas"

            Dim myHost As String
            Dim host As System.Net.IPHostEntry
            host = System.Net.Dns.GetHostEntry(Request.ServerVariables.Item("REMOTE_addr"))
            myHost = host.HostName

            Dim sqlprint As String = "select printer_name from printername where computer_name='" & Trim(myHost) & "'"
            SQLReader = opClass.DataReader(sqlprint)

            If SQLReader.HasRows Then

                SQLReader.Read()

                printer_name.Value = SQLReader("printer_name")

            Else
                printer_name.Value = Replace(printer_name.Value, "/", "\")

            End If

            SQLReader.Close()
            SQLReader = Nothing

            Dim sqlAgenI = "select sum(i.nilai_caj) as nilai_caj from item_caj i inner join pendaftaran_pintu p ON " _
            & " i.no_barcode=p.nombor_barcode inner join pembayaran_caj_ikan j ON j.no_barcode=p.nombor_barcode " _
            & " where i.cara_pembayaran='CEK' and p.kod_agen_pengangkutan='" & Trim((kod_agen.Text)) & "' and day(p.Tarikh_Masa_Masuk)='" & splitout(0) & "'" _
            & " and month(p.Tarikh_Masa_Masuk)='" & splitout(1) & "' and year(p.Tarikh_Masa_Masuk)='" & splitout(2) & "' and " _
            & " j.siri_module='individual_receipt'"
            SQLReader = opClass.DataReader(sqlAgenI)
            SQLReader.Read()

            If Not IsDBNull(SQLReader.GetValue(0)) Then
                kreditIn.Text = FormatNumber(SQLReader("nilai_caj"))
            Else
                kreditIn.Text = "0.00"
            End If

            SQLReader.Close()
            SQLReader = Nothing


        Else

            TextBox2.Text = (Left(Trim(Date.Now()), 10))

        End If


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
        opClass1.dbConnection_Close()
    End Sub

End Class
