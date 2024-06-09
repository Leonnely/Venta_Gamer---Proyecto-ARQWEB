<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bitacora.aspx.cs" Inherits="GUI.WebForms.Pages.bitacora" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../Styles/General.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/nav.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style>
        .h2{
            margin:10px 0px;
        }

        .container-table{
            margin-top:10px;
            width:100%;
            min-width:300px;
            display:flex;
            gap:20px;
            justify-content:center;
        }

        .table-bitacora{
            width:100%;
            border-collapse:collapse;
        }

        .table-bitacora th, .table-bitacora td {
            border: 1px solid #ddd;
            padding: 8px;
        }

        .table-bitacora th {
            background-color: #f2f2f2;
            text-align: left;
        }

        .table-bitacora tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .table-bitacora tr:hover {
            background-color: #ddd;
        }

        .input-group {
            display: flex;
            flex-direction: column;
            margin-bottom: 1em;
        }
        label {
            margin-bottom: 0.5em;
        }
        input[type="text"],
        input[type="date"] {
            padding: 0.5em;
            font-size: 1em;
        }
    </style>
</head>
   
<body>
    <form id="frmBitacora" runat="server">
        <nav class="navbar">
            <div class="navbar--left">
                <asp:HyperLink ID="hlBitacora" runat="server" NavigateUrl="~/WebForms/Pages/bitacora.aspx" CssClass="nav-link">Bitacora</asp:HyperLink>
                <asp:HyperLink ID="hlUFP" runat="server" NavigateUrl="~/UFP.aspx" CssClass="nav-link">UFP</asp:HyperLink>
                <asp:HyperLink ID="hlEncriptacion" runat="server" NavigateUrl="~/Encriptacion.aspx" CssClass="nav-link">Encriptacion</asp:HyperLink>
                <asp:HyperLink ID="hlBackup" runat="server" NavigateUrl="~/Backup.aspx" CssClass="nav-link">Backup</asp:HyperLink>
                <asp:HyperLink ID="hlRestore" runat="server" NavigateUrl="~/Restore.aspx" CssClass="nav-link">Restore</asp:HyperLink>
            </div>
            <div class="navbar--right">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </div>
        </nav>

        <div>
            <h2>Registros de <strong>Bitacora de eventos</strong></h2>
            <div class="container-table">
                <div>
                    <asp:Table ID="tbBitacora" runat="server" CssClass="table-bitacora"></asp:Table>
                </div>
                <div>
                    <div class="input-group">
                        <label for="txtAutor">Nombre del autor.</label>
                        <input type="text" id="txtAutor" name="txtAutor"/>
                    </div>
                    <div class="input-group">
                        <label for="txtFechaDesde">Periodo inicio.</label>
                        <input type="date" id="dtFechaDesde" name="dtFechaDesde"/>
                    </div>
                    <div class="input-group">
                        <label for="txtFechaHasta">Periodo fin.</label>
                        <input type="date" id="dtFechaHasta" name="dtFechaHasta"/>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
