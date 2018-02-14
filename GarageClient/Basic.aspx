<%@ Page Title="" Language="C#" MasterPageFile="~/Garage.Master" AutoEventWireup="true" CodeBehind="Basic.aspx.cs" Inherits="GarageClient.Basic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>AreaManagerId
                </td>
                <td>
                    <asp:TextBox ID="txtAreaManagerId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>AreaId
                </td>
                <td>
                    <asp:TextBox ID="txtAreaId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>VehicleId
                </td>
                <td>
                    <asp:TextBox ID="txtVehicleId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>VehicleIdType
                </td>
                <td>
                    <asp:TextBox ID="txtVehicleIdType" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>CountryCode
                </td>
                <td>
                    <asp:TextBox ID="txtCountryCode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>AccessId
                </td>
                <td>
                    <asp:TextBox ID="txtAccessId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>StartDateTime
                </td>
                <td>
                    <asp:TextBox ID="txtStartDateTime" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>EndDateTime
                </td>
                <td>
                    <asp:TextBox ID="txtEndDateTime" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Amount
                </td>
                <td>
                    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>VAT
                </td>
                <td>
                    <asp:TextBox ID="txtVAT" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Token
                </td>
                <td>
                    <asp:TextBox ID="txtReqToken" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>TokenType
                </td>
                <td>
                    <asp:TextBox ID="txtReqTokenType" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnSendStart" runat="server" OnClick="Button1_Click" Text="Get response" />
        <br />
        <table>
            <tr>
                <td>ProviderId
                </td>
                <td>
                    <asp:TextBox ID="txtProviderId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>AuthorisationMaxAmount
                </td>
                <td>
                    <asp:TextBox ID="txtAuthorisationMaxAmount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>AuthorisationValidUntil
                </td>
                <td>
                    <asp:TextBox ID="txtAuthorisationValidUntil" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>PaymentAuthorisationId
                </td>
                <td>
                    <asp:TextBox ID="txtPaymentAuthorisationId" runat="server"></asp:TextBox>
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
                <td>Remark
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Token
                </td>
                <td>
                    <asp:TextBox ID="txtResToken" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Token
                </td>
                <td>
                    <asp:TextBox ID="txtResTokenType" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    
</asp:Content>
