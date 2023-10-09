using cookie_stand.Models.DTOs;
using cookie_stand.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace cookie_stand.Models.Services
{
	public class UserService:IUser
	{
		private readonly UserManager<AppUser> _userManager;
		private JwtTokenService tokenService;

		public UserService(UserManager<AppUser> userManager , JwtTokenService tokenService)
		{
			_userManager = userManager;
			this.tokenService = tokenService;

		}

		public async Task<UserDTO> Login(LoginDTO loginDTO)
		{
			var user = await _userManager.FindByEmailAsync(loginDTO.Email);
			bool checkPassword = await _userManager.CheckPasswordAsync(user, loginDTO.Passowrd);
			if (checkPassword)
			{
				return new UserDTO()
				{
					Id = user.Id,
					Username = user.UserName,
					Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(5))
				};

			}
			return null;
		}
	}
}
