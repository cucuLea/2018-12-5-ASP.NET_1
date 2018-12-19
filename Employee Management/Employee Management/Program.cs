using System;
using System.Collections.Generic;
using Employee_Management.Dao;
using Employee_Management.Utils;

namespace Employee_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("input user: ");
            string user = Console.ReadLine();
            while (!LogIn.IsAdmin(user))
            {
                user = LogIn.ReInput();
            }
            LogIn.ShowHello(user);

            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee("lea","li",Gender.F,new DateTime(1997,07,03),"zucc","110","119"));
            InfomationShowUtil.ShowAllEmployees(employees);
            EmployeeDao employeeDao = new EmployeeDao();

            bool isUse = true;
            while (isUse)
            {
                InfomationShowUtil.ShowCuttingLine();
                Console.WriteLine("Function list as follow:");
                Console.WriteLine("1:Show all employees;");
                Console.WriteLine("2:Add a new employee;");
                Console.WriteLine("3:Delete a employee;");
                Console.WriteLine("4:Select a employee;");
                Console.WriteLine("5:Update a employee;");
                Console.WriteLine("extra:Leave the System;\n");
                Console.Write("What do you want to do ?(Input the number)");
                string option = Console.ReadLine();
                Console.WriteLine();
                switch (option)
                {
                    case "1": InfomationShowUtil.ShowAllEmployees(employees); break;
                    case "2": employeeDao.AddEmployee(employees);break;
                    case "3": employeeDao.DeleteEmployee(employees); break;
                    case "4": employeeDao.SelectEmployee(employees); break;
                    case "5": employeeDao.UpdateEmployee(employees); break;
                    default:
                        isUse = false; break;
                }               
            }
        }
    }
}
