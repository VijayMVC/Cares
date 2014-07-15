
using System.Collections.Generic;
using Models.DomainModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Measurement Unit Service Interface
    /// </summary>
    public interface IMeasurementUnitService
    {
        IEnumerable<MeasurementUnit> LoadAll();
    }
}
