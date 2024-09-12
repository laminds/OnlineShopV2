using OnlineShopV2.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnlineShopV2.Domain.Security;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Domain.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopV2.Infrastructure.Repository
{
    public class AdminLoginRepository : ILoginRepository
    {
        protected OnlineShopDbContext dbcontext;
        public AdminLoginRepository(OnlineShopDbContext _db)
        {
            dbcontext = _db;
        }

        public async Task<List<Users>> GetUserAsync()
        {
            return await dbcontext.Users.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<string> CheckSignIn(string username, string password)
        {
            try
            {
                var IsUserExist = dbcontext.Users.Where(x => x.IsDelete == false && x.IsAdmin == true && x.Email.ToLower() == username.ToLower()).FirstOrDefault();
                if (IsUserExist != null)
                {
                    var Password = AESCryptography.Decrypt(IsUserExist.Password);//Amit@123
                    if (Password == password)
                    {
                        return IsUserExist.FirstName + " " + IsUserExist.LastName;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            return "true";
        }

        public async Task<string> CreateUserAsync(Users request)
        {
            try
            {
                if (request.UserId != 0)
                {
                    
                    var result = await dbcontext.Database.ExecuteSqlRawAsync("EXEC [admin].[usp_InsertAndUpdateUserDetails] @UserId = {0}, @CustomerRole = {1}",
                    request.UserId, request.CustomerRole);
                    return "User Update successfully";
                }
                else
                {
                    var result = await dbcontext.Database.ExecuteSqlRawAsync("EXEC [admin].[usp_InsertAndUpdateUserDetails] @Guid = {0}, @FirstName = {1}, @LastName = {2}, @Email = {3}, @Password = {4}, @Phone = {5}, @CustomerRole = {6}, @CreatedBy = {7}",
                    request.Guid, request.FirstName, request.LastName, request.Email, request.Password, request.Phone,
                    request.CustomerRole, request.CreatedBy);
                    return "User Save successfully";
                }
            }
            catch (Exception ex)
            {
                return "false";
            }
        }
    }
}
