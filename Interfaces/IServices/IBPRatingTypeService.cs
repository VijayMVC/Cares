using System.Linq;
using Models.DomainModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Business partner Rating Type Service Interface
    /// </summary>
    public interface IBPRatingTypeService
    {
        IQueryable<BpRatingType> LoadAll();
    }
}
