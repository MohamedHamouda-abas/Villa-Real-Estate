using MagicVila_Web.Models.Dto;
using MagicVila_Web.Services.IServices;
using System.Reflection;
using Vaila_Utilities;
using MagicVila_Web.Models;

namespace Montview_Web.Services
{
    public class VilaService : BaseService, IVilaService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private string vilaUrl;
        public VilaService(IHttpClientFactory ClientFactory, IConfiguration configuration) : base(ClientFactory)
        {
            _ClientFactory = ClientFactory;
            vilaUrl = configuration.GetValue<string>("ServiceUrls:VailaAPI");
        }

        public Task<T> CreateAsync<T>(VailaCraeteDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = vilaUrl + "/api/VailaAPI"

            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = vilaUrl + "/api/VailaAPI/" + id

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,   
                Url = vilaUrl + "/api/VailaAPI"

            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = vilaUrl + "/api/VailaAPI"

            });
        }

        public Task<T> UpdateAsync<T>(VailaUpdteDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = vilaUrl + "/api/VailaAPI" + dto.Id

            });
        }
    }
}
