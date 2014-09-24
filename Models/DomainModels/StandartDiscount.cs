using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Standard Discount Domain Model
    /// </summary>
    public class StandardDiscount
    {
        #region Persisted Properties
        
        /// <summary>
        /// Standard Discount ID
        /// </summary>
        public long StandardDiscountId { get; set; }

        /// <summary>
        /// Standard Discount Main ID
        /// </summary>
        public long StandardDiscountMainId { get; set; }

        /// <summary>
        /// Child Standard Discount ID
        /// </summary>
        public long? ChildStandardDiscountId { get; set; }

        /// <summary>
        /// Operations Workplace ID
        /// </summary>
        public long? OperationsWorkPlaceId { get; set; }

        /// <summary>
        /// Vehicle Make ID
        /// </summary>
        public short? VehicleMakeId { get; set; }

        /// <summary>
        /// BP RatingType ID
        /// </summary>
        public short? BpRatingTypeId { get; set; }

        /// <summary>
        /// Vehicle Category ID
        /// </summary>
        public short? VehicleCategoryId { get; set; }

        /// <summary>
        /// Vehicle Model ID
        /// </summary>
        public short? VehicleModelId { get; set; }

        /// <summary>
        /// Hire Group ID
        /// </summary>
        public long? HireGroupId { get; set; }

        /// <summary>
        /// Role ID
        /// </summary>
        public long? RoleId { get; set; }

        /// <summary>
        /// Customer Type
        /// </summary>
        public short CustomerType { get; set; }

        /// <summary>
        /// Model Year
        /// </summary>
        public int? ModelYear { get; set; }

        /// <summary>
        /// Discount Perc
        /// </summary>
        public double DiscountPerc { get; set; }

        /// <summary>
        /// StandardDiscount Start Date
        /// </summary>
        public DateTime StandardDiscountStartDt { get; set; }

        /// <summary>
        /// StandardDiscount End Date
        /// </summary>
        public DateTime StandardDiscountEndDt { get; set; }

        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }
        
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }
        
        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        
        #endregion

        #region Reference Properties

        /// <summary>
        /// Standard Discounts
        /// </summary>
        public virtual StandardDiscountMain StandardDiscountMain { get; set; }

        /// <summary>
        /// Child StandardDiscount
        /// </summary>
        public virtual StandardDiscount ChildStandardDiscount { get; set; }

        /// <summary>
        /// Operations Workplace
        /// </summary>
        public virtual OperationsWorkPlace OperationsWorkPlace { get; set; }

        /// <summary>
        /// Vehicle Make
        /// </summary>
        public virtual VehicleMake VehicleMake { get; set; }

        /// <summary>
        /// Bp Rating Type
        /// </summary>
        public virtual BpRatingType BpRatingType { get; set; }

        /// <summary>
        /// Vehicle Model
        /// </summary>
        public virtual VehicleModel VehicleModel { get; set; }

        /// <summary>
        /// Vehicle Category
        /// </summary>
        public virtual VehicleCategory VehicleCategory { get; set; }

        /// <summary>
        /// Hire Group
        /// </summary>
        public virtual HireGroup HireGroup { get; set; }


        #endregion
    }
}
