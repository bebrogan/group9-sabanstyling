using System.Collections.Generic;
using System.Dynamic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class EmployeeDataHandler : IEmployeeDataHandler
    {
        private Database db;
        public EmployeeDataHandler()
        {
            db = new Database(); 
        }
        public void Delete(Employee emp)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Employee emp)
        {
            string sql = "INSERT INTO employee (empID, empfName, emplName, empEmail, empPassword) VALUES(@id, @firstName, @lastName, @email, @password);"; 

            var values = GetValues(emp); 
            db.Open(); 
            db.Insert(sql, values);
            db.Close();
        }

        public List<Employee> Select()
        {
            db.Open(); 

            string sql = "SELECT * from employee ORDER BY 'id' desc"; 

            List<ExpandoObject> results = db.Select(sql); 

            List<Employee> emp = new List<Employee>(); 
            foreach(dynamic item in results)
            {
                Employee temp = new Employee()
                {
                    ID = item.id,
                    FirstName = item.empfName,
                    LastName = item.emplName,
                    Email = item.empEmail,
                    Password = item.password,
                }; 
                emp.Add(temp); 
            }

            db.Close(); 
            return emp; 
        }

        public void Update(Employee emp)
        {
            string sql = "UPDATE employee SET ";

            var values = GetValues(emp); 
            foreach(var p in values)
            {
                if(p.Key != "ID" && p.Value != null)   
                {
                    switch(p.Key)
                    {
                        case "@message":
                            sql += "post = @message,";
                            break; 
                        case "@firstName":
                            sql += "empfName = @firstName,";
                            break; 
                        case "@lastName":
                            sql += "emplName = @lastName,";
                            break; 
                        case "@email":
                            sql += "empEmail = @email,";
                            break; 
                        case "@password":
                            sql += "empPassword = @password,";
                            break; 
                    }
                }
            }
            sql = sql.Remove(sql.Length - 1, 1);
            sql += " WHERE id=@id"; 
            db.Open(); 
            db.Update(sql, values);
            db.Close();
        }
        public Dictionary<string, object> GetValues(Employee emp)
        {
            var values = new Dictionary<string,object>()
            {
                {"@id", emp.ID},
                {"@firstName", emp.FirstName},
                {"@lastName", emp.LastName},
                {"@email", emp.Email},
                {"@password", emp.Password},
            }; 
            return values; 
        }
    }
}