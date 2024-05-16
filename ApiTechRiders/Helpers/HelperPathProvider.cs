using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;

namespace ApiTechRiders.Helpers
{
    public enum Folders { Images = 0}
    public class HelperPathProvider
    {
        private IServer server;
        private IWebHostEnvironment hostEnvironment;

        public HelperPathProvider(IWebHostEnvironment hostEnvironment, IServer server)
        {
            this.server = server;
            this.hostEnvironment = hostEnvironment;
        }

        private string GetFolderPath(Folders folder)
        {
            string carpeta = "";
            if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            return carpeta;
        }

        public string MapPath(Folders folder)
        {
            string carpeta = this.GetFolderPath(folder);
            string rootPath = this.hostEnvironment.WebRootPath;
            string path = Path.Combine(rootPath, carpeta);
            return path;
        }

        public string MapUrlPath(Folders folder)
        {
            string carpeta = this.GetFolderPath(folder);
            var addresses = server.Features.Get<IServerAddressesFeature>().Addresses;
            string serverUrl = addresses.FirstOrDefault();
            string urlPath = Path.Combine(serverUrl + "/" + carpeta + "/");
            return urlPath;
        }

        public string UrlPath()
        {            
            var addresses = server.Features.Get<IServerAddressesFeature>().Addresses;
            string serverUrl = addresses.FirstOrDefault();            
            return serverUrl;
        }
    }
}