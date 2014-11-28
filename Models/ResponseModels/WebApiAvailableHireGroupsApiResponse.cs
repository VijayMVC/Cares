
using System;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Available Hire groups 
    /// </summary>
    public class WebApiAvailableHireGroupsApiResponse
    {
        /// <summary>
        /// vehicle id
        /// </summary>
        public long VehilceId { get; set; }
        /// <summary>
        /// Vehicle number plate
        /// </summary>
        public string NumberPlate { get; set; }
        /// <summary>
        /// Vehicle Make
        /// </summary>
        public string VehicleMakeName { get; set; }
        /// <summary>
        /// Vehicle Model 
        /// </summary>
        public string VehilceModelName { get; set; }
        /// <summary>
        /// Vehicle Category
        /// </summary>
        public string VehicleCategoryName { get; set; }
        /// <summary>
        /// Vehicle model year
        /// </summary>
        public long ModelYear { get; set; }
        /// <summary>
        /// Tariff type code 
        /// </summary>
        public string TariffTypeCode { get; set; }
        /// <summary>
        /// Charge Rate
        /// </summary>
        public double RentalCharge { get; set; }
        /// <summary>
        /// Hire Group name
        /// </summary>
        public string HireGroupName { get; set; }
        /// <summary>
        /// Detail Hire Grouop Id
        /// </summary>
        public long HireGroupDetailId { get; set; }
        /// <summary>
        /// Vehicle Allowed mileage
        /// </summary>
        public double AllowedMileage { get; set; }

        /// <summary>
        /// Vehicle Image byte array
        /// </summary>
        public byte[] Image { get; set; }
        /// <summary>
        /// Vehicle Image source
        /// </summary>
        public string ImageSource
        {
            get
            {
                if (Image == null)
                {
                    return string.Empty;
                }

                string base64 = Convert.ToBase64String(Image);
                return string.Format("data:{0};base64,{1}", "image/jpg", base64);
            }
        }

    }
}
