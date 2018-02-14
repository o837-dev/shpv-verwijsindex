<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConsumerService.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ConsumerService</title>
    <link href="/style/verwijsindex.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="content">
        <p class="heading1">
            <a href="/Demo">..</a> / ConsumerService
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
                        <td>Remark
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>RemarkId
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarkId" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Amount</td>
                        <td><asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>VAT</td>
                        <td><asp:TextBox ID="txtVAT" runat="server"></asp:TextBox></td>
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
                        <h3>CancelAuthorisationRequest</h3>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" >
                            <Columns>
                                <asp:BoundField DataField="AreaId" HeaderText="AreaId" />
                                <asp:BoundField DataField="AreaManagerId" HeaderText="AreaManagerId" />
                                <asp:BoundField DataField="CancelDateTime" HeaderText="CancelDateTime" />
                                <asp:BoundField DataField="CountryCode" HeaderText="CountryCode" />
                                <asp:BoundField DataField="PaymentAuthorisationId" HeaderText="PaymentAuthorisationId" />
                                <asp:BoundField DataField="ProviderId" HeaderText="ProviderId" />
                                <asp:BoundField DataField="VehicleId" HeaderText="VehicleId" />
                                <asp:BoundField DataField="VehicleIdType" HeaderText="VehicleIdType" />
                                 <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnRevoke" runat="server" CommandName="Revoke" Text="Revoke" CommandArgument='<%# Eval("sUUID") %>'></asp:LinkButton>
                                        <asp:LinkButton ID="btnGrant" runat="server" CommandName="Grant" Text="Grant Request*" CommandArgument='<%# Eval("sUUID") %>'></asp:LinkButton>
                                        <asp:LinkButton ID="btnGrantNow" runat="server" CommandName="GrantNow" Text="Grant Alt*" CommandArgument='<%# Eval("sUUID") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <h3>ActivateAuthorisationRequest</h3> 
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView2_RowCommand" >
                            <Columns>
                                <asp:BoundField DataField="AreaId" HeaderText="AreaId" />
                                <asp:BoundField DataField="AreaManagerId" HeaderText="AreaManagerId" />
                                <asp:BoundField DataField="CountryCode" HeaderText="CountryCode" />
                                <asp:BoundField DataField="PaymentAuthorisationId" HeaderText="PaymentAuthorisationId" />
                                <asp:BoundField DataField="ProviderId" HeaderText="ProviderId" />
                                <asp:BoundField DataField="VehicleId" HeaderText="VehicleId" />
                                <asp:BoundField DataField="VehicleIdType" HeaderText="VehicleIdType" />
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnRevoke" runat="server" CommandName="Revoke" Text="Revoke" CommandArgument='<%# Eval("sUUID") %>'></asp:LinkButton>
                                        <asp:LinkButton ID="btnGrant" runat="server" CommandName="Grant" Text="Grant Request*" CommandArgument='<%# Eval("sUUID") %>'></asp:LinkButton>
                                        <asp:LinkButton ID="btnGrantNow" runat="server" CommandName="GrantNow" Text="Grant Alt*" CommandArgument='<%# Eval("sUUID") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        <asp:Timer ID="TimerStatusUpdate" runat="server" Interval="997" OnTick="TimerStatusUpdate_Tick"
                            Enabled="False" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div>Request* = Grant with CancelDateTime</div>
                <div>Alt* = Grant with current DateTime</div>
                <br />
            </div>
        </form>
    </div>
</body>
</html>
