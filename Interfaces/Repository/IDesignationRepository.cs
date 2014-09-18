using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Designation Repository Interface
    /// </summary>
    public interface IDesignationRepository : IBaseRepository<Designation, long>
    {
        /// <summary>
        /// Search Designation
        /// </summary>
        IEnumerable<Designation> SearchDesignation(DesignationSearchRequest request, out int rowCount);

        /// <summary>
        /// Designation code duplication check
        /// </summary>
        bool DoesDesignationCodeExist(Designation designation);
    }
}
