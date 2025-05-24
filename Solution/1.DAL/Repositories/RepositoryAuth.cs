using _1.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public class RepositoryAuth :IRepositoryAuth
    {

        private readonly MakersDbContext _dbContext;


        public RepositoryAuth(MakersDbContext _context)
        {
            this._dbContext = _context;
        }


        /// <summary>
        /// Permite consulatar todos los usuarios existentes
        /// </summary>
        /// <returns>Lista de usuarios existentes</returns>
        public async Task<List<Usuario>> GetUsersAll()
        {
            List<Usuario> _users = new List<Usuario>();
            _users =await _dbContext.Usuarios.ToListAsync<Usuario>();

            return _users;
        }


        /// <summary>
        /// Metodo que pernite crear un ususario
        /// </summary>
        /// <param name="user">Ususario que sera creado</param>
        /// <returns>Booleano que indica si el usuario fue creado con exito o no</returns>
        public async Task<bool> CreateUser(Usuario user)
        {
            _dbContext.Usuarios.Add(user);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        /// <summary>
        /// Permite buscar un ususario mediante el nomnre de usuario
        /// </summary>
        /// <param name="userName">Nombre de usuario a buscar</param>
        /// <returns>usuario encontrado</returns>
        public async Task<Usuario> GetUserLogin(string userName)
        {
            Usuario _user = await _dbContext.Usuarios.SingleOrDefaultAsync(u => u.Nombre == userName);

            return _user;
        }






    }
}
