using cookie_stand.Models.DTOs;

namespace cookie_stand.Models.Interfaces
{
	public interface IUser
	{
		Task<UserDTO> Login(LoginDTO loginDTO);

	}
}
