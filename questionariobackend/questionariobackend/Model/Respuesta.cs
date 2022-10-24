using System.ComponentModel.DataAnnotations;

namespace questionariobackend.Model
{
    public class Respuesta
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "UserId")]
        [Required]
        public int UserId { get; set; }
        [Display(Name = "QuestionId")]
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Contenido { get; set; }
    }
}
