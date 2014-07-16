using System.Linq;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<Product, long>
    {
        ProductResponse GetAllProducts(ProductSearchRequest productSearchRequest);
        IQueryable<Product> GetProductsByCategory(int catID);
        Product GetProductByName(string name, int id);
    }
}
