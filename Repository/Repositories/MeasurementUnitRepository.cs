using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Measurement Unit Repository
    /// </summary>
    public sealed class MeasurementUnitRepository : BaseRepository<MeasurementUnit>, IMeasurementUnit
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MeasurementUnitRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<MeasurementUnit> DbSet
        {
            get
            {
                return db.MeasurementUnits;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Measurement Units for User Domain Key
        /// </summary>
        public override IQueryable<MeasurementUnit> GetAll()
        {
            return DbSet.Where(measurementUnit => measurementUnit.UserDomainKey == UserDomainKey);
        }
        #endregion
    }
}
