
Partial Class suntinganmaklumat_newCajIkanCompanyEksport
    Inherits System.Web.UI.Page
    Public dbConn As System.Data.SqlClient.SqlConnection
    Public opClass As SQLOperation
    Public strKodImporter As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("username") Is Nothing Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                             "alert('Sistem Error!!! Sessi Anda Telah Tamat Atau Tidak Sah!!!');" & _
                                             "parent.location.href='../index.aspx';" & _
                                             "</script>"
            Response.Write(popupScript)
        End If


        opClass = New SQLOperation()
        opClass.dbConnection()
        kodImporter.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
        kodImporter.Attributes.Add("onBlur", "selectedDropDown();")
        Importer.Attributes.Add("onChange", "document.all.kodImporter.value=document.all.Importer.options.value;")






        If Page.IsPostBack = False Then
            strKodImporter = Request("kodImporter")
            kodImporter.Text = strKodImporter
        Else
            strKodImporter = Importer.SelectedValue
            kodImporter.Text = strKodImporter
        End If

    End Sub



    Protected Sub Importer_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles jenisUrusan.PreRender
        If strKodImporter <> "" Then
            Importer.ClearSelection()
            Importer.Items.FindByValue(strKodImporter).Selected = True
        End If
    End Sub


    Protected Sub Simpan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Simpan.Click

        If Simpan.Page.IsPostBack Then
            Dim kpk As Decimal = 0
            Dim kpb As Decimal = 0
            Dim kdr_ekor As Decimal = 0
            Dim qty As Decimal = 0
            Dim trkhMula As String = tarikhKuatKuasa.Text
            Dim trkhAkhir As String = tarikhAkhir.Text
            Dim newTrkhMula As String = ""
            Dim newTrkhAkhir As String = ""

            If trkhMula <> "" Then
                Dim formatDateMula As String() = trkhMula.Split("/")
                newTrkhMula = formatDateMula(1) & "/" & formatDateMula(0) & "/" & formatDateMula(2)
            End If

            If trkhAkhir <> "" Then
                Dim formatDateAkhir As String() = trkhAkhir.Split("/")
                newTrkhAkhir = formatDateAkhir(1) & "/" & formatDateAkhir(0) & "/" & formatDateAkhir(2)
            End If


            If pk.Text <> "" Then
                kpk = pk.Text
            End If

            If pb.Text <> "" Then
                kpb = pb.Text
            End If

            If ekor.Text <> "" Then
                kdr_ekor = ekor.Text
            End If

            If kk.Text <> "" Then
                qty = kk.Text
            End If

            Dim sql As String = "INSERT INTO COMPANY_IKAN_CAJ_EKSPORT" & _
                      "(Kategori_Ikan, Jenis_Urusan, Kadar_Peti_Kecil, Kadar_Peti_Besar," & _
                      "Kadar_Ekor, Kadar_Kuantiti, Kod_Pengimport, tarikh_mula," & _
                      "tarikh_tamat, kata_pengguna)" & _
                      "VALUES('" & kategoriIkan.SelectedValue & "','" & jenisUrusan.SelectedValue & "'" & _
                      "," & kpk & "," & kpb & "," & kdr_ekor & "," & qty & ",'" & Importer.SelectedValue & "','" & newTrkhMula & "','" & newTrkhAkhir & "','" & Session("username") & "')"
            'Response.Write(sql)
            opClass.InsertData(sql)
            Response.Write("<script> alert('Maklumat Telah Selamat Disimpan!!!!');location.href='cajIkanCompanyEksport.aspx?kodImporter=" & strKodImporter & "'; </script>")
        End If
    End Sub
End Class
