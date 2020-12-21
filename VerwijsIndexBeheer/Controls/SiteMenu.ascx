<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteMenu.ascx.cs" Inherits="Denion.WebService.Beheer.Controls.SiteMenu" %>
<%--<style>
    .mnuCont {
        display: block;
        margin-left: -25px;
    }

        .mnuCont ul {
            display: inline-block;
            vertical-align: top;
            list-style: none;
            margin: 2px;
            padding-left: 4px;
            padding-bottom: 3px;
            border-left: solid 2px rgb(119,27,125);
            border-bottom: solid 2px rgb(119,27,125);
        }
        .mnuCont li{
            margin-top : 2px;
        }
        .mnuCont a {
            margin-left: 10px;
        }
</style>--%>

<div class="mnuCont">
    <ul>
        <li>Providers</li>
        <li>
            <a href="Providers.aspx">Providers</a>
            <a href="ManageProviderContracts.aspx">ProviderContract</a>
            <a href="ProviderCertificates.aspx">ProviderCertificates</a>
        </li>
    </ul>
    <ul>
        <li>Consumers</li>
        <li>
            <a href="Consumers.aspx">Consumers</a>
            <a href="ConsumerContract.aspx">ConsumerContract</a>
            <a href="TestParkingFacility.aspx">PMSsim</a>
        </li>
    </ul>
    <ul>
        <li>Settings</li>
        <li>
            <a href="AreaManager.aspx">AreaManagers</a>
            <a href="Settings.aspx">Settings</a>
            <a href="SellingPointToGeo.aspx">SellingPointToGeo</a>
            <a href="AreaGroups.aspx">AreaGroups</a>
            <a href="Types.aspx">Types</a>
            <a href="AreaManagerFix.aspx">AreaManagerCorrections</a>
            <a href="ProviderIdCorrections.aspx">ProviderIdCorrections</a>
        </li>
    </ul>
    <ul>
        <li>Data</li>
        <li>
            <a href="Authorisation.aspx">Authorisation</a>
            <a href="Link.aspx">Link</a>
            <a href="Search.aspx">Search</a>
            <a href="Log.aspx">Log</a>
            <a href="Messages.aspx">Messages</a>
        </li>
    </ul>
</div>
