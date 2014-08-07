using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Business Partner Controller
    /// </summary>
    public class BusinessPartnerController : ApiController
    {
        #region Private
        /// <summary>
        /// Business Service
        /// </summary>
        private readonly IBusinessPartnerService businessPartnerService;
        #endregion

        #region Public
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerController(IBusinessPartnerService businessPartnerService)
        {
            if (businessPartnerService == null)
            {
                throw new ArgumentNullException("businessPartnerService");    
            }

            this.businessPartnerService = businessPartnerService;
        }
        #endregion

        /// <summary>
        /// Get all Bussiness Partner
        /// </summary>
        public BusinessPartnerResponse Get([FromUri] BusinessPartnerSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return businessPartnerService.LoadAllBusinessPartners(request).CreateFrom();
        }

        /// <summary>
        /// Update a Business Partner
        /// </summary>
        public void Post(BusinessPartnerDetail businessPartner)
        {
            if (businessPartner == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            businessPartnerService.UpdateBusinessPartner(businessPartner.CreateFrom());
        }

        /// <summary>
        /// Adds a Business Partner
        /// </summary>
        public void Put(BusinessPartnerDetail businessPartner)
        {
            if (businessPartner == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            businessPartnerService.AddBusinessPartner(businessPartner.CreateFrom());
        }

        /// <summary>
        /// Delete a Business Partner
        /// </summary>
        public void Delete(BusinessPartnerListView businessPartner)
        {
            if (businessPartner == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            businessPartnerService.DeleteBusinessPartner(businessPartner.CreateFrom());
        }
    }
}