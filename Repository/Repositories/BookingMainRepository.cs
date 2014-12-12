using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
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
        private readonly Dictionary<BookingMainByColumn, Func<BookingMain, object>> bookingMainClause =
             new Dictionary<BookingMainByColumn, Func<BookingMain, object>>
                    {
                        { BookingMainByColumn.BookingMainId, c => c.BookingMainId },
                        { BookingMainByColumn.StartDate, c => c.StartDtTime },
                        { BookingMainByColumn.EndDate, c => c.EndDtTime },
                        { BookingMainByColumn.OpenLocation, c => c.OpenLocation },
                        { BookingMainByColumn.CloseLocation, c => c.CloseLocation },
                        { BookingMainByColumn.Status, c => c.BookingStatus },
                        { BookingMainByColumn.Operation, c => c.Operation.OperationId },
                    };
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

        public BookingMainResponse LoadMainBookings(BookingMainSearchRequest request)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<BookingMain, bool>> query =
                s => (!request.BookingNumber.HasValue || s.BookingMainId == request.BookingNumber) && (!request.CloseLocationId.HasValue || s.CloseLocation == request.CloseLocationId)
                     && (!request.OpenLocationId.HasValue || s.OpenLocation == request.OpenLocationId) && (!request.StartDate.HasValue || s.StartDtTime == request.StartDate)
                     && (!request.EndDate.HasValue || s.EndDtTime == request.EndDate) && (!request.StatusId.HasValue || s.BookingStatus.BookingStatusId == request.StatusId) &&(s.UserDomainKey==UserDomainKey);

            IEnumerable<BookingMain> bookingMain = request.IsAsc ? DbSet.Where(query)
                                            .OrderBy(bookingMainClause[request.BookingMainOrderBy]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                            .OrderByDescending(bookingMainClause[request.BookingMainOrderBy]).Skip(fromRow).Take(toRow).ToList();

            return new BookingMainResponse { BookingMains = bookingMain, TotalCount = DbSet.Count(query) };
        }
    }
}
