using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HogwartsContext _context;

        public RoomRepository(HogwartsContext context)
        {
            _context = context;
        }
        public async Task AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

        }

        public Task<Room> GetRoom(long roomId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Room>> GetAllRooms()
        {
            return _context.Rooms.ToListAsync();
        }

        public Task UpdateRoom(Room room)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteRoom(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Room>> GetRoomsForRatOwners()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Room updatedRoom)
        {
            throw new System.NotImplementedException();
        }
    }
}
