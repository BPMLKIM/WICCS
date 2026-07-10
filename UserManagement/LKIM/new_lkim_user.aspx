<%@ Page Language="VB" AutoEventWireup="false" CodeFile="new_lkim_user.aspx.vb" Inherits="UserManagement_LKIM_new_lkim_user" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS Daftar Pengguna Baru LKIM</title>
    <link href="../../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>

<script type="text/javascript" language="javascript">

function keyToUpperCase(field, evt) {
  if (document.all) {
    var c = event.keyCode;
    var C = String.fromCharCode(c).toUpperCase().charCodeAt(); 
    event.keyCode = C;
    return true;
  }
  else 
    return true;
}

</script>

<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 570px">
            <tr>
                <td colspan="3">
                    <strong><span style="font-size: 10pt; font-family: Arial Black">PENGURUSAN PENGGUNA
                        LKIM - Daftar Baru</span></strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 15px">
                </td>
            </tr>
        </table>
    
    </div>
        <table style="width: 567px">
            <tr>
                <td colspan="2" height="20" style="color: white; background-color: royalblue">
                    <strong>Maklumat Pengguna Baru</strong></td>
            </tr>
            <tr>
                <td style="width: 239px">
                    <strong>Staff ID&nbsp;</strong> *</td>
                <td style="width: 424px">
                    <asp:TextBox ID="id_pegawai" runat="server" Width="65px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 239px">
                    <strong>Nama Pegawai *</strong></td>
                <td style="width: 424px">
                    <asp:TextBox ID="nama_pegawai" runat="server" Width="231px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 239px">
                    <strong>Gelaran *</strong></td>
                <td style="width: 424px">
                    <asp:DropDownList ID="gelaran" runat="server">
                        <asp:ListItem Selected="True">Mr.</asp:ListItem>
                        <asp:ListItem>Mrs.</asp:ListItem>
                        <asp:ListItem>Dato</asp:ListItem>
                        <asp:ListItem>Datuk Seri</asp:ListItem>
                        <asp:ListItem>Tan Sri</asp:ListItem>
                        <asp:ListItem>Tun</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 239px; height: 14px">
                    <strong>Jawatan *</strong></td>
                <td style="width: 424px; height: 14px">
                    <asp:TextBox ID="jawatan" runat="server" Width="232px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 239px">
                    <strong>ID Pengguna *</strong></td>
                <td style="width: 424px">
                    <asp:TextBox ID="kata_pengguna" runat="server"></asp:TextBox></td>
            </tr>
            <tr style="display:<%=display%>;">
                <td style="width: 239px; height: 15px;">
                    <strong><span style="color: red">Kata Laluan *</span></strong></td>
                <td style="width: 424px; height: 15px">
                    <asp:TextBox ID="kata_laluan" runat="server" MaxLength="20" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 239px; height: 15px">
                    <strong>Hak Akses</strong></td>
                <td style="width: 424px; height: 15px">
                    <asp:DropDownList ID="hak_akses" runat="server" DataSourceID="accessGroup" DataTextField="group_name" DataValueField="group_id">
                    </asp:DropDownList><asp:SqlDataSource ID="accessGroup" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
                        SelectCommand="SELECT [group_id], [group_name] FROM [group]">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="color: white; background-color: royalblue" height="20">
                </td>
            </tr>
        </table>
        <br />
        &nbsp;<asp:Button ID="NewUser" runat="server" OnClientClick="location.href='new_lkim_user.aspx';"
            Style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
            background-color: #f1f1f1" Text="Simpan Daftar Pengguna" />
        <input id="Button3" onclick="location.href='list_users.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Papar Senarai Pengguna" />&nbsp;<br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="id_pegawai"
            Display="None" ErrorMessage="ID Pegawai"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="nama_pegawai"
            Display="None" ErrorMessage="Nama Pegawai"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="gelaran"
            Display="None" ErrorMessage="Gelaran"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="jawatan"
            Display="None" ErrorMessage="Jawatan"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="kata_pengguna"
            Display="None" ErrorMessage="Kata Pengguna"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="hak_akses"
            Display="None" ErrorMessage="Hak Akses"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Maklumat Berikut Wajib Diisi "
            ShowMessageBox="True" ShowSummary="False" />
    </form>
</body>
</html>
