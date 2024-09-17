using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.WebForms.Pages
{
    public partial class backup : System.Web.UI.Page
    {
        BLL_GestionDb gestionDB = new BLL_GestionDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBackupFiles();
            }
        }

        private void LoadBackupFiles()
        {
            string backupFolder = Server.MapPath("~/App_Data/");
            List<BackupFileInfo> backupFiles = new List<BackupFileInfo>();

            if (Directory.Exists(backupFolder))
            {
                string[] files = Directory.GetFiles(backupFolder, "*.bak");

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    backupFiles.Add(new BackupFileInfo
                    {
                        FileName = fileInfo.Name,
                        FilePath = fileInfo.FullName,
                        CreationDate = fileInfo.CreationTime
                    });
                }
                backupFiles = backupFiles.OrderByDescending(b => b.CreationDate).ToList();

            }
            else
            {
                lblMessage.Text = "La carpeta de backups no existe.";
            }

            gvBackups.DataSource = backupFiles;
            gvBackups.DataBind();
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            Button btnRestore = (Button)sender;
            string filePath = btnRestore.CommandArgument;

            string restoreLocation = filePath;

            bool isSuccess = gestionDB.RestoreDatabase(restoreLocation);

            if (isSuccess)
            {
                lblMessage.Text = "Base de datos restaurada exitosamente.";
            }
            else
            {
                lblMessage.Text = "Error al restaurar la base de datos.";
            }

            lblMessage.Text = "Backup restaurado desde: " + filePath;
        }


        protected void btnDownload_Click(object sender, EventArgs e)
        {
            Button btnDownload = (Button)sender;
            string filePath = btnDownload.CommandArgument;

            string BackupLocation = filePath;

            if (System.IO.File.Exists(BackupLocation))
            {
                // Obtener el nombre del archivo
                string fileName = System.IO.Path.GetFileName(BackupLocation);

                // Limpiar cualquier respuesta anterior
                Response.Clear();
                Response.ContentType = "application/octet-stream"; // Tipo de contenido para archivos binarios
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.TransmitFile(BackupLocation); // Transmitir el archivo al cliente
                Response.End(); // Finalizar la respuesta
            }
            else
            {
                // Manejar el caso donde el archivo no existe
                Response.Write("<script>alert('El archivo no existe.');</script>");
            }

        }

        protected void btnCreateBackup_Click(object sender, EventArgs e)
        {
            string formattedDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string nameBackup = "BK" + formattedDateTime + ".bak";
            string backupLocation = Server.MapPath("~/App_Data/") + nameBackup;
            bool isSuccess = gestionDB.CreateBackup(backupLocation);

            if (isSuccess)
            {
                lblMessage.Text = "Backup creado exitosamente.";
            }
            else
            {
                lblMessage.Text = "Error al crear el backup.";
            }

            LoadBackupFiles(); // Recargar la lista de backups después de crear uno nuevo
        }

        protected void gvBackups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


    
}

