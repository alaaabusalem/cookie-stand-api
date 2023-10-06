using cookie_stand.Models.DTOs;

namespace cookie_stand.Models.Interfaces
{
	public interface ICookieStand
	{
		Task<CookieStand> Creat(CreatCookieStand creatCookieStand);
		Task<CookieStandDTO> Update(UpdateCookieStand UpdateCookieStand);
		Task<GetCookieStand> GetCookieStand( int id);
		Task<List<GetCookieStand>> GetCookieStands();
		Task<bool> Delete(int id);



	}
}
