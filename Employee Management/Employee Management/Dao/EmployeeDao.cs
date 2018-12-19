using Employee_Management.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Employee_Management.Dao
{
    struct EmployeeDao
    { 
        public List<Employee> AddEmployee(List<Employee> employees)
        {
            Employee newEmployee = getNewEmployee();
            employees.Add(newEmployee);
            Console.WriteLine("Add successfully!\n");
            return employees;
        }        
        //删除
        public void DeleteEmployee(List<Employee> employees)
        {
            if (!IsEmployeeExist(employees))
            {
                return;
            }
            Console.Write("delete by id,input the id,please:");
            //int.tryParse();
            int id = ForVerification.InputNumber();
            if (AskForSure())
            {
                Employee employee = employees.Find(e=>id==e.Id);
                if (employee == null)
                {
                    Console.WriteLine("Delete nothing!\n");
                    return;
                }
                employees.Remove(employee);
                Console.WriteLine("Delete successfully!\n");
            }
        }

        //修改
        public void UpdateEmployee(List<Employee> employees)
        {
            if (!IsEmployeeExist(employees))
            {
                return;
            }
            Console.Write("update by id,input the id,please:");

            int id = ForVerification.InputNumber();

            Employee employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                Console.WriteLine("the employee dont't exist!");
                return;
            }
            DoUpdate(employee);
            Console.WriteLine("update as follow:");
            InfomationShowUtil.ShowEmployeeById(employees, id);           
        }    
        //查询
        public void SelectEmployee(List<Employee> employees)
        {
            if (!IsEmployeeExist(employees))
            {
                return;
            }

            Console.Write("select by last name:");
            string likeLastName = Console.ReadLine();
            List<Employee> findEmployees = FindEmployees(employees, likeLastName);
            if (findEmployees == null)
            {
                Console.WriteLine("No Result!");
                return;
            }
            InfomationShowUtil.ShowAllEmployees(findEmployees);
        }
        #region private method
        private List<Employee> FindEmployees(List<Employee> employees, string likeLastName)
        {
            Regex IsTarget = new Regex(likeLastName.Trim().ToLower());
            var findEmployees = employees.FindAll(employee => IsTarget.IsMatch(employee.LastName.Trim().ToLower()));
            return findEmployees;
        }
        private Employee getNewEmployee()
        {
            Console.Write("new employee's first name:");
            string firstName = Console.ReadLine();
            Console.Write("new employee's last name:");
            string lastName = Console.ReadLine();
            Console.Write("new employee's gender(F/M :F is defalut):");
            string s_gender = Console.ReadLine();
            Console.Write("new employee's birth(yyyy-mm-dd ex:1997-10-01):");
            string s_birth;
            do
            {
                s_birth = Console.ReadLine();
            } while (!ForVerification.CheckDate(s_birth));
            Console.Write("new employee's address:");
            string address = Console.ReadLine();
            Console.Write("new employee's home phone:");
            string homePhone = Console.ReadLine();
            Console.Write("new employee's cell phone:");
            string cellPhone = Console.ReadLine();
            Gender gender;
            gender = "M".Equals(s_gender) == true ? Gender.M : Gender.F;
            DateTime birth = DateTime.Parse(s_birth.Trim());
            Employee e = new Employee(firstName, lastName, gender, birth, address, homePhone, cellPhone);
            return e;
        }
        private bool AskForSure()
        {
            bool isConfirm = false;
            Console.Write("Do you confirm to delete?(y/n)");
            if ("y".Equals(Console.ReadLine()))
            {
                isConfirm = true;
            }
            return isConfirm;
        }
        private void DoUpdate(Employee employee)
        {
            Console.Write("update last name:");
            string lastName = Console.ReadLine();
            Console.Write("update address:");
            string address = Console.ReadLine();
            Console.Write("update home phone:");
            string homePhone = Console.ReadLine();
            Console.Write("update cell phone:");
            string cellPhone = Console.ReadLine();
            employee.LastName = lastName;
            employee.Address = address;
            employee.HomePhone = homePhone;
            employee.CellPhone = cellPhone;
        }
        #endregion
        public bool IsEmployeeExist(List<Employee> employees)
        {
            bool flag = true;
            if (employees.Count == 0)
            {
                Console.WriteLine("there is no employee!");
                flag = false;
            }
            return flag;
        }
    }
}
