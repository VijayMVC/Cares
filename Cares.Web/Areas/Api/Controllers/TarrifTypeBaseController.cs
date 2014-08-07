﻿using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Tarrif Type Base Api Controller
    /// </summary>
    public class TarrifTypeBaseController : ApiController
    {
        #region Private
        private readonly ITarrifTypeService tarrifTypeService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TarrifTypeBaseController(ITarrifTypeService tarrifTypeService)
        {
            if (tarrifTypeService == null) throw new ArgumentNullException("tarrifTypeService");
            this.tarrifTypeService = tarrifTypeService;
        }

        #endregion
        #region Public
        // GET api/<controller>
        public TarrifTypeBaseResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return tarrifTypeService.GetBaseData().CreateFrom();
        }
        #endregion
    }
}