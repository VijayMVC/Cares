
using System;
using System.Drawing;

namespace Cares.Models.ResponseModels
{
    public class WebApiAvailableHireGroupsApiResponse
    {
        public string NumberPlate { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleCategory { get; set; }
        public long ModelYear { get; set; }
        public double StandardRate { get; set; }
        public string HireGroupName { get; set; }
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
