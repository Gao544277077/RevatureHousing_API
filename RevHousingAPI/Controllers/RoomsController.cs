using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RHEntities;
using RevHousingAPI.Data;
using RevHousingAPI.Repositories;
using Microsoft.AspNetCore.Cors;
using RevHousingAPI.IRepositories;

namespace RevHousingAPI.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class RoomsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IRoomRepository repo;

        public RoomsController(ApplicationDBContext context, IRoomRepository roomRepository)
        {
            _context = context;
            repo = roomRepository;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<IEnumerable<Room>> GetRoom()
        {
            return repo.GetAll();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            return repo.Get(id);
            *//*var room = await _context.Room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;*//*
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int? id, Room room)
        {
            repo.Update(room);
            //repo.SaveChanges();

            return NoContent();
            *//*if (id != room.RoomID)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();*//*
        }

        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            repo.Add(room);
            //repo.SaveChanges();

            return StatusCode(201);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(Room room)
        {
           // bool isRemoved = repo.RemoveRoom(room.RoomID);
            //if (isRemoved == false)
           // {
            //    return NotFound();
           // }
            //repo.SaveChanges();

            return room;
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.RoomID == id);
        }
    }*/
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult<List<Room>> GetRooms()
        {
            return roomRepository.GetAll().ToList();
        }

        // GET: api/rooms/5
        [HttpGet("{id}")]
        public ActionResult<Room> GetRoom(int id)
        {
            var room = roomRepository.Get(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/rooms/5
        [HttpPut("{id}")]
        public ActionResult UpdateRoom(int id, Room room)
        {
            if (id != room.RoomID)
            {
                return BadRequest();
            }

            try
            {
                roomRepository.Update(room);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/rooms
        [HttpPost]
        public ActionResult<Room> AddRoom(Room room)
        {
            roomRepository.Add(room);
            return CreatedAtAction("GetRoom", new { id = room.RoomID }, room);
        }

        public bool roomExists(int id)
        {
            return roomRepository.GetAll().Any(e => e.RoomID == id);
        }
    }
}
