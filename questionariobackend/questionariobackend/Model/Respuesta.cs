using System.ComponentModel.DataAnnotations;

namespace questionariobackend.Model
{
    public class Respuesta
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "UserId")]
        public int UserId { get; set; }
        [Display(Name = "QuestionId")]
        public int QuestionId { get; set; }
        public string Tipo { get; set; }
        public string Contenido { get; set; }
    }
}
