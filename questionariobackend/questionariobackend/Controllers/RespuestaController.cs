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
        public IActionResult addRespuesta([FromBody] Respuesta respuesta)
        {
            if (respuesta == null)
            {
                throw new ArgumentNullException();
            }
            Questions pregunta = null;
            User usuario = null;
            try
            {
                usuario = _context.Users.First(user => user.Id == respuesta.UserId);
                pregunta = _context.Question.First(question => question.Id == respuesta.QuestionId);
            }
            catch (Exception e) { }


            if (usuario == null)
            {
                return BadRequest("User reference not found");

            }
            if (pregunta == null)
            {
                return BadRequest("respuesta reference not found");
            }
            if (!pregunta.Tipo.Equals(respuesta.Tipo))
            {
                return BadRequest("Types of the question and the response do not match");
            }

            if (respuesta.Tipo == "boolean")
            {
                if (!respuesta.Contenido.Equals("true") && !respuesta.Contenido.Equals("false"))
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
                    return BadRequest(respuesta.Contenido + " its not allowed for response type number (NaN)");
                }
            }
            else if (respuesta.Tipo != "multChoice")
            {
                return BadRequest("Response type not allowed");
            }
            _context.Respuesta.Add(respuesta);
            _context.SaveChanges();
            return this.CreatedAtAction(nameof(GetRespuestaById), new { id = respuesta.Id }, respuesta);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRespuestaById(int id)
        {
            Respuesta respuesta = null;
            try
            {
                respuesta = _context.Respuesta.First((respuesta) => respuesta.Id == id);
            }
            catch (InvalidOperationException e)
            {
                return NotFound();
            }

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteRespuestaById(int id)
        {
            Respuesta respuesta = null;
            try
            {
                respuesta = _context.Respuesta.First((respuesta) => respuesta.Id == id);
            }
            catch (InvalidOperationException e)
            {
                return NotFound();
            }


            _context.Respuesta.Remove(respuesta);
            _context.SaveChanges();

            return Ok();
        }

    }
}
