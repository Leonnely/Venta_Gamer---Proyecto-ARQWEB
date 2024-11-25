<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GUI.WebForms.Session.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="../../Styles/General.css" rel="stylesheet" type="text/css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <title>Pantalla de Login</title>
    <style>
        #wfrmLogin{
            height: 100dvh;
            display: flex;
            align-items: center;
            background-color: #2c3e50;
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
            background-color: white;
            box-shadow: 10px 10px 0px #ff29b3, -10px -10px 0px #1a0064;
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
        /*.login-container #btnLogin{
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
        }*/
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
                
                <asp:Button ID="btnLogin" CssClass="btn btn-outline-primary" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click" />
                <asp:Button ID="btnRegister" CssClass="btn btn-outline-secondary" runat="server" Text="Registrarse como cliente" OnClick="btnRegister_Click" CausesValidation="false"/>

            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
