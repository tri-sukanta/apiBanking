using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBanking.Model
{
    public class AdAuthResponse 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdAuthResponse"/> class.
        /// </summary>
        public AdAuthResponse()
        {
            Result = new AdValidationResult();
        }
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public AdValidationResult Result { get; set; }

    }
}
