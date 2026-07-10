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



#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()

        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        opClass2 = New SQLOperation()
        opClass2.dbConnection()

        Session.LCID = 2057

        If Request("urusan") = "I" Then
            titleIkan.Text = "IMPORT"
        ElseIf Request("urusan") = "E" Then
            titleIkan.Text = "EKSPORT"
        End If

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

        If Page.IsPostBack Then

            Dim strSQL As String

            strSQL = " SELECT Nombor_Barcode from PENDAFTARAN_PINTU WHERE Nombor_Barcode = '" & Barcode.Text & "'"
            SQLReader = opClass.DataReader(strSQL)

            If Not SQLReader.HasRows Then

                SQLReader.Close()
                SQLReader = Nothing

                Response.Write("<script languange=javascript>alert('Nombor barcode tidak wujud');self.location.href='verifikasi_periksa_kastam.aspx?urusan=" & Trim(Request("urusan")) & "';</script>")
                Response.End()

            Else

                Dim strTable As String = ""
                Dim strTable1 As String = ""
                Dim periksa As Boolean

                SQLReader.Read()

                If Request("urusan") = "I" Then

                    strTable = "PEMERIKSAAN_IMPORT"
                    strTable1 = "PENGISYTIHARAN_I"

                ElseIf Request("urusan") = "E" Then

                    strTable = "PEMERIKSAAN_EKSPORT"
                    strTable1 = "PENGISYTIHARAN_E"

                End If

                Dim strSQL2 As String = " SELECT kod_urusan,status from " & Trim(strTable1) & " WHERE No_Barcode = '" & Trim(Barcode.Text) & "'"
                SQLReader2 = opClass2.DataReader(strSQL2)

                If Not SQLReader2.HasRows Then

                    SQLReader2.Close()
                    SQLReader2 = Nothing

                    Response.Write("<script languange=javascript>alert('Nombor barcode tersebut adalah bukan untuk pemeriksaan " & LCase(titleIkan.Text) & "');self.location.href='verifikasi_periksa_kastam.aspx?urusan=" & Trim(Request("urusan")) & "';</script>")
                    Response.End()

                Else

                    While (SQLReader2.Read())

                        If Trim(SQLReader2("kod_urusan")) <> "007" Then

                            SQLReader2.Close()
                            SQLReader2 = Nothing

                            Response.Write("<script languange=javascript>alert('Nombor barcode tersebut adalah bukan untuk pemeriksaan " & LCase(titleIkan.Text) & " barangan bukan ikan');self.location.href='verifikasi_periksa_kastam.aspx?urusan=" & Trim(Request("urusan")) & "';</script>")
                            Response.End()
                        ElseIf Trim(SQLReader2("status")) = "B" Then

                            SQLReader2.Close()
                            SQLReader2 = Nothing

                            Response.Write("<script languange=javascript>alert('Terdapat SKPI yang mempunyai status Tidak Sah. Sila isytihar semula.');self.location.href='verifikasi_periksa_kastam.aspx?urusan=" & Trim(Request("urusan")) & "';</script>")
                            Response.End()

                        End If



                    End While

                    SQLReader2.Close()
                    SQLReader2 = Nothing

                    periksa = True

                End If


                If periksa = True Then

                    Dim strSQL1 As String = " SELECT No_Barcode from " & Trim(strTable) & " WHERE No_Barcode = '" & Trim(Barcode.Text) & "' And status='1'"
                    SQLReader1 = opClass1.DataReader(strSQL1)

                    SQLReader1.Read()

                    If Not SQLReader1.HasRows Then

                        SQLReader1.Close()
                        SQLReader1 = Nothing

                        Response.Redirect("pemeriksaanNew_kastam.aspx?urusan=" & Trim(Request("urusan")) & "&strBarcode=" & Trim(Barcode.Text) & "")

                    Else

                        SQLReader1.Close()
                        SQLReader1 = Nothing

                        Response.Write("<script languange=javascript>alert('Nombor barcode tersebut telah membuat pemeriksaan');self.location.href='verifikasi_periksa_kastam.aspx?urusan=" & Trim(Request("urusan")) & "';</script>")
                        Response.End()

                    End If

                    


                End If

            End If

            SQLReader.Close()
            SQLReader = Nothing

        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
        opClass1.dbConnection_Close()
        opClass2.dbConnection_Close()
    End Sub
End Class
