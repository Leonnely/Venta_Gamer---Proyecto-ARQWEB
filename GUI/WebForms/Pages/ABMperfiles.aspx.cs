using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;


namespace GUI.WebForms.Pages
{
    public partial class ABMperfiles : System.Web.UI.Page
    {
        private List<Role> roles;
        private List<Permission> permissions;


        private void LoadRoles()
        {
            DDLFamilia.DataSource = null;
            roles = BLL_Perfil.GetRoles();
            DDLFamilia.DataSource = roles;
            DDLFamilia.DisplayMember = "Descripcion";
            DDLFamilia.ValueMember = "ID";
            DDLFamilia.SelectedIndex = -1;
        }

        private void LoadPermissions()
        {
            LstPermissions.DataSource = null;
            permissions = bllPerfil.GetPermissions();
            LstPermissions.DataSource = permissions;
            LstPermissions.DisplayMember = "Descripcion";
            LstPermissions.ValueMember = "ID";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}