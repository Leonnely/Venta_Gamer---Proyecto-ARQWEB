<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="GUI.WebForms.Pages.carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Tu Carrito</h1>

    <asp:Repeater ID="rptCarrito" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Producto</th>
                        <th>Cantidad</th>
                        <th>Precio</th>
                        <th>Total</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("Producto") %></td>
                <td>
                    <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                </td>
                <td>$<%# Eval("Precio") %></td>
                <td>$<%# Eval("Total") %></td>
                <td>
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CommandArgument='<%# Eval("Producto") %>' OnClick="btnActualizar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("Producto") %>' OnClick="btnEliminar_Click" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
