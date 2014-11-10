using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Default Setting Repository
    /// </summary>
    public sealed class DefaultSettingRepository : BaseRepository<DefaultSetting>, IDefaultSettingRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DefaultSettingRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<DefaultSetting> DbSet
        {
            get
            {
                return db.DefaultSettings;
            }
        }
        #endregion
       
        #region Public
        
        #endregion

        /// <summary>
        /// Get Default Settings For Current Logged In Employee
        /// </summary>
        public DefaultSetting GetForEmployee(long employeeId)
        {
            return DbSet.FirstOrDefault(ds => ds.EmployeeId == employeeId);
        }
    }
}
