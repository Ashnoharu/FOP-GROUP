using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<string> names = new List<string>();

            var roles = "1. Admin" +
                        "\n2. Warehouse" +
                        "\n3. User";

            Console.WriteLine(roles);

            Console.WriteLine("\nEnter a number:");
            var input = Convert.ToInt32(Console.ReadLine());

            switch (input)
        {
            case 1:
                    Console.WriteLine("Enter your username:");
                    var username = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password = Convert.ToInt32(Console.ReadLine());
                    break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
        }
        static void AddRoles(List<string> roles, string role)
        {
            roles.Add(role);
        }
    }
}