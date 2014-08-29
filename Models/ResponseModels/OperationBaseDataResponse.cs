using Cares.Models.DomainModels;
using System;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Operation Base Data Response class
    /// </summary>
  public  class OperationBaseDataResponse
    { 
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public List<String> DepartmentTypes { get; set; }
    }
}
