<%@ Page Title="Recuperación de Contraseña" Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="GUI.WebForms.Session.PasswordReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Contenedor principal para la recuperación de contraseña */
        .password-reset-container {
            width: 400px;
            margin: 50px auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        /* Encabezado */
        .password-reset-container h2 {
            text-align: center;
            margin-bottom: 20px;
            font-size: 1.5rem;
            color: #2c3e50;
        }

        /* Estilos para las entradas y botones */
        .password-reset-input-group {
            display: flex;
            flex-direction: column;
            gap: 10px;
            margin: 15px 0;
        }

        .password-reset-input-group label {
            font-size: 0.9rem;
            color: #2c3e50;
        }

        .password-reset-input-group .form-control {
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 0.9rem;
        }

        .password-reset-input-group .form-control:focus {
            border-color: #2c3e50;
            outline: none;
            box-shadow: 0 0 5px rgba(44, 62, 80, 0.5);
        }

        .password-reset-input-group .btn {
            background-color: #2c3e50;
            color: white;
            border: none;
            padding: 10px;
            border-radius: 4px;
            font-size: 0.9rem;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .password-reset-input-group .btn:hover {
            background-color: #34495e;
        }

        .password-reset-input-group .btn:focus {
            outline: none;
            box-shadow: 0 0 5px rgba(44, 62, 80, 0.5);
        }
    </style>

    <div class="container">
        <h2>Recuperación de Credenciales</h2>

        <div class="div_input">
            <label for="TextBoxUsername">Nombre de usuario</label>
            <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="div_input">
            <label for="TextBoxRespuesta">Responda a la pregunta: ¿Cuál es su profesor favorito?</label>
            <asp:TextBox ID="TextBoxRespuesta" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Verificar" CssClass="btn btn-primary mt-2" OnClick="Button1_Click" />
        </div>
        <div class="div_input">
            <label for="TextBoxNewPass">Nueva contraseña</label>
            <asp:TextBox ID="TextBoxNewPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="ButtonEnviar" runat="server" Text="Confirmar" CssClass="btn btn-primary mt-2" OnClick="ButtonEnviar_Click" />
        </div>
    </div>
</asp:Content>
