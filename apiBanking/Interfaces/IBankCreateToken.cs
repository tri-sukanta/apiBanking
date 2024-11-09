using apiBanking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBanking.Interfaces
{
    public interface IBankCreateToken
    {
        Task<AdAuthResponse> CreateToken(AuthenticationModel UIAuthCredentials, string ipAddress, bool IsRefreshed);

    }
}
