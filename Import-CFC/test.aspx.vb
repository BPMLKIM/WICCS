
Partial Class Import_test
    Inherits System.Web.UI.Page

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding

        DropDownList1.ClearSelection()
        DropDownList1.Items.FindByValue("K02").Selected = True
    End Sub

    Protected Sub Page_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete

        'DropDownList1.ClearSelection()
        'DropDownList1.Items.FindByValue("K02").Selected = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        'DropDownList1.ClearSelection()
        'DropDownList1.Items.FindByValue("K02").Selected = True
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        'DropDownList1.ClearSelection()
        'DropDownList1.Items.FindByValue("K02").Selected = True
    End Sub

    Protected Sub Page_SaveStateComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SaveStateComplete

        'DropDownList1.ClearSelection()
        'DropDownList1.Items.FindByValue("K02").Selected = True
    End Sub

    Protected Sub DropDownList1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.PreRender
        DropDownList1.ClearSelection()
        DropDownList1.Items.FindByValue("K02").Selected = True
    End Sub
End Class
