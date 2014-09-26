using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// RaHireGroup Discount Mapper
    /// </summary>
    public static class RaHireGroupDiscountMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static RaHireGroupDiscount CreateFrom(this DomainModels.RaHireGroupDiscount source)
        {
            return new RaHireGroupDiscount
            {
                RaHireGroupDiscountId = source.RaHireGroupDiscountId,
                RaHireGroupId = source.RaHireGroupId,
                StartDtTime = source.StartDtTime,
                EndDtTime = source.EndDtTime,
                TariffType = source.TariffType,
                DiscountAmount = source.DiscountAmount,
                DiscountCode = source.DiscountCode,
                DiscountDays = source.DiscountDays,
                DiscountHours = source.DiscountHours,
                DiscountKey = source.DiscountKey,
                DiscountMinutes = source.DiscountMinutes,
                DiscountPerc = source.DiscountPerc
            };
           
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DomainModels.RaHireGroupDiscount CreateFrom(this RaHireGroupDiscount source)
        {
            return new DomainModels.RaHireGroupDiscount
            {
                RaHireGroupDiscountId = source.RaHireGroupDiscountId,
                RaHireGroupId = source.RaHireGroupId,
                StartDtTime = source.StartDtTime,
                EndDtTime = source.EndDtTime,
                TariffType = source.TariffType,
                DiscountAmount = source.DiscountAmount,
                DiscountCode = source.DiscountCode,
                DiscountDays = source.DiscountDays,
                DiscountHours = source.DiscountHours,
                DiscountKey = source.DiscountKey,
                DiscountMinutes = source.DiscountMinutes,
                DiscountPerc = source.DiscountPerc
            };

        }

        #endregion

    }
}
