using MagicVila_Web.APIResponses;
using MagicVila_Web.Models.Dto;
using MagicVila_Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vaila_Utilities;

namespace MagicVila_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            LoginRequestDto loginRequestDto = new LoginRequestDto();
            return View(loginRequestDto);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            APIResponse response = await _authService.LoginAsync<APIResponse>(obj);
            if (response != null && response.IsSuccess)
            {
                LoginResponseDto model= JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(response.Result));
                HttpContext.Session.SetString(SD.SeesionTokin, model.Token);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", response.ErrorMessage.FirstOrDefault());
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterRequestDto model)
        {
            APIResponse result = await _authService.RegisterAsync<APIResponse>(model);
            if (result != null&&result.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(SD.SeesionTokin, "");
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> AccesDenied()
        {
            return View();
        }
    }
}
