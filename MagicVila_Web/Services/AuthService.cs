using MagicVila_Web.Models;
using MagicVila_Web.Models.Dto;
using MagicVila_Web.Services.IServices;
using Microsoft.AspNetCore.Identity.Data;
using Montview_Web.Services;
using Vaila_Utilities;

namespace MagicVila_Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private string vilaUrl;
        public AuthService(IHttpClientFactory ClientFactory, IConfiguration configuration) : base(ClientFactory)
        {
            _ClientFactory = ClientFactory;
            vilaUrl = configuration.GetValue<string>("ServiceUrls:VailaAPI");
        }

        public Task<T> LoginAsync<T>(LoginRequestDto obj)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = vilaUrl + "/api/UsersAuth/login"

            });
        }

        public Task<T> RegisterAsync<T>(RegisterRequestDto obj)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = vilaUrl + "/api/UsersAuth/register"

            });
        }
    }
}

