<%@ Page Title="Home" Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="GUI.WebForms.Pages.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .img-placeholder {
        position: relative;
        width: 100%;
        padding-top: 56.25%; /* Aspect ratio de 16:9 (ajústalo según necesites) */
        background-image: url('ruta-imagen-alternativa.jpg');
        background-size: cover;
        background-position: center;
    }

    .img-placeholder img {
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        object-fit: cover;
    }

    </style>
    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-4 g-4 w-100 m-auto">
        <asp:Repeater ID="ProductRepeater" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100 d-flex flex-column">
                        <figure class="card-img-top img-placeholder">
                            <img src="...." alt="Agreguen imagenes 🤯🤯🤯🤯🤯" class="img-fluid">
                        </figure>
                        <div class="card-body flex-grow-1">
                            <p class="product-category"><%# Eval("Category") %></p>
                            <h3 class="card-title"><%# Eval("Title") %></h3>
                            <p>Precio: $<%# Eval("Price") %></p>
                        </div>
                        <div class="card-footer mt-auto">
                            <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" 
                                        CommandArgument='<%# Eval("Title") %>' 
                                        OnClick="btnAgregarCarrito_Click" 
                                        CssClass="btn-agregar-carrito" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="pagination-container pagination pagination-sm">
        <asp:Repeater ID="PaginationRepeater" runat="server">
            <ItemTemplate>
                <asp:LinkButton ID="lnkPage" runat="server" 
                                Text='<%# Eval("PageNumber") %>' 
                                CommandArgument='<%# Eval("PageNumber") %>' 
                                OnClick="lnkPage_Click" 
                                CssClass="page-link" />
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>




<%--<nav class="navbar">
    <div class="navbar--left">
        <asp:HyperLink ID="hlBitacora" runat="server" NavigateUrl="~/WebForms/Pages/bitacora.aspx" CssClass="nav-link">Bitacora</asp:HyperLink>
        <asp:HyperLink ID="hlUFP" runat="server" NavigateUrl="~/UFP.aspx" CssClass="nav-link">UFP</asp:HyperLink>
        <asp:HyperLink ID="hlEncriptacion" runat="server" NavigateUrl="~/Encriptacion.aspx" CssClass="nav-link">Encriptacion</asp:HyperLink>
        <asp:HyperLink ID="hlBackup" runat="server" NavigateUrl="~/Backup.aspx" CssClass="nav-link">Backup</asp:HyperLink>
        <asp:HyperLink ID="hlRestore" runat="server" NavigateUrl="~/Restore.aspx" CssClass="nav-link">Restore</asp:HyperLink>
    </div>
    <div class="navbar--right">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
</nav>--%>