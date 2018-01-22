namespace SchoolTreinee.Domain.Entidades
{
    public class Professor : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int IdMateria { get; set; }

        public Materia Materia { get; set; }
    }
}