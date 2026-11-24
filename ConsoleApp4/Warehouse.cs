using System;
using System.Collections.Generic;
using ConsoleApp4;
using FOPGROUPMAIN;

public class Warehouse
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public Admin CreatedBy { get; set; }

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

    public static void DisplayOrders(List<User> userProductOrders)
    {
        if (userProductOrders.Count == 0)
            Console.WriteLine("\nNo Record found");

        foreach (var orders in userProductOrders)
        {
            Console.WriteLine("\nProduct name: " + orders.order);
            Console.WriteLine("Quantity: " + orders.Quantity);
        }
    }

    public static void AddProduct(List<Warehouse> warehouseUser, List<Admin> users)
    {
        var keepRunning = true;
        while (keepRunning)
        {
            Console.Write("Please enter the number of products you want to add: ");
            var productsNum = Convert.ToInt32(Console.ReadLine());

            if (productsNum <= 0)
            {
                Console.WriteLine("\nPlease enter a number greater than 0.");
                continue;
            }

            var newItems = new List<Warehouse>();
            var invalidQuantity = false;

            for (int i = 0; i < productsNum; i++)
            {
                Console.Write("\nPlease enter the name of the product: ");
                var productName = Console.ReadLine().Trim();

                if (productName == "")
                {
                    Console.WriteLine("\nProduct cannot be empty.");
                    return;
                }

                foreach (var item in warehouseUser)
                {
                    if (item.ProductName == productName)
                    {
                        Console.WriteLine("\nProduct cannot be the same.");
                        return;
                    }
                }

                foreach (var item in newItems)
                {
                    if (item.ProductName == productName)
                    {
                        Console.WriteLine("\nProduct cannot be the same.");
                        return;
                    }
                }

                Console.Write("Please enter the quantity of the product: ");
                var productQuantity = Convert.ToInt32(Console.ReadLine());

                if (productQuantity >= 1000000)
                {
                    Console.WriteLine("\nExcessive amount of quantity please lower the value.");
                    invalidQuantity = true;
                    return;
                }

                Warehouse orders = new Warehouse();
                orders.ProductName = productName;
                orders.Quantity = productQuantity;
                orders.Date = DateTime.Now;
                orders.CreatedBy = Admin.CurrentUser;
                newItems.Add(orders);
            }

            if (invalidQuantity)
            {
                continue;
            }

            warehouseUser.AddRange(newItems);

            Console.WriteLine("Stored Succesfully");

            Console.Write("\nDo you want to store product again? (Y/N): ");
            var answer = Console.ReadLine().ToLower().Trim();

            if (answer != "y")
            {
                keepRunning = false;
            }
        }
    }

    public static void DisplayWarehouse(List<Warehouse> warehouseUser, List<Admin> users)
    {
        if (warehouseUser.Count == 0)
            Console.WriteLine("No Record found");

        Console.WriteLine("\nUSER LIST");
        foreach (var orders in warehouseUser)
        {
            Console.WriteLine("\nProduct name: " + orders.ProductName);
            Console.WriteLine("Quantity: " + orders.Quantity);
            Console.WriteLine("Active: " + (orders.CreatedBy.IsActive ? "Yes" : "No"));
            Console.WriteLine("Created Date: " + orders.Date);
            Console.WriteLine("Created By: " + orders.CreatedBy.Username);
        }
    }
}