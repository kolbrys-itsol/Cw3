using System;
using Cw3.Models;
using Cw3.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public StudentsController(IDbService iDbService)
        {
            _dbService = iDbService;
        }


        [HttpGet]
        public IActionResult GetStudent()
        {
            return Ok(_dbService.GetStudents());
        }


        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (_dbService.GetStudent(id) != null)
            {
                return Ok(_dbService.GetStudent(id));
            }
            else
            {
                return NotFound("Nie znaleziono studenta o tym id");
            }
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id)
        {
            if (_dbService.GetStudent(id) != null)
            {
                return Ok("Aktualizacja zakończona");
            }
            else
            {
                return NotFound("Nie znaleziono studenta o tym id");
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (_dbService.GetStudent(id) != null)
            {
                return Ok("Usuwanie zakończone");
            }
            else
            {
                return NotFound("Nie znaleziono studenta o tym id");
            }
        }


    }
}