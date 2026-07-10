<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Senarai_Ikan1.aspx.vb" Inherits="Senarai_Ikan1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Senarai Ikan Larangan</title>
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

function sendValue(param1,param2,param3)
{

    window.parent.document.all.searchKodIkan.value=param1;
    window.parent.document.all.kodIkan.value=param1;   
    window.parent.document.all.Ikan.value=param2;
    window.parent.document.all.Ikan1.value=param3;
  
//    window.parent.document.all.noKenderaan.focus();
    //this.close();
    window.parent.agenwin.hide();
}    



</script>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    DataSourceID="Ikan" Width="362px" PageSize="15" AutoGenerateColumns="False">
                    <HeaderStyle BackColor="LightGray" />
                    <Columns>
                        <asp:BoundField DataField="kod_bkh" HeaderText="Kod Ikan" SortExpression="kod_bkh" />
                        <asp:BoundField DataField="kod_ikan" HeaderText="Kod 8 Digit" SortExpression="kod_ikan" />
                        <asp:BoundField DataField="nama_bkh" HeaderText="Nama Ikan" SortExpression="nama_bkh" />
                                           </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="Ikan" runat="server" ConnectionString="<%$ ConnectionStrings:w-iccs_Conn %>"
                    SelectCommand="SELECT [kod_bkh], [kod_ikan], [nama_bkh] FROM [jenis_ikan_larangan] WHERE ([nama_bkh] LIKE '%' + @Nama_Agen_Pengangkutan + '%') and status='yes'">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TextBox1" DefaultValue="%" Name="Nama_Agen_Pengangkutan"
                            PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Button ID="Button1" runat="server" Text="Mula Carian Pejabat" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1" Width="362px" /><br />
                <asp:TextBox ID="TextBox1" runat="server" Width="357px"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    
    </form>
</body>
</html>
