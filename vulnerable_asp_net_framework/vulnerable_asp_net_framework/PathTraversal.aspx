<%@ Page Title="Path Traversal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PathTraversal.aspx.cs" Inherits="vulnerable_asp_net_framework.PathTraversal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br></br>
    <br></br>

    <h1>Path Traversal</h1>

    <form>
        Download File:<br>
        <input type="text" name="filename"><br>
        <input type="submit" value="Post">
    </form>

    <br></br>
    <asp:Label ID="ContentSummary" runat="server" Text="Label"></asp:Label>
</asp:Content>
