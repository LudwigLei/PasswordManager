using PWManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWManager.Services
{
    #region Interface 
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);    
        Task<User> GetValidatedUserAsync(string name, string password);       
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid userId);
    }
    #endregion

    #region Interface implementation
    public class UserRepository : IUserRepository
    {
        PWManagerContext _context = new PWManagerContext();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> AddUserAsync(User user)
        {            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task DeleteUserAsync(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(a => a.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User> GetUserAsync(Guid id)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<User> GetValidatedUserAsync(string name, string password)
        {
            try
            {
                User user = _context.Users.Where(x => x.Username.Equals(name)).Single();
                if (Security.Security.PasswordValdation(password, user.Password))
                {
                    return _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(name));
                }
            }
            catch (Exception) 
            {
                return null;
            }
            return null;            
        }      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> UpdateUserAsync(User user)
        {
            try
            {
                if (!_context.Users.Local.Any(u => u.Id == user.Id))
                {
                    _context.Users.Attach(user);
                }
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
    }
    #endregion
}
