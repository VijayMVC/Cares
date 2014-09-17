using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Employee Job Progress Repository Interface
    /// </summary>
    public interface IEmpJobProgRepository : IBaseRepository<EmpJobProg, long>
    {
        /// <summary>
        /// To check the asssociation of designation and emp job info 
        /// </summary>
        bool IsEmpJobProgressAssociatedWithDesignation(long designationId);
    }
}
