<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tempoh_larangan_ikan.aspx.vb"
    Inherits="tempoh_larangan_ikan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PERSONALIA Maklumat Peribadi</title>
    <link href="css/bhea2.css" rel="stylesheet" type="text/css" />
</head>

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
        <div>
            <table border="0" cellpadding="0" cellspacing="0" width="938">
                <tr>
                    <td width="27%" style="height: 13px; font-weight: bold;">
                        MODUL MENYUNTING MAKLUMAT</td>
                    <td width="73%" bgcolor="#006699" style="height: 13px">
                        &nbsp;</td>
                </tr>
            </table>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            &nbsp;</div>
        <table style="width: 653px">
            <tr>
                <td colspan="3" style="font-weight: bold">
                    TEMPOH LARANGAN IKAN</td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 650px">
                    <tr>
                        <td style="width: 337px; height: 8px; font-size: 10pt;">
                            Masukkan No K/P Baru @ No K/P Lama @ No Pekerja @ Nama</td>
                        <td style="height: 8px">
                            <asp:TextBox ID="NamaPengguna" runat="server" Width="187px"></asp:TextBox>
                            <asp:Button ID="mulaCarian" runat="server" Text="Carian Rekod" Style="border-right: #333333 1px ridge;
                                padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                                padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                                border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1;" /></td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataSourceID="lkim_userlists" Width="100%" Height="22px"
                    Font-Size="Small" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <HeaderStyle BackColor="#990000" ForeColor="White" Height="22px" Font-Bold="True" />
                    <RowStyle Height="18px" BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="t_mula,t_tamat" DataNavigateUrlFormatString="tempoh_larangan_ikan_edit.aspx?t_mula={0:yyyy/MM/dd}&amp;idp={1:yyyy/MM/dd}"
                            Text="Pilih"></asp:HyperLinkField>
                           
                             <asp:TemplateField  HeaderText="Tarikh Mula" SortExpression="t_mula" >
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("t_mula") %>' ></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# IIf(Eval("t_mula", "{0:d}") = "01/01/1900", "", Eval("t_mula", "{0:dd/MM/yyyy}"))%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                           <asp:TemplateField  HeaderText="Tarikh Tamat" SortExpression="t_tamat" >
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("t_tamat") %>' ></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# IIf(Eval("t_tamat", "{0:d}") = "01/01/1900", "", Eval("t_tamat", "{0:dd/MM/yyyy}"))%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                       
                        <asp:BoundField DataField="Catatan" HeaderText="Catatan" SortExpression="Catatan">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        </Columns>
                    <FooterStyle BackColor="#990000" Height="22px" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle Font-Size="Larger" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                </asp:GridView>
                <asp:SqlDataSource ID="lkim_userlists" runat="server" ConnectionString="<%$ ConnectionStrings:w-iccs_Conn %>"
                    SelectCommand="SELECT tempoh_larangan.t_mula, tempoh_larangan.t_tamat, tempoh_larangan.catatan, status_tempoh.status FROM tempoh_larangan,status_tempoh WHERE tempoh_larangan.status=status_tempoh.kod order by tempoh_larangan.t_mula desc">
                   <%-- <SelectParameters>
                        <asp:ControlParameter ControlID="NamaPengguna" DefaultValue="%" Name="nama" PropertyName="Text"
                            Type="String" />
                    </SelectParameters>--%>
                </asp:SqlDataSource>
                <br />
                <asp:Button ID="NewUser" runat="server" Text="Rekod Baru" Style="border-right: #333333 1px ridge;
                    padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                    padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                    border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1;"
                    OnClientClick="location.href='tempoh_larangan_ikan_new.aspx';" /><asp:Button ID="Kembali"
                        runat="server" Text="Kembali" Style="border-right: #333333 1px ridge; padding-right: 1px;
                        border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                        border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                        font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1;" OnClientClick="location.href='suntingmaklumat.aspx';" /><br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
