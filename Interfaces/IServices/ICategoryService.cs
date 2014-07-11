using System.Collections.Generic;
using Models.DomainModels;

namespace Interfaces.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> LoadAllCategories();
    }
}
