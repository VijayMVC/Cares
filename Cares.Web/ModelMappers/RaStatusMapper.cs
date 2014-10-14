using Cares.Web.Models;
using DomainModels=Cares.Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Ra Status Mapper
    /// </summary>
    public static class RaStatusMapper
    {
        #region
        /// <summary>
        ///  Create web api model from domail model
        /// </summary>
        public static RaStatusDropDown CreateFrom(this DomainModels.RaStatus source)
        {
            return new RaStatusDropDown
            {
                RaStatusId = source.RaStatusId,
                RaStatusCodeName = source.RaStatusCode + "-" + source.RaStatusName
            };
        }
        #endregion
    }
}