using Cares.Models.CommonTypes;
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Department BaseData Response
    /// </summary>
    public class DepartmentBaseDataResponse
    {
        #region Public
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<Company> Companies { get; set; }
        #endregion
    }
}