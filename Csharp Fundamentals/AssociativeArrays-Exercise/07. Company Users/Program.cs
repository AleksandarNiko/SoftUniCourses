using System.Xml.Linq;

namespace _07._Company_Users
{
    class Company
    {
        public string CompanyName { get; set; }
        public List<string> EmployeesId { get; set; }

        public Company(string companyName)
            {
            CompanyName = companyName;
            EmployeesId = new List<string>();
           }
        public void AddEmployee(string employeeId)
        {
            if (!EmployeesId.Contains(employeeId))
            {
                EmployeesId.Add(employeeId);
            }
        }
        public override string ToString()
        {
            string result = $"{CompanyName}\n";

            for (int i = 0; i < EmployeesId.Count; i++)
            {
                result += $"-- {EmployeesId[i]}\n";
            }

            return result.Trim();
        }
}
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Company> companies = new Dictionary<string,Company>();
            string input;
            while ((input =Console.ReadLine())!="End")
            {
                string[] lineToken = input.Split(" -> ");
                string companyName = lineToken[0];
                string employeeId=lineToken[1];
                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new Company (companyName));
                }
                companies[companyName].AddEmployee(employeeId);
            }
            foreach (var  company in companies)
            {
                Console.WriteLine(company.Value);
            }
        }
    }
}
/*
SoftUni -> AA12345
SoftUni -> CC12344
Lenovo -> XX23456
SoftUni -> AA12345
Movement -> DD11111
End
*/