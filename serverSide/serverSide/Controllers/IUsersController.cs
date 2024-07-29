using Microsoft.AspNetCore.Mvc;
using serverSide.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IUsersController : ControllerBase
    {
        // GET: api/<IUsersController>
        [HttpGet]
        public IEnumerable<Book> Get(int userId)
        {
            return IUser.showMyBooks(userId);
 
        }

        // GET api/<IUsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IUsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        // POST api/<IUsersController>
        [HttpPost("addNewBookToUser")]
        public void Post( int userId, int bookId)
        {
            IUser.addNewBook(userId, bookId);
        }

        // PUT api/<IUsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IUsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
