using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Company_Roster
{
    class Employee
    {
        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public string Name { get; set; }

        public decimal Salary { get; set; }
    }

    class Department
    {
        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
        }

        public string DepartmentName { get; set; }

        public List<Employee> ListOfEmployees { get; set; } = new List<Employee>();

        public decimal TotalSalaries { get; set; }

        public void AddEmployee(string name, decimal salary)
        {
            this.TotalSalaries += salary;
            this.ListOfEmployees.Add(new Employee (name, salary));
        }
    }

    class Program
    {
        static void Main()
        {
            List<Department> allDepartments = new List<Department>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                // Peter 120.00 Development

                string[] currEmployeeData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = currEmployeeData[0];
                decimal salary = decimal.Parse(currEmployeeData[1]);
                string currDep = currEmployeeData[2];

                if (!allDepartments.Any(x => x.DepartmentName == currDep))
                {
                    allDepartments.Add(new Department(currDep));
                }

                allDepartments.Find(d => d.DepartmentName == currDep).AddEmployee(name, salary);
            }

            Department bestDepartment = allDepartments.OrderByDescending(d => d.TotalSalaries / d.ListOfEmployees.Count).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            foreach (Employee employee in bestDepartment.ListOfEmployees.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }
}
