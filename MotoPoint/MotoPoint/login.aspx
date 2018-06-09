<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" 
    Inherits="MotoPoint.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:TextBox runat="server" ID="txtUsuario"></asp:TextBox><br />
            <br />
            <asp:TextBox runat="server" ID="txtContrasenia" TextMode="Password"></asp:TextBox><br />
            <br />
            <asp:LinkButton ID="linkRegistrarse" runat="server">Registrarse</asp:LinkButton>
             |
            <asp:LinkButton ID="linkRecordar" runat="server">Recordar</asp:LinkButton>
            <br />
            <br />
            <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" />
        </div>
    </div>
    </form>
</body>
</html>
