<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Senarai_Ikan.aspx.vb" Inherits="Import_Senarai_Ikan" %>
<%@ OutputCache Duration="20" VaryByParam="*" SqlDependency="CommandNotification"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
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
}
}

</script>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataSourceID="jenis_ikan" AllowPaging="True" AllowSorting="True" PageSize="20" Width="364px">
            <Columns>
                <asp:BoundField DataField="Nama_BKH" HeaderText="Nama" SortExpression="Nama_BKH" />
                <asp:BoundField DataField="Kod_Ikan" HeaderText="Kod_Ikan" SortExpression="Kod_Ikan" />
                <asp:BoundField DataField="Kod_BKH" HeaderText="Kod" SortExpression="Kod_BKH" />
            </Columns>
                    <PagerSettings Mode="NextPreviousFirstLast" />
                    <PagerStyle BorderStyle="Inset" />
        </asp:GridView>
        <asp:SqlDataSource ID="jenis_ikan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Nama_BKH], [Kod_Ikan], [Kod_BKH] FROM [JENIS_IKAN] WHERE ([Nama_BKH] LIKE '' + @Nama_BKH + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" DefaultValue="%" Name="Nama_BKH" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="Button2" runat="server" Text="Button" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1" Width="367px"/><asp:TextBox ID="TextBox1" runat="server" Width="362px"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></div>
    </form>
</body>
</html>
