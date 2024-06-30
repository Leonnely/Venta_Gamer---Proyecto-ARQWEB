using SECURITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease;
using System.Web.Security;

namespace GUI.WebForms.Session
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //dv();

        }



        void dv()
        {
            //DVManager managerSecurity = new DVManager();
            DVManager.guardarTable(DVManager.HashTable("USUARIOS"), "DV_USUARIOS"); 
            DVManager.guardarTable(DVManager.HashTable("BITACORA_REGISTROS"), "DV_BITACORA");
        }

        int counter;
        
        //INICIO DE SESION
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (Request.Cookies["sesion"] != null)
            {
                // Verificar si el valor "intentos" dentro de la cookie "sesion" existe y no está vacío
                string intentosValue = Request.Cookies["sesion"]["intentos"];
                if (!string.IsNullOrEmpty(intentosValue))
                {
                    // Intentar convertir el valor a entero de manera segura
                    if (int.TryParse(intentosValue, out int intentos))
                    {
                        counter = intentos;
                    }
                }
            }
            else
            {
                counter = 0;
                Response.Cookies["sesion"]["intentos"] = counter.ToString();
            }

             if (Page.IsValid)
             {
                  string username = txtUsername.Text;
                  string password = txtPassword.Text;

                  LoginManager loginManager = new LoginManager();

                  if (loginManager.login(username, password))     //SI NO EXISTE SESION
                  {
                      //DVManager managerSecurity = new DVManager();
                      bool IntegridadBBDD = true;
                      Dictionary<string, bool> tablas = DVManager.HashAndCompare();

                      foreach (var item in tablas)
                      {
                          if (item.Value != true)
                          {
                              IntegridadBBDD = false;
                              break;
                          }
                      }

                      if (!IntegridadBBDD)
                      {
                          string script = "alert('Error');";
                          ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                      }
                      else
                      {
                          if (!loginManager.block)
                          {
                              Session["role"] = loginManager.role;
                              Session["user"] = txtUsername.Text;
                            Response.Redirect("~/WebForms/Pages/home.aspx");
                            //FormsAuthentication.RedirectFromLoginPage(Session["user"].ToString(), true);
                        }
                          else
                          {
                              lblMessage.Text=("Usuario bloqueado, contacte con un administrador");
                          }
                      }
                  }
                  else     //SI EXISTE SESION O CONTRASEÑA INCORRECTA
                  {
                      lblMessage.Text = "Error al iniciar sesion";
                      Response.Cookies["sesion"]["intentos"] = (counter + 1).ToString();
                      if (counter >= 3)
                      {
                          loginManager.blockUser(username);
                          lblMessage.Text = "Demasiados intentos de inicio de sesion fallidos, intentelo mas tarde o contacte con un administrador";
                      }
                  }
             }
        }





        protected void HyperLink1_DataBinding(object sender, EventArgs e)
        {

        }
    }
}