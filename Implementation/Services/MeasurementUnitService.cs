using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;
using Repository.Repositories;

namespace Implementation.Services
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
