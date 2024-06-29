<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="backup.aspx.cs" Inherits="GUI.WebForms.Pages.backup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Backup and Restore</title>
</head>
<body>
    <form id="frmBackup" runat="server">
        <div>
            <asp:Button ID="btnCreateBackup" runat="server" Text="Crear Backup" OnClick="btnCreateBackup_Click" />
        </div>
        <div>
            <asp:Button ID="btnRestoreBackup" runat="server" Text="Restaurar Backup" OnClick="btnRestoreBackup_Click" />
        </div>
        <div>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
