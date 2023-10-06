using cookie_stand.Data;
using cookie_stand.Models.Interfaces;
using cookie_stand.Models.Services;
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
			builder.Services.AddSwaggerGen();
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
			//DB connectionString 
			string connString = builder.Configuration.GetConnectionString("DefaultConnection");

			builder.Services
				.AddDbContext<CookiStandDB>
				(opions => opions.UseSqlServer(connString));

			builder.Services.AddTransient<ICookieStand, CookieStandService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseCors();
			//app.UseHttpsRedirection();

			//app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}