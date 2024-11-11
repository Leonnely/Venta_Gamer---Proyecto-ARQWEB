<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="GUI.WebForms.Pages.carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Tu Carrito</h1>

    <div class="cart-container">
        <asp:Repeater ID="rptCarrito" runat="server">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>Imagen</th>
                            <th>Producto</th>
                            <th>Cantidad</th>
                            <th>Precio</th>
                            <th>Subtotal</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <img src="../../Assets/Componente.png" alt="Imagen del producto" class="product-image" />
                    </td>
                    <td><%# Eval("Producto") %></td>
                    <td>
                        <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("Cantidad") %>' CssClass="cantidad-input" />
                    </td>
                    <td>$<%# Eval("Precio") %></td>
                    <td>$<%# Eval("Total") %></td>
                    <td>
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CommandArgument='<%# Eval("Producto") %>' CssClass="btn-accion" OnClick="btnActualizar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("Producto") %>' CssClass="btn-accion" OnClick="btnEliminar_Click" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <asp:Label ID="lblTotalCompra" CssClass="lbl-total-compra" runat="server" Text="Total: $0" />
        <asp:Button ID="btnConfirmarCompra" CssClass="btn-confirmar-compra" runat="server" Text="Confirmar compra" OnClick="btnConfirmarCompra_Click" />
    </div>
</asp:Content>
