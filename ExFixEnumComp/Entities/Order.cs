using ExFixEnumComp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ExFixEnumComp.Entities
{
    class Order
    {
        public DateTime Moment { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order() { }
        public Order(OrderStatus status, Client client)
        {
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem items)
        {
            OrderItems.Add(items);
        }
        public void RemoveItem(OrderItem items)
        {
            OrderItems.Remove(items);
        }
        public double Total()
        {
            double sum = 0.0;
            foreach(OrderItem item in OrderItems)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder s1 = new StringBuilder();
            s1.AppendLine("ORDER SUMMARY:");
            s1.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm/ss"));
            s1.AppendLine("Order status: " + Status);
            s1.Append("Client: " + Client.Name);
            s1.AppendLine("(" + Client.BirthDate.ToString("dd/MM/yyyy") + ")" + Client.Email);
            s1.AppendLine("Order Items: ");
            foreach(OrderItem order in OrderItems)
            {
                s1.Append(order.Product.Name + ", ");
                s1.Append("$" + order.Product.Price + ", ");
                s1.Append("Quantity: " + order.Quantity + ", ");
                s1.AppendLine("Subtotal: " + order.SubTotal());
            }
            s1.Append("Total price: " + Total().ToString("F2", CultureInfo.InvariantCulture));
            return s1.ToString();
        }
    }
}
