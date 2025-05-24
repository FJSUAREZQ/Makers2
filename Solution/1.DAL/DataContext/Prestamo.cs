using System;
using System.Collections.Generic;

namespace _1.DAL.DataContext;

public partial class Prestamo
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public decimal Monto { get; set; }

    public int PlazoEnMeses { get; set; }

    public int EstadoPrestamoId { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public string? MotivoRechazo { get; set; }

    public virtual EstadosPrestamo EstadoPrestamo { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
