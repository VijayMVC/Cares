using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.Web.Models
{
    /// <summary>
    /// Operation BaseData Response
    /// </summary>
    public class OperationBaseDataResponse
    {
        #region Public
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<CompanyDropDown> Companies { get; set; }
        /// <summary>
        /// Departmens
        /// </summary>
        public IEnumerable<DepartmentDropDown> Departmens { get; set; }
        /// <summary>
        /// DepartmensType
        /// </summary>
        public IEnumerable<string> DepartmensType { get; set; }

        #endregion
    }
}