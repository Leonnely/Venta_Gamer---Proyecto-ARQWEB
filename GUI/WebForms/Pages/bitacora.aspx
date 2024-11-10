<%@ Page Title="Backup" Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="bitacora.aspx.cs" Inherits="GUI.WebForms.Pages.bitacora" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Styles/General.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/nav.css" rel="stylesheet" type="text/css" />

    <div class="container my-4">
        <h2>Registros de <strong>Bitacora de eventos</strong></h2>

        <div class="mt-4">
            <div class="form-row d-flex gap-2 align-items-end mb-2">
                <div class="form-group col-md-4" style="max-width: 210px;">
                    <label for="txtAutor">Nombre del usuario</label>
                    <input type="text" id="txtAutor" name="txtAutor" runat="server" class="form-control" />
                </div>

                <div class="form-group col-md-4" style="max-width: 210px;">
                    <label for="dtFechaDesde">Periodo inicio</label>
                    <input type="date" id="dtFechaDesde" name="dtFechaDesde" runat="server" class="form-control" />
                </div>

                <div class="form-group col-md-4" style="max-width: 210px;">
                    <label for="dtFechaHasta">Periodo fin</label>
                    <input type="date" id="dtFechaHasta" name="dtFechaHasta" runat="server" class="form-control" />
                </div>

                <div class="form-group">
                    <asp:Button ID="btnAplicarFiltros" runat="server" Text="Aplicar filtros" CssClass="btn btn-primary align-self-end" OnClick="btnAplicarFiltros_Click" />
                </div>
            </div>
        </div>


        <div class="table-responsive " style="max-height: calc(100dvh - 390px);">
            <asp:Table ID="tbBitacora" runat="server" CssClass="table table-bordered table-hover"></asp:Table>
        </div>

    </div>
</asp:Content>
