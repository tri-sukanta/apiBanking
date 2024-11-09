using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBanking.Model
{
    public class AuthenticationModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationModel"/> class.
        /// </summary>
        public AuthenticationModel()
        {
            Password = string.Empty;
            UserName = string.Empty;
        }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }
    }
}
