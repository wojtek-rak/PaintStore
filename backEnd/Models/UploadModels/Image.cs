using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEnd.Models.UploadModels
{
    /// <summary>
    /// Model that will be passed to view
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Image caption to show
        /// </summary>
        public string Caption;

        ///// <summary>
        ///// Transformation that will be applied at showing image, not at uploading
        ///// </summary>
        //public Transformation ShowTransform;

        /// <summary>
        /// Cloudinary image URL
        /// </summary>
        public string Url;

        /// <summary>
        /// Image format
        /// </summary>
        public string Format;

        /// <summary>
        /// Cloudinary public ID of image
        /// </summary>
        public string PublicId;
    }
}
