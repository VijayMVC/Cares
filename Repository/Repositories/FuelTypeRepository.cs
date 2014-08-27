using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Fuel Type Repository
    /// </summary>
    public sealed class FuelTypeRepository : BaseRepository<FuelType>, IFuelTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Fuel Type Repository Constructor
        /// </summary>
        public FuelTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<FuelType> DbSet
        {
            get
            {
                return db.FuelTypes;
            }
        }

        #endregion
        
        #region Public
        /// <summary>
        /// Get All Fuel Types for User Domain Key
        /// </summary>
        public override IEnumerable<FuelType> GetAll()
        {
            return DbSet.Where(ft => ft.UserDomainKey == UserDomainKey).ToList();
        }


        #endregion
    }
}
