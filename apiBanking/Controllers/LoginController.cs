using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiBanking.Interfaces;
using apiBanking.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;


namespace apiBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IOptions<ApplicationSettings> _configuration;
        private readonly IBankCreateToken _createToken;

        public LoginController(IOptions<ApplicationSettings> configuration,IBankCreateToken createToken)
        {
            _configuration = configuration;
            _createToken = createToken;

        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] AuthenticationModel UIAuthCredentials)
        {
          
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new System.Exception();
                }
               
                AdAuthResponse isADAuthenticated = await _createToken.CreateToken(UIAuthCredentials, ipAddress(), false);
                return Ok(isADAuthenticated);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }

        private string ipAddress()
        {
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            //private static string host = Dns.GetHostName();
            //// Getting ip address using host name
            //IPHostEntry ip = Dns.GetHostEntry(host);

        }

        //private string ipAddress() =>
        //Request.Headers.ContainsKey("X-Forwarded-For")
        //    ? Request.Headers["X-Forwarded-For"]
        //    : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? "N/A";

    }
}
