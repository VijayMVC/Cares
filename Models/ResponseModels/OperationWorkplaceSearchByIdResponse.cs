using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Response model to the request to find all operations associated with workplace
    /// </summary>
    public class OperationWorkplaceSearchByIdResponse
    {
        public IEnumerable<DomainModels.OperationsWorkPlace> OperationWorkPlaces { get; set; }
    }
}
