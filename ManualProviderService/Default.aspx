<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ManualProviderService.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProviderService</title>
    <link href="/style/verwijsindex.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="content">
        <p class="heading1">
            <a href="/Demo">..</a> / ProviderService
        </p>
        <br />
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div>
                <span class="intro">Instellingen</span><br />
                <br />
                <table>

                    <tr>
                        <td>ProviderId
                        </td>
                        <td>
                            <asp:Label ID="lblProviderId" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>ValidFrom
                        </td>
                        <td>
                            <asp:TextBox ID="txtValidFrom" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ValidUntil
                        </td>
                        <td>
                            <asp:TextBox ID="txtValidUntil" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnRefresh" runat="server" Text="Auto Refresh" OnClick="btnRefresh_Click" />
                        </td>
                    </tr>
                </table>
                <span class="intro">Binnenkomende verzoeken</span><br />
                <br />
                <asp:UpdatePanel ID="upd" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>PaymentAuthorisationId
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPaymentAuthorisationId" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                        <%--<h3>LinkRequests</h3>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView2_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="VehicleId" HeaderText="VehicleId" />
                                <asp:BoundField DataField="CountryCode" HeaderText="CountryCode" />
                                <asp:BoundField DataField="ProviderId" HeaderText="ProviderId" />
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnGrant" runat="server" CommandName="Grant" Text="Grant" CommandArgument='<%# Eval("sUUID") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />--%>
                        <h3>PaymentStartRequest</h3>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="AccessId" HeaderText="AccessId" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                <asp:BoundField DataField="AreaId" HeaderText="AreaId" />
                                <asp:BoundField DataField="AreaManagerId" HeaderText="AreaManagerId" />
                                <asp:BoundField DataField="CountryCode" HeaderText="CountryCode" />
                                <asp:BoundField DataField="EndDateTime" HeaderText="EndDateTime" />
                                <asp:BoundField DataField="StartDateTime" HeaderText="StartDateTime" />
                                <asp:BoundField DataField="VAT" HeaderText="VAT" />
                                <asp:BoundField DataField="VehicleId" HeaderText="VehicleId" />
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnGrant" runat="server" CommandName="Grant" Text="Grant" CommandArgument='<%# Eval("sUUID") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Timer ID="TimerStatusUpdate" runat="server" Interval="1000" OnTick="TimerStatusUpdate_Tick"
                            Enabled="False" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </form>
    </div>
</body>
</html>
