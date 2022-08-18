using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models.Entities;

namespace HogwartsPotions.Interfaces
{
    public interface IRoomRepository
    {
        Task AddRoom(Room room);
        Task<Room> GetRoom(long roomId);
        Task<List<Room>> GetAllRooms();
        Task UpdateRoom(Room room);
        Task DeleteRoom(long id);
        Task<List<Room>> GetRoomsForRatOwners();
        void Update(Room updatedRoom);
    }
}
