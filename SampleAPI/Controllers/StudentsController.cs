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
            return _student.GetById(id.ToString());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            try
            {
                _student.Insert(student);
                return Ok($"Berhasil menambahkan data student {student.FirstMidName} {student.LastName}");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Student student)
        {
            _student.Update(id.ToString(), student);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _student.Delete(id.ToString());
        }
    }
}
