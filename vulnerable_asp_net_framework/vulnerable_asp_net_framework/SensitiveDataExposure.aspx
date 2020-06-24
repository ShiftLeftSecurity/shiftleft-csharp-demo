<%@ Page Title="SensitiveDataExposure" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SensitiveDataExposure.aspx.cs" Inherits="vulnerable_asp_net_framework.SensitiveDataExposure" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br></br>
    <br></br>

    <h1>Sensitive Data Exposure</h1>
    <h2>Login</h2>

    <form>
        Username:<br>
        <input type="text" name="name"><br>
        Password:<br>
        <input type="password" name="pw">
        <br>
        <input type="hidden" id="cardprop" name="cardprop" value="cardno">
        <input type="submit" value="Login">
    </form>

    <br></br>

    <asp:TextBox ID="SensitiveDataExposureResults" TextMode="multiline" Columns="50" Rows="5" runat="server" ReadOnly="True" />
</asp:Content>
