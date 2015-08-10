using PWManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWManager.Services
{
    #region Interface
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccountsAsync(Guid userId);
        Task<Account> GetAccountAsync(Guid id);
        Task<Account> AddAccountAsync(Account account);
        Task<Account> UpdateAccountAsync(Account account);
        Task DeleteAccountAync(Guid id);
    }
    #endregion


    #region Interface implementation
    public class AccountRepository : IAccountRepository
    {
        PWManagerContext _context = new PWManagerContext();

        public async Task<Account> AddAccountAsync(Account account)
        {
            // Validate the form here...
            if (true)
            {
                _context.Accounts.Add(account);
            }
            else
            {
                // implement INotifyDataErrorInfo
                MessageDialog.PromptError("FormatException Validation Error");
            }
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task DeleteAccountAync(Guid id)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
            await _context.SaveChangesAsync();            
        }

        public Task<Account> GetAccountAsync(Guid id)
        {
            return _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task<List<Account>> GetAccountsAsync(Guid userId)
        {
            return _context.Accounts.Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            if (!_context.Accounts.Local.Any(c => c.Id == account.Id))
            {
                _context.Accounts.Attach(account);
                
            }
            // Form validation 
            if (true)
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return account;
        }
    }
    #endregion
}
