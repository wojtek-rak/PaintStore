using System;
using System.Collections.Generic;
using System.Text;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using PaintStore.Application.Interfaces;
using PaintStore.Domain.UploadModels;

namespace PaintStore.Application.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Account _account;
        public CloudinaryService(IOptions<AppIdentitySettings> appIdentitySettings)
        {
            var acc = appIdentitySettings.Value;
            _account = new Account(){ ApiKey = acc.ApiKey, ApiSecret = acc.SecretApiKey, Cloud = acc.CouldName};
        }


        public void DeleteImage(string link)
        {
            var urlTrimmed = link.Substring(link.LastIndexOf("/", StringComparison.Ordinal) + 1);
            var id = urlTrimmed.Remove(urlTrimmed.LastIndexOf(".", StringComparison.Ordinal));

            var mCloudinary = new Cloudinary(_account);
            mCloudinary.DeleteResources(id);
        }
    }
}
