Imports System.Security
Imports secureInfo
Partial Class left
    Inherits System.Web.UI.Page

    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Protected hakAkses As String
    Protected display As String
    Public jsReader As System.Data.SqlClient.SqlDataReader
    Public Reader As System.Data.SqlClient.SqlDataReader
    Public filelocation As System.Data.SqlClient.SqlDataReader
    Public filelocation2 As System.Data.SqlClient.SqlDataReader



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        myEnc = New Encryption64()
        opClass = New SQLOperation()
        opClass.dbConnection()
        display = "none"

    End Sub
End Class
