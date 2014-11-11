using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Default Setting Mapper
    /// </summary>
    public static class DefaultSettingMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DefaultSetting CreateFrom(this DomainModels.DefaultSetting source)
        {
            if (source == null)
            {
                return null;
            }
            
            return new DefaultSetting
            {
                DefaultSettingId = source.DefaultSettingId,
                EmployeeId = source.EmployeeId,
                DefaultOperationId = source.DefaultOperationId,
                DefaultOperationWorkplaceId = source.DefaultOperationWorkplaceId,
                DefaultPaymentTermId = source.DefaultPaymentTermId
            };
        }

        #endregion
    }
}