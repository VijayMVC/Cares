using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Tarrif Type Base Response Web Models
    /// </summary>
    public class TarrifTypeBaseResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TarrifTypeBaseResponse()
        {
            ResponseCompanies = new List<Company>();
            ResponseMeasurementUnits = new List<MeasurementUnit>();
            ResponseDepartments = new List<Department>();
            ResponseOperations = new List<Operation>();
            ResponsePricingStrategies = new List<PricingStrategy>();
        }
        #endregion
        #region Public
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<Company> ResponseCompanies { get; set; }
        /// <summary>
        /// Measurement Unit 
        /// </summary>
        public IEnumerable<MeasurementUnit> ResponseMeasurementUnits { get; set; }
        /// <summary>
        /// Departments 
        /// </summary>
        public IEnumerable<Department> ResponseDepartments { get; set; }
        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<Operation> ResponseOperations { get; set; }
        /// <summary>
        /// List of Tarriff Types
        /// </summary>
        public IEnumerable<PricingStrategy> ResponsePricingStrategies { get; set; }
        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}