using _1.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public class RepositoryPrestamo: IRepositoryPrestamo
    {
        private readonly MakersDbContext _dbContext;

        public RepositoryPrestamo(MakersDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<List<Prestamo>> GetPrestamosAllAsync()
        {
            List<Prestamo> list_c = await _dbContext.Prestamos.ToListAsync();
            return list_c;

        }

        /// <summary>
        /// Metodo que permite crear un prestamo
        /// </summary>
        /// <param name="prestamo"></param>
        /// <returns>Id del prestamos creado</returns>
        public async Task<int> CreateAsync(Prestamo prestamo)
        {
            await _dbContext.Prestamos.AddAsync(prestamo);
            return await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// Permite consultar un prestamo mediante el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Prestamo> GetPrestamoByIdAsync(int id)
        {
            return await _dbContext.Prestamos.SingleOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Permite consultar todos los prestamos de un usuario mediante el id del usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Prestamo>> GetByUsuarioIdAsync(int userId)
        {
            return await _dbContext.Prestamos.Where(p => p.UsuarioId == userId).ToListAsync();

        }

        /// <summary>
        /// Metodo que permite actualizar un prestamo
        /// </summary>
        /// <param name="prestamo"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Prestamo prestamo)
        {
            _dbContext.Prestamos.Update(prestamo);
            await _dbContext.SaveChangesAsync();

        }
    }
}
