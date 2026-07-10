<%@ Page Language="VB" AutoEventWireup="false" CodeFile="list_users.aspx.vb" Inherits="UserManagement_LKIM_list_users" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS User Management</title>
    <link href="css/bhea2.css" rel="stylesheet" type="text/css" />
      <script language="javascript" type="text/javascript">
 
     function maskKeyPress(objEvent)
{
    var iKeyCode; 
    iKeyCode = objEvent.keyCode;              
    if (iKeyCode>=48 && iKeyCode<=57) 
    {
    return true;
    }
    else if (iKeyCode == 45) {
    return true;
    }
    else {
    return false;
    }
 }

function validateInt1()
{
    var deposit_semasa_tambahan; 
    deposit_semasa_tambahan = parseFloat(document.form1.deposit_semasa_tambahan.value); if ( isNaN(deposit_semasa_tambahan) || (deposit_semasa_tambahan % 1 != 0) ) { document.form1.deposit_semasa_tambahan.value = 0; } 
    var deposit_semasa; 
    deposit_semasa = parseFloat(document.form1.deposit_semasa.value); if ( isNaN(deposit_semasa) || (deposit_semasa % 1 != 0) ) { document.form1.deposit_semasa.value = 0; } 
    calculate1();
 }
function calculate1() 
{
    var tbdeposit_semasa_tambahan = parseFloat(document.form1.deposit_semasa_tambahan.value);
    var tbdeposit_semasa = parseFloat(document.form1.deposit_semasa.value);
    document.form1.nilai_deposit_semasa.value = parseInt(tbdeposit_semasa_tambahan) + parseInt(tbdeposit_semasa);
    }
</script>

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
        <td width="27%" style="height: 13px">MODUL&nbsp;&nbsp;MENYUNTING&nbsp;MAKLUMAT 
        </td>
        <td width="73%" bgcolor="#006699" style="height: 13px">&nbsp;</td>
      </tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp;</div>
        <table style="width: 653px">
            <tr>
                
      <td colspan="3"> Table Agen Pengangkutan</td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 650px">
            <tr>
                <td style="width: 217px; height: 8px">
                    Carian berdasarkan nama penuh Agen</td>
                <td style="height: 8px">
                    <asp:TextBox ID="NamaPengguna" runat="server" Width="187px"></asp:TextBox>
                    <asp:Button ID="mulaCarian" runat="server" Text="Mulakan Carian" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" /></td>
            </tr>
        </table>
                <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" DataSourceID="lkim_userlists"
            Width="100%" Height="22px" DataKeyNames="Kod_Agen_Pengangkutan" BorderStyle="None" BorderWidth="0px" >
            <HeaderStyle BackColor="#006699" ForeColor="White" Height="22px" />
            <PagerSettings Mode="NextPreviousFirstLast" />
            <RowStyle Height="18px" />
            <Columns>
                <asp:BoundField DataField="Kod_Agen_Pengangkutan" HeaderText="Kod_Agen_Pengangkutan"
                    ReadOnly="True" SortExpression="Kod_Agen_Pengangkutan" />
                <asp:BoundField DataField="Nama_Agen_Pengangkutan" HeaderText="Nama_Agen_Pengangkutan"
                    SortExpression="Nama_Agen_Pengangkutan" />
                <asp:BoundField DataField="Alamat_Agen_Pengangkutan" HeaderText="Alamat_Agen_Pengangkutan"
                    SortExpression="Alamat_Agen_Pengangkutan" />
                <asp:BoundField DataField="Deposit_Semasa" HeaderText="Deposit_Semasa" ReadOnly="True"
                    SortExpression="Deposit_Semasa" />
                <asp:BoundField DataField="Transaksi_Semasa" HeaderText="Transaksi_Semasa" ReadOnly="True"
                    SortExpression="Transaksi_Semasa" />
            </Columns>
            <FooterStyle BackColor="#006699" Height="22px" />
            <AlternatingRowStyle BackColor="#E0E0E0" />
        </asp:GridView>
        <asp:SqlDataSource ID="lkim_userlists" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT Kod_Agen_Pengangkutan, Nama_Agen_Pengangkutan, Alamat_Agen_Pengangkutan, CONVERT (varchar(13), CONVERT (money, Deposit_Semasa), 1) AS Deposit_Semasa, CONVERT (varchar(13), CONVERT (money, Transaksi_Semasa), 1) AS Transaksi_Semasa FROM AGEN_PENGANGKUTAN WHERE (Nama_Agen_Pengangkutan LIKE '%' + @nama + '%') AND (status = 'yes')">
            <SelectParameters>
                <asp:ControlParameter ControlID="NamaPengguna" DefaultValue="%" Name="nama" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
                &nbsp;<input id="NewUser2" onclick="location.href='new_lkim_user.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Tambah Agen" />

                  <input id="Kembali" onclick="location.href='suntingmaklumat.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Kembali" />
                
                <%--<asp:Button ID="NewUser2" runat="server" Text="Tambah Agen " style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClientClick="location.href='new_lkim_user.aspx';"/>
                <asp:Button ID="Kembali" runat="server" Text="Kembali" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClientClick="location.href='suntingmaklumat.aspx';"/>--%>

            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </form>
</body>
</html>
