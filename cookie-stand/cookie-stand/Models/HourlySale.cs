namespace cookie_stand.Models
{
	public class HourlySale
	{
        public int HourlySaleId { get; set; }
		public int Time { get; set;}
		//NP
		List<CookiStandHourlySale>? cookiStandnHourlysales { get; set; }	
    }
}
