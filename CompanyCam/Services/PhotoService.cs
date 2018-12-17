using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CompanyCam.Builders;
using CompanyCam.Models;
using CompanyCam.Objects;

namespace CompanyCam.Services
{
    public class PhotoService : CompanyCamService
    {
        public PhotoService(CompanyCamRequestOptions options = null) : base(options) { }
        
        public async Task<List<Photo>> List(PhotoFilter model)
        {
            this.SetHeaders();
            var url = QueryStringBuilder.BuildUrl("photos", model);

            var response = await Client.GetAsync(url);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<List<Photo>>();

            return result;
        }
        
        public async Task<Photo> Create(string projectId, Photo photo)
        {
            this.SetHeaders();
            var wrapper = new PhotoWrapper()
            {
                photo = photo
            };

            var response = await Client.PostAsJsonAsync($"projects/{projectId}/photos/", wrapper);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Photo>();

            return result;
        }

        public async Task<Photo> Get(string photoId)
        {
            this.SetHeaders();
            var response = await Client.GetAsync($"photos/{photoId}");
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Photo>();

            return result;
        }

        public async Task<Photo> Update(string photoId, Photo photo)
        {
            this.SetHeaders();
            var wrapper = new PhotoWrapper()
            {
                photo = photo
            };

            var response = await Client.PutAsJsonAsync($"photos/{photoId}", wrapper);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Photo>();
            return result;
        }

        public async Task<bool> Delete(string photoId)
        {
            this.SetHeaders();
            var response = await Client.DeleteAsync($"photos/{photoId}");
            HandleResponse(response);
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<(byte[] Data,string MimeType)> Download(string url)
        {
            this.SetHeaders();
            
            var response = await Client.GetAsync(url);
            
            var bytes = await response.Content.ReadAsByteArrayAsync();
            return (bytes,response.Content.Headers.ContentType.MediaType);
        }

        private class PhotoWrapper
        {
            public Photo photo { get; set; }
        }
    }


    public class ImageMediaTypeFormatter : MediaTypeFormatter
    {
        public ImageMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpg"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpeg"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/png"));
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            return ReadFromStreamAsync(type, readStream, content, formatterLogger, CancellationToken.None);
        }

        public override async Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger, CancellationToken cancellationToken)
        {
            using (var streamReader = new StreamReader(readStream))
            {
                return await streamReader.ReadToEndAsync();
            }
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(byte[]);
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }
    }
}
