using ComWeb.Models;
using ComWeb.Service.IService;
using ComWeb.Utility;
using static ComWeb.Utility.SD;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace ComWeb.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponesDto> AssignRoleAsync(RegistrationDto registrationDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationDto,
                Url = SD.AuthAPIBase + "/api/auth/assign_role"
            });
        }

        public async Task<ResponesDto> LoginAsync(LogInRequestDto logInRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = logInRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/login"
            }); 
        }

        public async Task<ResponesDto> RegisterAsync(RegistrationDto registrationDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationDto,
                Url = SD.AuthAPIBase + "/api/auth/register"
            });
        }
    }
}
