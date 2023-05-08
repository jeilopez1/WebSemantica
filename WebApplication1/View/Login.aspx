<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
        <asp:textbox id="Text1" type="text" Text="Usuario"  ></asp:textbox>
        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Iniciar Sesion" />

    </form>
</body>
</html>
