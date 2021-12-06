using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.Domain.Models;
using SimpleAPI.Persistance;
using SimpleAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPI.Server.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public StudentsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<StudentDto>> GetStudents()
        {
            var students = new List<StudentDto>();
            var list = await context.Students.ToListAsync();
            foreach (var obj in list)
            {
                StudentDto student = new()
                {
                    FirstName = obj.FirstName,
                    LastName = obj.LastName
                };
                students.Add(student);
            }
            return students;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto data)
        {
            Student student = new()
            {
                FirstName = data.FirstName,
                LastName = data.LastName
            };

            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
