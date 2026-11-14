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
            List<Warehouse> products = new List<Warehouse>();
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
                        User.AddUser(users);
                        AdminConditions(users,products, item, orders);
                        keepRunning = false;
                        break;
                    case 2:
                        keepRunning = false;
                        break;
                    case 3:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        public static void AdminConditions(List<User> users, List<Warehouse> products, List<string> item, List<string> orders)
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
                        User.AddUser(users);
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
                        User.DisplayProducts(products);
                        break;
                    case 8:
                        User.DisplayOrders(orders);
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
        public static void WarehouseConditions(List<Warehouse> products)
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
                        Warehouse.AddProduct(products);
                        break;
                    case 2:
                        Warehouse.DisplayWarehouse();
                        break;
                    case 3:
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