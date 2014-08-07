using System.Linq;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<Product, long>
    {
        ProductResponse GetAllProducts(ProductSearchRequest productSearchRequest);
        IQueryable<Product> GetProductsByCategory(int catID);
        Product GetProductByName(string name, int id);
    }
}
