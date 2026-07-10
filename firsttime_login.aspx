<%@ Page Inherits="firsttime_login" Src="firsttime_login.aspx.vb" Language="VB" EnableSessionState="True" %>
<html>
<head>
    <title>Untitled Document</title> 
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
   </head>
<body leftmargin="0" topmargin="0" marginheight="0" marginwidth="0">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr> 
    <td width="15%"><img src="image/44.gif" width="847" height="213"></td>
    <td width="61%" background="image/42.gif">&nbsp;</td>
  </tr>
</table>
<table cellspacing="5" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr>
                <td>
                    <form id="form1" runat="server">
          <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
              <tr> 
                <td width="293" style="width: 235px"> <font size="2" face="Arial, Helvetica, sans-serif">Kata 
                  Pengguna</font></td>
                <td width="755"> :&nbsp; <asp:TextBox id="loginid" runat="server" CssClass="textbox" Enabled="False" ReadOnly="True"></asp:TextBox> 
                </td>
              </tr>
              <tr> 
                <td style="width: 235px"> <font size="2" face="Arial, Helvetica, sans-serif">Sila 
                  Masukkan <strong>Kata Laluan Semasa</strong></font></td>
                <td> :&nbsp; <asp:TextBox id="oldpassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox> 
                  <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Current password are required" ControlToValidate="oldpassword" Display="None"></asp:RequiredFieldValidator> 
                </td>
              </tr>
              <tr> 
                <td style="width: 235px"> <font size="2" face="Arial, Helvetica, sans-serif"><br />
                  <br />
                  <strong>Create New Password </strong></font></td>
                <td>&nbsp; </td>
              </tr>
              <tr> 
                <td style="width: 235px"><font size="2" face="Arial, Helvetica, sans-serif"> 
                  Sila Masukkan <strong>Kata Laluan Baru</strong></font></td>
                <td> :&nbsp; <asp:TextBox id="newpassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox> 
                  <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="New password are required" ControlToValidate="newpassword" Display="None"></asp:RequiredFieldValidator> 
                </td>
              </tr>
              <tr> 
                <td style="width: 235px"><font size="2" face="Arial, Helvetica, sans-serif"> 
                  Sila Masukkan Semula <strong>Kata Laluan Baru</strong></font></td>
                <td> :&nbsp; <asp:TextBox id="confirmpassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox> 
                  <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Confirm new password are required" ControlToValidate="confirmpassword" Display="None"></asp:RequiredFieldValidator> 
                </td>
              </tr>
              <tr> 
                <td style="width: 235px">&nbsp; </td>
                <td> &nbsp; <asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary> 
                </td>
              </tr>
            </tbody>
          </table>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    
                <td> <strong><font size="1" face="Verdana, Arial, Helvetica, sans-serif">Please 
                  Note: </font></strong><font size="1" face="Arial, Helvetica, sans-serif"><br />
                  To better protect your account, make sure that your password 
                  is memorable for you but difficult for others to guess. Do not 
                  share your password with anyone, and never use the same password 
                  that you've used in the past. For security purposes, your new 
                  password must be a minimum of eight characters long. A strong 
                  password contains a combination of uppercase and lowercase letters 
                  (remember that your password is case sensitive), numbers, and 
                  special characters such as +, ?, and *.</font></td>
                                </tr>
                            </tbody>
                        </table>
                        
          <br>
          <img src="image/backend4.gif" width="460" height="26"> <br />
                        <asp:Button id="submit" onclick="submit_Click" runat="server" CssClass="button" Text="Proceed"></asp:Button>
                    </form>
                </td>
            </tr>
        </tbody>
    </table>
    <strong></strong>
</body>
</html>
