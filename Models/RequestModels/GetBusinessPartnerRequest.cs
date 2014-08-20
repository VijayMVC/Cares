using Cares.Models.Common;
using Cares.Models.CommonTypes;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Business Partner Request Model
    /// </summary>
    public class GetBusinessPartnerRequest
    {
        /// <summary>
        /// Filter Option (Individual/Company), 1 for Individual , 2 for Company
        /// </summary>
        public bool? SelectOption { get; set; }

        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long? BusinessPartnerId { get; set; }

        /// <summary>
        /// License No
        /// </summary>
        public string LicenseNo { get; set; }

        /// <summary>
        /// Passport No
        /// </summary>
        public string PassportNo { get; set; }

        /// <summary>
        /// Nic No
        /// </summary>
        public string NicNo { get; set; }

        /// <summary>
        /// Phone No
        /// </summary>
        public string PhoneNo { get; set; }

        /// <summary>
        /// Phone Type
        /// </summary>
        public int? PhoneType { get; set; }

        /// <summary>
        /// Phone Type
        /// </summary>
        public PhoneType? PhoneTypeOrig
        {
            get
            {
                return (PhoneType?) PhoneType;
            }
            set
            {
                PhoneType = (int?)value;
            }
        }
        
    }
}
