using System;
using System.Collections.Generic;
using FOPGROUPMAIN;

namespace FOPGROUPMAIN
{
    public class User
    {
        public static User CurrentUser;
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;

        public static void AddUser(List<User> users, List<Warehouse> warehouseUser)
        {
            Console.Write("Enter your username: ");
            var username = Console.ReadLine();

            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    Console.WriteLine("\nUser existing detected, enter password to login.");
                    Console.Write("Enter your password to login: ");
                    var loginPassword = Console.ReadLine();

                    if (user.Password == loginPassword)
                    {
                        CurrentUser = user;
                        Console.WriteLine("\nLogin successful.");
                    }
                    else
                    {
                        Console.WriteLine("\nWrong password detected creat new account.");
                        Console.WriteLine();
                        User.AddUser(users, warehouseUser);
                    }
                    return;
                }
            }

            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            User newUser = new User();
            newUser.Username = username;
            newUser.Password = password;
            users.Add(newUser);
            CurrentUser = newUser;

            Console.WriteLine("\nAccount created.");
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
                Console.WriteLine($"Username: " + users[i].Username);
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
                else
                    Console.WriteLine("No Inactive User");
            }
        }

        public static void DisplayActiveUsers(List<User> users)
        {
            foreach (var user in users)
            {
                if (user.IsActive)
                    Console.WriteLine("\nUsername: " + user.Username);
                else
                    Console.WriteLine("No Inactive User");
            }
        }

        public static void DisplayProducts(List<Warehouse> warehouseUser)
        {
            var i = 1;
            Console.WriteLine("\nPRODUCTS");

            foreach (var products in warehouseUser)
            {
                    Console.WriteLine(i++ + ". Product name: " + products.ProductName);
                    Console.WriteLine("Quantity: " + products.Quantity);
            }
        }

        public static void DisplayOrders(List<Info> userProductOrders)
        {
            if (userProductOrders.Count == 0)
                Console.WriteLine("\nNo Record found");

            foreach (var orders in userProductOrders)
            {
                Console.WriteLine("\nProduct name: " + orders.order);
                Console.WriteLine("Quantity: " + orders.Quantity);
            }
        }
    } 
}
public class Warehouse
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public User CreatedBy { get; set; }

    public static void AddProduct(List<Warehouse> warehouseUser, List<User> users)
    {
        var keepRunning = true;
        while (keepRunning)
        {
            var remaining = 5 - warehouseUser.Count;

            if (remaining <= 0)
            {
                Console.WriteLine("Storage is full, maximum of 5 items reached.");
                return;
            }

            Console.WriteLine("\nRemaining storage space: " + remaining);
            Console.Write("Please enter the number of products you want to add: ");
            var productsNum = Convert.ToInt32(Console.ReadLine());

            if (productsNum <= 0)
            {
                Console.WriteLine("Please enter a number greater than 0.");
                continue;
            }

            if (productsNum > remaining)
            {
                Console.WriteLine("Not enough space. You can only add " + remaining + " more item(s), please try again.");
                continue;
            }

            var newItems = new List<Warehouse>();
            var invalidQuantity = false;

            for (int i = 0; i < productsNum; i++)
            {
                Console.Write("\nPlease enter the name of the product: ");
                var productName = Console.ReadLine();

                Console.Write("Please enter the quantity of the product: ");
                var productQuantity = Convert.ToInt32(Console.ReadLine());

                if (productQuantity >= 1000000)
                {
                    Console.WriteLine("Excessive amount of quantity please lower the value.");
                    invalidQuantity = true;
                    break;
                }

                Warehouse orders = new Warehouse();
                orders.ProductName = productName;
                orders.Quantity = productQuantity;
                orders.Date = DateTime.Now;
                orders.CreatedBy = User.CurrentUser;
                newItems.Add(orders);
            }

            if (invalidQuantity)
            {
                continue;
            }

            warehouseUser.AddRange(newItems);

            Console.WriteLine("Stored Succesfully");

            if (warehouseUser.Count >= 5)
            {
                Console.WriteLine("Storage is now full.");
                return;
            }

            Console.Write("Do you want to store product again? (Y/N): ");
            var answer = Console.ReadLine().ToLower().Trim();

            if (answer != "y")
            {
                keepRunning = false;
            }
        }
    }

    public static void DisplayWarehouse(List <Warehouse> warehouseUser, List<User> users)
        {
            if (warehouseUser.Count == 0)
            Console.WriteLine("No Record found");

        foreach (var orders in warehouseUser)
            {
                Console.WriteLine("\nProduct name: " + orders.ProductName);
                Console.WriteLine("Quantity: " + orders.Quantity);
                Console.WriteLine("Active: "  + (orders.CreatedBy.IsActive ? "Yes" : "No"));
                Console.WriteLine("Created Date: " + orders.Date);
                Console.WriteLine("Created By: " + orders.CreatedBy.Username);
            }
        }
}
public class Info 
{
    public string order { get; set; }
    public int Quantity { get; set; }
    public static void UserInfo(List<Warehouse> warehouseUser, List<User> users, List<Info> userProductOrders)
    {
        if (warehouseUser.Count == 0)
        {
            Console.WriteLine("\nNo Record found");
        }
        else
        {
            var i = 1;
            Console.WriteLine("\nPRODUCTS");

            foreach (var products in warehouseUser)
            {
                Console.WriteLine(i++ + ". Product name: " + products.ProductName);
                Console.WriteLine("Quantity: " + products.Quantity);
            }
            Console.Write("\nPlease enter the number of the product you want to order: ");
            var selected = Convert.ToInt32(Console.ReadLine());

            if (selected < 1 || selected > warehouseUser.Count)
            {
                Console.WriteLine("\nInvalid selection.");
                return;
            }

            Console.Write("\nPlease enter the quantity of the product you want to order: ");
            var quantity = Convert.ToInt32(Console.ReadLine());

            switch (selected)
            {
                case 1:
                    if (quantity > warehouseUser[0].Quantity)
                    {
                        Console.WriteLine("Insufficient quantity available.");
                        return;
                    }
                    Console.WriteLine("Order details");
                    Console.WriteLine("Product: " + warehouseUser[0].ProductName);
                    Console.WriteLine("Quantity: " + quantity);
                    break;
                case 2:
                    if (quantity > warehouseUser[1].Quantity)
                    {
                        Console.WriteLine("Insufficient quantity available.");
                        return;
                    }
                    Console.WriteLine("Order details");
                    Console.WriteLine("Product: " + warehouseUser[1].ProductName);
                    Console.WriteLine("Quantity: " + quantity);
                    break;
                case 3:
                    if (quantity > warehouseUser[2].Quantity)
                    {
                        Console.WriteLine("Insufficient quantity available.");
                        return;
                    }
                    Console.WriteLine("Order details");
                    Console.WriteLine("Product: " + warehouseUser[2].ProductName);
                    Console.WriteLine("Quantity: " + quantity);
                    break;
                case 4:
                    if (quantity > warehouseUser[3].Quantity)
                    {
                        Console.WriteLine("\nInsufficient quantity available.");
                        return;
                    }
                    Console.WriteLine("Order details");
                    Console.WriteLine("Product: " + warehouseUser[3].ProductName);
                    Console.WriteLine("Quantity: " + quantity);
                    break;
                case 5:
                    if (quantity > warehouseUser[4].Quantity)
                    {
                        Console.WriteLine("Insufficient quantity available.");
                        return;
                    }
                    Console.WriteLine("Order details");
                    Console.WriteLine("Product: " + warehouseUser[4].ProductName);
                    Console.WriteLine("Quantity: " + quantity);
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    return;
            }
            warehouseUser[selected - 1].Quantity -= quantity;
            Info orders = new Info();
            orders.order = warehouseUser[selected - 1].ProductName;
            orders.Quantity = quantity;
            userProductOrders.Add(orders);

            Console.WriteLine("\nOrder has been placed successfully.");
        }
    }
    public static void DisplayUserOrders(List<Info> userProductOrders)
    {
        if (userProductOrders.Count == 0)
            Console.WriteLine("\nNo Record found");

        foreach (var orders in userProductOrders)
        {
            Console.WriteLine("\nProduct name: " + orders.order);
            Console.WriteLine("Quantity: " + orders.Quantity);
        }
    }
}