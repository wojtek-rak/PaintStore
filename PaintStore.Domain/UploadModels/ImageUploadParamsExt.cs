using CloudinaryDotNet.Actions;

namespace PaintStore.Domain.UploadModels
{
    /// <summary>
    /// We can inherit API class to make more convenient for us
    /// These fields will not be passes to cloudinary
    /// They will be used just at showing images after uploading
    /// </summary>
    public class ImageUploadParamsExt : ImageUploadParams
    {
        /// <summary>
        /// Image caption to show
        /// </summary>
        public string Caption;
    }
}
