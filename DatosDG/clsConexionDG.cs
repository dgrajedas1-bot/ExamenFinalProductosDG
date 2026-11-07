using System.Configuration;
using System.Data.SqlClient;

namespace DatosDG
{
    /// <summary>
    /// Clase encargada de construir la conexion hacia SQL Server
    /// usando la cadena "cnnExamenDG" del Web.config.
    /// </summary>
    public static class clsConexionDG
    {
        /// <summary>Nombre de la cadena de conexion en el archivo de configuracion.</summary>
        public const string cstrNombreCadenaDG = "cnnExamenDG";

        /// <summary>
        /// Crea una nueva conexion (sin abrir) hacia la base de datos.
        /// </summary>
        /// <returns>Objeto <see cref="SqlConnection"/> listo para abrirse.</returns>
        /// <exception cref="ConfigurationErrorsException">Si la cadena no existe en el Web.config.</exception>
        public static SqlConnection FncObtenerConexionDG()
        {
            ConnectionStringSettings lobjCadenaDG = ConfigurationManager.ConnectionStrings[cstrNombreCadenaDG];
            if (lobjCadenaDG == null || string.IsNullOrWhiteSpace(lobjCadenaDG.ConnectionString))
            {
                throw new ConfigurationErrorsException("No se encontró la cadena de conexión '" + cstrNombreCadenaDG + "' en el Web.config.");
            }
            return new SqlConnection(lobjCadenaDG.ConnectionString);
        }
    }
}
