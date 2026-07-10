<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lesen_edit_lkim_user.aspx.vb" Inherits="UserManagement_LKIM_edit_lkim_user" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS Kemaskini Maklumat Pengguna LKIM</title>
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
                        <span style="font-family: Arial"></span></span></td>
            </tr>
        </table>
    
    <br />
  </div>
        
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td width="15%"><font color="#333333"><strong>Maklumat <span style="color: #000000"> 
        Lesen</span></strong></font></td>
      <td width="15%">&nbsp;</td>
      <td width="70%">&nbsp;</td>
    </tr>
    <tr> 
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr> 
      <td>No lesen</td>
      <td><asp:textbox ID="textbox1" runat="server" Width="200px"></asp:textbox></td>
      <td>&nbsp;</td>
    </tr>
    <tr> 
      <td>Tarikh tamat</td>
      <td><asp:textbox ID="textbox2" runat="server" Width="200px"></asp:textbox></td>
      <td><asp:textbox ID="TextBox6" runat="server" Width="200px"></asp:textbox>
        <input id="calender1" runat="server" class="TextBox" name="choose2" onclick="popUpCalendar(this, TextBox6, 'm/d/yyyy')"
                      style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
                      width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
                      border-left-style: none; height: 18px; background-color: white; border-right-color: white;
                      border-bottom-style: none" type="button" value=" " visible="true" /></td>
    </tr>
    <tr> 
      <td>Tarikh disah</td>
      <td><asp:textbox ID="TextBox3" runat="server" Width="200px"></asp:textbox></td>
      <td><asp:textbox ID="TextBox7" runat="server" Width="200px"></asp:textbox>
        <input id="calender2" runat="server" class="TextBox" name="choose2" onclick="popUpCalendar(this, TextBox7, 'm/d/yyyy')"
                      style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
                      width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
                      border-left-style: none; height: 18px; background-color: white; border-right-color: white;
                      border-bottom-style: none" type="button" value=" " visible="true" /></td>
    </tr>
    <tr> 
      <td>kawasan</td>
      <td><asp:textbox ID="TextBox4" runat="server" Width="200px"></asp:textbox></td>
      <td>&nbsp;</td>
    </tr>
    <tr> 
      <td>Siri lesen</td>
      <td><asp:textbox ID="TextBox5" runat="server" Width="200px"></asp:textbox></td>
      <td>&nbsp;</td>
    </tr>
  </table>
  <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="NewUser" ConfirmText="Adakah anda pasti ingin mengemaskini maklumat pengguna berikut?">
        </cc1:ConfirmButtonExtender>
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="Button1" ConfirmText="Adakah and pasti ingin menghapuskan maklumat pengguna berikut?">
        </cc1:ConfirmButtonExtender>
       <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
            FilterType="Custom,Numbers" TargetControlID="textbox2" ValidChars=",-.">
        </cc1:FilteredTextBoxExtender>
        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
            TargetControlID="TextBox3" ValidChars=",-.">
        </cc1:FilteredTextBoxExtender>
      
        <br />
        &nbsp;<asp:Button ID="NewUser" runat="server"
            Style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
            background-color: #f1f1f1" Text="Kemaskini" /><asp:Button ID="Button1" runat="server" 
            Style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
            background-color: #f1f1f1" Text="Hapus" /><input id="Button3" onclick="location.href='lesen.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Papar" />
</form>
</body>
</html>
