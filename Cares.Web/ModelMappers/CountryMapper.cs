using ApiModel = Cares.Web.Models;
using DomainModel = Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Country Mapper
    /// </summary>
    public static class CountryMapper
    {
        #region Public
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.Country CreateFrom(this DomainModel.Country source)
            {
                return new ApiModel.Country
                {
                    CountryId = source.CountryId,
                    CountryCode = source.CountryCode,
                    CountryName = source.CountryName
                };
            }
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModel.Country CreateFrom(this ApiModel.Country source)
        {
            return new DomainModel.Country
            {
                CountryId = source.CountryId,
                CountryCode = source.CountryCode,
                CountryName = source.CountryName
            };
        }
        
        #endregion
        #endregion
    }
}