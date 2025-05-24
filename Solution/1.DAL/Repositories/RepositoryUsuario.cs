using _1.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        private readonly MakersDbContext _dbContext;

        public RepositoryUsuario(MakersDbContext dbContext)
        {
           this._dbContext = dbContext;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _dbContext.Usuarios.FindAsync(id);
        }
    }
}
