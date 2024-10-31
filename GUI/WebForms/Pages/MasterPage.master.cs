using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using GUI.WebForms.Models;
using SECURITY;
using SERVICES;

namespace GUI.WebForms.Pages
{
    public partial class MasterPage : System.Web.UI.MasterPage, IIdiomaObserver
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var idiomaSubject = SERVICES.IdiomaSubject.Instance;

                // Usamos una bandera para evitar múltiples observadores de idimoa
                if (Session["IsObservadorRegistrado"] == null || !(bool)Session["IsObservadorRegistrado"])
                {
                    idiomaSubject.Attach(this);  // Registrar MasterPage como observador
                    Session["IsObservadorRegistrado"] = true;  // Establecer la bandera
                }

                FillLanguageDropDown(ddlLanguages);  // Cargar el dropdown de idioma
            }

            // Mostrar o no el botón de logout basado en la sesión
            btnLogout.Visible = Session["user"] != null;
        }

        // Implementación del método de la interfaz IIdiomaObserver
        public void UpdateIdioma(Dictionary<string, string> textosActuales)
        {
            foreach (Control control in navbar.Controls)
            {
                if (control is HtmlAnchor link)
                {
                    string key = link.InnerText; // Recuperamos la clave de traducción
                    if (textosActuales.ContainsKey(key))
                    {
                        link.InnerText = textosActuales[key]; // Actualizar el texto del enlace
                    }
                }
            }
        }

        // Método para llenar el dropdown de idiomas
        private void FillLanguageDropDown(System.Web.UI.WebControls.DropDownList dropDown)
        {
            var bllGestionIdioma = new BLL_GestionIdioma();
            var idiomas = bllGestionIdioma.ObtenerIdiomas();
            dropDown.Items.Clear();  // Limpiamos antes de agregar

            foreach (var idioma in idiomas)
            {
                dropDown.Items.Add(new ListItem(idioma.Nombre, idioma.Codigo));
            }

            if (Session["language"] != null)
            {
                dropDown.SelectedValue = Session["language"].ToString();
            }
            else
            {
                dropDown.SelectedValue = "ES"; // Idioma por defecto
            }
        }

        // Método para configurar el navbar y cargar el idioma
        public void ConfigurarNavbarEIdioma()
        {
            try
            {
                string idiomaCodigo = Session["language"] != null
                    ? Session["language"].ToString()
                    : "ES";

                // Usar la instancia Singleton de IdiomaSubject
                var idiomaSubject = SERVICES.IdiomaSubject.Instance;
                idiomaSubject.CambiarIdiomaDesdeDB(idiomaCodigo);

                if (Session["role"] == null) //Si no hay sesión agregamos botón de inicio e iniciar sesion
                {
                    var navbarItems = new List<NavbarItem>
            {
                new NavbarItem { Name = SERVICES.IdiomaSubject.GetTexto("Home"), TextKey = "Home", Url = "~/WebForms/Pages/home.aspx" },
                new NavbarItem { Name = SERVICES.IdiomaSubject.GetTexto("Iniciar sesión"), TextKey = "Iniciar sesión", Url = "~/WebForms/Session/login.aspx" }
            };
                    GenerateNavbar(navbarItems);
                }
                else
                {
                    string role = GetUserRole((int)Session["role"]);
                    var navbarItems = RoleBasedNavbar.RoleNavItems.ContainsKey(role)
                        ? RoleBasedNavbar.RoleNavItems[role]
                        : RoleBasedNavbar.RoleNavItems["User"];

                    foreach (var item in navbarItems)
                    {
                        // Si TextKey es nulo,  lanza una excepción.
                        if (string.IsNullOrEmpty(item.TextKey))
                        {
                            throw new ArgumentNullException("TextKey", "El valor de TextKey no puede ser nulo.");
                        }

                        item.Name = SERVICES.IdiomaSubject.GetTexto(item.TextKey);  // Utiliza siempre TextKey para traducir
                    }

                    GenerateNavbar(navbarItems);
                }

                btnLogout.Text = SERVICES.IdiomaSubject.GetTexto("CerrarSesion");
            }
            catch (ArgumentNullException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                Response.Redirect("~/WebForms/Pages/ErrorPage.aspx", false);
            }
        }


        // Método para generar el navbar
        private void GenerateNavbar(List<NavbarItem> navbarItems)
        {
            navbarLeft.Controls.Clear();

            foreach (var item in navbarItems)
            {
                var link = new HtmlAnchor
                {
                    InnerText = SERVICES.IdiomaSubject.GetTexto(item.Name),
                    HRef = ResolveUrl(item.Url)
                };
                link.Attributes["class"] = "nav-link";
                navbarLeft.Controls.Add(link);
            }
        }

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dropDown = (DropDownList)sender;
            string nuevoIdioma = dropDown.SelectedValue;

            // Actualizar la sesión con el nuevo idioma
            Session["language"] = nuevoIdioma;

            // Usar la instancia Singleton de IdiomaSubject
            var idiomaSubject = SERVICES.IdiomaSubject.Instance;
            idiomaSubject.CambiarIdiomaDesdeDB(nuevoIdioma);

            if (Session["user"] != null)
            {
                int userId = (int)Session["id"];
                var loginManager = new LoginManager();
                loginManager.updateLanguaje(userId, idiomaSubject.ObtenerIdDesdeIdioma(nuevoIdioma));
            }

            Response.Redirect(Request.RawUrl, false);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/WebForms/Session/login.aspx");
        }

        public string GetUserRole(int rol)
        {
            switch (rol)
            {
                case 0:
                    return "Admin";
                case 1:
                    return "WebMaster";
                case 2:
                    return "User";
                default:
                    return "A";
            }
        }
    }
}
