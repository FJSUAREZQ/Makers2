using _1.DAL.DataContext;
using _1.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BLL.Services
{
    public class Services: IServices
    {

        private readonly IRepositoryAuth _repoAuth;
        private readonly IRepositoryUsuario _repoUsuario;
        private readonly IRepositoryPrestamo _repoPrestamo;
        private readonly IConfiguration _config;

        #region UsersLogin
        public Services(IRepositoryAuth _repositoryAuth, IRepositoryPrestamo repositoryPrestamo, IRepositoryUsuario repositoryUsuario, IConfiguration _configuration)
        {
            this._repoAuth = _repositoryAuth;
            this._repoPrestamo = repositoryPrestamo;
            this._repoUsuario = repositoryUsuario;
            this._config = _configuration;
        }

        /// <summary>
        /// Metodo que permite consulatar todos los usuarios existentes
        /// </summary>
        /// <returns>Lista de ussuarios existentes</returns>
        public async Task<List<Usuario>> GetUsersAll()
        {
            List<Usuario> result;
            result = await _repoAuth.GetUsersAll();

            return result;
        }


        /// <summary>
        /// Metodo que pernite crear un ususario
        /// </summary>
        /// <param name="user">Ususario que sera creado</param>
        /// <returns>Booleano que indica si el usuario fue creado con exito o no</returns>
        public async Task<bool> CreateUser(Usuario user)
        {
            bool result;
            result = await _repoAuth.CreateUser(user);

            return result;
        }

        /// <summary>
        /// Permite buscar un ususario mediante el nomnre de usuario
        /// </summary>
        /// <param name="userName">Nombre de usuario a buscar</param>
        /// <returns>usuario encontrado</returns>
        public async Task<Usuario> GetUserLogin(string userName)
        {
            Usuario _user = await _repoAuth.GetUserLogin(userName);

            return _user;
        }

#endregion UsersLogin




        #region Usuarios
        public async Task<Usuario> GetByUsuarioIdAsync(int id)
        {
            return await _repoUsuario.GetByIdAsync(id);
        }

        #endregion Usuarios




        #region Prestamos
        public async Task<List<Prestamo>> GetPrestamosAllAsync()
        {
            return await _repoPrestamo.GetPrestamosAllAsync();
        }

        public async Task<Prestamo> GetByPrestamoIdAsync(int id)
        {
            return await _repoPrestamo.GetPrestamoByIdAsync(id);
        }

        public async Task<List<Prestamo>> GetPrestamoByUsuarioIdAsync(int userId)
        {
            return await _repoPrestamo.GetByUsuarioIdAsync(userId);
        }

        public async Task<int> CrearPrestamosAsync(Prestamo prestamo)
        {
            if (prestamo == null)
            {
                throw new ArgumentNullException(nameof(prestamo), "El prestamo no puede ser nulo");
            }
            int result = await _repoPrestamo.CreateAsync(prestamo);
            return result;
        }

        public async Task ActualizarPrestamoAsync(Prestamo prestamo)
        {
            if (prestamo == null)
            {
                throw new ArgumentNullException(nameof(prestamo), "El prestamo no puede ser nulo");
            }
            await _repoPrestamo.UpdateAsync(prestamo);
        }

        #endregion Prestamos



    }
}
