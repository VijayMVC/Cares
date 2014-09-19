using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Operation BaseData Response web model
    /// </summary>
    public class OperationBaseDataResponse
    {
        #region Public
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