using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Chauffer Charge Base Web Response
    /// </summary>
    public class ChaufferChargeBaseResponse
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ChaufferChargeBaseResponse()
        {
            Companies = new List<CompanyDropDown>();
            Departments = new List<DepartmentDropDown>();
            Operations = new List<OperationDropDown>();
            TariffTypes = new List<TariffTypeDropDown>();
            DesigGrades = new List<DesigGradeDropDown>();
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
        /// Tariff Types
        /// </summary>
        public IEnumerable<TariffTypeDropDown> TariffTypes { get; set; }

        /// <summary>
        /// Desig Grades
        /// </summary>
        public IEnumerable<DesigGradeDropDown> DesigGrades { get; set; }

        #endregion
    }
}