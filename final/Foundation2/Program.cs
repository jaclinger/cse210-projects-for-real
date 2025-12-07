using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Oak Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Bruce Wayne", address1);

        Product product1 = new Product("Laptop", "L1001", 999.99);
        Product product2 = new Product("Mouse", "M2002", 29.99);
        Product product3 = new Product("Keyboard", "K3003", 59.99);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1, 1);
        order1.AddProduct(product2, 2);
        order1.AddProduct(product3, 1);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotal():0.00}");
    }
}
