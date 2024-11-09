using apiBanking.Interfaces;
using apiBanking.Model;
using apiBanking.Model.DBModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace apiBanking.Repository
{
    public class AccountServiceTests
    {
        //private readonly Mock<BankingDbContext> _mockContext;
        //private readonly BankingService _service;

        //public AccountServiceTests()
        //{
        // _mockContext = new Mock<BankingDbContext>();
        //_service = new BankingService(_mockContext.Object);
        //}

        private readonly Mock<BankingDbContext> _repositoryMock;
        private readonly BankingService _service;

        public AccountServiceTests()
        {
            _repositoryMock = new Mock<BankingDbContext>();
            _service = new BankingService(_repositoryMock.Object);
        }


        [Fact]
        public async Task Deposit_ValidAmount_ShouldSucceed()
        {
            //var deposit = new Account { Id = 1, Balance = 500 };
           
            Transaction transactions = new Transaction()
            {
                AccountId = 5,
                Amount = 11000,
                Type = "D",
                Date = DateTime.UtcNow
            };


           // _mockContext.Setup(x => x.Accounts.FindAsync(1)).ReturnsAsync(account);

            var result = await _service.Deposit(transactions);

            Assert.True(result);
            Assert.Equal(1500, transactions.Amount);
        }
    }
}
