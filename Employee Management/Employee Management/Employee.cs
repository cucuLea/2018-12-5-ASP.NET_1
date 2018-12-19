using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management
{
    class Employee
    {   
        static int systemId = 0;
        #region Construction
        public Employee() { }
    
        public Employee(string firstName, string lastName, Gender gender, DateTime birth, string address, string homePhone, string cellPhone)
        {
            systemId += 1;
            Id = systemId;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Birth = birth;
            Address = address;
            HomePhone = homePhone;
            CellPhone = cellPhone;
        }
        #endregion        
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        internal Gender Gender { get; set; }
        public string TestProp { get; set; }
    }
}
