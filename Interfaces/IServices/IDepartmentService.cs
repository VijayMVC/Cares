using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;

namespace Interfaces.IServices
{
    public interface IDepartmentService
    {
        IEnumerable<Department> LoadAll();
    }
}
