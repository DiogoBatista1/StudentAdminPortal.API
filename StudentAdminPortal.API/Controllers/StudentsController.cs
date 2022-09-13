using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("[Controller]")]

        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentRepository.GetStudents();

            return Ok(mapper.Map<List<Student>>(students));
        }

        [HttpGet]
        [Route("[Controller]/{studentId:guid}")]

        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            //Fetch student details
            var student = await studentRepository.GetStudentAsync(studentId); 
            //Return students
            if(student == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Student>(student));
        }
    }
}
