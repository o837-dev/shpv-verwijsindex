<%@ Page Language="C#" MasterPageFile="~/Garage.Master" AutoEventWireup="true" CodeBehind="PaymentStart.aspx.cs" Inherits="GarageClient.PaymentStart" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <vwx:EditerControl ID="request" runat="server" />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <vwx:EditerControl ID="response" runat="server" />    
</asp:Content>
