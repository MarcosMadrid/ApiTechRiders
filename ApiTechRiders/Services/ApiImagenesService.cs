using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace ApiTechRiders.Services
{
    public class ApiImagenesService
    {
        private string? urlApiImagenes;

        public ApiImagenesService(IConfiguration configuration)
        {
            this.urlApiImagenes = configuration.GetValue<string>("ApiImgs")!;
        }

        public async Task<string?> PostImagen(IFormFile imagen, string fileName)
        {
            string request = "/api/Usuario/UploadImgPublic";
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlApiImagenes);
                var formData = new MultipartFormDataContent();
                byte[] fileData;
                using (var memoryStream = new MemoryStream())
                {
                    await imagen.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                }
                var imageContent = new ByteArrayContent(fileData);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(imagen.ContentType);
                var name = imagen.ContentType.Split("/")[0];
                formData.Add(imageContent, name, fileName);

                var response = await httpClient.PostAsync(request, formData);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
                else
                {
                    Console.WriteLine("Request failed with status code: " + response.ReasonPhrase + "/" + await response.Content.ReadAsStringAsync());
                }
            }
            return null;
        }

        public async Task<string?> UpdateImagen(IFormFile imagen, string fileName, string token)
        {
            string request = "/api/Usuario/UploadImgUsuario";
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlApiImagenes);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Authorization", token);
                var formData = new MultipartFormDataContent();

                byte[] fileData;
                using (var memoryStream = new MemoryStream())
                {
                    await imagen.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                }
                var imageContent = new ByteArrayContent(fileData);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(imagen.ContentType);
                var name = imagen.ContentType.Split("/")[0];
                formData.Add(imageContent, name, fileName);

                var response = await httpClient.PostAsync(request, formData);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
                else
                {
                    Console.WriteLine("Request failed with status code: " + response.ReasonPhrase + "/" + await response.Content.ReadAsStringAsync());
                }
            }
            return null;
        }

        public async Task<string?> DeleteImagen(string token)
        {
            string request = "/api/Usuario/DeleteImg";
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlApiImagenes);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Authorization", token);

                var response = await httpClient.DeleteAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
                else
                {
                    Console.WriteLine("Request failed with status code: " + response.ReasonPhrase + "/" + await response.Content.ReadAsStringAsync());
                }
            }
            return null;
        }
    }
}
