using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using DesignGradeSearchRequestResponse = Cares.Web.Models.DesignGradeSearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    ///  Design Grade Controller
    /// </summary>
    [Authorize]
    public class DesignGradeController : ApiController
    {
       #region Private
       private readonly IDesignGradeService designGradeService;
       #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
       public DesignGradeController(IDesignGradeService designGradeService)
        {
            if (designGradeService == null)
            {
                throw new ArgumentNullException("designGradeService");
            }
            this.designGradeService = designGradeService;
        }

        #endregion
       #region Public

        /// <summary>
       /// Get Design Grades
        /// </summary>
       public DesignGradeSearchRequestResponse Get([FromUri] DesignGradeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return designGradeService.SearchDesignGrade(request).CreateFrom();
        }

        /// <summary>
       /// Delete Design Grade 
        /// </summary>
        [ApiException]
       public Boolean Delete(DesignGrade designGrade)
        {
            if (designGrade == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            designGradeService.DeleteDesignGrade(designGrade.DesigGradeId);
            return true;
        }

        /// <summary>
        ///  ADD / Update Design Grade
        /// </summary>
        [ApiException]
        public DesignGrade Post(DesignGrade designGrade)
        {
            if (designGrade == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return designGradeService.SaveDesignGrade(designGrade.CreateFrom()).CreateDesignGradeFrom();
        }

        #endregion
    }
}