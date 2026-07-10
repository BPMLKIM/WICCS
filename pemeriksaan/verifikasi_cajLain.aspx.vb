Imports System.Web
Partial Class verifikasi_barcode
    Inherits System.Web.UI.Page
#Region "Variables Declaration Area"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation
    Protected opClass2 As SQLOperation

    Dim SQLReader As System.Data.SqlClient.SqlDataReader
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
    Dim SQLReader2 As System.Data.SqlClient.SqlDataReader

    Dim strSQL As String
    Dim urusan As String

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Barcode.Focus()

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

        opClass = New SQLOperation()
        opClass.dbConnection()



        If Page.IsPostBack Then

            Dim rstBayar As String = "SELECT status FROM SISTEM_Q WHERE No_Barcode = '" & Trim(Barcode.Text) & "'"
            SQLReader = opClass.DataReader(rstBayar)

            SQLReader.Read()

            If SQLReader.HasRows Then

                If Trim(SQLReader("status")) = "Pintu Keluar Utara" Or Trim(SQLReader("status")) = "Pintu Keluar Selatan" Then

                    Response.Write("<script languange=javascript>alert('Status bagi barcode tersebut adalah telah keluar dari kompleks.');self.location.href='verifikasi_cajLain.aspx?urusan=" & Trim(Request("urusan")) & "';</script>")
                    Response.End()
                    Barcode.Focus()
                    barcode.text = ""

                End If


            End If


            SQLReader.Close()
            SQLReader = Nothing

            strSQL = " SELECT Kod_Jenis_Urusan,No_Kenderaan from PENDAFTARAN_PINTU WHERE Nombor_Barcode = '" & Barcode.Text & "'"
            SQLReader = opClass.DataReader(strSQL)

            If Not SQLReader.HasRows Then

                SQLReader.Close()
                SQLReader = Nothing
                Response.Write("<script languange=javascript>alert('Nombor barcode tidak wujud');self.location.href='verifikasi_cajLain.aspx?urusan=" & Trim(Request("urusan")) & "';</script>")
                Response.End()
                Barcode.Focus()
                barcode.text = ""

            Else

                SQLReader.Read()
                Dim urusan As String

                If Trim(SQLReader("Kod_Jenis_Urusan")) = "003" Or Trim(SQLReader("Kod_Jenis_Urusan")) = "017" Or Trim(SQLReader("Kod_Jenis_Urusan")) = "018" Then
                    urusan = "E"
                Else
                    urusan = "I"
                End If

                Response.Redirect("pemeriksaan_caj.aspx?no_kenderaan=" & SQLReader("No_Kenderaan") & "&urusan=" & Trim(urusan) & "&strBarcode=" & Trim(Barcode.Text) & "")

                SQLReader.Close()
                SQLReader = Nothing
            End If



        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

End Class
