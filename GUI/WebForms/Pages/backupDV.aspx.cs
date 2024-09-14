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
    public partial class backupDV : System.Web.UI.Page
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
                string script = @"
                    alert('Base de datos restaurada exitosamente!, redirigiendo al login');
                    setTimeout(function() {
                        window.location.href = '~/WebForms/Session/login.aspx';
                    }, 5000);
                ";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                Session.Abandon();
                Response.Redirect("~/WebForms/Session/login.aspx");
            }
            else
            {
                lblMessage.Text = "Error al restaurar la base de datos.";
            }

            lblMessage.Text = "Backup restaurado desde: " + filePath;
        }

        protected void gvBackups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}