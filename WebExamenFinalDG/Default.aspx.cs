using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidadesDG;
using CapaNegocioDG;

namespace WebExamenFinalDG
{
    /// <summary>
    /// Pagina principal: registro de productos (Guardar) e inventario actual (Listar / Eliminar).
    /// </summary>
    public partial class Default : Page
    {
        /// <summary>Objeto de la capa de negocio.</summary>
        private readonly clsProductoNegocioDG mobjNegocioDG = new clsProductoNegocioDG();

        /// <summary>
        /// Carga el inventario la primera vez que se abre la pagina.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MensajeDG"] != null)
                {
                    ProMostrarMensajeDG((string)Session["MensajeDG"], true);
                    Session.Remove("MensajeDG");
                }
                ProCargarInventarioDG();
            }
        }

        /// <summary>
        /// Guarda el producto capturado y actualiza automaticamente el inventario.
        /// </summary>
        /// <param name="sender">Boton Guardar.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnGuardarDG_Click(object sender, EventArgs e)
        {
            Page.Validate("vgProductoDG");
            if (!Page.IsValid)
            {
                ProMostrarMensajeDG("Revise los datos marcados en rojo.", false);
                return;
            }

            try
            {
                decimal ldecPrecioDG;
                int lintStockDG;
                if (!decimal.TryParse(txtPrecioDG.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out ldecPrecioDG))
                {
                    ProMostrarMensajeDG("El precio no es un número válido.", false);
                    return;
                }
                if (!int.TryParse(txtStockDG.Text.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out lintStockDG))
                {
                    ProMostrarMensajeDG("El stock debe ser un número entero.", false);
                    return;
                }

                clsProductoDG lobjProductoDG = new clsProductoDG
                {
                    CodigoDG = txtCodigoDG.Text,
                    NombreDG = txtNombreDG.Text,
                    PrecioDG = ldecPrecioDG,
                    StockDG = lintStockDG
                };

                clsResultadoDG lobjResultadoDG = mobjNegocioDG.FncGuardarDG(lobjProductoDG);
                if (lobjResultadoDG.ExitoDG)
                {
                    // Patron Post/Redirect/Get: evita duplicar el registro al refrescar.
                    Session["MensajeDG"] = lobjResultadoDG.MensajeDG;
                    Response.Redirect("~/Default.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }
                ProMostrarMensajeDG(lobjResultadoDG.MensajeDG, false);
                ProCargarInventarioDG();
            }
            catch (Exception lexcErrorDG)
            {
                ProMostrarMensajeDG("Ocurrió un error inesperado al guardar: " + lexcErrorDG.Message, false);
            }
        }

        /// <summary>
        /// Atiende el boton Eliminar de cada fila (la confirmacion se pide en el navegador).
        /// </summary>
        /// <param name="sender">GridView del inventario.</param>
        /// <param name="e">Datos del comando.</param>
        protected void gvInventarioDG_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "EliminarDG")
            {
                return;
            }
            try
            {
                int lintIdDG;
                if (!int.TryParse(Convert.ToString(e.CommandArgument), out lintIdDG))
                {
                    ProMostrarMensajeDG("Producto no válido.", false);
                    return;
                }
                clsResultadoDG lobjResultadoDG = mobjNegocioDG.FncEliminarDG(lintIdDG);
                ProMostrarMensajeDG(lobjResultadoDG.MensajeDG, lobjResultadoDG.ExitoDG);
                ProCargarInventarioDG();
            }
            catch (Exception lexcErrorDG)
            {
                ProMostrarMensajeDG("Ocurrió un error inesperado al eliminar: " + lexcErrorDG.Message, false);
            }
        }

        /// <summary>
        /// Consulta la base de datos y llena la tabla del inventario.
        /// </summary>
        private void ProCargarInventarioDG()
        {
            try
            {
                gvInventarioDG.DataSource = mobjNegocioDG.FncListarDG();
                gvInventarioDG.DataBind();
                lblContadorDG.Text = gvInventarioDG.Rows.Count == 1 ? "1 producto" : gvInventarioDG.Rows.Count + " productos";
                if (gvInventarioDG.HeaderRow != null)
                {
                    gvInventarioDG.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception lexcErrorDG)
            {
                gvInventarioDG.DataSource = null;
                gvInventarioDG.DataBind();
                lblContadorDG.Text = "Sin conexión";
                ProMostrarMensajeDG("No se pudo conectar a la base de datos. Revise la cadena 'cnnExamenDG' en Web.config. Detalle: " + lexcErrorDG.Message, false);
            }
        }

        /// <summary>
        /// Muestra un mensaje tipo alerta de Bootstrap.
        /// </summary>
        /// <param name="pstrMensajeDG">Texto a mostrar.</param>
        /// <param name="pblnExitoDG">true = verde, false = rojo.</param>
        private void ProMostrarMensajeDG(string pstrMensajeDG, bool pblnExitoDG)
        {
            lblMensajeDG.Text = Server.HtmlEncode(pstrMensajeDG);
            pnlMensajeDG.CssClass = pblnExitoDG ? "alert alert-success" : "alert alert-danger";
            pnlMensajeDG.Visible = true;
        }
    }
}
