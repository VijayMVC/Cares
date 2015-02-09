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
    /// Transmission Type Repository
    /// </summary>
    public sealed class TransmissionTypeRepository: BaseRepository<TransmissionType>, ITransmissionTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Transmission Type Repository Constructor
        /// </summary>
        public TransmissionTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<TransmissionType> DbSet
        {
            get
            {
                return db.TransmissionTypes;
            }
        }

        #endregion
        
        #region Public
        /// <summary>
        /// Get All Transmission Type for User Domain Key
        /// </summary>
        public override IEnumerable<TransmissionType> GetAll()
        {
            return DbSet.ToList();
        }
        #endregion
    }
}
