<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="GUI.WebForms.Session.PasswordReset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <p>This is a password reset page</p>

        </div>

        <asp:Label ID="Label3" runat="server" Text="Nombre de usuario"></asp:Label> <br />

        <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox><br /> 

        <asp:Label ID="Label1" runat="server" Text="Responda a la pregunta ¿Cual es su profesor favorito?"></asp:Label> <br />

        <asp:TextBox ID="TextBoxRespuesta" runat="server"></asp:TextBox><br /> 
        <asp:Button ID="Button1" runat="server" Text="Verificar" OnClick="Button1_Click" /><br /><br />

        <asp:Label ID="Label2" runat="server" Text="Nueva contraseña"></asp:Label> <br />
        <asp:TextBox ID="TextBoxNewPass" runat="server"></asp:TextBox><br />
        <asp:Button ID="ButtonEnviar" runat="server" Text="Confirmar" OnClick="ButtonEnviar_Click" />
    </form>
</body>
</html>
