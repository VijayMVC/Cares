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
        public static Company CreateFrom(this Cares.Models.DomainModels.Company source)
        {
            return new Company
            {
                CompanyId = source.CompanyId,
                CompanyName = source.CompanyCode+"-" +source.CompanyName,
            };
        }
        #endregion
    }
}