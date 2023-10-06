using cookie_stand.Models;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand.Data
{
	public class CookiStandDB: DbContext
	{
        public CookiStandDB(DbContextOptions options): base(options)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
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
		}

		public DbSet<CookieStand> CookieStands { get; set; }
		public DbSet<HourlySale> HourlySales { get; set; }
		public DbSet<CookiStandHourlySale> CookiStandHourlySales { get; set; }


	}
}

