using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Seasonal Discount Web Model
    /// </summary>
    public class SeasonalDiscount
    {
        /// <summary>
        /// Seasonal Discount ID
        /// </summary>
        public long SeasonalDiscountId { get; set; }

        /// <summary>
        /// Operations Workplace ID
        /// </summary>
        public long? OperationsWorkPlaceId { get; set; }

        /// <summary>
        /// Operations WorkPlace Code
        /// </summary>
        public string OperationsWorkPlaceCode { get; set; }

        /// <summary>
        /// Vehicle Make ID
        /// </summary>
        public short? VehicleMakeId { get; set; }

        /// <summary>
        /// Operations WorkPlace Code
        /// </summary>
        public string VehicleMakeCodeName { get; set; }

        /// <summary>
        /// BP RatingType ID
        /// </summary>
        public short? RatingTypeId { get; set; }

        /// <summary>
        /// Rating Type Code Name
        /// </summary>
        public string RatingTypeCodeName { get; set; }

        /// <summary>
        /// Vehicle Category ID
        /// </summary>
        public short? VehicleCategoryId { get; set; }

        /// <summary>
        /// Vehicle Category Code Name
        /// </summary>
        public string VehicleCategoryCodeName { get; set; }

        /// <summary>
        /// Vehicle Model ID
        /// </summary>
        public short? VehicleModelId { get; set; }

        /// <summary>
        /// Vehicle Model Code Name
        /// </summary>
        public string VehicleModelCodeName { get; set; }

        /// <summary>
        /// Hire Group ID
        /// </summary>
        public long? HireGroupId { get; set; }

        /// <summary>
        /// Hire Group Code Name
        /// </summary>
        public string HireGroupCodeName { get; set; }

        /// <summary>
        /// Customer Type
        /// </summary>
        public short CustomerType { get; set; }

        /// <summary>
        /// Customer Type Code Name
        /// </summary>
        private string customerTypeCodeName;

        /// <summary>
        /// Customer Type Code Name
        /// </summary>
        public string CustomerTypeCodeName
        {
            get
            {
                if (CustomerType == 1)
                {
                    customerTypeCodeName = "Individual";
                }
                else if (CustomerType == 2)
                {
                    customerTypeCodeName = "Corporate";
                }
                else
                {
                    customerTypeCodeName = "Both";
                }
                return customerTypeCodeName;
            }
        }

        /// <summary>
        /// Model Year
        /// </summary>
        public short? ModelYear { get; set; }

        /// <summary>
        /// Discount Perc
        /// </summary>
        public double DiscountPerc { get; set; }

        /// <summary>
        /// Seasonal Discount Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

        /// <summary>
        /// Seasonal Discount End Date
        /// </summary>
        public DateTime EndDt { get; set; }

        /// <summary>
        /// Revision Number
        /// </summary>
        public long? RevisionNumber { get; set; }
    }
}