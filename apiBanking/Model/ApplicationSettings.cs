using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBanking.Model
{
    public class ApplicationSettings
    {
        public string MicroserviceName { get; set; }
        public string JWTKey { get; set; }
        public string JWTIssuer { get; set; }
        public string JWTAudience { get; set; }
       public string MediaTypeHeaderValue { get; set; }
    }
}
