<%@ Page UICulture="it-IT" Culture="it-IT" Language="VB" AutoEventWireup="false" CodeFile="tempoh_larangan_ikan_new.aspx.vb" Inherits="tempoh_larangan_ikan_new" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PERSONALIA Daftar Maklumat Peribadi</title>
         <link rel="stylesheet" href="windowfiles/dhtmlwindow.css" type="text/css" />
        <link href="css/bhea2.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="popcalendar.js" type="text/javascript"></script>
     
</head>
<script type="text/javascript" src="windowfiles/dhtmlwindow.js">
</script>
<script type="text/javascript" language="javascript">


var agenwin;



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
<%
    
 %>
 
<body>
    <form id="form1" runat="server">
    
  <div> 
    <table border="0" cellpadding="0" cellspacing="0" width="938">
      <tr> 
        <td width="27%" style="height: 13px; font-weight: bold;">MODUL  MENYUNTING MAKLUMAT</td>
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
      
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
      <tr>
              <td colspan="2">
                  <font color="#333333"><strong> Daftar MaklumatTempoh Larangan Ikan</strong></font></td>
              <td colspan="1" style="width: 182px">
              </td>
          </tr>
         
          <tr>
              <td style="width: 220px; height: 19px;">&nbsp;
                  </td>
              <td style="width: 305px; height: 19px;">&nbsp;
                  </td>
              <td style="width: 182px; height: 19px;">
              </td>
          </tr>
                 
            
            <tr>
            <td style="width: 220px" >
                    Tarikh Mula :</td>
            <td style="width: 305px">
                    <asp:TextBox ID="t_mula" runat="server" Width="80px"></asp:TextBox>
            <input
            id="Button7" runat="server" class="textbox" name="choose2" onclick="popUpCalendar(this, t_mula, 'dd/mm/yyyy')"
            style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
            width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
            border-left-style: none; height: 18px; background-color: white; border-right-color: white;
            border-bottom-style: none" type="button" value=" " visible="true" />
                (dd/mm/yyyy)</td>
                            
                           <td style="width: 182px" >
                               Tarikh Tamat :</td>
                <td style="height: 14px; width: 309px;">
                    <asp:TextBox ID="t_tamat" runat="server" Width="80px"></asp:TextBox><input
            id="Button2" runat="server" class="textbox" name="choose2" onclick="popUpCalendar(this, t_tamat, 'dd/mm/yyyy')"
            style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
            width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
            border-left-style: none; height: 18px; background-color: white; border-right-color: white;
            border-bottom-style: none" type="button" value=" " visible="true" />
                    (dd/mm/yyyy)</td>
              </tr>
        <tr>
            <td style="width: 182px">
                Catatan :</td>
            <td style="width: 309px; height: 14px">
                <asp:TextBox ID="catatan" runat="server" Width="232px" TextMode="MultiLine"></asp:TextBox></td>
            <td style="width: 182px">
                Link :</td>
            <td style="width: 309px; height: 14px">
                <asp:TextBox ID="link" runat="server" TextMode="MultiLine" Width="232px"></asp:TextBox></td>
        </tr>
            
                  
      </table>
    <br />
    <asp:Button ID="NewUser" runat="server" Style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            Text="Simpan" /><input id="Button1" onclick="location.href='tempoh_larangan_ikan.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Papar/Kembali" />&nbsp;<br />
       <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textbox1"
            Display="None" ErrorMessage="no pekerja"></asp:RequiredFieldValidator>--%>
      &nbsp; &nbsp;
        &nbsp;&nbsp;<br />
        
    
    </div>
    </form>
</body>
</html>
