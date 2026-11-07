using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CapaDatosDG;
using CapaEntidadesDG;

namespace CapaNegocioDG
{
    /// <summary>
    /// Reglas de negocio para los productos: valida, normaliza y
    /// traduce errores tecnicos a mensajes amigables.
    /// </summary>
    public class clsProductoNegocioDG
    {
        /// <summary>Objeto de la capa de datos.</summary>
        private readonly clsProductoDatosDG mobjDatosDG = new clsProductoDatosDG();

        /// <summary>
        /// Devuelve el inventario actual.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        public List<clsProductoDG> FncListarDG()
        {
            return mobjDatosDG.FncListarDG();
        }

        /// <summary>
        /// Valida y guarda un producto nuevo.
        /// </summary>
        /// <param name="pobjProductoDG">Producto capturado en el formulario.</param>
        /// <returns>Resultado con mensaje amigable.</returns>
        public clsResultadoDG FncGuardarDG(clsProductoDG pobjProductoDG)
        {
            if (pobjProductoDG == null)
            {
                return clsResultadoDG.FncErrorDG("No se recibieron datos del producto.");
            }

            pobjProductoDG.CodigoDG = (pobjProductoDG.CodigoDG ?? string.Empty).Trim().ToUpperInvariant();
            pobjProductoDG.NombreDG = (pobjProductoDG.NombreDG ?? string.Empty).Trim();

            if (pobjProductoDG.CodigoDG.Length == 0 || pobjProductoDG.NombreDG.Length == 0)
            {
                return clsResultadoDG.FncErrorDG("El código y el nombre son obligatorios.");
            }
            if (!pobjProductoDG.PrecioDG.HasValue || pobjProductoDG.PrecioDG.Value <= 0)
            {
                return clsResultadoDG.FncErrorDG("El precio debe ser mayor que 0.");
            }
            if (!pobjProductoDG.StockDG.HasValue || pobjProductoDG.StockDG.Value < 0)
            {
                return clsResultadoDG.FncErrorDG("El stock no puede ser negativo.");
            }

            // Siempre 2 decimales.
            pobjProductoDG.PrecioDG = Math.Round(pobjProductoDG.PrecioDG.Value, 2, MidpointRounding.AwayFromZero);

            try
            {
                if (mobjDatosDG.FncExisteCodigoDG(pobjProductoDG.CodigoDG))
                {
                    return clsResultadoDG.FncErrorDG("Ya existe un producto con el código " + pobjProductoDG.CodigoDG + ".");
                }
                mobjDatosDG.FncInsertarDG(pobjProductoDG);
                return clsResultadoDG.FncExitoDG("Producto " + pobjProductoDG.CodigoDG + " guardado correctamente.");
            }
            catch (SqlException lexcSqlDG)
            {
                if (lexcSqlDG.Number == 2627 || lexcSqlDG.Number == 2601)
                {
                    return clsResultadoDG.FncErrorDG("Ya existe un producto con el código " + pobjProductoDG.CodigoDG + ".");
                }
                return clsResultadoDG.FncErrorDG("No se pudo guardar en la base de datos. Verifique la conexión. Detalle: " + lexcSqlDG.Message);
            }
        }

        /// <summary>
        /// Elimina un producto del inventario.
        /// </summary>
        /// <param name="pintIdProductoDG">Id del producto.</param>
        /// <returns>Resultado con mensaje amigable.</returns>
        public clsResultadoDG FncEliminarDG(int pintIdProductoDG)
        {
            if (pintIdProductoDG <= 0)
            {
                return clsResultadoDG.FncErrorDG("Producto no válido.");
            }
            try
            {
                return mobjDatosDG.FncEliminarDG(pintIdProductoDG)
                    ? clsResultadoDG.FncExitoDG("Producto eliminado correctamente.")
                    : clsResultadoDG.FncErrorDG("El producto ya no existe.");
            }
            catch (SqlException lexcSqlDG)
            {
                return clsResultadoDG.FncErrorDG("No se pudo eliminar en la base de datos. Detalle: " + lexcSqlDG.Message);
            }
        }
    }
}
