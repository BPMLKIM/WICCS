<%@ Page Inherits="par_bnm_firsttime_login" Src="par_bnm_firsttime_login.aspx.vb" Language="VB" EnableSessionState="True" %>
<html>
<head>
    <title>Untitled Document</title> 
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/stylesheet.css" type="text/css" rel="stylesheet" />
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr>
                
      <td> <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr> 
            <td width="15%"><img src="image/44.gif" width="847" height="213"></td>
            <td width="61%" background="image/42.gif">&nbsp;</td>
          </tr>
        </table></td>
            </tr>
        </tbody>
    </table>
    <table cellspacing="5" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr>
                <td>
                    <form id="form1" runat="server">
                        <strong><font color="#000000" size="3">FIRST TIME LOGIN&nbsp;&nbsp;&gt;</font></strong><font color="#000000" size="3">&nbsp;<strong>TUKAR
                            KATA LALUAN</strong></font>&nbsp;<br />
                        <br />
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td style="width: 235px">
                                        Kata Pengguna</td>
                                    <td width="81%">
                                        :&nbsp; 
                                        <asp:TextBox id="loginid" runat="server" CssClass="textbox" Enabled="False" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 235px">
                                        Sila Masukkan <strong>Kata Laluan Semasa</strong></td>
                                    <td>
                                        :&nbsp; 
                                        <asp:TextBox id="oldpassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Current password are required" ControlToValidate="oldpassword" Display="None"></asp:RequiredFieldValidator>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 235px">
                                        <br />
                                        <br />
                                        <font size="3"><strong>Create New Password </strong></font></td>
                                    <td>&nbsp;
                                         
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 235px">
                                        Sila Masukkan <strong>Kata Laluan Baru</strong></td>
                                    <td>
                                        :&nbsp; 
                                        <asp:TextBox id="newpassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="New password are required" ControlToValidate="newpassword" Display="None"></asp:RequiredFieldValidator>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 235px">
                                        Sila Masukkan Semula <strong>Kata Laluan Baru</strong></td>
                                    <td>
                                        :&nbsp; 
                                        <asp:TextBox id="confirmpassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Confirm new password are required" ControlToValidate="confirmpassword" Display="None"></asp:RequiredFieldValidator>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 235px">&nbsp;
                                         
                                    </td>
                                    <td>
                                        &nbsp; 
                                        <asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <strong>Please Note</strong>: 
                                        <br />
                                        To better protect your account, make sure that your password is memorable for you
                                        but difficult for others to guess. Do not share your password with anyone, and never
                                        use the same password that you've used in the past. For security purposes, your new
                                        password must be a minimum of eight characters long. A strong password contains a combination
                                        of uppercase and lowercase letters (remember that your password is case sensitive),
                                        numbers, and special characters such as +, ?, and *.</td>
                                </tr>
                            </tbody>
                        </table>
                        <br />
                        <br />
                        <asp:Button id="submit" onclick="submit_Click" runat="server" CssClass="button" Text="Proceed"></asp:Button>
                    </form>
                </td>
            </tr>
        </tbody>
    </table>
    <strong></strong>
</body>
</html>
