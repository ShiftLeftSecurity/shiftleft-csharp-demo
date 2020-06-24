<%@ Page Title="BrokenAccessControl" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrokenAccessControl.aspx.cs" Inherits="vulnerable_asp_net_framework.BrokenAccessControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br></br>
    <br></br>

    <h1>Broken Access Control</h1>
    <h2>Login</h2>

    <form method="get" action="BrokenAccessControl.aspx">
        Username:<br>
        <input type="text" name="name"><br>
        Password:<br>
        <input type="password" name="pw">
        <br>
        <input type="submit" value="Login">
        <input type="hidden" id="role" name="role" value="user">
        <input type="hidden" id="id" name="id" value="0">
    </form>

    <br></br>

    <asp:Label ID="BrokenAccessControlResults" runat="server" Text="Label"></asp:Label>
</asp:Content>
