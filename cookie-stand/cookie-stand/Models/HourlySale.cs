namespace cookie_stand.Models
{
	public class HourlySale
	{
        public int HourlySaleId { get; set; }
		public int Time { get; set;}
		//NP
		public List<CookiStandHourlySale>? cookiStandnHourlysales { get; set; }	
    }
}
