<%@ Page Title="Home" Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="GUI.WebForms.Pages.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Estilo para el contenedor de la imagen */
        .img-placeholder {
            position: relative;
            width: 100%;
            padding-top: 56.25%; /* Mantiene un aspecto 16:9 */
            overflow: hidden;
            border-radius: 8px;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.15); /* Sombra para resaltar */
        }

        /* Estilo para la imagen */
        .img-placeholder img {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            object-fit: cover;
        }
    </style>
    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-4 g-4 w-100 m-auto" style="max-width:1200px">
        <asp:Repeater ID="ProductRepeater" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100 d-flex flex-column">
                        <figure class="card-img-top img-placeholder">
                            <!-- URL de imagen fija para todos los productos -->
                            <img src="../../Assets/Componente.png"/ alt="Imagen de producto" class="img-fluid" />
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