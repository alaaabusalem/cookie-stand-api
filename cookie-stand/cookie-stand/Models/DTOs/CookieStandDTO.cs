namespace cookie_stand.Models.DTOs
{
	public class CookieStandDTO
	{
		public int CookieStandId { get; set; }

		public string Location { get; set; }
		public int Minimum_customers_per_hour { get; set; }
		public int Maximum_customers_per_hour { get; set; }
		public int Average_cookies_per_sale { get; set; }
	}
	public class CreatCookieStand
	{

		public string Location { get; set; }
		public int Minimum_customers_per_hour { get; set; }
		public int Maximum_customers_per_hour { get; set; }
		public int Average_cookies_per_sale { get; set; }

	}
	public class UpdateCookieStand
	{
		public int CookieStandId { get; set; }

		public string Location { get; set; }
		public int Minimum_customers_per_hour { get; set; }
		public int Maximum_customers_per_hour { get; set; }
		public int Average_cookies_per_sale { get; set; }

	}
	public class GetCookieStand
	{
		public int CookieStandId { get; set; }

		public string Location { get; set; }
		public int Minimum_customers_per_hour { get; set; }
		public int Maximum_customers_per_hour { get; set; }
		public int Average_cookies_per_sale { get; set; }
		public List<int> hourly_sales { get; set; }	
	}
}
