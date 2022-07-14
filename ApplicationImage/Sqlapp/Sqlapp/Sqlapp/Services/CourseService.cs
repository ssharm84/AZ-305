using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sqlapp.Models;
using MySql.Data.MySqlClient;

namespace Sqlapp.Services
{
    public class CourseService
    {
        // Ensure to change the below variables to reflect the connection details for your database
        private static string db_connectionstring = "server=mysql;user=root;password=Azure@123;database=appdb";

        private MySqlConnection GetConnection()
        {
            // Here we are creating the SQL connection

            return new MySqlConnection(db_connectionstring);
        }

        public IEnumerable<Course> GetCourses()
        {
            List<Course> _lst = new List<Course>();
            string _statement = "SELECT CourseID,ExamImage,CourseName,rating from Course";
            MySqlConnection _connection = GetConnection();
            // Let's open the connection
            _connection.Open();
            // We then construct the statement of getting the data from the Course table
            MySqlCommand _sqlcommand = new MySqlCommand(_statement, _connection);
            // Using the SqlDataReader class , we will read all the data from the Course table
            using (MySqlDataReader  _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course _course = new Course()
                    {
                        CourseID = _reader.GetInt32(0),
                        ExamImage=_reader.GetString(1),
                        CourseName = _reader.GetString(2),
                        Rating = _reader.GetDecimal(3)
                    };

                    _lst.Add(_course);
                }
            }
            _connection.Close();
            return _lst;
        }

    }
    }

    

