using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cares.Models.Common
{
    public enum OperationByColumn   /////////////////////
    {
       
        OperationCode = 1,
       
        OperationName = 2,
        /// <summary>
        /// FleetPool Operation
        /// </summary>
        Description = 3,
        /// <summary>
        /// Country Name
        /// </summary>
        Company = 4,
        /// <summary>
        /// Region Name
        /// </summary>
        DepartmentType = 5,
        Department = 6
    }
}
