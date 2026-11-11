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

            var roles = "Please Select a user role to login:" +
                        "\n1. Admin" +
                        "\n2. Warehouse" +
                        "\n3. User";

            Console.WriteLine(roles);

            Console.WriteLine("\nEnter a number:");
            var input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    AddUser(names);
                    break;
                case 2:
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
            Console.Write("Enter a number: ");
            var answer = Convert.ToInt32(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    SetNewPassword(roles);
                    break;
                case 2:
                    RemoveUser(names);
                    break;
                case 3:
                    AddNewUser(names);
                    break;
                case 4:
                    Console.WriteLine("Enter your username:");
                    var username6 = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password6 = Convert.ToInt32(Console.ReadLine());
                    break;
                case 5:
                    Console.WriteLine("Enter your username:");
                    var username7 = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password7 = Convert.ToInt32(Console.ReadLine());
                    break;
                case 6:
                    Console.WriteLine("Enter your username:");
                    var username8 = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password8 = Convert.ToInt32(Console.ReadLine());
                    break;
                case 7:
                    Console.WriteLine("Enter your username:");
                    var username9 = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password9 = Convert.ToInt32(Console.ReadLine());
                    break;
                case 8:
                    Console.WriteLine("Enter your username:");
                    var username10 = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password10 = Convert.ToInt32(Console.ReadLine());
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

            Console.WriteLine("\nEnter a number:");
            var response = Convert.ToInt32(Console.ReadLine());
        }
        static void AddUser(List<string> userInfo)
        {
            Console.WriteLine("Enter your username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            var password = Convert.ToInt32(Console.ReadLine());
        }
        static void SetNewPassword(string newPas)
        {
            Console.Write("Update Password:");
            var newPass = Convert.ToInt32(Console.ReadLine());
            var password = newPass;
            Console.WriteLine("New password:" + password.ToString());
        }
        static void RemoveUser(List<string> InactUser)
        {
            Console.Write("Enter a username:");
            var username = Console.ReadLine();
        }
        static void AddNewUser(List<string> newUser)
        {
            Console.WriteLine("Enter your username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            var password = Convert.ToInt32(Console.ReadLine());
        }
    }
}