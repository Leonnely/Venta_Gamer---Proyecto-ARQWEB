<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="GUI.WebForms.Session.Registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de Usuario</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registro de Usuario</h2>
            <asp:Label ID="lblUsername" runat="server" Text="Nombre de usuario:" />
            <asp:TextBox ID="txtUsername" runat="server" />
            <br />Rol:
            <asp:DropDownList ID="DDLrol" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña:" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            <br /><br />
            <asp:Button ID="btnRegister" runat="server" Text="Registrar" OnClick="btnRegister_Click" />
            <br /><br />
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" />
        </div>
    </form>
</body>
</html>