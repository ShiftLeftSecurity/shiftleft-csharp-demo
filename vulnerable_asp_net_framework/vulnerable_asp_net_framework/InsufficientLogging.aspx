<%@ Page Title="Insufficient Logging" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsufficientLogging.aspx.cs" Inherits="vulnerable_asp_net_framework.InsufficientLogging" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br></br>
    <br></br>

    <h1>Insufficient Logging</h1>

    <form>
        <input type="hidden" id="showlogs" name="showlogs" value="1">
        <input type="submit" value="Show Logs">
    </form>

    <br></br>

    <asp:Label ID="InsufficientLoggingResults" runat="server" Text="Label"></asp:Label>
</asp:Content>
