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
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp;</div>
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
            AutoGenerateColumns="False"
            Width="651px" Height="22px" ShowFooter="True" >
            <HeaderStyle BackColor="RoyalBlue" ForeColor="White" Height="22px" />
            <PagerSettings Mode="NextPreviousFirstLast" />
            <RowStyle Height="18px" />
            <FooterStyle BackColor="RoyalBlue" Height="22px" />
            <AlternatingRowStyle BackColor="#E0E0E0" />
        </asp:GridView>
        <asp:SqlDataSource ID="lkim_userlists" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT PEGAWAI.id, PEGAWAI.id_pegawai AS [ID Pegawai], PEGAWAI.nama AS [Nama Pegawai], PEGAWAI.jawatan AS Jawatan, PEGAWAI.kebenaran_akses AS [Kumpulan Pengguna], PEGAWAI.kata_pengguna AS [Kata Pengguna], PEGAWAI.kata_laluan AS [Kata Laluan], PEGAWAI.gelaran, KUMPULAN_KEBENARAN_AKSES.nama_kumpulan_kebenaran FROM PEGAWAI INNER JOIN KUMPULAN_KEBENARAN_AKSES ON PEGAWAI.kebenaran_akses = KUMPULAN_KEBENARAN_AKSES.kebenaran_akses WHERE (PEGAWAI.nama LIKE '%' + @nama + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="NamaPengguna" DefaultValue="%" Name="nama" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
                <br />
                <asp:Button ID="NewUser" runat="server" Text="Pengguna Baru" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClientClick="location.href='new_lkim_user.aspx';"/>
                <asp:Button ID="Button2" runat="server" Text="Kembali Ke Laman Utama" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;"/>&nbsp;<br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
