using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management.Utils
{
    struct LogIn
    {
        public static bool IsAdmin(string user)
        {
            if ("admin".Equals(user))
            {
                return true;
            }
            return false;
        }

        public static void ShowHello(string user)
        {
            Console.Clear();
            Console.WriteLine("Hello,"+user);
        }

        public static string ReInput()
        {
            Console.Write("user doesn't exist,re enter please!\nInput user:");
            return Console.ReadLine();
        }
    }
}
