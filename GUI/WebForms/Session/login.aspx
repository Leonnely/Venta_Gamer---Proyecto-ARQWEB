<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GUI.WebForms.Session.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="../../Styles/General.css" rel="stylesheet" type="text/css" />
    <title>Pantalla de Login</title>
    <style>
        .login-container {
            width: 100%;
            max-width:600px;
            margin: 4px auto;
            margin-top:100px;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        .login-container h2 {
            text-align: center;
        }
        .login-container input {
            width: 100%;
            padding: 10px;
            margin-top:15px;
        }
        .login-container #btnLogin{
            margin-top:20px;
            width: 100%;
            padding: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
        }
        .login-container button:hover {
            background-color: #45a049;
        }
        .validators{
            color:red;
            font-size:.8rem;
        }
    </style>
</head>
<body>
    <form id="wfrmLogin" runat="server">
        <div class="login-container">
            <h2>Iniciar sesión</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            
            <asp:TextBox ID="txtUsername" runat="server" Placeholder="Nombre de Usuario"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" Class="validators" runat="server" ControlToValidate="txtUsername" ErrorMessage="Nombre de usuario es un campo obligatorio."></asp:RequiredFieldValidator>
            
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Contraseña"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" Class="validators" runat="server" ControlToValidate="txtPassword" ErrorMessage="Contraseña es un campo obligatorio."></asp:RequiredFieldValidator>
            
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
