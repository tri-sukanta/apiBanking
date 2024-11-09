using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiBanking.Model;

namespace apiBanking.Interfaces
{
    public interface IBankingService
    {
       // User GetUser(int userId);
        Task<bool> CreateAccount(Account accounts);
        //void DeleteAccount(int accountId);
        Task <bool> Deposit(Transaction transaction);
        Task<bool> Withdraw(Transaction transaction);
    }
}
