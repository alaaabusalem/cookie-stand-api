namespace cookie_stand.Models
{
	public class CookiStandHourlySale
	{
		public int HourlySaleId { get; set; }
		public int CookieStandId { get; set; }
        public int Value { get; set; }
        //NP
        public HourlySale? hourly_Sale { get; set; }
		public CookieStand? cookie_Stand { get; set; }

	}
}
