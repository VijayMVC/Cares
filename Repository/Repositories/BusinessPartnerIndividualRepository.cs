using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Business Partner Individual Repository
    /// </summary>
    public sealed class BusinessPartnerIndividaulRepository : BaseRepository<BusinessPartnerIndividual>, IBusinessPartnerIndividualRepository
    {
        #region Private
        ///// <summary>
        ///// Order by Column Names Dictionary statements - for Product
        ///// </summary>
        //private readonly Dictionary<BusinessPartnerByColumn, Func<BusinessPartner, object>> businessPartnerClause =
        //      new Dictionary<BusinessPartnerByColumn, Func<BusinessPartner, object>>
        //            {
        //                {BusinessPartnerByColumn.BusinessPartnerId, c => c.BusinessPartnerId},
        //                {BusinessPartnerByColumn.BusinessPartnerName, c => c.BusinessPartnerName},
        //                {BusinessPartnerByColumn.IsIndividual, c => c.IsIndividual},
        //                {BusinessPartnerByColumn.CompanyName, c => c.Company.CompanyName},
        //                {BusinessPartnerByColumn.BPRatingTypeName, c => c.BPRatingType.BpRatingTypeName}
        //            };
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerIndividaulRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerIndividual> DbSet
        {
            get
            {
                return db.BusinessPartnerIndividuals;
            }
        }

        #endregion

        #region Public
        ///// <summary>
        ///// Get All Business Partners for User Domain Key
        ///// </summary>
        //public BusinessPartnerResponse GetAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest)
        //{
        //    int fromRow = (businessPartnerSearchRequest.PageNo - 1) * businessPartnerSearchRequest.PageSize;
        //    int toRow = businessPartnerSearchRequest.PageSize;

        //    Expression<Func<BusinessPartner, bool>> query =
        //        s =>( (!(businessPartnerSearchRequest.SelectOption.HasValue) || s.IsIndividual == businessPartnerSearchRequest.SelectOption) && 
        //            (string.IsNullOrEmpty(businessPartnerSearchRequest.SearchString) || s.BusinessPartnerName.Contains(businessPartnerSearchRequest.SearchString)));

        //    IEnumerable<BusinessPartner> businesspartners = businessPartnerSearchRequest.IsAsc ? DbSet.Where(query)
        //                                    .OrderBy(businessPartnerClause[businessPartnerSearchRequest.BusinessPartnerOrderBy]).Skip(fromRow).Take(toRow).ToList()
        //                                    : DbSet.Where(query)
        //                                        .OrderByDescending(businessPartnerClause[businessPartnerSearchRequest.BusinessPartnerOrderBy]).Skip(fromRow).Take(toRow).ToList();

        //    return new BusinessPartnerResponse { BusinessPartners = businesspartners, TotalCount = DbSet.Count(query) };
        //}
        /// <summary>
        /// Get business partner by firstname and id
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartnerIndividual GetBusinessPartnerIndividualByName(string firstname, int id)
        {
            return DbSet.FirstOrDefault(businessPartnerIndividual => businessPartnerIndividual.FirstName == firstname && businessPartnerIndividual.BusinessPartnerId == id);
        }
        /// <summary>
        /// Get All Business Partner Individuals for User Domain Key
        /// </summary>
        public override IEnumerable<BusinessPartnerIndividual> GetAll()
        {
            return DbSet.Where(businessPartnerIndividual => businessPartnerIndividual.UserDomainKey == UserDomainKey).ToList();
        }
        /// <summary>
        /// Get Business Partner Individual by Id
        /// </summary>
        public BusinessPartnerIndividual GetById(long id)
        {
            return DbSet.FirstOrDefault(businessPartnerIndividual => businessPartnerIndividual.UserDomainKey == UserDomainKey && businessPartnerIndividual.BusinessPartnerId == id);
        }
        #endregion





       
    }
}
