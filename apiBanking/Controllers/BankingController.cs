using apiBanking.Interfaces;
using apiBanking.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBanking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BankingController : ControllerBase
    {
        private readonly IBankingService _service;
        private readonly IValidationManager _validationManager;
        public BankingController(IBankingService service, IValidationManager validationManager)
        {
            _service = service;
            _validationManager = validationManager;
        }
        [HttpPost("createaccounts")]
        public async Task<BankResponse> CreateAccount([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                throw new System.Exception();
            }
            try
            {
                await _validationManager.ValidateAccountRequest(account);
                var isInsert = await _service.CreateAccount(account);
                var result = new BankResponse();
                if (isInsert)
                {
                    result = new BankResponse { StatusCode = 200, Message = "Account Created Sucessfully", ReferenceId = "" };
                }
                return result;
            }
            catch (Exception ex)
            {
                var result = new BankResponse { Message = ex.Message, ReferenceId = "" };
                //throw new Exception(ex.Message);
                return result;
            }

        }


        [HttpPost("deposit")]
        public async Task<BankResponse> Deposit([FromBody] Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                throw new System.Exception();
            }
            try
            {
                var isDeposit = await _service.Deposit(transaction);
                var result = new BankResponse();
                if (isDeposit)
                {
                    result = new BankResponse { StatusCode = 200, Message = "Deposit Sucessfully", ReferenceId = "" };
                }
                return result;
            }
            catch (Exception ex)
            {
                var result = new BankResponse { Message = ex.Message, ReferenceId = "" };
                //throw new Exception(ex.Message);
                return result;
            }
        }

        [HttpPost("withdraw")]
        public async Task<BankResponse> Withdraw([FromBody] Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                throw new System.Exception();
            }
            try
            {
                var isDeposit = await _service.Withdraw(transaction);
                var result = new BankResponse();
                if (isDeposit)
                {
                    result = new BankResponse { StatusCode = 200, Message = "Withdraw Sucessfully", ReferenceId = "" };
                }
                return result;
            }
            catch (Exception ex)
            {
                var result = new BankResponse { Message = ex.Message, ReferenceId = "" };
                //throw new Exception(ex.Message);
                return result;
            }
        }
    }
}
