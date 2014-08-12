using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Company Mapper
    /// </summary>
    public static class CompanyMapper
    {
        #region Public
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static CompanyDropDown CreateFrom(this DomainModels.Company source)
        {
            return new CompanyDropDown
            {
                CompanyId = source.CompanyId,
                CompanyCodeName = source.CompanyCode+" - " +source.CompanyName,
            };
        }
        #endregion
    }
}