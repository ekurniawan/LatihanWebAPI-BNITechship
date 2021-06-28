using Microsoft.Extensions.Configuration;
using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SampleAPI.Data
{
    public class StudentDataSQL : IStudent
    {
       
        private IConfiguration _config;
        public StudentDataSQL(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetByName(string studentName)
        {
            throw new NotImplementedException();
        }

        public void Insert(Student obj)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Student obj)
        {
            throw new NotImplementedException();
        }
    }
}
