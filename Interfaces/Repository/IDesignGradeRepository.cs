using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Design Grade Repository Interface
    /// </summary>
    public interface IDesignGradeRepository : IBaseRepository<DesignGrade, long>
    {
        /// <summary>
        /// Search Desig Grade
        /// </summary>
        IEnumerable<DesignGrade> SearchDesigGrade(DesignGradeSearchRequest request, out int rowCount);

        /// <summary>
        /// To validate the code duplication check 
        /// </summary>
        bool DesignGradeCodeDuplicationCheck(DesignGrade designGrade);
    }
}