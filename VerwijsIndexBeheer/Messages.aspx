<%@ Page Language="C#" MasterPageFile="~/Config.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="Denion.WebService.Beheer.Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="cntnt" runat="server"><span class="intro">Content of table:&nbsp;&nbsp;&nbsp;&nbsp;</span><asp:Label CssClass="intro" ID="lblTable" runat="server"></asp:Label><asp:Button ID="btnFetch" runat="server" Text="Fetch" OnClick="btnFetch_Click" /></p>
    <br />
    <p id="fltr" runat="server">
        Filter: 
        <asp:TextBox ID="txtWhere" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:Button ID="btnfilter" runat="server" Text="Filter"
            OnClick="btnfilter_Click" />&nbsp;
        <asp:Button ID="btnClear" runat="server" Text="Clear"
            OnClick="btnClear_Click" /><br />
        <asp:Button ID="btnReCount" runat="server" Text="Recount" OnClick="btnReCount_Click" />
        <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
    </p>

    <asp:GridView ID="GridView1" runat="server" EnableViewState="False" OnRowDataBound="GridView1_RowDataBound" />
</asp:Content>
