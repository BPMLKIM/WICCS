<%@ Page Language="VB" AutoEventWireup="false" CodeFile="changed_password.aspx.vb" Inherits="UserManagement_LKIM_new_lkim_user"%>

<html>
<head>
    <title>Untitled Document</title> 
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/stylesheet.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <strong>
            <br />
            Change
        Password</strong> 
        <!--
        <strong>&nbsp;APPLICATION FORMS : </strong><strong><font color="#ff0000">Membership
        Utilities </font></strong>
        <br />
        &nbsp;<font color="#ff0000"><strong>Change Password</strong></font> 
        <br />
        <br />
        <table bordercolor="#000000" cellspacing="1" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td bgcolor="<%=bcolor%>" height="20">
                        <strong><font color="#ffffff">&nbsp;Change Password</font></strong></td>
                </tr>
            </tbody>
        </table>
        -->
        <br />
        <br />
        <table cellspacing="0" cellpadding="2" width="100%" border="1">
            <tbody>
                <tr>
                    <td bgcolor="#ffffcc">
                        <strong>Please Note</strong>: To better protect your account, make sure that your
                        password is memorable to you but difficult for other users to guess. Do not share
                        your password with anyone, and never use the same password which you have used in
                        the past. For security purposes, your password must be of a minimum of eight characters
                        long. A strong password contains a combination of uppercase and lowercase letters
                        (remember that your password is case sensitive), numbers, and special characters such
                        as +, ?, and *.</td>
                </tr>
            </tbody>
        </table>
        <br />
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td width="40%">
                        &nbsp;User ID</td>
                    <td width="60%">
                        :&nbsp; 
                        <asp:TextBox id="loginid" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;Enter your <strong>Current Password</strong></td>
                    <td>
                        :&nbsp; 
                        <asp:TextBox id="oldpassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Current password are required" ControlToValidate="oldpassword"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp; 
                    </td>
                    <td>
                        &nbsp; 
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;Enter a <strong>New Password</strong></td>
                    <td>
                        :&nbsp; 
                        <asp:TextBox id="newpassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="New password are required" ControlToValidate="newpassword"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;Confirm your <strong>New Password</strong></td>
                    <td>
                        :&nbsp; 
                        <asp:TextBox id="confirmpassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Confirm new password are required" ControlToValidate="confirmpassword"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp; 
                    </td>
                    <td>
                        &nbsp; 
                    </td>
                </tr>
            </tbody>
        </table>
        <hr size="1" />
        <asp:Button id="submit" onclick="submit_Click" runat="server" CssClass="button" Text="Save"></asp:Button>
        <asp:Button id="returns" onclick="return_Click" runat="server" CssClass="button" Text="Back" Visible="False"></asp:Button>
    </form>
</body>
</html>
