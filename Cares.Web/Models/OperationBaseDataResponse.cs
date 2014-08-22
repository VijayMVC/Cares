using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.Web.Models
{
    public class OperationBaseDataResponse
    {
        #region Public
       
        public IEnumerable<CompanyDropDown> Companies { get; set; }

      
        public IEnumerable<DepartmentDropDown> Departmens { get; set; }
        public IEnumerable<string> DepartmensType { get; set; }
        #endregion
    }
}