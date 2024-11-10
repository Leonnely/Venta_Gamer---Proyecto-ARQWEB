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
using SECURITY;


namespace GUI.WebForms.Pages
{
    public partial class ABMperfiles : System.Web.UI.Page
    {
        private List<Role> roles;
        private List<Permission> permissions;
        private BLL_Perfil bllPerfil = new BLL_Perfil();
        private List<string> permisosUsuario;



        private void LoadRoles()
        {
            DDLFamilia.DataSource = null;
            roles = bllPerfil.GetRoles();
            DDLFamilia.DataSource = roles;
            DDLFamilia.DataTextField = "Descripcion";
            DDLFamilia.DataValueField = "ID";
            DDLFamilia.DataBind();
            DDLFamilia.Items.Insert(0, new ListItem("-- Seleccione un rol --", string.Empty));
        }

        private void LoadPermissions()
        {
            LBPermisosDisponibles.DataSource = null;
            permissions = bllPerfil.GetPermissions();
            LBPermisosDisponibles.DataSource = permissions;
            LBPermisosDisponibles.DataTextField = "Descripcion";
            LBPermisosDisponibles.DataValueField = "ID";
            LBPermisosDisponibles.DataBind();
        }
        private void InicializarFormulario()
        {
            LoadRoles();
            LoadPermissions();
            DeshabilitarBotones();
        }
        private void DeshabilitarBotones()
        {
            BtnCancelar.Enabled = false;
            BtnAplicar.Enabled = false;
            BtnAñadirPerfil.Enabled = true;
            BtnModificarPerfil.Enabled = true;
            BtnEliminarPerfil.Enabled = true;
            BtnAñadirPermiso.Enabled = false;
            BtnEliminarPermiso.Enabled = false;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string rolenum = GetUserRole((int)Session["role"]);
                //permisosUsuario = bllPerfil.ObtenerPermisosPorRol(rolenum);
                //ConfigurarForm(permisosUsuario);
                InicializarFormulario();
            }

        }
        public string GetUserRole(int rol)
        {
            switch (rol)
            {
                case 0:
                    return "0";
                case 1:
                    return "1";
                case 2:
                    return "2";
                case 3:
                    return "3";
                case 4:
                    return "4";
                default:
                    return "A";
            }
        }
        //private void ConfigurarForm(List<string> permisos)
        //{
        //    BtnAñadirPerfil.Visible = false;
        //    BtnEliminarPerfil.Visible = false;
        //    BtnModificarPerfil.Visible = false;
        //    BtnEliminarPermiso.Visible = false;
        //    BtnAñadirPermiso.Visible = false;
        //    BtnAplicar.Visible = false;
        //    BtnCancelar.Visible = false;

        //    foreach (string permiso in permisos)
        //    {
        //        switch (permiso)
        //        {
        //            case "Permisos Agregar":
        //                BtnAñadirPerfil.Visible = true;
        //                BtnAplicar.Visible = true;
        //                BtnCancelar.Visible = true;
        //                break;
        //            case "Permisos Eliminar":
        //                BtnEliminarPerfil.Visible = true;
        //                BtnAplicar.Visible = true;
        //                BtnCancelar.Visible = true;
        //                break;
        //            case "Permisos Modificar":
        //    BtnModificarPerfil.Visible = true;
        //    BtnEliminarPermiso.Visible = true;
        //    BtnAñadirPermiso.Visible = true;
        //    BtnAplicar.Visible = true;
        //    BtnCancelar.Visible = true;
        //                break;
        //            // Agregar más casos según los permisos definidos en tu sistema
        //            default:
        //                break;
        //        }
        //    }
        //}
        protected void BtnAñadirPerfil_Click(object sender, EventArgs e)
        {
            LblMensaje.Text = "Modo Añadir";
            HabilitarEdicion();
        }

        protected void BtnModificarPerfil_Click(object sender, EventArgs e)
        {
            LblMensaje.Text = "Modo Modificar";
            BtnCancelar.Enabled = false;
            BtnAplicar.Enabled = false;
            BtnAñadirPerfil.Enabled = false;
            BtnModificarPerfil.Enabled = false;
            BtnEliminarPerfil.Enabled = false;
            BtnAñadirPermiso.Enabled = true;
            BtnEliminarPermiso.Enabled = true;
        }

        protected void BtnEliminarPerfil_Click(object sender, EventArgs e)
        {
            LblMensaje.Text = "Modo Eliminar";
            HabilitarEdicion();
        }

        protected void BtnAñadirPermiso_Click(object sender, EventArgs e)
        {
            LblMensaje.Text = "Modo Añadir Permiso/s";
            HabilitarEdicion();
        }

        protected void BtnEliminarPermiso_Click(object sender, EventArgs e)
        {
            LblMensaje.Text = "Modo Eliminar Permiso/s";
            HabilitarEdicion();
        }

