using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Cw3.Models;

namespace Cw3.DAL
{
    public class DbService : IDbService
    {
        private const string connectionString = "Data Source=db-mssql;Initial Catalog=s18310;Integrated Security=True";

        public IEnumerable<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (var connection =
                new SqlConnection("Data Source=db-mssql;Initial Catalog=s18310;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "select * from Student inner join Enrollment on Student.IdEnrollment=Enrollment.IdEnrollment inner join Studies on Enrollment.IdStudy=Studies.IdStudy";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var student = new Student();
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.IndexNumber = reader["IndexNumber"].ToString();
                    student.BirthDate=DateTime.Parse(reader["BirthDate"].ToString()).ToShortDateString();
                    student.Studies = reader["Name"].ToString();
                    student.Semester = int.Parse(reader["Semester"].ToString());
                    students.Add(student);
                }
            }

            return students;
        }

        public Student GetStudent(int index)
        {
            using (var connection =
                new SqlConnection("Data Source=db-mssql;Initial Catalog=s18310;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "select * from Student inner join Enrollment on Student.IdEnrollment=Enrollment.IdEnrollment " +
                                      "inner join Studies on Enrollment.IdStudy=Studies.IdStudy where IndexNumber=@index";
                command.Parameters.AddWithValue("index", index);
                connection.Open();
                var reader = command.ExecuteReader();
                if(reader.Read())
                {
                    var student = new Student();
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.IndexNumber = reader["IndexNumber"].ToString();
                    student.BirthDate=DateTime.Parse(reader["BirthDate"].ToString()).ToShortDateString();
                    student.Studies = reader["Name"].ToString();
                    student.Semester = int.Parse(reader["Semester"].ToString());
                    return student;
                }
                return null;
                
            }
        }
    }
}