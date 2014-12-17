
using Cares.Models.IdentityModels;
using System;

namespace Cares.Models.Common
{
    public class ClaimParamters
    {
        public Int16 LicenseTypeId { get; set; }
        public Int16 RaPerMonth { get; set; }
        public Int16 Employee { get; set; }
        public Int16 Branches { get; set; }
        public Int16 FleetPools { get; set; }
        public Int16 Vehicles { get; set; }
        public double UserDomainKey { get; set; }
        public User CaresUser { get; set; }
    }
}
