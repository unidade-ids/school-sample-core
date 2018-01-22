using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTreinee.Domain.Entidades
{
    public class Estudante : BaseEntity
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<Turma> Turmas { get; set; }
    }
}
