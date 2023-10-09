using cookie_stand.Data;
using cookie_stand.Models;
using cookie_stand.Models.Interfaces;
using cookie_stand.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace cookie_stand
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			
			builder.Services.AddCors(options =>
			{
				options.AddDefaultPolicy(
					policy =>
					{
						policy.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader();


					}
					);
			});
			builder.Services.AddSwaggerGen();
			//DB connectionString 
			string connString = builder.Configuration.GetConnectionString("DefaultConnection");

			builder.Services
				.AddDbContext<CookiStandDB>
				(opions => opions.UseSqlServer(connString));
			builder.Services.AddScoped<JwtTokenService>();

			builder.Services.AddTransient<ICookieStand, CookieStandService>();
			builder.Services.AddTransient<IUser, UserService>();


			builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
			{
				options.User.RequireUniqueEmail = true;
			}).AddEntityFrameworkStores<CookiStandDB>();
			builder.Services.AddAuthentication(options =>
			{
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				// Tell the authenticaion scheme "how/where" to validate the token + secret
				options.TokenValidationParameters = JwtTokenService.GetValidationPerameters(builder.Configuration);
			});
			builder.Services.AddAuthorization();


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.UseCors();
			app.UseSwagger();
				app.UseSwaggerUI();
			
			
			app.UseHttpsRedirection();

			app.UseAuthentication();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}