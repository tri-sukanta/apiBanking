﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBanking.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string UserId { get; set; }
       // public User User { get; set; }
        public string AccountNumber { get; set; } 
        public decimal Balance { get; set; }

    }
}
