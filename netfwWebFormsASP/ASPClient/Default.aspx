<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="EmployeeIDTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="Button" runat="server" Text="Get salary of employee" OnClick="Button_Click" />
            <asp:Label ID="EmployeeSalaryLabel" runat="server" Text="???"></asp:Label>
        </div>
    </form>
</body>
</html>
