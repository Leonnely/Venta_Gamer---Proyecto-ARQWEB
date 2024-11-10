<%@ Page Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="GUI.WebForms.Pages.Configuracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Estilos específicos para la página de configuración */
        .configuracion-page {
            font-family: Arial, sans-serif;
            background-color: #f9f9f9;
            color: #333;
            padding: 20px;
        }
        
        .configuracion-page .settings-container {
            max-width: 400px;
            margin: auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .configuracion-page h2 {
            color: #007bff;
            margin-bottom: 20px;
        }

        .configuracion-page .form-row {
            margin-bottom: 15px;
        }

        .configuracion-page .label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555;
        }

        .configuracion-page select,
        .configuracion-page input[type="text"] {
            width: 100%;
            padding: 8px;
            border: 1px solid #ddd;
            border-radius: 4px;
        }

        .configuracion-page .help-link {
            color: #007bff;
            text-decoration: none;
        }

        .configuracion-page .help-link:hover {
            text-decoration: underline;
        }
    </style>

    <!-- Contenedor principal de la página de configuración -->
    <div class="configuracion-page">
        <div class="settings-container">
            <h2>Configuración Básica</h2>

            <!-- Nombre de usuario -->
            <div class="form-row">
                <asp:Label ID="LabelUser" runat="server" Text="Usuario: " CssClass="label"></asp:Label>
            </div>

            <!-- Selección de idioma -->
            <div class="form-row">
                <asp:Label ID="LabelIdioma" runat="server" Text="Idioma: " CssClass="label"></asp:Label>
            </div>

            <!-- Link a la página de ayuda -->
            <div class="form-row">
                <asp:HyperLink ID="lnkHelp" runat="server" NavigateUrl="~/WebForms/Pages/Ayuda.aspx" CssClass="help-link">Página de ayuda</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
