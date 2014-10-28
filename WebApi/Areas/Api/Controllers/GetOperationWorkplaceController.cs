using System.Collections.Generic;
using System.Web.Http;

namespace Cares.WebApi.Areas.Api.Controllers
{
    /// <summary>
    /// Get Operation Workplace
    /// </summary>
    [Authorize]
    public class GetOperationWorkplaceController : ApiController
    {
        [HttpGet]
        public List<string> Get()
        {
            return new List<string>{ "a", "b", "c" };
        } 
    }
}