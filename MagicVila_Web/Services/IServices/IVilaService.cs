using MagicVila_Web.Models.Dto;

namespace MagicVila_Web.Services.IServices
{
    public interface IVilaService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VailaCraeteDto dto);
        Task<T> UpdateAsync<T>(VailaUpdteDto dto);
        Task<T> DeleteAsync<T>(int id);

    }
}
