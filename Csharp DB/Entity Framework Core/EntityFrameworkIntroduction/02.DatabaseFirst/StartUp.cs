using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SoftUni.Data;
using SoftUni.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
             .Select(e => new { e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary });

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }
            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new { e.FirstName, e.Salary })
                .Where(e => e.Salary > 50000)
                .ToList();
                
            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e=>e.Department.Name== "Research and Development")
                .Select(e => new { e.FirstName,e.LastName, e.Department.Name,e.Salary })
                .OrderBy (e => e.Salary)
                .ThenByDescending(e=>e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from Research and Development - ${e.Salary:f2}");
            }

            return sb.ToString();      
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address() { AddressText ="Vitoshka 15", TownId = 4};

            Employee? employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            employee!.Address = address;

            context.SaveChanges();

            var employeesAddresses=context.Employees
                .OrderByDescending(e=>e.AddressId)
                .Take(10)
                .Select(e=>e.Address!.AddressText)
                .ToList();

            return string.Join("\n", employeesAddresses);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees.Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager!.FirstName,
                    ManagerLastName = e.Manager!.LastName,
                    Projects = e.EmployeesProjects
                    .Where(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003)
                    .Select(e => new
                    {
                        ProjectName = e.Project.Name,
                        StartDate = e.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = e.Project.EndDate.HasValue ?
                        e.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                    })
                    .ToList()
                })
            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Projects )
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.Town.Name)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .Select(a => $"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees")
            .ToList();

            return string.Join("\n", addresses );
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(p => new { p.Project.Name }).OrderBy(p => p.Name).ToArray()
                })
                .FirstOrDefault();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var p in employee.Projects.Select(x=>x.Name))
            {
                sb.AppendLine(p);
            }

            return sb.ToString();

        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d=>d.Employees.Count > 5)
                .OrderBy(d=>d.Employees.Count)
                .ThenBy(d=>d.Name)
                .Select(d => new
                {
                    DepartmentName=d.Name,
                    ManagerFirstName=d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e=>e.FirstName)
                    .ThenBy(e=>e.LastName)
                    .ToList()
                }).ToList();

            StringBuilder sb=new StringBuilder ();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .ToList();

            return string.Join("\n", projects.Select(x => x.Name + "\n" + x.Description + "\n" + x.StartDate));
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departmentNames = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Where(e => departmentNames.Contains(e.Department.Name))
                .ToArray();

            foreach (var e in employees)
            {
                e.Salary *= 1.12m;
            }

            var increasedEmp = employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => $"{e.FirstName} {e.LastName} (${e.Salary:f2})")
                .ToList();

            return string.Join("\n", increasedEmp);
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e=>e.FirstName.StartsWith("Sa"))
                .OrderBy(e=>e.FirstName)
                .ThenBy(e=>e.LastName)
                .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})")
                .ToList();

            return string.Join("\n", employees);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var empProjectsToDelete = context.EmployeesProjects.Where(p => p.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(empProjectsToDelete);

            var projectsToDelete = context.Projects.Where(p => p.ProjectId == 2);
            context.Projects.RemoveRange(projectsToDelete);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            return string.Join("\n", projects);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            Town? townToRemove = context.Towns
                .Where(t => t.Name == "Seattle")
                .FirstOrDefault();

            var addressesToRemove = context.Addresses
                .Where(a => a.TownId == townToRemove!.TownId)
                .ToList();

            var employeesToRemove= context.Employees
                .Where(e=>addressesToRemove.Contains(e.Address))
                .ToList();

            foreach (var e in employeesToRemove) 
            {
                e.AddressId = null; 
            }

            context.Addresses.RemoveRange(addressesToRemove);
            context.Towns.Remove(townToRemove!);

            context.SaveChanges();

            return $"{addressesToRemove.Count()} addresses in Seattle were deleted";
        }
    }
}
