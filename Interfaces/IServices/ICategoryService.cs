using System.Collections.Generic;
using Models.DomainModels;

namespace Cares.Interfaces.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> LoadAllCategories();
    }
}
