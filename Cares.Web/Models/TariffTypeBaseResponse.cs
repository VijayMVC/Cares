using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// tariff Type Base Response Web Models
    /// </summary>
    public class TariffTypeBaseResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TariffTypeBaseResponse()
        {
            ResponseCompanies = new List<CompanyDropDown>();
            ResponseMeasurementUnits = new List<MeasurementUnitDropDown>();
            ResponseDepartments = new List<DepartmentDropDown>();
            ResponseOperations = new List<OperationDropDown>();
            ResponsePricingStrategies = new List<PricingStrategyDropDown>();
        }
        #endregion
        #region Public
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<CompanyDropDown> ResponseCompanies { get; set; }
        /// <summary>
        /// Measurement Unit 
        /// </summary>
        public IEnumerable<MeasurementUnitDropDown> ResponseMeasurementUnits { get; set; }
        /// <summary>
        /// Departments 
        /// </summary>
        public IEnumerable<DepartmentDropDown> ResponseDepartments { get; set; }
        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<OperationDropDown> ResponseOperations { get; set; }
        /// <summary>
        /// Pricing Strategies
        /// </summary>
        public IEnumerable<PricingStrategyDropDown> ResponsePricingStrategies { get; set; }
        #endregion
    }
}