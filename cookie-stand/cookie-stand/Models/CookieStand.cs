namespace cookie_stand.Models
{
	public class CookieStand
	{
        public int CookieStandId { get; set; }
		public string Location { get; set; }
		public int Minimum_customers_per_hour { get; set; }
		public int Maximum_customers_per_hour { get; set; }
		public int Average_cookies_per_sale { get; set; }
		//np
		List<CookiStandHourlySale>? cookiStandnHourlysales { get; set; }


	}
}
