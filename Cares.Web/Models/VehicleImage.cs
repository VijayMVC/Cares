using System;
using Castle.Core.Internal;

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
            set
            {
                if (value.IsNullOrEmpty() || !value.Contains("base64,"))
                {
                    Image = null;
                    return;
                }
                var index = value.IndexOf("base64,", StringComparison.Ordinal);
                Image = Convert.FromBase64String(value.Substring(index+7));
            }
        }
    }
}