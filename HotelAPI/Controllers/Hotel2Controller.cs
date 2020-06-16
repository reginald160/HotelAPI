using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Models;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Hotel2Controller : ControllerBase
    {
        private readonly IHotel _hotelContext;
        public Hotel2Controller(IHotel hotel) => _hotelContext = hotel;


        // GET: api/<Hotel2Controller>
        [HttpGet]
        public IEnumerable<Hotel> GetAll()
        {
            return _hotelContext.GetAll();
        }

        // GET api/<Hotel2Controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] long  Id)
        {

            var hotel = await _hotelContext.Get(Id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }


        [HttpPost]
        public async Task<IActionResult> PostHotel([FromBody] Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
      

            await _hotelContext.Add(hotel);
            return Ok(hotel);
        }


        // POST api/<Hotel2Controller>
        [HttpPut]
        public async Task<IActionResult> PutHotel([FromRoute]long Id, Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Id != hotel.Id)
            {
                return BadRequest("Hotel ID does not exist");
            }

            await _hotelContext.Update(hotel);
            return NoContent();
        }

        // PUT api/<Hotel2Controller>/5
        //[HttpDelete("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<Hotel2Controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(long Id)
        {
            await _hotelContext.Delete(Id);
                return Ok();
        }
    }
}
