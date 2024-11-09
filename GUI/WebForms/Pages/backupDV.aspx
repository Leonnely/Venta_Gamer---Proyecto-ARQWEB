<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="backupDV.aspx.cs" Inherits="GUI.WebForms.Pages.backupDV" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    <link href="../../Styles/General.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/nav.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="~/Content/bootstrap.min.css"/>
    
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
        <section class="main-content">
            <!-- Header de advertencia -->
            <div class="alert alert-danger mb-4 p-4 text-center">
                <h2 class="m-0">¡Inconsistencia detectada en la base de datos!</h2>
                <p class="m-0">Las siguientes tablas se ven afectadas:</p>
            </div>
            
            <!-- Lista de tablas afectadas -->
            <ul id="listTablas" runat="server" class="list-group mb-4 px-4">
                <!-- Items de las tablas se agregarán aquí -->
            </ul>
            
            <!-- Botones de acción -->
            <div class="d-flex gap-2">
                <asp:Button ID="btnRecalcularDV" runat="server" Text="Recalcular Dígito Verificador" 
                            OnClick="btnRecalcularDV_Click" CssClass="btn btn-warning" />
                
                <asp:Button ID="btnLogin" runat="server" Text="Volver al Login" 
                            OnClick="btnLogin_Click" CssClass="btn btn-secondary" />
            </div>

            <!-- Mensaje de estado -->
            <div class="mt-3 text-center">
                <asp:Label ID="lblMessage" runat="server" CssClass="text-info" Text=""></asp:Label>
            </div>
            <div class="container_grid">
                <asp:GridView ID="gvBackups" runat="server" AutoGenerateColumns="false" CssClass="gridview-backups">
                    <Columns>
                        <asp:BoundField DataField="FileName" HeaderText="Nombre del archivo" />
                        <asp:BoundField DataField="CreationDate" HeaderText="Fecha de creación" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <!-- Botón Restaurar con confirmación -->
                                <asp:Button ID="btnRestore" runat="server" Text="Restaurar" 
                                    CommandArgument='<%# Eval("FilePath") %>' 
                                    OnClick="btnRestore_Click" 
                                    OnClientClick="return confirm('¿Estás seguro de que quieres restaurar este archivo?');" 
                                    CssClass="btn btn-warning" />

                                <!-- Botón Descargar con confirmación -->
                                <asp:Button ID="btnDownload" runat="server" Text="Descargar" 
                                    CommandArgument='<%# Eval("FilePath") %>' 
                                    OnClick="btnDownload_Click" 
                                    OnClientClick="return confirm('¿Estás seguro de que quieres descargar este archivo?');" 
                                    CssClass="btn btn-primary" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </section>
    </form>
</body>
</html>
