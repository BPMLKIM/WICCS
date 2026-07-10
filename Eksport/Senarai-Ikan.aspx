<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Senarai-Ikan.aspx.vb" Inherits="Import_Senarai_Ikan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Senarai Ikan</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>

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
}
}

function sendValue(param1,param2,param3,param4)
{
    
    //reset details ikan value    
    window.opener.document.all.txtPetiKecil.value="";
    window.opener.document.all.txtKuantitiKecil.value="";
    window.opener.document.all.txtPetiBesar.value="";
    window.opener.document.all.txtKuantitiBesar.value="";
    window.opener.document.all.txtEkor.value="";
    window.opener.document.all.txtNilai.value="";
    
    window.opener.document.all.txtJumlahNilai.value="";
    
    
    //
    
    window.opener.document.all.Kod_BKH.value=param1.replace(/\s+$/,"");
    window.opener.document.all.Nama_Ikan.value=param2;
    window.opener.document.all.Kod8_Digit.value=param3;
    window.opener.document.all.txtNilai.value=param4;
    var categoryIkan = param3.substr(0,1);
    var kodUrusan=window.opener.document.all.JenisUrusan.options.value; 
    window.opener.document.all.Destination.focus(); 
   
    //alert(categoryIkan);
    //alert(categoryIkan.substr(0,1));
    //Enable Input Texts
    switch(categoryIkan)
    {  
        case "1" :    // *** Ikan Basah ***
            
//                window.opener.document.all.txtPetiKecil.disabled = false;
//                window.opener.document.all.txtPetiBesar.disabled = false;
//                window.opener.document.all.txtKuantitiKecil.disabled = false;
//                window.opener.document.all.txtKuantitiBesar.disabled = false;
//                window.opener.document.all.txtPek.disabled = true;
//                window.opener.document.all.txtEkor.disabled = true;
//                window.opener.document.all.txtNilai.disabled = true;
                
                window.opener.document.all.txtPetiKecil.disabled = false;
                window.opener.document.all.txtPetiBesar.disabled = false;
                window.opener.document.all.txtKuantitiKecil.disabled = false;
                window.opener.document.all.txtKuantitiBesar.disabled = false;
                window.opener.document.all.txtPek.disabled = false;
                window.opener.document.all.txtEkor.disabled = false;
                window.opener.document.all.txtNilai.disabled = false;
                break;
            
        case "2" :    // *** Sejukbeku ***
          
//                window.opener.document.all.txtPetiKecil.disabled = false;
//                window.opener.document.all.txtPetiBesar.disabled = true;
//                window.opener.document.all.txtKuantitiKecil.disabled = false;
//                window.opener.document.all.txtKuantitiBesar.disabled = true;
//                window.opener.document.all.txtPek.disabled = true;
//                window.opener.document.all.txtEkor.disabled = true;
//                window.opener.document.all.txtNilai.disabled = true;
//                
                window.opener.document.all.txtPetiKecil.disabled = false;
                window.opener.document.all.txtPetiBesar.disabled = false;
                window.opener.document.all.txtKuantitiKecil.disabled = false;
                window.opener.document.all.txtKuantitiBesar.disabled = false;
                window.opener.document.all.txtPek.disabled = false;
                window.opener.document.all.txtEkor.disabled = false;
                window.opener.document.all.txtNilai.disabled = false;
                break;
             
        case "3" :    // *** Hidup ***

//                window.opener.document.all.txtPetiKecil.disabled = false;
//                window.opener.document.all.txtPetiBesar.disabled = false;
//                window.opener.document.all.txtKuantitiKecil.disabled = false;
//                window.opener.document.all.txtKuantitiBesar.disabled = false;
//                window.opener.document.all.txtPek.disabled = true;
//                window.opener.document.all.txtEkor.disabled = false;
//                window.opener.document.all.txtNilai.disabled = false;

                window.opener.document.all.txtPetiKecil.disabled = false;
                window.opener.document.all.txtPetiBesar.disabled = false;
                window.opener.document.all.txtKuantitiKecil.disabled = false;
                window.opener.document.all.txtKuantitiBesar.disabled = false;
                window.opener.document.all.txtPek.disabled = false;
                window.opener.document.all.txtEkor.disabled = false;
                window.opener.document.all.txtNilai.disabled = false;
                break;      
                
        case "4" :    // *** Proses/Produk Perikanan ***
                       
//                window.opener.document.all.txtPetiKecil.disabled = false;
//                window.opener.document.all.txtPetiBesar.disabled = false;
//                window.opener.document.all.txtKuantitiKecil.disabled = false;
//                window.opener.document.all.txtKuantitiBesar.disabled = false;
//                window.opener.document.all.txtPek.disabled = true;
//                window.opener.document.all.txtEkor.disabled = true;
//                window.opener.document.all.txtNilai.disabled = true;

                window.opener.document.all.txtPetiKecil.disabled = false;
                window.opener.document.all.txtPetiBesar.disabled = false;
                window.opener.document.all.txtKuantitiKecil.disabled = false;
                window.opener.document.all.txtKuantitiBesar.disabled = false;
                window.opener.document.all.txtPek.disabled = false;
                window.opener.document.all.txtEkor.disabled = false;
                window.opener.document.all.txtNilai.disabled = false;
                break;
                
        case "5" :    // *** Produk Perikanan Yang Lain ***
                  
//                window.opener.document.all.txtPetiKecil.disabled = true;
//                window.opener.document.all.txtPetiBesar.disabled = true;
//                window.opener.document.all.txtKuantitiKecil.disabled = false;
//                window.opener.document.all.txtKuantitiBesar.disabled = true;
//                window.opener.document.all.txtPek.disabled = true;
//                window.opener.document.all.txtEkor.disabled = true;
//                window.opener.document.all.txtNilai.disabled = true;

                window.opener.document.all.txtPetiKecil.disabled = false;
                window.opener.document.all.txtPetiBesar.disabled = false;
                window.opener.document.all.txtKuantitiKecil.disabled = false;
                window.opener.document.all.txtKuantitiBesar.disabled = false;
                window.opener.document.all.txtPek.disabled = false;
                window.opener.document.all.txtEkor.disabled = false;
                window.opener.document.all.txtNilai.disabled = false;
                break;       
    }//end switch for categoryIkan condition
   
     
}
</script>

    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                &nbsp; &nbsp;&nbsp;<br />
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SenaraiIkan" Width="317px" AllowPaging="True" AllowSorting="True" PageSize="18">
                    <HeaderStyle BackColor="LightGray" />
                </asp:GridView>
                <asp:SqlDataSource ID="SenaraiIkan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>" SelectCommand="SELECT [Nama_BKH], [Kod_Ikan], [Kod_BKH],[Harga_BKH] FROM [JENIS_IKAN] WHERE ([Nama_BKH] LIKE '%' + @Nama_BKH + '%')">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TextBox1" DefaultValue="%" Name="Nama_BKH" PropertyName="Text"
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
        <asp:hiddenfield ID="TextBox2" runat="server"></asp:hiddenfield>
        <asp:Button ID="Button1" runat="server" Text="Mulakan Carian Nama Ikan" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1" Width="318px" /><asp:TextBox ID="TextBox1" runat="server" Width="312px"></asp:TextBox>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        &nbsp;<br />
        &nbsp;
        &nbsp; &nbsp;<br />
        &nbsp;
    </form>
</body>
</html>
