<%@ Page Title="Insecure Deserialziation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Deserialize.aspx.cs" Inherits="vulnerable_asp_net_framework.Deserialize" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br></br>
    <br></br>

    <h1>Insecure Deserialization</h1>
    <h2>Send your request</h2>

    <form>
        Request:<br>
        <input type="text" name="xml"><br>
        <input type="submit" value="Send">
    </form>

    <br></br>

	<asp:Label ID="DeserializeResult" runat="server" Text="Label"></asp:Label>
</asp:Content>
