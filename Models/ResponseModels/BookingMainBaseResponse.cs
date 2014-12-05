using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    public sealed class BookingMainBaseResponse
    {
        /// <summary>
        /// Operation Work Places
        /// </summary>
        public IEnumerable<OperationsWorkPlace> OperationWorkPlaces { get; set; }
    }
}
