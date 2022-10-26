using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using questionariobackend.Data;
using questionariobackend.Model;
using System.Collections;
using System.Web.Http.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToArray<User>();
        }



        // GET api/<UserController>/5
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

        // User api/<UserController>
        [HttpPost]
        public void User([FromBody] User value)
        {
            _context.Users.Add(value);
            _context.SaveChanges();
        }

        [HttpPost("/login")]
        public bool Login([FromBody] Account value)
        {
            try {
            User account = _context.Users.First(x => x.Email == value.email);

            if (account.Password== value.pass)
            {
                return true;
            }
            else{
                return false;
            }
            }
            catch
            {
                return false;
            }
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody][Bind("Id,Title,Body,Category")] User value)
        {
            value.Id = id;
            _context.Update(value);

            _context.SaveChanges();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            _context.Respuesta.AsQueryable().ForEachAsync((respuesta) =>
            {
                if (respuesta.UserId == id)
                {
                    _context.Respuesta.Remove(respuesta);
                }
            });

            _context.Users.Remove(Get(id));
            _context.SaveChanges();
        }

        // GET api/<UserController>/5/responses
        [HttpGet("{id}/responses")]
        public IActionResult GetUserResponses(int id)
        {
            ArrayList respuestas = new ArrayList();
            _context.Respuesta.AsQueryable().ForEachAsync((respuesta) =>
            {
                if (respuesta.UserId == id)
                {
                    respuestas.Add(respuesta);
                }
            });

            return Ok(respuestas);
        }
    }
}
