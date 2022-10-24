using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Hosting;
using questionariobackend.Data;
using questionariobackend.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{


    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<PostsController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToArray<User>();
        }



        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            try
            {
                return _context.Users.FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                return new User();
            }
        }

        // User api/<PostsController>
        [HttpPost]
        public void User([FromBody] User value)
        {
            _context.Users.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody][Bind("Id,Title,Body,Category")] User value)
        {
            value.Id = id;
            _context.Update(value);

            _context.SaveChanges();
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Users.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
