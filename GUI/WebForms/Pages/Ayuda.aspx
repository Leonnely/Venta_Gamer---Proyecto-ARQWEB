<%@ Page Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="Ayuda.aspx.cs" Inherits="GUI.WebForms.Pages.Ayuda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Estilos específicos para la página de ayuda */
        .ayuda-page {
            font-family: Arial, sans-serif;
            padding: 20px;
            text-align: center;
            color: #333;
        }

        .ayuda-page h1 {
            color: #007bff;
        }
    </style>

    <!-- Contenedor principal de la página de ayuda -->
    <div class="ayuda-page">
        <h1>Esta es una página de ayuda</h1>
    </div>
</asp:Content>

