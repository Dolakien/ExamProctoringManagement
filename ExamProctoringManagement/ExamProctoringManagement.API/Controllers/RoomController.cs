using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{

    public class RoomController : BaseApiController
    {
        private readonly IRoomService _RoomService;

        public RoomController(IRoomService RoomService)
        {
            _RoomService = RoomService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(string id)
        {
            var Room = await _RoomService.GetRoomByIdAsync(id);
            if (Room == null)
            {
                return NotFound();
            }
            return Room;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRooms()
        {
            var Rooms = await _RoomService.GetAllRoomsAsync();
            return Ok(Rooms);
        }

        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom([FromBody] RoomDTO Room)
        {
            var createdRoom = await _RoomService.CreateRoomAsync(Room);
            return Ok(createdRoom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(string id, [FromBody] RoomDTO Room)
        {
            if (id != Room.RoomId)
            {
                return BadRequest();
            }

            await _RoomService.UpdateRoomAsync(Room);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(string id)
        {
            await _RoomService.DeleteRoomAsync(id);
            return NoContent();
        }
    }
}
