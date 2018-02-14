<%@ Page Language="C#" MasterPageFile="~/Config.Master" AutoEventWireup="true" CodeBehind="ContractUniqueness.aspx.cs" Inherits="Denion.WebService.Beheer.ContractUniqueness" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="cntnt" runat="server"><span class="intro">Content of table:&nbsp;&nbsp;&nbsp;&nbsp;</span><asp:Label CssClass="intro" ID="lblTable" runat="server"></asp:Label><br /><br />
    <asp:Label CssClass="intro" ID="lblErr" runat="server"></asp:Label><br /></p>
    <br />
    <br />
    <asp:GridView ID="grd" runat="server"
        EnableModelValidation="True" 
        onrowcancelingedit="grd_RowCancelingEdit" onrowediting="grd_RowEditing"
        onrowupdating="grd_RowUpdating" DataKeyNames="ID"
        AutoGenerateColumns="False" OnRowCommand="grd_RowCommand" 
        ShowFooter="true" onrowdatabound="grd_RowDataBound" 
        onrowdeleting="grd_RowDeleting">
        <Columns>
            <asp:BoundField DataField="ID" Visible="false" HeaderText="ID" />

            <asp:TemplateField HeaderText="AREAMANAGERID">
                <HeaderTemplate>
                    <center>AREAMANAGERID<br/><asp:DropDownList ID="fltrAREAMANAGERID" DataTextField="DESCRIPTION" DataValueField="ID" AutoPostBack="true" OnSelectedIndexChanged="fltrAREAMANAGERID_SelectedIndexChanged" runat="server"/></center>
                </HeaderTemplate>
                <ItemTemplate>
                    <center><asp:DropDownList ID="contractUniquenessAREAMANAGERID" DataTextField="DESCRIPTION" DataValueField="ID" runat="server" Enabled="false"/></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center><asp:DropDownList ID="contractUniquenessAREAMANAGERID" DataTextField="DESCRIPTION" DataValueField="ID" runat="server"/></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center><asp:DropDownList ID="contractUniquenessAREAMANAGERID" DataTextField="DESCRIPTION" DataValueField="ID" runat="server" /></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
             </asp:TemplateField>

            <asp:TemplateField HeaderText="PRIORITY">
                <ItemTemplate>
                    <center><asp:Label ID="contractUniquenessPRIORITY" Text='<%# Bind("PRIORITY") %>' runat="server" ></asp:Label></center>
                    </ItemTemplate>
                <EditItemTemplate>
                    <center><asp:TextBox ID="contractUniquenessPRIORITYEdit" Text='<%# Bind("PRIORITY") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center><asp:TextBox ID="contractUniquenessPRIORITYFooter" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
             </asp:TemplateField>

            <asp:TemplateField HeaderText="ISUNIQUE">
                <ItemTemplate>
                    <center><asp:CheckBox ID="contractUniquenessISUNIQUE" Enabled="false" Checked='<%# Bind("ISUNIQUE") %>' runat="server" /></center>
                    </ItemTemplate>
                <EditItemTemplate>
                    <center><asp:CheckBox ID="contractUniquenessISUNIQUE" Checked='<%# Bind("ISUNIQUE") %>' runat="server" /></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center><asp:CheckBox ID="contractUniquenessISUNIQUE" runat="server" /></center>
                </FooterTemplate>
             </asp:TemplateField>

            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Bewerken"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Verwijderen" 
                    OnClientClick="if(!confirm('Weet U zeker dat U deze uniciteit wilt verwijderen?')) return false;" ></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Opslaan"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Annuleren"></asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btnAdd" runat="server" Text="Toevoegen" CommandName="Insert"/>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
