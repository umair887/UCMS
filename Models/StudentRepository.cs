using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Student_Managment_System.Models
{
  static  public class StudentRepository
    {

        public static void AddStudent(Student s)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"insert into Student(Name, Age, CGPA, Semester) values('{s.Name}','{s.Age}','{s.CGPA}','{s.Semester}')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void RemoveStudent(int id)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"delete from Student where Id = '{id}'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void EditStudent(Student s)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"update Student set Name = '{s.Name}', Age = '{s.Age}', CGPA = '{s.CGPA}', Semester = '{s.Semester}' where Id = '{s.Id}'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static Student FindStudent(int id)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from Student where Id = '{id}'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Student s = new Student();
            s.Name = (string)dr[1];
            s.Age = (int?)dr[2];
            s.CGPA = (float?)dr[3];
            s.Semester = (string)dr[4];
            con.Close();
            return s;
        }

        public static List<Student> GetStudents()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from Student";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Student> students = new List<Student>();
            Student s = new Student();
            while (dr.Read())
            {
                s.Name = (string)dr[1];
                s.Age = (int?)dr[2];
                s.CGPA = (float?)dr[3];
                s.Semester = (string)dr[4];

                students.Add(s);
            }
            con.Close();
            return students;
        }
    }
}
