using System;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Address Base Controller
    /// </summary>
    public class AddressBaseController : ApiController
    {
        #region Private
        private readonly IAddressBaseDataService addressBaseDataService;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AddressBaseController(IAddressBaseDataService addressBaseDataService)
        {
            if (addressBaseDataService == null)
            {
                throw new ArgumentNullException("addressBaseDataService");
            }
            this.addressBaseDataService = addressBaseDataService;
        }
        #endregion

        #region Public
         /// <summary>
         /// Get Address Base Data by Country
         /// </summary>
        public AddressBaseResponse Get(int id)
         {
             return addressBaseDataService.LoadDataByCountry(id).CreateFrom();
        }
        #endregion
    }
}