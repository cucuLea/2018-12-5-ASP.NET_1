using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Employee_Management.Utils
{
    struct ForVerification
    {
        public static bool CheckDate(string date)
        {
            Regex IsDate = new Regex(@"^\d{4}-\d{2}-\d{2}$");
            if (IsDate.IsMatch(date.Trim()))
            {   
                return true;
            }

            Console.WriteLine("please input with the right format! re input:");
            return false;
        }

        public static int InputNumber()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("input a number,please:");
            }
            return id;
        }
    }
}
