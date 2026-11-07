using System;
using System.Web.UI;

namespace WebExamenFinalDG
{
    /// <summary>
    /// Pagina maestra con el menu: Examen Final, Inicio, Acerca de y Contacto.
    /// </summary>
    public partial class SiteMaster : MasterPage
    {
        /// <summary>
        /// Protege los formularios contra CSRF ligando el ViewState a la sesion del usuario.
        /// </summary>
        /// <param name="e">Argumentos del evento.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            // Se guarda un valor para que el SessionID sea estable entre peticiones.
            if (Session["SesionDG"] == null)
            {
                Session["SesionDG"] = DateTime.Now;
            }
            Page.ViewStateUserKey = Session.SessionID;
        }
    }
}
