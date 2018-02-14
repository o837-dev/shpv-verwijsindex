<%@ Page Language="C#" MasterPageFile="~/Garage.Master" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="GarageClient.Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/garage.css" rel="stylesheet" type="text/css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
    function controlGate(arg1, arg2) {
        var elm = document.getElementById('<%= gate.ClientID %>');
        if (elm != null) {
            elm.attributes["class"].value = arg1 + "_" + arg2;
        }
    }

</script>

    <table style="width: 50%;" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div style="float:left;"><asp:Button CssClass="btnDirection" ID="btnIn" runat="server" onclick="btnIn_Click" Text="Inrijden" /></div>
                <div style="float:right"><asp:Button CssClass="btnDirection" ID="btnOut" runat="server" onclick="btnOut_Click" Text="Uitrijden"/></div>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td rowspan="6">
                <div id="gate" name="gate" runat="server" style="width:375px; height:440px;background-color:Gray; background-repeat:no-repeat" >
                    <div style="position:relative; top:180px; left:50px; background-image:url('res/car_back.png'); width:264px; height:164px;">
                        <input runat="server" id="txtKenteken" type="text" style="position:relative; background-color:yellow; color:black; top:128px; left:60px; width:90px " value="KEN-TEK-EN" onfocus="ClearOnFocus(this);"/>
                        <input runat="server" id="txtLandcode" type="text" style="position:relative; background-color:yellow; color:black; top:128px; left:20px; width:20px " value="NL" onfocus="ClearOnFocus(this);" />
                        <input runat="server" id="txtKentekenType" type="text" style="position:relative; background-color:white; color:black; top:148px; left:10px; width:150px" value="LICENSE_PLATE" />
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="imgPark" runat="server" ImageUrl="res/P.png" alt="Park"
                    onclick="imgPark_Click" /><br /><br />
                <span style="margin-left:20px">AccessID</span><br />
                <asp:TextBox ID="txtAccessId" runat="server">NL-Park-001.01</asp:TextBox><br /><br />
                <span style="margin-left:20px">AreaManager</span><br />
                <asp:TextBox ID="txtAreaManagerId" runat="server">02065</asp:TextBox><br />
                <span style="margin-left:20px">Area</span><br />
                <asp:TextBox ID="txtArea" runat="server">CENTRUM</asp:TextBox><br />
                <div id="divUitrijden" runat="server">
                    <span style="margin-left:20px; color:Black">ProviderId</span><br />
                    <asp:TextBox ID="txtProviderId" runat="server"></asp:TextBox><br />
                    <span style="margin-left:20px; color:Black">PaymentAuthorisationId</span><br />
                    <asp:TextBox ID="txtPaymentAuthorisationId" runat="server"></asp:TextBox><br />
                </div>
            </td>
            <td style="background-position:right; background-repeat:no-repeat; vertical-align: top" >
                <div style="width:375px; height:100px; background-color:Gray;" id="prov01" runat="server" >
                    <div style="width:100%; height:20px; background-color:White">&nbsp;</div>
                    <br />&nbsp;Betaalprovider<br /><br />
                    <input id="srv01" runat="server" type="text" style="width:200px" value=""/>
                </div>
                
                <img id="kaartje" runat="server" style="padding-left:20px; position:fixed; top:250px" src="res/parkeerkaartje.jpg" alt="kaartje" />
                <img id="exclamination" runat="server" style="padding-left:90px; position:fixed; top:250px" src="res/Exclamation.png" alt="exclamination" />
                
            </td>
        </tr>
    </table>
</asp:Content>
