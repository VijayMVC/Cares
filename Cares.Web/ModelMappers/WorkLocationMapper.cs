using Cares.Web.Models;
using System.Linq;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Work Location Mapper
    /// </summary>
    public static class WorkLocationMapper
    {
        #region Public
        /// <summary>
        /// Mapper from domain model to web model dropdown
        /// </summary>
        public static WorkLocationDropDown CreateFrom(this Cares.Models.DomainModels.WorkLocation source)
        {
            return new WorkLocationDropDown
            {
                CompanyId = source.CompanyId,
                WorkLocationId = source.WorkLocationId,
                WorkLocationCodeName = source.WorkLocationCode + " - " + source.WorkLocationName
            };
        }

        /// <summary>
        /// Create from base data domain model to base data web model
        /// </summary> 
        public static WorkLocationBaseDataResponse CreateFrom(this Cares.Models.ResponseModels.WorkLocationBaseDataResponse source)
        {
            return new WorkLocationBaseDataResponse
            {
                Companies = source.Companies.Select(company => company.CreateFrom()),
                Countries = source.Countries.Select(country => country.CreateFrom()),
                Regions = source.Regions.Select(region => region.CreateDropdownFrom()),
                SubRegions = source.SubRegions.Select(subRegion => subRegion.CreateDropdownFrom()),
                Cities = source.Cities.Select(city => city.CreateDropdownFrom()),
                Areas = source.Areas.Select(area => area.CreateFrom()),
                PhoneTypes = source.PhoneTypes.Select(phoneType => phoneType.CreateFrom())
            };
        }

        /// <summary>
        /// Create From domain Response model to web Response model 
        /// </summary>
        public static WorkLocationSerachRequestResponse CreateFrom(this Cares.Models.ResponseModels.WorkLocationSerachRequestResponse source)
        {
            return new WorkLocationSerachRequestResponse
            {
                WorkLocations = source.WorkLocations.Select(workLocation => workLocation.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Create From Domain model
        /// </summary>
        public static WorkLocation CreateFromm(this Cares.Models.DomainModels.WorkLocation source)
        {
            return new WorkLocation
            {
                WorkLocationCode = source.WorkLocationCode,
                WorkLocationId = source.WorkLocationId,
                WorkLocationName = source.WorkLocationName,
                WorkLocationDescription = source.WorkLocationDescription,
                CompanyId = source.CompanyId,
                CompanyName = source.Company.CompanyName,
                Address = source.Address.CreateFrom(),
                Phones = source.Phones != null ? source.Phones.Select(phone => phone.CreateFrom()).ToList() : null,
            };
        }

        /// <summary>
        /// Create From web model
        /// </summary>
        public static Cares.Models.DomainModels.WorkLocation CreateFrom(this WorkLocation source)
        {
            return new Cares.Models.DomainModels.WorkLocation
            {
                WorkLocationCode = source.WorkLocationCode.Trim(),
                WorkLocationId = source.WorkLocationId,
                WorkLocationName = source.WorkLocationName,
                WorkLocationDescription = source.WorkLocationDescription,
                CompanyId = source.CompanyId,
                Address = source.Address.CreateFrom(),
                Phones = source.Phones != null ? source.Phones.Select(phone => phone.CreateFrom()).ToList() : null,
            };
        } 
        #endregion
    }
}