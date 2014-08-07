using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    public class MeasurementUnitService:IMeasurementUnitService
    {
        private readonly IMeasurementUnit measurementUnitRepo;

        public MeasurementUnitService(IMeasurementUnit measurementUnitRepo)
        {
            this.measurementUnitRepo = measurementUnitRepo;
        }

        public IEnumerable<MeasurementUnit> LoadAll()
        {
            return measurementUnitRepo.GetAll();
        }
    }
}
