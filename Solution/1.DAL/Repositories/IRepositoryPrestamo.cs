using _1.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public interface IRepositoryPrestamo
    {
        Task<List<Prestamo>> GetPrestamosAllAsync();
        Task<Prestamo> GetPrestamoByIdAsync(int id);
        Task<List<Prestamo>> GetByUsuarioIdAsync(int userId);
        Task<int> CreateAsync(Prestamo prestamo);
        Task UpdateAsync(Prestamo prestamo);
    }
}
