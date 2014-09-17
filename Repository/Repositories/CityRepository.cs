using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// City Repository
    /// </summary>
    public sealed class CityRepository : BaseRepository<City>, ICityRepository
    {
        #region privte
        /// <summary>
        /// City Orderby clause for sorting 
        /// </summary>
        private readonly Dictionary<CityByColumn, Func<City, object>> cityOrderByClause = new Dictionary<CityByColumn, Func<City, object>>
                    {
                        {CityByColumn.Code, d => d.CityCode},
                        {CityByColumn.Name, c => c.CityName},
                        {CityByColumn.Description, d => d.CityDescription},
                        {CityByColumn.Country, d => d.Country.CountryId},
                        {CityByColumn.Region, d => d.Region.RegionId},
                        {CityByColumn.SubRegion, d => d.SubRegion.SubRegionId},
                        
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CityRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<City> DbSet
        {
            get
            {
                return db.Cities;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Cities for User Domain Key
        /// </summary>
        public override IEnumerable<City> GetAll()
        {
            return DbSet.Where(city => city.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Find City By Id
        /// </summary>
        public City Find(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Get Cities By Country
        /// </summary>
        public IQueryable<City> GetCitiesByCountry(int countryId)
        {
            return DbSet.Where(city => city.UserDomainKey == UserDomainKey && city.CountryId == countryId);
        }

        /// <summary>
        /// Check if region is asssociated with any city
        /// </summary>
        public bool IsRegionAssociatedWithCity(long regionId)
        {
            return DbSet.Count(city => city.UserDomainKey == UserDomainKey && city.RegionId == regionId)>0;
        }

        /// <summary>
        /// Check if sub region is asssociated with any city
        /// </summary>
        public bool IsSubRegionAssociatedWithCity(long subRegionId)
        {
            return DbSet.Count(city => city.UserDomainKey == UserDomainKey && city.SubRegionId == subRegionId) > 0;
        }

        /// <summary>
        /// Search City
        /// </summary>
        public IEnumerable<City> SearchCity(CitySearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<City, bool>> query =
                city =>
                    (string.IsNullOrEmpty(request.CityFilterText) ||
                     (city.CityCode.Contains(request.CityFilterText)) ||
                     (city.CityName.Contains(request.CityFilterText))) && (
                         (!request.CountryId.HasValue || request.CountryId == city.CountryId));

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(cityOrderByClause[request.CityOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(cityOrderByClause[request.CityOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// City Code duplication check 
        /// </summary>
        public bool DoesCityCodeExists(City city)
        {
            return DbSet.Count(dbcity => dbcity.CityCode == city.CityCode && dbcity.CityId != city.CityId) > 0;
        }


        /// <summary>
        /// Get City with detail
        /// </summary>
        public City LoadCityWithDetail(long cityId)
        {
            return DbSet.Include(city => city.Country)
                .Include(city => city.Region)
                .Include(city => city.SubRegion)
               .FirstOrDefault(dbCity => dbCity.UserDomainKey == UserDomainKey && dbCity.CityId == cityId);
        }
        #endregion
    }
}
