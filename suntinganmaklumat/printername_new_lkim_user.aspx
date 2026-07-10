<%@ Page Language="VB" AutoEventWireup="false" CodeFile="printername_new_lkim_user.aspx.vb" Inherits="UserManagement_LKIM_new_lkim_user" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS Daftar Pengguna Baru LKIM</title>
    <link href="css/bhea2.css" rel="stylesheet" type="text/css" />
     <script language="javascript" src="popcalendar.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    
  <div> 
    <table border="0" cellpadding="0" cellspacing="0" width="938">
      <tr> 
        <td width="27%" style="height: 13px">MODUL  MENYUNTING MAKLUMAT </td>
        <td width="73%" bgcolor="#006699" style="height: 13px">&nbsp;</td>
      </tr>
    </table>
    <table style="width: 570px">
            <tr>
                <td colspan="3">
                    <span style="font-size: 10pt; font-family: Arial Black">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <span style="font-family: Arial"></span></span>
                </td>
            </tr>
        </table>
      <br />
      <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
          <tr>
              <td colspan="2" style="height: 13px">
                  <font color="#333333"><strong>Maklumat Printer</strong></font></td>
          </tr>
          <tr>
              <td style="width: 79px">
              </td>
              <td style="width: 94px">
              </td>
          </tr>
          <tr>
              <td style="width: 79px">&nbsp;
                  </td>
              <td style="width: 94px">&nbsp;
                  </td>
          </tr>
          <tr>
              <td style="width: 79px">
                  Printer Name</td>
              <td style="width: 94px">
                  <asp:TextBox ID="textbox1" runat="server" Width="200px"></asp:TextBox></td>
          </tr>
          <tr>
              <td style="width: 79px; height: 21px">
                  Owner</td>
              <td style="width: 94px; height: 21px">
                  <asp:TextBox ID="textbox2" runat="server" MaxLength="20" Width="200px"></asp:TextBox>&nbsp;
              </td>
          </tr>
          <tr>
              <td style="width: 79px">
                  Computer Name</td>
              <td style="width: 94px">
                  <asp:TextBox ID="TextBox3" runat="server" MaxLength="20" Width="200px"></asp:TextBox></td>
          </tr>
      </table>
     <br />
        &nbsp;<asp:Button ID="NewUser" runat="server" Style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            Text="Simpan" /><input id="Button1" onclick="location.href='printername.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Papar" />&nbsp;<br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textbox1"
            Display="None" ErrorMessage="kod spesis"></asp:RequiredFieldValidator>
      &nbsp; &nbsp;
        &nbsp;&nbsp;<br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Maklumat Berikut Wajib Diisi "
            ShowMessageBox="True" ShowSummary="False" />         
    </div>
    </form>
</body>
</html>
