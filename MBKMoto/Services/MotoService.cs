using Handmade.Web.Models;
using Handmade.Web.Services.IServices;
using Handmade.Web.Services;
using Handmade.Web;
using System;
using static Handmade.Web.SD;

namespace Handmade.Web.Services
{
    public class EmbroideryService : BaseService, IEmbroideryService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmbroideryService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            httpClientFactory = httpClientFactory;
        }

        public async Task<T> CreateEmbroideriesAsync<T>(EmbroideryDto embroideryDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.POST,
                data = embroideryDto,
                url = SD.EmbroideryApiBase + "/api/embroideries",
                // AccessToken = token
            }
                 );
        }

        public async Task<T> DeleteEmbroideriesAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.DELETE,
                url = SD.EmbroideryApiBase + "/api/embroideries/" + id,
                // AccessToken = token
            }
                );
        }

        public async Task<T> GetAllEmbroideriesAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.GET,

                url = SD.EmbroideryApiBase + "/api/embroideries",
                //AccessToken = token
            }
                );
        }

        public async Task<T> GetEmbroideryByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.GET,

                url = SD.EmbroideryApiBase + "/api/embroideries/" + id,
                // AccessToken = token
            }
                 );
        }

        public async Task<T> UpdateEmbroideriesAsync<T>(EmbroideryDto embroideryDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.PUT,
                data = embroideryDto,

                url = SD.EmbroideryApiBase + "/api/embroideries",
                // AccessToken = token
            }
                ); throw new NotImplementedException();
        }
    }
}

