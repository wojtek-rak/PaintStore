using CloudinaryDotNet.Actions;

namespace backEnd.Models.UploadModels
{
    /// <summary>
    /// We can inherit API class to make more convenient for us
    /// These fields will not be passes to cloudinary
    /// They will be used just at showing images after uploading
    /// </summary>
    class ImageUploadParamsExt : ImageUploadParams
    {
        /// <summary>
        /// Image caption to show
        /// </summary>
        public string Caption;

        ///// <summary>
        ///// Transformation that will be applied at showing image, not at uploading
        ///// </summary>
        //public Transformation ShowTransform;
    }
}
