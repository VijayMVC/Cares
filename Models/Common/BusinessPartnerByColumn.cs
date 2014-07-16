using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{ /// <summary>
    /// Order By Business Partner columns
    /// </summary>
    public enum BusinessPartnerByColumn
    {
         /// <summary>
        /// Business Partner Id
        /// </summary>
        BusinessPartnerId = 1,

        /// <summary>
        /// Business Partner Name
        /// </summary>
        BusinessPartnerName = 2,

        /// <summary>
        /// Is Individual
        /// </summary>
        IsIndividual = 3,
        
        /// <summary>
        /// CompanyName
        /// </summary>
        CompanyName = 4,

        /// <summary>
        /// BP Rating TypeName
        /// </summary>
        BPRatingTypeName = 5,

    }
}
