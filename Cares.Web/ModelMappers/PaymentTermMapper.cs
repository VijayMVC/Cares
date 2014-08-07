using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Payment Term Mapper
    /// </summary>
    public static class PaymentTermMapper
    {
        #region Public
        /// <summary>
        ///  Create web api model from domail model
        /// </summary>
        public static PaymentTerm CreateFrom(this Cares.Models.DomainModels.PaymentTerm source)
        {
            return new PaymentTerm
            {
                PaymentTermId = source.PaymentTermId,
                PaymentTermName = source.PaymentTermName
            };
        }
        /// <summary>
        ///  Create domain model from web api model
        /// </summary>
        public static Cares.Models.DomainModels.PaymentTerm CreateFrom(this PaymentTerm source)
        {
            if (source != null)
            {
                return new Cares.Models.DomainModels.PaymentTerm
                {
                    PaymentTermId = source.PaymentTermId,
                    PaymentTermName = source.PaymentTermName
                };
            }
            return new Cares.Models.DomainModels.PaymentTerm();
        }
        #endregion
    }
}