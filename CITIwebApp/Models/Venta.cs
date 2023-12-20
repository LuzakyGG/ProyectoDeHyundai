using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITIwebApp.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column (TypeName="date")]
        public DateTime Fecha { get; set; }

        [Required]
        public float Monto { get; set; }

        public int VehiculoId { get; set; }
        public virtual Vehiculo? Vehiculo { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
