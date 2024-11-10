﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="GUI.WebForms.Pages.Productos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Productos</title>
    <style>
        body {
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
            color: #d9534f; /* Color rojo para mensajes de error */
        }
        .success {
            color: #5cb85c; /* Color verde para mensajes de éxito */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>