<%@ Page Language="VB" AutoEventWireup="false" CodeFile="list_users.aspx.vb" Inherits="UserManagement_LKIM_list_users" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS User Management</title>
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
    
  <div> <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager> 
    &nbsp;<br />
    <table border="0" cellpadding="0" cellspacing="0" width="938">
      <tr> 
        <td width="27%" style="height: 13px">M O D U L &nbsp;&nbsp;&nbsp;K E S 
          E L A M A T A N</td>
        <td width="73%" bgcolor="#999999" style="height: 13px">&nbsp;</td>
      </tr>
    </table>
    <br />
  </div>
        <table style="width: 653px">
            <tr>
                <td colspan="3">
                    <strong><span style="font-size: 10pt; font-family: Arial Black">PENGURUSAN PENGGUNA
                    LKIM</span></strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px" bgcolor="gainsboro">
                    <strong>
                    Perhatian :</strong> Sila klik pada kata penguna untuk mengemaskini atau memapar maklumat
                    pengguna.</td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 650px">
                    <tr>
                        <td style="width: 217px; height: 8px">
                        </td>
                        <td style="height: 8px">
                        </td>
                    </tr>
            <tr>
                <td style="width: 217px; height: 8px">
                    Carian berdasarkan nama penuh pengguna</td>
                <td style="height: 8px">
                    <asp:TextBox ID="NamaPengguna" runat="server" Width="187px"></asp:TextBox>
                    <asp:Button ID="mulaCarian" runat="server" Text="Mulakan Carian" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" /></td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" DataSourceID="lkim_userlists"
            Width="651px" Height="22px" ShowFooter="True" >
            <HeaderStyle BackColor="RoyalBlue" ForeColor="White" Height="22px" />
            <PagerSettings Mode="NextPreviousFirstLast" />
            <RowStyle Height="18px" />
            <Columns>
                <asp:BoundField DataField="ID Pegawai" HeaderText="ID Pegawai" SortExpression="ID Pegawai" />
                <asp:BoundField DataField="Nama Pegawai" HeaderText="Nama Pegawai" SortExpression="Nama Pegawai" />
                <asp:BoundField DataField="gelaran" HeaderText="Gelaran" SortExpression="gelaran" />
                <asp:BoundField DataField="Jawatan" HeaderText="Jawatan" SortExpression="Jawatan" />
                <asp:BoundField DataField="Kata Pengguna" HeaderText="ID Pengguna" ReadOnly="True"
                    SortExpression="Kata Pengguna" />
                <asp:BoundField DataField="group_name" HeaderText="Hak Kebenaran Akses"
                    SortExpression="group_name" />
            </Columns>
            <FooterStyle BackColor="RoyalBlue" Height="22px" />
            <AlternatingRowStyle BackColor="#E0E0E0" />
        </asp:GridView>
        <asp:SqlDataSource ID="lkim_userlists" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT PEGAWAI.id, PEGAWAI.id_pegawai AS [ID Pegawai], &#13;&#10;PEGAWAI.nama AS [Nama Pegawai], PEGAWAI.jawatan AS Jawatan, &#13;&#10;PEGAWAI.kebenaran_akses AS [Kumpulan Pengguna], &#13;&#10;PEGAWAI.kata_pengguna AS [Kata Pengguna], PEGAWAI.kata_laluan AS [Kata Laluan], &#13;&#10;PEGAWAI.gelaran, [group].group_name FROM PEGAWAI &#13;&#10;INNER JOIN [group] &#13;&#10;ON PEGAWAI.kebenaran_akses = [group].group_id &#13;&#10;WHERE (PEGAWAI.nama LIKE '%a%' and PEGAWAI.deleted='N')">
        </asp:SqlDataSource>
                <br />
                <asp:Button ID="NewUser" runat="server" Text="Pengguna Baru" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClientClick="location.href='new_lkim_user.aspx';"/>
                <asp:Button ID="Button2" runat="server" Text="Kembali Ke Laman Utama" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;"/>&nbsp;<br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
