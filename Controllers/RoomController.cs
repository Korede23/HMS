using HMS.Dto.RequestModel;
using HMS.Implementation.Interface;
using HMS.Implementation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpPost("create-room")]
        public async Task<IActionResult> CreateRoom(CreateRoom request)
        {
            var room = await _roomService.CreateRoom(request);
            if (room.Success == true)
            {
                return Ok(room);
            }
            else
            {
                return BadRequest(room.Success == false);
            }

        }

        [HttpPost("edit-room")]
        public async Task<IActionResult> EditRoom([FromBody] UpdateRoom request)
        {

            var room = await _roomService.UpdateRoom(request.Id, request);
            if (room.Success == true)
            {
                return Ok(room);
            }
            else
            {
                return BadRequest(room.Success == false);
            }
        }

        [HttpDelete("delete-room")]
        public async Task<IActionResult> DeleteRoomAsync([FromRoute] int id)
        {
            var room = await _roomService.DeleteRoomAsync(id);
            if (room.Success == true)
            {
                return Ok(room);
            }
            return BadRequest(room.Success == false);

        }
        [HttpGet("get-all-rooms-created")]
        public async Task<IActionResult> GetAllRoomsCreatedAsync()
        {
            var rooms = await _roomService.GetAllRoomsCreatedAsync();
            if (rooms.Success == true)
            {
                return Ok(rooms);
            }
            else
            {
                return BadRequest(rooms.Success == false);
            }


        }

        [HttpGet("get-room-by-id/{id}")]
        public async Task<IActionResult> GetRoomsByIdAsync(int id)
        {

            var rooms = await _roomService.GetRoomsByIdAsync(id);
            if (rooms.Success == true)
            {
                return Ok(rooms);
            }
            else
            {
                return BadRequest(rooms.Success == false);
            }

        }


    }
}
