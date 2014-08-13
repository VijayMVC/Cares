using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Hire Group Up Grade Repository Interface
    /// </summary>
    public interface IHireGroupUpGradeRepository:IBaseRepository<HireGroupUpGrade, long>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<HireGroupUpGrade> FindByHireGroupId(long id);
    }
}
