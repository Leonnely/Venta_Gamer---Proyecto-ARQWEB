<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMperfiles.aspx.cs" Inherits="GUI.WebForms.Pages.ABMperfiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Gestion de perfiles<br />
            <br />
            <asp:Label ID="lblFamilia" runat="server" Text="Familia"></asp:Label>
            <br />
            <asp:DropDownList ID="DDLFamilia" runat="server" Height="16px" Width="140px">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="LblPermisosFamilia" runat="server" Text="Permisos Familia"></asp:Label>
            <br />
            <asp:ListBox ID="LBPermisosFamilia" runat="server" Height="126px" Width="136px"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="LblNombrePerfil" runat="server" Text="Nombre Perfil"></asp:Label>
            <br />
            <asp:TextBox ID="txtNombrePerfil" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblPermisosDisponibles" runat="server" Text="Permisos Disponibles"></asp:Label>
            <br />
            <asp:ListBox ID="LBPermisosDisponibles" runat="server" Height="129px" Width="133px"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="LblMensaje" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="BtnAñadirPerfil" runat="server" Text="Añadir Perfil" />
            <asp:Button ID="BtnModificarPerfil" runat="server" Text="Modificar Perfil" />
            <asp:Button ID="BtnEliminarPerfil" runat="server" Text="Eliminar Perfil" />
            <br />
            <br />
            <asp:Button ID="BtnAñadirPermiso" runat="server" Text="Añadir Permiso" />
            <asp:Button ID="BtnEliminarPermiso" runat="server" Text="Eliminar Permiso" />
            <br />
            <br />
            <asp:Button ID="BtnAplicar" runat="server" Text="Aplicar" />
            <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" />
        </div>
    </form>
</body>
</html>
