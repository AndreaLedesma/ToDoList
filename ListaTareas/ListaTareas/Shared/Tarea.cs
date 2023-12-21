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

        public DateTime FechaVencimiento { get; set; }

        public bool Estado { get; set; }    

    }
}
