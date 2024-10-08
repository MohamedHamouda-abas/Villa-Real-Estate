using MagicVila_Web.Models.Dto;
using MagicVila_Web.Services.IServices;
using System.Reflection;
using Vaila_Utilities;
using MagicVila_Web.Models;

namespace Montview_Web.Services
{
    public class VilaNumberService : BaseService, IVilaNumberService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private string vilaUrl;
        public VilaNumberService(IHttpClientFactory ClientFactory, IConfiguration configuration) : base(ClientFactory)
        {
            _ClientFactory = ClientFactory;
            vilaUrl = configuration.GetValue<string>("ServiceUrls:VailaAPI");
        }

        public Task<T> CreateAsync<T>(VailaNumberCreateDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = vilaUrl + "/api/VailaNumberAPI"

            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = vilaUrl + "/api/VailaNumberAPI/" + id

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,   
                Url = vilaUrl + "/api/VailaNumberAPI"

            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = vilaUrl + "/api/VailaNumberAPI"

            });
        }

        public Task<T> UpdateAsync<T>(VailaNumberUpdateDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = vilaUrl + "/api/VailaNumberAPI" + dto.VailaNo

            });
        }
    }
}
