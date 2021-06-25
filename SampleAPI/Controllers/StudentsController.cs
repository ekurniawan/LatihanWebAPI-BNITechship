using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Data;
using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudent _student;
        public StudentsController(IStudent student)
        {
            _student = student;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _student.GetAll();
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _student.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Student student)
        {
            _student.Insert(student);
        }
    }
}
