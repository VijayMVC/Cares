using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Non Revenue Ticket Service Interface
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public interface INRTService
    {
        /// <summary>
        /// Load Non Revenue Ticket Base data
        /// </summary>
        NRTBaseResponse GetBaseData();
    }
}
