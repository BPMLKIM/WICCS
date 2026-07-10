
Partial Class suntinganmaklumat_cajIkanCompanyEksport
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
        Importer.Attributes.Add("onChange", "document.all.kodImporter.value=document.all.Importer.options.value;document.form1.submit();")


        If Page.IsPostBack = False Then
            strKodImporter = Request("kodImporter")
            kodImporter.Text = strKodImporter
        Else
            strKodImporter = Importer.SelectedValue
            kodImporter.Text = strKodImporter
        End If

    End Sub

    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        If Button1.Page.IsPostBack Then
            If Importer.SelectedValue = "" Then
                Label1.Text = "Sila Pilih Pengimport Terlebih Dahulu!!!!"
            Else
                Label1.Text = ""
                Response.Redirect("newCajIkanCompanyEksport.aspx?kodImporter=" & Importer.SelectedValue)
                'Server.Transfer("newCajIkanCompany.aspx")
                'Panel1.Visible = True
            End If
        End If
    End Sub

    Protected Sub Importer_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Importer.PreRender
        If strKodImporter <> "" Then
            Importer.ClearSelection()
            Importer.Items.FindByValue(strKodImporter).Selected = True
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onClick", "HighLightTR('#c9cc99','cc3333');location.href='cajIkanCompany_edit_lkim_user_eksport.aspx?user=" & e.Row.DataItem(0).ToString() & "';")
            'Response.Write("location.href='edit_lkim_user.aspx?user=" & e.Row.DataItem(1).ToString() & "';")
        End If
    End Sub
End Class
