using apiBanking.Interfaces;
using apiBanking.Model;
using apiBanking.Model.DBModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBanking.Repository
{
    public class ValidationManager : IValidationManager
    {
        private readonly BankingDbContext _dbContext;


        public ValidationManager(BankingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ValidateAccountRequest(Account accountRequest)
        {

            ValidateCustomerRequest(accountRequest);

        }


        public void ValidateCustomerRequest(Account accountRequest)
        {
            var accountInfo = _dbContext.Accounts.Where(c => accountRequest.AccountNumber.Equals(c.AccountNumber)).FirstOrDefault();
            if (accountInfo != null)
            {
                throw new Exception("Account Number Already Exist");
            }

            if (string.IsNullOrEmpty(accountRequest.AccountNumber))
            {
                throw new Exception("Enter Account Number");
            }

            if (accountRequest.Balance < 100)
            {
                throw new Exception("Account Opening Amount Should be Equal/More than 100");
            }
        }

    }
}
