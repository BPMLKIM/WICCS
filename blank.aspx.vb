
Partial Class blank
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))

        Try
            If Session("username").ToString() Is Nothing Then

                Session.Clear()
                Dim popupScript As String = "<script language='javascript'>" & _
                                                             "alert('Sessi penggunaan anda telah tamat !!!');parent.location.href='index.aspx';" & _
                                                             "</script>"
                Response.Write(popupScript)


            End If
        Catch ex As Exception
            Dim popupScript As String = "<script language='javascript'>" & _
                                                         "alert('Sessi penggunaan anda telah tamat !!!');parent.location.href='index.aspx';" & _
                                                         "</script>"
            Response.Write(popupScript)

        End Try




    End Sub
End Class
