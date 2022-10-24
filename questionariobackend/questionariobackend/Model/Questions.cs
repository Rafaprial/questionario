using System.ComponentModel.DataAnnotations;

namespace questionariobackend.Model
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }

        public string Tipo { get; set; }

        public string Respuestas { get; set; }
    }
}
