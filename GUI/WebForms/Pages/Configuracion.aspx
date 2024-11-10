<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="GUI.WebForms.Pages.Configuracion" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Configuración Básica</title>
    <style>
        body { font-family: Arial, sans-serif; background-color: #f9f9f9; color: #333; margin: 0; padding: 20px; }
        .settings-container { max-width: 400px; margin: auto; padding: 20px; background-color: #fff; border-radius: 8px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); }
        h2 { color: #007bff; margin-bottom: 20px; }
        .form-row { margin-bottom: 15px; }
        .label { display: block; margin-bottom: 5px; font-weight: bold; color: #555; }
        select, input[type="text"] { width: 100%; padding: 8px; border: 1px solid #ddd; border-radius: 4px; }
        .help-link { color: #007bff; text-decoration: none; }
        .help-link:hover { text-decoration: underline; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="settings-container">
            

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
                <asp:HyperLink ID="lnkHelp" runat="server" NavigateUrl="~/WebForms/Pages/Ayuda.aspx" CssClass="help-link">Pagina de ayuda</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>