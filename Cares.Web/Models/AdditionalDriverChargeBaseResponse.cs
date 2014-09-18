using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Additional Driver Base Web Response
    /// </summary>
    public class AdditionalDriverChargeBaseResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalDriverChargeBaseResponse()
        {
            Operations = new List<OperationDropDown>();
            TariffTypes = new List<TariffTypeDropDown>();
            Companies = new List<CompanyDropDown>();
            Departments = new List<DepartmentDropDown>();
        }
        #endregion

        #region Public
        
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<CompanyDropDown> Companies { get; set; }

        /// <summary>
        /// Departments
        /// </summary>
        public IEnumerable<DepartmentDropDown> Departments { get; set; }
        
        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<OperationDropDown> Operations { get; set; }
        
        /// <summary>
        /// Tariff types
        /// </summary>
        public IEnumerable<TariffTypeDropDown> TariffTypes { get; set; }

        #endregion
    }
}