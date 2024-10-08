using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using VailaPlace.Data;
using VailaPlace.Models;
using VailaPlace.Models.Dto;
using VailaPlace.Repository.IRepository;

namespace VailaPlace.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private string secretKey;

        public UserRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string username)
        {
            var userName = _context.localUsers.FirstOrDefault(u => u.UserName == username);
            if (userName == null)
            {
                return true;
            }
            return false;
        }
        //Create Token
        public async Task<LoginResponseDto> Login(LoginRequestDto LoginRequestDto)
        {
            var user = _context.localUsers.FirstOrDefault(u => u.UserName.ToLower() == LoginRequestDto.UserName.ToLower() && u.PassWord == LoginRequestDto.Password);
            if (user == null)
            {
                return new LoginResponseDto()
                {
                    Token = "",
                    User = null,
                };
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(secretKey);
            byte[] key = new byte[32]; // 32 bytes = 256 bits  
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            var tokendiscrptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokendiscrptor);
            LoginResponseDto LoginResponseDto = new LoginResponseDto()
            {
                Token = tokenhandler.WriteToken(token),
                User = user
            };
            return LoginResponseDto;
        }
        public async Task<LocalUser> Register(RegisterRequestDto RegisterRequestDto)
        {
            LocalUser register = new()
            {
                UserName = RegisterRequestDto.UserName,
                Name = RegisterRequestDto.Name,
                PassWord = RegisterRequestDto.PassWord,
                Role = RegisterRequestDto.Role,
            };
            await _context.AddAsync(register);
            await _context.SaveChangesAsync();
            register.PassWord = "";
            return register;
        }
    }
}
