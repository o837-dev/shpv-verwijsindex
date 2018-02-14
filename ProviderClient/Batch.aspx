<%@ Page Title="Provider batch module" Language="C#" MasterPageFile="~/Provider.Master" AutoEventWireup="true" CodeBehind="Batch.aspx.cs" Inherits="Denion.Web.ProviderClient.Batch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="/style/verwijsindex.css" rel="stylesheet" type="text/css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="res/ProviderTemplate.csv">Template</a><br/><br/>
    <asp:FileUpload ID="FileUploadControl" runat="server" />
    <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
    <br /><br />
    <asp:Label runat="server" id="StatusLabel" text="" />
</asp:Content>
