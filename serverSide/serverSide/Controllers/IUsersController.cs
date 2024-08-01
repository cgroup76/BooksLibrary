using Microsoft.AspNetCore.Mvc;
using serverSide.BL;
using System.Dynamic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IUsersController : ControllerBase
    {
        // GET: api/<IUsersController>
        [HttpGet]
        public List<dynamic> Get(int userId)
        {
            return IUser.showMyBooks(userId);

        }
        // GET: api/<IUsersController>
        [HttpGet("GetRequestsPerUser")]
        public List<dynamic> GetRequestsPerUser(int userId)
        {
            return IUser.getRequestsPerUser(userId);
        }

        // POST sign up new user
        [HttpPost("signUpNewUser")]
        public IActionResult Post([FromBody] IUser newUser)
        {
            int newUserId = newUser.Insert(newUser);

            if (newUserId != 0)
            {
                dynamic userDetails = new ExpandoObject();

                userDetails.userId = newUserId;
                userDetails.userName = newUser.UserName;

                return Ok(userDetails);
            }
            return BadRequest();
        }
        // POST api/<IUsersController>
        [HttpPost("addNewBookToUser")]
        public IActionResult Post(int userId, int bookId)
        {
            int status = IUser.addNewBook(userId, bookId);

            if (status == 1) { return Ok(true); }

            else if (status == 0) { return NotFound(false); }

            return Unauthorized("user session has ended");
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

            else { return NotFound(); }
        }
        // PUT book as read by user 
        [HttpPut("readBookByUser")]
        public IActionResult Put(int bookId, int userId)
        {
            int status = IUser.readBook(bookId, userId);

            if (status == 1) { return Ok(true); }

            else if (status == 0) { return NotFound(false); }

            return Unauthorized("user session has ended");
        }
        //// PUT sale and buy books
        //[HttpPut("saleAndBuyBook")]
        //public bool Put(int buyerId, int sellerId, int bookId)
        //{
        //    return IUser.saleAndBuyBook(buyerId, sellerId, bookId);
        //}
        // DELETE api/<IUsersController>/5

        // POST insert new request
        [HttpPost("insertNewRequest")]
        public bool POST(int sellerId, int buyerId, int bookId)
        {
            return IUser.insertNewRequest(sellerId, buyerId, bookId);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)

        {
        }

        // PUT sale and buy books
        [HttpPut("requestHandling")]
        public bool Put(int buyerId, int sellerId, int bookId, string requeststatus)
        {
            return IUser.requestHandling(buyerId, sellerId, bookId, requeststatus);
        }



    }
}
