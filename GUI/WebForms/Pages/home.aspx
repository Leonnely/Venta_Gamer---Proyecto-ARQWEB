<%@ Page Title="Home" Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="GUI.WebForms.Pages.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="products-container">
        <asp:Repeater ID="ProductRepeater" runat="server">
            <ItemTemplate>
                <div class="product-card">
                    <p class="product-category"><%# Eval("Category") %></p>
                    <h3><%# Eval("Title") %></h3>
                    <p>Precio: $<%# Eval("Price") %></p>
                    <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" 
                                CommandArgument='<%# Eval("Title") %>' 
                                OnClick="btnAgregarCarrito_Click" 
                                CssClass="btn-agregar-carrito" />
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