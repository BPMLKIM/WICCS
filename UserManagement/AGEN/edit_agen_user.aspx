<%@ Page Language="VB" AutoEventWireup="false" CodeFile="edit_agen_user.aspx.vb" Inherits="UserManagement_AGEN_edit_agen_user" %>

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
                        PENGURUSAN PENGGUNA AGEN - Kemaskini Maklumat Pengguna</span></strong></td>
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
                    <strong>Agen Pengangkutan <span style="color: #0000ff">*</span></strong></td>
                <td style="width: 424px">
                    <asp:DropDownList ID="Agen" runat="server" DataSourceID="agenSrc" DataTextField="Nama_Agen_Pengangkutan"
                        DataValueField="Kod_Agen_Pengangkutan" Enabled="False">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 164px">
                    <strong>Nama Penuh Pengguna <span style="color: #0000ff">*</span></strong></td>
                <td style="width: 424px">
                    <asp:TextBox ID="nama" runat="server" Width="231px" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 164px; height: 14px">
                    <strong>Jawatan <span style="color: #0000ff">*</span></strong></td>
                <td style="width: 424px; height: 14px">
                    <asp:TextBox ID="jawatan" runat="server" Width="232px" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 164px; height: 23px">
                    <strong>Alamat Email</strong></td>
                <td style="width: 424px; height: 23px">
                    <asp:TextBox ID="email" runat="server" MaxLength="50" Width="232px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 164px; height: 23px">
                    <strong>No. Untuk Di hubungi <span style="color: #0000ff">*</span></strong></td>
                <td style="width: 424px; height: 23px">
                    <asp:TextBox ID="contact_no" runat="server" MaxLength="50" Width="131px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 164px; height: 23px;">
                    <strong>ID Pengguna <span style="color: #0000ff">*</span></strong></td>
                <td style="width: 424px; height: 23px;">
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
                    <strong>Jenis Pengguna <span style="color: #0000ff">*</span></strong></td>
                <td style="width: 424px; height: 15px">
                    <asp:DropDownList ID="hak_akses" runat="server" DataSourceID="accessGroup" DataTextField="description" DataValueField="user_type">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 164px; height: 15px">
                    <strong>Status Pengguna <span style="color: #0000ff">*</span></strong></td>
                <td style="width: 424px; height: 15px">
                    <asp:DropDownList ID="status" runat="server" DataSourceID="statusSrc" DataTextField="description" DataValueField="user_status">
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
                        SelectCommand="SELECT [user_type], [description] FROM [user_type]">
                    </asp:SqlDataSource>
        <asp:SqlDataSource ID="agenSrc" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT RTRIM([Kod_Agen_Pengangkutan]) as [Kod_Agen_Pengangkutan] , [Nama_Agen_Pengangkutan] FROM [AGEN_PENGANGKUTAN] ORDER BY [Nama_Agen_Pengangkutan]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="statusSrc" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>" SelectCommand="SELECT [user_status], [description] FROM [user_status]"></asp:SqlDataSource>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email"
            Display="None" ErrorMessage="Alamat Email tidak sah" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ControlToValidate="Agen" Display="None"
                ErrorMessage="Agen Pengangkutan Wajib Diisi"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="nama" Display="None"
                    ErrorMessage="Nama Penuh Wajib Diisi"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="kata_pengguna"
                        Display="None" ErrorMessage="Kata Pengguna Wajib Diisi"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator5" runat="server" ControlToValidate="contact_no" Display="None"
                            ErrorMessage="No. Utk Dihubungi Wajib Diisi"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator6" runat="server" ControlToValidate="jawatan" Display="None"
                                ErrorMessage="Jawatan Wajib Diisi"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator7" runat="server" ControlToValidate="hak_akses" Display="None"
                                    ErrorMessage="Jenis Pengguna Wajib Diisi"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="status" Display="None"
                                        ErrorMessage="Status Pengguna Wajib Diisi"></asp:RequiredFieldValidator><asp:ValidationSummary
                                            ID="ValidationSummary1" runat="server" HeaderText="Input Error :-" ShowMessageBox="True"
                                            ShowSummary="False" />
        &nbsp;
        &nbsp;&nbsp;<br />
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
        &nbsp; &nbsp; &nbsp;&nbsp;
    </form>
</body>
</html>
