using System.Collections.Generic;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.IServices
{
    public interface IProductService
    {
        ProductResponse LoadAllProducts(ProductSearchRequest productSearchRequest);
        Product FindProduct(int id);
        IEnumerable<Product> FindProductsByCategory(int catId); 
        void DeleteProduct(Product product);
        bool AddProduct(Product product);
        bool Update(Product product);//,Category category

    }
}
