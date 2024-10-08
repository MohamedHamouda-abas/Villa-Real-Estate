using VailaPlace.Models;
using VailaPlace.Models.Dto;

namespace VailaPlace.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDto> Login(LoginRequestDto LoginRequestDto);
        Task<LocalUser> Register(RegisterRequestDto RegisterRequestDto);

    }
}
