using HotelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Services
{
   public interface IHotel
    {
        public IEnumerable<Hotel> GetAll();
        public Task<Hotel> Get(long Id);

        public Task<Hotel> Add(Hotel hotel);

        public Task<Hotel> Update(Hotel hotelChanges);
        public Task<Hotel> Delete(long Id);
    }
}
