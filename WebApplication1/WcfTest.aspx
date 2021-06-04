<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WcfTest.aspx.cs" Inherits="WebApplication1.WcfTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:GridView ID="CustomersGridView" runat="server" 
             AutoGenerateSelectButton="True"
             DataKeyNames="Id"
             OnSelectedIndexChanged="CustomersGridView_SelectedIndexChanged">
         </asp:GridView>
         <br />
         <asp:Panel ID="Order_Pnl" runat="server" Visible="False">
             <asp:GridView ID="OrdersGridView" runat="server">
             </asp:GridView>
             <asp:Button ID="Order_Ok_Btn" runat="server" OnClick="Order_Ok_Btn_Click" Text="Ок" />
         </asp:Panel>
         <br />
    </form>
</body>
</html>
