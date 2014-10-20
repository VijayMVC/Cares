using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Payment Mode Mapper
    /// </summary>
    public static class PaymentModeMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static PaymentMode CreateFrom(this Cares.Models.DomainModels.PaymentMode source)
        {
            return new PaymentMode
            {
                PaymentModeId = source.PaymentModeId,
                PaymentModeKey = source.PaymentModeKey,
                PaymentModeName = source.PaymentModeName,
                PaymentModeCode = source.PaymentModeCode,
                PaymentModeCodeName = source.PaymentModeCode + "-" + source.PaymentModeName,
                PaymentModeDescription = source.PaymentModeDescription
            };
        }

        /// <summary>
        ///  Create web model from entity [dropdown]
        /// </summary>
        public static PaymentModeDropDown CreateFromForLookup(this Cares.Models.DomainModels.PaymentMode source)
        {
            return new PaymentModeDropDown
            {
                PaymentModeId = source.PaymentModeId,
                PaymentModeCodeName = source.PaymentModeCode + " - " + source.PaymentModeName,
                PaymentModeKey = source.PaymentModeKey
            };
        }

        /// <summary>
        ///  Create From web model 
        /// </summary>
        public static Cares.Models.DomainModels.PaymentMode CreateFrom(this PaymentMode source)
        {
            return new Cares.Models.DomainModels.PaymentMode
            {
                PaymentModeId = source.PaymentModeId,
                PaymentModeName = source.PaymentModeName,
                PaymentModeCode = source.PaymentModeCode,
                PaymentModeDescription = source.PaymentModeDescription
            };
        }

        #endregion
    }
}