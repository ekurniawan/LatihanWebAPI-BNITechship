using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Data
{
    public interface IStudent
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Insert(Student student);
        void Update(int id, Student student);
        void Delete(int id);
    }
}
