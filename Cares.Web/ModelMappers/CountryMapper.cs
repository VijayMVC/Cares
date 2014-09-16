using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Cares.Models.DomainModels;

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
        ///  Create  dropdown web model from entity
        /// </summary>
        public static ApiModel.CountryDropDown CreateFrom(this Country source)
        {
            return new ApiModel.CountryDropDown
            {
                CountryId = source.CountryId,
                CountryCodeName = source.CountryCode + " - " + source.CountryName,
            };
        }


        /// <summary>
        ///  Create   web model from entity
        /// </summary>
        public static ApiModel.Country CreateFromm(this Country source)
        {
            return new ApiModel.Country
            {
                CountryId = source.CountryId,
                CountryCode = source.CountryCode,
                CountryName = source.CountryName,
                CountryDescription = source.CountryDescription
            };
        }
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static Country CreateFrom(this ApiModel.CountryDropDown source)
        {
            return new Country
            {
                CountryId = source.CountryId,
                CountryName = source.CountryCodeName
            };
        }

        #endregion
        #endregion
    }
}