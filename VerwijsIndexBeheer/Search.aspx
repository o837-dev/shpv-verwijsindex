<%@ Page Language="C#" MasterPageFile="~/Config.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Denion.WebService.Beheer.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p id="fltr" runat="server" >Search: 
        <asp:TextBox ID="txtWhere" runat="server"></asp:TextBox>
        <asp:Button ID="btnfilter" runat="server" Text="Fetch" onclick="btnfilter_Click" />&nbsp;
        <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
    </p>
    <br />
    <h3><asp:Label ID="lblGrd1" runat="server" Text=""></asp:Label></h3>
    <asp:GridView ID="grd1" runat="server" AutoGenerateColumns="true"/>
    <br /><br />
    <h3><asp:Label ID="lblGrd2" runat="server" Text=""></asp:Label></h3>
    <asp:GridView ID="grd2" runat="server" AutoGenerateColumns="true"/>
</asp:Content>
