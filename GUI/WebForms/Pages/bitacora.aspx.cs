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
            if (this.Master is MasterPage masterPage)
            {
                masterPage.ConfigurarNavbarEIdioma();
            }

            if (Session["role"] != null)
            {
                if ((int)Session["role"] != 1)
                {
                    Response.Redirect("~/WebForms/Pages/ErrorPage.aspx");
                }
                else
                {
                    if (!IsPostBack)
                    {
                        CargarDatosBitacora();
                    }
                }
            }
            else
            {
                Response.Redirect("~/WebForms/Pages/ErrorPage.aspx");
            }
        }

        //FILTRADO DE REGISTROS
        protected void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            string autor = txtAutor.Value;
            DateTime? fechaDesde = string.IsNullOrEmpty(dtFechaDesde.Value) ? (DateTime?)null : DateTime.Parse(dtFechaDesde.Value);
            DateTime? fechaHasta = string.IsNullOrEmpty(dtFechaHasta.Value) ? (DateTime?)null : DateTime.Parse(dtFechaHasta.Value);

            CargarDatosBitacora(autor, fechaDesde, fechaHasta);
        }

        //LECTURA DE BITACORA
        private void CargarDatosBitacora(string autor = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            BLL_Bitacora bllBitacora = new BLL_Bitacora();
            var datos = bllBitacora.getAll();

            if (!string.IsNullOrEmpty(autor))
            {
                datos = datos.Where(d => d.user.IndexOf(autor, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            if (fechaDesde.HasValue)
            {
                datos = datos.Where(d => d.Fecha >= fechaDesde.Value).ToList();
            }

            if (fechaHasta.HasValue)
            {
                datos = datos.Where(d => d.Fecha <= fechaHasta.Value).ToList();
            }

            tbBitacora.Rows.Clear();

            TableHeaderRow encabezado = new TableHeaderRow();
            encabezado.Cells.Add(new TableHeaderCell { Text = "Evento" });
            encabezado.Cells.Add(new TableHeaderCell { Text = "Fecha" });
            encabezado.Cells.Add(new TableHeaderCell { Text = "Usuario" });
            encabezado.Cells.Add(new TableHeaderCell { Text = "Modulo" });
            tbBitacora.Rows.Add(encabezado);

            foreach (var registro in datos)
            {
                TableRow fila = new TableRow();
                fila.Cells.Add(new TableCell { Text = registro.Mensaje });
                fila.Cells.Add(new TableCell { Text = registro.Fecha.ToString() });
                fila.Cells.Add(new TableCell { Text = registro.user.ToString() });
                fila.Cells.Add(new TableCell { Text = registro.Modulo });
                tbBitacora.Rows.Add(fila);
            }
        }
    }
}