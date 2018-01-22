using System.Collections.Generic;

namespace SchoolTreinee.Domain.Entidades
{
    public class Turma
    {
        public int IdProfessor { get; set; }
        public int IdAluno { get; set; }
        public int IdTurma { get; set; }

        public ICollection<Estudante> Estudantes { get; set; }
        public ICollection<Professor> Professores { get; set; }
    }
}