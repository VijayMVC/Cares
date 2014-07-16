

using Cares.Web.Models;

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
        public static Company CreateFrom(this global::Models.DomainModels.Company source)
        {
            return new Company
            {
                CompanyId = source.CompanyId,
                CompanyName = source.CompanyName,
            };
        }
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static global::Models.DomainModels.Company CreateFrom(this Company source)
        {
            if (source != null)
            {
                return new global::Models.DomainModels.Company
                {
                    CompanyId = source.CompanyId,
                    CompanyName = source.CompanyName,
                };
            }
            return new global::Models.DomainModels.Company();
        }
        #endregion
    }
}