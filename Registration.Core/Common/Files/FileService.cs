using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Registration.Core.Common.Files
{
    public class FileService
    {
        private readonly UploadCore _uploadCore;

        public FileService(UploadCore uploadCore)
        {
            _uploadCore = uploadCore;
        }

        private static string Rename()
        {
            var random = new Random();
            var randomNumber = random.Next(10000, 99999);
            var name = randomNumber.ToString();
            return name;
        }
        public string Upload(IFormFile file, string folderName)
        {
            string url;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var filename = Rename() + extension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/" + folderName, filename);
                var stream = new FileStream(path, FileMode.Create);
                var result = file.CopyToAsync(stream);
                result.Wait();
                if (result.IsCompletedSuccessfully)
                {
                    url = _uploadCore.GetBaseUrl() + "/uploads/" + folderName + "/" + filename;
                    stream.Close();
                }
                else
                {
                    url = _uploadCore.GetBaseUrl() + "/uploads/default.jpg";
                }
            }
            else
            {
                url = _uploadCore.GetBaseUrl() + "/uploads/default.jpg";
            }
            return url;
        }
    }
}
