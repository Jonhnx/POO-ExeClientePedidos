using ExFixEnumComp.Entities;
using ExFixEnumComp.Entities.Enums;
using System;
using System.Globalization;

namespace ExFixEnumComp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());
            Order order = new Order(orderStatus, client);

            Console.Write("How many items to this order? ");
            int mi = int.Parse(Console.ReadLine());
            for (int i = 1; i <= mi; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string nameP = Console.ReadLine();
                Console.Write("Product Price: ");
                double priceP = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantityP = int.Parse(Console.ReadLine());
                Product product = new Product(nameP, priceP);
                OrderItem orderItem = new OrderItem(quantityP, priceP, product);
                order.AddItem(orderItem);
            }

            Console.WriteLine(order);
        }
    }
}
