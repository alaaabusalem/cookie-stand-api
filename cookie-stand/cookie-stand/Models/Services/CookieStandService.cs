using cookie_stand.Data;
using cookie_stand.Models.DTOs;
using cookie_stand.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand.Models.Services
{
	public class CookieStandService : ICookieStand
	{
		private readonly CookiStandDB _DB;
		public CookieStandService(CookiStandDB db) { 
		   _DB = db;
		}	
		public async Task<CookieStand> Creat(CreatCookieStand creatCookieStand)
		{
			CookieStand stand= new CookieStand()
			{
				Location = creatCookieStand.Location,
				Average_cookies_per_sale = creatCookieStand.Average_cookies_per_sale,
				Maximum_customers_per_hour = creatCookieStand.Maximum_customers_per_hour,
				Minimum_customers_per_hour = creatCookieStand.Minimum_customers_per_hour
			};		
		      await _DB.CookieStands.AddAsync(stand);
			await _DB.SaveChangesAsync();	
			if(stand!= null)
			{
				var HourlList = await _DB.HourlySales.ToListAsync();
                foreach (var item in HourlList)
                {
					await _DB.CookiStandHourlySales.AddAsync(new CookiStandHourlySale
					{
						CookieStandId = stand.CookieStandId,
						HourlySaleId = item.HourlySaleId,
						Value = (stand.Maximum_customers_per_hour + stand.Minimum_customers_per_hour) * stand.Average_cookies_per_sale
					}); ;
					await _DB.SaveChangesAsync();

				}
				return stand;
			}
			return null;
		}

		public async Task Delete(int id)
		{
			var stand = await _DB.CookieStands.FindAsync(id);
			if(stand != null)
			{
				_DB.CookieStands.Remove(stand);
			}
		}

		public async Task<GetCookieStand> GetCookieStand(int id)
		{
		var cookieStand = await _DB.CookieStands.Select(CS => new GetCookieStand()
			{
				CookieStandId = CS.CookieStandId,
				Location = CS.Location,
				Maximum_customers_per_hour = CS.Maximum_customers_per_hour,
				Minimum_customers_per_hour = CS.Minimum_customers_per_hour,
				CookiStandHourlySaleDTOs = CS.cookiStandnHourlysales.Select(s => new CookiStandHourlySaleDTO()
				{
					Value= s.Value,	

				}).ToList(),

			 }).FirstOrDefaultAsync(cs=> cs.CookieStandId == id);
			if(cookieStand != null) return cookieStand;
			return null;

		}

		public Task<List<GetCookieStand>> GetCookieStands()
		{
			throw new NotImplementedException();
		}

		public Task<CookieStand> Update(UpdateCookieStand UpdateCookieStand)
		{
			throw new NotImplementedException();
		}
	}
}
