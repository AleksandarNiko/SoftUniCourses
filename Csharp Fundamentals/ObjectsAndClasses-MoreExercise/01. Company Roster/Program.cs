using Microsoft.VisualBasic;

namespace _01._Company_Roster
{
        internal class Program
        {
            static void Main(string[] args)
            {
            List<Department> departments = new List<Department>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] lineToken = Console.ReadLine().Split();

                if (!departments.Any(d => d.DepartmentName == lineToken[2]))
                {
                    departments.Add(new Department(lineToken[2]));
                }

                departments.Find(d => d.DepartmentName == lineToken[2]).AddNewEmployee(lineToken[0], decimal.Parse(lineToken[1]));

            }

            Department bestDepartment = departments.OrderByDescending(d => d.TotalSalaries / d.Employees.Count()).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            foreach (var employee in bestDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }

            }
        }

        class Employee
        {
            public string Name { get; set; }
            public decimal Salary { get; set; }

            public Employee(string name, decimal salary)
            {
                this.Name = name;
                this.Salary = salary;
            }
        }

        class Department
        {
            public string DepartmentName { get; set; }
            public List<Employee> Employees { get; set; } = new List<Employee>();
            public decimal TotalSalaries { get; set; }

            public void AddNewEmployee(string empName, decimal empSalary)
            {
                this.TotalSalaries += empSalary;

                this.Employees.Add(new Employee(empName, empSalary));
            }

            public Department(string departmentName)
            {
                this.DepartmentName = departmentName;
            }
        }
}
/*
4
Peter 120,00 Development
Tony 333,33 Marketing
Jony 840,20 Development
George 0,20 Nowhere
*/