using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTareas.Shared
{
    public class Tarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TareaID { get; set; }

        public string? Titulo { get; set; }
        
        [Required(ErrorMessage = "Añade una descripción")]
        public string Descripcion { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Vencimiento")]
        public DateTime FechaVencimiento { get; set; }

        public bool Estado { get; set; }    


        //intento por validar que la fecha de vencimiento No sea menos a la actual
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (FechaVencimiento.Date < DateTime.Today)
        {
            yield return new ValidationResult("La Fecha de Vencimiento no puede ser menor a la fecha actual.", new[] { nameof(FechaVencimiento) });
        }
    }

    }
}
