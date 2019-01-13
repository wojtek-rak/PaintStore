using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Cors;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using backEnd.Models.UploadModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backEnd.Controllers.UploadImagesControllers
{
    [Route("api/[controller]")]
    public class UploadImageController : Controller
    {
        private IHostingEnvironment _env;
        //private ISaveImage _saveImage;
        private Account _account;
        public UploadImageController(IHostingEnvironment env, Account account)
        {
            _env = env;
            _account = account;
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
        [EnableCors("AllowAllOrigins")]
        public IActionResult Upload(IFormFile file)
        {
            var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
            using (Stream stream = file.OpenReadStream())
            {
                var bg = new BackgroundUploader(_env, _account, filename, stream);
                var imgs = bg.Upload();
                if (imgs != null) return Ok(imgs);
                else return Ok("Cannot upload");
            }
            // return Ok(filename);
        }
    }

    public class BackgroundUploader
    {
        private Cloudinary m_cloudinary;
        private List<ImageUploadParamsExt> m_uploadParams;
        private List<Image> m_images;
        //private Image image;

        public List<Image> Images { get { return m_images; } }

        public Api CloudinaryApi { get { return m_cloudinary.Api; } }

        private IHostingEnvironment _env;


        public BackgroundUploader(IHostingEnvironment env, Account acc, string filename, Stream stream)
        {
            m_cloudinary = new Cloudinary(acc);

            m_uploadParams = new List<ImageUploadParamsExt>();

            // Upload local image, public_id will be generated on Cloudinary's backend.
            m_uploadParams.Add(new ImageUploadParamsExt()
            {
                File = new FileDescription(filename ,stream),
                Tags = "basic_mvc4",

                Caption = "Local file, Fill 200x150",
                //ShowTransform = new Transformation().Width(200).Height(150).Crop("fill")
            });

            m_images = new List<Image>();
        }

        public List<Image> Upload()
        {
            // Upload images in background to allow user to see the progress
            //actor todo
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

///Users/wolix/Documents/c#_project/PaintStore_BackEnd/backEnd/wwwroot
///

//public BackgroundUploader(IHostingEnvironment env, Account acc)
//{
//    // Set up cloudinary object
//    _env = env;


//    m_cloudinary = new Cloudinary(acc);

//    // Check that application is properly installed in IIS
//    string fileToCheck = _env.WebRootPath + "/Uploads/Zrzut ekranu 2018-06-27 o 16.42.53.png";
//    if (!File.Exists(fileToCheck))
//        throw new ApplicationException(String.Format("Can't find file {0}!", fileToCheck));

//    // Set up parameters of uploading tasks

//    m_uploadParams = new List<ImageUploadParamsExt>();

//    // Upload local image, public_id will be generated on Cloudinary's backend.
//    m_uploadParams.Add(new ImageUploadParamsExt()
//    {
//        File = new FileDescription(_env.WebRootPath + "/Uploads/Zrzut ekranu 2018-06-27 o 16.42.53.png"),
//        Tags = "basic_mvc4",

//        Caption = "Local file, Fill 200x150",
//        ShowTransform = new Transformation().Width(200).Height(150).Crop("fill")
//    });

//    // Upload local image, uploaded with a public_id.
//    //m_uploadParams.Add(new ImageUploadParamsExt()
//    //{
//    //    File = new FileDescription(HttpContext.Current.Server.MapPath("/Images/pizza.jpg")),
//    //    PublicId = "custom_name",
//    //    Tags = "basic_mvc4",

//    //    Caption = "Local file, custom public ID, Fit into 200x150",
//    //    ShowTransform = new Transformation().Width(200).Height(150).Crop("fit")
//    //});

//    // Eager transformations are applied as soon as the file is uploaded, instead of waiting
//    // for a user to request them. 
//    //m_uploadParams.Add(new ImageUploadParamsExt()
//    //{
//    //    File = new FileDescription(HttpContext.Current.Server.MapPath("/Images/lake.jpg")),
//    //    PublicId = "eager_custom_name",
//    //    Tags = "basic_mvc4",
//    //    EagerTransforms = new List<Transformation>(){
//    //        new EagerTransformation().Width(200).Height(150).Crop("scale")},

//    //    Caption = "Local file, Eager transformation of scaling to 200x150",
//    //    ShowTransform = new Transformation().Width(200).Height(150).Crop("scale")
//    //});

//    // In the two following examples, the file is fetched from a remote URL and stored in Cloudinary.
//    // This allows you to apply the same transformations, and serve those using Cloudinary's CDN layer.
//    //m_uploadParams.Add(new ImageUploadParamsExt()
//    //{
//    //    File = new FileDescription("http://res.cloudinary.com/demo/image/upload/couple.jpg"),
//    //    Tags = "basic_mvc4",

//    //    Caption = "Uploaded remote image, Face detection based 200x150 thumbnail",
//    //    ShowTransform = new Transformation().Width(200).Height(150).Crop("thumb").Gravity("faces")
//    //});

//    //m_uploadParams.Add(new ImageUploadParamsExt()
//    //{
//    //    File = new FileDescription("http://res.cloudinary.com/demo/image/upload/couple.jpg"),
//    //    Tags = "basic_mvc4",
//    //    Transformation = new Transformation().Width(500).Height(500).Crop("fit").Effect("saturation:-70"),

//    //    Caption = "Uploaded remote image, Fill 200x150, round corners, apply the sepia effect",
//    //    ShowTransform = new Transformation().Width(200).Height(150).Crop("fill").Gravity("face").Radius(10).Effect("sepia")
//    //});

//    m_images = new List<Image>();
//}