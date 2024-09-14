<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="backup.aspx.cs" Inherits="GUI.WebForms.Pages.backup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Backup and Restore</title>
    <link href="../../Styles/General.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/nav.css" rel="stylesheet" type="text/css" />
    <style>

        .main-content{

        }

        .create_backup {
            text-align: center;
            margin: 10px;
            padding: 10px;
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }



        .create_backup button {
            padding: 10px 20px;
            font-size: 16px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .create_backup button:hover {
            background-color: #45a049;
        }

        .container_grid {
            max-height: calc(100vh - 105px); /* Ajusta este valor según sea necesario */
            overflow-y: auto;
            position: relative;
        }

        .container_grid table {
            width: 100%;
            border-collapse: collapse;
        }

        .container_grid th, .container_grid td {
            padding: 10px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        .container_grid th {
            background-color: #4CAF50;
            color: white;
            position: sticky;
            top: 0;
            z-index: 1;
        }

        .container_grid td button {
            padding: 5px 10px;
            font-size: 14px;
            background-color: #f44336;
            color: white;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        .container_grid td button:hover {
            background-color: #d32f2f;
        }

        .message_container {
            margin-top: 20px;
            text-align: center;
            font-size: 16px;
            color: #333;
        }
    </style>
</head>
    
<body>
    <form id="frmBackup" runat="server">
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
        <section class="main-content">
            <div>
                <asp:Button ID="btnCreateBackup" runat="server"  Text="Crear Backup" OnClick="btnCreateBackup_Click" CssClass="create_backup" />
            </div>
        
            <div styles="margin-left:5px;">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
            <div class="container_grid">
                <asp:GridView ID="gvBackups" runat="server" AutoGenerateColumns="false" CssClass="gridview-backups">
                    <Columns>
                        <asp:BoundField DataField="FileName" HeaderText="Nombre del archivo" />
                        <asp:BoundField DataField="CreationDate" HeaderText="Fecha de creación" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button ID="btnRestore" runat="server" Text="Restaurar" CommandArgument='<%# Eval("FilePath") %>' OnClick="btnRestore_Click" CssClass="btn-restore" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </section>
    </form>
</body>
</html>
