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
            List<string> adminNames = new List<string>();

            var keepRunning = true;
            while (keepRunning)
            {
                var selectedRoles = "Please Select a user role to login:" +
                        "\n1. Admin" +
                        "\n2. Warehouse" +
                        "\n3. User";

                Console.WriteLine(selectedRoles);

                Console.Write("\nEnter a number:");
                var input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        AddUser(adminNames);
                        Conditions(adminNames);
                        break;
                    case 2:
                        WarehouseRole();
                        break;
                    case 3:
                        User(adminNames);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        public static void Conditions(List<string> adminNames)
        {
            var keepRunning = true;
            while (keepRunning)
            { 
                var adminQuestion = "\nPlease select an option:" +
            "\n1.Update Password" +
            "\n2.Inactivate User" +
            "\n3.Add User" +
            "\n4.Display All Users" +
            "\n5.Display Inactive Users" +
            "\n6.Display Active Users" +
            "\n7.Display Products" +
            "\n8.Display Orders" +
            "\n9.Logout";

            Console.WriteLine(adminQuestion);
            Console.Write("\nEnter a number: ");
            var adminAnswer = Convert.ToInt32(Console.ReadLine());

                switch (adminAnswer)
                {
                    case 1:
                        SetNewPassword(adminNames);
                        break;
                    case 2:
                        DeactUser(adminNames);
                        break;
                    case 3:
                        AddNewUser(adminNames);
                        break;
                    case 4:
                        DisplayAllUsers(adminNames);
                        break;
                    case 5:
                        DisplayInactiveUsers(adminNames);
                        break;
                    case 6:
                        DisplayActiveUsers(adminNames);
                        break;
                    case 7:
                        DisplayProducts(adminNames);
                        break;
                    case 8:
                        DisplayOrders(adminNames);
                        break;
                    case 9:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        public static void AddUser(List<string> adminNames)
        {
            Console.Write("Enter your username: ");
            var username = Console.ReadLine();
            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            adminNames.Add("Username:" + username + "|" + "Password:" + password);

        }
        public static void SetNewPassword(List<string> adminNames)
        {
            if (adminNames.Count == 0)
                Console.WriteLine("No Record found");

            foreach (var user in adminNames)
            {
                for (int i = 0; i < adminNames.Count; i++)
                { 
                    Console.WriteLine("\nAll Accounts");
                    Console.WriteLine($"{i}. Username:" + user.Split('|')[0]);
                }

            }
            Console.Write("Search a user you want to change password: ");
            var selected = Console.ReadLine();

            int index = adminNames.FindIndex(x => x.StartsWith("Username:" + selected + "|"));

            if (index == -1)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter new password: ");
            var newPassword = Console.ReadLine();
            Console.Write("Confirm new password: ");
            var confirmPassword = Console.ReadLine();

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("Passwords do not match.");
                return;
            }
            else
                adminNames[index] = "Username:" + selected + "|" + "Password:" + newPassword;
                Console.WriteLine("Password updated for " + selected);
        }
        public static void DeactUser(List<string> adminNames)
        {
            Console.Write("Remove Student By Name or Id: ");
            var keyword = Console.ReadLine();

            var ctr = 0;
            var isFound = false;
            foreach (var user in adminNames)
            {
                if (user.Contains(keyword))
                {
                    isFound = true;
                    break;
                }
                ctr++;
            }
            if (isFound)
                adminNames.RemoveAt(ctr);

            DisplayAllUsers(adminNames);
        }
        public static void AddNewUser(List<string> adminNames)
        {
            Console.WriteLine("Enter your username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            var password = Console.ReadLine();
            adminNames.Add(username + "|" + password);
        }
        public static void DisplayAllUsers(List<string> adminNames)
        {
            if (adminNames.Count == 0)
                Console.WriteLine("No Record found");

            foreach (var user in adminNames)
            {
                Console.WriteLine();
                Console.WriteLine("Username:" + user.Split('|')[0]);
                Console.WriteLine("User Id:" + user.Split('|')[1]);
            }
        }
        public static void DisplayInactiveUsers(List<string> adminNames)
        {
            foreach (var user in adminNames)
            {
                Console.WriteLine("\nUsername:" + user.Split('|')[0]);
                Console.WriteLine("User Id:" + user.Split('|')[1]);
            }
        }
        public static void DisplayActiveUsers(List<string> adminNames)
        {
            if (adminNames.Count == 0)
                Console.WriteLine("No Record found");

            foreach (var user in adminNames)
            {
                Console.WriteLine("\nUsername:" + user.Split('|')[0]);
                Console.WriteLine("User Id:" + user.Split('|')[1]);
            }
        }
        public static void DisplayProducts(List<string> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
        public static void DisplayOrders(List<string> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }
        public static void WarehouseRole()
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
        public static void WarehouseUser()
        {
            Console.Write("Enter your username:");
            var username = Console.ReadLine();
            Console.Write("Enter your password:");
            var password = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }
        public static void User(List<string> adminNames)
        {
            if (adminNames.Count == 0)
                Console.WriteLine("No Record found");

            foreach (var user in adminNames)
            {
                for(int i = 0; i < adminNames.Count; i++)
                {
                    Console.WriteLine("\nAll Accounts");
                    Console.WriteLine($"{i}. Username:" + user.Split('|')[0]);
                }
            }
        }
    }
}