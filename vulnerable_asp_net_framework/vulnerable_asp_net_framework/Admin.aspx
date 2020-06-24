<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="vulnerable_asp_net_framework.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2><%: Title %></h2>
	<asp:Label ID="AdminResults" runat="server" Text="Label"></asp:Label>
</asp:Content>
