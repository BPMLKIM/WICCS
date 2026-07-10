<%@ Page Language="VB" AutoEventWireup="false" CodeFile="edit_lkim_user.aspx.vb" Inherits="UserManagement_LKIM_edit_lkim_user" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS Kemaskini Maklumat Pengguna LKIM</title>
    <link href="../../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 570px">
            <tr>
                <td colspan="3">
                    <strong><span style="font-size: 10pt; font-family: Arial Black">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        PENGURUSAN PENGGUNA
                        LKIM - Kemaskini Maklumat Pengguna</span></strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 15px">
                </td>
            </tr>
        </table>
    
    </div>
        <table style="width: 100%">
            <tr>
                <td colspan="2" height="20" style="color: white; background-color: royalblue">
                    <strong>Maklumat Pengguna Baru</strong></td>
            </tr>
            <tr>
                <td style="width: 164px">
                    <strong>ID Pegawai</strong>
                </td>
                <td style="width: 424px">
                    <asp:TextBox ID="id_pegawai" runat="server" Width="65px" MaxLength="20" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 164px">
                    <strong>Nama Pegawai</strong></td>
                <td style="width: 424px">
                    <asp:TextBox ID="nama_pegawai" runat="server" Width="231px" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 164px; height: 23px;">
                    <strong>Gelaran</strong></td>
                <td style="width: 424px; height: 23px;">
                    <asp:TextBox ID="gelaran" runat="server" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 164px; height: 14px">
                    <strong>Jawatan</strong></td>
                <td style="width: 424px; height: 14px">
                    <asp:TextBox ID="jawatan" runat="server" Width="232px" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 164px">
                    <strong>ID Pengguna</strong></td>
                <td style="width: 424px">
                    <asp:TextBox ID="kata_pengguna" runat="server" MaxLength="20" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr id="kataLaluan" style="display:<%=display%>">
                <td style="width: 164px; height: 15px">
                    <strong style="color: red">Kata Laluan Baru Pengguna</strong></td>
                <td style="width: 424px; height: 15px">
                    <asp:TextBox ID="kata_laluan" runat="server" MaxLength="20" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 164px; height: 15px">
                    <strong>Hak Akses</strong></td>
                <td style="width: 424px; height: 15px">
                    <asp:DropDownList ID="hak_akses" runat="server" DataSourceID="accessGroup" DataTextField="group_name" DataValueField="group_id">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 15px">
                    <asp:CheckBox ID="resetPassword" runat="server" Font-Bold="True" Text="Reset Kata Laluan  "
                        TextAlign="Left" Width="372px" /></td>
            </tr>
            <tr>
                <td colspan="2" style="color: white; background-color: royalblue" height="20">
                </td>
            </tr>
        </table>
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="NewUser" ConfirmText="Adakah anda pasti ingin mengemaskini maklumat pengguna berikut?">
        </cc1:ConfirmButtonExtender>
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="Button1" ConfirmText="Adakah and pasti ingin menghapuskan maklumat pengguna berikut?">
        </cc1:ConfirmButtonExtender>
        <asp:SqlDataSource ID="accessGroup" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
                        SelectCommand="SELECT [group_id], [group_name] FROM [group]">
                    </asp:SqlDataSource>
        &nbsp;<br />
        &nbsp;<asp:Button ID="NewUser" runat="server"
            Style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
            background-color: #f1f1f1" Text="Kemaskini Maklumat Pengguna" />
        <asp:Button ID="Button1" runat="server" 
            Style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
            background-color: #f1f1f1" Text="Hapus Maklumat Pengguna" />
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
