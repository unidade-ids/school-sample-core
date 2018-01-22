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
    public class HomeController : Controller
    {
        private readonly IRepositoryBase<Estudante> _repositoryStudent;

        public HomeController(IRepositoryBase<Estudante> repositoryStudent)
        {
            _repositoryStudent = repositoryStudent;
        }
        public IActionResult Index()
        {
            var students = _repositoryStudent.GetAll().Select(s => new StudentViewModel { ID = s.ID, Nome = s.Nome, Idade = s.Idade, Email = s.Email });
            

            return View(students);
        }

        public IActionResult Save()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id == 0)
                return NotFound();

            var student = _repositoryStudent.GetById(id);

            if (student == null)
                return BadRequest();

            _repositoryStudent.Delete(student);

            return Ok();
        }
    }
}