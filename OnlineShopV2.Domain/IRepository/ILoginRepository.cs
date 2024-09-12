using OnlineShopV2.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Domain.IRepository
{
    public interface ILoginRepository
    {
        Task<string> CheckSignIn(string username, string password);
        Task<string> CreateUserAsync(Users request);
        Task<List<Users>> GetUserAsync();
    }
}
