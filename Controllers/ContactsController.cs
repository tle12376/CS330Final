using CS330Final.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS330Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authenticator]
    public class ContactsController : ControllerBase
    {
        private static int currentID = 1;
        private static List<Contact> contacts = new List<Contact>();

        // GET: api/<ContactsController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Get specific
            var contact = contacts.FirstOrDefault(t => t.Id == id);
            if (contact == null)
            { return NotFound(); }
            else
            {
                return Ok(contact);
            }
            
        }

        // POST api/<ContactsController>
        [HttpPost]
        public IActionResult Post([FromBody] Contact value)
        {

            if (string.IsNullOrEmpty(value.Email) || string.IsNullOrEmpty(value.UserPassword))
            {
                var errorResponse = new ErrorResponse
                {
                    DBCode = ErrorType.MissingField,
                    Message = "Null or Empty Email or Password",
                    FieldName = "Email or Password",
                };
                return BadRequest(errorResponse);
            }
            value.Id = currentID++;
            value.CreatedDate = DateTime.Now;
            contacts.Add(value);

            // Look at the "Location" header in the response output in Postman
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact value)
        {
            //var contact = contacts.FirstOrDefault(t =>t.Id == id);
            //if (contact == null)
            //{
            //    return NotFound();
            //}
            if (string.IsNullOrEmpty(value.Email) || string.IsNullOrEmpty(value.UserPassword))
            {
                var errorResponse = new ErrorResponse
                {
                    DBCode = ErrorType.MissingField,
                    Message = "Null or Empty Email or Password",
                    FieldName = "Email or Password",
                };
                return BadRequest(errorResponse);
            }
            else
            {
                var contact = contacts.FirstOrDefault(t => t.Id == id);
                contact.Email = value.Email;
                contact.UserPassword = value.UserPassword;

                return Ok(contact);
            }
            //contact.Name = value.Name;
            //return Ok(contact);

        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rowsDeleted = contacts.RemoveAll(t => t.Id == id);
            if (rowsDeleted == 0)
            { return NotFound(); }
            else 
            { return Ok(rowsDeleted); }
        }
    }
}
