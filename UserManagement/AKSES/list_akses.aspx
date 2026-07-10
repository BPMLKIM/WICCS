<%@ Page Language="VB" AutoEventWireup="false" CodeFile="list_akses.aspx.vb" Inherits="list_akses" %>

<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>[WICCS]PEMERIKSAAN</title>
    <link href="../../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>

<script language="javascript" type="text/javascript">
var preEl ;
var orgBColor;
var orgTColor;


function HighLightTR(backColor,textColor){  
if(typeof(preEl)!='undefined') {
preEl.bgColor=orgBColor; 
try{ChangeTextColor(preEl,orgTColor);}catch(e){;}
} 
var el = event.srcElement;
el = el.parentElement;
orgBColor = el.bgColor;
orgTColor = el.style.color;
el.bgColor=backColor;

try{ChangeTextColor(el,textColor);}catch(e){;}
preEl = el; 
}

function ChangeTextColor(a_obj,a_color){  ;
for (i=0;i<a_obj.cells.length;i++){//put condition before increase!!!!!
a_obj.cells(i).style.color=a_color; 
document.all.currentImporter.value=a_obj.cells(i).innerHTML;
}
}
</script>

<body>
    <form id="form1" runat="server">
 
        <br />
        <br />
        <strong>SENARAI KUMPULAN UNTUK PENGGUNA LKIM</strong><br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BorderStyle="None" BorderWidth="0px" DataSourceID="lkim_userlists"
            Height="22px" Width="80%" HorizontalAlign="Left">
            <PagerSettings Mode="NextPreviousFirstLast" />
            <FooterStyle BackColor="#006699" Height="22px" />
            <Columns>
                <asp:TemplateField HeaderText="No" InsertVisible="False" SortExpression="group_id">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1"  valign="center" runat="server" Text='<%# Bind("group_id") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" valign="center" runat="server" Text='<%# Bind("group_id") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:BoundField DataField="group_name" HeaderText="Nama Kumpulan" SortExpression="group_name" >
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <RowStyle Height="18px" />
            <HeaderStyle BackColor="#006699" ForeColor="White" Height="22px" />
            <AlternatingRowStyle BackColor="#E0E0E0" />
        </asp:GridView>
        &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Menu_main], [module_id], [link], [menu_order] FROM [menu_main]">
        </asp:SqlDataSource><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [submodule_id], [submodule] FROM [menu_sub]"></asp:SqlDataSource><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [group_id], [group_name] FROM [group]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="lkim_userlists" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [group_id], [group_name] FROM [group]">
        </asp:SqlDataSource>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br /><br /><br />
        <input id="idgroup" type="button" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
            background-color: #f1f1f1" value="Kumpulan Baru" />               
    </form>

</body>
</html>
