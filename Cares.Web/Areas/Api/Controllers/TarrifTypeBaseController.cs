using System.Linq;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;


namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Tarrif Type Base Api Controller
    /// </summary>
    public class TarrifTypeBaseController : ApiController
    {
        #region Private
        private readonly IDepartmentService departmentService;
        private readonly ICompanyService companyService;
        private readonly IMeasurementUnitService measurementUnitService;
        private readonly IOperationService operation;
        private readonly ITarrifTypeService tarrifTypeService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TarrifTypeBaseController(IOperationService operation, IDepartmentService departmentService, ICompanyService companyService,
           IMeasurementUnitService measurementUnitService, ITarrifTypeService tarrifTypeService)
        {

            this.operation = operation;
            this.departmentService = departmentService;
            this.companyService = companyService;
            this.measurementUnitService = measurementUnitService;
            this.tarrifTypeService = tarrifTypeService;
        }
        #endregion
        #region Public
        // GET api/<controller>
        public TarrifTypeBaseResponse Get()
        {
            TarrifTypeBaseResponse tarrifTypeBaseResponse = new TarrifTypeBaseResponse()
            {
                ResponseCompanies = companyService.LoadAll().AsEnumerable().Select(c => c.CreateFrom()),
                ResponseMeasurementUnits = measurementUnitService.LoadAll().Select(m => m.CreateFrom()),
                ResponseDepartments = departmentService.LoadAll().Select(d => d.CreateFrom()),
                ResponseOperations = operation.LoadAll().Select(o => o.CreateFrom()),
                ResponseTarrifTypes = tarrifTypeService.LoadAll().Select(t => t.CreateFrom())
            };
            
            return tarrifTypeBaseResponse;
        }
        #endregion
    }
}