using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqXMLZadanie1
{
    public static class CustomersToXML
    {
        public static void SaveCustomersToXML()
        {
            var xml = new XDocument(
                new XElement("Customers",
                new XElement("Customer",
                    new XElement("CustomerID", "KRAHA"),
                    new XElement("CompanyName", "Krakowski Handelek"),
                    new XElement("City", "Kraków"),
                    new XElement("Country", "Poland"),
                    new XElement("Orders")
                    ),
                new XElement("Customer",
                    new XElement("CustomerID", "ANATR"),
                    new XElement("CompanyName", "Ana Trujillo Emparedados y helados"),
                    new XElement("City", "Mexico"),
                    new XElement("Country", "Mexico"),
                    new XElement("Orders",
                        new XElement("Order",
                            new XElement("OrderID","10308"),
                            new XElement("OrderDate", "2014-09-18T00:00:00"),
                            new XElement("Total","88.80")
                            )
                        )
                    ),
                new XElement("Customer",
                    new XElement("CustomerID", "ANTON"),
                    new XElement("CompanyName", "Antonio Moreno Taqueria"),
                    new XElement("City", "Rio de Janeiro"),
                    new XElement("Country", "Brazil"),
                    new XElement("Orders",
                    new XElement("Order",
                            new XElement("OrderID", "10365"),
                            new XElement("OrderDate", "2014-11-27T00:00:00"),
                            new XElement("Total", "403.20")
                        ),
                    new XElement("Order",
                            new XElement("OrderID", "10507"),
                            new XElement("OrderDate", "2015-04-15T00:00:00"),
                            new XElement("Total", "749.06")
                            )
                        )   
                    )             
                )
            );
            xml.Save("Customers.xml");
        }
    }
}
