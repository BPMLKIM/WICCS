<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Senarai-printer.aspx.vb" Inherits="Import_Senarai_Ikan" %>

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

function sendValue(param1)
{
 
    window.opener.document.all.printer_name.value=param1;
    
}
    

</script>
    <form id="form1" runat="server">
    <div align="Center"><br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataSourceID="jenis_ikan" AllowPaging="True" AllowSorting="True" Width="240px">
                    <PagerSettings Mode="NextPreviousFirstLast" />
                    <PagerStyle BorderStyle="Inset" />
                    <Columns>
                        <asp:BoundField DataField="Printer_Name" HeaderText="Printer_Name" SortExpression="Printer_Name" />
                        <asp:BoundField DataField="owner" HeaderText="owner" SortExpression="owner" />
                    </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="jenis_ikan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Printer_Name], [owner] FROM [printerName] where status='yes'">
        </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
