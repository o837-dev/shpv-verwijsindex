<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebControls.WebForm1" %>

<%@ Register assembly="WebControls" namespace="WebControls" tagprefix="reef" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <reef:EditerControl ID="EditerControl1" runat="server" Text =" das " />
        <select>
            <option value="1">een</option>
        </select>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"   />
    </form>
</body>
</html>
