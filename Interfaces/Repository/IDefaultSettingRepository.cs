using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Default Setting Repository Interface
    /// </summary>
    public interface IDefaultSettingRepository : IBaseRepository<DefaultSetting, long>
    {
        /// <summary>
        /// Get Default Settings For Current Logged In Employee
        /// </summary>
        DefaultSetting GetForEmployee(long employeeId);
    }
}
