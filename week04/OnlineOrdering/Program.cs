using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Phoenix", "Arizona", "USA");
        Customer customer1 = new Customer("Allison Rose", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "P1001", 25.99, 2));
        order1.AddProduct(new Product("Keyboard", "P1002", 45.50, 1));
        order1.AddProduct(new Product("USB Cable", "P1003", 8.75, 3));

        Address address2 = new Address("55 Queen Street", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("James Carter", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "P2001", 199.99, 1));
        order2.AddProduct(new Product("Laptop Stand", "P2002", 34.95, 2));

        Console.WriteLine("ORDER 1");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():F2}");
        Console.WriteLine();

        Console.WriteLine("ORDER 2");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():F2}");
    }
}