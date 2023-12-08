using CITIwebApp.Dtos;
using System.ComponentModel.DataAnnotations;

namespace CITIwebApp.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CI { get; set; }
        [Required]
        public int Celular { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        
    }
}
