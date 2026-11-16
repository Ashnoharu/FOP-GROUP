using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http.Headers;

namespace FOPGROUPMAIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            List<Warehouse> warehouseUser = new List<Warehouse>();
            List<string> item = new List<string>();
            List<string> orders = new List<string>();

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
                        User.AddUser(users, warehouseUser);
                        AdminConditions(users, warehouseUser);
                        keepRunning = false;
                        break;
                    case 2:
                        User.AddUser(users, warehouseUser);
                        WarehouseConditions(warehouseUser, users);
                        keepRunning = false;
                        break;
                    case 3:
                        UserConditions(users, warehouseUser, item, orders);
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        public static void AdminConditions(List<User> users, List<Warehouse> warehouseUser)
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
                        User.SetNewPassword(users);
                        break;
                    case 2:
                        User.DeactUser(users);
                        break;
                    case 3:
                        User.AddUser(users, warehouseUser);
                        break;
                    case 4:
                        User.DisplayAllUsers(users);
                        break;
                    case 5:
                        User.DisplayInactiveUsers(users);
                        break;
                    case 6:
                        User.DisplayActiveUsers(users);
                        break;
                    case 7:
                        User.DisplayProducts(warehouseUser);
                        break;
                    case 8:
                        User.DisplayOrders(warehouseUser);
                        break;
                    case 9:
                        Console.WriteLine("Logging out...");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        public static void WarehouseConditions(List<Warehouse> warehouseUser, List<User> users)
        {
            var keepRunning = true;
            while (keepRunning)
            {
                var selectedOrder = "Please Select a user role to login:" +
                                    "\n1. Add Products" +
                                    "\n2. Display Products" +
                                    "\n3. Logout";

                Console.WriteLine(selectedOrder);
                Console.Write("\nEnter a number:");
                var input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Warehouse.AddProduct(warehouseUser, users);
                        break;
                    case 2:
                        Warehouse.DisplayWarehouse(warehouseUser, users);
                        break;
                    case 3:
                        Console.WriteLine("Logging out...");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        public static void UserConditions(List<User> users, List<Warehouse> products, List<string> item, List<string> orders)
        {
            var keepRunning = true;
            while (keepRunning)
            {
                var selectedOrder = "Please Select a user role to login:" +
                                    "\n1. Place Order" +
                                    "\n2. Display Orders" +
                                    "\n3. Logout";
                Console.WriteLine(selectedOrder);
                Console.Write("\nEnter a number:");
                var input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        Console.WriteLine("Logging out...");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}