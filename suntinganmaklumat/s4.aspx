<%@ Page Language="VB" AutoEventWireup="false" CodeFile="s4.aspx.vb" Inherits="UserManagement_LKIM_list_users" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS User Management</title>
    <link href="css/bhea2.css" rel="stylesheet" type="text/css" />
   

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
    
  <div> 
    <table border="0" cellpadding="0" cellspacing="0" width="938">
      <tr> 
        <td width="27%" style="height: 13px">MODUL  MENYUNTING MAKLUMAT </td>
        <td width="73%" bgcolor="#006699" style="height: 13px">&nbsp;</td>
      </tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp;</div>
        <table style="width: 653px">
            <tr>
                
      <td colspan="3"> Table Spesis Sotong</td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 650px">
            <tr>
                <td style="width: 237px; height: 8px">
                    Carian berdasarkan nama Spesis Sotong</td>
                <td style="height: 8px">
                    <asp:TextBox ID="NamaPengguna" runat="server" Width="187px"></asp:TextBox>
                    <asp:Button ID="mulaCarian" runat="server" Text="Mulakan Carian" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" /></td>
            </tr>
        </table>
                <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" DataSourceID="lkim_userlists"
            Width="100%" Height="22px" BorderStyle="None" BorderWidth="0px" >
            <HeaderStyle BackColor="#006699" ForeColor="White" Height="22px" />
            <PagerSettings Mode="NextPreviousFirstLast" />
            <RowStyle Height="18px" />
            <Columns>
                <asp:BoundField DataField="Kod_Spesis_Ikan_4" HeaderText="Kod_Spesis_Ikan_4" SortExpression="Kod_Spesis_Ikan_4" />
                <asp:BoundField DataField="Nama_Spesis_Ikan_4" HeaderText="Nama_Spesis_Ikan_4" SortExpression="Nama_Spesis_Ikan_4" />
            </Columns>
            <FooterStyle BackColor="#006699" Height="22px" />
            <AlternatingRowStyle BackColor="#E0E0E0" />
        </asp:GridView>
        <asp:SqlDataSource ID="lkim_userlists" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT Kod_Spesis_Ikan_4, Nama_Spesis_Ikan_4 FROM SPESIS_IKAN_4 WHERE (Nama_Spesis_Ikan_4 LIKE '%' + @nama + '%')and(status='yes')">
            <SelectParameters>
                <asp:ControlParameter ControlID="NamaPengguna" DefaultValue="%" Name="nama" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
                <br />
                    <input id="NewUser" onclick="location.href='s4_new_lkim_user.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Tambah spesis" />

                  <input id="Kembali" onclick="location.href='suntingmaklumat.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Kembali" />

<%--                <asp:Button ID="NewUser" runat="server" Text="Tambah spesis" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClientClick="location.href='s4_new_lkim_user.aspx';"/><asp:Button ID="Kembali" runat="server" Text="Kembali" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClientClick="location.href='suntingmaklumat.aspx';"/>--%>
                
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