        protected void BtnAplicar_Click(object sender, EventArgs e)
        {

            if (LblMensaje.Text == "Modo Añadir")
            {
                try
                {
                    Role rol = new Role
                    {
                        Descripcion = txtNombrePerfil.Text
                    };

                    List<int> selectedPermissions = new List<int>();
                    foreach (ListItem item in LBPermisosDisponibles.Items)
                    {
                        if (item.Selected)
                        {
                            selectedPermissions.Add(int.Parse(item.Value));
                        }
                    }

                    int? parentRoleId = null;
                    if (DDLFamilia.SelectedIndex != -1 && DDLFamilia.SelectedItem.Text != "-- Seleccione un rol --")
                    {
                        parentRoleId = int.Parse(DDLFamilia.SelectedValue);
                    }

                    bllPerfil.CreateRole(rol, selectedPermissions, parentRoleId);

                    ScriptManager.RegisterStartupScript(this, GetType(), "alertSuccess", "alert('Perfil creado exitosamente.');", true);

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertError", $"alert('Error: {ex.Message}');", true);
                }
            }
            else if (LblMensaje.Text == "Modo Eliminar")
            {
                try
                {
                    if (DDLFamilia.SelectedIndex != -1)
                    {
                        int roleId = int.Parse(DDLFamilia.SelectedValue);
                        bllPerfil.DeleteRole(roleId);
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertSuccess", "alert('Perfil eliminado exitosamente.');", true);
                        LBPermisosFamilia.Items.Clear();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertNoSelection", "alert('Por favor, seleccione un perfil para eliminar.');", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertError", $"alert('Error: {ex.Message}');", true);
                }

            }
            else if (LblMensaje.Text == "Modo Añadir Permiso/s")
            {
                if (DDLFamilia.SelectedIndex != -1)
                {
                    int roleId = int.Parse(DDLFamilia.SelectedValue);
                    List<int> selectedPermissions = new List<int>();
                    foreach (ListItem item in LBPermisosDisponibles.Items)
                    {
                        if (item.Selected)
                        {
                            selectedPermissions.Add(int.Parse(item.Value));
                        }
                    }

                    bllPerfil.AddPermissionsToRole(roleId, selectedPermissions);
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertSuccess", "alert('Permisos añadidos exitosamente.');", true);

                    // Refrescar la lista de permisos del rol
                    LoadRolePermissions(roleId); 
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertNoSelection", "alert('Por favor, seleccione un rol para añadir permisos.');", true);
                }
            }
            else if (LblMensaje.Text == "Modo Eliminar Permiso/s")
            {
                if (DDLFamilia.SelectedValue != null && int.TryParse(DDLFamilia.SelectedValue.ToString(), out int roleId))
                {
                    List<int> permissionIds = new List<int>();
                    foreach (ListItem item in LBPermisosFamilia.Items)
                    {
                        if (item.Selected)
                        {
                            permissionIds.Add(int.Parse(item.Value));
                        }
                    }
                    bllPerfil.RemovePermissionsFromRole(roleId, permissionIds);
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertSuccess", "alert('Permisos eliminados exitosamente.');", true);

                    // Refrescar la lista de permisos del rol
                    LoadRolePermissions(roleId);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertNoSelection", "alert('Por favor, seleccione un rol para eliminar permisos.');", true);
                }
            }

            InicializarFormulario();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            LblMensaje.Text = "Operacion Cancelada";
            InicializarFormulario();
        }

        protected void DDLFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si el texto seleccionado es "-- Seleccione un rol --"
            if (DDLFamilia.SelectedItem.Text == "-- Seleccione un rol --")
            {
                // Limpiar la lista de permisos de la familia
                LBPermisosFamilia.Items.Clear();
                // Volver a cargar todos los permisos disponibles
                LoadPermissions(); // Se vuelve a cargar la lista de permisos disponibles
            }
            else if (DDLFamilia.SelectedValue != null && int.TryParse(DDLFamilia.SelectedValue.ToString(), out int selectedRoleId))
            {
                // Si se selecciona un rol válido, cargar los permisos de ese rol
                LoadRolePermissions(selectedRoleId);
            }
            else
            {
                // Si no hay un rol seleccionado, limpiar la lista de permisos de la familia
                LBPermisosFamilia.DataSource = null;
                LBPermisosFamilia.DataBind(); // Limpiar y volver a cargar los permisos de la familia
                LoadPermissions(); // Volver a cargar todos los permisos disponibles
            }
        }
        private void HabilitarEdicion()
        {
            BtnCancelar.Enabled = true;
            BtnAplicar.Enabled = true;
            BtnAñadirPerfil.Enabled = false;
            BtnModificarPerfil.Enabled = false;
            BtnEliminarPerfil.Enabled = false;
            BtnAñadirPermiso.Enabled = false;
            BtnEliminarPermiso.Enabled = false;
        }
        private void LoadRolePermissions(int roleId)
        {
            // Obtener los permisos del rol seleccionado
            List<Permission> rolePermissions = bllPerfil.GetPermissionsByRoleId(roleId);

            // Verificar si permissions está vacío o null
            if (permissions == null || permissions.Count == 0)
            {
                permissions = bllPerfil.GetPermissions(); // Obtener todos los permisos si es null o vacío
            }

            // Limpiar y cargar permisos en LBPermisosFamilia
            LBPermisosFamilia.DataSource = null; // Limpiar DataSource antes de reasignar
            LBPermisosFamilia.DataSource = rolePermissions;
            LBPermisosFamilia.DataTextField = "Descripcion"; // Campo de texto visible en ASP.NET
            LBPermisosFamilia.DataValueField = "ID"; // Campo de valor asociado en ASP.NET
            LBPermisosFamilia.DataBind(); // Llamar a DataBind para aplicar los datos al control

            // Crear una lista de permisos que no están en el rol seleccionado
            List<Permission> remainingPermissions = new List<Permission>();

            // Verificar que rolePermissions no sea null
            if (rolePermissions != null)
            {
                remainingPermissions = permissions
                    .Where(p => !rolePermissions.Any(rp => rp.ID == p.ID)) // Filtrar permisos no asignados al rol
                    .ToList();
            }

            // Asignar la nueva lista como DataSource para LBPermisosDisponibles
            LBPermisosDisponibles.DataSource = null;
            LBPermisosDisponibles.DataSource = remainingPermissions;
            LBPermisosDisponibles.DataTextField = "Descripcion";
            LBPermisosDisponibles.DataValueField = "ID";
            LBPermisosDisponibles.DataBind(); // Llamar a DataBind para aplicar los datos al control
        }

    }
}