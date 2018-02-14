<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimePicker.ascx.cs" Inherits="WebControls.TimePicker" %>

<asp:Panel ID="Panel1" runat="server" Width="200px">
    <asp:TextBox runat="server" ID="txtDate" Width="90px" autocomplete="off" AutoPostBack="false" /> 
    <ajaxtoolkit:calendarextender ID="calDate" runat="server" TargetControlID="txtDate" Format="dd-MM-yyyy" />
    <asp:TextBox ID="tbHour" runat="server" MaxLength="2" Width="20px"></asp:TextBox>
    <asp:TextBox ID="tbMin" runat="server" MaxLength="2" Width="20px"></asp:TextBox>
    <asp:Label ID="lblDate" runat="server" class="error" Text="*" Visible="false"/>   
</asp:Panel>