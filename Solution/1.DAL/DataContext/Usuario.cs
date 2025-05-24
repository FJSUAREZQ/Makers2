using System;
using System.Collections.Generic;

namespace _1.DAL.DataContext;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RolId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    public virtual Role Rol { get; set; } = null!;
}
