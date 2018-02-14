<%@ Page Title="" Language="C#" MasterPageFile="~/Garage.Master" AutoEventWireup="true" CodeBehind="Raw.aspx.cs" Inherits="GarageClient.Raw" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span>Request</span><br />
    <asp:TextBox ID="tbAddress" runat="server" Columns="100" TextMode="MultiLine" Rows="1"></asp:TextBox><br />
    <asp:TextBox ID="tbRequest" runat="server" TextMode="MultiLine" Rows="15" Columns="100">&lt;?xml version=&quot;1.0&quot;?&gt;
&lt;s:Envelope xmlns:a=&quot;http://www.w3.org/2005/08/addressing&quot; xmlns:s=&quot;http://www.w3.org/2003/05/soap-envelope&quot;&gt;
  &lt;s:Header&gt;
    &lt;a:Action s:mustUnderstand=&quot;1&quot;&gt;https://verwijsindex.shpv.nl/service/VerwijsIndex/PaymentStart&lt;/a:Action&gt;
    &lt;a:MessageID&gt;raw&lt;/a:MessageID&gt;
    &lt;a:ReplyTo&gt;
      &lt;a:Address&gt;http://www.w3.org/2005/08/addressing/anonymous&lt;/a:Address&gt;
    &lt;/a:ReplyTo&gt;
  &lt;/s:Header&gt;
  &lt;s:Body&gt;
    &lt;PaymentStart xmlns=&quot;https://verwijsindex.shpv.nl/service/&quot;&gt;
      &lt;PaymentStartRequest xmlns:d4p1=&quot;https://verwijsindex.shpv.nl/messages/&quot; xmlns:i=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;
        &lt;d4p1:AreaManagerId&gt;02065&lt;/d4p1:AreaManagerId&gt;
        &lt;d4p1:AreaId&gt;CENTRUM&lt;/d4p1:AreaId&gt;
        &lt;d4p1:VehicleId&gt;KEN-TEK-EN&lt;/d4p1:VehicleId&gt;
        &lt;d4p1:CountryCode /&gt;
        &lt;d4p1:AccessId i:nil=&quot;true&quot; /&gt;
        &lt;d4p1:StartDateTime&gt;2016-05-20T14:00:00.0000000+02:00&lt;/d4p1:StartDateTime&gt;
        &lt;d4p1:EndDateTime i:nil=&quot;true&quot; /&gt;
        &lt;d4p1:Amount i:nil=&quot;true&quot; /&gt;
        &lt;d4p1:VAT i:nil=&quot;true&quot; /&gt;
        &lt;d4p1:Token i:nil=&quot;true&quot; /&gt;
        &lt;d4p1:VehicleIdType&gt;LICENSE_PLATE&lt;/d4p1:VehicleIdType&gt;
        &lt;d4p1:TokenType i:nil=&quot;true&quot; /&gt;
      &lt;/PaymentStartRequest&gt;
    &lt;/PaymentStart&gt;
  &lt;/s:Body&gt;
&lt;/s:Envelope&gt;</asp:TextBox><br />
    <asp:Button ID="btnSend" runat="server" Text="Send" onclick="btnSend_Click" /><br />
    <br />
    <span>Response</span><br />
    <asp:TextBox ID="tbResponse" runat="server" TextMode="MultiLine" Rows="15" Columns="100"></asp:TextBox><br />
    <span>Debug info</span><br />
    <asp:TextBox ID="tbDebug" runat="server" TextMode="MultiLine" Rows="10" Columns="100"></asp:TextBox><br />
</asp:Content>
