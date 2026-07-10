Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections

Partial Class script1_tocTab

    Inherits System.Web.UI.Page
    Public opClass As SQLOperation
    Public jsReader As SqlDataReader
    Public menutree_list As New ArrayList
    Public submenuArrayList_menu As New ArrayList
    Public submenuArrayList_link As New ArrayList
    Public submenuArrayList_order As New ArrayList
    Public submenuArrayList_moduleid As New ArrayList
    Public toctab As String
    Public tocparas As String
    Public displayToc As String
    Public top As String
    Public mainpage As String
    Public titles As String
    Dim cnt As Double


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        titles = "LKIM - Bukit Kayu Hitam"
        toctab = "script1/tocTab.aspx"
        tocparas = "script1/tocParas(pegawai).js"
        displayToc = "script1/displayToc(pegawai).js"
        mainpage = "blank.htm"
        top = "top.aspx"

        opClass = New SQLOperation()
        opClass.dbConnection()
        'Dim sqlText As String = "SELECT menu_sub.submodule, menu_sub.link, CAST(menu_sub.module_id AS varchar) + '.' + CAST(menu_sub.submenu_order AS varchar) AS arrayIndex, menu_sub.submenu_order, menu_sub.module_id  " & _
        '                        "FROM group_setting INNER JOIN " & _
        '                        "menu_sub ON group_setting.sub_module_id = menu_sub.submodule_id " & _
        '                        "WHERE (group_setting.group_id = '" & trim(Session("akses")) & "') order by menu_sub.submenu_order asc"

        Dim sqlText As String = "SELECT distinct menu_sub.submodule, menu_sub.link, CAST(menu_sub.module_id AS varchar) + '.' + CAST(menu_sub.submenu_order AS varchar) AS arrayIndex, menu_sub.submenu_order, menu_sub.module_id  " & _
                               "FROM group_setting_sub INNER JOIN " & _
                               "menu_sub ON group_setting_sub.sub_module_id = menu_sub.submodule_id " & _
                               "WHERE (group_setting_sub.group_id = '" & Trim(Session("akses")) & "') order by menu_sub.submenu_order asc"

        'Response.Write(sqlText)
        'Response.End()
        jsReader = opClass.DataReader(sqlText)
        Do While jsReader.Read
            'Response.Write(jsReader.GetValue(0).ToString & "<br>")
            'Response.Write(jsReader.GetValue(1).ToString & "<br>")
            'Response.Write(jsReader.GetValue(3).ToString & "<br>")
            'Response.Write(jsReader.GetValue(4) & "<br>")
            submenuArrayList_menu.Add(jsReader.GetValue(0).ToString)
            submenuArrayList_link.Add(jsReader.GetValue(1).ToString)
            submenuArrayList_order.Add(jsReader.GetValue(3).ToString)
            submenuArrayList_moduleid.Add(jsReader.GetValue(4))
        Loop
        jsReader.Close()
        jsReader = Nothing

        'Response.End()

        'Loading Main Module
        sqlText = "SELECT DISTINCT menu_main.Menu_main, ISNULL(menu_main.link,'') as link, menu_main.menu_order, menu_main.module_id " & _
                  "FROM group_setting INNER JOIN " & _
                  "menu_main ON menu_main.module_id = group_setting.module_id " & _
                  "WHERE(group_setting.group_id = '" & Trim(Session("akses")) & "') order by menu_main.module_id asc "
        jsReader = opClass.DataReader(sqlText)


        cnt = 1
        Do While jsReader.Read
            cnt = cnt + 1
            Dim link As String = jsReader.GetValue(1)
            Dim myData As String = "tocTab[" & cnt.ToString & "] = new Array ('" & cnt.ToString & "', '" & jsReader.GetValue(0) & "', '" & link & "');"
            menutree_list.Add(myData)
            Dim module_id As Integer = jsReader.GetValue(3)
            ' Loading Sub Module If Available
            addSubMenu(module_id, cnt)
        Loop
        jsReader.Close()
        jsReader = Nothing


    End Sub

    'Function For Loading Sub Module
    Public Sub addSubMenu(ByVal mod_id As Integer, ByVal countno As Integer)
        Dim i As Integer
        Dim toctabIndex As Double = countno
        For i = 0 To submenuArrayList_moduleid.Count - 1
            If (submenuArrayList_moduleid(i) = mod_id) Then
                toctabIndex = toctabIndex + 0.1
                cnt = cnt + 1
                Dim myData As String = "tocTab[" & cnt.ToString & "] = new Array ('" & toctabIndex.ToString & "', '" & submenuArrayList_menu(i).ToString & "', '" & submenuArrayList_link(i).ToString & "');"
                menutree_list.Add(myData)
            End If
        Next
    End Sub

End Class
