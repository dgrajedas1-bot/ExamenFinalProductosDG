using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EntidadesDG;

namespace DatosDG
{
    /// <summary>
    /// Capa de acceso a datos para la tabla dbo.tblProductoDG.
    /// Todas las consultas son parametrizadas para evitar inyeccion SQL.
    /// </summary>
    public class clsProductoDatosDG
    {
        /// <summary>
        /// Obtiene todos los productos ordenados por codigo.
        /// </summary>
        /// <returns>Lista de productos registrados.</returns>
        public List<clsProductoDG> FncListarDG()
        {
            List<clsProductoDG> llstProductosDG = new List<clsProductoDG>();
            const string lstrSqlDG = "SELECT IdProductoDG, CodigoDG, NombreDG, PrecioDG, StockDG, FechaRegistroDG FROM dbo.tblProductoDG ORDER BY CodigoDG;";

            using (SqlConnection lcnnConexionDG = clsConexionDG.FncObtenerConexionDG())
            using (SqlCommand lcmdComandoDG = new SqlCommand(lstrSqlDG, lcnnConexionDG))
            {
                lcnnConexionDG.Open();
                using (SqlDataReader ldrLectorDG = lcmdComandoDG.ExecuteReader())
                {
                    while (ldrLectorDG.Read())
                    {
                        llstProductosDG.Add(new clsProductoDG
                        {
                            IdProductoDG = ldrLectorDG.GetInt32(0),
                            CodigoDG = ldrLectorDG.GetString(1),
                            NombreDG = ldrLectorDG.GetString(2),
                            PrecioDG = ldrLectorDG.GetDecimal(3),
                            StockDG = ldrLectorDG.GetInt32(4),
                            FechaRegistroDG = ldrLectorDG.GetDateTime(5)
                        });
                    }
                }
            }
            return llstProductosDG;
        }

        /// <summary>
        /// Indica si ya existe un producto con el codigo indicado.
        /// </summary>
        /// <param name="pstrCodigoDG">Codigo a buscar.</param>
        /// <returns>true si el codigo ya esta registrado.</returns>
        public bool FncExisteCodigoDG(string pstrCodigoDG)
        {
            const string lstrSqlDG = "SELECT COUNT(1) FROM dbo.tblProductoDG WHERE CodigoDG = @CodigoDG;";
            using (SqlConnection lcnnConexionDG = clsConexionDG.FncObtenerConexionDG())
            using (SqlCommand lcmdComandoDG = new SqlCommand(lstrSqlDG, lcnnConexionDG))
            {
                lcmdComandoDG.Parameters.Add("@CodigoDG", SqlDbType.NVarChar, 20).Value = pstrCodigoDG;
                lcnnConexionDG.Open();
                return Convert.ToInt32(lcmdComandoDG.ExecuteScalar()) > 0;
            }
        }

        /// <summary>
        /// Inserta un producto nuevo en la base de datos.
        /// </summary>
        /// <param name="pobjProductoDG">Producto a insertar (ya validado).</param>
        /// <returns>Id generado por la base de datos.</returns>
        public int FncInsertarDG(clsProductoDG pobjProductoDG)
        {
            const string lstrSqlDG = "INSERT INTO dbo.tblProductoDG (CodigoDG, NombreDG, PrecioDG, StockDG) VALUES (@CodigoDG, @NombreDG, @PrecioDG, @StockDG); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            using (SqlConnection lcnnConexionDG = clsConexionDG.FncObtenerConexionDG())
            using (SqlCommand lcmdComandoDG = new SqlCommand(lstrSqlDG, lcnnConexionDG))
            {
                lcmdComandoDG.Parameters.Add("@CodigoDG", SqlDbType.NVarChar, 20).Value = pobjProductoDG.CodigoDG;
                lcmdComandoDG.Parameters.Add("@NombreDG", SqlDbType.NVarChar, 100).Value = pobjProductoDG.NombreDG;
                SqlParameter lprmPrecioDG = lcmdComandoDG.Parameters.Add("@PrecioDG", SqlDbType.Decimal);
                lprmPrecioDG.Precision = 10;
                lprmPrecioDG.Scale = 2;
                lprmPrecioDG.Value = pobjProductoDG.PrecioDG.Value;
                lcmdComandoDG.Parameters.Add("@StockDG", SqlDbType.Int).Value = pobjProductoDG.StockDG.Value;
                lcnnConexionDG.Open();
                return Convert.ToInt32(lcmdComandoDG.ExecuteScalar());
            }
        }

        /// <summary>
        /// Elimina un producto por su identificador.
        /// </summary>
        /// <param name="pintIdProductoDG">Id del producto a eliminar.</param>
        /// <returns>true si se elimino un registro.</returns>
        public bool FncEliminarDG(int pintIdProductoDG)
        {
            const string lstrSqlDG = "DELETE FROM dbo.tblProductoDG WHERE IdProductoDG = @IdProductoDG;";
            using (SqlConnection lcnnConexionDG = clsConexionDG.FncObtenerConexionDG())
            using (SqlCommand lcmdComandoDG = new SqlCommand(lstrSqlDG, lcnnConexionDG))
            {
                lcmdComandoDG.Parameters.Add("@IdProductoDG", SqlDbType.Int).Value = pintIdProductoDG;
                lcnnConexionDG.Open();
                return lcmdComandoDG.ExecuteNonQuery() > 0;
            }
        }
    }
}
