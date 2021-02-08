<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="CaptchaProject.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Welcome</title>
</head>
<body>
    <h1>Welcome !</h1>
    <p>Correct captcha code.</p>
    <asp:Image ID="secondCaptcha" ImageUrl="~/views/CallSecondCaptcha.aspx" runat="server" />
</body>
</html>
