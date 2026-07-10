<?xml version="1.0" encoding="iso-8859-1"?><%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>WICCS - Lembaga Kemajuan Ikan Malaysia</title>
	 <link href="css/bhea2.css" type="text/css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
  <SCRIPT LANGUAGE="JavaScript">
var theImages = new Array()

//Random-loading images
theImages[0] = 'image/59.gif' // replace with names of images
theImages[1] = 'image/67.gif' // replace with names of images
//theImages[2] = 'images/banner3.jpg' // replace with names of images
//theImages[3] = 'images/banner4.jpg' // replace with names of images
//theImages[4] = 'images/banner5.jpg' // replace with names of images
//theImages[5] = 'images/banner6.jpg' // replace with names of images
//theImages[6] = 'images/banner7.jpg' // replace with names of images

var j = 0
var p = theImages.length;
var preBuffer = new Array()

for (i = 0; i < p; i++){
preBuffer[i] = new Image()
preBuffer[i].src = theImages[i]
}
var whichImage = Math.round(Math.random()*(p-1));

function showImage(){
if(whichImage==0){
document.write('<img src="'+theImages[whichImage]+'"></a>');
}
else if(whichImage==1){
document.write('<img src="'+theImages[whichImage]+'"></a>');
}
else if(whichImage==2){
document.write('<img src="'+theImages[whichImage]+'"</a>');
}
else if(whichImage==3){
document.write('<img src="'+theImages[whichImage]+'"></a>');
}
else if(whichImage==4){
document.write('<img src="'+theImages[whichImage]+'"></a>');
}
else if(whichImage==5){
document.write('<img src="'+theImages[whichImage]+'"></a>');
}
else if(whichImage==6){
document.write('<img src="'+theImages[whichImage]+'"></a>');
}
else if(whichImage==7){
document.write('<img src="'+theImages[whichImage]+'"></a>');
}
}

</script>
</head>
<body background="image/55.gif" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<form id="form1" runat="server">
    
  <div> </div>
  <div align="center"> 
    <table width="1024" border="0" cellspacing="0" cellpadding="0">
      <tr> 
        <td width="25%"><img src="image/53.gif" width="262" height="81" /></td>
        <td width="75%"><img src="image/54.gif" width="762" height="81" /></td>
      </tr>
    </table>
    <table width="1024" border="0" cellspacing="0" cellpadding="0">
      <tr> 
        <td width="261" height="178" valign="top"><br /> <br /> <img src="image/56.gif" width="262" height="14" /><br /> 
          <br /> <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr> 
              <td width="319"><div align="right"><img src="image/10.jpg" width="94" height="23" /> 
                </div></td>
              <td width="253"><asp:TextBox ID="LoginId" runat="server"></asp:TextBox></td>
            </tr>
            <tr> 
              <td> <div align="right"><img src="image/11.jpg" width="82" height="23" /></div></td>
              <td><asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr> 
              <td colspan="2" style="height: 20px"> </td>
            </tr>
            <tr> 
              <td colspan="2" style="height: 20px"> <div align="center">&nbsp; 
                  &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                  <asp:Button ID="Button_masuk" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Enter" />
                  <asp:Button ID="reset" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Reset" />
                </div></td>
            </tr>
          </table></td>
        <td width="763" valign="top"> <div align="left">
            <script>showImage();</script>
          </div></td>
      </tr>
    </table>
    <table width="1024" border="0" cellspacing="0" cellpadding="0">
      <tr> 
        <td width="25%" height="328" valign="top"><img src="image/57.gif" width="262" height="17" /><br /> 
          <br /> <table bordercolor="#333333" cellspacing="0" cellpadding="0" width="100%" 
      border="0">
            <tbody>
              <tr> 
                <td width="6%">&nbsp;</td>
                <td width="92%"><script type="text/javascript">

/***********************************************
* Pausing updown message scroller- © Dynamic Drive DHTML code library (www.dynamicdrive.com)
* This notice MUST stay intact for legal use
* Visit Dynamic Drive at http://www.dynamicdrive.com/ for full source code
***********************************************/

//configure the below five variables to change the style of the scroller
var scrollerdelay='5000' //delay between msg scrolls. 3000=3 seconds.
var scrollerwidth='262px'
//var scrollerheight='95px'
var scrollerheight='100px'
var scrollerbgcolor=''
//set below to '' if you don't wish to use a background image
var scrollerbackground='scrollerback.gif'

//configure the below variable to change the contents of the scroller
var messages=new Array()
messages[0]="<font face='default' size='1'>Lembaga Kemajuan Ikan Malaysia (LKIM) ialah sebuah Badan Berkanun yang ditubuhkan pada 1 November, 1971 di bawah Akta 49, Akta Lembaga Kemajuan Ikan Malaysia, 1971.</font>"
messages[1]="<font face='default' size='1'>Ibu Pejabat LKIM Beroperasi Di : Lembaga Kemajuan Ikan Malaysia, Tingkat 10, Menara Olympia No. 8, Jln. Raja Chulan, 50200 Kuala Lumpur. Tel:03-2617 7000 Faks: 03- 2691 1931 Teleks: IKAN MA 30054.</font>"
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

