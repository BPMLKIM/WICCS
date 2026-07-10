<%@ Page Language="VB" AutoEventWireup="false" CodeFile="new_lkim_user.aspx.vb" Inherits="UserManagement_LKIM_new_lkim_user" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS Daftar Pengguna Baru LKIM</title>
    <link href="../../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table style="width: 570px">
            <tr>
                <td colspan="3">
                    <strong><span style="font-size: 10pt; font-family: Arial Black">PENGURUSAN HAK AKSES
                        LKIM</span></strong></td>
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
                    <strong>Maklumat Hak Akses Baru</strong></td>
            </tr>
            <tr>
                <td style="width: 239px">
                    <strong>Group Name</strong></td>
                <td style="width: 424px">
                    <asp:TextBox ID="id_pegawai" runat="server" Width="65px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 239px; height: 15px">
                    <strong>Hak Akses</strong></td>
                <td style="width: 424px; height: 15px">
                    <asp:DropDownList ID="hak_akses" runat="server">
                        <asp:ListItem>Sila Buat Pilhan</asp:ListItem>
                        <asp:ListItem>Pintu Masuk</asp:ListItem>
                        <asp:ListItem>Pengisytiharan Import</asp:ListItem>
                        <asp:ListItem>Pengisytiharan Eksport</asp:ListItem>
                        <asp:ListItem>Pemeriksaan Import</asp:ListItem>
                        <asp:ListItem>Pemeriksaan Eksport</asp:ListItem>
                        <asp:ListItem>Pembayaran</asp:ListItem>
                        <asp:ListItem>Pintu Keluar</asp:ListItem>
                        <asp:ListItem>Pengisytiharan caj lain</asp:ListItem>
                        <asp:ListItem>Update Pintu Masuk</asp:ListItem>
                        <asp:ListItem>Menyunting Maklumat</asp:ListItem>
                        <asp:ListItem>Keselamatan</asp:ListItem>
                        <asp:ListItem>Pemantauan</asp:ListItem>
                       <asp:ListItem>Laporan</asp:ListItem>                                         
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="color: white; background-color: royalblue; height: 20px;">
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
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="hak_akses"
            Display="None" ErrorMessage="ID Pegawai"></asp:RequiredFieldValidator>
        &nbsp; &nbsp;&nbsp;<br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Maklumat Berikut Wajib Diisi "
            ShowMessageBox="True" ShowSummary="False" />
    </form>
</body>
</html>
