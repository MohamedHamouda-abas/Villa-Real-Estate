using MagicVila_Web.Models.Dto;

namespace MagicVila_Web.Services.IServices
{
    public interface IVilaNumberService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VailaNumberCreateDto dto);
        Task<T> UpdateAsync<T>(VailaNumberUpdateDto dto);
        Task<T> DeleteAsync<T>(int id);

    }
}
