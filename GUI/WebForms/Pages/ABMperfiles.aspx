<%@ Page Title="Gestión de Perfiles" Language="C#" MasterPageFile="~/WebForms/Pages/MasterPage.master" AutoEventWireup="true" CodeBehind="ABMperfiles.aspx.cs" Inherits="GUI.WebForms.Pages.ABMperfiles" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4 overflow-auto" style="max-height: 80vh;">
        
        <div class="d-flex justify-content-between">
            <h2 class="mb-4">Gestión de Perfiles</h2>
            <asp:Label ID="LblMensaje" runat="server" CssClass="text-danger"></asp:Label>
        </div>

        <div class="mb-1">
            <asp:Button ID="BtnModificarPerfil" runat="server" Text="Modificar Perfil" CssClass="btn btn-warning me-2" OnClick="BtnModificarPerfil_Click" />
        </div>
        <div class="mb-2">
            <asp:Label ID="lblFamilia" runat="server" Text="Familia" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="DDLFamilia" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="DDLFamilia_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <div class="mb-2">
            <asp:Button ID="BtnAñadirPermiso" runat="server" Text="Añadir Permiso" CssClass="btn btn-success me-2" OnClick="BtnAñadirPermiso_Click" />
            <asp:Button ID="BtnEliminarPermiso" runat="server" Text="Eliminar Permiso" CssClass="btn btn-secondary me-2" OnClick="BtnEliminarPermiso_Click" />
        </div>

        <div class="mb-2">
            <asp:Label ID="LblPermisosFamilia" runat="server" Text="Permisos Familia" CssClass="form-label"></asp:Label>
            <asp:ListBox ID="LBPermisosFamilia" runat="server" CssClass="form-control" SelectionMode="Multiple" Rows="5"></asp:ListBox>
        </div>

        <hr />

        <div class="mb-1">
            <asp:Button ID="BtnAñadirPerfil" runat="server" Text="Añadir Perfil" CssClass="btn btn-primary me-2" OnClick="BtnAñadirPerfil_Click" />
            <asp:Button ID="BtnEliminarPerfil" runat="server" Text="Eliminar Perfil" CssClass="btn btn-danger me-2" OnClick="BtnEliminarPerfil_Click" />
        </div>

        <div class="mb-2">
            <asp:Label ID="LblNombrePerfil" runat="server" Text="Nombre Perfil" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtNombrePerfil" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-2">
            <asp:Label ID="LblPermisosDisponibles" runat="server" Text="Permisos Disponibles" CssClass="form-label"></asp:Label>
            <asp:ListBox ID="LBPermisosDisponibles" runat="server" CssClass="form-control" SelectionMode="Multiple" Rows="5" EnableViewState="true"></asp:ListBox>
        </div>


        <div class="mb-2 d-flex justify-content-end">
            <asp:Button ID="BtnAplicar" runat="server" Text="Aplicar" CssClass="btn btn-success me-2" OnClick="BtnAplicar_Click" />
            <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-outline-secondary" OnClick="BtnCancelar_Click" />
        </div>

    </div>
</asp:Content>
