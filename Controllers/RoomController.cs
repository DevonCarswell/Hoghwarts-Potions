using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Data;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HogwartsPotions.Controllers
{
    [ApiController, Route("[Controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomRepository;
        private readonly IStudentService _studentRepository;

        public RoomController(IRoomService roomRepository, IStudentService studentRepository)
        {
            _roomRepository = roomRepository;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<List<Room>> GetAllRooms()
        {
            return await _roomRepository.GetAllRooms();
        }

        [HttpPost]
        public async  Task AddRoom([FromBody] Room room)
        {
            await _roomRepository.AddRoom(room);
        }

        [HttpGet("/{id}")]
        public async Task<Room> GetRoomById(long id)
        {
            return await _roomRepository.GetRoom(id);
        }

        [HttpPut("{id}")]
        public void UpdateRoomById(long id, [FromBody] Room updatedRoom)
        {
            var students = _roomRepository.GetRoom(id).Result.Residents;
            _studentRepository.UpdateStudentRoomId(students);
            _roomRepository.UpdateRoom(id,updatedRoom);
        }

        [HttpDelete("{id}")]
        public async Task DeleteRoomById(long id)
        {
            await _roomRepository.DeleteRoom(id);
        }

        [HttpGet("rat-owners")]
        public async Task<List<Room>> GetRoomsForRatOwners()
        {
            return await _roomRepository.GetRoomsForRatOwners();
        }

    }
}
