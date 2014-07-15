using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Business Partner Service Interface
    /// </summary>
    public interface IBusinessPartnerService
    {
        /// <summary>
        /// Get all business partneres
        /// </summary>
        /// <param name="businessPartnerSearchRequest"></param>
        /// <returns></returns>
        BusinessPartnerResponse LoadAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest);
        
        //Product FindProduct(int id);
        //IEnumerable<Product> FindProductsByCategory(int catId); 
        //void DeleteProduct(Product product);
        //bool AddProduct(Product product);
        //bool Update(Product product);//,Category category

    }
}
