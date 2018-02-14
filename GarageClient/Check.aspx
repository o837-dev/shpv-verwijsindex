<%@ Page Title="" Language="C#" MasterPageFile="~/Garage.Master" AutoEventWireup="true" CodeBehind="Check.aspx.cs" Inherits="GarageClient.Check" %>

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
                <td>CheckDateTime
                </td>
                <td>
                    <asp:TextBox ID="txtCheckDateTime" runat="server"></asp:TextBox>
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
                <td>Provider
                </td>
                <td>
                    <asp:TextBox ID="txtProvider" runat="server"></asp:TextBox>
                </td>
            </tr>            
        </table>
        <br />
        <asp:Button ID="btnSendStart" runat="server" OnClick="Button1_Click" Text="Get response" />
        <br />
        <table>
            <tr>
                <td>AreaId
                </td>
                <td>
                    <asp:TextBox ID="txtResAreaId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Granted
                </td>
                <td>
                    <asp:TextBox ID="txtResGranted" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>ProviderId
                </td>
                <td>
                    <asp:TextBox ID="txtProviderId" runat="server"></asp:TextBox>
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
        </table>
    </div>
</asp:Content>
