using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiBanking.Interfaces;
using apiBanking.Model;
using apiBanking.Model.DBModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace apiBanking.Repository
{
    public class BankingService : IBankingService
    {
        private readonly BankingDbContext _dbContext;
        public BankingService(BankingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // public User GetUser(int userId) => _repository.GetUserById(userId);

        public async Task<bool> CreateAccount(Account accounts)
        {
            try
            {
                Account account = new Account()
                {
                    UserId = accounts.UserId,
                    AccountNumber = accounts.AccountNumber,
                    Balance = accounts.Balance

                };

                //using (var tran = await _dbContext.Database.BeginTransactionAsync())
                //{
                //    try
                //    {
                var response = _dbContext.Accounts.Add(account);
                await _dbContext.SaveChangesAsync();
                var fetchAccount = _dbContext.Accounts.Where(c => accounts.AccountNumber.Equals(c.AccountNumber)).FirstOrDefault();



                Transaction transaction = new Transaction()
                {
                    AccountId = fetchAccount.Id,
                    Amount = account.Balance,
                    Type = "D",
                    Date = DateTime.UtcNow
                };
                _dbContext.Transactions.Add(transaction);

                await _dbContext.SaveChangesAsync();

                //    await tran.CommitAsync();
                //}
                //catch (Exception e)
                //{
                //    await tran.RollbackAsync();
                //    throw new Exception(e.Message);
                //}
                // }


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public void DeleteAccount(int accountId)
        //{
        //    var account = _repository.GetAccountById(accountId);
        //    if (account != null)
        //    {
        //        _repository.GetUserById(account.UserId)?.Accounts.Remove(account);
        //        _repository.SaveChanges();
        //    }
        //}
        public async Task<bool> Deposit(Transaction transaction)
        {
            try
            {
                if (transaction.Amount > 10000) throw new Exception("Deposit exceeds maximum allowed amount.");

                var accountDet = _dbContext.Accounts.Where(c => transaction.Account.AccountNumber.Equals(c.AccountNumber)).FirstOrDefault();

                accountDet.Balance = accountDet.Balance + transaction.Amount;

                Transaction transactions = new Transaction()
                {
                    AccountId = accountDet.Id,
                    Amount = transaction.Amount,
                    Type = "D",
                    Date = DateTime.UtcNow
                };
                _dbContext.Transactions.Add(transactions);



                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Withdraw(Transaction transaction)
        {
            try
            {

                var accountDet = _dbContext.Accounts.Where(c => transaction.Account.AccountNumber.Equals(c.AccountNumber)).FirstOrDefault();

                if (transaction.Amount >= (accountDet.Balance * 0.9M)) throw new Exception("Deposit exceeds maximum allowed amount.");



                accountDet.Balance = accountDet.Balance - transaction.Amount;

                Transaction transactions = new Transaction()
                {
                    AccountId = accountDet.Id,
                    Amount = transaction.Amount,
                    Type = "W",
                    Date = DateTime.UtcNow
                };
                _dbContext.Transactions.Add(transactions);



                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
