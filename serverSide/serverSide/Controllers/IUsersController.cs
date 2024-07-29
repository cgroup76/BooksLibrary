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
            object loggedinUserDetails = IUser.Login(user);

            if (((IDictionary<string, object>)loggedinUserDetails).Any()) { return Ok(loggedinUserDetails); } // checks if the object is not empty

            else { return BadRequest(); }
        }
        // PUT book as read by user 
        [HttpPut("readBookByUser")]
        public bool Put(int bookId, int userId)
        {
            return IUser.readBook(bookId, userId);
        }
        // PUT sale and buy books
        [HttpPut("saleAndBuyBook")]
        public bool Put(int buyyerId, int sellerId, int bookId)
        {
            return IUser.saleAndBuyBook(buyyerId, sellerId, bookId);
        }
        // DELETE api/<IUsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
