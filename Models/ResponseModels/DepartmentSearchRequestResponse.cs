using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Department Search Request Response
    /// </summary>
   public class DepartmentSearchRequestResponse
    {
        #region Public
        /// <summary>
        ///Departments List
        /// </summary>
       public IEnumerable<Department> Departments { get; set; }

        /// <summary>
        /// FleetPools Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
