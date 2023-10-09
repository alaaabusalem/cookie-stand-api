using cookie_stand.Models.DTOs;
using cookie_stand.Models.Interfaces;
using cookie_stand.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cookie_stand.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUser userService;
		public UsersController(IUser service)
		{
			userService = service;
		}
		[HttpPost("Login")]
		public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
		{
			var user = await userService.Login(loginDto);

			if (user == null)
			{
				return Unauthorized();
			}
			return user;
		}
	}
}
