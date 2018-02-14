<%@ Page Language="C#" MasterPageFile="~/Config.Master" AutoEventWireup="true" CodeBehind="SellingPointToGeo.aspx.cs" Inherits="Denion.WebService.Beheer.SellingPointToGeo" %>

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
        OnRowDataBound="grd_RowDataBound" >

        <Columns>
            <asp:BoundField DataField="ID" Visible="false" HeaderText="ID" />

            <asp:TemplateField HeaderText="AreaManagerId">
                <ItemTemplate>
                    <center><asp:Label ID="AreaManagerId" Text='<%# Bind("AreaManagerId") %>' runat="server"></asp:Label></center>
                    </ItemTemplate>
                <EditItemTemplate>
                    <center><asp:TextBox ID="AreaManagerId" Text='<%# Bind("AreaManagerId") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center><asp:TextBox ID="AreaManagerId" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
             </asp:TemplateField>

            <asp:TemplateField HeaderText="AreaId">
                <ItemTemplate>
                    <center><asp:Label ID="AreaId" Text='<%# Bind("AreaId") %>' runat="server"></asp:Label></center>
                    </ItemTemplate>
                <EditItemTemplate>
                    <center><asp:TextBox ID="AreaId" Text='<%# Bind("AreaId") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center><asp:TextBox ID="AreaId" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
             </asp:TemplateField>

            <asp:TemplateField HeaderText="Latitude">
                <ItemTemplate>
                    <center><asp:Label ID="Latitude" Text='<%# Bind("Latitude") %>' runat="server"></asp:Label></center>
                    </ItemTemplate>
                <EditItemTemplate>
                    <center><asp:TextBox ID="Latitude" Text='<%# Bind("Latitude") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center><asp:TextBox ID="Latitude" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
             </asp:TemplateField>

            <asp:TemplateField HeaderText="Longitude">
                <ItemTemplate>
                    <center><asp:Label ID="Longitude" Text='<%# Bind("Longitude") %>' runat="server"></asp:Label></center>
                    </ItemTemplate>
                <EditItemTemplate>
                    <center><asp:TextBox ID="Longitude" Text='<%# Bind("Longitude") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center><asp:TextBox ID="Longitude" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
             </asp:TemplateField>

            <asp:TemplateField HeaderText="Maps">
                <ItemTemplate>
                    <center><asp:Label ID="Maps" Text='<%# URL(Container.DataItem) %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate />
                <FooterTemplate/>
                
                <ControlStyle Width="95%" />
             </asp:TemplateField>

            <asp:TemplateField HeaderText="SellingPointId">
                <ItemTemplate>
                    <center><asp:Label ID="SellingPointId" Text='<%# Bind("SellingPointId") %>' runat="server"></asp:Label></center>
                    </ItemTemplate>
                <EditItemTemplate>
                    <center><asp:TextBox ID="SellingPointId" Text='<%# Bind("SellingPointId") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center><asp:TextBox ID="SellingPointId" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
             </asp:TemplateField>

             <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Bewerken"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Verwijderen" 
                    OnClientClick="if (!confirm ('Weet U zeker dat U dit verkooppunt wilt verwijderen?') ) return false;" ></asp:LinkButton>
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
