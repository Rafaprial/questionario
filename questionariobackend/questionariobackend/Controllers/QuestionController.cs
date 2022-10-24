using Microsoft.AspNetCore.Mvc;
using questionariobackend.Data;
using questionariobackend.Model;

namespace questionariobackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController
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

        [HttpGet]
        [Route("{id}")]
        public Questions GetQuestionById(int id)
        {
            return _context.Question.First((question) => question.Id == id);
        }


        [HttpPost]
        [Route("")]
        public void addQuestion(Questions question)
        {
            _context.Question.Add(question);
            _context.SaveChanges();
        }




    }
}
