using System.Collections.Generic;
using Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICategoryRepository : IBaseRepository<Category, long>
    {
        IEnumerable<Category> GetAllCategories();
    }
}
