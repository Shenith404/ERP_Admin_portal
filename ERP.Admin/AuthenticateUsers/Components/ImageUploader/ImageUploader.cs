using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;


namespace UI.ImageUploader
{
    public class ImageUploader : IImageUploader
    {
        private readonly IWebHostEnvironment _webHostEnviroment;


        public ImageUploader(IWebHostEnvironment env)
        {
            _webHostEnviroment = env;
        }



        public async Task<List<string>> Post(ImageFile[] files)
        {
            List<string> fileNames = new List<string>();
            foreach (var file in files)
            {
                string newFileName = $"{Guid.NewGuid().ToString("N")}-{file.fileName}";
                fileNames.Add(newFileName);
                var buf = Convert.FromBase64String(file.base64data);
                await File.WriteAllBytesAsync(Path.Combine(_webHostEnviroment.WebRootPath, "Images", newFileName), buf);
                Console.WriteLine(Path.Combine(_webHostEnviroment.WebRootPath, "Images", newFileName));
            }
            return fileNames;
        }
    }


}
 public class ImageFile
    {
        public string base64data { get; set; }
        public string contentType { get; set; }
        public string fileName { get; set; }
    }