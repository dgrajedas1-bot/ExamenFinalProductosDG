using System.Configuration;

namespace WebExamenFinalDG
{
    /// <summary>
    /// Lee de forma centralizada los datos del alumno guardados en el Web.config (appSettings).
    /// </summary>
    public static class clsConfiguracionAlumnoDG
    {
        /// <summary>Nombre completo del alumno.</summary>
        public static string NombreDG { get { return FncLeerDG("AlumnoNombreDG"); } }

        /// <summary>Carne del alumno.</summary>
        public static string CarneDG { get { return FncLeerDG("AlumnoCarneDG"); } }

        /// <summary>Seccion del curso.</summary>
        public static string SeccionDG { get { return FncLeerDG("AlumnoSeccionDG"); } }

        /// <summary>Nombre del curso.</summary>
        public static string CursoDG { get { return FncLeerDG("AlumnoCursoDG"); } }

        /// <summary>Correo de soporte (opcional, vacio = no se muestra).</summary>
        public static string CorreoDG { get { return FncLeerDG("AlumnoCorreoDG"); } }

        /// <summary>
        /// Lee una llave de appSettings y devuelve cadena vacia si no existe.
        /// </summary>
        /// <param name="pstrLlaveDG">Nombre de la llave.</param>
        /// <returns>Valor configurado.</returns>
        private static string FncLeerDG(string pstrLlaveDG)
        {
            return (ConfigurationManager.AppSettings[pstrLlaveDG] ?? string.Empty).Trim();
        }
    }
}
