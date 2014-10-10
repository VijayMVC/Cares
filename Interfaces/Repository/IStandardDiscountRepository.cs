using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Standard Discount Repository Interface
    /// </summary>
    public interface IStandardDiscountRepository : IBaseRepository<StandardDiscount, long>
    {
        /// <summary>
        /// Association check of Standard Discount and vehicle make
        /// </summary>
        bool IsStandardDiscountAssociatedWithVehicleMake(long vehicleMakeId);

    }
}
