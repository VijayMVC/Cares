
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// NRT Main Repository interface
    /// </summary>
    public interface INrtMainRepository: IBaseRepository<NrtMain, long>
    {
        /// <summary>
        /// Associaton check with nrt type before deletion
        /// </summary>
        bool IsNrtMainAssociatedWithNrtType(long nrtTypeId);
    }
}
