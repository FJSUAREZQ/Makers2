using _1.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BLL.Services
{
    public interface IServices
    {

        #region UsuariosLogin

        Task<bool> CreateUser(Usuario user);
        Task<Usuario> GetUserLogin(string userName);
        Task<List<Usuario>> GetUsersAll();

        #endregion UsuariosLogin


        #region Usuarios
        Task<Usuario> GetByUsuarioIdAsync(int id);
        #endregion Usuasrios



        #region Prestamos
        Task<List<Prestamo>> GetPrestamosAllAsync();
        Task<Prestamo> GetByPrestamoIdAsync(int id);
        Task<List<Prestamo>> GetPrestamoByUsuarioIdAsync(int userId);
        Task<int> CrearPrestamosAsync(Prestamo prestamo);
        Task ActualizarPrestamoAsync(Prestamo prestamo);

        #endregion Prestamos


    }
}
