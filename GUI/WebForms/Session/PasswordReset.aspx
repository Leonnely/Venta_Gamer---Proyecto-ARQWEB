<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="GUI.WebForms.Session.PasswordReset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Password Reset</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            margin: 0;
            padding: 0;
        }

        .container {
            width: 400px;
            margin: 50px auto;
            padding: 20px;
            background-color: white;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .div_input {
            display: flex;
            display: flex;
            flex-direction: column;
            gap: 4px;
            margin: 15px 0px;
        }
    </style>
</head>
<body>
    <form id="frmPassword" runat="server">
        <div class="container">
            <h1>Recuperacion de credenciales</h1>

            <div class="div_input">
                <label for="TextBoxUsername">Nombre de usuario</label>
                <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
            </div>
            <div class="div_input">
                <label for="TextBoxRespuesta">Responda a la pregunta ¿Cuál es su profesor favorito?</label>
                <asp:TextBox ID="TextBoxRespuesta" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Verificar" OnClick="Button1_Click" />
            </div>
            <div class="div_input">
                <label for="TextBoxNewPass">Nueva contraseña</label>
                <asp:TextBox ID="TextBoxNewPass" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonEnviar" runat="server" Text="Confirmar" OnClick="ButtonEnviar_Click" />

            </div>
        </div>
    </form>
</body>
</html>
