namespace ComGroups.Services.AuthAPI.Model.Dto
{
    public class LogInResponceDto
    {
        public UserDto User { get; set; }

        public string Token { get; set; }
    }
}
