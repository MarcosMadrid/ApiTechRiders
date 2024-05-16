using Microsoft.AspNetCore.Hosting.Server;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace ApiTechRiders.Helpers
{
    public class HelperFilesManager
    {
        private string pathImgs;
        private string formatFileImageUser;
        private HelperPathProvider pathProvider;

        public HelperFilesManager(HelperPathProvider helperPathProvider)
        {
            this.pathProvider = helperPathProvider;        
            BuildFolderImgs(Folders.Images);
            //La x es el lugar que tomara el UserId para la imagen.
            this.formatFileImageUser = "user-image-x.jpeg";
        }

        public bool ImgExists(string imgName)
        {
            string imgPath = Path.Combine(pathProvider.MapPath(Folders.Images), imgName);
            return File.Exists(imgPath);
        }

        public async Task<string> CreateImg(string imgName, Stream imgStream)
        {
            if (ImgExists(imgName))
            {
                throw new InvalidOperationException("Image already exists.");
            }

            string imgPath = Path.Combine(this.pathImgs, imgName);
            using (Stream jpegStream = await ConvertToJpeg(imgStream))
            {
                using (FileStream fs = File.OpenWrite(imgPath))
                {
                    await jpegStream.CopyToAsync(fs);
                }
            }
            string urlImage = this.pathProvider.MapUrlPath(Folders.Images) + imgName;
            return urlImage;
        }

        public async Task<string> UpdateImg(string imgName ,Stream imgStream)
        {
            if (!ImgExists(imgName))
            {
                throw new FileNotFoundException("Image not found.");
            }

            string imgPath = Path.Combine(this.pathImgs, imgName);
            using (Stream jpegStream = await ConvertToJpeg(imgStream))
            {
                using (FileStream fs = File.OpenWrite(imgPath))
                {
                    await jpegStream.CopyToAsync(fs);
                }
            }
            string urlImage = this.pathProvider.MapUrlPath(Folders.Images) + "/" + imgName;
            return urlImage;
        }

        public void DeleteImg(string imgName)
        {
            if (!ImgExists(imgName))
            {
                throw new FileNotFoundException("Image not found.");
            }

            string imgPath = Path.Combine(this.pathImgs, imgName);
            File.Delete(imgPath);
        }

        public int GetIdImage(string fileName)
        {
            string idAndExtension = fileName.Split('-').Last();
            string idImg = idAndExtension.Split(".").First();
            int id = int.Parse(idImg);
            return id;
        }

        public string GetNameImage(int userId)
        {
            return 
                formatFileImageUser.Replace("x", userId.ToString());
        }

        public async Task<MemoryStream> ConvertToJpeg(Stream imgStream)
        {
            try
            {
                using (var image = Image.Load(imgStream))
                {
                    using (var outputStream = new MemoryStream())
                    {
                        image.Save(outputStream, new JpegEncoder { Quality = 75 });
                        outputStream.Position = 0;
                        var jpegStream = new MemoryStream(outputStream.ToArray());
                        jpegStream.Position = 0;
                        return jpegStream;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error converting image to JPEG: " + ex.Message);
                throw;
            }
        }

        private void BuildFolderImgs(Folders folders)
        {
            this.pathImgs = this.pathProvider.MapPath(folders);
            if (!Directory.Exists(pathImgs))
            {
                Directory.CreateDirectory(this.pathImgs);
            }
        }
    }
}
