using HotelAPI.Data;
using HotelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Services
{
    public class HotelRepository : IHotel
    {
        private readonly DataDBContext _context;

        public HotelRepository(DataDBContext hotelData)
        {
            _context = hotelData;
        }
        public async Task<Hotel> Add( Hotel hotel)
        {
            _context.HotelTable.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> Delete(long Id)
        {
            Hotel hotel = _context.HotelTable.Find(Id);
            if (hotel != null)
            {
                _context.HotelTable.Remove(hotel);
                 await _context.SaveChangesAsync();

            }
            return hotel;
        }

        public async Task<Hotel> Get(long Id)
        { 
            return await _context.HotelTable.FindAsync(Id);
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _context.HotelTable;
        }

        public async Task<Hotel> Update(Hotel hotelChanges)
        {
            _context.HotelTable.Update(hotelChanges);
            await _context.SaveChangesAsync();

            return hotelChanges;
        }
    }
}
