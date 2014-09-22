using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using JobTypeSearchRequestResponse = Cares.Web.Models.JobTypeSearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Job Type Controller
    /// </summary>
    public class JobTypeController : ApiController
    {
        #region Private
        private readonly IJobTypeService jobTypeService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public JobTypeController(IJobTypeService jobTypeService)
        {
            if (jobTypeService == null)
            {
                throw new ArgumentNullException("jobTypeService");
            }
            this.jobTypeService = jobTypeService;
        }

        #endregion
        #region Public

        /// <summary>
        /// Get Job Types
        /// </summary>
        public JobTypeSearchRequestResponse Get([FromUri] JobTypeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return jobTypeService.SearchJobType(request).CreateFrom();
        }

        /// <summary>
        /// Delete Job Type 
        /// </summary>
        [ApiException]
        public Boolean Delete(JobType jobType)
        {
            if (jobType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            jobTypeService.DeleteJobType(jobType.JobTypeId);
            return true;
        }

        /// <summary>
        ///  ADD / Update Job Type
        /// </summary>
        [ApiException]
        public JobType Post(JobType jobType)
        {
            if (jobType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return jobTypeService.SaveJobType(jobType.CreateFrom()).CreateFromm();
        }

        #endregion
    }
}