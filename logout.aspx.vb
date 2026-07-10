
Partial Class logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
     
        
        Session.Clear()
        Dim popupScript As String = "<script language='javascript'>" & _
                                                                 "parent.location.href='index.aspx';" & _
                                                                 "</script>"
        Response.Write(popupScript)

    End Sub
End Class
