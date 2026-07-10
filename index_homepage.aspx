<?xml version="1.0" encoding="iso-8859-1"?><%@ Page Language="VB" AutoEventWireup="true" CodeFile="index_homepage.aspx.vb" Inherits="index_homepage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LKIM Homepage</title>
	 <link href="css/bhea2.css" type="text/css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<form id="form1" runat="server">
    
  <div> 
    <div align="left">
      <table width="1024" border="0" cellspacing="0" cellpadding="0">
        <tr> 
          <td height="201"><img src="image/79.gif" width="1024" height="201" /></td>
        </tr>
      </table>
      <table width="1024" border="0" cellspacing="0" cellpadding="0">
        <tr> 
          <td width="254" height="494" valign="top" background="image/88.gif"> 
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr> 
                <td>&nbsp;</td>
              </tr>
            </table>
            <img src="image/89.gif" width="241" height="14" /><br />
            <br />
			 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                          <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                  <asp:ListItem>sila buat pilihan</asp:ListItem>
                  <asp:ListItem Value="01">Bukit Kayu Hitam</asp:ListItem>
              </asp:DropDownList>
              <br /> <br />
            <img src="image/90.gif" width="241" height="15" /><br />
            <br />
            <table bordercolor="#333333" cellspacing="0" cellpadding="0" width="100%" 
      border="0">
              <tbody>
                <tr> 
                  <td width="12%">&nbsp;</td>
                  <td width="86%"><font color="#FFFFFF">
                    <script type="text/javascript">

/***********************************************
* Pausing updown message scroller- © Dynamic Drive DHTML code library (www.dynamicdrive.com)
* This notice MUST stay intact for legal use
* Visit Dynamic Drive at http://www.dynamicdrive.com/ for full source code
***********************************************/

//configure the below five variables to change the style of the scroller
var scrollerdelay='5000' //delay between msg scrolls. 3000=3 seconds.
var scrollerwidth='200px'
//var scrollerheight='95px'
var scrollerheight='100px'
var scrollerbgcolor=''
//set below to '' if you don't wish to use a background image
var scrollerbackground='scrollerback.gif'

//configure the below variable to change the contents of the scroller
var messages=new Array()
messages[0]="<font face='arial' size='1'>Lembaga Kemajuan Ikan Malaysia (LKIM) ialah sebuah Badan Berkanun yang ditubuhkan pada 1 November, 1971 di bawah Akta 49, Akta Lembaga Kemajuan Ikan Malaysia, 1971.</font>"
messages[1]="<font face='arial' size='1'>Ibu Pejabat LKIM Beroperasi Di : Lembaga Kemajuan Ikan Malaysia, TKT.1,7,8,9,10, & 11, Wisma PKNS,  Jln. Raja Laut, 50784 Kuala Lumpur. Tel:03-2617 7000 Faks: 03- 2691 1931 Teleks: IKAN MA 30054.</font>"
///////Do not edit pass this line///////////////////////

var ie=document.all
var dom=document.getElementById

if (messages.length>2)
i=2
else
i=0

function move(whichdiv){
tdiv=eval(whichdiv)
if (parseInt(tdiv.style.top)>0&&parseInt(tdiv.style.top)<=5){
tdiv.style.top=0+"px"
setTimeout("move(tdiv)",scrollerdelay)
setTimeout("move2(second2_obj)",scrollerdelay)
return
}
if (parseInt(tdiv.style.top)>=tdiv.offsetHeight*-1){
tdiv.style.top=parseInt(tdiv.style.top)-5+"px"
setTimeout("move(tdiv)",50)
}
else{
tdiv.style.top=parseInt(scrollerheight)+"px"
tdiv.innerHTML=messages[i]
if (i==messages.length-1)
i=0
else
i++
}
}

function move2(whichdiv){
tdiv2=eval(whichdiv)
if (parseInt(tdiv2.style.top)>0&&parseInt(tdiv2.style.top)<=5){
tdiv2.style.top=0+"px"
setTimeout("move2(tdiv2)",scrollerdelay)
setTimeout("move(first2_obj)",scrollerdelay)
return
}
if (parseInt(tdiv2.style.top)>=tdiv2.offsetHeight*-1){
tdiv2.style.top=parseInt(tdiv2.style.top)-5+"px"
setTimeout("move2(second2_obj)",50)
}
else{
tdiv2.style.top=parseInt(scrollerheight)+"px"
tdiv2.innerHTML=messages[i]
if (i==messages.length-1)
i=0
else
i++
}
}

function startscroll(){
first2_obj=ie? first2 : document.getElementById("first2")
second2_obj=ie? second2 : document.getElementById("second2")
move(first2_obj)
second2_obj.style.top=scrollerheight
second2_obj.style.visibility='visible'
}

if (ie||dom){
document.writeln('<div id="main2" style="position:relative;width:'+scrollerwidth+';height:'+scrollerheight+';overflow:hidden;background-color:'+scrollerbgcolor+' ;background-image:url('+scrollerbackground+')">')
document.writeln('<div style="position:absolute;width:'+scrollerwidth+';height:'+scrollerheight+';clip:rect(0 '+scrollerwidth+' '+scrollerheight+' 0);left:0px;top:0px">')
document.writeln('<div id="first2" style="position:absolute;width:'+scrollerwidth+';left:0px;top:1px;">')
document.write(messages[0])
document.writeln('</div>')
document.writeln('<div id="second2" style="position:absolute;width:'+scrollerwidth+';left:0px;top:0px;visibility:hidden">')
document.write(messages[dyndetermine=(messages.length==1)? 0 : 1])
document.writeln('</div>')
document.writeln('</div>')
document.writeln('</div>')
}

if (window.addEventListener)
window.addEventListener("load", startscroll, false)
else if (window.attachEvent)
window.attachEvent("onload", startscroll)
else if (ie||dom)
window.onload=startscroll

</script>
                    </font></td>
                  <td width="2%">&nbsp;</td>
                </tr>
              </tbody>
            </table>
          </td>
          <td width="770" valign="top"><div align="left"> 
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr> 
                  <td height="333" valign="top"> 
                    <div align="center">
                      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td bgcolor="#999999"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td><img src="image/83.gif" width="769" height="20" /></td>
                              </tr>
                            </table></td>
                        </tr>
                      </table>
                      <div align="left"><img src="image/86.gif" width="764" height="337" /><br />
                        <img src="image/87.gif" width="457" height="103" /> </div>
                    </div></td>
                </tr>
              </table>
              <br />
            </div></td>
        </tr>
      </table>
      <table width="1024" border="0" cellspacing="0" cellpadding="0">
        <tr> 
          <td width="254" valign="top">&nbsp; </td>
          <td width="770" valign="top"><div align="left"> <img src="image/backend4.gif" width="460" height="26" /><br />
            </div></td>
        </tr>
      </table>
    </div>
  </div>
    </form>
</body>
</html>
