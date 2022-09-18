using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Data.Repositories
{
    public class RoomService : IRoomService
    {
        private readonly HogwartsContext _context;

        public RoomService(HogwartsContext context)
        {
            _context = context;
        }
        public async Task AddRoom(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();

        }

        public async Task<Room> GetRoom(long roomId)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.ID == roomId);
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public void UpdateRoom(long id, Room room)
        {
            var roomToUpdate = GetRoom(id).Result;
            if (roomToUpdate != null)
            {
                room.ID = roomToUpdate.ID;
                _context.Entry(roomToUpdate).State = EntityState.Detached;
                _context.Entry(room).State = EntityState.Modified;
                _context.Rooms.Update(room);
                _context.SaveChanges();
            }
            
        }

        public async Task DeleteRoom(long id)
        {
            var roomToDelete = await GetRoom(id);
            if (roomToDelete != null)
            {
                _context.Rooms.Remove(roomToDelete);
                await _context.SaveChangesAsync();
            }


        }

        public async Task<List<Room>> GetRoomsForRatOwners()
        {
            return await _context.Rooms
                .Where(r => r.Residents.All(s => s.PetType != PetType.Cat && s.PetType != PetType.Owl) ).ToListAsync();
        }

    
    }
}
