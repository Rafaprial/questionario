using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using questionariobackend.Data;
using questionariobackend.Model;

namespace questionariobackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class QuestionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuestionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            return Ok(_context.Question);
        }

        [HttpPost]
        [Route("")]
        public IActionResult addQuestion([FromBody] Questions question)
        {

            if (question.Tipo == "boolean")
            {
                question.Respuestas = "true:false";
            }
            else if (question.Tipo == "number")
            {
                question.Respuestas = "1:2:3:4:5:6:7:8:9:10";
            }
            else if (question.Tipo != "multChoice")
            {
                return BadRequest();
            }
            _context.Question.Add(question);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetQuestionById), new { id = question.Id }, question);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetQuestionById(int id)
        {
            Questions question = null;
            try
            {
                question = _context.Question.First((question) => question.Id == id);
            }
            catch (InvalidOperationException e)
            {
                return NotFound();
            }

            return Ok(question);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteQuestionById(int id)
        {
            Questions toRemove = null;
            try
            {
                toRemove = _context.Question.First((question) => question.Id == id);
            }
            catch
            {
                return NotFound();
            }


            _context.Respuesta.AsQueryable().ForEachAsync((respuesta) =>
            {
                if (respuesta.QuestionId == id)
                {
                    _context.Respuesta.Remove(respuesta);
                }
            });

            _context.Question.Remove(toRemove);
            _context.SaveChanges();
            return Ok();
        }


    }
}