</td>
                <td width="2%">&nbsp;</td>
              </tr>
            </tbody>
          </table>
          <div align="center"><br />
            <br />
            <img src="image/58.gif" width="237" height="109" border="0" usemap="#Map" /> 
          </div></td>
        <td width="48%" valign="top"><br /> <img src="image/61.gif" width="89" height="14" /><br /> 
          <br /> 
          <table width="480" border="0" cellspacing="0" cellpadding="0">
            <tr> 
              <td width="32%" height="89" valign="top"><img src="image/65.gif" width="150" height="89" /></td>
              <td width="68%" valign="top"><div align="justify"><strong><font face="Verdana, Arial, Helvetica, sans-serif">Masalah 
              Projek Jeti LKIM Di Kuala Selangor Yang Tergendala Selesai</font></strong><br />
                    KUALA SELANGOR, 5 Sept (Bernama) -- Projek jeti pendaratan ikan Lembaga Kemajuan Ikan
                    Malaysia (LKIM) di Kuala Selangor bernilai RM22 juta yang tergendala sejak lima tahun lepas
                    kerana bantahan penduduk dan Penganut Dewa Sei Ling telah mencapai jalan penyelesaian
                    hari ini.
                    Menteri Pembangunan Usahawan dan Koperasi Datuk Noh Omar mengadakan pertemuan
                    dengan anggota jawatankuasa persatuan penganut tersebut serta empat pemilik rumah yang
                    terlibat dalam pembangunan projek jeti berkenaan.
                    Tapak projek tersebut seluas 0.1 hektar dan terletak di Jalan Tokong Bagan di Pasir
                    Penambang, di sini.
                    Persatuan tersebut yang mendirikan tokong mereka di situ dan pemilik rumah berkenaan yang
                    pada mulanya membantah untuk berpindah, tetapi menerusi hasil rundingan yang mengambil
                    kira sensitiviti agama dan kependudukan pemilik rumah yang melebihi 20 tahun, satu keputusan
                    menang-menang akhirnya dicapai.
                    </div></td>
            </tr>
            <tr> 
              <td height="13" colspan="2" valign="top"><div align="justify"> <br />
                    "Kita telah dapat persetujuan tokong untuk dipindahkan di hujung di kawasan projek dan saya
                    turut minta LKIM memberi sedikit tapak baru kepada empat buah rumah ini," kata Noh.
                    Tokong berkenaan yang terletak di dalam kawasan Parlimen Tanjong Karang telah didirikan
                    sejak enam tahun lepas dan ia dikunjungi oleh penganutnya setiap hari. Persatuan Penganut
                    Dewa Sei Ling mempunyai ahli seramai 30,000 orang di seluruh negara.
                    Noh yang juga Anggota Parlimen Tanjong Karang berkata kos pemindahan tokong dan
                    penduduk adalah di bawah tanggungan masing-masing tetapi beliau difahamkan LKIM akan
                    memberikan sedikit pampasan dan para kontraktor yang terlibat dalam projek jeti tersebut boleh
                    turut menyumbang sebanyak RM10,000 seorang kepada mereka yang terlibat.
                    Beliau berkata projek jeti tersebut mampu memberi faedah kepada nelayan sebagai pelantar
                    pendaratan ikan, restoran dan aktiviti agropelancongan.
                     </div></td>
            </tr>
          </table>  <br />
          <br />
          <img src="image/62.gif" width="90" height="14" /> <br />
          <br />
          <br />
          <br />
        </td>
        <td width="0%" valign="top" background="image/66.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td><img src="image/63.gif" width="10" height="327" /></td>
            </tr>
          </table></td>
        <td width="27%" valign="top"><div align="justify"><br />
            <img src="image/64.gif" width="60" height="16" /> <br />
            <br />
            - <a href="http://www.bharian.com.my/Joran/JoranBH/Berita/20060721112958/joranews_html" target="_blank">LKIM-GP 
            Joran La Tour D&#8217; Pancing , 21 July 2006</a><br />
            - Family Day<br />
            <br />
            <br />
            <br />
          </div></td>
      </tr>
    </table>
    <table width="1024" border="0" cellspacing="0" cellpadding="0">
      <tr> 
        <td><img src="image/60.gif" width="1024" height="65" /></td>
      </tr>
    </table>
  </div>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LoginId"
        Display="None" ErrorMessage="Nama Pengguna"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password"
        Display="None" ErrorMessage="Kata Laluan"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Maklumat Berikut Wajib Diisi"
        ShowMessageBox="True" ShowSummary="False" />
    </form>
<map name="Map" id="Map">
  <area shape="rect" coords="102,67,196,80" href="http://www.lkim.gov.my" target="_blank" />
</map>
</body>
</html>
