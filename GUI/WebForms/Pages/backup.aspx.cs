using BLL;
using System;
using System.Collections.Generic;
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

        }

        protected void btnCreateBackup_Click(object sender, EventArgs e)
        {
            string backupLocation = Server.MapPath("~/App_Data/") + "backup.bak";
            bool isSuccess = gestionDB.CreateBackup(backupLocation);

            if (isSuccess)
            {
                lblMessage.Text = "Backup creado exitosamente.";
            }
            else
            {
                lblMessage.Text = "Error al crear el backup.";
            }
        }

        protected void btnRestoreBackup_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                string restoreLocation = Server.MapPath("~/App_Data/") + fileUpload.FileName;
                fileUpload.SaveAs(restoreLocation);

                bool isSuccess = gestionDB.RestoreDatabase(restoreLocation);

                if (isSuccess)
                {
                    lblMessage.Text = "Base de datos restaurada exitosamente.";
                }
                else
                {
                    lblMessage.Text = "Error al restaurar la base de datos.";
                }
            }
            else
            {
                lblMessage.Text = "Por favor seleccione un archivo para restaurar.";
            }
        }
    }
}
