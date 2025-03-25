using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using AngularProject.Models;

using Microsoft.AspNetCore.Cors;



namespace AngularProject.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    [EnableCors("allowCors")]

    public class ContactController : ControllerBase

    {

        private readonly ApplicationDbContext _context;



        public ContactController(ApplicationDbContext context)

        {

            _context = context;

        }



        // GET: api/Contact 

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()

        {

            return await _context.Contacts.ToListAsync();

        }



        // GET: api/Contact/5 

        [HttpGet("{id}")]

        public async Task<ActionResult<Contact>> GetContact(int id)

        {

            var contact = await _context.Contacts.FindAsync(id);



            if (contact == null)

            {

                return NotFound();

            }



            return contact;

        }



        // PUT: api/Contact/5 

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateContact(int id, Contact contact)

        {

            if (id != contact.Id)

            {

                return BadRequest();

            }



            _context.Entry(contact).State = EntityState.Modified;



            try

            {

                await _context.SaveChangesAsync();

            }

            catch (DbUpdateConcurrencyException)

            {

                if (!ContactExists(id))

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



        // POST: api/Contact 

        [HttpPost]

        public async Task<ActionResult<Contact>> CreateContact(Contact contact)

        {

            _context.Contacts.Add(contact);

            await _context.SaveChangesAsync();



            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);

        }



        // DELETE: api/Contact/5 

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteContact(int id)

        {

            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)

            {

                return NotFound();

            }



            _context.Contacts.Remove(contact);

            await _context.SaveChangesAsync();



            return NoContent();

        }



        private bool ContactExists(int id)

        {

            return _context.Contacts.Any(c => c.Id == id);

        }

    }

}

