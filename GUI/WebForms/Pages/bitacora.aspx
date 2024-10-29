<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bitacora.aspx.cs" Inherits="GUI.WebForms.Pages.bitacora" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../Styles/General.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/nav.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style>
        

    </style>
</head>
   
<body>
    <form id="frmBitacora" runat="server">
        <nav class="navbar">
            <div class="navbar--left">
                <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/WebForms/Pages/home.aspx" CssClass="nav-link">Home</asp:HyperLink>
                <asp:HyperLink ID="hlBitacora" runat="server" NavigateUrl="~/WebForms/Pages/bitacora.aspx" CssClass="nav-link">Bitacora</asp:HyperLink>
                <asp:HyperLink ID="hlBackup" runat="server" NavigateUrl="~/WebForms/Pages/backup.aspx" CssClass="nav-link">Gestion DB</asp:HyperLink>
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
                    <label for="txtAutor">Nombre del usuario.</label>
                    <input type="text" id="txtAutor" name="txtAutor" runat="server"/>
                </div>
                <div class="input-group">
                    <label for="txtFechaDesde">Periodo inicio.</label>
                    <input type="date" id="dtFechaDesde" name="dtFechaDesde" runat="server"/>
                </div>
                <div class="input-group">
                    <label for="txtFechaHasta">Periodo fin.</label>
                    <input type="date" id="dtFechaHasta" name="dtFechaHasta" runat="server"/>
                </div>
                    <asp:Button ID="btnAplicarFiltros" runat="server" Text="Aplicar filtros" OnClick="btnAplicarFiltros_Click" />
                </div>

            </div>
        </div>
    </form>
</body>
</html>
