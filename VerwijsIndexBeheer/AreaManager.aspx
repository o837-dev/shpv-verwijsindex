<%@ Page Language="C#" MasterPageFile="~/Config.Master" AutoEventWireup="true" CodeBehind="AreaManager.aspx.cs" Inherits="Denion.WebService.Beheer.AreaManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="cntnt" runat="server"><span class="intro">Content of table:&nbsp;&nbsp;&nbsp;&nbsp;</span><asp:Label CssClass="intro" ID="lblTable" runat="server"></asp:Label><br />
    <asp:Label CssClass="intro" ID="lblErr" runat="server"></asp:Label><br /></p>

    <asp:GridView ID="grd" runat="server"
        EnableModelValidation="True" 
        onrowcancelingedit="grd_RowCancelingEdit" onrowediting="grd_RowEditing"
        onrowupdating="grd_RowUpdating" DataKeyNames="ID"
        AutoGenerateColumns="False" onrowdeleting="grd_RowDeleting" 
        OnRowCommand="grd_RowCommand" ShowFooter="true" 
        onrowdatabound="grd_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <center><asp:Label ID="ProviderID" Text='<%# Bind("ID") %>' runat="server"></asp:Label></center>
                    </ItemTemplate>
                <EditItemTemplate>
                    <center><asp:TextBox ID="ProviderID" Text='<%# Bind("ID") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center><asp:TextBox ID="ProviderID" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
             </asp:TemplateField>

            <asp:TemplateField HeaderText="DESCRIPTION">
                <ItemTemplate>
                    <center><asp:Label ID="ProviderDESCRIPTION" Text='<%# Bind("DESCRIPTION") %>' runat="server"></asp:Label></center>
                    </ItemTemplate>
                <EditItemTemplate>
                    <center><asp:TextBox ID="ProviderDESCRIPTION" Text='<%# Bind("DESCRIPTION") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center><asp:TextBox ID="ProviderDESCRIPTION" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
             </asp:TemplateField>

             <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Bewerken"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Verwijderen" 
                    OnClientClick="if (!confirm ('Weet U zeker dat U deze AreaManager wilt verwijderen?') ) return false;" ></asp:LinkButton>
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
