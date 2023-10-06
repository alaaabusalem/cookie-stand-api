using cookie_stand.Models.DTOs;

namespace cookie_stand.Models.Interfaces
{
	public interface ICookieStand
	{
		Task<CookieStand> Creat(CreatCookieStand creatCookieStand);
		Task<CookieStand> Update(UpdateCookieStand UpdateCookieStand);
		Task<GetCookieStand> GetCookieStand( int id);
		Task<List<GetCookieStand>> GetCookieStands();
		Task Delete(int id);



	}
}
