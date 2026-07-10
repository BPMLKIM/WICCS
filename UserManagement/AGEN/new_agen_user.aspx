<%@ Page Language="VB" AutoEventWireup="false" CodeFile="new_agen_user.aspx.vb" Inherits="UserManagement_LKIM_new_lkim_user" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS Daftar Pengguna Baru LKIM</title>
    <link href="../../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 570px">
            <tr>
                <td colspan="3">
                    <strong><span style="font-size: 10pt; font-family: Arial Black">PENGURUSAN PENGGUNA
                        AGEN - Daftar Baru</span></strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 15px">
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        <table style="width: 100%">
            <tr>
                <td colspan="2" height="20" style="color: white; background-color: royalblue">
                    <strong>Maklumat Pengguna Baru</strong></td>
            </tr>
            <tr>
                <td style="width: 164px">
                    <strong>Agen Pengangkutan <span style="color: blue">*</span></strong></td>
                <td style="width: 424px">
                    <asp:DropDownList ID="Agen" runat="server" DataSourceID="agenSrc" DataTextField="Nama_Agen_Pengangkutan"
                        DataValueField="Kod_Agen_Pengangkutan">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 164px">
                    <strong>Nama Penuh Pengguna <span style="color: blue">*</span></strong></td>
                <td style="width: 424px">
                    <asp:TextBox ID="nama" runat="server" MaxLength="50" Width="231px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 164px; height: 14px">
                    <strong>Jawatan <span style="color: blue">*</span></strong></td>
                <td style="width: 424px; height: 14px">
                    <asp:TextBox ID="jawatan" runat="server" MaxLength="50" Width="232px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 164px; height: 23px">
                    <strong>Alamat Email </strong></td>
                <td style="width: 424px; height: 23px">
                    <asp:TextBox ID="email" runat="server" MaxLength="50" Width="232px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 164px; height: 23px">
                    <strong><span>No. Untuk Di hubungi <span style="color: blue">*</span></span></strong></td>
                <td style="width: 424px; color: #ff0000; height: 23px">
                    <asp:TextBox ID="contact_no" runat="server" MaxLength="50" Width="131px"></asp:TextBox></td>
            </tr>
            <tr style="color: #ff0000">
                <td style="width: 164px; height: 23px">
                    <strong>ID Pengguna <span style="color: blue">*</span></strong></td>
                <td style="width: 424px; height: 23px">
                    <asp:TextBox ID="kata_pengguna" runat="server" MaxLength="20"></asp:TextBox></td>
            </tr>
            <tr id="kataLaluan" style="display:<%=display%>">
                <td style="width: 164px; height: 15px">
                    <span style="color: #000000"><strong style="color: red">Kata Laluan Pengguna</strong></span></td>
                <td style="width: 424px; color: #000000; height: 15px">
                    <asp:TextBox ID="kata_laluan" runat="server" MaxLength="20" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 164px; height: 15px">
                    <strong>Jenis Pengguna <span style="color: blue">*</span></strong></td>
                <td style="width: 424px; height: 15px">
                    <asp:DropDownList ID="hak_akses" runat="server" DataSourceID="accessGroup" DataTextField="description"
                        DataValueField="user_type">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 164px; height: 15px">
                    <strong>Status Pengguna <span style="color: blue">*</span></strong></td>
                <td style="width: 424px; height: 15px">
                    <asp:DropDownList ID="status" runat="server" DataSourceID="statusSrc" DataTextField="description" DataValueField="user_status">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 15px">
                    </td>
            </tr>
            <tr>
                <td colspan="2" height="20" style="color: white; background-color: royalblue">
                </td>
            </tr>
        </table>
        <br />
        &nbsp;<asp:Button ID="NewUser" runat="server"
            Style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
            background-color: #f1f1f1" Text="Simpan Daftar Pengguna" />
        <input id="Button3" onclick="location.href='list_users.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Papar Senarai Pengguna" />&nbsp;<br />
        &nbsp; &nbsp;
        <asp:SqlDataSource ID="statusSrc" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>" SelectCommand="SELECT [user_status], [description] FROM [user_status]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="agenSrc" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT RTRIM([Kod_Agen_Pengangkutan]) as [Kod_Agen_Pengangkutan], [Nama_Agen_Pengangkutan] FROM [AGEN_PENGANGKUTAN] ORDER BY [Nama_Agen_Pengangkutan]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="accessGroup" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [user_type], [description] FROM [user_type]"></asp:SqlDataSource>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email"
            Display="None" ErrorMessage="Alamat Email tidak sah" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Agen"
            Display="None" ErrorMessage="Agen Pengangkutan Wajib Diisi"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="nama"
            Display="None" ErrorMessage="Nama Penuh Wajib Diisi"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="kata_pengguna"
            ErrorMessage="Kata Pengguna Wajib Diisi" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="contact_no"
            ErrorMessage="No. Utk Dihubungi Wajib Diisi" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="jawatan"
            Display="None" ErrorMessage="Jawatan Wajib Diisi"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="hak_akses"
            Display="None" ErrorMessage="Jenis Pengguna Wajib Diisi"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="status"
            Display="None" ErrorMessage="Status Pengguna Wajib Diisi"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Input Error :-"
            ShowMessageBox="True" ShowSummary="False" />
        <cc1:confirmbuttonextender id="ConfirmButtonExtender1" runat="server" targetcontrolid="NewUser" ConfirmText="Adakah Anda Pasti Untuk Menyimpan Maklumat Berikut"></cc1:confirmbuttonextender>
    </form>
</body>
</html>
