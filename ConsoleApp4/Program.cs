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
            var question = "Please select an option:" +
                        "\n1.Update Password" +
                        "\n2.Inactivate User" +
                        "\n3.Add User" +
                        "\n4.Display All Users" +
                        "\n5.Display Inactive Users" +
                        "\n6.Display Active Users" +
                        "\n7.Display Products" +
                        "\n8.Display Orders" +
                        "9.Logout";
            Console.WriteLine(question);

            Console.WriteLine("\nEnter a number:");
            var response = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hello World");
            Console.WriteLine("Hello World");
        }
        static void AddRoles(List<string> roles, string role)
        {
            roles.Add(role);
        }
    }
}