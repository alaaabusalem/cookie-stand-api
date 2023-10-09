using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace cookie_stand.Models.Services
{
	public class JwtTokenService
	{
		private IConfiguration configuration;
		private SignInManager<AppUser> signInManager;

		public JwtTokenService(IConfiguration config, SignInManager<AppUser> manager)
		{
			configuration = config;
			signInManager = manager;
		}
		public static TokenValidationParameters GetValidationPerameters(IConfiguration configuration)
		{
			return new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = GetSecurityKey(configuration),
				ValidateIssuer = false,
				ValidateAudience = false
			};
		}

		private static SecurityKey GetSecurityKey(IConfiguration configuration)
		{
			var secret = configuration["JWT:Secret"];
			if (secret == null)
			{
				throw new InvalidOperationException("JWT: Secret key is not exist");
			}

			var secretBytes = Encoding.UTF8.GetBytes(secret);

			return new SymmetricSecurityKey(secretBytes);
		}

		public async Task<string> GetToken(AppUser user, TimeSpan expiresIn)
		{
			var principle = await signInManager.CreateUserPrincipalAsync(user);

			if (principle == null)
			{
				return null;
			}
			var signingKey = GetSecurityKey(configuration);

			var token = new JwtSecurityToken(
				expires: DateTime.UtcNow + expiresIn,
				signingCredentials: new SigningCredentials(signingKey,
				SecurityAlgorithms.HmacSha256),
				claims: principle.Claims

				);

			return new JwtSecurityTokenHandler().WriteToken(token);


		}
	}
}
