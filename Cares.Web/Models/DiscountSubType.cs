
namespace Cares.Web.Models
{
    /// <summary>
    /// Discount Sub Type Web Model
    /// </summary>
    public class DiscountSubType
    {
      
        /// <summary>
        /// Discount Type ID
        /// </summary>
        public short DiscountTypeId { get; set; }

        /// <summary>
        /// Discount Typ eName
        /// </summary>
        public string DiscountTypeName { get; set; }

        /// <summary>
        /// Discount Sub Type ID
        /// </summary>
        public short DiscountSubTypeId { get; set; }

        /// <summary>
        /// Discount Sub Type Code
        /// </summary>
        public string DiscountSubTypeCode { get; set; }

        /// <summary>
        /// Discount Sub Type Name
        /// </summary>
        public string DiscountSubTypeName { get; set; }

        /// <summary>
        /// Discount Sub Type Description
        /// </summary>
        public string DiscountSubTypeDescription { get; set; }
    }
}