using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using simplecrud.Database;

namespace simplecrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ParticipantController : ControllerBase{
        private readonly DBContext _context;
        public ParticipantController(DBContext context){
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
           return Ok(_context.Participant.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var par = _context.Participant.Find(id);
            if (par == null) {
                return NotFound();
            }
            return Ok(par);
        }

        [HttpPost]
        public IActionResult CreateParticipant(Participant participant){
            try{
                _context.Participant.Add(participant);
                _context.SaveChanges();
                return Ok(participant);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateParticipant(Participant participant){
            _context.Participant.Update(participant);
            _context.SaveChanges();
            return Ok(participant);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteParticipant(int id){
            var participant = _context.Participant.Find(id);
            _context.Participant.Remove(participant);
            _context.SaveChanges();
            return Ok(participant);
        }
    }
}