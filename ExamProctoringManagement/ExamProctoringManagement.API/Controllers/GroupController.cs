using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Request;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProctoringManagement.API.Controllers
{

    public class GroupController : BaseApiController
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(string id)
        {
            var group = await _groupService.GetGroupByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return group;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetAllGroups()
        {
            var groups = await _groupService.GetAllGroupsAsync();
            return Ok(groups);
        }

        [HttpPost]
        public async Task<ActionResult<Group>> CreateGroup([FromBody] Group group)
        {
            var createdGroup = await _groupService.CreateGroupAsync(group);
            return CreatedAtAction(nameof(GetGroup), new { id = createdGroup.GroupId }, createdGroup);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(string id, [FromBody] Group group)
        {
            if (id != group.GroupId)
            {
                return BadRequest();
            }

            await _groupService.UpdateGroupAsync(group);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(string id)
        {
            await _groupService.DeleteGroupAsync(id);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<ActionResult<GroupWithListRoomsDto>> CreateGroupAndGroupRooms([FromBody] CreateGroupAndRoomsRequest createGroupAndRoomsRequest)
        {
            var groups = await _groupService.GetAllGroupsAsync();
            List<GroupWithListRoomsDto> dtos = new List<GroupWithListRoomsDto>();

            foreach (var group in groups)
            {
                if (group.GroupId == createGroupAndRoomsRequest.Group.GroupId)
                {
                    return BadRequest("GroupId đã tồn tại.");
                }
            }

            if (createGroupAndRoomsRequest.GroupRoomIds.Count() != createGroupAndRoomsRequest.RoomIds.Count())
            {
                return BadRequest("Số lượng GroupRoomIds và RoomIds không khớp.");
            }

            if (createGroupAndRoomsRequest.RoomIds.Count() > 3 || createGroupAndRoomsRequest.RoomIds.Count() == 0)
            {
                return BadRequest("Số lượng Room từ 1 đến 3.");
            }

            foreach (var existingGroup in groups)
            {
                var existingDto = await _groupService.GetGroupWithListRoomsAsync(existingGroup.GroupId);
                dtos.Add(existingDto);
            }

            foreach (var oldDto in dtos)
            {
                var existingRoomIds = oldDto.rooms.Select(r => r.RoomId).ToList();
                if (existingRoomIds.Count == createGroupAndRoomsRequest.RoomIds.Count &&
                    !existingRoomIds.Except(createGroupAndRoomsRequest.RoomIds).Any())
                {
                    return BadRequest("Một Group với cùng danh sách Rooms đã tồn tại.");
                }
            }

            var createdGroup = await _groupService.CreateGroupAndGroupRoomAsync(createGroupAndRoomsRequest);
            var dto = await _groupService.GetGroupWithListRoomsAsync(createdGroup.GroupId);
            return CreatedAtAction(nameof(GetGroup), new { id = dto.groupId }, dto);
        }

        [HttpGet("rooms/{id}")]
        public async Task<ActionResult<GroupWithListRoomsDto>> GetGroupWithListRooms(string id)
        {
            var group = await _groupService.GetGroupWithListRoomsAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return group;
        }
    }
}
