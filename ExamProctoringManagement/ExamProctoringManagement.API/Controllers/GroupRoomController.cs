using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupRoomController : BaseApiController
    {
        private readonly IGroupRoomService _GroupRoomService;

        public GroupRoomController(IGroupRoomService GroupRoomService)
        {
            _GroupRoomService = GroupRoomService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupRoom>> GetGroupRoom(string id)
        {
            var GroupRoom = await _GroupRoomService.GetGroupRoomByIdAsync(id);
            if (GroupRoom == null)
            {
                return NotFound();
            }
            return GroupRoom;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupRoom>>> GetAllGroupRooms()
        {
            var GroupRooms = await _GroupRoomService.GetAllGroupRoomsAsync();
            return Ok(GroupRooms);
        }

        [HttpPost]
        public async Task<ActionResult<GroupRoom>> CreateGroupRoom(GroupRoom GroupRoom)
        {
            var createdGroupRoom = await _GroupRoomService.CreateGroupRoomAsync(GroupRoom);
            return CreatedAtAction(nameof(GetGroupRoom), new { id = createdGroupRoom.GroupRoomId }, createdGroupRoom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroupRoom(string id, GroupRoom GroupRoom)
        {
            if (id != GroupRoom.GroupRoomId)
            {
                return BadRequest();
            }

            await _GroupRoomService.UpdateGroupRoomAsync(GroupRoom);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupRoom(string id)
        {
            await _GroupRoomService.DeleteGroupRoomAsync(id);
            return NoContent();
        }
    }
}
