<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CaptchaProject.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Home</title>
</head>
<body>
    <h1>Captcha</h1>
    <form id="form1" runat="server">
        <asp:Image ID="bitmap" ImageUrl="~/CallCaptcha.aspx" runat="server" />
        <br />
        <asp:TextBox ID="userInput" runat="server" />
        <br />
        <asp:Button ID="confirm" Text="Confirm" runat="server" />
        <br />
        <asp:Label ID="error" runat="server" />
    </form>
</body>
</html>
