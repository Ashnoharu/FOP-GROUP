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
            List<Admin> users = new List<Admin>();
            List<Warehouse> warehouseUser = new List<Warehouse>();
            List<User> userOrders = new List<User>();  
            
            Console.WriteLine("SELECTION MENU");
            Login(users, warehouseUser, userOrders);
        }
        public static void Login(List<Admin> users, List<Warehouse> warehouseUser, List<User> userOrders)
        {
            var keepRunning = true;
            var attempts = 3;
            while (keepRunning)
            {
                var selectedRoles = "\nPlease Select a user role to login:" +
                                    "\n1. Admin" +
                                    "\n2. Warehouse" +
                                    "\n3. User" +
                                    "\n4. Log Out";

                Console.WriteLine(selectedRoles);
                Console.Write("\nEnter a number:");
                int input;

                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("\nInvalid input, please try again.");
                    continue;
                }

                switch (input)
                {
                    case 1:
                        Admin.AddUser(users, warehouseUser);
                        AdminConditions(users, warehouseUser, userOrders);
                        keepRunning = false;
                        break;
                    case 2:
                        Admin.AddUser(users, warehouseUser);
                        WarehouseConditions(users, warehouseUser, userOrders);
                        keepRunning = false;
                        break;
                    case 3:
                        UserConditions(users, warehouseUser, userOrders);
                        keepRunning = false;
                        break;
                    case 4:
                        Console.WriteLine("\nLogging Out...");
                        keepRunning = false;
                        break;
                    default:
                        attempts--;
                        if (attempts > 0)
                        {
                            Console.WriteLine($"Invalid input. {attempts} attempt(s) left.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. No attempts left.");
                            keepRunning = false;
                        }
                        break;
                }
            }
        }
        public static void AdminConditions(List<Admin> users, List<Warehouse> warehouseUser, List<User> userOrders)
        {
            var keepRunningAdmin = true;
            while (keepRunningAdmin)
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
                int input;

                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("\nInvalid input, please try again.");
                }

                switch (input)
                {
                    case 1:
                        Admin.SetNewPassword(users);
                        break;
                    case 2:
                        Admin.DeactivateUser(users);
                        break;
                    case 3:
                        Admin.AddUser(users, warehouseUser);
                        break;
                    case 4:
                        Admin.DisplayAllUsers(users);
                        break;
                    case 5:
                        Admin.DisplayInactiveUsers(users);
                        break;
                    case 6:
                        Admin.DisplayActiveUsers(users);
                        break;
                    case 7:
                        Admin.DisplayProducts(warehouseUser);
                        break;
                    case 8:
                        Admin.DisplayOrders(userOrders);
                        break;
                    case 9:
                        Console.WriteLine("Logging out...");
                        keepRunningAdmin = false;
                        Login(users, warehouseUser, userOrders);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        public static void WarehouseConditions(List<Admin> users, List<Warehouse> warehouseUser, List<User> userOrders)
        {
            var keepRunningWarehouse = true;
            while (keepRunningWarehouse)
            {
                var selectedOrder = "\nPlease select an option:" +
                                    "\n1. Add Products" +
                                    "\n2. Display Products" +
                                    "\n3. Logout";

                Console.WriteLine(selectedOrder);
                Console.Write("\nEnter a number:");
                int input;

                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("\nInvalid input, please try again.");
                }

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
                        keepRunningWarehouse = false;
                        Login(users, warehouseUser, userOrders);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        public static void UserConditions(List<Admin> users, List<Warehouse> warehouseUser, List<User> userProductOrders)
        {
            var keepRunningUser = true;
            while (keepRunningUser)
            {
                var selectedOrder = "\nPlease select an option:" +
                                    "\n1. Place Order" +
                                    "\n2. Display Orders" +
                                    "\n3. Logout";
                Console.WriteLine(selectedOrder);
                Console.Write("\nEnter a number:");
                int input;

                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("\nInvalid input, please try again.");
                }
                switch (input)
                {
                    case 1:
                        User.UserInfo(warehouseUser, users, userProductOrders);
                        break;
                    case 2:
                        User.DisplayUserOrders(userProductOrders);
                        break;
                    case 3:
                        Console.WriteLine("Logging out...");
                        keepRunningUser = false;
                        Login(users, warehouseUser, userProductOrders);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}