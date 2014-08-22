using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Models.CommonTypes;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
  public  class OperationBaseDataResponse
    { 
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public List<String> DepartmentTypes { get; set; }
    }
}
