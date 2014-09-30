using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Document Base Data Response domain model
    /// </summary>
    public class DocumentBaseDataResponse
    {
        /// <summary>
        /// List of Document Group
        /// </summary>
        public IEnumerable<DocumentGroup> DocumentGroups { get; set; }
    }
}
