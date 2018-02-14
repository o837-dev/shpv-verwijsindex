<%@ Page Language="C#" MasterPageFile="~/Config.Master" AutoEventWireup="true" CodeBehind="ConsumerContract.aspx.cs" Inherits="Denion.WebService.Beheer.ConsumerContract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="cntnt" runat="server">
        <span class="intro">Content of table:&nbsp;&nbsp;&nbsp;&nbsp;</span><asp:Label CssClass="intro" ID="lblTable" runat="server"></asp:Label><br />
        <br />
        <asp:Label CssClass="intro" ID="lblErr" runat="server"></asp:Label><br />
    </p>
    <br />
    <br />
    <asp:GridView ID="grd" runat="server"
        EnableModelValidation="True"
        OnRowCancelingEdit="grd_RowCancelingEdit" OnRowEditing="grd_RowEditing"
        OnRowUpdating="grd_RowUpdating" DataKeyNames="ID"
        AutoGenerateColumns="False" OnRowCommand="grd_RowCommand"
        ShowFooter="true" OnRowDataBound="grd_RowDataBound"
        OnRowDeleting="grd_RowDeleting">
        <Columns>
            <asp:BoundField DataField="ID" Visible="false" HeaderText="ID" />

            <asp:TemplateField HeaderText="AREAMANAGERID">
                <HeaderTemplate>
                    <center>AREAMANAGERID<br />
                        <asp:DropDownList ID="fltrAREAMANAGERID" DataTextField="DESCRIPTION" DataValueField="ID" AutoPostBack="true" OnSelectedIndexChanged="fltrAREAMANAGERID_SelectedIndexChanged" runat="server" /></center>
                </HeaderTemplate>
                <ItemTemplate>
                    <center>
                        <asp:DropDownList ID="consumerContractAREAMANAGERID" DataTextField="DESCRIPTION" DataValueField="ID" runat="server" Enabled="false" /></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:DropDownList ID="consumerContractAREAMANAGERID" DataTextField="DESCRIPTION" DataValueField="ID" runat="server" /></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:DropDownList ID="consumerContractAREAMANAGERID" DataTextField="DESCRIPTION" DataValueField="ID" runat="server" /></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="AREAID">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="consumerContractAREAID" Text='<%# Bind("AREAID") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:TextBox ID="consumerContractAREAID" Text='<%# Bind("AREAID") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:TextBox ID="consumerContractAREAID" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="CONSUMERID">
                <ItemTemplate>
                    <center>
                        <asp:DropDownList ID="consumerContractCONSUMERID" DataTextField="DESCRIPTION" DataValueField="CID" runat="server" Enabled="false" /></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:DropDownList ID="consumerContractCONSUMERID" DataTextField="DESCRIPTION" DataValueField="CID" runat="server" /></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:DropDownList ID="consumerContractCONSUMERID" DataTextField="DESCRIPTION" DataValueField="CID" runat="server" /></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="STARTDATE">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="consumerContractSTARTDATE" Text='<%# Bind("STARTDATE") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <sbs:TimePicker ID="consumerContractSTARTDATE" runat="server" Value='<%# Bind("STARTDATE") %>' />
                    </center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <sbs:TimePicker ID="consumerContractSTARTDATE" runat="server" />
                    </center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ENDDATE">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="consumerContractENDDATE" Text='<%# Bind("ENDDATE") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <sbs:TimePicker ID="consumerContractENDDATE" runat="server" Value='<%# Bind("ENDDATE") %>' />
                    </center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <sbs:TimePicker ID="consumerContractENDDATE" runat="server" />
                    </center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Bewerken"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Verwijderen"
                        OnClientClick="if(!confirm('Weet U zeker dat U dit ConsumerContract wilt verwijderen?')) return false;"></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Opslaan"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Annuleren"></asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btnAdd" runat="server" Text="Toevoegen" CommandName="Insert" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
