using _1.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public interface IRepositoryAuth
    {
        Task<bool> CreateUser(Usuario user);

        Task<Usuario> GetUserLogin(string userName);

        Task<List<Usuario>> GetUsersAll();


    }
}
