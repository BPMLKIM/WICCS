<%@ Page Language="VB" AutoEventWireup="false" CodeFile="newCajIkanCompanyEksport.aspx.vb" Inherits="suntinganmaklumat_newCajIkanCompanyEksport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" src="popcalendar.js" type="text/javascript"></script>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<script type="text/javascript" language="javascript">
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

function selectedDropDown()
{   
    var found = 0;
    var searchKod = document.all.kodImporter.value;
    for (i=0; i<document.all.Importer.options.length;i++)
    {
       if(document.all.Importer.options[i].value == searchKod)
       { 
        found=1;
        document.all.Importer.options[i].selected = true;
        //document.form1.submit();
        break;        
       }       
    }
    if (found==0)
    {
       alert("Kod Pengimport Tidak Ditemui !!!");
       document.all.kodImporter.value="";
       document.all.kodImporter.focus();
    }
    
}
</script>
<body>
    <form id="form1" runat="server">
    <div>
      <table style="width: 95%" border="0">
                    
                    <tr>
                        <td colspan="2" style="height: 15px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; color: white; background-color: royalblue;">
                            <strong>&nbsp;PENGURANGAN CAJ IKAN BARU</strong></td>
                    </tr>
                    <tr>
                    <td style="width: 197px">&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
          <tr>
              <td style="width: 197px">
                  &nbsp;<strong>Kod Agen Pengeksport</strong></td>
              <td>
                  :<asp:TextBox ID="kodImporter" runat="server" Width="91px"></asp:TextBox></td>
          </tr>
          <tr>
              <td style="width: 197px">
                  <strong>&nbsp;Senarai Pengeksport</strong></td>
              <td>
                  :<asp:DropDownList ID="Importer" runat="server" AppendDataBoundItems="True" DataSourceID="SenaraiPengimport"
                      DataTextField="Nama_Syarikat_eksport" DataValueField="Kod_Pengeksport">
                      <asp:ListItem Value="">Sila Pilih</asp:ListItem>
                  </asp:DropDownList></td>
          </tr>
                    <tr>
                        <td style="width: 197px">
                            <strong>&nbsp;Jenis Urusan</strong></td>
                        <td>
                            :<asp:DropDownList ID="jenisUrusan" runat="server" DataSourceID="JenisUrusanSrc"
                                DataTextField="Nama_Urusan" DataValueField="Kod_Urusan">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 197px">
                            <strong>&nbsp;Kategori Ikan</strong></td>
                        <td>
                            :<asp:DropDownList ID="kategoriIkan" runat="server" DataSourceID="kategoriIkanSrc" DataTextField="Nama_Kategori_Ikan" DataValueField="Kod_Kategori_Ikan">
                            </asp:DropDownList>&nbsp;
                            </td>
                       
                        
                    </tr>
                   <%-- <tr>
                        <td style="width: 197px">
                            <strong>&nbsp;Kod  Ikan</strong></td>
                                            
                            <td>  :<asp:TextBox ID="TextBox2" runat="server" Width="91px" ReadOnly="True">11000000</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 197px">
                            <strong>&nbsp;Jenis Ikan</strong></td>
                      
                        <td>:<asp:DropDownList ID="jenisIkan" runat="server" DataSourceID="jenisIkanSrc" DataTextField="Nama_BKH" DataValueField="Kod_Ikan">
                        
                        </asp:DropDownList>
                            </td>
                    </tr>--%>
                    <tr>
                        <td style="width: 197px">
                            <strong>&nbsp;Kadar Peti Kecil</strong></td>
                        <td>
                            : <strong>RM</strong>
                            <asp:TextBox ID="pk" runat="server" Width="56px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 15px; width: 197px;">
                            <strong>&nbsp;Kadar Peti Besar</strong></td>
                        <td style="height: 15px">
                            : <strong>RM</strong>
                            <asp:TextBox ID="pb" runat="server" Width="56px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 197px">
                            <strong>&nbsp;Kadar Ekor</strong></td>
                        <td>
                            : <strong>RM</strong>
                            <asp:TextBox ID="ekor" runat="server" Width="56px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 197px">
                            <strong>&nbsp;Kadar Kuantiti</strong></td>
                        <td>
                            : <strong>RM</strong>
                            <asp:TextBox ID="kk" runat="server" Width="56px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 197px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 197px; height: 23px;">
                            <strong>&nbsp;Tarikh Mula Penguatkuasaan</strong></td>
                        <td style="height: 23px">
                            :
                            <asp:TextBox ID="tarikhKuatKuasa" runat="server" EnableViewState="False" Width="70px"></asp:TextBox><input id="calender2" runat="server" class="textbox" name="choose2" onclick="popUpCalendar(this, tarikhKuatKuasa, 'dd/mm/yyyy')"
                                style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
                                width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
                                border-left-style: none; height: 18px; background-color: white; border-right-color: white;
                                border-bottom-style: none" type="button" value=" " visible="true"  />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 197px">
                            <strong>&nbsp;Tarikh Akhir Penguatkuasaan</strong></td>
                        <td>
                            :
                            <asp:TextBox ID="tarikhAkhir" runat="server" EnableViewState="False" Width="70px"></asp:TextBox><input id="Button3" runat="server" class="textbox" name="choose2" onclick="popUpCalendar(this, tarikhAkhir, 'dd/mm/yyyy')"
                                style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
                                width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
                                border-left-style: none; height: 18px; background-color: white; border-right-color: white;
                                border-bottom-style: none" type="button" value=" " visible="true"  />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;<asp:Button ID="Simpan" runat="server" Style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        Text="Simpan" Width="130px"  />
                            <asp:Button ID="Batal" runat="server" Style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        Text="Batal" Width="130px"  /></td>
                    </tr>
                </table>
                
                
                    <br />
                    <br />
                    
        &nbsp;
          
          
            
            <asp:SqlDataSource ID="kategoriIkanSrc" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
              SelectCommand="SELECT [Kod_Kategori_Ikan], [Nama_Kategori_Ikan] FROM [KATEGORI_IKAN]">
              </asp:SqlDataSource>

            <asp:SqlDataSource ID="JenisUrusanSrc" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Kod_Urusan], [Nama_Urusan] FROM [JENIS_URUSAN]"></asp:SqlDataSource>

            <asp:SqlDataSource ID="SenaraiPengimport" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT RTRIM([Kod_Pengeksport]) as Kod_Pengeksport, [Nama_Syarikat_eksport] FROM [PENGEKSPORT]">
            </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>

<%--<script language="javascript">
function getStrength()
{
 var ddl = document.getElementById("<%=kategoriIkan.ClientID%>");
    var i = ddl.options[ddl.selectedIndex].value;
    var tb = document.getElementById("<%=textbox1.ClientID%>");
    tb.value = i;
    
   
   
     
}

function getStrength1()
{
 
    
    var ddl1 = document.getElementById("<%=jenisIkan.ClientID%>");
    var i1 = ddl1.options[ddl1.selectedIndex].value;
    var tb1= document.getElementById("<%=textbox2.ClientID%>");
    tb1.value = i1;
   
     
}

</script> --%>

