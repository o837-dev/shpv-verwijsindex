<%@ Page Language="C#" MasterPageFile="~/Config.Master" AutoEventWireup="true" CodeBehind="TestParkingFacility.aspx.cs" Inherits="Denion.WebService.Beheer.TestParkingFacility" %>

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
        OnRowCommand="grd_RowCommand" ShowFooter="true"
        OnRowDataBound="grd_RowDataBound">

        <Columns>
            <asp:BoundField DataField="ID" Visible="false" HeaderText="ID" />

            <asp:TemplateField HeaderText="VEHICLEID">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="lblVehicleId" Text='<%# Bind("VehicleId") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:TextBox ID="VehicleId" Text='<%# Bind("VehicleId") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:TextBox ID="VehicleId" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="COUNTRYCODE">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="lblCountryCode" Text='<%# Bind("CountryCode") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:TextBox ID="CountryCode" Text='<%# Bind("CountryCode") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:TextBox ID="CountryCode" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="VEHICLEIDTYPE">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="lblVehicleIdType" Text='<%# Bind("VehicleIdType") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:TextBox ID="VehicleIdType" Text='<%# Bind("VehicleIdType") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:TextBox ID="VehicleIdType" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="STARTDATETIME">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="lblStartDateTime" Text='<%# Bind("StartDateTime") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <sbs:TimePicker ID="tpStartDateTime" runat="server" Value='<%# EvalDateTime(Container.DataItem, "StartDateTime") %>' />
                    </center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <sbs:TimePicker ID="tpStartDateTime" runat="server" />
                    </center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ENDDATE">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="lblEndDateTime" Text='<%# Bind("EndDateTime") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <sbs:TimePicker ID="tpEndDateTime" runat="server" Value='<%# EvalDateTime(Container.DataItem, "EndDateTime") %>' />
                    </center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <sbs:TimePicker ID="tpEndDateTime" runat="server" />
                    </center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="AREAMANAGERID">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="AreaManagerId" Text='<%# Bind("AreaManagerId") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:TextBox ID="AreaManagerId" Text='<%# Bind("AreaManagerId") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:TextBox ID="AreaManagerId" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="AREAID">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="AreaId" Text='<%# Bind("AreaId") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:TextBox ID="AreaId" Text='<%# Bind("AreaId") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:TextBox ID="AreaId" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="AMOUNT">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="lblAmount" Text='<%# Bind("Amount") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:TextBox ID="Amount" Text='<%# Bind("Amount") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:TextBox ID="Amount" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>


            <asp:TemplateField HeaderText="VAT">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="lblVat" Text='<%# Bind("Vat") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:TextBox ID="Vat" Text='<%# Bind("Vat") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:TextBox ID="Vat" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>


            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Bewerken"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Verwijderen"
                        OnClientClick="if (!confirm ('Weet U zeker dat U dit voertuig wilt verwijderen?') ) return false;"></asp:LinkButton>
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
