using Microsoft.AspNetCore.Mvc;
using questionariobackend.Data;
using questionariobackend.Model;

namespace questionariobackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RespuestaController : ControllerBase
    {

        private readonly AppDbContext _context;

        public RespuestaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Respuesta);
        }

        [HttpPost]
        [Route("")]
        public IActionResult addRespuesta(Respuesta respuesta)
        {
            if (respuesta == null)
            {
                throw new ArgumentNullException();
            }
            int questionId = respuesta.QuestionId;
            int userId = respuesta.UserId;

            if (_context.Users.First(user => user.Id == userId) == null)
            {
                return BadRequest("User reference not found");
            }
            if (_context.Question.First(question => question.Id == questionId) == null)
            {
                return BadRequest("respuesta reference not found");
            }

            if (respuesta.Tipo == "boolean")
            {
                if (respuesta.Contenido != "true" || respuesta.Contenido != "false")
                {
                    return BadRequest(respuesta.Contenido + " not allowed for response type boolean");
                }
            }
            else if (respuesta.Tipo == "number")
            {
                try
                {
                    int parsed = Convert.ToInt32(respuesta.Contenido);
                    if (parsed < 0 || parsed > 10)
                    {
                        return BadRequest(respuesta.Contenido + " number not allowed for response type number(min 0, max 10)");
                    }
                }
                catch (FormatException e)
                {
                    return BadRequest(respuesta.Contenido + " its not allowed for response type number");
                }
            }
            else if (respuesta.Tipo != "multChoice")
            {
                return BadRequest("type not allowed");
            }
            _context.Respuesta.Add(respuesta);
            _context.SaveChanges();
            return this.CreatedAtAction(nameof(GetRespuestaById), new { id = respuesta.Id }, respuesta);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRespuestaById(int id)
        {
            Respuesta respuesta = _context.Respuesta.First((respuesta) => respuesta.Id == id);
            if (respuesta == null)
            {
                return NotFound();
            }
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteRespuestaById(int id)
        {
            Respuesta toRemove = _context.Respuesta.First((respuesta) => respuesta.Id == id);


            _context.Respuesta.Remove(toRemove);
            _context.SaveChanges();
        }

    }
}
