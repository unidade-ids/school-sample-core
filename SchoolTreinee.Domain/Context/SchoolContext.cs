using Microsoft.EntityFrameworkCore;
using SchoolTreinee.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTreinee.Domain.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            :base(options)
        {
        }

        public DbSet<Estudante> Estudante { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Materia> Materia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudante>().ToTable("Aluno");
            modelBuilder.Entity<Professor>().ToTable("Professor");
            modelBuilder.Entity<Materia>().ToTable("Materia");
        }
    }
}
