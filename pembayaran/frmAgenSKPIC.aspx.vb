
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class pembayaran_frmAgenSKPIC
    Inherits System.Web.UI.Page

#Region "Variables Declaration"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation

    Dim SQLReader As System.Data.SqlClient.SqlDataReader
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
    Dim SQLReader3 As System.Data.SqlClient.SqlDataReader

    Dim DepositSemasa As Decimal
    Dim total_caj_kredit As Decimal
    Dim total_caj_agen As Decimal
    Dim stmt As String = ""
    Dim NoSiriResit As String = ""
    Dim Baki_Semasa As Decimal = 0
    Dim DepositSkrg As Decimal
    Dim cajIkan1 As String = ""

    Public filetransfer As String = ""

#End Region

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()

        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        Session.LCID = 2057

        If Page.IsPostBack Then

            If TextBox2.Text = "" Or kod_agen.Text = "" Then

                Response.Write("<script languange=javascript>alert('Sila masukkan tarikh dan kod agen');self.location.href='frmAgenSKPIC.aspx';</script>")
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

            Dim strKod As String = "select Nama_Agen_Pengangkutan,kod_agen_pengangkutan,deposit_semasa from agen_pengangkutan where kod_agen_pengangkutan='" & Trim(kod_agen.Text) & "'"
            SQLReader = opClass.DataReader(strKod)

            If SQLReader.HasRows Then

                SQLReader.Read()
                kod_agen.Text = SQLReader("Kod_Agen_Pengangkutan")
                name_agen.Text = SQLReader("Nama_Agen_Pengangkutan")
                DepositSkrg = Trim(SQLReader("deposit_semasa"))
                'lbldepositagen.Text = (Trim(SQLReader("deposit_semasa")))
            Else
                name_agen.Text = "Nama Agen tidak terdapat dalam pengkalan data"
            End If

            SQLReader.Close()
            SQLReader = Nothing


            ' untuk cek jumlah yang ada telah digunakan oleh agen
            Dim cekBayar As String = "Select sum(jumlah_caj_kredit) as total_caj from pembayaran_caj where Kod_Agen_Pengangkutan = '" & Trim(kod_agen.Text) & "' and " _
            & "(DAY(Tarikh_Bayar) = '" & splitout(0) & "') AND (MONTH(Tarikh_Bayar) = '" & splitout(1) & "') AND (YEAR(Tarikh_Bayar) = '" & splitout(2) & "')"
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

            'lbldepositagen.Text = FormatNumber(CDec(DepositSkrg) - CDec(total_caj_kredit))


            'info untuk paparkan yang dah bayar lagi dan untuk print sekali

            Dim strSQL1 As String = ""

            If Trim(urusan.SelectedValue = "I") Then

                strSQL1 = "select i.no_barcode,n.no_invois,sum(j.borang) as borang,b.nilai_caj,b.cara_pembayaran,b.no_cek " _
                & " from PENGISYTIHARAN_I i" _
                & " inner join pendaftaran_pintu p on i.no_barcode=p.nombor_barcode" _
                & " inner join agen_pengangkutan a on p.kod_agen_pengangkutan=a.kod_agen_pengangkutan" _
                & " inner join jenis_urusan j on p.kod_jenis_urusan=j.kod_urusan" _
                & " inner join item_caj b on i.no_barcode=b.no_barcode" _
                & " inner join no_invois n on i.no_barcode=n.no_barcode" _
                & " inner join pembayaran_caj_skpi k on i.no_barcode=k.no_barcode" _
                & " where i.status='A' and p.kod_agen_pengangkutan='" & Trim(kod_agen.Text) & "'" _
                & " and day(p.Tarikh_Masa_Masuk)='" & splitout(0) & "' and month(p.Tarikh_Masa_Masuk)='" & splitout(1) & "' and " _
                & " year(p.Tarikh_Masa_Masuk)='" & splitout(2) & "' and k.siri_module='agent_receipt' and b.kod_service_caj='Caj Pengisytiharan (Borang SKPI) - PNK SRI MUARA' and k.print_status=0" _
                & " group by i.no_barcode,n.no_invois,b.nilai_caj, b.cara_pembayaran,b.no_cek"

            Else

                strSQL1 = "select i.no_barcode,n.no_invois,sum(j.borang) as borang,b.nilai_caj,b.cara_pembayaran,b.no_cek " _
                & " from PENGISYTIHARAN_E i" _
                & " inner join pendaftaran_pintu p on i.no_barcode=p.nombor_barcode" _
                & " inner join agen_pengangkutan a on p.kod_agen_pengangkutan=a.kod_agen_pengangkutan" _
                & " inner join jenis_urusan j on p.kod_jenis_urusan=j.kod_urusan" _
                & " inner join item_caj_eksport b on i.no_barcode=b.no_barcode" _
                & " inner join no_invois_eksport n on i.no_barcode=n.no_barcode" _
                & " inner join pembayaran_caj_skpe k on i.no_barcode=k.no_barcode" _
                & " where i.status='A' and p.kod_agen_pengangkutan='" & Trim(kod_agen.Text) & "'" _
                & " and day(p.Tarikh_Masa_Masuk)='" & splitout(0) & "' and month(p.Tarikh_Masa_Masuk)='" & splitout(1) & "' and " _
                & " year(p.Tarikh_Masa_Masuk)='" & splitout(2) & "' and k.siri_module='agent_receipt' and b.kod_service_caj='Caj Pengisytiharan (Borang SKPI) - PNK SRI MUARA' and k.print_status=0" _
                & " group by i.no_barcode,n.no_invois,b.nilai_caj, b.cara_pembayaran,b.no_cek"

            End If
            SQLReader = opClass.DataReader(strSQL1)

            Dim tablep As String = ""
            Dim table_bayar As String = ""
            Dim table_periksa As String = ""

            If Trim(urusan.SelectedValue) = "I" Then

                table_bayar = "no_siri_resit_nekad"

            Else

                table_bayar = "no_siri_resit_nekad_eksport"

            End If

            If SQLReader.HasRows Then

                Dim bil1 As Integer = 0
                Dim itemTunai As Decimal = 0
                Dim itemCek As Decimal = 0
                Dim cara_bayar As String = ""
                Dim no_cek As String = ""

                While SQLReader.Read()


                    cajIkan1 = cajIkan1 & SQLReader("no_barcode") & "`" & SQLReader("no_invois") & "`" & (SQLReader("nilai_caj")) & "`" & SQLReader("cara_pembayaran") & "`" & SQLReader("no_cek") & "~"

                    Dim sqlText1 As String = ""

                    sqlText1 = "SELECT print_status from " & table_bayar & " where No_barcode = '" & Trim(SQLReader("no_barcode")) & "'"
                    SQLReader1 = opClass1.DataReader(sqlText1)

                    SQLReader1.Read()

                    If Not SQLReader1.HasRows Then
                        print_status.Value = "N"
                    Else
                        print_status.Value = "Y"
                    End If

                    SQLReader1.Close()
                    SQLReader1 = Nothing


                End While

            End If

            SQLReader.Close()
            SQLReader = Nothing

            arrayVal.Value = cajIkan1
            lblStatusPembayaran.Text = "Jelas"

            ' untuk view file untuk cetak resit


            If Trim(urusan.SelectedValue) = "I" Then

                filetransfer = "cetakResitB1.aspx"

            ElseIf Trim(urusan.SelectedValue) = "E" Then

                filetransfer = "cetakResitBE1.aspx"

            End If

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

            'end coded

        Else

            TextBox2.Text = (Left(Trim(Date.Now()), 10))


        End If


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        opClass.dbConnection_Close()
        opClass1.dbConnection_Close()

    End Sub

End Class
