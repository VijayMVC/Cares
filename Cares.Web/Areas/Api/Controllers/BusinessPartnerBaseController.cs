using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Business Partner Base Controller
    /// </summary>
    public class BusinessPartnerBaseController : ApiController
    {
        #region Private
        private readonly ICompanyService companyService;
        private readonly IPaymentTermService paymentTermService;
        private readonly IBPRatingTypeService bPRatingTypeService;
        private readonly IBusinessLegalStatusService businessLegalStatusService;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerBaseController(ICompanyService companyService, IPaymentTermService paymentTermService, IBPRatingTypeService bPRatingTypeService, IBusinessLegalStatusService businessLegalStatusService)
        {
            if (companyService == null)
            {
                throw new ArgumentNullException("companyService");
            }
            if (paymentTermService == null)
            {
                throw new ArgumentNullException("paymentTermService");
            }
            if (bPRatingTypeService == null)
            {
                throw new ArgumentNullException("bPRatingTypeService");
            }
            if (businessLegalStatusService == null)
            {
                throw new ArgumentNullException("businessLegalStatusService");
            }
            this.companyService = companyService;
            this.paymentTermService = paymentTermService;
            this.bPRatingTypeService = bPRatingTypeService;
            this.businessLegalStatusService = businessLegalStatusService;
        }
        #endregion

        #region Public
        /// <summary>
        /// Get Base Data
        /// </summary>
        public BusinessPartnerBaseResponse Get()
        {
            BusinessPartnerBaseResponse response = new BusinessPartnerBaseResponse()
                                                   {
                                                       ResponseCompanies = companyService.LoadAll().AsEnumerable().Select(c => c.CreateFrom()),
                                                       ResponsePaymentTerms = paymentTermService.LoadAll().AsEnumerable().Select(c => c.CreateFrom()),
                                                       ResponseBPRatingTypes = bPRatingTypeService.LoadAll().AsEnumerable().Select(c => c.CreateFrom()),
                                                       ResponseBusinessLegalStatuses = businessLegalStatusService.LoadAll().AsEnumerable().Select(c=>c.CreateFrom())
                                                   };
            return response;
        }
        #endregion
    }
}