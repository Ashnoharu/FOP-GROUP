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
            case 2:
                    Console.WriteLine("Enter your username:");
                    var username2 = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password2 = Convert.ToInt32(Console.ReadLine());
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
            switch (input)
            {
                case 1:
                    Console.Write("Update Password:");
                    var newPass = Console.ReadLine();
                    var password = newPass;
                    Console.WriteLine("New password:" + password);

                    break;
                case 2:
                    Console.WriteLine("Enter your username:");
                    var username4 = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password4 = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Enter your username:");
                    var username5 = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password5 = Convert.ToInt32(Console.ReadLine());
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
        static void AddRoles(List<string> roles, string role)
        {
            roles.Add(role);
        }
    }
}