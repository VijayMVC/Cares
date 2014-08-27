namespace Cares.Web.Models
{
    /// <summary>
    /// Insurance Type Drop Down
    /// </summary>
    public sealed class InsuranceTypeDropDown
    {
        /// <summary>
        ///Insurance Type Id
        /// </summary>
        public short InsuranceTypeId { get; set; }
        
        /// <summary>
        /// Insurance Type Code Name
        /// </summary>
        public string InsuranceTypeCodeName { get; set; }
    }
}