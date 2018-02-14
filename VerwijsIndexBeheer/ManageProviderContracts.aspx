<%@ Page Language="C#" MasterPageFile="~/Config.Master" AutoEventWireup="true" CodeBehind="ManageProviderContracts.aspx.cs" Inherits="Denion.WebService.Beheer.ManageProviderContracts" %>

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
                        <asp:DropDownList ID="contractAREAMANAGERID" DataTextField="DESCRIPTION" DataValueField="ID" runat="server" Enabled="false" /></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:DropDownList ID="contractAREAMANAGERID" DataTextField="DESCRIPTION" DataValueField="ID" runat="server" /></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:DropDownList ID="contractAREAMANAGERID" DataTextField="DESCRIPTION" DataValueField="ID" runat="server" /></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <%--            <asp:TemplateField HeaderText="PROVIDERID">
                <ItemTemplate>
                    <center><asp:DropDownList ID="contractPROVIDERID" DataTextField="DESCRIPTION" DataValueField="ID" runat="server" Enabled="false" /></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center><asp:DropDownList ID="contractPROVIDERID" runat="server" DataTextField="DESCRIPTION" DataValueField="ID" /></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center><asp:DropDownList ID="contractPROVIDERID" DataTextField="DESCRIPTION" DataValueField="ID" runat="server" /></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
             </asp:TemplateField>--%>

            <asp:TemplateField HeaderText="PROVIDERID2">
                <HeaderTemplate>
                    <center>PROVIDERID2<br />
                        <asp:DropDownList ID="fltrPROVIDERID2" DataTextField="DESCRIPTION" DataValueField="PID" AutoPostBack="true" OnSelectedIndexChanged="fltrPROVIDERID2_SelectedIndexChanged" runat="server" /></center>
                </HeaderTemplate>
                <ItemTemplate>
                    <center>
                        <asp:DropDownList ID="contractPROVIDERID2" DataTextField="DESCRIPTION" DataValueField="PID" runat="server" Enabled="false" /></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:DropDownList ID="contractPROVIDERID2" DataTextField="DESCRIPTION" DataValueField="PID" runat="server" /></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:DropDownList ID="contractPROVIDERID2" DataTextField="DESCRIPTION" DataValueField="PID" runat="server" /></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="PRIORITY">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="contractPRIORITY" Text='<%# Bind("PRIORITY") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:TextBox ID="contractPRIORITY" Text='<%# Bind("PRIORITY") %>' runat="server"></asp:TextBox></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:TextBox ID="contractPRIORITY" runat="server"></asp:TextBox></center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="SENDLINKREQUEST">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="contractSENDLINKREQUEST" Text='<%# Bind("SENDLINKREQUEST") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:DropDownList ID="contractSENDLINKREQUEST" runat="server" SelectedValue='<%# Bind("SENDLINKREQUEST") %>'>
                            <asp:ListItem>Implicit</asp:ListItem>
                            <%--<asp:ListItem>Explicit</asp:ListItem>--%>
                            <asp:ListItem>None</asp:ListItem>
                        </asp:DropDownList>
                    </center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:DropDownList ID="contractSENDLINKREQUEST" runat="server" SelectedValue='<%# Bind("SENDLINKREQUEST") %>'>
                            <asp:ListItem>Implicit</asp:ListItem>
                            <%--<asp:ListItem>Explicit</asp:ListItem>--%>
                            <asp:ListItem>None</asp:ListItem>
                        </asp:DropDownList>
                    </center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="LINKTYPE">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="contractLINKTYPE" Text='<%# Bind("LINKTYPE") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:DropDownList ID="contractLINKTYPE" runat="server" SelectedValue='<%# Bind("LINKTYPE") %>'>
                            <asp:ListItem>iNclusive</asp:ListItem>
                            <asp:ListItem>eXclusive</asp:ListItem>
                            <asp:ListItem>Overrule</asp:ListItem>
                        </asp:DropDownList>
                    </center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:DropDownList ID="contractLINKTYPE" runat="server" SelectedValue='<%# Bind("LINKTYPE") %>'>
                            <asp:ListItem>iNclusive</asp:ListItem>
                            <asp:ListItem>eXclusive</asp:ListItem>
                            <asp:ListItem>Overrule</asp:ListItem>
                        </asp:DropDownList>
                    </center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="RELAYINDICATOR">
                <ItemTemplate>
                    <center>
                        <asp:CheckBox ID="chkRELAYINDICATOR" Enabled="false" Checked='<%# Bind("RELAYINDICATOR") %>' runat="server" /></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:CheckBox ID="chkRELAYINDICATOR" Checked='<%# Bind("RELAYINDICATOR") %>' runat="server" /></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:CheckBox ID="chkRELAYINDICATOR" runat="server" /></center>
                </FooterTemplate>
            </asp:TemplateField>

			<asp:TemplateField HeaderText="NPRREGISTRATION">
                <ItemTemplate>
                    <center>
                        <asp:CheckBox ID="chkNPRREGISTRATION" Enabled="false" Checked='<%# Bind("NPRREGISTRATION") %>' runat="server" /></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <asp:CheckBox ID="chkNPRREGISTRATION" Checked='<%# Bind("NPRREGISTRATION") %>' runat="server" /></center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <asp:CheckBox ID="chkNPRREGISTRATION" runat="server" /></center>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="STARTDATE">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="contractSTARTDATE" Text='<%# Bind("STARTDATE") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <sbs:TimePicker ID="contractSTARTDATE" runat="server" Value='<%# Bind("STARTDATE") %>' />
                    </center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <sbs:TimePicker ID="contractSTARTDATE" runat="server" />
                    </center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ENDDATE">
                <ItemTemplate>
                    <center>
                        <asp:Label ID="contractENDDATE" Text='<%# Bind("ENDDATE") %>' runat="server"></asp:Label></center>
                </ItemTemplate>
                <EditItemTemplate>
                    <center>
                        <sbs:TimePicker ID="contractENDDATE" runat="server" Value='<%# Bind("ENDDATE") %>' />
                    </center>
                </EditItemTemplate>
                <FooterTemplate>
                    <center>
                        <sbs:TimePicker ID="contractENDDATE" runat="server" />
                    </center>
                </FooterTemplate>
                <ControlStyle Width="95%" />
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Bewerken"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Verwijderen"
                        OnClientClick="if(!confirm('Weet U zeker dat U dit Contract wilt verwijderen?')) return false;"></asp:LinkButton>
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
    </asp:GridView><br />
    <br />
    <br />
    <span>SENDLINKREQUEST</span>
    <ul>
        <li>N: No, geen autorisatieverzoeken voor voertuigen, waarvoor geen koppeling bestaat.</li>
        <%--<li>E: Expliciet, eerst een koppelingsverzoek sturen, bij een voertuig waarvoor nog geen koppeling bestaat</li>--%>
        <li>I: Impliciet, autorisatieverzoek sturen en als daar een positief antwoord op komt de koppeling registreren</li>
    </ul>
    <br />
    <span>LINKTYPE</span>
    <ul>
        <li>N: Niet exclusieve koppelingen: er mogen op hettzelfde prioriteitsniveau meerdere koppelingen bestaan. Bij autorisatie vragen wordt de volgorde door loting bepaald. </li>
        <li>X: (eXclusieve koppelingen):, Een koppelingsverzoek van een provider wordt afgewezen (met anonieme vermelding van de reden), als er reeds een koppeling bestaat van een andere provider</li>
        <li>O: Overneembare koppelingen: Een koppelingsverzoek van een provider vervangt een eventuele koppeling van een andere provider op hetzelfde niveau</li>
    </ul>
</asp:Content>
