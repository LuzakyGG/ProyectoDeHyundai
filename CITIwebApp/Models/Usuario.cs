using CITIwebApp.Dtos;
using System.ComponentModel.DataAnnotations;

namespace CITIwebApp.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        [Required]
        public RolEmun Rol { get; set; }
    }
}
