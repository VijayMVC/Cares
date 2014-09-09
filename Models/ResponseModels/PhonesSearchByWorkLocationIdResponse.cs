using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{

    /// <summary>
    /// Response model to the request to find all phones associated with worklocation
    /// </summary>
    public class PhonesSearchByWorkLocationIdResponse
    {
        /// <summary>
        /// list of phones asssiciated with worklocation
        /// </summary>
        public IEnumerable<DomainModels.Phone> PhonesAssociatedWithWorkLocation { get; set; }
    }
}
