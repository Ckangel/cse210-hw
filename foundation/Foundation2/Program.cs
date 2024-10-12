using System;
using System.Collections.Generic;

// Class representing a product
class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetPackingLabel()
    {
        return $"{_name} (ID: {_productId})";
    }
}

// Class representing an address
class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

// Class representing a customer
class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"{_name}\n{_address.GetFullAddress()}";
    }
}

// Class representing an order
class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = 0;

        foreach (var product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        // Determine shipping cost based on whether the customer lives in the USA
        decimal shippingCost = _customer.LivesInUSA() ? 5m : 35m;
        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (var product in _products)
        {
            packingLabel += product.GetPackingLabel() + "\n";
        }
        return packingLabel.Trim();
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create an address for a USA customer
        Address addressUSA = new Address("123 Main St", "New York", "NY", "USA");
        Customer customerUSA = new Customer("Joseph Derry", addressUSA);

        // Create an address for a non-USA customer
        Address addressNonUSA = new Address("36 Microphone St", "Mataheko", "GH", "Ghana");
        Customer customerNonUSA = new Customer("Adekemi Ajeigbe", addressNonUSA);

        // Create products
        Product product1 = new Product("Widget", "W123", 10m, 2); // $10 * 2 = $20
        Product product2 = new Product("Gadget", "G456", 15m, 1); // $15 * 1 = $15
        Product product3 = new Product("Doodad", "D789", 5m, 3);  // $5 * 3 = $15

        // Create an order for a USA customer
        Order orderUSA = new Order(customerUSA);
        orderUSA.AddProduct(product1);
        orderUSA.AddProduct(product2);

        // Create an order for a non-USA customer
        Order orderNonUSA = new Order(customerNonUSA);
        orderNonUSA.AddProduct(product2);
        orderNonUSA.AddProduct(product3);

        // Display order details for the USA customer
        Console.WriteLine("Order for USA Customer:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(orderUSA.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(orderUSA.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${orderUSA.GetTotalCost():0.00}\n");

        // Display order details for the non-USA customer
        Console.WriteLine("Order for Non-USA Customer:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(orderNonUSA.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(orderNonUSA.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${orderNonUSA.GetTotalCost():0.00}");
    }
}