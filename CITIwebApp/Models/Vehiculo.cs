using CITIwebApp.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITIwebApp.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Modelo { get; set; }
        [Required]
        public string? Matricula { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal Precio { get; set; }
        public string? Foto { get; set; }

        [Required]
        public EspecialidadEnum Especialidad { get; set; }

        [NotMapped]
        [Display(Name ="Cargar Foto")]
        public IFormFile? FotoFile { get; set; }
    }
}
