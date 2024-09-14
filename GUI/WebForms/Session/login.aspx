<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GUI.WebForms.Session.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="../../Styles/General.css" rel="stylesheet" type="text/css" />
    <title>Pantalla de Login</title>
    <style>
        #wfrmLogin{
            height: 100dvh;
            display: flex;
            align-items: center;
        }
        div img {
            width: 300px;
        }

        .main_container{
            display: flex;
            justify-content: center;
            align-items:center;
            width: max-content;
            padding: 20px;
            margin: auto;
            box-shadow:  20px 20px 60px #bebebe,
                            -20px -20px 60px #ffffff;
        }
        .login-container {
            width: 100%;
            max-width:600px;
            padding: 20px;
        }
        .login-container h2 {
            text-align: start;
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
        <div class="main_container">
            <div>
                <img  src="../../Assets/logo.jpeg"/>
            </div>
            <div class="login-container">
                <h2>Iniciar sesión</h2>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            
                <asp:TextBox ID="txtUsername" runat="server" Placeholder="Nombre de Usuario"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" Class="validators" runat="server" ControlToValidate="txtUsername" ErrorMessage="Nombre de usuario es un campo obligatorio."></asp:RequiredFieldValidator>
            
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Contraseña"></asp:TextBox>
                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/WebForms/Session/PasswordReset.aspx">Olvide mi contraseña</asp:HyperLink>
                <asp:RequiredFieldValidator ID="rfvPassword" Class="validators" runat="server" ControlToValidate="txtPassword" ErrorMessage="Contraseña es un campo obligatorio."></asp:RequiredFieldValidator>
                

                <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click" />
                
            </div>
        </div>
    </form>
</body>
</html>
