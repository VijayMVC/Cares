using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Response model to the request to find all phones associated with worklocation
    /// </summary>
    public class PhonesSearchByWorkLocationIdResponse
    {
         /// <summary>
        /// list of phones asssiciated with worklocation
        /// </summary>
        public IEnumerable<Phone> PhonesAssociatedWithWorkLocation { get; set; }
    }
    
}