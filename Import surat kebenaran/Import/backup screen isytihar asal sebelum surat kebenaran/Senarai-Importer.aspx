<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Senarai-Importer.aspx.vb" Inherits="Importer_Ikan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Senarai Importer</title>
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

function sendValue(param1,param2)
{
    //set importer value & eksporter value
    window.opener.document.all.searchKodImporter.value=param2;
    window.opener.document.all.Importer.value=param1;   
     
}
</script>

    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                &nbsp; &nbsp;&nbsp;<br />
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SenaraiImporter" Width="317px" AllowPaging="True" AllowSorting="True" PageSize="20" AutoGenerateColumns="False">
                    <HeaderStyle BackColor="LightGray" />
                    <Columns>
                        <asp:BoundField DataField="kodPengimport" HeaderText="kodPengimport" ReadOnly="True"
                            SortExpression="kodPengimport" />
                        <asp:BoundField DataField="Nama_Syarikat_Import" HeaderText="Nama_Syarikat_Import"
                            ReadOnly="True" SortExpression="Nama_Syarikat_Import" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SenaraiImporter" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>" SelectCommand="SELECT RTRIM(PENGIMPORT.Kod_Pengimport) AS kodPengimport, RTRIM(PENGIMPORT.Kod_Pengimport) + '|' + RTRIM(PENGIMPORT.No_Lesen) + '|' + CAST(DAY(LESEN.Tarikh_Tamat) AS nvarchar(200)) + '/' + CASE WHEN MONTH(LESEN.Tarikh_Tamat) < 10 THEN '0' + CAST(month(lesen.tarikh_tamat) AS varchar(1)) ELSE CAST(month(lesen.tarikh_tamat) AS varchar(2)) END + '/' + CAST(YEAR(LESEN.Tarikh_Tamat) AS nvarchar(4)) AS Val, LEFT (RTRIM(PENGIMPORT.Nama_Syarikat_Import), 40) AS Nama_Syarikat_Import FROM PENGIMPORT INNER JOIN LESEN ON PENGIMPORT.No_Lesen = LESEN.No_Lesen WHERE (LEFT (RTRIM(PENGIMPORT.Nama_Syarikat_Import), 40) LIKE '' + @Nama_IMP + '%') ORDER BY Nama_Syarikat_Import">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TextBox1" DefaultValue="%" Name="Nama_IMP" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
        <asp:hiddenfield ID="TextBox2" runat="server"></asp:hiddenfield>
        <asp:Button ID="Button1" runat="server" Text="Mulakan Carian Nama Importer" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1" Width="318px" /><asp:TextBox ID="TextBox1" runat="server" Width="312px"></asp:TextBox>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        &nbsp;<br />
        &nbsp;
        &nbsp; &nbsp;<br />
        &nbsp;
    </form>
</body>
</html>
