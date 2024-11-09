using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBanking.Model
{
    public class AdValidationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdValidationResult"/> class.
        /// </summary>
        public AdValidationResult()
        {
            UserName = string.Empty;
            Pwd = string.Empty;
            Token = string.Empty;
            GroupList = new ArrayList();
            ETime = 0;
            ID = 0;
            Role = new string[] { };
            AccessLevel = string.Empty;
            Expires = DateTime.UtcNow;
            Created = DateTime.UtcNow;
            CreatedByIp = string.Empty;
            Revoked = DateTime.UtcNow;
            ReplacedByToken = string.Empty;
        }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Int32 ID { get; set; }
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public string[] Role { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Pwd { get; set; }
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }

        public string RefreshToken { get; set; }
        /// <summary>
        /// Gets or sets the group list.
        /// </summary>
        /// <value>
        /// The group list.
        /// </value>
        public ArrayList GroupList { get; set; }
        /// <summary>
        /// Gets or sets the e time.
        /// </summary>
        /// <value>
        /// The e time.
        /// </value>
        public Int32 ETime { get; set; }
        /// <summary>
        /// Gets or sets the access level.
        /// </summary>
        /// <value>
        /// The access level.
        /// </value>
        public string AccessLevel { get; set; }



        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool IsRevoked => Revoked != null;
        public bool IsActive => !IsRevoked && !IsExpired;




    }
}
