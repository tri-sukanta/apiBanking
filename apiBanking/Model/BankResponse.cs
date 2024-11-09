using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBanking.Model
{
    public class BankResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string ReferenceId { get; set; }
    }
}
