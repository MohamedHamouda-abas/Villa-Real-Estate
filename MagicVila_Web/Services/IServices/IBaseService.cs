using MagicVila_Web.APIResponses;
using MagicVila_Web.Models;

namespace MagicVila_Web.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
