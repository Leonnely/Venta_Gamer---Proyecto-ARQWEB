<%@ Page Title="Registro de Usuario" Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="GUI.WebForms.Session.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .form-container {
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
            max-width: 400px;
            width: 100%;
            margin: auto;
        }

        .form-container h2 {
            text-align: center;
            margin-bottom: 20px;
        }

        .form-container .btn {
            width: 100%;
        }

        .form-container .message {
            text-align: center;
            margin-top: 10px;
        }
    </style>

    <div class="form-container">
        <h2>Registro de Usuario</h2>
        <div class="mb-3">
            <asp:Label ID="lblUsername" runat="server" Text="Nombre de usuario:" CssClass="form-label" />
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <asp:Label ID="lblRole" runat="server" Text="Rol:" CssClass="form-label" />
            <asp:DropDownList ID="DDLrol" runat="server" CssClass="form-select">
            </asp:DropDownList>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña:" CssClass="form-label" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
        </div>
        <asp:Button ID="btnRegister" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
        <asp:Label ID="lblMessage" runat="server" CssClass="message text-danger" />
    </div>
</asp:Content>
