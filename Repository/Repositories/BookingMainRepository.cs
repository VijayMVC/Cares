using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Booking Main Repository
    /// </summary>
    public sealed class BookingMainRepository : BaseRepository<BookingMain>, IBookingMainRepository
    {
        #region Private
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BookingMainRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BookingMain> DbSet
        {
            get
            {
                return db.BookingMains;
            }
        }

        #endregion

        #region Public
        #endregion
    }
}
