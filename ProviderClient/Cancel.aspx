<%@ Page Language="C#" MasterPageFile="~/Provider.Master" AutoEventWireup="true" CodeBehind="Cancel.aspx.cs" Inherits="Denion.Web.ProviderClient.Cancel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="cntnt" runat="server">
        <span class="intro">Content of table:&nbsp;&nbsp;&nbsp;&nbsp;</span><asp:Label CssClass="intro" ID="lblTable" runat="server"></asp:Label><br />
        <asp:Label CssClass="intro" ID="lblErr" runat="server"></asp:Label><br />
    </p>

    <asp:GridView ID="grd" runat="server"
        EnableModelValidation="True"
        DataKeyNames="REQUESTID"
        AutoGenerateColumns="False"
        OnRowCommand="grd_RowCommand">
        <Columns>

            <asp:BoundField DataField="REQUESTID" Visible="false" HeaderText="ID" />
            <asp:BoundField DataField="AREAMANAGERID" Visible="true" HeaderText="AREAMANAGERID" />
            <asp:BoundField DataField="AREAID" Visible="true" HeaderText="AREAID" />
            <asp:BoundField DataField="VEHICLEID" Visible="true" HeaderText="VEHICLEID" />
            <asp:BoundField DataField="COUNTRYCODE" Visible="true" HeaderText="COUNTRYCODE" />
            <asp:BoundField DataField="VEHICLEIDTYPE" Visible="true" HeaderText="VEHICLEIDTYPE" />
            <asp:BoundField DataField="PROVIDERID" Visible="true" HeaderText="PROVIDERID" />
            <asp:BoundField DataField="PAYMENTAUTHORISATIONID" Visible="true" HeaderText="PAYMENTAUTHORISATIONID" />

            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnCancel" runat="server" CommandName="Annuleren" Text="Annuleren" CommandArgument='<%# Container.DataItemIndex%>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
