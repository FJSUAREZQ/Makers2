using _1.DAL.DataContext;
using System.ComponentModel.DataAnnotations;

namespace Web_API.DTOs.PrestamosDTO
{
    public class PrestamoDTO
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int PlazoEnMeses { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int EstadoPrestamoId { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public string? MotivoRechazo { get; set; }

        public virtual EstadosPrestamo EstadoPrestamo { get; set; } = null!;

        public virtual Usuario Usuario { get; set; } = null!;

    }
}
