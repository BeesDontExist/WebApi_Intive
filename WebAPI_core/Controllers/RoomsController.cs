using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_core.Models;

namespace WebAPI_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly RoomsContext _context;
        public RoomsController(RoomsContext context)
        {
            _context = context;
            
            if(_context.Rooms.Count()==0)
            {
                _context.Rooms.Add(new Room { Owner = "Kowalski", Capacity = 20 });
                _context.SaveChanges();
            }
        }

        //GET: api/Rooms
        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        //GET: api/Rooms/{id}
        [HttpGet("{id}")]
        public ActionResult<Room> GetRoomByID(int id)
        {
            var RoomItem = _context.Rooms.Find(id);
            if (RoomItem == null)
            {
                return NotFound();
            }
            else
            {
                return RoomItem;
            }
        }
        //POST: api/Rooms
        [HttpPost]
        public ActionResult<Room> PostRoom(Room roomItem)
        {
            _context.Rooms.Add(roomItem);
            _context.SaveChanges();
            return NoContent(); //brak uzycia CreateAtAction() z powodu bledu - obiekt zostaje pomyslnie utworzony, ale server zwraca: InvalidOperationException: No route matches the supplied values.
        }
        //PUT: api/Rooms/{id}
        [HttpPut("{id}")]
        public ActionResult<Room> PutRoom(int id, Room roomItem)
        {
            if (id != roomItem.Id)
                return BadRequest();
            _context.Entry(roomItem).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        //PATCH:

        //DELETE: api/Rooms/{id}
        [HttpDelete("{id}")]
        public ActionResult<Room> DeleteRoom(int id)
        {
            var roomItem = _context.Rooms.Find(id);
            if (roomItem == null)
                return NotFound();
            _context.Rooms.Remove(roomItem);
            _context.SaveChanges();
            return roomItem;
        }
    }
}
