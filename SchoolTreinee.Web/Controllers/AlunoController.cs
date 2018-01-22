using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolTreinee.Domain.Contratos;
using SchoolTreinee.Domain.Entidades;
using SchoolTreinee.Web.Models;

namespace SchoolTreinee.Web.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IRepositoryBase<Estudante> _repositoryStudent;

        public AlunoController(IRepositoryBase<Estudante> repositoryStudent)
        {
            _repositoryStudent = repositoryStudent;
        }

        public IActionResult Index()
        {
            var students = _repositoryStudent.GetAll().Select(s => new StudentViewModel { ID = s.ID, Nome = s.Nome, Idade = s.Idade, Email = s.Email });

            return View(students);
        }
    }
}