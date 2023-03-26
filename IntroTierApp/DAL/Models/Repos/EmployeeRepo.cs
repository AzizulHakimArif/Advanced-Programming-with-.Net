﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Repos
{
    public class EmployeeRepo
    {
        static EmpContext empContext;
        static EmployeeRepo()
        {
            empContext = new EmpContext();
        }

        public static List<Employee> Get()
        { 
            var employees = new List<Employee>(); 
            for(int i = 1; i <=12 ; i++) 
            {
                employees.Add(new Employee { Id =i ,Name = "E-"+1});
            }
            return employees;

        }
        public static Employee Get(int id)
        {
            return empContext.Employees.Find(id);
        }
        public static bool Add(Employee employee)
        {
            empContext.Employees.Add(employee);
            return empContext.SaveChanges() > 0; 
        }
        public static bool Update(Employee employee)
        {
            var exemp = empContext.Employees.Find(employee.Id);
            empContext.Entry(exemp).CurrentValues.SetValues(employee);
            return empContext.SaveChanges() > 0;
        }
        public static bool Delete(int id)
        { 
        var exemp =Get(id);
            empContext.Employees.Remove(exemp);
            return empContext.SaveChanges() > 0;
        }

        public static bool Create(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}