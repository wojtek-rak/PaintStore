using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Cors;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using PaintStore.Domain.UploadModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaintStore.BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class UploadImageController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly Account _account;
        public UploadImageController(IHostingEnvironment env, IOptions<AppIdentitySettings> appIdentitySettings)
        {
            _env = env;
            var acc = appIdentitySettings.Value;
            _account = new Account(){ ApiKey = acc.ApiKey, ApiSecret = acc.SecretApiKey, Cloud = acc.CouldName};
        }
        /// <summary>
        /// testing GET: api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            return _env.WebRootPath;
        }

        [HttpPost]
        //[EnableCors("AllowAllOrigins")]
        public IActionResult Upload(IFormFile file)
        {
            var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
            using (Stream stream = file.OpenReadStream())
            {
                var bg = new BackgroundUploader(_account, filename, stream);
                var imgs = bg.Upload();
                if (imgs != null) return Ok(imgs);
                else return Ok("Cannot upload");
            }
        }
    }

    public class BackgroundUploader
    {
        private readonly Cloudinary m_cloudinary;
        private readonly List<ImageUploadParamsExt> m_uploadParams;
        private readonly List<Image> m_images;


        public BackgroundUploader(Account acc, string filename, Stream stream)
        {
            m_cloudinary = new Cloudinary(acc);

            m_uploadParams = new List<ImageUploadParamsExt>();

            // Upload local image, public_id will be generated on Cloudinary's backend.
            m_uploadParams.Add(new ImageUploadParamsExt()
            {
                File = new FileDescription(filename ,stream),
                Tags = "basic_mvc4",

                Caption = "Local file, Fill 200x150",
            });

            m_images = new List<Image>();
        }

        public List<Image> Upload()
        {
            // Upload images in background to allow user to see the progress
            //actor TODO
                try
                {
                    for (int i = 0; i < m_uploadParams.Count; i++)
                    {
                        // Using Cloudinary API to upload images
                        ImageUploadResult result = m_cloudinary.Upload(m_uploadParams[i]);

                        m_images.Add(new Image()
                        {
                            // Copy predefined caption and transformation
                            Caption = m_uploadParams[i].Caption,
                            //ShowTransform = m_uploadParams[i].ShowTransform,

                            // Load data from Cloudinary response
                            PublicId = result.PublicId,
                            Url = result.Uri.ToString(),
                            Format = result.Format
                        });

                    }

                    return m_images;
                }
                catch
                {
                    return null;
                }
        }
    }
}