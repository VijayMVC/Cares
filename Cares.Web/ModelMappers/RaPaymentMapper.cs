using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// RaPayment Mapper
    /// </summary>
    public static class RaPaymentMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static RaPayment CreateFrom(this DomainModels.RaPayment source)
        {
            return new RaPayment
            {
                RaPaymentId = source.RaPaymentId,
                RaMainId = source.RaMainId,
                Bank = source.Bank,
                ChequeNumber = source.ChequeNumber,
                ClearanceDate = source.ClearanceDate,
                CreditCardExpiryDt = source.CreditCardExpiryDt,
                CreditCardNumber = source.CreditCardNumber,
                CreditCardType = source.CreditCardType,
                IssueDate = source.IssueDate,
                PaidBy = source.PaidBy,
                PaymentModeId = source.PaymentModeId,
                RaPaymentAmount = source.RaPaymentAmount,
                RaPaymentDt = source.RaPaymentDt
            };
           
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DomainModels.RaPayment CreateFrom(this RaPayment source)
        {
            return new DomainModels.RaPayment
            {
                RaPaymentId = source.RaPaymentId,
                RaMainId = source.RaMainId,
                Bank = source.Bank,
                ChequeNumber = source.ChequeNumber,
                ClearanceDate = source.ClearanceDate,
                CreditCardExpiryDt = source.CreditCardExpiryDt,
                CreditCardNumber = source.CreditCardNumber,
                CreditCardType = source.CreditCardType,
                IssueDate = source.IssueDate,
                PaidBy = source.PaidBy,
                PaymentModeId = source.PaymentModeId,
                RaPaymentAmount = source.RaPaymentAmount,
                RaPaymentDt = source.RaPaymentDt
            };

        }

        #endregion

    }
}
