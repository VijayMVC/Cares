using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Response model to the request to find all operations associated with workplace
    /// </summary>
    public class OperationWorkplaceSearchByIdResponse
    {
        public IEnumerable<OperationsWorkPlace> OperationWorkPlaces { get; set; }
    }
}
