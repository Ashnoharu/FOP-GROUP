using System;
using System.Collections.Generic;

namespace FOPGROUPMAIN
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;

        public static void AddUser(List<User> users)
        {
            Console.Write("Enter your username: ");
            var username = Console.ReadLine();
            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            User newUser = new User();
            newUser.Username = username;
            newUser.Password = password;
            users.Add(newUser);
        }

        public static void SetNewPassword(List<User> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("No Record found");
                return;
            }
            Console.WriteLine("\nACCOUNTS");

            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i}. Username: " + users[i].Username);
            }

            Console.Write("Search the user you want to change password: ");
            var selected = Console.ReadLine();

            User found = users.Find(u => u.Username == selected);

            if (found == null)
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

            found.Password = newPassword;
            Console.WriteLine("Password updated for " + found.Username);
        }

        public static void DeactUser(List<User> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("No Record found");
                return;
            }
            Console.WriteLine("\nACCOUNTS");

            foreach (var user in users)
            {
                Console.WriteLine("Username: " + user.Username);
            }

            Console.WriteLine("\nDEACTIVATING USERS");
            Console.Write("Enter a username to deactivate: ");
            var keyword = Console.ReadLine().ToLower();

            User found = users.Find(u => u.Username.ToLower() == keyword);

            if (found == null)
                Console.WriteLine("No Record found");
            else
            {
                Console.Write("Do you wish to deactivate this user? (Y/N): ");
                string answer = Console.ReadLine().Trim().ToLower();

                if (answer == "y")
                {
                    found.IsActive = false;
                    Console.WriteLine("User deactivated.");
                }
                else
                    Console.WriteLine("User has not been deactivated");
            }
        }

        public static void DisplayAllUsers(List<User> users)
        {
            if (users.Count == 0)
                Console.WriteLine("No Record found");

            foreach (var user in users)
            {
                Console.WriteLine();
                Console.WriteLine("Username: " + user.Username);
                Console.WriteLine("Status: " + (user.IsActive ? "Active" : "Deactivated"));
            }
        }

        public static void DisplayInactiveUsers(List<User> users)
        {
            foreach (var user in users)
            {
                if (!user.IsActive)
                    Console.WriteLine("\nUsername: " + user.Username);
            }
        }

        public static void DisplayActiveUsers(List<User> users)
        {
            foreach (var user in users)
            {
                if (user.IsActive)
                    Console.WriteLine("\nUsername: " + user.Username);
            }
        }

        public static void DisplayProducts(List<Warehouse> products)
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
    } 
}
public class Warehouse
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }

    public static void AddProduct(List<Warehouse> products)
        {

            var option = "\nPlease select an option" +
                         "\n1.Add Products" +
                         "\n2.Display Products" +
                         "\n3.Logout";

            Console.WriteLine(option);
            Console.Write("Choose an Option:");
            var input = Convert.ToInt32(Console.ReadLine());

            switch (input)
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

            Console.Write("Please enter the name of the product:");
            var productName = Console.ReadLine();

            Console.Write("Please enter the quantity of the product:");
            var productQuantity = Convert.ToInt32(Console.ReadLine());

            Warehouse Neworders = new Warehouse();
            Neworders.ProductName = productName;
            Neworders.Quantity = productQuantity;
            products.Add(Neworders);
        }

        public static void DisplayWarehouse()
        {
            Console.Write("Enter your username:");
            var username = Console.ReadLine();
            Console.Write("Enter your password:");
            var password = Console.ReadLine();
            Console.WriteLine();
        }

        public static void UserInfo(List<Warehouse> warehouse)
        {
            if (warehouse.Count == 0)
                Console.WriteLine("No Record found");

            Console.WriteLine("\nACCOUNTS");
            for (int i = 0; i < warehouse.Count; i++)
            {
                Console.WriteLine($"{i}. Username: " + warehouse[i].ProductName);
            }
        }
}