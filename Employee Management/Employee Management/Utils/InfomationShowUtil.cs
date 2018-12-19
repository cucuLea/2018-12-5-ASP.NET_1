using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management.Utils
{
    struct InfomationShowUtil
    {
        public static void ShowAllEmployees(List<Employee> employees)
        {
            Console.WriteLine("Here is all the Employees Infomation:");
            ShowTableHead();
            employees.ForEach(employee => ShowEmployeeInfomation(employee));
            
        }
        
        public static void ShowCuttingLine()
        {
            Console.WriteLine("------------------------------------------");
        }

        public static void ShowEmployeeById(List<Employee> employees,int id)
        {           
            Employee employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                 Console.WriteLine("Nothing Find\n");
                 return;
            }
            ShowTableHead();
            ShowEmployeeInfomation(employee);          
        }

        public static void ShowTableHead()
        {
            Console.WriteLine("id |firstName |lastName |gender |     birth      |address |homePhone |cellPhone");
        }

        private static void ShowEmployeeInfomation(Employee employee)
        {
            Console.WriteLine(String.Format("{0,-3}|{1,-10}|{2,-9}|{3,-7}|{4,-16}|{5,-8}|{6,-10}|{7,-10}", employee.Id, employee.FirstName, employee.LastName
    , employee.Gender, employee.Birth.ToShortDateString().ToString(), employee.Address, employee.HomePhone, employee.CellPhone));
        }
    }
}
