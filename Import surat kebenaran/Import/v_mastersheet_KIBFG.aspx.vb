
Partial Class Import_v_mastersheet_kibfg
    Inherits System.Web.UI.Page
#Region "Variables Declaration Area"
    Protected opClass As SQLOperation
    'Protected strKodKenderaan As String
    Protected strJenisUrusan As String
    Protected namaJenisUrusan As String
    Public jsReader As System.Data.SqlClient.SqlDataReader
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass.Load_CajIkan()
    End Sub
End Class
