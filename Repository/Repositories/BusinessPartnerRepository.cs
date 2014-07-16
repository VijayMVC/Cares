﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.Common;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Business Partner Repository
    /// </summary>
    public sealed class BusinessPartnerRepository : BaseRepository<BusinessPartner>, IBusinessPartnerRepository
    {
        #region Private
        /// <summary>
        /// Order by Column Names Dictionary statements - for Product
        /// </summary>
        private readonly Dictionary<BusinessPartnerByColumn, Func<BusinessPartner, object>> businessPartnerClause =
              new Dictionary<BusinessPartnerByColumn, Func<BusinessPartner, object>>
                    {
                        {BusinessPartnerByColumn.BusinessPartnerId, c => c.BusinessPartnerId},
                        {BusinessPartnerByColumn.BusinessPartnerName, c => c.BusinessPartnerName},
                        {BusinessPartnerByColumn.IsIndividual, c => c.IsIndividual},
                        {BusinessPartnerByColumn.CompanyName, c => c.Company.CompanyName},
                        {BusinessPartnerByColumn.BPRatingTypeName, c => c.BPRatingType.BpRatingTypeName}
                    };
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartner> DbSet
        {
            get
            {
                return db.BusinessPartners;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Business Partners for User Domain Key
        /// </summary>
        public BusinessPartnerResponse GetAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest)
        {
            int fromRow = (businessPartnerSearchRequest.PageNo - 1) * businessPartnerSearchRequest.PageSize;
            int toRow = businessPartnerSearchRequest.PageSize;

            Expression<Func<BusinessPartner, bool>> query =
                s =>( (!(businessPartnerSearchRequest.SelectOption.HasValue) || s.IsIndividual == businessPartnerSearchRequest.SelectOption) && 
                    (string.IsNullOrEmpty(businessPartnerSearchRequest.SearchString) || s.BusinessPartnerName.Contains(businessPartnerSearchRequest.SearchString)));

            IEnumerable<BusinessPartner> businesspartners = businessPartnerSearchRequest.IsAsc ? DbSet.Where(query)
                                            .OrderBy(businessPartnerClause[businessPartnerSearchRequest.BusinessPartnerOrderBy]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                                .OrderByDescending(businessPartnerClause[businessPartnerSearchRequest.BusinessPartnerOrderBy]).Skip(fromRow).Take(toRow).ToList();

            return new BusinessPartnerResponse { BusinessPartners = businesspartners, TotalCount = DbSet.Count(query) };
        }

        #endregion

    }
}
