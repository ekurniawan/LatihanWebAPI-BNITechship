using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private List<Student> lstStudent = new List<Student>
        {
            new Student
            {
                ID=1,
                FirstMidName="Erick",
                LastName="Kurniawan",
                EnrollmentDate = DateTime.Now
            },
            new Student
            {
                ID=2,
                FirstMidName = "Adi",
                LastName = "Nugroho",
                EnrollmentDate = DateTime.Now
            }
        };

        [HttpGet]
        public List<Student> Get()
        {
            return lstStudent;
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            //var result = lstStudent.Where(s => s.ID == id).FirstOrDefault();
            var result = (from std in lstStudent
                          where std.ID == id
                          select std).FirstOrDefault();
            return result;
        }

       
    }
}
