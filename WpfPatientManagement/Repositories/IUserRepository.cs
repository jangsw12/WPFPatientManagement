using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPatientManagement.Models;

namespace WpfPatientManagement.Repositories
{
    public interface IUserRepository
    {
        Task<List<USERS>> SelectUserAsync();
        Task<USERS?> GetUserByCredentialAsync(string id, string password);
        Task<USERS?> GetUserByIdAsync(string id);
    }
}