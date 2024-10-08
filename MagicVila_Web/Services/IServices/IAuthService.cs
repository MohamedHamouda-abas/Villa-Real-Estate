using MagicVila_Web.Models;
using MagicVila_Web.Models.Dto;
using Microsoft.AspNetCore.Identity.Data;

namespace MagicVila_Web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDto apiRequest);
        Task<T> RegisterAsync<T>(RegisterRequestDto apiRequest);
    }
}
