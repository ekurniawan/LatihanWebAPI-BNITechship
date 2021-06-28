using Microsoft.Extensions.Configuration;
using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

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
            List<Student> lstStudents = new List<Student>();
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Students 
                                  order by FirstMidName asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstStudents.Add(new Student
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            FirstMidName = dr["FirstMidName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            EnrollmentDate = Convert.ToDateTime(dr["EnrollmentDate"])
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lstStudents;
        }

        public Student GetById(string id)
        {
            Student student = new Student();
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Students
                                  where ID=@ID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    student = new Student
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        FirstMidName = dr["FirstMidName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        EnrollmentDate = Convert.ToDateTime(dr["EnrollmentDate"])
                    };
                }
                else
                {
                    throw new Exception($"Data Student ID: {id} tidak ditemukan");
                }

                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return student;
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
