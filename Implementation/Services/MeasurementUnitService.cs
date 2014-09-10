using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Measurement Unit Service
    /// </summary>
    public class MeasurementUnitService : IMeasurementUnitService
    {
        private readonly IMeasurementUnit measurementUnitRepo;

        #region Constructor
       
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="measurementUnitRepo"></param>
        public MeasurementUnitService(IMeasurementUnit measurementUnitRepo)
        {
            this.measurementUnitRepo = measurementUnitRepo;
        }
        #endregion

        #region Public
        /// <summary>
        /// Get All Measurement
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MeasurementUnit> LoadAll()
        {
            return measurementUnitRepo.GetAll();
        }
        #endregion
    }
}
