using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Measurement Unit Service Interface
    /// </summary>
    public interface IMeasurementUnitService
    {
        IEnumerable<MeasurementUnit> LoadAll();
    }
}
