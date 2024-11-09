using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace apiBanking.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
