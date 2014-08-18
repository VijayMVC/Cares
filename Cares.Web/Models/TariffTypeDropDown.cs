using System.Security.Cryptography.X509Certificates;

namespace Cares.Web.Models
{
    /// <summary>
    /// Tariff Type Drop Down
    /// </summary>
    public sealed class TariffTypeDropDown
    {
        /// <summary>
        /// Tariff Type Id
        /// </summary>
        public long TariffTypeId { get; set; }
        /// <summary>
        /// Tariff Type Code Name
        /// </summary>
        public string TariffTypeCodeName { get; set; }
        /// <summary>
        /// Operation Id
        /// </summary>
        public long OperationId { get; set; }
    }
}