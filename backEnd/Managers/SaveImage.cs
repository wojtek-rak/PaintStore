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
            var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');


            var webRoot = env.WebRootPath;

            var filePath = webRoot + "/Uploads" + $@"/{ filename}";

            var fileExists = File.Exists(filePath);

            if (fileExists)
            {
                Random random = new Random();
                var randomNum = random.Next(99999);
                filename = randomNum + filename;
                filePath = webRoot + "/Uploads" + $@"/{ filename}";
            }

            using (FileStream fs = File.Create(filePath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return filename;
        }
    }
}
