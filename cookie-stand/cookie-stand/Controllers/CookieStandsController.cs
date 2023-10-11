using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cookie_stand.Data;
using cookie_stand.Models;
using cookie_stand.Models.Interfaces;
using cookie_stand.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace cookie_stand.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    
    public class CookieStandsController : ControllerBase
    {
        private readonly ICookieStand _context;

        public CookieStandsController(ICookieStand context)
        {
            _context = context;
        }

		[Route("api/CookieStands")]
		// GET: api/CookieStands
		[HttpGet]
        public async Task<ActionResult<IEnumerable<GetCookieStand>>> GetCookieStands()
        {
          if ( await _context.GetCookieStands() == null)
          {
              return NotFound();
          }
          
            return await _context.GetCookieStands(); ;

		}

		[Route("api/CookieStand/{id}")]

		// GET: api/CookieStands/5
		[HttpGet("{id}")]
        public async Task<ActionResult<GetCookieStand>> GetCookieStand(int id)
        {
			var cookieStand = await _context.GetCookieStand(id);
			if (cookieStand == null)
          {
              return NotFound();
          }
       
            return cookieStand;
        }
		[Authorize(Roles = "admin")]

		[Route("api/CookieStand/{id}")]

		// PUT: api/CookieStands/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
        public async Task<IActionResult> PutCookieStand(int id, UpdateCookieStand cookieStand)
        {
            if (id != cookieStand.CookieStandId)
            {
                return BadRequest();
            }

			var cookieStandToUpdate = await _context.Update(cookieStand);

			
                if (cookieStandToUpdate == null)
                {
                    return NotFound();
                }
            return Ok();
            

        }
		[Route("api/CookieStand")]
		[Authorize(Roles = "admin")]

		// POST: api/CookieStands
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
        public async Task<ActionResult<CookieStand>> PostCookieStand(CreatCookieStand cookieStand)
        {
            var stand = await _context.Creat(cookieStand);
          if (stand == null)
          {
              return Problem("Entity set 'CookiStandDB.CookieStands'  is null.");
          }


            //return RedirectToAction("GetCookieStand", new { id = stand.CookieStandId });
            return Ok();
        }

		[Route("api/CookieStand/{id}")]

		// DELETE: api/CookieStands/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]

		public async Task<IActionResult> DeleteCookieStand(int id)
        {
            bool result = await _context.Delete(id);
            if (result == false)
            {
                return NotFound();
            }
            

            return NoContent();
        }

      
    }
}
