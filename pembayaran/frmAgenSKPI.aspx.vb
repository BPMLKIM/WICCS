Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class pembayaran_frmAgenSKPI
    Inherits System.Web.UI.Page

#Region "Variables Declaration"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation

    Dim SQLReader As System.Data.SqlClient.SqlDataReader
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
    Dim SQLReader3 As System.Data.SqlClient.SqlDataReader

    Public filetransfer As String = ""
    Public printpaper As Boolean

#End Region
    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()

        Session.LCID = 2057

        If Page.IsPostBack Then

            If TextBox2.Text = "" Or kod_agen.Text = "" Then

                Response.Write("<script languange=javascript>alert('Sila masukkan tarikh dan kod agen');self.location.href='frmAgenSKPI.aspx';</script>")
                Response.End()

            End If

            id_nameagen.Attributes.Add("style", "DISPLAY:Block")
            txtCek.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
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


            Dim strKod As String = "select Nama_agen_pengangkutan,kod_agen_pengangkutan,deposit_semasa from " _
            & "agen_pengangkutan where kod_agen_pengangkutan='" & Trim(kod_agen.Text) & "'"
            SQLReader = opClass.DataReader(strKod)

            If SQLReader.HasRows Then

                SQLReader.Read()
                kod_agen.Text = SQLReader("Kod_Agen_Pengangkutan")
                name_agen.Text = SQLReader("Nama_agen_pengangkutan")
            Else
                name_agen.Text = "Nama Agen tidak terdapat dalam pengkalan data"
            End If

            SQLReader.Close()
            SQLReader = Nothing

            Dim strSQL As String = ""

            If (urusan.SelectedValue = "I") Then

                strSQL = "select i.no_barcode,n.no_invois,sum(j.borang) as borang" _
                & " from PENGISYTIHARAN_I i" _
                & " inner join pendaftaran_pintu p on i.no_barcode=p.nombor_barcode" _
                & " inner join agen_pengangkutan a on p.kod_agen_pengangkutan=a.kod_agen_pengangkutan" _
                & " inner join jenis_urusan j on p.kod_jenis_urusan=j.kod_urusan" _
                & " inner join no_invois n on i.no_barcode=n.no_barcode" _
                & " where i.status='A' and p.kod_agen_pengangkutan='" & Trim(kod_agen.Text) & "'" _
                & " and day(p.Tarikh_Masa_Masuk)='" & splitout(0) & "' and month(p.Tarikh_Masa_Masuk)='" & splitout(1) & "' and " _
                & " year(p.Tarikh_Masa_Masuk)='" & splitout(2) & "' and not exists(select no_barcode from pembayaran_caj_SKPI where no_barcode=i.no_barcode and kod_agen='" & Trim(kod_agen.Text) & "')" _
                & " group by i.no_barcode,n.no_invois"
            Else
                strSQL = "select i.no_barcode,n.no_invois,sum(j.borang) as borang" _
                & " from PENGISYTIHARAN_E i" _
                & " inner join pendaftaran_pintu p on i.no_barcode=p.nombor_barcode" _
                & " inner join agen_pengangkutan a on p.kod_agen_pengangkutan=a.kod_agen_pengangkutan" _
                & " inner join jenis_urusan j on p.kod_jenis_urusan=j.kod_urusan" _
                & " inner join no_invois_eksport n on i.no_barcode=n.no_barcode" _
                & " where i.status='A' and p.kod_agen_pengangkutan='" & Trim(kod_agen.Text) & "'" _
                & " and day(p.Tarikh_Masa_Masuk)='" & splitout(0) & "' and month(p.Tarikh_Masa_Masuk)='" & splitout(1) & "' and " _
                & " year(p.Tarikh_Masa_Masuk)='" & splitout(2) & "' and not exists(select no_barcode from pembayaran_caj_SKPE where no_barcode=i.no_barcode and kod_agen='" & Trim(kod_agen.Text) & "')" _
                & " group by i.no_barcode,n.no_invois"
            End If
            SQLReader = opClass.DataReader(strSQL)

            Dim cajBorang As String = ""

            If SQLReader.HasRows Then
                Dim bil As Integer = 1

                While SQLReader.Read()

                    cajBorang = cajBorang & SQLReader("no_barcode") & "`" & SQLReader("no_invois") & "`" & (SQLReader("borang")) & "~"
                    
                End While

                arrayVal.Value = cajBorang


            Else

                arrayVal.Value = ""

                'Response.Write("<script>alert('Maklumat tidak wujud');history.back();</script>")

            End If


            SQLReader.Close()
            SQLReader = Nothing

            statuspembayaran.Text = ""

            cmdResit.Disabled = False
            Button7.Disabled = False
            Button3.Disabled = False
            cmdBayar.Enabled = True

            If txtKredit.Text <> "0.00" Then
                cmdBayar.Enabled = False
            End If


            If Request("strVal") <> "" Then
                kod_agen.Enabled = False
            End If


        Else

            TextBox2.Text = (Left(Trim(Date.Now()), 10))

            If Request("strVal") <> "" Then

                Dim i As Integer
                Dim labelnull1 As Integer = 0
                Dim rowArray = Request("strVal").Split("~")
                Dim dataVal As String = ""
                Dim barcodeNumber As String = ""

                For i = 0 To UBound(rowArray) - 1

                    Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

                    'If labelnull1 = 0 Then

                    'dataVal = Trim(arrBayarCol(0)) & "`" & Trim(arrBayarCol(1)) & "`" & Trim(arrBayarCol(2)) & "`" & Trim(arrBayarCol(3)) & "`" & Trim(arrBayarCol(4)) & "`" & Trim(arrBayarCol(5)) & "`" & Trim(arrBayarCol(6)) & "~"
                    'barcodeNumber = Trim(arrBayarCol(4)) & "~"
                    'Else

                    dataVal = dataVal & Trim(arrBayarCol(0)) & "`" & Trim(arrBayarCol(1)) & "`" & Trim(arrBayarCol(2)) & "`" & Trim(arrBayarCol(3)) & "`" & Trim(arrBayarCol(4)) & "`" & Trim(arrBayarCol(5)) & "`" & Trim(arrBayarCol(6)) & "~"
                    barcodeNumber = barcodeNumber & Trim(arrBayarCol(4)) & "~"

                    'End If

                    'labelnull1 = labelnull1 + 1

                Next


                arrayValT.Value = dataVal
                listbarcode.Value = barcodeNumber
                kod_agen.Enabled = False


                tolak.Disabled = True
                tambah.Disabled = True
                cmdResit.Disabled = False
                Button7.Disabled = False
                Button3.Disabled = False

                If txtKredit.Text <> "0.00" Then
                    cmdBayar.Enabled = False
                End If

                statuspembayaran.Text = "Bayar"
                kod_agen.Text = Trim(Request("kod_agen"))
                TextBox2.Text = Trim(Request("tarikh_send"))

            End If

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

            printpaper = True


        End If

        SQLReader.Close()
        SQLReader = Nothing

        ' untuk view file untuk cetak resit

        If Trim(Request("urusan")) = "I" Then

            filetransfer = "cetakResitB1.aspx"

        ElseIf Trim(Request("urusan")) = "E" Then

            filetransfer = "cetakResitBE1.aspx"

        End If



    End Sub


    Public Sub BAYAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        Dim splitout = Split(TextBox2.Text, "/")

        If (sender.Id) = "cmdBayar" Then

            If arrayValT.Value = "" Then

                Response.Write("<script language = javascript>alert('Tiada pilihan dibuat untuk pembayaran.');self.location.href='frmAgenSKPI.aspx';</script>")
                Response.End()

            End If

            Dim strValue = arrayValT.Value
            Dim i As Integer
            Dim rowArray = strValue.Split("~")
            Dim cara_bayar As String = ""
            Dim no_cek As String = ""


            ' to insert the data into the specific table

            Dim bil_item As Integer
            Dim transaksi_semasa As Decimal = 0


            Dim arrloop As String

            If UBound(rowArray) = 0 Then
                arrloop = 0
            Else
                arrloop = UBound(rowArray) - 1

            End If


            Dim tablep As String = ""
            Dim table_in As String = ""
            Dim table_bayar As String = ""

            If Trim(urusan.SelectedValue) = "I" Then

                tablep = "ITEM_CAJ"
                table_in = "no_invois"
                table_bayar = "pembayaran_caj_SKPI"

            Else

                tablep = "ITEM_CAJ_EKSPORT"
                table_in = "no_invois_eksport"
                table_bayar = "pembayaran_caj_SKPE"

            End If


            For i = 0 To arrloop

                Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

                Dim sqlbil As String = "Select bil_item from item_caj where No_Barcode= '" & Trim(arrBayarCol(4)) & "' order by bil_item desc"
                SQLReader = opClass.DataReader(sqlbil)

                SQLReader.Read()

                If SQLReader.HasRows Then

                    bil_item = SQLReader("bil_item") + 1

                Else
                    bil_item = 1

                End If


                SQLReader.Close()
                SQLReader = Nothing

                If arrBayarCol(0) = "CEK / TUNAI" Then

                    'bil_item = 1

                    If arrBayarCol(2) <> "" Then

                        Dim sqlText1 = "INSERT INTO [W-ICCS].[dbo].[" & tablep & "]" _
                        & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                        & " VALUES('" & Trim(arrBayarCol(4)) & "','" & bil_item & "','Caj Pengisytiharan (Borang SKPI) - PNK SRI MUARA'," _
                        & " '" & CDec(arrBayarCol(2)) & "','TUNAI','Tiada'," _
                        & " 'PNK SRI MUARA','PENGISYTIHARAN','" & Session("namaPegawai") & "'," _
                        & " '" & Session("id_pegawai") & "','" & Right(Trim(arrBayarCol(4)), 3) & "')"
                        opClass1.InsertData(sqlText1)

                    End If

                    bil_item = bil_item + 1

                    If arrBayarCol(3) <> "" Then

                        Dim sqlText2 = "INSERT INTO [W-ICCS].[dbo].[" & tablep & "]" _
                        & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                        & " VALUES('" & Trim(arrBayarCol(4)) & "','" & bil_item & "','Caj Pengisytiharan (Borang SKPI) - PNK SRI MUARA'," _
                        & " '" & CDec(arrBayarCol(3)) & "','CEK','" & Trim(arrBayarCol(1)) & "'," _
                        & " 'PNK SRI MUARA','PENGISYTIHARAN','" & Session("namaPegawai") & "'," _
                        & " '" & Session("id_pegawai") & "','" & Right(Trim(arrBayarCol(4)), 3) & "')"
                        opClass1.InsertData(sqlText2)

                    End If

                Else


                    If arrBayarCol(0) = "CEK" Then
                        no_cek = (arrBayarCol(1))
                    Else
                        no_cek = "Tiada"
                    End If

                    'bil_item = 1

                    Dim sqlText1 = "INSERT INTO [W-ICCS].[dbo].[" & tablep & "]" _
                    & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    & " VALUES('" & Trim(arrBayarCol(4)) & "','" & bil_item & "','Caj Pengisytiharan (Borang SKPI) - PNK SRI MUARA'," _
                    & " '" & CDec(arrBayarCol(6)) & "','" & Trim(arrBayarCol(0)) & "','" & Trim(no_cek) & "'," _
                    & " 'PNK SRI MUARA','PENGISYTIHARAN','" & Session("namaPegawai") & "'," _
                    & " '" & Session("id_pegawai") & "','" & Right(Trim(arrBayarCol(4)), 3) & "')"
                    opClass1.InsertData(sqlText1)

                End If


                Dim no_invois As String

                Dim intInvois As String = "select no_invois from " & table_in & " where no_barcode='" & Trim(arrBayarCol(4)) & "'"
                SQLReader1 = opClass.DataReader(intInvois)

                SQLReader1.Read()
                no_invois = SQLReader1("no_invois")

                SQLReader1.Close()
                SQLReader1 = Nothing

                'bil_item = bil_item + 1

                Dim sqlcheck1 As String = "Select * FROM " & table_bayar & " WHERE  No_Barcode = '" & Trim(arrBayarCol(4)) & "'"
                SQLReader3 = opClass.DataReader(sqlcheck1)

                If Not SQLReader3.HasRows Then

                    Dim strBayar2 = "insert into " & table_bayar & "(no_barcode,no_invois,siri_module,kod_agen,print_status,site_code) " _
                    & "values('" & Trim(arrBayarCol(4)) & "','" & Trim(no_invois) & "','agent_receipt','" & Trim(kod_agen.Text) & "','0','" & Right(Trim(arrBayarCol(4)), 3) & "')"
                    opClass1.InsertData(strBayar2)


                End If

                SQLReader3.Close()
                SQLReader3 = Nothing

                ' insert for status transaction

                Dim sqlupdate As String = "INSERT INTO IsyProgressStatus_Front([no_rujukan],[no_barcode], [proses], [dateEnter], [entryBy])" & _
                "VALUES('','" & Trim(arrBayarCol(4)) & "','PEMBAYARAN CAJ BORANG SKPI',getdate(),'" & Session("username") & "')"
                opClass1.InsertData(sqlupdate)

                ' end coded

                'for export update Sistem Q as Bayar

                If Trim(urusan.SelectedValue) = "E" Then

                    Dim updateq = "update sistem_q set status='Bayar' where no_barcode='" & Trim(arrBayarCol(4)) & "'"
                    opClass1.InsertData(updateq)

                End If
                ' end coded

            Next

            Response.Write("<script languange=javascript>alert('Maklumat pembayaran SKPI telah disimpan.');self.location.href='frmAgenSKPI.aspx?urusan=" & urusan.SelectedValue & "&strVal=" & Trim(arrayValT.Value) & "&tarikh_send=" & Trim(TextBox2.Text) & "&Kod_Agen= " & Trim(kod_agen.Text) & "';</script>")
            Response.End()


        End If

        opClass.dbConnection_Close()
        opClass1.dbConnection_Close()

    End Sub


    Protected Sub urusan_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles urusan.PreRender
        If Request("urusan") <> "" Then
            urusan.ClearSelection()
            urusan.Items.FindByValue(Request("urusan")).Selected = True
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

   
End Class
