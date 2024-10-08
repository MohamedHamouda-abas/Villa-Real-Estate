using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using VailaPlace.APIResponses;
using VailaPlace.Models.Dto;
using VailaPlace.Repository.IRepository;

namespace VailaPlace.Controllers
{
    [Route("api/UsersAuth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private APIResponse _resonse;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _resonse = new APIResponse();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginresponse = await _userRepository.Login(model);
            if (loginresponse.User == null || string.IsNullOrEmpty(loginresponse.Token))
            {
                _resonse.StatusCode =HttpStatusCode.BadRequest;
                _resonse.IsSuccess = false;
                _resonse.ErrorMessage.Add("the username or password is incorrect");
                return BadRequest(_resonse);
            }
            _resonse.StatusCode = System.Net.HttpStatusCode.OK;
            _resonse.IsSuccess = true;
            _resonse.Result = loginresponse;
            return Ok(_resonse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            bool ifUserisUniq = _userRepository.IsUniqueUser(model.UserName);
            if (!ifUserisUniq)
            {
                _resonse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _resonse.IsSuccess = false;
                _resonse.ErrorMessage.Add("Username is exsist");
                return BadRequest(_resonse);
            }
            var user =await _userRepository.Register(model);
            if (user == null)
            {
                _resonse.StatusCode = System.Net.HttpStatusCode.NotFound;
                _resonse.IsSuccess = false;
                _resonse.ErrorMessage.Add("Username is NotFound");
                return NotFound();
            }
            _resonse.StatusCode = System.Net.HttpStatusCode.OK;
            _resonse.IsSuccess = true;
            return Ok(_resonse);
        }
    }
}
    