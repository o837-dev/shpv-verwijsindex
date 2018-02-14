<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="Denion.Web.ProviderClient.Demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <asp:UpdatePanel ID="upd" runat="server">
    <ContentTemplate>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Start" onclick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            Text="Stop" />
                <asp:Timer ID="TimerStatusUpdate" runat="server" Interval="500" 
                    OnTick="TimerStatusUpdate_Tick" Enabled="False" />    
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
