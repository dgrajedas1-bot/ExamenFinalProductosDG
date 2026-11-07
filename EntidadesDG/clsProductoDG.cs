using System;
using System.ComponentModel.DataAnnotations;

namespace EntidadesDG
{
    /// <summary>
    /// Entidad que representa un producto del inventario.
    /// Autora: Daniela Paola Grajeda Sandoval (sufijo DG).
    /// </summary>
    public class clsProductoDG
    {
        /// <summary>Identificador interno autonumerico del producto.</summary>
        public int IdProductoDG { get; set; }

        /// <summary>Codigo unico del producto, por ejemplo PRD-001.</summary>
        [Display(Name = "Código de Producto")]
        [Required(ErrorMessage = "El código es obligatorio.")]
        [StringLength(20, ErrorMessage = "El código admite máximo 20 caracteres.")]
        [RegularExpression(@"^[A-Za-z0-9\-]+$", ErrorMessage = "Use solo letras, números y guiones (ej. PRD-001).")]
        public string CodigoDG { get; set; }

        /// <summary>Nombre descriptivo del producto.</summary>
        [Display(Name = "Nombre del Producto")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre admite máximo 100 caracteres.")]
        public string NombreDG { get; set; }

        /// <summary>Precio unitario en dolares, con 2 decimales.</summary>
        [Display(Name = "Precio ($)")]
        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(typeof(decimal), "0.01", "99999999.99", ErrorMessage = "El precio debe estar entre 0.01 y 99,999,999.99.")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal? PrecioDG { get; set; }

        /// <summary>Cantidad disponible en inventario.</summary>
        [Display(Name = "Stock")]
        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, 1000000, ErrorMessage = "El stock debe estar entre 0 y 1,000,000.")]
        public int? StockDG { get; set; }

        /// <summary>Fecha y hora en que se registro el producto.</summary>
        public DateTime FechaRegistroDG { get; set; }
    }
}
