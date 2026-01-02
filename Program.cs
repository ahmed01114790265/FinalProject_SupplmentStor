using FinalProject_SupplmentStor;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Product> products = new List<Product>();
    static int idCounter = 1;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Supplement Products System ===");
            Console.WriteLine("1- Add Product");
            Console.WriteLine("2- Update Product");
            Console.WriteLine("3- Delete Product");
            Console.WriteLine("4- View All Products");
            Console.WriteLine("5- View Product Details");
            Console.WriteLine("6- Search Products");
            Console.WriteLine("0- Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddProduct(); break;
                case "2": UpdateProduct(); break;
                case "3": DeleteProduct(); break;
                case "4": ViewAllProducts(); break;
                case "5": ViewProductDetails(); break;
                case "6": SearchProducts(); break;
                case "0": return;
                default: Console.WriteLine("Invalid choice"); break;
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    // 1- Add
    static void AddProduct()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Flavor: ");
        string flavor = Console.ReadLine();

        Console.Write("Category: ");
        string category = Console.ReadLine();

        Console.Write("Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        products.Add(new Product
        {
            Id = idCounter++,
            Name = name,
            Flavor = flavor,
            Category = category,
            Price = price,
            Quantity = quantity
        });

        Console.WriteLine("Product added successfully");
    }

    // 2- Update
    static void UpdateProduct()
    {
        Console.Write("Enter Product ID: ");
        int id = int.Parse(Console.ReadLine());

        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            Console.WriteLine("Product not found ");
            return;
        }

        Console.Write("New Name: ");
        product.Name = Console.ReadLine();

        Console.Write("New Flavor: ");
        product.Flavor = Console.ReadLine();

        Console.Write("New Category: ");
        product.Category = Console.ReadLine();

        Console.Write("New Price: ");
        product.Price = decimal.Parse(Console.ReadLine());

        Console.Write("New Quantity: ");
        product.Quantity = int.Parse(Console.ReadLine());

        Console.WriteLine("Product updated successfully ✅");
    }

    // 3- Delete
    static void DeleteProduct()
    {
        Console.Write("Enter Product ID: ");
        int id = int.Parse(Console.ReadLine());

        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            Console.WriteLine("Product not found ");
            return;
        }

        products.Remove(product);
        Console.WriteLine("Product deleted successfully");
    }

    // 4- View All
    static void ViewAllProducts()
    {
        if (!products.Any())
        {
            Console.WriteLine("No products available");
            return;
        }

        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id} - {p.Name} | {p.Flavor} | {p.Category} | {p.Price} EGP");
        }
    }

    // 5- View Details
    static void ViewProductDetails()
    {
        Console.Write("Enter Product ID: ");
        int id = int.Parse(Console.ReadLine());

        var p = products.FirstOrDefault(p => p.Id == id);
        if (p == null)
        {
            Console.WriteLine("Product not found ");
            return;
        }

        Console.WriteLine($"Name: {p.Name}");
        Console.WriteLine($"Flavor: {p.Flavor}");
        Console.WriteLine($"Category: {p.Category}");
        Console.WriteLine($"Price: {p.Price} EGP");
        Console.WriteLine($"Quantity: {p.Quantity}");
    }

    // 6- Search
    static void SearchProducts()
    {
        Console.Write("Search by Name / Flavor / Category: ");
        string keyword = Console.ReadLine().ToLower();

        var result = products.Where(p =>
            p.Name.ToLower().Contains(keyword) ||
            p.Flavor.ToLower().Contains(keyword) ||
            p.Category.ToLower().Contains(keyword)
        ).ToList();

        if (!result.Any())
        {
            Console.WriteLine("No matching products ");
            return;
        }

        foreach (var p in result)
        {
            Console.WriteLine($" Name:{p.Name} | Flavor:{p.Flavor}|");
        }
    }
}
