<%@ Page Title="XXE" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="XXE.aspx.cs" Inherits="vulnerable_asp_net_framework.XXE" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br></br>
    <br></br>

    <h1>XXE</h1>
    <h2>Send your request</h2>

    <form>
        Request:<br>
        <input type="text" name="xml"><br>
        <input type="submit" value="Send">
    </form>

    <br></br>

    <asp:TextBox ID="XXEResults" TextMode="multiline" Columns="50" Rows="5" runat="server" />
</asp:Content>
