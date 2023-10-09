namespace cookie_stand.Models.DTOs
{
	public class UserDTO
	{
		public string Id { get; set; }


		public string Username { get; set; }
		public string Token { get; set; }

	}
	public class LoginDTO
	{
		public string Email { get; set; }
		public string Passowrd { get; set; }

	}
}
