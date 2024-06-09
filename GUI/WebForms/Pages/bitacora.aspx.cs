using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.WebForms.Pages
{
    public partial class bitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatosBitacora();
        }


        private void CargarDatosBitacora()
        {
            BLL_Bitacora bllBitacora = new BLL_Bitacora();
            var datos = bllBitacora.getAll();
            

            // Crear la fila de cabecera
            TableHeaderRow encabezado = new TableHeaderRow();
            encabezado.Cells.Add(new TableHeaderCell { Text = "Evento" });
            encabezado.Cells.Add(new TableHeaderCell { Text = "Fecha" });
            encabezado.Cells.Add(new TableHeaderCell { Text = "Usuario" });
            encabezado.Cells.Add(new TableHeaderCell { Text = "Modulo" });
            tbBitacora.Rows.Add(encabezado);

            // Crear las filas de datos
            foreach (var registro in datos)
            {
                TableRow fila = new TableRow();
                fila.Cells.Add(new TableCell { Text = registro.Mensaje });
                fila.Cells.Add(new TableCell { Text = registro.Fecha.ToString() });
                fila.Cells.Add(new TableCell { Text = registro.Autor });
                fila.Cells.Add(new TableCell { Text = registro.Modulo });
                tbBitacora.Rows.Add(fila);
            }
        }
    }
}