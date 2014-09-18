using Cares.Models.DomainModels;
namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Address Repository Interface
    /// </summary>
    public interface IAddressRepository : IBaseRepository<Address, long>
    {
        /// <summary>
        /// To check the association of area with address
        /// </summary>
        bool IsAreaAssociatedWithAddress(long areaId);
    }
}
