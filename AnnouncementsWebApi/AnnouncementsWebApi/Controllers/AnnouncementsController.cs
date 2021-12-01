using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataAccessLayer;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnnouncementsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        AnnouncementRepository repository;

        public AnnouncementsController(AnnouncementRepository rep)
        {
            repository = rep;
        }

        [HttpGet]
        public async Task<IEnumerable<Announcement>> Get()
        {
            return await repository.GetAll();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Announcement>> Get(int id)
        {
            Announcement result = await repository.GetAnnouncement(id);

            if (result == null) return NotFound();
            else return result;
        }

        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Announcement ann)
        {
            ann.CreateDate = System.DateTime.Now;

            await repository.AddAnnouncement(ann);
            return CreatedAtAction("Get", new { id = ann.AnnouncementId }, ann);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Announcement value)
        {
            if(id != value.AnnouncementId) return BadRequest();

            try
            {
                await repository.EditAnnouncement(value);
            }
            catch
            {
                return BadRequest();
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Announcement>> Delete(int id)
        {
            var anno = await repository.GetAnnouncement(id);
            if(anno == null) return BadRequest();

            await repository.RemoveAnnouncement(anno);
            return anno;

        }
    }
}
