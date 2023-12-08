using CITIwebApp.Dtos;
using System.ComponentModel.DataAnnotations;

namespace CITIwebApp.Models
{
    public class Ingeniero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Rni { get; set; }
        [Required]
        public string? Ci { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        public DateTime FechaRegistro { get; set; }
        [Required]
        public EspecialidadEnum Especialidad { get; set; }
    }
}
