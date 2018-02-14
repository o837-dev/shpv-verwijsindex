<%@ Page Title="" Language="C#" MasterPageFile="~/Config.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Denion.WebService.Beheer.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Queue Length: <asp:Label ID="lblInfo" runat="server" /><br />
    <br />
    <asp:Button ID="btnFork" runat="server" Text="Fork" OnClick="btnFork_Click" />
</asp:Content>
