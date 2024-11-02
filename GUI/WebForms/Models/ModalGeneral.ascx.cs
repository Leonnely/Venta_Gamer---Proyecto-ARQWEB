using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.WebForms.Models
{
    public partial class ModalGeneral : System.Web.UI.UserControl
    {
        public event EventHandler YesClicked;
        public event EventHandler NoClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            YesClicked?.Invoke(this, EventArgs.Empty); // Llama al evento de "Sí"
            miModal.Style["display"] = "none"; // Cierra el modal
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            NoClicked?.Invoke(this, EventArgs.Empty); // Llama al evento de "No"
            miModal.Style["display"] = "none"; // Cierra el modal
        }
    }
}

//< button type = "button" onclick = "abrirModal('Confirmación', '¿Está seguro que desea continuar?')" > Abrir Modal </ button >

//public partial class MiPagina : System.Web.UI.Page
//{
//    protected void Page_Load(object sender, EventArgs e)
//    {
//        // Suscribirse a los eventos del modal
//        ModalControl.YesClicked += ModalControl_YesClicked;
//        ModalControl.NoClicked += ModalControl_NoClicked;
//    }

//    protected void ModalControl_YesClicked(object sender, EventArgs e)
//    {
//        // Lógica para manejar el clic en "Sí"
//        lblMessage.Text = "El usuario seleccionó Sí.";
//        // Aquí puedes agregar más lógica según sea necesario
//    }

//    protected void ModalControl_NoClicked(object sender, EventArgs e)
//    {
//        // Lógica para manejar el clic en "No"
//        lblMessage.Text = "El usuario seleccionó No.";
//        // Aquí puedes agregar más lógica según sea necesario
//    }
//}