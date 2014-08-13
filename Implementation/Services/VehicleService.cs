using System;
using System.Globalization;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Vehicle Service
    /// </summary>
    public class VehicleService : IVehicleService
    {
        

        #region Private

        private readonly IVehicleRepository vehicleRepository;

        #endregion

        #region Constructors
        
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleService(IVehicleRepository vehicleRepository)
        {
            if (vehicleRepository == null)
            {
                throw new ArgumentNullException("vehicleRepository");
            }

            this.vehicleRepository = vehicleRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Get By Hire Group
        /// </summary>
        public GetVehicleResponse GetByHireGroup(VehicleSearchRequest request)
        {
            return vehicleRepository.GetByHireGroup(request);
        }

        /// <summary>
        /// Get Vehicle By Id
        /// </summary>
        public Vehicle GetById(long vehicleId)
        {
            Vehicle vehicle = vehicleRepository.Find(vehicleId);
            if (vehicle == null)
            {
                throw new ApplicationException(string.Format(CultureInfo.InvariantCulture, "Vehicle with Id {0} not found!", vehicleId));
            }

            return vehicleRepository.Find(vehicleId);
        }

        #endregion

    }
}
