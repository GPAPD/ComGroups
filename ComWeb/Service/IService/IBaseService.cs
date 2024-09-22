using ComWeb.Models;

namespace ComWeb.Service.IService
{
	public interface IBaseService
	{
		Task<ResponesDto> SendAsync(RequestDto requestDto, bool withBearer = true );
	}
}
