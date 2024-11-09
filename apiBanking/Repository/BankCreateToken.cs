using apiBanking.Interfaces;
using apiBanking.Model;
using apiBanking.Model.DBModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Security.Cryptography;



namespace apiBanking.Repository
{
    public class BankCreateToken : IBankCreateToken
    {
        private readonly BankingDbContext _dbContext;
        private readonly IOptions<ApplicationSettings> _configuration;

        public BankCreateToken(BankingDbContext dbContext, IOptions<ApplicationSettings> configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<AdAuthResponse> CreateToken(AuthenticationModel UIAuthCredentials, string ipAddress, bool IsRefreshed)
        {
            try
            {
                AdAuthResponse isAuthenticated = new AdAuthResponse();
                var token = await GenerateToken(UIAuthCredentials, ipAddress);
                isAuthenticated = token;
                return isAuthenticated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<AdAuthResponse> GenerateToken(AuthenticationModel UIAuthCredentials, string ipAddress)
        {
            try
            {

                //var authSigningKey = new System.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Value.JWTKey));
                var tokenKey = Encoding.ASCII.GetBytes(_configuration.Value.JWTKey);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.Value.JWTKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("Name", UIAuthCredentials.UserName.ToString()) }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

                    Issuer = _configuration.Value.JWTIssuer,
                    Audience = _configuration.Value.JWTAudience

                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);


                AdAuthResponse isAuthenticated = new AdAuthResponse()
                {
                    Result = new AdValidationResult
                    {
                        Token = jwtToken.ToString(),
                        CreatedByIp = ipAddress,// ip.AddressList[1].ToString(),
                        Expires = DateTime.UtcNow.AddMinutes(30)
                    }

                };

                return isAuthenticated;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
