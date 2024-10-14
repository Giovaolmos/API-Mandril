using System.ComponentModel.DataAnnotations;
using static MandrilAPI.Models.Habilidad;

namespace MandrilAPI.Models;

public class HabilidadInsert
{
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
    
         [Required]
        public EPotencia Potencia { get; set; }
}