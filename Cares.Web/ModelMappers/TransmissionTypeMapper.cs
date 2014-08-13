using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Transmission Type Mapper
    /// </summary>
    public static class TransmissionTypeMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static TransmissionType CreateFrom(this Cares.Models.DomainModels.TransmissionType source)
        {
            return new TransmissionType
            {
                TransmissionTypeId = source.TransmissionTypeId,
                TransmissionTypeName = source.TransmissionTypeName,
                TransmissionTypeCode = source.TransmissionTypeCode
            };
        }

        #endregion
    }
}