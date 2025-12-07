using System.Collections.Generic;

public class Order
{
    public Customer _customer;
    private List<(Product product, int quantity)> _products
        = new List<(Product product, int quantity)>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product p, int quantity)
    {
        _products.Add((p, quantity));
    }

    public double CalculateTotal()
    {
        double total = 0;

        foreach (var item in _products)
        {
            total += item.product._price * item.quantity;
        }

        if (_customer._address.LivesInUSA())
            total += 5;
        else
            total += 35;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL:\n";

        foreach (var item in _products)
        {
            label += $"{item.product._name} (ID: {item.product._productId}) x{item.quantity}\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        string label = "SHIPPING LABEL:\n";
        label += $"{_customer._name}\n";
        label += _customer._address.GetFullAddress();
        return label;
    }
}
