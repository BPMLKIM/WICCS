<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pintumasuk_edit_lkim_user.aspx.vb" Inherits="UserManagement_LKIM_edit_lkim_user" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS Kemaskini Maklumat Pengguna LKIM</title>
    <link href="css/bhea2.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="popcalendar.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
 
     function maskKeyPress(objEvent)
{
    var iKeyCode; 
    iKeyCode = objEvent.keyCode;              
    if (iKeyCode>=48 && iKeyCode<=57) 
    {
    return true;
    }
    else if (iKeyCode == 45) {
    return true;
    }
    else {
    return false;
    }
 }

function validateInt1()
{
    var deposit_semasa_tambahan; 
    deposit_semasa_tambahan = parseFloat(document.form1.deposit_semasa_tambahan.value); if ( isNaN(deposit_semasa_tambahan) || (deposit_semasa_tambahan % 1 != 0) ) { document.form1.deposit_semasa_tambahan.value = 0; } 
    var deposit_semasa; 
    deposit_semasa = parseFloat(document.form1.deposit_semasa.value); if ( isNaN(deposit_semasa) || (deposit_semasa % 1 != 0) ) { document.form1.deposit_semasa.value = 0; } 
    calculate1();
 }
function calculate1() 
{
    var tbdeposit_semasa_tambahan = parseFloat(document.form1.deposit_semasa_tambahan.value);
    var tbdeposit_semasa = parseFloat(document.form1.deposit_semasa.value);
    document.form1.nilai_deposit_semasa.value = parseInt(tbdeposit_semasa_tambahan) + parseInt(tbdeposit_semasa);
    }
</script>
    
    
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
      <strong>&nbsp;</strong><table width="100%" border="0" cellspacing="0" cellpadding="0" style="font-weight: bold">
    <tr>
      <td width="25%"><font color="#333333"><span style="color: #000000">Maklumat Pengimport</span><span style="color: #000000"> 
        malaysia</span></font></td>
      <td width="75%">&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>Kod Pengimport Malaysia</td>
      <td>
          <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
    </tr>
          <tr>
              <td>
              </td>
              <td>
              </td>
          </tr>
    <tr>
      <td>Nama Syarikat</td>
      <td>
          <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
    </tr>
          <tr>
              <td style="height: 19px">
              </td>
              <td style="height: 19px">
              </td>
          </tr>
    <tr>
      <td style="height: 19px">
          Pintu Masuk</td>
      <td style="height: 19px">
          <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nama_PPI" DataValueField="Kod_PPI">
          </asp:DropDownList></td>
    </tr>
      <tr>
          <td style="height: 19px">
          </td>
          <td style="height: 19px">
              </td>
      </tr>
          <tr>
              <td style="height: 19px">
              </td>
              <td style="height: 19px"><asp:Button ID="NewUser" runat="server" Text="Tambah Pintu Masuk" Style="border-right: #333333 1px ridge;
                      padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                      padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                      border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" /><input id="Button1" onclick="location.href='pintumasuk.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="kembali " /><asp:Button ID="reset" runat="server" Text="Reset" Style="border-right: #333333 1px ridge;
                      padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                      padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                      border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" />
                  </td>
          </tr>
  </table>
      <br />
      <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#FF0066" Text="Label"
          Visible="False"></asp:Label>&nbsp;<br />
      Senarai Pintu Masuk untuk Pengimport<br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource2" Width="50%" ForeColor="#333333" GridLines="None" PageSize="6">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Kod_Pengimport" HeaderText="Kod_Pengimport" SortExpression="Kod_Pengimport">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <FooterStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Kod_PPI" HeaderText="Kod_PPI" SortExpression="Kod_PPI" />
                <asp:BoundField DataField="Nama_PPI" HeaderText="Nama_PPI" SortExpression="Nama_PPI" />
                <asp:CommandField DeleteText="Hapus" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
      &nbsp;<br />
      &nbsp; &nbsp;
        &nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>" SelectCommand="SELECT [Kod_PPI], [Nama_PPI] FROM [PUSATKOMPLEK]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>" SelectCommand="SELECT pintu_masuk_sistem_q.id, pintu_masuk_sistem_q.Kod_Pengimport, pintu_masuk_sistem_q.Kod_PPI, PUSATKOMPLEK.Nama_PPI FROM pintu_masuk_sistem_q INNER JOIN PUSATKOMPLEK ON pintu_masuk_sistem_q.Kod_PPI = PUSATKOMPLEK.Kod_PPI WHERE (pintu_masuk_sistem_q.Kod_Pengimport LIKE '%' + @nama + '%')" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [pintu_masuk_sistem_q] WHERE [id] = @original_id AND [Kod_Pengimport] = @original_Kod_Pengimport AND [Kod_PPI] = @original_Kod_PPI" InsertCommand="INSERT INTO [pintu_masuk_sistem_q] ([Kod_Pengimport], [Kod_PPI]) VALUES (@Kod_Pengimport, @Kod_PPI)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [pintu_masuk_sistem_q] SET [Kod_Pengimport] = @Kod_Pengimport, [Kod_PPI] = @Kod_PPI WHERE [id] = @original_id AND [Kod_Pengimport] = @original_Kod_Pengimport AND [Kod_PPI] = @original_Kod_PPI">
            <DeleteParameters>
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_Kod_Pengimport" Type="String" />
                <asp:Parameter Name="original_Kod_PPI" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Kod_Pengimport" Type="String" />
                <asp:Parameter Name="Kod_PPI" Type="String" />
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_Kod_Pengimport" Type="String" />
                <asp:Parameter Name="original_Kod_PPI" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="Label2" DefaultValue="%" Name="nama" PropertyName="Text" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Kod_Pengimport" Type="String" />
                <asp:Parameter Name="Kod_PPI" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
  </div>
</form>
</body>
</html>
