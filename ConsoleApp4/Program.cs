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

            Console.Write("\nEnter a number:");
            var input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    AddUser(names);
                    break;
                case 2:
                    WarehouseRole();
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
                        "\n9.Logout";

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
                    DisplayAllUsers(names);
                    break;
                case 5:
                    DisplayInactiveUsers(names);
                    break;
                case 6:
                    DisplayActiveUsers(names);
                    break;
                case 7:
                    DisplayProducts(names);
                    break;
                case 8:
                    DisplayOrders(names);
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

            Console.Write("\nEnter a number:");
            var response = Convert.ToInt32(Console.ReadLine());
        }
        static void AddUser(List<string> userInfo)
        {
            Console.Write("Enter your username:");
            var username = Console.ReadLine();
            Console.Write("Enter your password:");
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
        static void DisplayAllUsers(List<string> allUsers)
        {
            foreach (var user in allUsers)
            {
                Console.WriteLine(user);
            }
        }
        static void DisplayInactiveUsers(List<string> inactiveUsers)
        {
            foreach (var user in inactiveUsers)
            {
                Console.WriteLine(user);
            }
        }
        static void DisplayActiveUsers(List<string> activeUsers)
        {
            foreach (var user in activeUsers)
            {
                Console.WriteLine(user);
            }
        }
        static void DisplayProducts(List<string> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
        static void DisplayOrders(List<string> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }
        static void WarehouseRole()
        {
            Console.Write("Pick a Number:");
            var optionNo = Convert.ToInt32(Console.ReadLine());

            switch (optionNo)
            {
                case 1:
                    WarehouseUser();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

            var option = "Please select an option" +
            "\n1.Add Products" +
            "\n2.Display Products" +
            "\n3.Logout";
            Console.WriteLine(option);
            Console.Write("Choose an Option:");
            var whatOption = Convert.ToInt32(Console.ReadLine());
            switch (whatOption)
            {
                case 1:

                    break;
                case 2:

                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
            Console.WriteLine();

            Console.Write("Please enter the number of products you want to add: ");
            var productsNum = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < productsNum; i++)
            {
                Console.Write("Please enter the name of the product:");
                var productName = Console.ReadLine();

                Console.Write("Please enter the quantity of the product:");
                var productQuantity = Convert.ToInt32(Console.ReadLine());
            }

            var optionB = "Please select an option" +
                        "\n1.Add Products" +
                        "\n2.Display Products";
            Console.WriteLine(optionB);

        }

        static void WarehouseUser()
        {
            Console.Write("Enter your username:");
            var username = Console.ReadLine();
            Console.Write("Enter your password:");
            var password = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }
    }
}