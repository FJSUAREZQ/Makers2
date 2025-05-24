using _1.DAL.DataContext;
using System.ComponentModel.DataAnnotations;

namespace Web_API.DTOs.PrestamosDTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Email { get; set; } = null!;

        public int RolId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        public virtual Role Rol { get; set; } = null!;

    }
}
