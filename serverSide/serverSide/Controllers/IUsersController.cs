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

        // GET get the loggedin user name
        [HttpGet("getUserName")]
        public string Get(int id)
        {
            return "value";
        }

        // POST sign up new user
        [HttpPost("signUpNewUser")]
        public bool Post([FromBody] IUser newUser)
        {
            return newUser.Insert(newUser);
        }
        // POST api/<IUsersController>
        [HttpPost("addNewBookToUser")]
        public void Post( int userId, int bookId)
        {
            IUser.addNewBook(userId, bookId);
        }

        // PUT logout user by id
        [HttpPut("logoutUser")]
        public bool Put([FromBody] int userId)
        {
            return IUser.Logout(userId);
        }

        // PUT login user
        [HttpPut("loginUser")]
        public IActionResult Put([FromBody] IUser user)
        {
            int loggedinUserId = IUser.Login(user);

            if (loggedinUserId != 0) { return Ok(loggedinUserId); }

            else { return BadRequest(); }
        }
        // PUT book as read by user 
        [HttpPut("readBookByUser")]
        public bool Put(int bookId, int userId)
        {
            return IUser.readBook(bookId, userId);
        }

        // DELETE api/<IUsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
