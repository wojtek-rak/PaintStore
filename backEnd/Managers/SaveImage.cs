using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace backEnd.Controllers.UploadImagesControllers
{
    public interface ISaveImage
    {
        string SaveImageOnServer(IHostingEnvironment env, IFormFile file);
    }
    /// <summary>
    /// Currently not used in project
    /// </summary>
    public class SaveImage : ISaveImage
    {
        public string SaveImageOnServer(IHostingEnvironment env, IFormFile file) 
        {
            long size = 0;

            var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');


            var webRoot = env.WebRootPath;

            var filePath = webRoot + "/Uploads" + $@"/{ filename}";

            bool fileExists = (System.IO.File.Exists(filePath) ? true : false);

            if (fileExists)
            {
                Random random = new Random();
                var randomNum = random.Next(99999);
                filename = randomNum + filename;
                filePath = webRoot + "/Uploads" + $@"/{ filename}";
            }
            size += file.Length;
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return filename;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class SaveImageExtensions
    //{
    //    public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<SaveImage>();
    //    }
    //}
}
