using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Model;

namespace StudentProject.Entites
{
    public class Students:BaseEntite
    {
        Hashtable studentHashtable = new Hashtable();

        public Hashtable addStudent(int id,string name,string address,int age)
        {
            if (!(studentHashtable[id] is Student))
            {
                Student student = new Student() { Age = age, id = id, name = name, Address = address };
                studentHashtable.Add(student.id, student);
                return studentHashtable;
            }
                return null;

            
        }
        public object funRead(SqlDataReader reader){
             studentHashtable.Clear();
            while (reader.Read())
            {
                addStudent(reader.GetInt32(reader.GetOrdinal("Id")), reader.GetString(reader.GetOrdinal("Name")), reader.GetString(reader.GetOrdinal("Address")), reader.GetInt32(reader.GetOrdinal("Age")));

            }
            return studentHashtable;
        }
        public Hashtable AddStudentHashtable()
        {
            Hashtable hashtableStudent;
            try
            {
                hashtableStudent=(Hashtable)Dal.SqlQurey.RunResultComand("select Id,Address,Name,Age from StudentsData", funRead);
                return hashtableStudent;

            }
            catch (Exception Ex)
            {
                return null;
            }

        }

        public void AddStudentData(int id,string address,string name,int age)
        {
           

            Dal.SqlQurey.RunComand($"insert into StudentsData(Id,Address,Name,Age) values ({id} ,'{address}','{name}',{age})");
        }

    }
}
