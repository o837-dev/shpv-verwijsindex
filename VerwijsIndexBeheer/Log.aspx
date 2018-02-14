<%@ Page Language="C#" MasterPageFile="~/Config.Master" AutoEventWireup="true" CodeBehind="Log.aspx.cs" Inherits="Denion.WebService.Beheer.Log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p id="cntnt" runat="server"><span class="intro">Content of table:&nbsp;&nbsp;&nbsp;&nbsp;</span><asp:Label CssClass="intro" ID="lblTable" runat="server"></asp:Label><asp:Button ID="btnFetch" runat="server" Text="Fetch" OnClick="btnFetch_Click" /></p>
    <br />
    <p id="fltr" runat="server" >Filter: 
        <asp:TextBox ID="txtWhere" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:Button ID="btnfilter" runat="server" Text="Filter" 
            onclick="btnfilter_Click" />&nbsp;
        <asp:Button ID="btnClear" runat="server" Text="Clear" 
            onclick="btnClear_Click" /><br />
        <asp:Button ID="btnReCount" runat="server" Text="Recount" OnClick="btnReCount_Click" />
        <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
    </p>

    <asp:GridView ID="grd" runat="server" DataKeyNames="ID" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />

            <asp:TemplateField HeaderText="MESSAGE">
                <ItemTemplate>
                    <pre style="background-color:#E5E5CC; margin:0px; border:none; padding:0px"><code><%# Eval("MESSAGE") %></code></pre>
                </ItemTemplate>
             </asp:TemplateField>

            <asp:TemplateField HeaderText="RECEIVED">
                <ItemTemplate>
                    <span style="white-space:nowrap"><%# Eval("RECEIVED") %></span>
                </ItemTemplate>
             </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

