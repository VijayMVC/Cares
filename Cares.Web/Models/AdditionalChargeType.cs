using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Additional Charge Type Web Model
    /// </summary>
    public class AdditionalChargeType
    {
        /// <summary>
        /// Additional Charge Type ID
        /// </summary>
        public short AdditionalChargeTypeId { get; set; }

        /// <summary>
        /// Additional Charge Type Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Additional Charge Type Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Additional Charge Type Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Is Editable
        /// </summary>
        public bool IsEditable { get; set; }

        /// <summary>
        /// Additional Charges
        /// </summary>
        public List<AdditionalCharge> AdditionalCharges { get; set; }
    }
}