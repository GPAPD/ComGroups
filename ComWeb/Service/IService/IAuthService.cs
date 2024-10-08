﻿using ComWeb.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace ComWeb.Service.IService
{
    public interface IAuthService
    {
        Task<ResponesDto> LoginAsync(LogInRequestDto logInRequestDto);
        Task<ResponesDto> RegisterAsync(RegistrationDto registrationDto);
        Task<ResponesDto> AssignRoleAsync(RegistrationDto registrationDto);
    }
}
