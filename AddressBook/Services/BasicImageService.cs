using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    public class BasicImageService: IImageService
    {
        public string DecodePoster(byte[] image, string contentType)
        {
            if (image == null)
            {
                return null;
            }
            var uploadImage = Convert.ToBase64String(image);
            return $"data:{contentType};base64,{uploadImage}";
        }

        public async Task<byte[]> EncodeImageURLAsync(string imageURL)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(imageURL);

            Stream stream = await response.Content.ReadAsStreamAsync();

            var ms = new MemoryStream();
            await stream.CopyToAsync(ms);

            return ms.ToArray();

        }

        public async Task<byte[]> EncodePosterAsync(IFormFile image)
        {
            if (image == null)
            {
                return null;
            }
            using var ms = new MemoryStream();
            await image.CopyToAsync(ms);
            return ms.ToArray();

        }

        public string RecordContentType(IFormFile image)
        {
            if (image == null)
            {
                return null;
            }
            return image.ContentType;
        }
    }
}
