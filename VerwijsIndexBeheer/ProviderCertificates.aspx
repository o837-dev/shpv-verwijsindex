<%@ Page Language="C#" MasterPageFile="~/Config.Master" AutoEventWireup="true" CodeBehind="ProviderCertificates.aspx.cs" Inherits="Denion.WebService.Beheer.ProviderCertificates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="cntnt" runat="server">
        <span class="intro">Content of table:&nbsp;&nbsp;&nbsp;&nbsp;</span><asp:Label CssClass="intro" ID="lblTable" runat="server"></asp:Label><br />
        <asp:Label CssClass="intro" ID="lblErr" runat="server"></asp:Label><br />
    </p>

    <asp:GridView ID="grd" runat="server"
        EnableModelValidation="True"
        OnRowCancelingEdit="grd_RowCancelingEdit" OnRowEditing="grd_RowEditing"
        OnRowUpdating="grd_RowUpdating" DataKeyNames="ID"
        AutoGenerateColumns="False" OnRowDeleting="grd_RowDeleting"
        OnRowCommand="grd_RowCommand" ShowFooter="true">
        <Columns>
            <asp:BoundField DataField="ID" Visible="false" HeaderText="ID" />

            <asp:TemplateField HeaderText="PROVIDER">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="ProviderPROVIDER" Text='<%# Bind("PROVIDER") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:TextBox ID="ProviderPROVIDER" Text='<%# Bind("PROVIDER") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:TextBox ID="ProviderPROVIDER" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="CERTIFICATE">
                <ItemTemplate>
                    <center>
                        <i><asp:Label ID="ProviderCERTIFICATE" Text='<%# Bind("FILENAME") %>' runat="server"></asp:Label></i></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <i><asp:Label ID="ProviderCERTIFICATE" Text='<%# Bind("FILENAME") %>' runat="server"></asp:Label></i></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:FileUpload ID="ProviderCERTIFICATE" runat="server"></asp:FileUpload></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="CERTPIN">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="ProviderCERTPIN" Text="********" runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:TextBox ID="ProviderCERTPIN" Text="********" TextMode="Password"  runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:TextBox ID="ProviderCERTPIN" TextMode="Password" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

                        <asp:TemplateField HeaderText="VALIDFROM">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="ProviderVALIDFROM" Text='<%# Bind("VALIDFROM") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <sbs:TimePicker ID="ProviderVALIDFROM" runat="server" Value='<%# Bind("VALIDFROM") %>' />
                    </center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <sbs:TimePicker ID="ProviderVALIDFROM" runat="server" />
                    </center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

                        <asp:TemplateField HeaderText="VALIDUNTIL">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="ProviderVALIDUNTIL" Text='<%# Bind("VALIDUNTIL") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <sbs:TimePicker ID="ProviderVALIDUNTIL" runat="server" Value='<%# Bind("VALIDUNTIL") %>' />
                    </center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <sbs:TimePicker ID="ProviderVALIDUNTIL" runat="server" />
                    </center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Bewerken"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Verwijderen"
                    OnClientClick="if(!confirm('Weet U zeker dat U dit ProviderNPRCertificate wilt verwijderen?')) return false;"></asp:LinkButton>
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
