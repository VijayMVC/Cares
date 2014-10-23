using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Image
    /// </summary>
    public class VehicleImage
    {

        /// <summary>
        /// Vehicle Image ID
        /// </summary>
        public long VehicleImageId { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Image Source
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