<%@ Page Title="XSS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="XSS.aspx.cs" Inherits="vulnerable_asp_net_framework.XSS" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br></br>
    <br></br>

    <h1>XSS</h1>
    <h2>Post your comment</h2>

    <form>
        comment:<br>
        <input type="text" name="comment"><br>
        <input type="submit" value="Post">
    </form>

    <br></br>

    <asp:Label ID="XSSInput" runat="server" Text="Label"></asp:Label>
</asp:Content>
