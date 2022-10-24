namespace questionariobackend.Model
{
    public abstract class Questions
    {
        public int Id { get; set; }
        public string Question { get; set; }

        public string Tipo { get; set; }
    }
}
