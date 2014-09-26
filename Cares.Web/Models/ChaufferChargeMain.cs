using System;
using System.Collections;
using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Chauffer Charge Main Web Model
    /// </summary>
    public class ChaufferChargeMain
    {
        /// <summary>
        /// Chauffer Charge Main ID
        /// </summary>
        public long ChaufferChargeMainId { get; set; }

        /// <summary>
        /// Chauffer Charge Main Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Chauffer Charge Main Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Chauffer Charge Main Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Company Id
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// Department Id
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// Operation Id
        /// </summary>
        public long OperationId { get; set; }

        /// <summary>
        /// Tariff Type Id
        /// </summary>
        public long TariffTypeId { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Chauffer Charge List
        /// </summary>
        public IEnumerable<ChaufferCharge> ChaufferCharges { get; set; }

    }
}