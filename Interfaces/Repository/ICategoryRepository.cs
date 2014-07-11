using System.Collections.Generic;
using Models.DomainModels;

namespace Interfaces.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category, int>
    {
        IEnumerable<Category> GetAllCategories();
    }
}
