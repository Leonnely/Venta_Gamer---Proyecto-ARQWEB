<%@ Page Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="DetalleCompra.aspx.cs" Inherits="GUI.WebForms.Pages.DetalleCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Estilos específicos para DetalleCompra */
        .detalle-compra {
            font-family: Arial, sans-serif;
            color: #333;
            background-color: #f5f5f5;
        }
        .detalle-compra .container {
            width: 80%;
            max-width: 800px;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .detalle-compra .titulo {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
            text-align: center;
            color: #4CAF50;
        }
        .detalle-compra .item-list {
            margin-bottom: 20px;
        }
        .detalle-compra .item {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }
        .detalle-compra .item:last-child {
            border-bottom: none;
        }
        .detalle-compra .item strong {
            color: #333;
        }
        .detalle-compra .total {
            text-align: right;
            font-size: 18px;
            font-weight: bold;
            color: #333;
            margin-top: 20px;
        }
        .detalle-compra .btn-descargar {
            display: block;
            width: 100%;
            padding: 10px;
            font-size: 16px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            text-align: center;
        }
        .detalle-compra .btn-descargar:hover {
            background-color: #45a049;
        }
    </style>

    <div class="detalle-compra">
        <div class="container">
            <div class="titulo">Detalle de la Compra</div>

            <!-- Listado de Items Comprados -->
            <div class="item-list" id="listaCompras" runat="server">
                <!-- El contenido se generará desde el código detrás -->
            </div>

            <!-- Total de la Compra -->
            <div class="total" id="totalCompraDiv" runat="server">
                <!-- Mostrar el total aquí -->
            </div>

            <!-- Botón para Descargar el PDF -->
            <asp:Button ID="btnDownloadPDF" CssClass="btn-descargar" runat="server" Text="Descargar Resumen en PDF" OnClick="btnDownloadPDF_Click" />
        </div>
    </div>
</asp:Content>
