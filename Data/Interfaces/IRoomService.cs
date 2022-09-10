using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsPotions.Interfaces
{
    public interface IRoomService
    {
        Task AddRoom(Room room);
        Task<Room> GetRoom(long roomId);
        Task<List<Room>> GetAllRooms();
        void UpdateRoom(long id, Room room);
        Task DeleteRoom(long id);
        Task<List<Room>> GetRoomsForRatOwners();
    }
}
