using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Questions> GetAll()
        {
            return _context.Question;
        }

        [HttpPost]
        [Route("")]
        public IActionResult addQuestion(Questions question)
        {
            if (question == null)
            {
                throw new ArgumentNullException();
            }
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
            return this.CreatedAtAction(nameof(GetQuestionById), new { id = question.Id }, question);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetQuestionById(int id)
        {
            Questions question = _context.Question.First((question) => question.Id == id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteQuestionById(int id)
        {
            Questions toRemove = _context.Question.First((question) => question.Id == id);


            _context.Question.Remove(toRemove);
            _context.SaveChanges();
        }


    }
}
