namespace NegocioDG
{
    /// <summary>
    /// Resultado de una operacion de negocio con mensaje amigable para el usuario.
    /// </summary>
    public class clsResultadoDG
    {
        /// <summary>Indica si la operacion fue exitosa.</summary>
        public bool ExitoDG { get; set; }

        /// <summary>Mensaje para mostrar al usuario.</summary>
        public string MensajeDG { get; set; }

        /// <summary>Crea un resultado exitoso.</summary>
        /// <param name="pstrMensajeDG">Mensaje a mostrar.</param>
        /// <returns>Resultado con ExitoDG = true.</returns>
        public static clsResultadoDG FncExitoDG(string pstrMensajeDG)
        {
            return new clsResultadoDG { ExitoDG = true, MensajeDG = pstrMensajeDG };
        }

        /// <summary>Crea un resultado con error.</summary>
        /// <param name="pstrMensajeDG">Mensaje a mostrar.</param>
        /// <returns>Resultado con ExitoDG = false.</returns>
        public static clsResultadoDG FncErrorDG(string pstrMensajeDG)
        {
            return new clsResultadoDG { ExitoDG = false, MensajeDG = pstrMensajeDG };
        }
    }
}
