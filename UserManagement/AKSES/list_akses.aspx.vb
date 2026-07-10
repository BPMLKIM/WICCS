Imports System
Imports System.Data
Imports System.Data.SQLClient
Imports System.Configuration
Imports System.IO
Imports System.Text
Partial Class list_akses
    Inherits System.Web.UI.Page
#Region "Variables Declaration"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation
    Protected opClass2 As SQLOperation
    Dim SQLReader As System.Data.SqlClient.SqlDataReader
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()

        idgroup.Attributes.Add("onclick", "javascript:self.location.href='hak_akses.aspx';")

    End Sub


    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onClick", "HighLightTR('#c9cc99','cc3333');location.href='edit_group.aspx?iduser=" & e.Row.DataItem(0).ToString() & "&user=" & e.Row.DataItem(1).ToString() & "';")
            'Response.Write("location.href='lesen_lkim_user.aspx?user=" & e.Row.DataItem(0).ToString() & "';")
        End If
    End Sub

End Class
