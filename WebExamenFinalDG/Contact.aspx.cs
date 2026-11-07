using System;
using System.Web.UI;

namespace WebExamenFinalDG
{
    /// <summary>
    /// Pagina de Contacto: muestra carne, nombre y apellido, seccion y curso del alumno
    /// leidos desde el Web.config.
    /// </summary>
    public partial class Contact : Page
    {
        /// <summary>
        /// Llena las etiquetas con los datos del alumno.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNombreDG.Text = Server.HtmlEncode(clsConfiguracionAlumnoDG.NombreDG);
            lblCarneDG.Text = Server.HtmlEncode(clsConfiguracionAlumnoDG.CarneDG);
            lblSeccionDG.Text = Server.HtmlEncode(clsConfiguracionAlumnoDG.SeccionDG);
            lblCursoDG.Text = Server.HtmlEncode(clsConfiguracionAlumnoDG.CursoDG);

            string lstrCorreoDG = clsConfiguracionAlumnoDG.CorreoDG;
            if (lstrCorreoDG.Length > 0)
            {
                hlCorreoDG.Text = Server.HtmlEncode(lstrCorreoDG);
                hlCorreoDG.NavigateUrl = "mailto:" + lstrCorreoDG;
                phCorreoDG.Visible = true;
            }
        }
    }
}
