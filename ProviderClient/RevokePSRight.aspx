<%@ Page Language="C#" MasterPageFile="~/Provider.Master" AutoEventWireup="true" CodeBehind="RevokePSRight.aspx.cs" Inherits="Denion.Web.ProviderClient.RevokePSRight" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <vwx:EditerControl ID="request" runat="server" />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <vwx:EditerControl ID="response" runat="server" />
</asp:Content>
