<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cajIkanCompanyEksport.aspx.vb" Inherits="suntinganmaklumat_cajIkanCompanyEksport" %>

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
        document.form1.submit();
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

<script language="javascript" type="text/javascript">
var preEl ;
var orgBColor;
var orgTColor;


function HighLightTR(backColor,textColor){  
if(typeof(preEl)!='undefined') {
preEl.bgColor=orgBColor; 
try{ChangeTextColor(preEl,orgTColor);}catch(e){;}
} 
var el = event.srcElement;
el = el.parentElement;
orgBColor = el.bgColor;
orgTColor = el.style.color;
el.bgColor=backColor;

try{ChangeTextColor(el,textColor);}catch(e){;}
preEl = el; 
}

function ChangeTextColor(a_obj,a_color){  ;
for (i=0;i<a_obj.cells.length;i++){//put condition before increase!!!!!
a_obj.cells(i).style.color=a_color; 
document.all.currentImporter.value=a_obj.cells(i).innerHTML;
}
}
</script>
<body>       
        <form id="form1" runat="server">
  <div> <br />
    <table border="0" cellpadding="0" cellspacing="0" width="938">
      <tr> 
        <td width="27%" style="height: 13px">M O D U L &nbsp;&nbsp;M E N Y U N 
          T I N G &nbsp;&nbsp;M A K L U M A T </td>
        <td width="73%" bgcolor="#006699" style="height: 13px">&nbsp;</td>
      </tr>
    </table>
    <br />
    <table style="width: 100%">
            <tr>
                <td colspan="1" style="height: 15px">
                    <strong><span style="font-size: 10pt; font-family: Arial Black">PENGURUSAN PENETAPAN
                        KADAR CAJ IKAN BAGI 
                        <br />
                        SYARIKAT-SYARIKAT TERTENTU.</span></strong></td>
            </tr>
        </table>   
    </div>      
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            &nbsp;&nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="width: 100%">
            <tr>
                <td style="width: 138px; height: 15px">
                </td>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 138px; height: 15px">
                    &nbsp;<strong>Kod Agen Pengeksport</strong></td>
                <td style="height: 15px">
                    <asp:TextBox ID="kodImporter" runat="server" Width="91px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 138px; height: 15px">
                    <strong>&nbsp;Senarai Pengeksport</strong></td>
                <td style="height: 15px">
                    <asp:DropDownList ID="Importer" runat="server" DataSourceID="SenaraiPengimport"
                        DataTextField="Nama_Syarikat_Eksport" DataValueField="Kod_Pengeksport" AppendDataBoundItems="True">
                        <asp:ListItem Value="">Sila Pilih</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 15px">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 15px">
                    <asp:Button ID="Button2" runat="server" Style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        Text="Papar Kadar Caj Ikan" Width="115px" />
                    <asp:Button ID="Button1" runat="server" Style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        Text="Kadar Caj Ikan Baru" Width="130px" OnClick="Button1_Click1"  /></td>
            </tr>
        </table>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Width="100%"></asp:Label><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SenaraiCaj" EmptyDataText="Tiada Rekod Ditemui" Font-Bold="False" Height="22px" HorizontalAlign="Left" ShowFooter="True" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="ID" />
                <asp:BoundField DataField="Kategori_Ikan" HeaderText="Kategori_Ikan" SortExpression="Kategori_Ikan" />
                <asp:BoundField DataField="Nama_Kategori_Ikan" HeaderText="Nama_Kategori_Ikan" SortExpression="Nama_Kategori_Ikan" />
                <asp:BoundField DataField="Jenis_Urusan" HeaderText="Jenis_Urusan" SortExpression="Jenis_Urusan" />
                <asp:BoundField DataField="Nama_Urusan" HeaderText="Nama_Urusan" SortExpression="Nama_Urusan" />
                <asp:BoundField DataField="Kadar_Peti_Kecil" HeaderText="Kadar_Peti_Kecil" SortExpression="Kadar_Peti_Kecil" />
                <asp:BoundField DataField="Kadar_Peti_Besar" HeaderText="Kadar_Peti_Besar" SortExpression="Kadar_Peti_Besar" />
                <asp:BoundField DataField="Kadar_Ekor" HeaderText="Kadar_Ekor" SortExpression="Kadar_Ekor" />
                <asp:BoundField DataField="Kadar_Kuantiti" HeaderText="Kadar_Kuantiti" SortExpression="Kadar_Kuantiti" />
                <asp:BoundField DataField="Kod_Pengimport" HeaderText="Kod_Pengimport" SortExpression="Kod_Pengimport" />
                <asp:BoundField DataField="tarikh_mula" HeaderText="tarikh_mula" SortExpression="tarikh_mula" />
                <asp:BoundField DataField="tarikh_tamat" HeaderText="tarikh_tamat" SortExpression="tarikh_tamat" />
            </Columns>
            <EmptyDataRowStyle Font-Bold="True" />
            <RowStyle Height="18px" />
            <HeaderStyle BackColor="RoyalBlue" ForeColor="White" Height="22px" HorizontalAlign="Left" />
            <AlternatingRowStyle BackColor="#E0E0E0" />
            <FooterStyle BackColor="RoyalBlue" Height="22px" />
        </asp:GridView>
                   
                    <br />
                    <br />
                    <br />
       
                    <br />
                    <br />
                   
      
        <asp:SqlDataSource ID="SenaraiCaj" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT COMPANY_IKAN_CAJ.ID, COMPANY_IKAN_CAJ.Kategori_Ikan,COMPANY_IKAN_CAJ.Kod_Ikan, KATEGORI_IKAN.Nama_Kategori_Ikan, COMPANY_IKAN_CAJ.Jenis_Urusan, JENIS_URUSAN.Nama_Urusan, COMPANY_IKAN_CAJ.Kadar_Peti_Kecil, COMPANY_IKAN_CAJ.Kadar_Peti_Besar, COMPANY_IKAN_CAJ.Kadar_Ekor, COMPANY_IKAN_CAJ.Kadar_Kuantiti, COMPANY_IKAN_CAJ.Kod_Pengimport, COMPANY_IKAN_CAJ.tarikh_mula, COMPANY_IKAN_CAJ.tarikh_tamat FROM KATEGORI_IKAN INNER JOIN COMPANY_IKAN_CAJ_EKSPORT as COMPANY_IKAN_CAJ  ON KATEGORI_IKAN.Kod_Kategori_Ikan = COMPANY_IKAN_CAJ.Kategori_Ikan INNER JOIN JENIS_URUSAN ON COMPANY_IKAN_CAJ.Jenis_Urusan = JENIS_URUSAN.Kod_Urusan WHERE (COMPANY_IKAN_CAJ.Kod_Pengimport = @Kod_Pengimport) AND (COMPANY_IKAN_CAJ.status = 'yes')">
            <SelectParameters>
                <asp:ControlParameter ControlID="Importer" Name="Kod_Pengimport" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>          
        <asp:SqlDataSource ID="SenaraiPengimport" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT RTRIM([Kod_Pengeksport]) as Kod_Pengeksport, [Nama_Syarikat_Eksport] FROM [PENGEKSPORT]">
        </asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
            &nbsp;&nbsp;<br />
              
              
            
            <br />
            <br />        
        <br />
               
        
    </form>

     
</body>
</html>
