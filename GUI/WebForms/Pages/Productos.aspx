<%@ Page Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="GUI.WebForms.Pages.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Estilos generales para toda la página de productos */
        .productos-page {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }
        
        .container {
            max-width: 500px;
            margin: auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
        }

        h2 {
            text-align: center;
            color: #333;
        }

        label {
            font-weight: bold;
            margin-bottom: 5px;
            display: block;
            color: #555;
        }

        input[type="text"],
        select {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ddd;
            border-radius: 4px;
            transition: border-color 0.3s;
        }

        input[type="text"]:focus,
        select:focus {
            border-color: #007bff;
            outline: none;
        }

        .btn {
            background-color: #007bff;
            color: white;
            padding: 10px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            width: 100%;
            font-size: 16px;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        .message {
            margin-top: 10px;
            text-align: center;
            color: #d9534f;
        }

        .success {
            color: #5cb85c; /* Color verde para mensajes de éxito */
        }
    </style>

    <!-- Contenedor para cargar productos -->
    <div class="productos-page">
        <div class="container">
            <h2>Cargar Producto</h2>
            <label for="ddlCategory">Categoría:</label>
            <asp:DropDownList ID="ddlCategory" runat="server" />
            
            <label for="txtTitle">Título:</label>
            <asp:TextBox ID="txtTitle" runat="server" placeholder="Ingrese el título del producto" />
            
            <label for="txtPrice">Precio:</label>
            <asp:TextBox ID="txtPrice" runat="server" placeholder="Ingrese el precio del producto" />
            
            <asp:Button ID="btnSubmit" runat="server" Text="Cargar Producto" CssClass="btn" OnClick="btnSubmit_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="message" Text="" />
        </div>
    </div>

    <!-- Contenedor para la modificación de productos -->
    <div class="productos-page">
        <div class="container">
            <h2>Modificar Producto</h2>
            <label for="ddlEditProduct">Selecciona un Producto:</label>
            <asp:DropDownList ID="ddlEditProduct" runat="server" OnSelectedIndexChanged="ddlEditProduct_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Selecciona un producto" Value="0" />
            </asp:DropDownList>

            <label for="txtEditTitle">Nuevo Título:</label>
            <asp:TextBox ID="txtEditTitle" runat="server" placeholder="Nuevo título del producto" />

            <label for="txtEditPrice">Nuevo Precio:</label>
            <asp:TextBox ID="txtEditPrice" runat="server" placeholder="Nuevo precio del producto" />

            <label for="ddlEditCategory">Nueva Categoría:</label>
            <asp:DropDownList ID="ddlEditCategory" runat="server"></asp:DropDownList>

            <asp:Button ID="btnUpdateProduct" runat="server" Text="Actualizar Producto" CssClass="btn" OnClick="btnUpdateProduct_Click" />
            <asp:Label ID="lblUpdateMessage" runat="server" CssClass="message" Text="" />
        </div>
    </div>

    <!-- Contenedor para eliminar productos -->
    <div class="productos-page">
        <div class="container">
            <h2>Eliminar Producto</h2>
            <label for="ddlProducts">Selecciona el producto a eliminar:</label>
            <asp:DropDownList ID="ddlProducts" runat="server" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged" />
            
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar Producto" CssClass="btn" OnClick="btnDelete_Click" />
            <asp:Label ID="lblDeleteMessage" runat="server" CssClass="message" Text="" />
        </div>
    </div>
</asp:Content>