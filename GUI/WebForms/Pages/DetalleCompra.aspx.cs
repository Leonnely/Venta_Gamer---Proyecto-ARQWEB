using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using BE;

namespace GUI.WebForms.Pages
{
    public partial class DetalleCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Master is MasterPage masterPage)
            {
                masterPage.ConfigurarNavbarEIdioma();
            }

            if (!IsPostBack)
            {
                if (Session["DetallesCompra"] == null)
                {
                    Response.Write("<script>alert('No hay detalles de compra disponibles.');</script>");
                    return;
                }

                // Cargar el detalle de la compra
                decimal totalCompra = 0;
                var detallesCompra = (List<BE_DetalleCompra>)Session["DetallesCompra"];
                foreach (var item in detallesCompra)
                {
                    // Generar contenido para cada item en listaCompras
                    listaCompras.InnerHtml += $"<div class='item'><strong>Producto:</strong> {item.Producto} - <strong>Cantidad:</strong> {item.Cantidad} - <strong>Precio:</strong> ${item.Precio} - <strong>Total:</strong> ${item.Total}</div>";
                    totalCompra += item.Total;
                }

                // Mostrar el total en totalCompraDiv
                totalCompraDiv.InnerHtml = $"Total de la Compra: ${totalCompra}";
            }
        }

        protected void btnDownloadPDF_Click(object sender, EventArgs e)
        {
            if (Session["DetallesCompra"] == null)
            {
                // Mostrar un mensaje o redirigir si no hay detalles de compra
                Response.Write("<script>alert('No hay detalles de compra disponibles.');</script>");
                return;
            }

            string fileName = Server.MapPath("~/App_Data/DetalleCompra.pdf");

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                // Agregar contenido al PDF
                document.Add(new Paragraph("Resumen de Compra"));
                document.Add(new Paragraph("Fecha: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                // Recuperar y escribir detalles de la compra
                decimal totalCompra = 0;
                foreach (BE_DetalleCompra item in (List<BE_DetalleCompra>)Session["DetallesCompra"])
                {
                    document.Add(new Paragraph($"{item.Producto} - Cantidad: {item.Cantidad}, Precio: ${item.Precio}, Total: ${item.Total}"));
                    totalCompra += item.Total;
                }

                document.Add(new Paragraph("Total de la Compra: $" + totalCompra));
                document.Close();
            }

            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=DetalleCompra.pdf");
            Response.TransmitFile(fileName);
            Response.End();
        }
    }
}