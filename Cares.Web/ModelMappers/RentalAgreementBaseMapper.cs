using System.Linq;
using Cares.Models.ResponseModels;
using ApiModels = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Rental Agreement Base Mapper
    /// </summary>
    public static class RentalAgreementBaseMapper
    {
       #region Base Response Mapper

        /// <summary>
        ///  Rental Agreement Base Response Mapper
        /// </summary>
        public static ApiModels.RentalAgreementBaseDataResponse CreateFrom(this RentalAgreementBaseDataResponse source)
        {
            return new ApiModels.RentalAgreementBaseDataResponse
            {
                PaymentTerms = source.PaymentTerms.Select(pt => pt.CreateFrom()),
                Operations = source.Operations.Select(op => op.CreateFrom()),
                OperationsWorkPlaces = source.OperationsWorkPlaces.Select(op => op.CreateFrom())
            };
        }

        #endregion
    }
}
