using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Address Type Repository Interface
    /// </summary>
    public interface IAddressTypeRepository : IBaseRepository<AddressType, int>
    {
        /// <summary>
        /// Get Address Type Id using Address Type Key value
        /// </summary>    
        short GetAddressTypeIdByAddressTypeKey(long addressTypeKey);
    }
}
