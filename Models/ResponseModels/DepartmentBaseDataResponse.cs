using Cares.Models.CommonTypes;
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    public class DepartmentBaseDataResponse
    {
        #region Public
        public IEnumerable<Company> Companies { get; set; }
        #endregion
    }
}