/* 
2. C#: Employees Management

Given a list of data, implement the following 3 methods using LINQ in a class that allows for managing employees:

1. AverageAgeForEachCompany- calculates the average age of employees for each unique company and returns the
results as a Dictionary<string, int> sorted by key, where Key[string] is the unique company name, and Value[int] is
the average age of employees in this company. The average age is rounded to the nearest whole number.

2. CountOfEmployeesForEachCompany - calculates the count of employees for each unique company and returns the
results as a Dictionary<string, int> sorted by key, where Key[string] is the unique company name, and Value[int] is
the count of employees in this company.

3. OldestAgeForEachCompany - finds the oldest aged employee for each unique company and returns the results as
a Dictionary<string, Employee> sorted by key, where Key[string] is the unique company name, and Value[Employee]
is the oldest employee in this company.

Here is the description of the Employee class:

. FirstName [string] - the first name of the employee.

. LastName[string] - the last name of the employee.

. Company [string] - the company of the employee.

. Age [int] - the age of the employee.

Your implementation of the class will be tested by a stubbed code on several input files. The input file contains
parameters for the function calls (i.e., the employee data). The functions will be called with those parameters, and
the result of their executions will be printed to the standard output by the stubbed code.
*/


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    public class Solution
    {

         public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            var result = new Dictionary<string, int>();
            foreach (var company in employees.Select(x => x.Company).Distinct().OrderBy(x => x))
            {
                result.Add(company, (int)Math.Round(employees.Where(x => x.Company == company).Average(y => y.Age), 0));
            }

            return result;
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            var result = new Dictionary<string, int>();
            foreach (var company in employees.Select(x => x.Company).Distinct().OrderBy(x => x))
            {
                result.Add(company, (int)employees.Where(x => x.Company == company).Count());
            }

            return result;
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            var result = new Dictionary<string, Employee>();
            foreach (var company in employees.Select(x => x.Company).Distinct().OrderBy(x => x))
            {
                result.Add(company, employees.Where(x => x.Company == company).OrderByDescending(y => y.Age).First());
            }

            return result;
        }

        public static void Main()
        {   
            int countOfEmployees = int.Parse(Console.ReadLine());
            
            var employees = new List<Employee>();
            
            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee { 
                    FirstName = strArr[0], 
                    LastName = strArr[1], 
                    Company = strArr[2], 
                    Age = int.Parse(strArr[3]) 
                    });
            }
            
            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }
            
            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }
            
            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }
    
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}   
