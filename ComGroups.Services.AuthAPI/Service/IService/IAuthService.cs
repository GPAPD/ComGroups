using ComGroups.Services.AuthAPI.Model.Dto;

namespace ComGroups.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationDto registrationDto);

        Task<LogInResponceDto> Login(LogInRequestDto logInRequestDto);

        Task<bool> AssignRole(string email, string roleName);
    }
}
