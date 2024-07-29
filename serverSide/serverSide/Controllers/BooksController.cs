using Microsoft.AspNetCore.Mvc;
using serverSide.BL;
using System.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET - get all books
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return Book.showBooks();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST add new book to DB
        [HttpPost("AddNewBook")]
        public bool Post([FromBody] Book newBook)
        {
            return newBook.AddNewBook(newBook);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


}
