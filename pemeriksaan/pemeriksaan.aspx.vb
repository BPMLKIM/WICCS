
Partial Class Pemeriksaan_Ikan
    Inherits System.Web.UI.Page
    Public strSQL As String = ""
    Public SQLReader As System.Data.SqlClient.SqlDataReader



#Region "Variables Declaration Area"
    Protected opClass As SQLOperation
    Protected strKodKenderaan As String
    Protected strJenisUrusan As String

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()

        '    Dim Table1 As New Table
        Dim strBarcode As String = Request.QueryString("Barcode")

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


        ' javascript load here
        DropDownList1.Attributes.Add("onChange", "javascript: if (document.form1.DropDownList1.options[document.form1.DropDownList1.selectedIndex].text=='Tidak Sah') {document.all.a1.style.display='block'} else {document.all.a1.style.display='none';}")
        ' end of javascript code

        '********* to view information for pendaftaran pintu *********

        strSQL = " SELECT Pendaftaran_Pintu.No_Kenderaan,JENIS_URUSAN.Nama_Urusan FROM " & _
                 " Pendaftaran_Pintu INNER JOIN" & _
                  " JENIS_URUSAN ON Pendaftaran_Pintu.Kod_Jenis_Urusan = JENIS_URUSAN.Kod_Urusan" & _
                  " WHERE (Pendaftaran_Pintu.Nombor_Barcode = '" & strBarcode & "')"
        SQLReader = opClass.DataReader(strSQL)
        '      Response.Write(strSQL)

        If SQLReader.HasRows Then

            SQLReader.Read()

            noKenderaan.Text = SQLReader.GetString(0)
            Barcode.Text = strBarcode
            jenis_urusan.Text = SQLReader.GetString(1)

        End If

        SQLReader.Close()
        SQLReader = Nothing

        '************* end **********************************************


        ' Data for fro viewing for barcode

       

        strSQL = "SELECT  dbo.PENGISYTIHARAN_I.No_SKPI, dbo.PENGIMPORT.Nama_Syarikat_Import FROM dbo.PENGISYTIHARAN_I INNER JOIN " _
        & "dbo.PENGIMPORT ON dbo.PENGISYTIHARAN_I.Kod_Pengimport = dbo.PENGIMPORT.Kod_Pengimport WHERE dbo.PENGISYTIHARAN_I.No_Barcode = '" & strBarcode & "'"
        SQLReader = opClass.DataReader(strSQL)

        Dim dataVal As String = ""
        Dim labelnull As String = ""
        'arrayVal.Value = ""

        While SQLReader.Read()

            If labelnull = 0 Then

                dataVal = SQLReader("No_SKPI") & "`" & SQLReader("Nama_Syarikat_Import") & "~"

            Else
                dataVal = dataVal & SQLReader("No_SKPI") & "`" & SQLReader("Nama_Syarikat_Import") & "~"
            End If

            labelnull = labelnull + 1

        End While

        arrayVal.Value = dataVal


        Response.Write(dataVal)

        SQLReader.Close()
        SQLReader = Nothing

        ' ended coded 

    End Sub


End Class
