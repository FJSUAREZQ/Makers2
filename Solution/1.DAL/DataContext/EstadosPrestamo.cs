using System;
using System.Collections.Generic;

namespace _1.DAL.DataContext;

public partial class EstadosPrestamo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
