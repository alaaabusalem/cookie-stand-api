using cookie_stand.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace cookie_stand.Data
{
	public class CookiStandDB: IdentityDbContext<AppUser>
	{
        public CookiStandDB(DbContextOptions options): base(options)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<CookiStandHourlySale>()
				.HasKey(locationHourlySale => new { locationHourlySale.HourlySaleId, locationHourlySale.CookieStandId }
				);

			modelBuilder.Entity<HourlySale>().HasData(
			 new HourlySale { HourlySaleId = 1, Time = 6 },
			 new HourlySale { HourlySaleId = 2, Time = 7 },
			 new HourlySale { HourlySaleId = 3, Time = 8 },
			 new HourlySale { HourlySaleId = 4, Time = 9 },
			 new HourlySale { HourlySaleId = 5, Time = 10 },
			 new HourlySale { HourlySaleId = 6, Time = 11 },
			 new HourlySale { HourlySaleId = 7, Time = 12 },
		     new HourlySale { HourlySaleId = 8, Time = 1},
			 new HourlySale { HourlySaleId = 9, Time = 2 },
			 new HourlySale { HourlySaleId = 10, Time = 3 },
			 new HourlySale { HourlySaleId = 11, Time = 4 },
			 new HourlySale { HourlySaleId = 12, Time = 5 },
			 new HourlySale { HourlySaleId = 13, Time = 6 },
			new HourlySale { HourlySaleId = 14, Time = 7 }
		   );
			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "admin",
				Name = "admin",
				NormalizedName = "Admin",
				ConcurrencyStamp = Guid.Empty.ToString()
			});
			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "user",
				Name = "user",
				NormalizedName = "USER",
				ConcurrencyStamp = Guid.Empty.ToString()
			});

			var hasher = new PasswordHasher<AppUser>();

			var admin = new AppUser
			{
				Id = "1",
				UserName = "Admin",
				NormalizedUserName = "ADMIN",
				Email = "admin@Gmail.com",
				PhoneNumber = "1234567890",
				NormalizedEmail = "admin@GMAIL.COM",
				EmailConfirmed = true,
				LockoutEnabled = false
			};
			admin.PasswordHash = hasher.HashPassword(admin, "Admin@123");
			modelBuilder.Entity<AppUser>().HasData(admin);
			modelBuilder.Entity<IdentityUserRole<string>>().HasData(
			new IdentityUserRole<string>
			{
				RoleId = "admin",
				UserId = admin.Id
			});
		}

		public DbSet<CookieStand> CookieStands { get; set; }
		public DbSet<HourlySale> HourlySales { get; set; }
		public DbSet<CookiStandHourlySale> CookiStandHourlySales { get; set; }


	}
}

