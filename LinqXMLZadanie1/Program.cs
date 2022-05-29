using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqXMLZadanie1
{
    public class Program
    {
        static void Main(string[] args)
        { 
        //    CustomersToXML.SaveCustomersToXML();
        //    var customers = XDocument.Load("Customers.xml");
            string rok = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            string stream;
            do
            {
                stream = Console.ReadLine();
                sb.AppendLine(stream);
            
            } while (stream != "" || stream != string.Empty);
            
            var Customers = XDocument.Parse(sb.ToString());

            List<Customer> list = new List<Customer>();

            foreach (var item in from customer in Customers.Descendants("Customers").Descendants("Customer") select customer)
            {
                var lista = item.Descendants("Orders").Descendants("Order").ToList();
                if (lista.Count > 0)
                {
                    List<Orders> orders = new List<Orders>();
                    foreach (var order in lista)
                    {
                        var orderDate = order.Element("OrderDate").Value;
                        if (!orderDate.StartsWith(rok))
                            continue;

                        orders.Add(new Orders
                        {
                            OrderID = order.Element("OrderID").Value,
                            OrderDate = orderDate,
                            Total = order.Element("Total").Value
                        });
                    }
                    if (orders.Count > 0)
                    {
                        list.Add(new Customer
                        {
                            CustomerID = item.Element("CustomerID").Value,
                            CompanyName = item.Element("CompanyName").Value,
                            Country = item.Element("Country").Value,
                            City = item.Element("City").Value,
                            Orders = orders
                        });
                    }
                }
            }
            var sortedList = list.OrderBy(q => q.Country).ThenBy(q => q.City).ThenBy(q => q.CompanyName);

            if (list.Count <= 0)
                Console.WriteLine("empty");
            else
            {
                foreach (var customer in sortedList)
                    Console.WriteLine(customer.CompanyName);
            }
        }
    }
}
