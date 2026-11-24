using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOPGROUPMAIN;

namespace ConsoleApp4
{
    public class User
    {
        public string order { get; set; }
        public int Quantity { get; set; }

        public static void UserInfo(List<Warehouse> warehouseUser, List<Admin> users, List<User> userProductOrders)
        {
            var keepRunning = true;

            while (keepRunning)
            {
                if (warehouseUser.Count == 0)
                {
                    Console.WriteLine("\nNo Record found");
                    return;
                }

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

                while (true)
                {
                    Console.Write("\nPlease enter the quantity of the product you want to order: ");
                    var quantity = Convert.ToInt32(Console.ReadLine());

                    if (quantity <= 0)
                    {
                        Console.WriteLine("\nQuantity cannot be zero or negative");
                        return;
                    }

                    if (quantity > warehouseUser[selected - 1].Quantity)
                    {
                        Console.WriteLine("\nInsufficient quantity available.");
                        Console.Write("Do you wish to enter a valid quantity? (Y/N): ");
                        var answer = Console.ReadLine().ToLower().Trim();

                        if (answer == "y")
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Order has not been placed.");
                            keepRunning = false;
                            return;
                        }
                    }

                    Console.WriteLine("\nOrder details");
                    Console.WriteLine("Product: " + warehouseUser[selected - 1].ProductName);
                    Console.WriteLine("Quantity: " + quantity);

                    warehouseUser[selected - 1].Quantity -= quantity;
                    User orders = new User();
                    orders.order = warehouseUser[selected - 1].ProductName;
                    orders.Quantity = quantity;
                    userProductOrders.Add(orders);

                    Console.WriteLine("\nOrder has been placed successfully.");

                    Console.Write("Do you want to order again? (Y/N): ");
                    var orderAnswer = Console.ReadLine().ToLower().Trim();

                    if (orderAnswer != "y")
                    {
                        keepRunning = false;
                    }
                    break;
                }
            }
        }

        public static void DisplayUserOrders(List<User> userProductOrders)
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
